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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common
{
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.Azure;
    using Moq;
    using Moq.Language.Flow;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static void SetUpDefaultRemoteAppRemoveUserDisk(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string userUpn)
        {
            AzureOperationResponse response = new AzureOperationResponse()
            {
                RequestId = "12345",
                StatusCode = System.Net.HttpStatusCode.Accepted
            };

            ISetup<IRemoteAppManagementClient, Task<AzureOperationResponse>> setup =
                clientMock.Setup(c => c.UserDisks.DeleteAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static void SetUpDefaultRemoteAppCopyUserDisk(Mock<IRemoteAppManagementClient> clientMock, string sourceCollectionName, string destinationCollectionName, string userUpn, bool overwriteExistingUserDisk)
        {
            AzureOperationResponse response = new AzureOperationResponse()
            {
                RequestId = "12345",
                StatusCode = System.Net.HttpStatusCode.Accepted
            };

            ISetup<IRemoteAppManagementClient, Task<AzureOperationResponse>> setup =
                clientMock.Setup(c => c.UserDisks.CopyAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));
        }
    }
}
