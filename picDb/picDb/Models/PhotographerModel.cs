using picDb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace picDb.Models
{
    public class PhotographerModel
    {
        public int ID { get; set; }

        private string _firstName;

        private string _lastName;

        public DateTime? Birthday { get; set; }
        public string Notes { get; set; }
        public string FirstName 
        {
            get
            {
                if (!string.IsNullOrEmpty(_firstName))
                {
                    return _firstName;
                }
                return "no value";
            }
            set
            {
                if (string.IsNullOrEmpty(_firstName))
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                if (!string.IsNullOrEmpty(_lastName))
                {
                    return _lastName;
                }
                return "no value";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
            }
        }
        public PhotographerModel() { }
        public PhotographerModel(PhotographerViewModel pvm)
        {
            ID = pvm.ID;
            FirstName = pvm.FirstName;
            LastName = pvm.LastName;
            Notes = pvm.Notes;
            Birthday = pvm.Birthday;
        }

    }
}
