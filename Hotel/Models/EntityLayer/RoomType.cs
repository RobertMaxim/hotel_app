using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class RoomType
    {
        public Room Room { get; set; } = new Room();
        public string CameraType { get; set; }

    }
}
