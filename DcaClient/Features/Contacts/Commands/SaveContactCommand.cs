﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Features.Contacts.Messages;
using DcaModels;
using DcaServices.DataAccess;

namespace DcaClient.Features.Contacts.Commands;

public class SaveContactCommand : IRelayCommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly ContactViewModel vm;
    private readonly IMessenger messenger;
    private readonly IRepository<ContactEntity> contactRepo;

    public SaveContactCommand(ContactViewModel vm, IMessenger messenger, IRepository<ContactEntity> contactRepo)
    {
        this.vm = vm;
        this.messenger = messenger;
        this.contactRepo = contactRepo;
    }

    public bool CanExecute(object? parameter)
    {
        return vm.IsContactNameValid;
    }

    public void Execute(object? parameter)
    {
        var random = new Random();
        contactRepo.Add(new ContactEntity
        {
            Name = vm.ContactName,
            Number = vm.ContactNumber,
            ColorR = 128 + random.Next(128),
            ColorG = 128 + random.Next(128),
            ColorB = 128 + random.Next(128)
        });
        messenger.Send(new SaveContactMessage(null));
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, new());
    }
}
