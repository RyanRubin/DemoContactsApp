using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class SaveContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;

    public SaveContactCommand(ContactViewModel vm)
    {
        this.vm = vm;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {

    }
}
