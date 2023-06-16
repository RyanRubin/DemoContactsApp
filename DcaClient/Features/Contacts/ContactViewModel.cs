using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common;
using DcaClient.Features.Contacts.Commands;
using DcaModels;
using DcaServices.DataAccess;
using System.ComponentModel;
using System.Windows.Input;

namespace DcaClient.Features.Contacts;

public class ContactViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // code when using MVVM Toolkit
    //
    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(FirstLetterOfContactName))]
    //private string contactName = string.Empty;

    // boilerplate code when using INotifyPropertyChanged
    //
    private string contactName = string.Empty;
    public string ContactName
    {
        get => contactName;
        set
        {
            contactName = value;
            PropertyChanged?.Invoke(this, new(nameof(ContactName)));
            PropertyChanged?.Invoke(this, new(nameof(FirstLetterOfContactName)));
        }
    }

    private string contactNumber = string.Empty;
    public string ContactNumber
    {
        get => contactNumber;
        set
        {
            contactNumber = value;
            PropertyChanged?.Invoke(this, new(nameof(ContactNumber)));
        }
    }

    private Color? contactColor;
    public Color? ContactColor
    {
        get => contactColor;
        set
        {
            contactColor = value;
            PropertyChanged?.Invoke(this, new(nameof(ContactColor)));
        }
    }

    private bool isContactNameValid;
    public bool IsContactNameValid
    {
        get => isContactNameValid;
        set
        {
            isContactNameValid = value;
            PropertyChanged?.Invoke(this, new(nameof(IsContactNameValid)));
            SaveContactCommand?.NotifyCanExecuteChanged();
        }
    }

    public string FirstLetterOfContactName => ContactName.Length > 0 ? ContactName[0].ToString() : string.Empty;

    public int? ContactId { get; set; }

    public ICommand? CallContactCommand { get; private set; }
    public ICommand? TextContactCommand { get; private set; }
    public ICommand? EditContactCommand { get; private set; }
    public IRelayCommand? SaveContactCommand { get; private set; }

    private readonly IMessenger messenger;
    private readonly IRepository<ContactEntity> contactRepo;
    private readonly IPhoneDialer phoneDialer;
    private readonly ISms sms;
    private readonly Shell shell;

    public ContactViewModel(IMessenger messenger, IRepository<ContactEntity> contactRepo, IPhoneDialer phoneDialer, ISms sms, Shell? shell = null)
    {
        this.messenger = messenger;
        this.contactRepo = contactRepo;
        this.phoneDialer = phoneDialer;
        this.sms = sms;
        this.shell = shell ?? RequiredServiceProvider.GetRequiredService<Shell>();
        SetCommands();
    }

    private void SetCommands()
    {
        //CallContactCommand = new CallContactCommand(this, phoneDialer, shell);
        CallContactCommand = new CallContactCommand(this);
        TextContactCommand = new TextContactCommand(this, sms);
        EditContactCommand = new EditContactCommand(this, messenger);
        SaveContactCommand = new SaveContactCommand(this, messenger, contactRepo);
    }

    public ContactViewModel ShallowCopy()
    {
        var clone = (ContactViewModel)MemberwiseClone();
        clone.SetCommands();
        return clone;
    }
}
