using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts;
using DcaClient.Features.Contacts.Messages;

namespace DcaClient.Common.Popups;

public partial class ContactPopup : Popup
{
    private readonly ContactViewModel vm;
    private readonly IMessenger messenger;

    public ContactPopup(ContactViewModel vm, IMessenger messenger)
    {
        InitializeComponent();
        Opened += ContactPopup_Opened;
        Closed += ContactPopup_Closed;
        this.vm = vm;
        this.messenger = messenger;
    }

    private void ContactPopup_Opened(object? sender, PopupOpenedEventArgs e)
    {
        BindingContext = vm;
        messenger.Register<SavedContactMessage>(this, (_, _) => Close());
    }

    private void ContactPopup_Closed(object? sender, PopupClosedEventArgs e)
    {
        messenger.Unregister<SavedContactMessage>(this);
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}