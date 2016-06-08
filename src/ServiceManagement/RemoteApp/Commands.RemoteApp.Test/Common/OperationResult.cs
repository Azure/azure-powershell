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
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Moq;
    using Moq.Language.Flow;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static int SetUpDefaultRemoteAppOperationResult(Mock<IRemoteAppManagementClient> clientMock, string trackingId)
        {
            ISetup<IRemoteAppManagementClient, Task<RemoteAppOperationStatusResult>> setup = null;

            RemoteAppOperationStatusResult response = new RemoteAppOperationStatusResult()
            {
                RequestId = "77394",
                StatusCode = HttpStatusCode.OK,
                RemoteAppOperationResult = new OperationResult()
                {
                    Description = "The Operation has completed successfully",
                    ErrorDetails = null,
                    Status = RemoteAppOperationStatus.Success
                }
            };

            mockOperationResult = new List<OperationResult>()
            {
                new OperationResult()
                {
                    Description = response.RemoteAppOperationResult.Description,
                    ErrorDetails = response.RemoteAppOperationResult.ErrorDetails,
                    Status = response.RemoteAppOperationResult.Status
                }
            };

            setup = clientMock.Setup(c => c.OperationResults.GetAsync(trackingId, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockOperationResult.Count;
        }

        public static bool ContainsExpectedOperationResult(List<OperationResult> expectedResult, OperationResult operationResult)
        {
            bool isIdentical = false;

            foreach (OperationResult expected in expectedResult)
            {
                isIdentical = expected.Description == operationResult.Description;
                isIdentical &= expected.ErrorDetails == operationResult.ErrorDetails;
                isIdentical &= expected.Status == operationResult.Status;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
