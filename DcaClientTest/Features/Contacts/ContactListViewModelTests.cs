using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common;
using DcaClient.Features.Contacts;
using DcaModels;
using DcaServices.DataAccess;
using Moq;

namespace DcaClientTest.Features.Contacts;

public class ContactListViewModelTests
{
    private readonly IMessenger messenger = Mock.Of<IMessenger>();
    private readonly IRepository<ContactEntity> contactRepo = Mock.Of<IRepository<ContactEntity>>();
    private readonly IClientShell navigator = Mock.Of<IClientShell>();
    private readonly IPhoneDialer phoneDialer = Mock.Of<IPhoneDialer>();
    private readonly ISms sms = Mock.Of<ISms>();

    private readonly ContactListViewModel systemUnderTest;

    public ContactListViewModelTests()
    {
        systemUnderTest = new(messenger, contactRepo, navigator, phoneDialer, sms);
    }

    [Fact]
    public async Task InitializeViewModel_ShouldLoadContacts()
    {
        var testData = new[] {
            new ContactEntity { Name = "Name A", Number = "123" },
            new ContactEntity { Name = "Name B", Number = "456" }
        };
        Mock.Get(contactRepo).Setup(repo => repo.GetAll()).ReturnsAsync(testData);

        await systemUnderTest.InitializeViewModel();

        var expected = testData;
        var actual = systemUnderTest.FilteredContactList;
        Assert.Collection(actual, actual0 =>
        {
            Assert.Equal(expected[0].Name, actual0.ContactName);
            Assert.Equal(expected[0].Number, actual0.ContactNumber);
        }, actual1 =>
        {
            Assert.Equal(expected[1].Name, actual1.ContactName);
            Assert.Equal(expected[1].Number, actual1.ContactNumber);
        });
    }

    [Fact]
    public async Task ViewContactCommand_ShouldNavigateToContactDetails()
    {
        await systemUnderTest.ViewContactCommand.ExecuteAsync(null);

        Mock.Get(navigator).Verify(nav => nav.GoToAsync(
            It.IsAny<ShellNavigationState>(),
            It.IsAny<IDictionary<string, object>>()
            ), Times.Once);
    }
}
