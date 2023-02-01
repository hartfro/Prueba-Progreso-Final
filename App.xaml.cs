using AntonellaCortes_PROGRESOFINAL.ACData;
using AntonellaCortes_PROGRESOFINAL.ACViews;

namespace AntonellaCortes_PROGRESOFINAL;

public partial class App : Application
{
    public static ACGameDataBase GameRepo { get; set; }
    public App(ACGameDataBase repo)
    {
        InitializeComponent();

        MainPage = new AppShell();
        GameRepo = repo;
    }
}
