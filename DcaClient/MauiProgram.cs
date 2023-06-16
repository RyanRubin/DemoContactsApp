using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common;
using DcaClient.Features.Contacts;
using DcaClient.Features.Contacts.Desktop;
using DcaClient.Features.Contacts.Mobile;
using DcaServices.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DcaClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        //#if ANDROID || IOS
        builder.Services.AddTransient<ContactListPageMobile>();
        builder.Services.AddTransient<ContactPageMobile>();
        //#elif WINDOWS || MACCATALYST
        builder.Services.AddTransient<ContactListPageDesktop>();
        //#endif

        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<ContactListViewModel>();
        builder.Services.AddTransient<ContactViewModel>();

        builder.Services.AddSingleton<IMessenger>(_ => WeakReferenceMessenger.Default);
        builder.Services.AddSingleton(_ => Shell.Current);
        builder.Services.AddSingleton<INavigator, Navigator>();
        builder.Services.AddSingleton(_ => PhoneDialer.Default);
        builder.Services.AddSingleton(_ => Sms.Default);

        builder.Services.AddDbContext<DcaDbContext>(opt => opt.UseInMemoryDatabase("DCA"));
        builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        return builder.Build();
    }
}
