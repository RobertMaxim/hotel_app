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
    public class SearchVM : BasePropertyChanged
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
        public SearchVM()
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
                return RoomList;
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

    }
}
