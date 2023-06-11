using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DcaClient.Features.Contacts;

public partial class ContactListViewModel : ObservableObject
{
    [ObservableProperty]
    private string searchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ContactViewModel> contactList = new();

    [RelayCommand]
    private void ViewContact(ContactViewModel contactViewModel)
    {

    }

    [RelayCommand]
    private void AddContact()
    {

    }
}
