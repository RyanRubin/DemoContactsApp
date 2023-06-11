﻿using DcaClient.Features.Contacts.Commands;
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

    public string FirstLetterOfContactName => ContactName.Length > 0 ? ContactName[0].ToString() : string.Empty;

    public ICommand? CallContactCommand { get; }
    public ICommand? TextContactCommand { get; }
    public ICommand? EditContactCommand { get; }

    public ContactViewModel()
    {
        CallContactCommand = new CallContactCommand(this);
        TextContactCommand = new TextContactCommand(this);
        EditContactCommand = new EditContactCommand(this);
    }
}
