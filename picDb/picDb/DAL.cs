using picDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace picDb
{
    class DAL
    {

        public PictureModel getPicture(int ID)
        {
            return null;
        }

        public List<PictureModel> getPictures(string ID, string ID2, string ID3, string ID4)
        {
            return null;
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
