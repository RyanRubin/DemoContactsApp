using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common.Popups;
using DcaClient.Features.Contacts.Messages;

namespace DcaClient.Features.Contacts.Mobile;

[QueryProperty(nameof(Vm), "Contact")]
public partial class ContactPageMobile : ContentPage
{
    public ContactViewModel? Vm { get; set; }

    private readonly IMessenger messenger;

    public ContactPageMobile(IMessenger messenger)
    {
        InitializeComponent();
        NavigatedTo += ContactPageMobile_NavigatedTo;
        NavigatingFrom += ContactPageMobile_NavigatingFrom;
        this.messenger = messenger;
    }

    private void ContactPageMobile_NavigatedTo(object? sender, NavigatedToEventArgs e)
    {
        BindingContext = Vm;
        messenger.Register<ShowContactPopupMessage>(this, (_, message) => this.ShowPopup(new ContactPopup(message.Value, messenger)));
    }

    private void ContactPageMobile_NavigatingFrom(object? sender, NavigatingFromEventArgs e)
    {
        messenger.Unregister<ShowContactPopupMessage>(this);
    }
}