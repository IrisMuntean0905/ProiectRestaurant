using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Menu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FoodCategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}