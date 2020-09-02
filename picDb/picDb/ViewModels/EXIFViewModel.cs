using picDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    public class EXIFViewModel
    {
        public double ExifVersion { get; set; }
        public string Make { get; set; }
        public double FNumber { get; set; }
        public double ExposureTime { get; set; }
        public double ISOSpeed { get; set; }

        public EXIFViewModel(EXIFModel exif)
        {
            ExifVersion = exif.ExifVersion;
            Make = exif.Make;
            FNumber = exif.FNumber;
            ExposureTime = exif.ExposureTime;
            ISOSpeed = exif.ISOSpeed;
        }
    }
}
