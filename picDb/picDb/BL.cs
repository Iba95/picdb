using picDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace picDb
{
    class BL
    {
        private DAL _dal;
        public BL()
        {
            _dal = new DAL();
            sync();
        }
        public PictureModel getPicture(int ID)
        {
            return _dal.getPicture(ID);
        }
        public IEnumerable<PictureModel> getPictures()
        {
            return _dal.getPictures();
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
            _dal.sync();         
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
