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

    // Publish-AzureRemoteAppProgram, Unpublish-AzureRemoteAppProgram

    public class RemoteAppProgramTest : RemoteAppClientTest
    {
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllRemoteApps()
        {
            List<PublishedApplicationDetails> remoteApps = null;
            int countOfExpectedApps = 0;
            GetAzureRemoteAppProgram mockCmdlet = SetUpTestCommon<GetAzureRemoteAppProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppApplications(remoteAppManagementClientMock, mockCmdlet.CollectionName);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<PublishedApplicationDetails>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(remoteApps);

            Assert.True(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.True(MockObject.HasExpectedResults<PublishedApplicationDetails>(remoteApps, MockObject.ContainsExpectedApplication),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRemoteAppByName()
        {
            List<PublishedApplicationDetails> remoteApps = null;
            int countOfExpectedApps = 0;
            GetAzureRemoteAppProgram mockCmdlet = SetUpTestCommon<GetAzureRemoteAppProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Alias = "1340fc";

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppApplicationsByName(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.Alias);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<PublishedApplicationDetails>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(remoteApps);

            Assert.True(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.True(MockObject.HasExpectedResults<PublishedApplicationDetails>(remoteApps, MockObject.ContainsExpectedApplication),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllStartMenuApplication()
        {
            List<StartMenuApplication> remoteApps = null;
            int countOfExpectedApps = 0;
            GetStartMenuProgram mockCmdlet = SetUpTestCommon<GetStartMenuProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppStartMenu(remoteAppManagementClientMock, mockCmdlet.CollectionName);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<StartMenuApplication>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(remoteApps);

            Assert.True(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.True(MockObject.HasExpectedResults<StartMenuApplication>(remoteApps, MockObject.ContainsExpectedStartMenu),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }
    }
}
