using Restaurant.Models;

namespace Restaurant;

public partial class MenusR : ContentPage
{
    public MenusR()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMenusAsync();
    }

    async void OnMenuAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuR
        {
            BindingContext = new Menu()
        });
    }

    async void OnViewSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MenuR
            {
                BindingContext = e.SelectedItem as Menu
            });
        }
    }
}