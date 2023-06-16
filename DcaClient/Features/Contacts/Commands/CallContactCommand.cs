using CommunityToolkit.Maui.Alerts;
using DcaClient.Common;
using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class CallContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly IPhoneDialer phoneDialer;
    private readonly IClientShell shell;

    public CallContactCommand(ContactViewModel vm, IPhoneDialer phoneDialer, IClientShell shell)
    {
        this.vm = vm;
        this.phoneDialer = phoneDialer;
        this.shell = shell;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        bool isWindows = false;
#if WINDOWS
        isWindows = true;
#endif

        if (!phoneDialer.IsSupported || isWindows)
        {
            shell.DisplaySnackbar("Phone dialer is not supported.");
            shell.DisplayAlert(string.Empty, "Phone dialer is not supported.", "OK");
            return;
        }

        phoneDialer.Open(vm.ContactNumber);
    }
}
