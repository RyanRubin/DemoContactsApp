using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DcaClient.Features.Contacts.Messages;

public class ShowContactPopupMessage : ValueChangedMessage<ContactViewModel>
{
    public ShowContactPopupMessage(ContactViewModel value) : base(value)
    {
    }
}
