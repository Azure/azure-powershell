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

namespace Microsoft.Azure.Commands.RemoteApp.Test
{
    using Common;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Xunit;

    // Get-AzureRemoteAppCollectionUsageDetails, Get-AzureRemoteAppCollectionUsageSummary, 
    public class RemoteAppCollectionTest : RemoteAppClientTest
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllCollections()
        {
            int countOfExpectedCollections = 0;
            GetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<GetAzureRemoteAppCollection>();

            // Setup the environment for testing this cmdlet
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollection(remoteAppManagementClientMock, collectionName);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedCollections);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<Collection> collections = MockObject.ConvertList<Collection>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(collections);

            Assert.True(collections.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                    countOfExpectedCollections,
                    collections.Count
                )
            );

            Assert.True(MockObject.HasExpectedResults<Collection>(collections, MockObject.ContainsExpectedCollection),
                "The actual result does not match the expected."
            );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedCollections);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetCollectionsByName()
        {
            int countOfExpectedCollections = 1;
            GetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<GetAzureRemoteAppCollection>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection to get this collection {0}.", mockCmdlet.CollectionName);

            mockCmdlet.ExecuteCmdlet();

            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppUser returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<Collection> collections = MockObject.ConvertList<Collection>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(collections);

            Assert.True(collections.Count == countOfExpectedCollections,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedCollections,
                   collections.Count
               )
           );

            Assert.True(MockObject.HasExpectedResults<Collection>(collections, MockObject.ContainsExpectedCollection),
               "The actual result does not match the expected."
           );

           Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedCollections);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            NewAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<NewAzureRemoteAppCollection>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Location = region;
            mockCmdlet.Plan = billingPlan;
            mockCmdlet.ImageName = templateName;
            mockCmdlet.Description = description;
            mockCmdlet.CustomRdpProperty = customRDPString;

            // Setup the environment for testing this cmdlet
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollectionCreate(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.Location, mockCmdlet.Plan, mockCmdlet.ImageName, mockCmdlet.Description, mockCmdlet.CustomRdpProperty, trackingId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for New-AzureRemoteAppCollection completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            UpdateAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<UpdateAzureRemoteAppCollection>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.ImageName = templateName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollectionSet(remoteAppManagementClientMock, mockCmdlet.CollectionName, subscriptionId, String.Empty, mockCmdlet.ImageName, null, String.Empty, trackingId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Update-AzureRemoteAppCollection completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();

            System.Security.SecureString password = new System.Security.SecureString();
            password.AppendChar('p');

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Plan = billingPlan;
            mockCmdlet.Credential = new PSCredential(@"MyDomain\Administrator", password);

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollectionSet(remoteAppManagementClientMock, mockCmdlet.CollectionName, subscriptionId, mockCmdlet.Plan, String.Empty, mockCmdlet.Credential, domainName, trackingId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for New-AzureRemoteAppCollection completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveCollection()
        {
            List<TrackingResult> trackingIds = null;
            RemoveAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppCollection>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            MockObject.SetUpDefaultRemoteAppCollectionDelete(remoteAppManagementClientMock, mockCmdlet.CollectionName, trackingId);
            mockCmdlet.ResetPipelines();

            Log("Calling Remove-AzureRemoteAppCollection");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppCollection completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRegionList()
        {
            List<Region> regionList = null;
            GetAzureRemoteAppLocation mockCmdlet = SetUpTestCommon<GetAzureRemoteAppLocation>();

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppRegionList(remoteAppManagementClientMock);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppRegionList");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppRegionList returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            regionList = MockObject.ConvertList<Region>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(regionList);

            Assert.True(MockObject.HasExpectedResults<Region>(regionList, MockObject.ContainsExpectedRegion),
                "The actual result does not match the expected."
            );

            Log("The test for Get-AzureRemoteAppRegionList");
        }

    }
}
