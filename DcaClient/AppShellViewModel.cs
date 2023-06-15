using CommunityToolkit.Mvvm.ComponentModel;
using DcaClient.Features.Contacts.Desktop;
using DcaClient.Features.Contacts.Mobile;

namespace DcaClient;

public partial class AppShellViewModel : ObservableObject
{
    [ObservableProperty]
    private DataTemplate? shellContentTemplate;

    public AppShellViewModel()
    {
        //#if ANDROID || IOS
        ShellContentTemplate = new DataTemplate(typeof(ContactListPageMobile));
        //#elif WINDOWS || MACCATALYST
        //ShellContentTemplate = new DataTemplate(typeof(ContactListPageDesktop));
        //#endif
    }
}
