namespace DcaClient.Common;

public static class RequiredServiceProvider
{
    public static IServiceProvider? Current =>
#if ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        null;
#elif WINDOWS
        MauiWinUIApplication.Current.Services;
#else
        null;
#endif

    public static TService GetRequiredService<TService>() where TService : class =>
        Current is null ? throw new InvalidOperationException("No service provider available") : Current.GetRequiredService<TService>();
}
