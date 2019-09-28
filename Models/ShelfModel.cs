using System;
using System.ComponentModel;

namespace Models
{
    public class ShelfModel : IDataErrorInfo, INotifyPropertyChanged
    {
        #region [INotifyPrivateProperties]
        private string name { get; set; }
        #endregion
        public Guid Id { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Name");
            }
        }
        public string Description { get; set; }
        #region[Validation Interface]
        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }
        #endregion
        #region[Validate]
        static readonly string[] VaidatedProperties =
        {
            "Name"
        };
        public bool IsValid
        {
            get
            {
                foreach (string property in VaidatedProperties)
                {
                    if (GetValidationError(property) != null)
                        return false;
                }
                return true;
            }
        }


        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Name":
                    error = VaildateShelfName();
                    break;
            }
            return error;
        }
        private string VaildateShelfName()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrEmpty(Name))
            {
                return "Name can not be empty";
            }
            return null;
        }
        #endregion
        #region[Property Changed Event]
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion
    }


    public class ShelfSearchViewModel : GenralSearchModel
    {
        public string Name { get; set; }
    }




}
