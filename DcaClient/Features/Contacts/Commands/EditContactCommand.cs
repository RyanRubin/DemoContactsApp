using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class EditContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly IMessenger messenger;

    public EditContactCommand(ContactViewModel vm, IMessenger messenger)
    {
        this.vm = vm;
        this.messenger = messenger;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        messenger.Send(new ShowContactPopupMessage(vm.ShallowCopy()));
    }
}
