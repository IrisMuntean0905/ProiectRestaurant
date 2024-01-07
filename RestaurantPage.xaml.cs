using Restaurant.Models;
namespace Restaurant;

public partial class RestaurantPage : ContentPage
{
    public RestaurantPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var restaurant = (RestaurantLocation)BindingContext;
        Console.WriteLine(restaurant.ID);
        Console.WriteLine(restaurant.Name);
        Console.WriteLine(restaurant.Address);
        await App.Database.SaveRestaurantAsync(restaurant);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var restaurant = (RestaurantLocation)BindingContext;
        Console.WriteLine(restaurant.ID);
        Console.WriteLine(restaurant.Name);
        Console.WriteLine(restaurant.Address);
        await App.Database.DeleteRestaurantAsync(restaurant);
        await Navigation.PopAsync();
    }
}