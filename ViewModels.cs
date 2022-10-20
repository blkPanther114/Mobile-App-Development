using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;

namespace CustomerApp
{
    public class CustomerView : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string address;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private int id;

        public int ID
        {
            get
            {
                return id;
            }
        }
        private string imageName;

        public string ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        public void Load(Customer cust)
        {
            Name = cust.Name;
            Address = cust.Address;
            id = cust.ID;
            ImageName = cust.ImageName;
        }

        public void Save(ref Customer cust)
        {
            cust.Name = Name;
            cust.Address = Address;
            cust.ImageName = ImageName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}