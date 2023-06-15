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
    private readonly Shell shell;

    public ContactListViewModel(
        IMessenger messenger,
        IRepository<ContactEntity> contactRepo,
        Shell shell)
    {
        this.messenger = messenger;
        this.contactRepo = contactRepo;
        this.shell = shell;
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
    private void ViewContact(ContactViewModel contactViewModel)
    {
        shell.GoToAsync("contacts/details",
            new Dictionary<string, object> { { "Contact", contactViewModel } });
    }

    [RelayCommand]
    private void AddContact()
    {
        messenger.Send(new ShowContactPopupMessage(new(messenger, contactRepo)));
    }

    private async Task LoadContacts()
    {
        var contacts = await contactRepo.GetAll();
        var contactVms = contacts.Select(c => new ContactViewModel(messenger, contactRepo)
        {
            ContactId = c.Id,
            ContactName = c.Name ?? string.Empty,
            ContactNumber = c.Number ?? string.Empty,
            ContactColor = Color.FromRgb(c.ColorR, c.ColorG, c.ColorB)
        });
        ContactList = new(contactVms);
    }
}
