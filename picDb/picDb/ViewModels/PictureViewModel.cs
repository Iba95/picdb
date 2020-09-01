using picDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    class PictureViewModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public EXIFModel EXIF { get; set; }
        public IPTCModel IPTC { get; set; }
        public PhotographerModel Photographer { get; set; }

        public PictureViewModel(PictureModel picture)
        {
            
        }
    }
}
