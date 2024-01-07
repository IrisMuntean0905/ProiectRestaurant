//using AndroidX.Emoji2.Text.FlatBuffer;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class RestaurantLocation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Menu>? Menus { get; set; }
    }

}