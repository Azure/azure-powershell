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
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static void SetUpDefaultWorkspace(Mock<IRemoteAppManagementClient> clientMock, string clientUrl, string endUserFeedName)
        {
            ISetup<IRemoteAppManagementClient, Task<GetAccountResult>> Setup = null;
            GetAccountResult response = new GetAccountResult()
            {
                RequestId = "7834-12346",
                StatusCode = System.Net.HttpStatusCode.OK,
                Details = new AccountDetails() 
                {
                    ClientUrl = clientUrl,
                    EndUserFeedName = endUserFeedName
                }
            };

            mockWorkspace = new List<Workspace>()
            {
                new Workspace(response)
            };

            Setup = clientMock.Setup(c => c.Account.GetAsync(It.IsAny<CancellationToken>()));
            Setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static void SetUpDefaultEditWorkspace(Mock<IRemoteAppManagementClient> clientMock, string endUserFeedName)
        {
            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> Setup = null;
            AccountDetailsParameter details = new AccountDetailsParameter()
            {
                AccountInfo = new AccountDetails()
                {
                    EndUserFeedName = endUserFeedName
                }
            };

            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = "34167",
                RequestId = "111-2222-4444"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            Setup = clientMock.Setup(c => c.Account.SetAsync(It.IsAny<AccountDetailsParameter>(), It.IsAny<CancellationToken>()));
            Setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static bool ContainsExpectedWorkspace(List<Workspace> expectedResult, Workspace operationResult)
        {
            bool isIdentical = false;
            foreach (Workspace expected in expectedResult)
            {
                isIdentical = expected.ClientUrl == operationResult.ClientUrl;
                isIdentical &= expected.EndUserFeedName == operationResult.EndUserFeedName;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}