// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test
{
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common;


    public class RemoteAppClientCredentials : SubscriptionCloudCredentials
    {
        private string Id;
        public RemoteAppClientCredentials(string subscriptionId) { Id = subscriptionId; }

        public override string SubscriptionId 
        { 
            get { return Id; }
        }
    }

    public abstract class RemoteAppClientTest : SMTestBase
    {
        protected const string subscriptionId = "foo";

        protected const string collectionName = "test1";

        protected const string secondaryCollectionName = "test2";

        protected const bool OverwriteExistingUserDisk = false;

        protected const string vmName = "testVm";

        protected const string loggedInUserUpn = "test@somedomain.com";

        protected const string templateName = "Fake_Windows.vhd";

        protected const string billingPlan = "Standard";

        protected const string trackingId = "12345";

        protected const string region = "West US";

        protected const string domainName = "testDomain";

        protected const string description = "unit test";

        protected const string customRDPString = "custom";

        protected const string remoteApplication = "Mohoro Test App";

        protected const string appAlias = "9bd99659-9772-4689-af10-7ac72e43c28e";

        protected Action<string> logger { get; private set; }

        public MockCommandRuntime mockCommandRuntime { get; private set; }

        protected Mock<IRemoteAppManagementClient> remoteAppManagementClientMock { get; set; }

        protected Mock<Microsoft.WindowsAzure.Management.ManagementClient> mgmtClient {get; set; }

        protected RemoteAppClientTest()
        {
            mockCommandRuntime = new MockCommandRuntime();
            remoteAppManagementClientMock = new Mock<IRemoteAppManagementClient>();
            remoteAppManagementClientMock.SetupProperty(c => c.RdfeNamespace, "remoteapp");
        }

        protected T SetUpTestCommon<T>() where T : RdsCmdlet, new()
        {
            T RemoteAppCmdlet = null;
            ISetup<Microsoft.WindowsAzure.Management.ManagementClient, Task<AzureOperationResponse>> setup = null;

            AzureOperationResponse response = new AzureOperationResponse()
            {
                RequestId = "1",
                StatusCode = System.Net.HttpStatusCode.OK
            };
            mgmtClient = new Mock<WindowsAzure.Management.ManagementClient>();
            setup = mgmtClient.Setup(c => c.Subscriptions.RegisterResourceAsync("remoteapp", It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            RemoteAppCmdlet = new T()
            {
                CommandRuntime = mockCommandRuntime,
                Client = remoteAppManagementClientMock.Object,
                ActiveDirectoryHelper = new MockAdHelper(),
                MgmtClient = mgmtClient.Object
            };

            return RemoteAppCmdlet;
        }
    }
}
