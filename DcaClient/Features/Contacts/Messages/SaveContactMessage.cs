using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DcaClient.Features.Contacts.Messages;

public class SaveContactMessage : ValueChangedMessage<object?>
{
    public SaveContactMessage(object? value) : base(value)
    {
    }
}
