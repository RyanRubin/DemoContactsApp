using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DcaClient.Features.Contacts.Messages;

public class SavedContactMessage : ValueChangedMessage<ContactViewModel>
{
    public SavedContactMessage(ContactViewModel value) : base(value)
    {
    }
}
