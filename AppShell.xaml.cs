using AntonellaCortes_PROGRESOFINAL.ACViews;

namespace AntonellaCortes_PROGRESOFINAL;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ACGameDetails), typeof(ACGameDetails));
        Routing.RegisterRoute(nameof(ACGenerateGame), typeof(ACGenerateGame));
    }
}
