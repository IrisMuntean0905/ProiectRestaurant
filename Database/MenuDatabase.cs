using SQLite;
using Restaurant.Models;

namespace Restaurant.Database
{
    public class MenuDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public MenuDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Menu>().Wait();
            _database.CreateTableAsync<Reservation>().Wait();
            _database.CreateTableAsync<RestaurantLocation>().Wait();
        }

        public Task<List<Menu>> GetMenusAsync()
        {
            return _database.Table<Menu>().ToListAsync();
        }

        public Task<Menu> GetMenuAsync(int id)
        {
            return _database.Table<Menu>()
                             .Where(i => i.ID == id)
                             .FirstOrDefaultAsync();
        }

        public Task<int> SaveMenuAsync(Menu menu)
        {
            if (menu.ID != 0)
            {
                return _database.UpdateAsync(menu);
            }
            else
            {
                return _database.InsertAsync(menu);
            }
        }

        public Task<int> DeleteMenuAsync(Menu menu)
        {
            return _database.DeleteAsync(menu);
        }


        //pentru rezervare

        public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservation reservation)
        {
            if (reservation.ID != 0)
            {
                return _database.UpdateAsync(reservation);
            }
            else
            {
                return _database.InsertAsync(reservation);
            }
        }

        public Task<int> DeleteReservationAsync(Reservation reservation)
        {
            return _database.DeleteAsync(reservation);
        }

        public Task<List<RestaurantLocation>> GetRestaurantsAsync()
        {
            return _database.Table<RestaurantLocation>().ToListAsync();
        }

        public Task<RestaurantLocation> GetRestaurantAsync(int id)
        {
            return _database.Table<RestaurantLocation>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveRestaurantAsync(RestaurantLocation restaurant)
        {
            if (restaurant.ID != 0)
            {
                return _database.UpdateAsync(restaurant);
            }
            else
            {
                return _database.InsertAsync(restaurant);
            }
        }

        public Task<int> DeleteRestaurantAsync(RestaurantLocation restaurant)
        {
            return _database.DeleteAsync(restaurant);
        }


    }
}