using picDb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace picDb
{
    class DAL
    {
        private string connstr;
        private const String SERVER = "127.0.0.1";
        private const String DATABASE = "picdb";
        private const String UID = "root";
        private const String PASSWORD = "";

        public DAL()
        {
             connstr = @"server=127.0.0.1;userid=root;password=;database=picdb";
        }
        public PictureModel getPicture(int ID)
        {
            var con = new MySqlConnection(connstr);
            con.Open();
            var stm = "SELECT * FROM picturemodel Where ID = @ID;";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            PictureModel pic = new PictureModel();

            while (rdr.Read())
            {
                pic.ID = rdr.GetInt32("ID");
                pic.FileName = rdr.GetString("FileName");
            }
            return pic;
        }

        public List<PictureModel> getPictures(string ID, string ID2, string ID3, string ID4)
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

        public void savePicture(PictureModel picture)
        {
            
        }
        public void deletePicture(int ID)
        {

        }

        public PhotographerModel getPhotographer(int ID)
        {
            return null;
        }

        public List<PhotographerModel> getPhotographers()
        {
            return null;
        }       

        public void savePhotographer(PhotographerModel photographer)
        {
            
        }
        public void updatePhotographer(PhotographerModel photographer)
        {

        }

        public void deletePhotographer(int ID)
        {

        }

        private IEnumerable<string> PicturesFromFolder(string folder, string[] extensions)
        {
            List<string> Pics = new List<string>();

            foreach (string extension in extensions)
            {
                foreach (string pic in Directory.GetFiles(folder, extension, SearchOption.AllDirectories))
                {
                    Pics.Add(pic);
                }
            }

            return Pics;
        }


    }
}
