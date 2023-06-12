using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DcaClient.Features.Contacts.Messages;

public class CloseContactPopupMessage : ValueChangedMessage<object?>
{
    public CloseContactPopupMessage(object? value) : base(value)
    {
    }
}
