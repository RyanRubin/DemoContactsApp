using DcaClient.Features.Contacts.Desktop;
using DcaClient.Features.Contacts.Mobile;

namespace DcaClient;

public partial class App : Application
{
    public App(AppShellViewModel vm)
    {
        InitializeComponent();

        //#if ANDROID || IOS
        Routing.RegisterRoute("contacts", typeof(ContactListPageMobile));
        Routing.RegisterRoute("contacts/details", typeof(ContactPageMobile));
        //#elif WINDOWS || MACCATALYST
        //Routing.RegisterRoute("contacts", typeof(ContactListPageDesktop));
        //#endif

        MainPage = new AppShell(vm);
    }
}
