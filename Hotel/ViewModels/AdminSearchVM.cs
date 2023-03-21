using Hotel.Models.BusinessLogicLayer;
using Hotel.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Hotel.ViewModels.Command;
using Hotel.Views;
using System.Collections.Generic;

namespace Hotel.ViewModels
{
    class AdminSearchVM : BasePropertyChanged
    {
        private string searchKeyword;
        public string SearchKeyword
        {
            get
            {
                return searchKeyword;
            }
            set
            {
                searchKeyword = value;
                NotifyPropertyChanged("SearchKeyword");
            }
        }


        RoomBLL roomBLL = new RoomBLL();
        public AdminSearchVM()
        {
            RoomList = roomBLL.GetAllRooms();
            RoomListCopy = RoomList;
        }

        private ObservableCollection<RoomType> roomList;
        public ObservableCollection<RoomType> RoomList
        {
            get
            {
                return roomList;
            }
            set
            {
                if (value != roomList)
                {
                    roomList = value;
                }
                NotifyPropertyChanged(nameof(RoomList));
            }
        }

        public ObservableCollection<RoomFeatures> RoomListWithFeatures
        {
            get => roomBLL.RoomFeatures;
            set => roomBLL.RoomFeatures = value;
        }
        public void FilterFunction(object parameter)
        {
            SearchFilters sf = new SearchFilters();
            sf.Show();
        }

        public ObservableCollection<RoomType> RoomListCopy;

        public ObservableCollection<RoomType> SearchedRooms { get; set; } = new ObservableCollection<RoomType>();

        public void SearchFunction(object parameter)
        {
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                RoomList = GetAllRoomsByKeyword();

            }
            else if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                RoomList = RoomListCopy;
            }
        }

        public ObservableCollection<RoomType> GetAllRoomsByKeyword()
        {
            SearchedRooms.Clear();
            int results = 0;
            foreach (RoomType room in RoomListCopy)
            {
                if (room.CameraType == SearchKeyword)
                {
                    SearchedRooms.Add(room);
                    results++;
                }
            }
            if (results == 0)
            {
                MessageBox.Show("0 results found");
            }
            return SearchedRooms;
        }
        private ICommand search;
        public ICommand Search
        {
            get
            {
                if (search == null)
                {
                    search = new RelayCommand<UserRegistration>(SearchFunction);
                }
                return search;
            }
        }

        private ICommand filter;
        public ICommand Filter
        {
            get
            {
                if (filter == null)
                {
                    filter = new RelayCommand<object>(FilterFunction);
                }
                return filter;
            }
        }

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand<RoomType>(AddRoomFunction);
                }
                return add;
            }
        }

        private ICommand delete;
        public ICommand Delete {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand<RoomType>(DeleteRoomFunction);
                }
                return delete;
            }
        }

        private ICommand details;
        public ICommand Details
        {
            get
            {
                if (details == null)
                {
                    details = new RelayCommand<RoomType>(DetailsFunction);
                }
                return details;
            }
        }

        private ICommand update;
        public ICommand Update
        {
            get
            {
                if (update == null)
                {
                    update = new RelayCommand<RoomType>(UpdateFunction);
                }
                return update;
            }
        }

        public void UpdateFunction(RoomType parameter)
        {
            roomBLL.UpdateRoom(parameter);
            RoomList = roomBLL.GetAllRooms();
            RoomListCopy = RoomList;
        }

        public ObservableCollection<RoomFeatures> rft { get; set; } = new ObservableCollection<RoomFeatures>();

        public void DetailsFunction(RoomType parameter)
        {
            rft = roomBLL.GetRoomFeatures();
            List<string> denumiri = new List<string>();
            int found = 0;
            foreach (RoomFeatures room in rft)
            {
                if (room.room.Room.CameraID == parameter.Room.CameraID)
                {
                    found = 1;
                    denumiri = room.Denumire;
                    break;
                }
            }
            if (found == 1)
            {
                RoomDetails rd = new RoomDetails(parameter, denumiri);
                rd.Show();
            }
        }
        public void AddRoomFunction(RoomType room)
        {
            roomBLL.AddRoom(room);
            RoomList = roomBLL.GetAllRooms();
            RoomListCopy = RoomList;

        }

        public void DeleteRoomFunction(RoomType room)
        {
            roomBLL.DeleteRoom(room);
            RoomList = roomBLL.GetAllRooms();
            RoomListCopy = RoomList;

        }
    }
}
