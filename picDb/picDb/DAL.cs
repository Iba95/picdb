using picDb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Controls;

namespace picDb
{
    class DAL
    {
        private string connstr;
        private string Folder;

        public DAL()
        {
            connstr = @"server=127.0.0.1;userid=root;password=;database=picdb;convert zero datetime=True";
            Folder = @"C:\Users\islam\Documents\Arbeit\FH\4 SEM\SWE 2\pics";
        }
        public PictureModel getPicture(int ID)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT picturemodel.ID,FileName, ExifVersion, Make, FNUmber, " +
                "ExposureTime, ISOSpeed, Title, Caption, CopyrightNotice, Creator, Keywords, Photographer " +
                "FROM `picturemodel` JOIN exifmodel ON EXIF = exifmodel.ID JOIN iptcmodel ON IPTC = iptcmodel.ID " +
                "JOIN photographer ON Photographer = photographer.ID Where picturemodel.ID = @ID;";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            PictureModel pic = new PictureModel();

            while (rdr.Read())
            {
                pic.ID = rdr.GetInt32("ID");
                pic.FileName = rdr.GetString("FileName");
                pic.EXIF.ExifVersion = rdr.GetInt32("ExifVersion");
                pic.EXIF.Make = rdr.GetString("Make");
                pic.EXIF.FNumber = rdr.GetInt32("FNUmber");
                pic.EXIF.ExposureTime = rdr.GetInt32("ExposureTime");
                pic.EXIF.ISOSpeed = rdr.GetInt32("ISOSpeed");
                pic.IPTC.Title = rdr.GetString("Title");
                pic.IPTC.Caption = rdr.GetString("Caption");
                pic.IPTC.CopyrightNotice = rdr.GetString("CopyrightNotice");
                pic.IPTC.Creator = rdr.GetString("Creator");
                pic.IPTC.Keywords = rdr.GetString("Keywords");
                pic.Photographer = getPhotographer(rdr.GetInt32("Photographer"));
            }
            return pic;
        }

        public List<PictureModel> getPictures()
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT * FROM picturemodel;";
            var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<PictureModel> pics = new List<PictureModel>();

