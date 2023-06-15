using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using DcaModels;
using DcaServices.DataAccess;

namespace DcaClient.Features.Contacts.Commands;

public class SaveContactCommand : IRelayCommand
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
        return vm.IsContactNameValid;
    }

    public void Execute(object? parameter)
    {
        if (!vm.ContactId.HasValue)
        {
            var random = new Random();
            var contact = contactRepo.Add(new ContactEntity
            {
                Name = vm.ContactName,
                Number = vm.ContactNumber,
                ColorR = 128 + random.Next(128),
                ColorG = 128 + random.Next(128),
                ColorB = 128 + random.Next(128)
            });
            vm.ContactId = contact.Id;
        }
        else
        {
            contactRepo.Update(new ContactEntity
            {
                Id = vm.ContactId.Value,
                Name = vm.ContactName,
                Number = vm.ContactNumber
            });
        }
        messenger.Send(new SavedContactMessage(null));
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, new());
    }
}
