using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using System.Collections.ObjectModel;

namespace DcaClient.Features.Contacts;

public partial class ContactListViewModel : ObservableObject
{
    [ObservableProperty]
    private string searchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ContactViewModel> contactList = new();

    private readonly WeakReferenceMessenger messenger;

    public ContactListViewModel(WeakReferenceMessenger messenger)
    {
        this.messenger = messenger;
    }

    [RelayCommand]
    private void ViewContact(ContactViewModel contactViewModel)
    {

    }

    [RelayCommand]
    private void AddContact()
    {
        messenger.Send(new ShowContactPopupMessage(new()));
    }
}
