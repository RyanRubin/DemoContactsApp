using CommunityToolkit.Mvvm.Messaging;
using DcaClient.Common;
using DcaClient.Features.Contacts;
using DcaModels;
using DcaServices.DataAccess;
using Moq;
//using Microsoft.Maui.ApplicationModel.Communication;

namespace DcaClientTest.Features.Contacts;

public class ContactListViewModelTests
{
    private readonly IMessenger messenger = Mock.Of<IMessenger>();
    private readonly IRepository<ContactEntity> contactRepo = Mock.Of<IRepository<ContactEntity>>();
    private readonly INavigator navigator = Mock.Of<INavigator>();
    //private readonly IPhoneDialer phoneDialer = Mock.Of<IPhoneDialer>();
    //private readonly ISms sms = Mock.Of<ISms>();

    private readonly ContactListViewModel systemUnderTest;

    public ContactListViewModelTests()
    {
    }

    [Fact]
    public void Test1()
    {

    }
}
