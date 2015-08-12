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

using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test
{
    using Common;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    // Get-AzureRemoteAppCollectionUsageDetails, Get-AzureRemoteAppCollectionUsageSummary, 
    public class RemoteAppVmTest : RemoteAppClientTest
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartVm()
        {
            int countOfExpectedCollections = 0;
            RestartAzureRemoteAppVm mockCmdlet = SetUpTestCommon<RestartAzureRemoteAppVm>();
            IEnumerable<TrackingResult> trackingIds = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.UserUpn = loggedInUserUpn;

            // Setup the environment for testing this cmdlet
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppVm(remoteAppManagementClientMock, collectionName, vmName, loggedInUserUpn, trackingId);
            mockCmdlet.ResetPipelines();

            Log("Calling Restart-AzureRemoteAppVm which should return tracking id.");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Restart-AzureRemoteAppVm returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            trackingIds = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            Assert.NotNull(trackingIds);

            Assert.Equal(1, trackingIds.Count());

            Assert.True(trackingIds.Any(t => t.TrackingId == trackingId), "The actual result does not match the expected.");
        }
    }
}
