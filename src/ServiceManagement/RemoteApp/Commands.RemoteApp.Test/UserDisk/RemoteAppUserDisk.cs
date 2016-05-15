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

    public class RemoteAppUserDiskTest : RemoteAppClientTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveUserDisk()
        {
            RemoveAzureRemoteAppUserDisk mockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppUserDisk>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.UserUpn = loggedInUserUpn;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppRemoveUserDisk(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.UserUpn);

            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppUserDisk returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            Log("The test for Remove-AzureRemoteAppUserDisk completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CopyUserDisk()
        {
            CopyAzureRemoteAppUserDisk mockCmdlet = SetUpTestCommon<CopyAzureRemoteAppUserDisk>();

            // Required parameters for this test
            mockCmdlet.SourceCollectionName = collectionName;
            mockCmdlet.DestinationCollectionName = secondaryCollectionName;
            mockCmdlet.UserUpn = loggedInUserUpn;
            mockCmdlet.OverwriteExistingUserDisk = OverwriteExistingUserDisk;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCopyUserDisk(remoteAppManagementClientMock, mockCmdlet.SourceCollectionName, mockCmdlet.DestinationCollectionName, mockCmdlet.UserUpn, mockCmdlet.OverwriteExistingUserDisk);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Copy-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            Log("The test for Copy-AzureRemoteAppTemplate completed successfully");
        }
    }
}
