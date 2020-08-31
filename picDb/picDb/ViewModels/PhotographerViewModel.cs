using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    class PhotographerViewModel
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool ShowBirthday { get { return Birthday.HasValue; } }
        public int NumberOfPictures
        {
            get
            {
                if (obj != null)
                {
                    return obj.Pictures.Count;
                }
                return 0;
            }
        }
        bool IsValid { get; }
        string ValidationSummary { get; }

        private ICommandViewModel _saveCommand;
        public ICommandViewModel SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new SimpleCommandViewModel(
                    "Speichern",
                    "Speichert diesen Datensatz",
                    () =>
                    {
                        _bl.Save(_photographer);
                    },
                    () => IsValid);
                }
                return _saveCommand;
            }
        }

    }
}
