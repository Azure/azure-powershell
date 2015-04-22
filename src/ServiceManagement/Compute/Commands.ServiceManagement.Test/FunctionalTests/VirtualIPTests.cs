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

using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
    using System.IO;
    using System.Linq;

    [TestClass]
    public class VirtualIPTests : ServiceManagementTest
    {
        private const string DNS_IP = "208.67.222.222";
        private const string subnet = "Subnet1";
        private const string vnet = "NewVNet4";
        private string serviceName;
        private static string vnetName;
        private static string subNet;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var vnetConfig = vmPowershellCmdlets.GetAzureVNetConfig(null);
            vmPowershellCmdlets.SetAzureVNetConfig(Directory.GetCurrentDirectory() + "\\Resources\\VnetconfigWithLocation.netcfg");
            var sites = vmPowershellCmdlets.GetAzureVNetSite(null);
            subNet = sites[0].Subnets.First().Name;
            vnetName = sites[0].Name;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "Remove Azure Vnet config after tests");
        }

        [TestInitialize]
        public void Intialize()
        {
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            cleanupIfPassed = true;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (cleanupIfPassed)
                Utilities.ExecuteAndLog(() => CleanupService(serviceName), "Delete service");
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Preview), Owner("avgupt"),
         Description(
             "Test the cmdlets (Add-AzureVirtualIP, Add-AzureEndpoint, Remove-AzureEndpoint, Get-AzureDeployment,Remove-AzureVirtualIP)"
             )]
        public void TestVirtualIPLifecycle()
        {
            try
            {
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string vipName = Utilities.GetUniqueShortName("Vip");
                string endpointName = Utilities.GetUniqueShortName("Endpoint");
                // Create a new VM with the reserved ip.
                DnsServer dns = null;
                Utilities.ExecuteAndLog(() => { dns = vmPowershellCmdlets.NewAzureDns(dnsName, DNS_IP); },
                    "Create a new Azure DNS");
                PersistentVM vm = null;
                Utilities.ExecuteAndLog(() =>
                {
                    vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows,
                        username, password, subnet);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] {vm}, vnet, new[] {dns}, location: locationName);
                }, "Create a new windows azure vm without reserved ip.");

                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.AddAzureVirtualIP(vipName, serviceName), "Adding Azure VirtualIP");

                var deployment = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                var retrievedVip = deployment.VirtualIPs.FirstOrDefault(vip => string.Equals(vip.Name, vipName));
                Assert.IsNotNull(retrievedVip);
                Assert.IsTrue(string.IsNullOrEmpty(retrievedVip.Address));

                AzureEndPointConfigInfo endpointInfo = new AzureEndPointConfigInfo
                {
                    EndpointName = endpointName,
                    EndpointProtocol = ProtocolInfo.tcp,
                    EndpointLocalPort = 1000,
                    EndpointPublicPort = 444,
                    VirtualIPName = vipName,
                    Vm = vm
                };

                var updatedVM = vmPowershellCmdlets.AddAzureEndPoint(endpointInfo);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, updatedVM);
                deployment = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                retrievedVip = deployment.VirtualIPs.FirstOrDefault(vip => string.Equals(vip.Name, vipName));
                Assert.IsNotNull(retrievedVip);
                Assert.IsTrue(!string.IsNullOrEmpty(retrievedVip.Address));

                AzureEndPointConfigInfo removeEndpointInfo = new AzureEndPointConfigInfo
                {
                    EndpointName = endpointName,
                    EndpointProtocol = ProtocolInfo.tcp,
                    EndpointLocalPort = 1000,
                    EndpointPublicPort = 444,
                    VirtualIPName = vipName,
                    Vm = updatedVM
                };

                updatedVM = vmPowershellCmdlets.RemoveAzureEndPoint(endpointName, updatedVM);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, updatedVM);

                deployment = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                retrievedVip = deployment.VirtualIPs.FirstOrDefault(vip => string.Equals(vip.Name, vipName));
                Assert.IsNotNull(retrievedVip);
                Assert.IsTrue(string.IsNullOrEmpty(retrievedVip.Address));

                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVirtualIP(vipName, serviceName), "Adding Azure VirtualIP");
                
                deployment = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                retrievedVip = deployment.VirtualIPs.FirstOrDefault(vip => string.Equals(vip.Name, vipName));
                Assert.IsNull(retrievedVip);
                cleanupIfPassed = false;

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, "Production", true);
                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

    }
}
