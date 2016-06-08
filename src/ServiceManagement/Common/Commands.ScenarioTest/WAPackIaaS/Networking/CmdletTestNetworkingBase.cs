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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    public class CmdletTestNetworkingBase : CmdletTestBase
    {
        protected class Cmdlets
        {
            public const string NewWAPackVNet = "New-WAPackVNet";
            public const string NewWAPackVMSubnet = "New-WAPackVMSubnet";
            public const string NewWAPackStaticIPAddressPool = "New-WAPackStaticIPAddressPool";
            public const string GetWAPackLogicalNetwork = "Get-WAPackLogicalNetwork";
            public const string GetWAPackVNet = "Get-WAPackVNet";
            public const string GetWAPackVMSubnet = "Get-WAPackVMSubnet";
            public const string GetWAPackStaticIPAddressPool = "Get-WAPackStaticIPAddressPool";
            public const string RemoveWAPackVNet = "Remove-WAPackVNet";
            public const string RemoveWAPackVMSubnet = "Remove-WAPackVMSubnet";
            public const string RemoveWAPackStaticIPAddressPool = "Remove-WAPackStaticIPAddressPool";
        }

        // Network properties
        protected const string staticIPAddressPoolName = "TestStaticIPAddressPoolForNetworkingTests";
        protected const string vmSubnetName = "TestVMSubnetForNetworkingTests";
        protected const string vNetName = "TestVNetForNetworkingTests";
        protected const string vNetDescription = "Description - TestVNetForNetworkingTests";
        protected const string subnet = "192.168.1.0/24";
        protected const string ipAddressRangeStart = "192.168.1.2";
        protected const string ipAddressRangeEnd = "192.168.1.10";

        protected List<PSObject> createdVNet;
        protected List<PSObject> createdVMSubnet;
        protected List<PSObject> createdStaticIPAddressPool;

        // Error handling
        protected const string nonExistantResourceExceptionMessage = "The remote server returned an error: (404) Not Found.";
        protected const string assertFailedNonExistantRessourceExceptionMessage = "Assert.IsFalse failed. " + nonExistantResourceExceptionMessage;

        protected CmdletTestNetworkingBase()
        {
            this.createdVNet = new List<PSObject>();
            this.createdVMSubnet = new List<PSObject>();
            this.createdStaticIPAddressPool = new List<PSObject>();
        }
        protected void CreateFullVNet()
        {
            this.CreateVNet();
            this.CreateVMSubnet();
            this.CreateStaticIPAddressPool();
        }

        protected void CreateVNet()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvezLogicalNetworkName}
            };
            var existingLogicalNetwork = this.InvokeCmdlet(Cmdlets.GetWAPackLogicalNetwork, inputParams, null);
            Assert.AreEqual(1, existingLogicalNetwork.Count, string.Format("{0} LogicalNetwork Found, {1} LogicalNetwork Was Expected.", existingLogicalNetwork.Count, 1));

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vNetName},
                {"Description", vNetDescription},
                {"LogicalNetwork", existingLogicalNetwork.First()}
            };
            var createdVNet = this.InvokeCmdlet(Cmdlets.NewWAPackVNet, inputParams, null);
            Assert.AreEqual(1, createdVNet.Count, string.Format("{0} VNet Found, {1} VNet Was Expected.", createdVNet.Count, 1));
            this.createdVNet.AddRange(createdVNet);
        }

        protected void CreateVMSubnet()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmSubnetName},
                {"VNet", this.createdVNet.First()},
                {"Subnet", subnet}
            };
            var createdSubnet = this.InvokeCmdlet(Cmdlets.NewWAPackVMSubnet, inputParams, null);
            Assert.AreEqual(1, createdSubnet.Count, string.Format("{0} VMSubnet Found, {1} VMSubnet Was Expected.", createdSubnet.Count, 1));
            createdVMSubnet.AddRange(createdSubnet);
        }

        protected void CreateStaticIPAddressPool()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", staticIPAddressPoolName},
                {"VMSubnet", this.createdVMSubnet.First()},
                {"IPAddressRangeStart", ipAddressRangeStart},
                {"IPAddressRangeEnd", ipAddressRangeEnd}
            };
            var createdStaticIPAddressPool = this.InvokeCmdlet(Cmdlets.NewWAPackStaticIPAddressPool, inputParams, null);
            Assert.AreEqual(1, createdStaticIPAddressPool.Count, string.Format("{0} StaticIPAddressPool Found, {1} StaticIPAddressPool Was Expected.", createdStaticIPAddressPool.Count, 1));
            this.createdStaticIPAddressPool.AddRange(createdStaticIPAddressPool);
        }

        protected void RemoveVNet()
        {
            // No need to remove individual components (StaticIPAddressPool, VMSubnet) since 
            // Remove-WAPackVNet will revove all components before removing the VNet.
            foreach (var vNet in this.createdVNet)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"VNet", vNet},
                    {"Force", null},
                    {"PassThru", null}
                };
                var isDeleted = this.InvokeCmdlet(Cmdlets.RemoveWAPackVNet, inputParams);
                Assert.AreEqual(1, isDeleted.Count);
                Assert.AreEqual(true, isDeleted.First());

                inputParams = new Dictionary<string, object>()
                {
                    {"Name", vNetName}
                };
                var deletedVNet = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams, null);
                Assert.AreEqual(0, deletedVNet.Count);
            }
            this.createdVNet.Clear();
        }

        protected void NetworkingPreTestCleanup()
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>()
            {
                {"Name", vNetName}
            };
            var existingVNet = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams, null);

            if (existingVNet.Any())
            {
                this.createdVNet.AddRange(existingVNet);
                this.RemoveVNet();
            }
        }
    }
}
