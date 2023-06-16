using System.Windows.Input;

namespace DcaClient.Features.Contacts.Commands;

public class TextContactCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly ISms sms;

    public TextContactCommand(ContactViewModel vm, ISms sms)
    {
        this.vm = vm;
        this.sms = sms;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        if (!sms.IsComposeSupported)
        {
            return;
        }

        string[] recipients = new[] { vm.ContactNumber };
        string text = "Hello.";

        var message = new SmsMessage(text, recipients);

        await sms.ComposeAsync(message);
    }
}
