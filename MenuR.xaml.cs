using Restaurant.Models;

namespace Restaurant;

public partial class MenuR : ContentPage
{
    public MenuR()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var menu = (Menu)BindingContext;
        Console.WriteLine(menu.ID);
        Console.WriteLine(menu.FoodCategoryName);
        Console.WriteLine(menu.Price);
        Console.WriteLine(menu.Description);
        await App.Database.SaveMenuAsync(menu);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var menu = (Menu)BindingContext;
        Console.WriteLine(menu.ID);
        Console.WriteLine(menu.FoodCategoryName);
        Console.WriteLine(menu.Price);
        Console.WriteLine(menu.Description);
        await App.Database.DeleteMenuAsync(menu);
        await Navigation.PopAsync();
    }
}