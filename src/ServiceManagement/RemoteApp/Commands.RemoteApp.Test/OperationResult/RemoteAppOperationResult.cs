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
    using Common;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Xunit;

    public class RemoteAppOperationResult : RemoteAppClientTest
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResult()
        {
            List<OperationResult> operationResult = null;

            int countOfExpectedResults = 0;
            GetAzureRemoteAppOperationResult mockCmdlet = SetUpTestCommon<GetAzureRemoteAppOperationResult>();

            // Required parameters for this test
            mockCmdlet.TrackingId = "1234";

            // Setup the environment for testing this cmdlet
            countOfExpectedResults = MockObject.SetUpDefaultRemoteAppOperationResult(remoteAppManagementClientMock, mockCmdlet.TrackingId);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppOperationResult this tracking id ", mockCmdlet.TrackingId);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            operationResult = MockObject.ConvertList<OperationResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(operationResult);

            Assert.True(operationResult.Count == countOfExpectedResults,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedResults,
                    operationResult.Count
                )
            );

            Assert.True(MockObject.HasExpectedResults<OperationResult>(operationResult, MockObject.ContainsExpectedOperationResult),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", mockCmdlet.TrackingId);
        }
    }
}
