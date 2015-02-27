namespace Microsoft.Azure.Commands.Test.RemoteApp
{
    using Common;
    using Microsoft.Azure.Management.RemoteApp;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.Azure.Management.RemoteApp.Fakes;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using Microsoft.QualityTools.Testing.Fakes;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoteAppCollectionSessionsTests : RemoteAppClient
    {
        [TestMethod]
        public void CanGetNoSessionsFromCollectionWithNoSessions()
        {
            String collection0SessionName = "testcollection";
            String requestId = Guid.NewGuid().ToString();
            DateTime logonTimeUtc = DateTime.UtcNow;

            Mock<ICommandRuntime> mockRuntime = new Mock<ICommandRuntime>();

////            Mock<RemoteAppManagementClient> mockClient = new Mock<RemoteAppManagementClient>();
//            RemoteAppManagementClient client = new RemoteAppManagementClient();

//            Mock<IRemoteAppCollectionOperations> mockCollectionOperations = Mock.Get(client.Collections);

////            mockClient.SetupGet(f => f.Collections).Returns(mockCollectionOperations.Object);

//            mockCollectionOperations.Setup(f => f.ListSessions(collection0SessionName)).Returns(() =>
//            {
//                CollectionSessionListResult sessionList = new CollectionSessionListResult()
//                {
//                    RequestId = requestId,
//                    StatusCode = HttpStatusCode.OK,
//                    Sessions = new List<RemoteAppSession>()
//                };

//                return sessionList;
//            });

            //using (ShimsContext.Create())
            //{
            //    ShimRemoteAppCollectionOperationsExtensions.ListSessionsIRemoteAppCollectionOperationsString = (intf, collectionName) =>
            //    {
            //        CollectionSessionListResult sessionList = new CollectionSessionListResult()
            //        {
            //            RequestId = requestId,
            //            StatusCode = HttpStatusCode.OK,
            //            Sessions = new List<RemoteAppSession>()
            //        };

            //        return sessionList;
            //    };

            //    GetAzureRemoteAppSessions sessionsCmdlet = new GetAzureRemoteAppSessions()
            //    {
            //        CommandRuntime = mockRuntime.Object,
            //        CollectionName = collection0SessionName
            //    };

            //    sessionsCmdlet.ExecuteCmdlet();

            //    //mockCollectionOperations.Verify(f => f.ListSessions(collection0SessionName), Times.Once());
            //    mockRuntime.Verify(f => f.WriteVerbose(It.IsAny<String>()), Times.Once());
            //}
        }

        [TestMethod]
        public void CanGetSessionsFromCollectionWithSessions()
        {
            //String collectionName = "testcollection";
            //String requestId = Guid.NewGuid().ToString();
            //DateTime logonTimeUtc = DateTime.UtcNow;

            //Mock<IRemoteAppManagementClient> mockClient = new Mock<IRemoteAppManagementClient>();
            //Mock<IRemoteAppCollectionOperations> mockCollectionOperations = Mock.Get(mockClient.Object.Collections);

            //Mock<ICommandRuntime> mockRuntime = new Mock<ICommandRuntime>();

            //List<RemoteAppSession> sessions = new List<RemoteAppSession>(){
            //            new RemoteAppSession(){
            //                LogonTimeUtc = logonTimeUtc,
            //                State = Management.RemoteApp.Models.SessionState.Connected,
            //                UserUpn = "test1@test.com"
            //            },
            //            new RemoteAppSession(){
            //                LogonTimeUtc = logonTimeUtc,
            //                State = Management.RemoteApp.Models.SessionState.Disconnected,
            //                UserUpn = "test2@test.com"
            //            },
            //        };

            //mockCollectionOperations.Setup(f => f.ListSessions(collectionName)).Returns(() =>
            //{
            //    CollectionSessionListResult sessionList = new CollectionSessionListResult()
            //    {
            //        RequestId = requestId,
            //        StatusCode = HttpStatusCode.OK,
            //        Sessions = sessions
            //    };

            //    return sessionList;
            //});

            //GetAzureRemoteAppSessions sessionsCmdlet = new GetAzureRemoteAppSessions()
            //{
            //    Client = mockClient.Object,
            //    CommandRuntime = mockRuntime.Object,
            //    CollectionName = collectionName
            //};

            //sessionsCmdlet.ExecuteCmdlet();

            //mockCollectionOperations.Verify(f => f.ListSessions(collectionName), Times.Once());
            //mockRuntime.Verify(f => f.WriteObject(sessions, true), Times.Once());
        }
    }
}
