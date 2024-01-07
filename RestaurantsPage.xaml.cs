using Restaurant.Models;
namespace Restaurant;

public partial class RestaurantsPage : ContentPage
{
	public RestaurantsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRestaurantsAsync();
    }

    async void OnRestaurantAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantPage
        {
            BindingContext = new RestaurantLocation()
        });
    }

    async void OnViewSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RestaurantPage
            {
                BindingContext = e.SelectedItem as RestaurantLocation
            });
        }
    }
}