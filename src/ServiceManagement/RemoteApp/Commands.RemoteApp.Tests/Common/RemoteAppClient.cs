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

namespace Microsoft.Azure.Commands.Test.RemoteApp
{
    using Microsoft.Azure.Management.RemoteApp;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using System;

    public class RemoteAppClientCredentials : SubscriptionCloudCredentials
    {
        private string Id;
        public RemoteAppClientCredentials(string subscriptionId) { Id = subscriptionId; }

        public override string SubscriptionId 
        { 
            get { return Id; }
        }
    }

    public abstract class RemoteAppClientTest : TestBase
    {
        protected const string subscriptionId = "foo";

        protected const string collectionName = "test1";

        protected const string templateName = "Fake_Windows.vhd";

        protected const string billingPlan = "Standard";

        protected const string trackingId = "12345";

        protected const string region = "West US";

        protected const string domainName = "testDomain";

        protected const string description = "unit test";

        protected const string customRDPString = "custom";

        protected const string remoteApplication = "Mohoro Test App";

        protected Action<string> logger { get; private set; }

        public MockCommandRuntime mockCommandRuntime { get; private set; }

        protected Mock<IRemoteAppManagementClient> remoteAppManagementClientMock { get; private set; }

        protected RemoteAppClientTest()
        {
            mockCommandRuntime = new MockCommandRuntime();
            remoteAppManagementClientMock = new Mock<IRemoteAppManagementClient>();
        }

        protected T SetUpTestCommon<T>() where T : RdsCmdlet, new()
        {
            T RemoteAppCmdlet = null;

            RemoteAppCmdlet = new T()
            {
                CommandRuntime = mockCommandRuntime,
                Client = remoteAppManagementClientMock.Object
            };
            return RemoteAppCmdlet;
        }
    }
}
