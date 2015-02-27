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
    using Common;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using VisualStudio.TestTools.UnitTesting;

    // Get-AzureRemoteAppCollectionUsageDetails, Get-AzureRemoteAppCollectionUsageSummary, 
    [TestClass]
    public class RemoteAppCollectionTest : RemoteAppClientTest
    {

        [TestMethod]
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
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<Collection> collections = MockObject.ConvertList<Collection>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(collections);

            Assert.IsTrue(collections.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                    countOfExpectedCollections,
                    collections.Count
                )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<Collection>(collections, MockObject.ContainsExpectedCollection),
                "The actual result does not match the expected."
            );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedCollections);
        }


        [TestMethod]
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
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppUser returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<Collection> collections = MockObject.ConvertList<Collection>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(collections);

            Assert.IsTrue(collections.Count == countOfExpectedCollections,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedCollections,
                   collections.Count
               )
           );

            Assert.IsTrue(MockObject.HasExpectedResults<Collection>(collections, MockObject.ContainsExpectedCollection),
               "The actual result does not match the expected."
           );

           Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedCollections);
        }


        [TestMethod]
        [Ignore]
        public void AddCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            NewAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<NewAzureRemoteAppCollection>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Region = region;
            mockCmdlet.BillingPlan = billingPlan;
            mockCmdlet.ImageName = templateName;
            mockCmdlet.Description = description;
            mockCmdlet.CustomRdpProperty = customRDPString;

            // Setup the environment for testing this cmdlet
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollectionCreate(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.Region, mockCmdlet.BillingPlan, mockCmdlet.ImageName, mockCmdlet.Description, mockCmdlet.CustomRdpProperty, trackingId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(trackingIds);

            Assert.IsTrue(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for New-AzureRemoteAppCollection completed successfully");
        }

        [TestMethod]
        public void UpdateCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            UpdaAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<UpdaAzureRemoteAppCollection>();

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
                Assert.Fail(
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(trackingIds);

            Assert.IsTrue(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Update-AzureRemoteAppCollection completed successfully");
        }

        [TestMethod]
        public void SetCollection()
        {
            List<TrackingResult> trackingIds = null;
            int countOfExpectedCollections = 0;
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();

            System.Security.SecureString password = new System.Security.SecureString();
            password.AppendChar('p');

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.BillingPlan = billingPlan;
            mockCmdlet.Credential = new PSCredential(@"MyDomain\Administrator", password);

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppCollectionSet(remoteAppManagementClientMock, mockCmdlet.CollectionName, subscriptionId, mockCmdlet.BillingPlan, String.Empty, mockCmdlet.Credential, domainName, trackingId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("New-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(trackingIds);

            Assert.IsTrue(trackingIds.Count == countOfExpectedCollections,
                String.Format("The expected number of collections returned {0} does not match the actual {1}",
                    countOfExpectedCollections,
                    trackingIds.Count
                 )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for New-AzureRemoteAppCollection completed successfully");
        }

        [TestMethod]
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
                Assert.Fail(
                    String.Format("Remove-AzureRemoteAppCollection returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(trackingIds);

            Assert.IsTrue(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppCollection completed successfully");
        }

        [TestMethod]
        [Ignore]
        public void GetRegionList()
        {
            List<Region> regionList = null;
            List<string> regions = null;
            GetAzureRemoteAppRegionList mockCmdlet = SetUpTestCommon<GetAzureRemoteAppRegionList>();

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppRegionList(remoteAppManagementClientMock);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppRegionList");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppRegionList returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            Assert.IsNotNull(regionList);
            regionList = MockObject.ConvertList<Region>(mockCmdlet.runTime().OutputPipeline);

            Assert.IsTrue(MockObject.HasExpectedResults<string>(regions, MockObject.ContainsExpectedRegion), // This is expecting a List<string> instead of LocalModels.RegionList
                "The actual result does not match the expected."
            );

            Log("The test for Get-AzureRemoteAppRegionList");
        }

    }
}
