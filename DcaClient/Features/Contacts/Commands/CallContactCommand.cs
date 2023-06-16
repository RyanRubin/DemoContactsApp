using CommunityToolkit.Maui.Alerts;
using DcaClient.Common;
using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class CallContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly IPhoneDialer phoneDialer;
    private readonly Shell shell;

    public CallContactCommand(ContactViewModel vm, IPhoneDialer? phoneDialer = null, Shell? shell = null)
    {
        this.vm = vm;
        this.phoneDialer = phoneDialer ?? RequiredServiceProvider.GetRequiredService<IPhoneDialer>();
        this.shell = shell ?? RequiredServiceProvider.GetRequiredService<Shell>();
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
            shell.CurrentPage.DisplaySnackbar("Phone dialer is not supported.");
            shell.CurrentPage.DisplayAlert(string.Empty, "Phone dialer is not supported.", "OK");
            return;
        }

        phoneDialer.Open(vm.ContactNumber);
    }
}
