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
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static int SetUpDefaultRemoteAppVNet(Mock<IRemoteAppManagementClient> clientMock, string vNetName)
        {
            VNetListResult response = new VNetListResult();

            response.VNetList = new List<VNet>()
            {
                new VNet()
                {
                    Name = vNetName,
                    Region = "West US", 
                    State = VNetState.Ready
                },
                new VNet()
                {
                    Name = "test2",
                    Region = "East US",
                    State = VNetState.Provisioning
                }
            };

            mockVNetList = new List<VNet>();
            foreach (VNet vNet in response.VNetList)
            {
                VNet mockVNet = new VNet()
                {
                    Name = vNet.Name,
                    Region = vNet.Region,
                    State = vNet.State
                };

                mockVNetList.Add(mockVNet);
            }

            ISetup<IRemoteAppManagementClient, Task<VNetListResult>> setup = clientMock.Setup(c => c.VNet.ListAsync(It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockVNetList.Count;
        }

        public static int SetUpDefaultRemoteAppVNetByName(Mock<IRemoteAppManagementClient> clientMock, string vNetName, bool IncludeSharedKey)
        {
            VNetResult response = new VNetResult();
            response.VNet = new VNet()
            {
                Name = vNetName,
                Region = "West US",
                SharedKey = "22222",
                State = VNetState.Ready
            };

            mockVNetList = new List<VNet>()
            {
                new VNet()
                {
                    Name = response.VNet.Name,
                    Region = response.VNet.Region,
                    SharedKey = response.VNet.SharedKey,
                    State = response.VNet.State
                }
            };

            ISetup<IRemoteAppManagementClient, Task<VNetResult>> setup = clientMock.Setup(c => c.VNet.GetAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockVNetList.Count;
        }

        public static int SetUpDefaultRemoteAppAddVNet(Mock<IRemoteAppManagementClient> clientMock, VNetParameter vNetDetails)
        {
            List<VNet> vnetList = new List<VNet>()
            {
                new VNet()
                {
                    Region = vNetDetails.Region,
                    VnetAddressSpaces = vNetDetails.VnetAddressSpaces,
                    LocalAddressSpaces = vNetDetails.LocalAddressSpaces,
                    DnsServers = vNetDetails.DnsServers,
                    VpnAddress = vNetDetails.VpnAddress,
                    GatewayType = vNetDetails.GatewayType
                }
            };

            mockVNetList = vnetList;

            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = "12345",
                RequestId = "111-2222-4444"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setup =
                clientMock.Setup(c => c.VNet.CreateOrUpdateAsync(It.IsAny<string>(), It.IsAny<VNetParameter>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockVNetList.Count;
        }

        public static void SetUpDefaultRemoteAppRemoveVNet(Mock<IRemoteAppManagementClient> clientMock, string name)
        {
            OperationResultWithTrackingId response = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = "225986",
                RequestId = "6233-2222-4444"
            };

            mockTrackingId = new List<TrackingResult>()
            {
                new TrackingResult(response)
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setup =
                clientMock.Setup(c => c.VNet.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));
        }

        public static int SetUpDefaultResetVpnSharedKey(Mock<IRemoteAppManagementClient> clientMock, string trackingId)
        {
            ISetup<IRemoteAppManagementClient, Task<VNetOperationStatusResult>> setup = null;
            VNetOperationStatusResult response = new VNetOperationStatusResult()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                RequestId = "6233-2222-4444",
                Status = VNetOperationStatus.Success
            };

            mockVNetStatusList = new List<VNetOperationStatus>();
            mockVNetStatusList.Add(response.Status);

            setup = clientMock.Setup(c => c.VNet.GetResetVpnSharedKeyOperationStatusAsync(trackingId, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockVNetStatusList.Count;
        }

        public static int SetUpDefaultVpnDevice(Mock<IRemoteAppManagementClient> clientMock, string name)
        {
            ISetup<IRemoteAppManagementClient, Task<VNetVpnDeviceResult>> setup = null;

            VNetVpnDeviceResult response = new VNetVpnDeviceResult()
            {
                RequestId = "23411-345",
                StatusCode = System.Net.HttpStatusCode.OK,
                Vendors = new Vendor[]
                    { 
                        new Vendor()
                        {
                            Name = "Acme",
                            Platforms = new List<Platform>()
                            { 
                                new Platform()
                                {
                                    Name = "BasicVPN",
                                    OsFamilies = new List<OsFamily>()
                                }
                            }
                        }
                    }
            };

            mockVpnList = new List<Vendor>(response.Vendors);

            setup = clientMock.Setup(c => c.VNet.GetVpnDevicesAsync(name, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockVpnList.Count;
        }

        public static bool ContainsExpectedVNet(List<VNet> expectedResult, VNet operationResult)
        {
            bool isIdentical = false;
            foreach (VNet expected in expectedResult)
            {
                isIdentical = expected.Name == operationResult.Name;
                isIdentical &= expected.Region == operationResult.Region;
                isIdentical &= expected.SharedKey == operationResult.SharedKey;
                isIdentical &= expected.State == operationResult.State;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedVendor(List<Vendor> vendors, Vendor vendor)
        {
            return false;
        }

        public static bool ContainsExpectedSharedKeyResult(List<VNetOperationStatus> expectedResult, VNetOperationStatus operationResult)
        {
            bool isIdentical = false;
            foreach (VNetOperationStatus expected in expectedResult)
            {
                isIdentical = expected == operationResult;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
