using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using DcaModels;
using DcaServices.DataAccess;
using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class SaveContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly IMessenger messenger;
    private readonly IRepository<ContactEntity> contactRepo;

    public SaveContactCommand(ContactViewModel vm, IMessenger messenger, IRepository<ContactEntity> contactRepo)
    {
        this.vm = vm;
        this.messenger = messenger;
        this.contactRepo = contactRepo;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        contactRepo.Add(new ContactEntity { Name = vm.ContactName, Number = vm.ContactNumber });
        messenger.Send(new CloseContactPopupMessage(null));
    }
}
