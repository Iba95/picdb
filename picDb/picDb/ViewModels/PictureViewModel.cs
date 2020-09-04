using picDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    public class PictureViewModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public EXIFModel EXIF { get; set; }
        public IPTCModel IPTC { get; set; }
        public PhotographerViewModel Photographer { get; set; }

        public PictureViewModel(PictureModel picture)
        {
            //if (picture is PictureModel)
            //{
            //    IPTC = new IPTCViewModel((IPTCModel)picture.IPTC);
            //    EXIF = new EXIFViewModel((EXIFModel)picture.EXIF);
            //    Photographer = new PhotographerViewModel((PhotographerModel)picture.Photographer);
            //}

            if (picture != null)
            {
                ID = picture.ID;
                FileName = picture.FileName;
                EXIF = picture.EXIF;
                IPTC = picture.IPTC;
                Photographer = new PhotographerViewModel(picture.Photographer);
                string name = picture.FileName;
                string creator = picture.IPTC.Creator;
            }
        }
    }
}
