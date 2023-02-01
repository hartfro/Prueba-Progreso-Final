using AntonellaCortes_PROGRESOFINAL.ACData;

namespace AntonellaCortes_PROGRESOFINAL;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        string dbPath = FileAccessHelper.GetLocalFilePath("game.db3");
		builder.Services.AddSingleton<ACGameDataBase>(s => ActivatorUtilities.CreateInstance<ACGameDataBase>(s, dbPath));
		return builder.Build();
    }
}
