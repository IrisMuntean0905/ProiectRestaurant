//using Kotlin.Coroutines.Jvm.Internal;
using Restaurant.Models;

namespace Restaurant;

public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();
        Populate();
    }

    private async void Populate()
    {
        try
        {
            var restaurants = await App.Database.GetRestaurantsAsync();
            var menus = await App.Database.GetMenusAsync();

            // Check if the list is not empty before populating the Picker
            if (restaurants != null && restaurants.Count > 0)
            {
                Console.WriteLine(restaurants.ToString());
                foreach (var shop in restaurants)
                {
                    Console.WriteLine(shop.Name);
                    restaurantPicker.ItemsSource = restaurants;
                    restaurantPicker.SelectedIndex = 0; // Set a default selection if needed
                }
                menuPicker.ItemsSource = menus;
                menuPicker.SelectedIndex = 0;

            }
            else
            {
                DisplayAlert("Error", "No restaurants available", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Failed to retrieve restaurants: {ex.Message}", "OK");
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var reservation = (Reservation)BindingContext;
        RestaurantLocation selectedRestaurant = (RestaurantLocation)restaurantPicker.SelectedItem;
        Menu selectedMenu = (Menu)menuPicker.SelectedItem;

        Reservation newRes = new Reservation
        {
            ID = reservation.ID,
            Name = reservation.Name,
            Phone = reservation.Phone,
            Date = restaurantDatePicker.Date,
            Time = restaurantTimePicker.Time,
            RestaurantId = selectedRestaurant.ID,
            RestaurantName = selectedRestaurant.Name,
            MenuId = selectedMenu.ID,
            MenuName = selectedMenu.FoodCategoryName,
            NumarPortii = reservation.NumarPortii
        };

        if (reservation != null && reservation.Equals(newRes))
        {
            await App.Database.SaveReservationAsync(reservation);

            Console.WriteLine("Current reservation starting");
            Console.WriteLine(reservation.ID);
            Console.WriteLine(reservation.Date);
            Console.WriteLine(reservation.Time);
            Console.WriteLine(reservation.RestaurantId);
            Console.WriteLine(reservation.RestaurantName);
            Console.WriteLine(reservation.MenuId);
            Console.WriteLine(reservation.MenuName);
            Console.WriteLine(reservation.NumarPortii);
            Console.WriteLine("Current reservation ended");
        }
        else
        {
            await App.Database.SaveReservationAsync(newRes);
        }

        Console.WriteLine("newBooking: ", newRes.ID);


        Console.WriteLine("NewBooking below");
        Console.WriteLine(newRes.ID);
        Console.WriteLine(newRes.Date);
        Console.WriteLine(newRes.Time);
        Console.WriteLine(newRes.RestaurantId);
        Console.WriteLine(newRes.RestaurantName);
        Console.WriteLine(newRes.MenuId);
        Console.WriteLine(newRes.MenuName);
        Console.WriteLine(newRes.NumarPortii);
        Console.WriteLine("NewReservation ended");

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var res = (Reservation)BindingContext;
        Console.WriteLine(res.ID);
        await App.Database.DeleteReservationAsync(res);
        await Navigation.PopAsync();
    }
}