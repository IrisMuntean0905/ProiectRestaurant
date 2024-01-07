using SQLite;

using SQLiteNetExtensions.Attributes;

namespace Restaurant.Models
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }//numele persoanei pe care se face rezervarea
        public string Phone { get; set; }

        [MaxLength(250), Unique]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }
        [ForeignKey(typeof(RestaurantLocation))]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        [ForeignKey(typeof(Menu))]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int NumarPortii { get; set; }
    }
}
