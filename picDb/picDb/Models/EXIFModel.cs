using picDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.Models
{
    public class EXIFModel
    {
        public double ExifVersion { get; set; }
        public string Make { get; set; }
        public double FNumber { get; set; }
        public double ExposureTime { get; set; }
        public double ISOSpeed { get; set; }
        public EXIFModel()
        {
            ExifVersion = 2.3;
            Make = "Nikon";
            FNumber = 2.8;
            ExposureTime = 1/6;
            ISOSpeed = 100;

        }
        public EXIFModel(EXIFViewModel exifvm)
        {
            ExifVersion = exifvm.ExifVersion;
            Make = exifvm.Make;
            FNumber = exifvm.FNumber;
            ExposureTime = exifvm.ExposureTime;
            ISOSpeed = exifvm.ISOSpeed;
        }
       
    }
}
