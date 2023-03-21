using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Room:BasePropertyChanged
    {
        private Int64 cameraID;
        public Int64 CameraID
        {
            get
            {
                return cameraID;
            }
            set
            {
                cameraID = value;
                NotifyPropertyChanged("CameraID");
            }
        }

        private Int64 cameraTypeID;
        public Int64 CameraTypeID
        {
            get
            {
                return cameraTypeID;
            }
            set
            {
                cameraTypeID = value;
                NotifyPropertyChanged("CameraTypeID");
            }
        }

        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        private bool availability;
        public bool Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
                NotifyPropertyChanged("Availability");
            }
        }

       
    }
}
