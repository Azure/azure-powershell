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
        public static int SetUpDefaultRemoteAppCollection(Mock<IRemoteAppManagementClient> clientMock, string collectionName)
        {
            CollectionListResult response = new CollectionListResult();
            response.Collections = new List<Collection>()
            {
                new Collection()
                {
                    Name = collectionName,
                    Region = "West US",
                    Status = "Active"
                },

                new Collection()
                {
                    Name = "test2",
                    Region = "West US",
                    Status = "Active"
                }
            };

            mockCollectionList = new List<Collection>();
            foreach (Collection collection in response.Collections)
            {
                Collection mockCollection = new Collection()
                {
                    Name = collection.Name,
                    Region = collection.Region,
                    Status = collection.Status
                };
                mockCollectionList.Add(mockCollection);
            }

            ISetup<IRemoteAppManagementClient, Task<CollectionListResult>> setup = clientMock.Setup(c => c.Collections.ListAsync(It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockCollectionList.Count;
        }

        public static int SetUpDefaultRemoteAppCollectionByName(Mock<IRemoteAppManagementClient> clientMock, string collectionName)
        {
            CollectionResult response = new CollectionResult();
            response.Collection = new Collection()
            {
                Name = collectionName,
                Region = "West US",
                Status = "Active"
            };

            mockCollectionList = new List<Collection>()
            {
                new Collection()
                {
                    Name = response.Collection.Name,
                    Region = response.Collection.Region,
                    Status = response.Collection.Status
                }
            };

            ISetup<IRemoteAppManagementClient, Task<CollectionResult>> setup = clientMock.Setup(c => c.Collections.GetAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockCollectionList.Count;
        }

        public static int SetUpDefaultRemoteAppCollectionCreate(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string region, string billingPlan, string imageName, string description, string customProperties, string trackingId)
        {

            CollectionCreationDetails collectionDetails = new CollectionCreationDetails()
            {
                Name = collectionName,
                PlanName = billingPlan,
                TemplateImageName = imageName,
                Mode = CollectionMode.Apps,
                Region = region,
                Description = description,
                CustomRdpProperty = customProperties
            };
   
            List<Collection> collectionList = new List<Collection>()
            {
                new Collection()
                {
                    Name = collectionDetails.Name,
                    Region = collectionDetails.Region,
                    PlanName = collectionDetails.PlanName,
                    TemplateImageName = collectionDetails.TemplateImageName,
                    Mode = collectionDetails.Mode,
                    Description = collectionDetails.Description,
                    Status = "Active"
                }
            };

            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = trackingId,
                RequestId = "111-2222-4444"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setup = clientMock.Setup(c => c.Collections.CreateAsync(It.IsAny<bool>(), It.IsAny <CollectionCreationDetails>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockCollectionList = collectionList;

            return mockCollectionList.Count;
        }

        public static int SetUpDefaultRemoteAppCollectionSet(Mock<IRemoteAppManagementClient> clientMock,string collectionName, string subscriptionId, string billingPlan, string imageName, PSCredential credential, string domainName, string trackingId)
        {

            NetworkCredential cred = credential != null ? credential.GetNetworkCredential() : null;

            CollectionCreationDetails collectionDetails = new CollectionCreationDetails()
            {
                Name = collectionName,
                PlanName = billingPlan,
                TemplateImageName = imageName,
                Mode = CollectionMode.Apps,
                Description = "unit test"
            };

            if (cred != null)
            {
                collectionDetails.AdInfo = new ActiveDirectoryConfig()
                {
                    DomainName = domainName,
                    UserName = cred.UserName,
                    Password = cred.Password
                };
            }

            List<Collection> collectionList = new List<Collection>()
            {
                new Collection()
                {
                    Name = collectionDetails.Name,
                    PlanName = collectionDetails.PlanName,
                    TemplateImageName = collectionDetails.TemplateImageName,
                    Mode = collectionDetails.Mode,
                    Description = collectionDetails.Description,
                    Status = "Active",
                    AdInfo = collectionDetails.AdInfo != null ? collectionDetails.AdInfo : null
                }
            };

            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = trackingId,
                RequestId = "222-3456-789"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setup = 
                clientMock.Setup(
                    c => c.Collections.SetAsync(
                            collectionName, 
                            It.IsAny<bool>(), 
                            It.IsAny<bool>(), 
                            It.IsAny<CollectionUpdateDetails>(), 
                            It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockCollectionList = collectionList;

           return mockCollectionList.Count;
        }

        public static void SetUpDefaultRemoteAppRegionList(Mock<IRemoteAppManagementClient> clientMock)
        {
            ISetup<IRemoteAppManagementClient, Task<RegionListResult>> setup = null;
            RegionListResult response = new RegionListResult()
            {
                RequestId = "23113-442",
                StatusCode = HttpStatusCode.OK,
                Regions = new List<Region>()
                 {
                     new Region()
                     {
                         Name = "West US"
                     },
                     new Region()
                     {
                        Name = "East-US"
                     },
                     new Region()
                     {
                        Name = "North Europe"
                     }
                 }
            };

            mockRegionList = new List<Region>(response.Regions);

            setup = clientMock.Setup(c => c.Collections.RegionListAsync(It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static void SetUpDefaultRemoteAppCollectionDelete(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string trackingId)
        {
            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = trackingId,
                RequestId = "02111-222-3456"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setup = clientMock.Setup(c => c.Collections.DeleteAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static bool ContainsExpectedCollection(List<Collection> expectedResult, Collection actual)
        {
            bool isIdentical = false;
            foreach (Collection expected in expectedResult)
            {
                isIdentical = expected.Name == actual.Name;
                isIdentical &= expected.Region == actual.Region;
                isIdentical &= expected.Status == actual.Status;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedRegion(List<Region> expectedResult, Region actual)
        {
            bool isIdentical = false;
            foreach (Region expected in expectedResult)
            {
                isIdentical = expected.DisplayName == actual.DisplayName;
                isIdentical &= expected.Name == actual.Name;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
