using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DcaClient.Features.Contacts.Messages;

public class SavedContactMessage : ValueChangedMessage<object?>
{
    public SavedContactMessage(object? value) : base(value)
    {
    }
}
