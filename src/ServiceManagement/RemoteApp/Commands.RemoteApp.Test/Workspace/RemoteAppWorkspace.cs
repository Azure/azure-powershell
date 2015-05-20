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
    using Xunit;

    public class RemoteAppWorkspace : RemoteAppClientTest
    {
        string EndUserFeedName = "MockFeed";
        string ClientUrl = "https://remoteapp.contoso.com/feed";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetWorkspace()
        {
            List<Workspace> workspace = null;
            GetAzureRemoteAppWorkspace mockCmdlet = SetUpTestCommon<GetAzureRemoteAppWorkspace>();

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultWorkspace(remoteAppManagementClientMock, ClientUrl, EndUserFeedName);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppWorkspace");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppWorkspace returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            workspace = MockObject.ConvertList<Workspace>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(workspace);

            Assert.True(MockObject.HasExpectedResults<Workspace>(workspace, MockObject.ContainsExpectedWorkspace),
                "The actual result does not match the expected."
            );

            Log("The test for Get-AzureRemoteAppWorkspace completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetWorkspace()
        {
            List<TrackingResult> trackingIds = null;
            string EndUserFeedName = "MockAwesomeFeed";
            SetAzureRemoteAppWorkspace mockCmdlet = SetUpTestCommon<SetAzureRemoteAppWorkspace>();

            // Required parameters for this test
            mockCmdlet.WorkspaceName = EndUserFeedName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultWorkspace(remoteAppManagementClientMock, ClientUrl, EndUserFeedName);
            MockObject.SetUpDefaultEditWorkspace(remoteAppManagementClientMock, EndUserFeedName);
            mockCmdlet.ResetPipelines();

            Log("Calling Set-AzureRemoteAppWorkspace");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Set-AzureRemoteAppWorkspace returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingId);

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Set-AzureRemoteAppWorkspace completed successfully");
        }
    }
}
