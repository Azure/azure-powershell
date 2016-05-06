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
        }

        [Fact]
        public void PatchCollectionTest()
        {
            UpdateAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<UpdateAzureRemoteAppCollection>();
            string collectionName = "mycol";
            string expectedTrackingId = "2432145";
            String imageName = "my template image";
            CollectionUpdateDetails requestData = null;
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.ImageName = imageName;
            requestData = new CollectionUpdateDetails()
            {
                TemplateImageName = mockCmdlet.ImageName
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Active"
            };

            PerfomrCollectionTestHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetCollection()
        {
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();
            string collectionName = "mycol";
            string expectedTrackingId = "2432145";
            CollectionUpdateDetails requestData = null;
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Plan = billingPlan;
            requestData = new CollectionUpdateDetails()
            {
                PlanName = mockCmdlet.Plan,
                AdInfo = null
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Active"
            };

            PerfomrCollectionTestHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, false);
        }

        [Fact]
        public void SetCollectionCustomRdpPropertyTest()
        {
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();
            string collectionName = "mycol";
            string expectedTrackingId = "fdadffdas";
            CollectionUpdateDetails requestData = null;
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.CustomRdpProperty = "some:value:*";
            requestData = new CollectionUpdateDetails()
            {
                CustomRdpProperty = mockCmdlet.CustomRdpProperty
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Active"
            };

            PerfomrCollectionTestHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, false);
        }

        [Fact]
        public void SetCollectionDescriptionTest()
        {
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();
            string collectionName = "mycol";
            string expectedTrackingId = "213145";
            CollectionUpdateDetails requestData = null;
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.Description = "This is my test collection";
            requestData = new CollectionUpdateDetails()
            {
                Description = mockCmdlet.Description
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Active"
            };

            PerfomrCollectionTestHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, false);

        }

        private void PerformCollectionTestWithAdInfoHelper(
            RdsCmdlet mockCmdlet,
            string collectionName,
            Collection expectedCollection,
            String trackingId,
            CollectionUpdateDetails reqestData,
            bool forceRedeploy)
        {
            ISetup<IRemoteAppManagementClient, Task<CollectionResult>> setupGet = null;
            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setupSetApi = null;
            MockCommandRuntime cmdRuntime = null;
            IEnumerable<TrackingResult> trackingIds = null;

            // Setup the environment for testing this cmdlet
            setupGet = remoteAppManagementClientMock.Setup(c => c.Collections.GetAsync(collectionName, It.IsAny<CancellationToken>()));

            setupGet.Returns(Task.Factory.StartNew(
                () =>
                    new CollectionResult()
                    {
                        Collection = expectedCollection,
                        StatusCode = System.Net.HttpStatusCode.OK
                    }));

            setupSetApi = remoteAppManagementClientMock.Setup(
                        c => c.Collections.SetAsync(
                                collectionName,
                                forceRedeploy,
                                false,
                                It.Is<CollectionUpdateDetails>(col =>
                                            col.CustomRdpProperty == reqestData.CustomRdpProperty &&
                                            col.Description == reqestData.Description &&
                                            col.PlanName == reqestData.PlanName &&
                                            col.TemplateImageName == reqestData.TemplateImageName &&
                                            (col.AdInfo == null ||
                                                (reqestData.AdInfo != null &&
                                                    col.AdInfo.DomainName == reqestData.AdInfo.DomainName &&
                                                    col.AdInfo.OrganizationalUnit == reqestData.AdInfo.OrganizationalUnit &&
                                                    col.AdInfo.UserName == reqestData.AdInfo.UserName &&
                                                    col.AdInfo.Password == reqestData.AdInfo.Password)
                                                 )
                                             ),
                                It.IsAny<CancellationToken>()));
            setupSetApi.Returns(Task.Factory.StartNew(() => new OperationResultWithTrackingId()
            {
                TrackingId = trackingId
            }));

            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();

            cmdRuntime = mockCmdlet.runTime();
            if (cmdRuntime.ErrorStream.Count > 0)
            {
                Assert.True(cmdRuntime.ErrorStream.Count == 0,
                        String.Format("Set-AzureRemoteAppCollection returned the following error {0}",
                            mockCmdlet.runTime().ErrorStream[0].Exception.Message));
            }

            trackingIds = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            Assert.NotNull(trackingIds);

            Assert.Equal(1, trackingIds.Count());

            Assert.True(trackingIds.Any(t => t.TrackingId == trackingId), "The actual result does not match the expected.");
        }


        private void PerfomrCollectionTestHelper(
            RdsCmdlet mockCmdlet,
            string collectionName,
            Collection expectedCollection,
            String trackingId,
            CollectionUpdateDetails reqestData,
            bool forceRedeploy)
        {
            ISetup<IRemoteAppManagementClient, Task<CollectionResult>> setupGet = null;
            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setupSetApi = null;
            MockCommandRuntime cmdRuntime = null;
            IEnumerable<TrackingResult> trackingIds = null;

            // Setup the environment for testing this cmdlet
            setupGet = remoteAppManagementClientMock.Setup(c => c.Collections.GetAsync(collectionName, It.IsAny<CancellationToken>()));

            setupGet.Returns(Task.Factory.StartNew(
                () =>
                    new CollectionResult()
                    {
                        Collection = expectedCollection,
                        StatusCode = System.Net.HttpStatusCode.OK
                    }));

            setupSetApi = remoteAppManagementClientMock.Setup(
                        c => c.Collections.SetAsync(
                                collectionName,
                                forceRedeploy,
                                false,
                                It.Is<CollectionUpdateDetails>(col =>
                                            col.CustomRdpProperty == reqestData.CustomRdpProperty &&
                                            col.Description == reqestData.Description &&
                                            col.PlanName == reqestData.PlanName &&
                                            col.TemplateImageName == reqestData.TemplateImageName &&
                                            col.AdInfo == null),
                                It.IsAny<CancellationToken>()));
            setupSetApi.Returns(Task.Factory.StartNew(() => new OperationResultWithTrackingId()
            {
                TrackingId = trackingId
            }));

            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();

            cmdRuntime = mockCmdlet.runTime();
            if (cmdRuntime.ErrorStream.Count > 0)
            {
                Assert.True(cmdRuntime.ErrorStream.Count == 0,
                        String.Format("Set-AzureRemoteAppCollection returned the following error {0}",
                            mockCmdlet.runTime().ErrorStream[0].Exception.Message));
            }

            trackingIds = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            Assert.NotNull(trackingIds);

            Assert.Equal(1, trackingIds.Count());

            Assert.True(trackingIds.Any(t => t.TrackingId == trackingId), "The actual result does not match the expected.");
        }

        [Fact]
        public void SetCollectionAdConfigTest()
        {
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();
            string collectionName = "mycol";
            System.Security.SecureString password = new System.Security.SecureString();
            string expectedTrackingId = "2432145";
            CollectionUpdateDetails requestData = null;
            string userName = @"Administrator@MyDomain";
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            password.AppendChar('p');
            mockCmdlet.Credential = new PSCredential(userName, password);
            requestData = new CollectionUpdateDetails()
            {
                AdInfo = new ActiveDirectoryConfig()
                {
                    UserName = userName,
                    Password = "p"
                }
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Active",
                AdInfo = new ActiveDirectoryConfig()
            };

            PerformCollectionTestWithAdInfoHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, false);
        }

        [Fact]
        public void SetInactiveCollectionAdConfigTest()
        {
            SetAzureRemoteAppCollection mockCmdlet = SetUpTestCommon<SetAzureRemoteAppCollection>();
            string collectionName = "mycol";
            System.Security.SecureString password = new System.Security.SecureString();
            string expectedTrackingId = "fasdfsadfsdf";
            CollectionUpdateDetails requestData = null;
            string userName = @"MyDomain\Administrator";
            Collection expectedCollection = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            password.AppendChar('f');
            mockCmdlet.Credential = new PSCredential(userName, password);
            requestData = new CollectionUpdateDetails()
            {
                AdInfo = new ActiveDirectoryConfig()
                {
                    UserName = userName,
                    Password = "f"
                }
            };

            expectedCollection = new Collection()
            {
                Name = collectionName,
                Status = "Inactive",
                AdInfo = new ActiveDirectoryConfig()
            };

            PerformCollectionTestWithAdInfoHelper(mockCmdlet, collectionName, expectedCollection, expectedTrackingId, requestData, true);
        }

        [Fact]
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
