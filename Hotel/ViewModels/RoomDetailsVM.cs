using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class RoomDetailsVM:BasePropertyChanged
    {

        public RoomType CurrentRoomFeatures { get; set; }
        public RoomDetailsVM(RoomType rft, List<string> denumiri)
        {
            CurrentRoomFeatures = rft;
            TipCamera = rft.CameraType;
            Status = rft.Room.Availability.ToString();
            Pret = rft.Room.Price.ToString();
            Dotari = Denumiri(denumiri);
        }

        public string Denumiri(List<string> denumiri)
        {
            string rezultat = string.Empty;
            foreach(string sir in denumiri)
            {
                rezultat += sir;
            }
            return rezultat;
        }

        private string tipCamera;
        public string TipCamera {
            get
            {
                return tipCamera;
            }
            set
            {
                tipCamera = value;
                NotifyPropertyChanged("TipCamera");
            }
        }

        private string pret;
        public string Pret
        {
            get
            {
                return pret;
            }
            set
            {
                pret = value;
                NotifyPropertyChanged("Pret");
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        private string dotari;
        public string Dotari {
            get
            {
                return dotari;
            }
            set
            {
                dotari = value;
                NotifyPropertyChanged("Dotari");
            }
        }


    }
}
