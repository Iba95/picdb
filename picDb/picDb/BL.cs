using picDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace picDb
{
    class BL
    {
        private DAL _dal;
        private string Folder;
        public BL()
        {
            _dal = new DAL();
            Folder = @"C:\Users\islam\Documents\Arbeit\FH\4 SEM\SWE 2\pics";
        }
        public PictureModel getPicture(int ID)
        {
            return _dal.getPicture(ID);
        }
        public IEnumerable<PictureModel> getPictures()
        {
            return _dal.getPictures(null, null, null, null);
        }
        public void savePicture(PictureModel picture)
        {
            _dal.savePicture(picture);
        }
        public void deletePicture(int ID)
        {
            _dal.deletePicture(ID);
        }
        public void sync()
        {
            var files = Directory.GetFiles(Folder, "*.*", SearchOption.AllDirectories);

            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                    imageFiles.Add(filename);
            }
        }

        public PhotographerModel getPhotographer(int ID)
        {
            return _dal.getPhotographer(ID);
        }
        public List<PhotographerModel> getPhotographers()
        {
            return _dal.getPhotographers();
        }
        public void savePhotographer(PhotographerModel photographer)
        {
            _dal.savePhotographer(photographer);
        }
        public void updatePhotographer(PhotographerModel photographer)
        {
            _dal.updatePhotographer(photographer);
        }
        public void delPhotographer(int ID)
        {
            _dal.deletePhotographer(ID);
        }

        public EXIFModel getEXIFInfos()
        {
            EXIFModel em = new EXIFModel();
            return em;
        }

        public IPTCModel getIPTCInfos()
        {
            IPTCModel im = new IPTCModel();
            return im;
        }
    }


}
