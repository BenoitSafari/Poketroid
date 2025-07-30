using Microsoft.Extensions.Logging;

namespace Poketroid.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("itc_stone_sans_bold.otf", "Bold");
				fonts.AddFont("itc_stone_sans_italic.otf", "Italic");
				fonts.AddFont("itc_stone_sans_regular.otf", "Regular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
