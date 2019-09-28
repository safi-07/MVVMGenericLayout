using Helpers;
using Models.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Models
{
    public class BranchModel : IDataErrorInfo, INotifyPropertyChanged, IImage
    {
        #region [INotifyPrivateProperties]
        private const string Format = "hh:mm tt";
        private const string defaultStartTime = "09:00 AM";
        private const string defaultEndTime = "06:00 PM";
        private string name { get; set; }
        private string startTimeStr { get; set; } = defaultStartTime;
        private string endTimeStr { get; set; } = defaultEndTime;
        private string description { get; set; }
        private string serverPicturePath { get; set; }
        #endregion
        public BranchModel()
        {
            Address = new AddressModel();
        }
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



        public string StartTimeStr
        {
            get
            {
                try
                {
                    return new DateTime(TimeSpan.Parse(startTimeStr).Ticks).ToString(Format);
                }
                catch
                {
                    return startTimeStr;
                }
            }
            set
            {
                startTimeStr = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("StartTimeStr");
            }
        }
        public string EndTimeStr
        {
            get
            {
                try
                {
                    return new DateTime(TimeSpan.Parse(endTimeStr).Ticks).ToString(Format);
                }
                catch
                {
                    return endTimeStr;
                }
            }
            set
            {
                endTimeStr = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("EndTimeStr");
            }
        }
        public TimeSpan StartTime
        {
            get
            {
                return DateTime.Parse(startTimeStr).TimeOfDay;
            }
        }
        public TimeSpan EndTime
        {
            get
            {
                return DateTime.Parse(endTimeStr).TimeOfDay;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Description");
            }
        }

        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSynced { get; set; }
        public bool IsShareable { get; set; }
        public bool IsNew { get; set; }
        public Guid ApplicationId { get; set; }
        public int AddressId { get; set; }
        public AddressModel Address { get; set; }
        public bool IsPictureUploaded { get; set; }
        public string ServerPicturePath
        {
            get
            {
                return serverPicturePath;
            }
            set
            {
                serverPicturePath = value;
                OnPropertyChanged("Picture");
                OnPropertyChanged("ServerPicturePath");
            }
        }
        public string PictureType { get; set; }
        public byte[] PictureInBytes { get; set; }
        public ImageSource Picture
        {
            get
            {
                if (PictureInBytes == null)
                {
                    BitmapImage dp = new BitmapImage();
                    dp.BeginInit();
                    dp.UriSource = new Uri(@"/DesktopApplication;component/Resources/Images/noimagefound.jpg", UriKind.Relative);
                    dp.EndInit();
                    ImageSource ProfilePicture = dp;
                    return ProfilePicture;
                }
                else
                {
                    ImageSource ProfilePicture = ImageHelper.LoadImage(PictureInBytes);
                    return ProfilePicture;

                }
            }
        }
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
                    error = VaildateBranchName();
                    break;
            }
            return error;
        }
        private string VaildateBranchName()
        {
            if (string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrEmpty(this.Name))
            {
                return "Branch name can not be empty";
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


    public class BranchSearchViewModel : GenralSearchModel
    {
        public string Name { get; set; }
    }



   
}
