using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class AddressModel : IDataErrorInfo, INotifyPropertyChanged
    {
        #region [INotifyPrivateProperties]
        private string email { get; set; }
        private string addressLine1 { get; set; }
        private string addressLine2 { get; set; }
        private string city { get; set; }
        private string state { get; set; }
        private string zipCode { get; set; }
        private string country { get; set; }
        private string phoneNo { get; set; }
        private string mobileNo { get; set; }
        #endregion
        public int Id { get; set; }
        public string AddressLine1
        {
            get { return addressLine1; }
            set
            {
                addressLine1 = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("AddressLine1");
            }
        }
        public string AddressLine2
        {
            get { return addressLine2; }
            set
            {
                addressLine2 = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("AddressLine2");
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("City");
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("State");
            }
        }
        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ZipCode");
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Country");
            }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set
            {
                phoneNo = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("phoneNo");
            }
        }
        public string MobileNo
        {
            get { return mobileNo; }
            set
            {
                mobileNo = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("MobileNo");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Email");
            }
        }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSynced { get; set; }
        public bool IsShareable { get; set; }
        public Guid ApplicationId { get; set; }
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
            "Email"
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

                case "Email":
                    error = VaildateEmail();
                    break;


            }
            return error;
        }
        private string VaildateEmail()
        {
            //if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrEmpty(this.Email))
            //{
            //    return "E-mail can not be empty";
            //}
            return null;
        }

        #endregion
        #region[Property Changed Event]
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
