using CommunityToolkit.Maui.Views;
using DcaClient.Features.Contacts;
using CommunityToolkit.Maui.Core;

namespace DcaClient.Common.Popups;

public partial class ContactPopup : Popup
{
    private readonly ContactViewModel vm;

    public ContactPopup(ContactViewModel vm)
    {
        InitializeComponent();
        Opened += ContactPopup_Opened;
        Closed += ContactPopup_Closed;
        this.vm = vm;
    }

    private void ContactPopup_Opened(object? sender, PopupOpenedEventArgs e)
    {
        BindingContext = vm;
    }

    private void ContactPopup_Closed(object? sender, PopupClosedEventArgs e)
    {

    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}