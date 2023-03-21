using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class RoomFeatures
    {
        public RoomType room { get; set; } = new RoomType();
        public List<string> Denumire { get; set; } = new List<string>();
    }
}
