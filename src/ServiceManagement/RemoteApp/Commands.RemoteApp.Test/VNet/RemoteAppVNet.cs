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
    using System.Linq;
    using Xunit;

    public class RemoteAppVNetTest : RemoteAppClientTest
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllVNets()
        {
            List<VNet> vNets = null;
            int countOfExpectedVNets = 0;
            GetAzureRemoteAppVNet mockCmdlet = SetUpTestCommon<GetAzureRemoteAppVNet>();

            // Setup the environment for testing this cmdlet
            countOfExpectedVNets = MockObject.SetUpDefaultRemoteAppVNet(remoteAppManagementClientMock, "vNetTest");
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppVNet which should have {0} VNets", countOfExpectedVNets);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            vNets = MockObject.ConvertList<VNet>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(vNets);

            Assert.True(vNets.Count == countOfExpectedVNets,
                String.Format("The expected number of VNets returned {0} does not match the actual {1}",
                    countOfExpectedVNets,
                    vNets.Count
                )
            );

            Assert.True(MockObject.HasExpectedResults<VNet>(vNets, MockObject.ContainsExpectedVNet),
                 "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppVNet with {0} VNets completed successfully", countOfExpectedVNets);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetVNetsByName()
        {
            List<VNet> vNets = null;
            int countOfExpectedVNets = 0;
            GetAzureRemoteAppVNet mockCmdlet = SetUpTestCommon<GetAzureRemoteAppVNet>();

            // Required parameters for this test
            mockCmdlet.VNetName = "vNetTest";
            mockCmdlet.IncludeSharedKey = true;

            // Setup the environment for testing this cmdlet
            countOfExpectedVNets = MockObject.SetUpDefaultRemoteAppVNetByName(remoteAppManagementClientMock, mockCmdlet.VNetName, mockCmdlet.IncludeSharedKey);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppVNet which should have {0} VNets", countOfExpectedVNets);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            vNets = MockObject.ConvertList<VNet>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(vNets);

            Assert.True(vNets.Count == countOfExpectedVNets,
                String.Format("The expected number of VNets returned {0} does not match the actual {1}",
                    countOfExpectedVNets,
                    vNets.Count
                )
            );

            Assert.True(MockObject.HasExpectedResults<VNet>(vNets, MockObject.ContainsExpectedVNet),
                 "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppVNet with {0} VNets completed successfully", countOfExpectedVNets);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddVNetsThatDontExist()
        {
            List<TrackingResult> trackingIds = null;
            VNetParameter vNetDetails = new VNetParameter()
            {
                Region = region,
                VnetAddressSpaces = new List<string>() { "10.0.0.0/16" },
                LocalAddressSpaces = new List<string>() { "11.0.0.0/16" },
                DnsServers = new List<string>() { "11.0.0.10" },
                VpnAddress = "13.0.0.1",
                GatewayType = GatewayType.StaticRouting
            };
            int countOfAddedVNets = 0;
            NewAzureRemoteAppVNet mockCmdlet = SetUpTestCommon<NewAzureRemoteAppVNet>();


            // Required parameters for this test
            mockCmdlet.VNetName = "vNetTest1";
            mockCmdlet.Location = vNetDetails.Region;
            mockCmdlet.VirtualNetworkAddressSpace = vNetDetails.VnetAddressSpaces.ToArray();
            mockCmdlet.LocalNetworkAddressSpace = vNetDetails.LocalAddressSpaces.ToArray();
            mockCmdlet.DnsServerIpAddress = vNetDetails.DnsServers.ToArray();
            mockCmdlet.VpnDeviceIpAddress = vNetDetails.VpnAddress;
            mockCmdlet.GatewayType = vNetDetails.GatewayType;

            // Setup the environment for testing this cmdlet
            countOfAddedVNets = MockObject.SetUpDefaultRemoteAppAddVNet(remoteAppManagementClientMock, vNetDetails);
            mockCmdlet.ResetPipelines();

            Log("Calling Add-AzureRemoteAppVNet which should have {0} VNets", countOfAddedVNets);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Add-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Add-AzureRemoteAppVNet completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetVNetsThatDoExist()
        {
            List<TrackingResult> trackingIds = null;
            VNetParameter vNetDetails = new VNetParameter()
            {
                VnetAddressSpaces = new List<string>() { "10.0.0.0/16" },
                LocalAddressSpaces = new List<string>() { "11.0.0.0/16" },
                DnsServers = new List<string>() { "11.0.0.10" },
                VpnAddress = "13.0.0.1"
            };
            int countOfAddedVNets = 0;
            SetAzureRemoteAppVNet mockCmdlet = SetUpTestCommon<SetAzureRemoteAppVNet>();


            // Required parameters for this test
            mockCmdlet.VNetName = "vNetTest1";
            mockCmdlet.VirtualNetworkAddressSpace = vNetDetails.VnetAddressSpaces.ToArray();
            mockCmdlet.LocalNetworkAddressSpace = vNetDetails.LocalAddressSpaces.ToArray();
            mockCmdlet.DnsServerIpAddress = vNetDetails.DnsServers.ToArray();
            mockCmdlet.VpnDeviceIpAddress = vNetDetails.VpnAddress;

            // Setup the environment for testing this cmdlet
            countOfAddedVNets = MockObject.SetUpDefaultRemoteAppAddVNet(remoteAppManagementClientMock, vNetDetails);
            mockCmdlet.ResetPipelines();

            Log("Calling Set-AzureRemoteAppVNet which should have {0} VNets", countOfAddedVNets);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Set-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Set-AzureRemoteAppVNet completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveVNetsThatDoExist()
        {
            List<TrackingResult> trackingIds = null;
            RemoveAzureRemoteAppVNet mockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppVNet>();

            // Required parameters for this test
            mockCmdlet.VNetName = "vNetTest";

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppRemoveVNet(remoteAppManagementClientMock, mockCmdlet.VNetName);
            mockCmdlet.ResetPipelines();

            Log("Calling Remove-AzureRemoteAppVNet");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            trackingIds = MockObject.ConvertList<TrackingResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(trackingIds);

            Assert.True(MockObject.HasExpectedResults<TrackingResult>(trackingIds, MockObject.ContainsExpectedTrackingId),
               "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppVNet completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetVpnDevices()
        {
            List<Vendor> vpnDevices = null; 
            int countOfExpectedVNetVpnDevices = 0;
            GetAzureRemoteAppVpnDevice mockCmdlet = SetUpTestCommon<GetAzureRemoteAppVpnDevice>();

            // Required parameters for this test
            mockCmdlet.VNetName = "Vnet";

            // Setup the environment for testing this cmdlet
            countOfExpectedVNetVpnDevices = MockObject.SetUpDefaultVpnDevice(remoteAppManagementClientMock, mockCmdlet.VNetName);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppVNet which should have {0} VNets", countOfExpectedVNetVpnDevices);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppVNet returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            vpnDevices = MockObject.ConvertList<Vendor>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(vpnDevices);

            Assert.True(vpnDevices.Count == countOfExpectedVNetVpnDevices,
                String.Format("The expected number of VNets returned {0} does not match the actual {1}",
                    countOfExpectedVNetVpnDevices,
                    vpnDevices.Count
                )
            );

            Log("The test for Get-AzureRemoteAppVNet with {0} VNets completed successfully", countOfExpectedVNetVpnDevices);
        }
    }
}
