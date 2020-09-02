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
        public PhotographerModel Photographer { get; set; }

        public PictureViewModel(PictureModel picture)
        {
            //if (picture is PictureModel)
            //{
            //    IPTC = new IPTCViewModel(picture.IPTC);
            //    EXIF = new EXIFViewModel(picture.EXIF);
            //    Photographer = new PhotographerViewModel(picture.Photographer);
            //}

            if (picture != null)
            {
                ID = picture.ID;
                FileName = picture.FileName;
                string name = picture.FileName;
                string creator = picture.IPTC.Creator;
            }
        }
    }
}
