using Restaurant.Database;
namespace Restaurant;

public partial class App : Application
{

    static MenuDatabase database;
    public static MenuDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new MenuDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Menu.db3"));
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}