using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using DcaModels;
using DcaServices.DataAccess;
using System.Collections.ObjectModel;

namespace DcaClient.Features.Contacts;

public partial class ContactListViewModel : ObservableObject
{
    [ObservableProperty]
    private string searchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ContactViewModel> contactList = new();

    private readonly IMessenger messenger;
    private readonly IRepository<ContactEntity> contactRepo;

    public ContactListViewModel(IMessenger messenger, IRepository<ContactEntity> contactRepo)
    {
        this.messenger = messenger;
        this.contactRepo = contactRepo;
    }

    [RelayCommand]
    private void ViewContact(ContactViewModel contactViewModel)
    {

    }

    [RelayCommand]
    private void AddContact()
    {
        messenger.Send(new ShowContactPopupMessage(new(messenger, contactRepo)));
    }
}
