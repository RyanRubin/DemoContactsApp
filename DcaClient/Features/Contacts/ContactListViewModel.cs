using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common;
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
    private readonly INavigator navigator;
    private readonly IPhoneDialer phoneDialer;
    private readonly ISms sms;

    public ContactListViewModel(
        IMessenger messenger,
        IRepository<ContactEntity> contactRepo,
        INavigator navigator,
        IPhoneDialer phoneDialer,
        ISms sms)
    {
        this.messenger = messenger;
        this.contactRepo = contactRepo;
        this.navigator = navigator;
        this.phoneDialer = phoneDialer;
        this.sms = sms;
    }

    public async Task InitializeViewModel()
    {
        messenger.Register<SavedContactMessage>(this, async (_, _) => await LoadContacts());
        await LoadContacts();
    }

    public void UnloadViewModel()
    {
        messenger.Unregister<SavedContactMessage>(this);
    }

    [RelayCommand]
    private async Task ViewContact(ContactViewModel contactViewModel)
    {
        await navigator.GoToAsync("contacts/details",
            new Dictionary<string, object> { { "Contact", contactViewModel } });
    }

    [RelayCommand]
    private void AddContact()
    {
        messenger.Send(new ShowContactPopupMessage(new(messenger, contactRepo, phoneDialer, sms)));
    }

    private async Task LoadContacts()
    {
        var contacts = await contactRepo.GetAll();
        var contactVms = contacts.Select(c => new ContactViewModel(messenger, contactRepo, phoneDialer, sms)
        {
            ContactId = c.Id,
            ContactName = c.Name ?? string.Empty,
            ContactNumber = c.Number ?? string.Empty,
            ContactColor = Color.FromRgb(c.ColorR, c.ColorG, c.ColorB)
        });
        ContactList = new(contactVms);
    }
}
