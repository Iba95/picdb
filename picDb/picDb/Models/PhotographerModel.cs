using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace picDb.Models
{
    public class PhotographerModel : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public List<Pictures> Pictures { get; }
    }
}
