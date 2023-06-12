using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common.Popups;
using DcaClient.Features.Contacts.Messages;

namespace DcaClient.Features.Contacts.Mobile;

public partial class ContactListPageMobile : ContentPage
{
    private readonly ContactListViewModel vm;
    private readonly IMessenger messenger;

    public ContactListPageMobile(ContactListViewModel vm, IMessenger messenger)
    {
        InitializeComponent();
        NavigatedTo += ContactListPageMobile_NavigatedTo;
        NavigatingFrom += ContactListPageMobile_NavigatingFrom;
        this.vm = vm;
        this.messenger = messenger;
    }

    private void ContactListPageMobile_NavigatedTo(object? sender, NavigatedToEventArgs e)
    {
        BindingContext = vm;
        messenger.Register<ShowContactPopupMessage>(this, (_, message) => this.ShowPopup(new ContactPopup(message.Value, messenger)));
    }

    private void ContactListPageMobile_NavigatingFrom(object? sender, NavigatingFromEventArgs e)
    {

    }
}