            while (rdr.Read())
            {
                PictureModel pic = new PictureModel();
                pic.ID = rdr.GetInt32("ID");
                pic.FileName = rdr.GetString("FileName");
                pic.EXIF = new EXIFModel();
                pic.IPTC = new IPTCModel();
                pic.Photographer = new PhotographerModel();

                pics.Add(pic);
            }
            return pics;
        }

        public List<PictureModel> getPictures(string term)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT picturemodel.ID,FileName, ExifVersion, Make, FNUmber, "+
                "ExposureTime, ISOSpeed, Title, Caption, CopyrightNotice, Creator, Keywords, Photographer "+
                "FROM `picturemodel` JOIN exifmodel ON EXIF = exifmodel.ID JOIN iptcmodel ON IPTC = iptcmodel.ID "+
                "left JOIN photographer ON Photographer = photographer.ID WHERE FileName LIKE @term OR ExifVersion = @term " +
                "OR Title LIKE @term OR Make LIKE @term  OR FNUmber = @term OR ExposureTime = @term OR ISOSpeed = @term " +
                "OR Caption LIKE @term OR CopyrightNotice LIKE @term OR Creator LIKE @term OR Keywords LIKE @term " +
                "OR FirstName LIKE @term OR LastName LIKE @term OR Notes LIKE @term";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@term", "%"+ term + "%");
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<PictureModel> pics = new List<PictureModel>();

            while (rdr.Read())
            {
                PictureModel pic = new PictureModel();
                pic.ID = rdr.GetInt32("ID");
                pic.FileName = rdr.GetString("FileName");
                pic.EXIF = new EXIFModel();
                pic.IPTC = new IPTCModel();
                pic.Photographer = new PhotographerModel();

                pics.Add(pic);
            }
            return pics;

        }

        public void savePicture(PictureModel picture)
        {
            var con = new MySqlConnection(connstr);
            con.Open();

            var stmIPTC = "INSERT INTO `iptcmodel`(`Title`, `Caption`, `CopyrightNotice`, `Creator`, `Keywords`) " +
                "VALUES (@Title, @Caption, @CopyrightNotice, @Creator, @Keywords);select last_insert_id();";  
            var cmdIPTC = new MySqlCommand(stmIPTC, con);

            cmdIPTC.Parameters.AddWithValue("@Title", picture.IPTC.Title);
            cmdIPTC.Parameters.AddWithValue("@Caption", picture.IPTC.Caption);
            cmdIPTC.Parameters.AddWithValue("@CopyrightNotice", picture.IPTC.CopyrightNotice);
            cmdIPTC.Parameters.AddWithValue("@Creator", picture.IPTC.Creator);
            cmdIPTC.Parameters.AddWithValue("@Keywords", picture.IPTC.Keywords);
            cmdIPTC.Prepare();

            int idIPTC = Convert.ToInt32(cmdIPTC.ExecuteScalar());

            var stmPic = "INSERT INTO `picturemodel`(`FileName`, `EXIF`, `IPTC`) VALUES (@FileName,1,@IPTC);";
            var cmdPic = new MySqlCommand(stmPic, con);

            cmdPic.Parameters.AddWithValue("@FileName", picture.FileName);
            cmdPic.Parameters.AddWithValue("@IPTC", idIPTC);
            cmdPic.Prepare();
            cmdPic.ExecuteScalar();

        }
        public void updatePicture(PictureModel picture)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            //First Section
            var stm1 = "Select IPTC FROM `picturemodel` WHERE ID = @ID;";
            var cmd1 = new MySqlCommand(stm1, con);

            cmd1.Parameters.AddWithValue("@ID", picture.ID);
            cmd1.Prepare();

            using MySqlDataReader rdr = cmd1.ExecuteReader();
            PictureModel pic = new PictureModel();
            int idIPTC = 0;
            while (rdr.Read())
            {
                idIPTC = rdr.GetInt32("IPTC");
            }
            rdr.Close();

            //Second Section
            var stm2 = "UPDATE `iptcmodel` SET Title = @Title, Caption = @Caption, CopyrightNotice = @CopyrightNotice, " +
                "Creator = @Creator, Keywords = @Keywords WHERE ID = @ID;";
            var cmd2 = new MySqlCommand(stm2, con);

            cmd2.Parameters.AddWithValue("@ID", idIPTC);
            cmd2.Parameters.AddWithValue("@Title", picture.IPTC.Title);
            cmd2.Parameters.AddWithValue("@Caption", picture.IPTC.Caption);
            cmd2.Parameters.AddWithValue("@CopyrightNotice", picture.IPTC.CopyrightNotice);
            cmd2.Parameters.AddWithValue("@Creator", picture.IPTC.Creator);
            cmd2.Parameters.AddWithValue("@Keywords", picture.IPTC.Keywords);
            cmd2.Prepare();
            cmd2.ExecuteScalar();

            //Third Section
            var stm3 = "UPDATE `picturemodel` SET Photographer = @PID WHERE ID = @ID;";
            var cmd3 = new MySqlCommand(stm3, con);
            if (picture.Photographer != null)
            {
                cmd3.Parameters.AddWithValue("@ID", picture.ID);
                cmd3.Parameters.AddWithValue("@PID", picture.Photographer.ID);
                cmd3.Prepare();
                cmd3.ExecuteScalar();
            }

        }
        public void deletePicture(int ID)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            //First Section
            var stm1 = "Select IPTC FROM `picturemodel` WHERE ID = @ID;";
            var cmd1 = new MySqlCommand(stm1, con);

            cmd1.Parameters.AddWithValue("@ID", ID);
            cmd1.Prepare();

            using MySqlDataReader rdr = cmd1.ExecuteReader();
            PictureModel pic = new PictureModel();
            int idIPTC =0;
            while (rdr.Read())
            {
                idIPTC = rdr.GetInt32("IPTC");
            }
            rdr.Close();

            //Second Section
            var stm2 = "DELETE FROM `picturemodel` WHERE ID = @ID;";
            var cmd2 = new MySqlCommand(stm2, con);

            cmd2.Parameters.AddWithValue("@ID", ID);
            cmd2.Prepare();
            cmd2.ExecuteScalar();

            //Third Section
            var stm3 = "DELETE FROM `iptcmodel` WHERE ID = @ID;";
            var cmd3 = new MySqlCommand(stm3, con);

            cmd3.Parameters.AddWithValue("@ID", idIPTC);
            cmd3.Prepare();
            cmd3.ExecuteScalar();
        }

        public void sync()
        {
            var files = Directory.GetFiles(Folder, "*.*", SearchOption.AllDirectories).ToList();

            //List<string> imageFiles = new List<string>();
            List<PictureModel> pics = getPictures().ToList();
            foreach (PictureModel pic in pics)
            {
                if (!files.Contains(pic.FileName))
                {
                    deletePicture(pic.ID);
                }
                else
                {
                    files.Remove(pic.FileName);
                }
            }
            foreach (string file in files)
            {
                PictureModel picture = new PictureModel();
                picture.FileName = file;
                picture.EXIF = readEXIF();
                picture.IPTC = readIPTC();
                savePicture(picture);
            }
        }

        public PhotographerModel getPhotographer(int ID)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT * FROM `photographer` WHERE ID = @ID;";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            PhotographerModel photographer = new PhotographerModel();

            while (rdr.Read())
            {
                photographer.FirstName = rdr.GetString("FirstName");
                photographer.LastName = rdr.GetString("LastName");
                photographer.Birthday = DateTime.Parse(rdr["Birthday"].ToString());
                photographer.Notes = rdr.GetString("Notes");
            }
            return photographer;
        }

        public List<PhotographerModel> getPhotographers()
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT * FROM photographer;";
            var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<PhotographerModel> photographers = new List<PhotographerModel>();

            while (rdr.Read())
            {
                PhotographerModel photographer = new PhotographerModel();
                photographer.ID = rdr.GetInt32("ID");
                photographer.FirstName = rdr.GetString("FirstName");
                photographer.LastName = rdr.GetString("LastName");
                photographer.Birthday = DateTime.Parse(rdr["Birthday"].ToString());
                photographer.Notes = rdr.GetString("Notes");

                photographers.Add(photographer);
            }
            return photographers;
        }       

        public void savePhotographer(PhotographerModel photographer)
        {
            var con = new MySqlConnection(connstr);
            con.Open();

            var stm = "INSERT INTO `photographer`(`FirstName`, `LastName`, `Birthday`, `Notes`) " +
                "VALUES(@FirstName, @LastName, @Birthday, @Notes);";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@FirstName", photographer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", photographer.LastName);
            cmd.Parameters.AddWithValue("@Birthday", photographer.Birthday);
            cmd.Parameters.AddWithValue("@Notes", photographer.Notes);
            cmd.Prepare();

            cmd.ExecuteScalar();
        }
        public void updatePhotographer(PhotographerModel photographer)
        {
            var con = new MySqlConnection(connstr);
            con.Open();

            var stm = "UPDATE `photographer` SET `FirstName`=@FirstName,`LastName`=@LastName," +
                "`Birthday`=@Birthday,`Notes`=@Notes WHERE ID = @ID;";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", photographer.ID);
            cmd.Parameters.AddWithValue("@FirstName", photographer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", photographer.LastName);
            cmd.Parameters.AddWithValue("@Birthday", photographer.Birthday);
            cmd.Parameters.AddWithValue("@Notes", photographer.Notes);
            cmd.Prepare();

            cmd.ExecuteScalar();
        }

        public void deletePhotographer(int ID)
        {          
            var con = new MySqlConnection(connstr);
            con.Open();

            var stm = "DELETE FROM `photographer` WHERE ID = @ID;";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Prepare();

            cmd.ExecuteScalar();
        }
        public EXIFModel readEXIF()
        {
            EXIFModel exif = new EXIFModel();
            exif.ExifVersion = 2.1;
            exif.Make = "Nikon";
            exif.FNumber = 2.8;
            exif.ExposureTime = 1/100;
            exif.ISOSpeed = 150;   
            return exif;
        }
        public IPTCModel readIPTC()
        {
            IPTCModel iptc = new IPTCModel();
            iptc.Title = "Best Image";
            iptc.Caption = "An image";
            iptc.CopyrightNotice = "to whom'st it belongs";
            iptc.Creator = "the camera";
            iptc.Keywords = "cats";
            return iptc;
        }

        //private IEnumerable<string> PicturesFromFolder(string folder, string[] extensions)
        //{
        //    List<string> Pics = new List<string>();

        //    foreach (string extension in extensions)
        //    {
        //        foreach (string pic in Directory.GetFiles(folder, extension, SearchOption.AllDirectories))
        //        {
        //            Pics.Add(pic);
        //        }
        //    }

        //    return Pics;
        //}


    }
}
