﻿using picDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    public class PhotographerViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Notes { get; set; }
        bool IsValid { get; }
        string ValidationSummary { get; }

        public PhotographerViewModel(PhotographerModel photographer)
        {
            if (photographer == null) return;
            ID = photographer.ID;
            FirstName = photographer.FirstName;
            LastName = photographer.LastName;
            
        }
      

    }
}
