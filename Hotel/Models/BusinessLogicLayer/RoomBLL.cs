using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Models.BusinessLogicLayer
{
    class RoomBLL
    {
        public ObservableCollection<RoomType> RoomList { get; set; } = new ObservableCollection<RoomType>();
        public ObservableCollection<RoomFeatures> RoomFeatures { get; set; }

        RoomDAL roomDAL = new RoomDAL();

        public ObservableCollection<RoomType> GetAllRooms()
        {
            return roomDAL.GetAllRooms();
        }

        public ObservableCollection<RoomFeatures> GetRoomFeatures()
        {
            return roomDAL.GetRoomsWithFeatures();
        }
        public void AddRoom(RoomType room)
        {
            if(room.CameraType!=null&&room.Room.Availability!=null&&room.Room.Price!=null)
            {
                roomDAL.AddRoom(room);
                RoomList.Add(room);
                MessageBox.Show("Camera adaugata cu succes!");
            }
            else
            {
                MessageBox.Show("Completeaza toate campurile pentru a adauga camera!");
            }
        }
        public void DeleteRoom(RoomType room)
        {
            if (room == null)
            {
                MessageBox.Show("Selectati o Camera");
                return;
            }
            roomDAL.DeleteRoom(room);
            RoomList.Remove(room);
        }

        public void UpdateRoom(RoomType room)
        {
            if(room== null)
            {
                MessageBox.Show("Selectati o camera");
                return;
            }
            roomDAL.UpdateRoom(room);
        }

        //public ObservableCollection<RoomFeatures> ApplyFiltersFunction(RoomFeatures Features)
        //{
        //    ObservableCollection<RoomFeatures> result = new ObservableCollection<RoomFeatures>();
        //    if (Features.Denumire.Count == 0 && string.IsNullOrEmpty(Features.room.CameraType) && Features.room.Room.Availability == false)
        //    {
        //        MessageBox.Show("No changes were made");
        //    }
        //    else
        //    {
        //        Features.Denumire.Sort();
        //        ObservableCollection<RoomFeatures> roomFeatures = roomDAL.GetRoomsWithFeatures();
        //        foreach (RoomFeatures feat in RoomFeatures)
        //        {
        //            feat.Denumire.Sort();
        //            if (Features.Denumire == feat.Denumire)
        //            {
        //                result.Add(feat);
        //            }
        //            if (Features.room.CameraType != null && feat.room.CameraType == Features.room.CameraType)
        //            {
        //                result.Add(feat);
        //            }
        //            if (Features.room.Room.Availability == feat.room.Room.Availability == true)
        //            {
        //                result.Add(feat);
        //            }

        //        }
        //    }
        //    return result;
        //}
    }
}
