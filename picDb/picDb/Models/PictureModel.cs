using picDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.Models
{
    class PictureModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public EXIFModel EXIF { get; set; }
        public IPTCModel IPTC { get; set; }        
        public PhotographerModel Photographer { get; set; }
        public PictureModel()
        {
            EXIF = new EXIFModel();
            IPTC = new IPTCModel();           
            Photographer = new PhotographerModel();
        }
        public PictureModel(PictureViewModel picturevm)
        {
            ID = picturevm.ID;
            FileName = picturevm.FileName;
            EXIF = picturevm.EXIF;
            IPTC = picturevm.IPTC;
            Photographer = picturevm.Photographer;
        }
    }
}
