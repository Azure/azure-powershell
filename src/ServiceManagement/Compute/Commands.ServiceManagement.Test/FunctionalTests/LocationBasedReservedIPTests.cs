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
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class LocationBasedReservedIPTests: ServiceManagementTest
    {
        private static string vnetName;
        private static string subNet;
        private const string DNS_IP = "208.67.222.222";
        private const string subnet = "Subnet1";
        private const string vnet = "NewVNet4";
        private string serviceName;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var vnetConfig = vmPowershellCmdlets.GetAzureVNetConfig(null);
            if (vnetConfig.Count > 0)
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureService | Remove-AzureService -Force");
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "in use", 5, 30);
            }
            vmPowershellCmdlets.SetAzureVNetConfig(Directory.GetCurrentDirectory() + "\\VnetconfigWithLocation.netcfg");
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Sequential), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateReservedIPThenWindowsVM()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl",5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                var input = new ReservedIPContext()
                {
                    //Address = string.Empty,
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName,
                    State = "Created"
                };

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName, locationName, reservedIpLabel), "Reserve a new IP");
                //Get the reserved ip and verify the reserved Ip properties.
                VerifyReservedIpNotInUse(input);
                // Create a new VM with the reserved ip.
                DnsServer dns = null;
                Utilities.ExecuteAndLog(() => { dns = vmPowershellCmdlets.NewAzureDns(dnsName, DNS_IP); }, "Create a new Azure DNS");
                Utilities.ExecuteAndLog(() =>
                    {
                         PersistentVM vm = CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows);
                         vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, location: locationName, reservedIPName: reservedIpName);
                    },"Create a new windows azure vm with reserved ip.");
                VerifyReservedIpInUse(serviceName,input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVM(vmName, serviceName, true), "Remove Azure VM and verify that a warning is given.");
                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureReservedIP(reservedIpName, true), "Release the reserved ip");
                VerifyReservedIpRemoved(reservedIpName);
                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

         [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Sequential), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateReservedIPThenLinuxVM()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                string affinityGroup = Utilities.GetUniqueShortName("AffGrp");
                var input = new ReservedIPContext()
                {
                    //Address = string.Empty,
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName,
                    State = "Created"
                };

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName, locationName, reservedIpLabel), "Reserve a new IP");
                
                //Get the reserved ip and verify the reserved Ip properties.
                VerifyReservedIpNotInUse(input);
                // Create a new VM with the reserved ip.
                DnsServer dns = null;
                Utilities.ExecuteAndLog(() => { dns = vmPowershellCmdlets.NewAzureDns(dnsName, DNS_IP); }, "Create a new Azure DNS");
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureAffinityGroup(affinityGroup, locationName, affinityGroup, affinityGroup), "Create a new affinity group");

                Utilities.ExecuteAndLog(() =>
                    {
                        PersistentVM vm = CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Linux);
                        vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, affinityGroup: affinityGroup, reservedIPName: reservedIpName);
                    }, "");
                VerifyReservedIpInUse(serviceName, input);
                vmPowershellCmdlets.RemoveAzureDeployment(serviceName,DeploymentSlotType.Production, true);
                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureReservedIP(reservedIpName, true), "Release the reserved ip");
                VerifyReservedIpRemoved(reservedIpName);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureService(serviceName, true), "Delete the hosted service");
                cleanupIfPassed = false;
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityGroup), "Delete the affintiy group");
                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Sequential), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateReservedIPThenWindowsQuickVM()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                string affinityGroup = Utilities.GetUniqueShortName("AffGrp");
                var input = new ReservedIPContext()
                {
                    //Address = string.Empty,
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName,
                    State = "Created"
                };
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName, locationName, reservedIpLabel), "Reserve a new IP");
                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureAffinityGroup(affinityGroup, locationName, affinityGroup, affinityGroup), "Create a new affinity group");
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, null, InstanceSize.Small, username, password, null,affinityGroup, reservedIpName), "Create a new Azure windows Quick VM with reserved ip.");
                VerifyReservedIpInUse(serviceName, input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.StopAzureVM(vmName, serviceName,force:true),"Stop Azure VM");
                VerifyReservedIpInUse(serviceName, input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureService(serviceName, true), "Delete the hosted service");
                cleanupIfPassed = false;
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureReservedIP(reservedIpName, true), "Release the reserved ip");
                VerifyReservedIpRemoved(reservedIpName);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityGroup), "Delete the affintiy group");
                pass = true;
                
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Sequential), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateReservedIPThenLinuxQuickVM()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                string affinityGroup = Utilities.GetUniqueShortName("AffGrp");
                var input = new ReservedIPContext()
                {
                    //Address = string.Empty,
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName,
                    State = "Created"
                };
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName, locationName, reservedIpLabel), "Reserve a new IP");
                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureAffinityGroup(affinityGroup, locationName, affinityGroup, affinityGroup), "Create a new affinity group");
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureQuickVM(OS.Linux, vmName, serviceName, imageName, username, password, locationName, InstanceSize.Small.ToString(), null,  reservedIpName), "Create a new Azure windows Quick VM with reserved ip.");
                VerifyReservedIpInUse(serviceName, input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.StopAzureVM(vmName, serviceName,true), "Stop Azure VM and stay provisioned.");
                VerifyReservedIpInUse(serviceName, input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureService(serviceName, true), "Delete the hosted service");
                cleanupIfPassed = false;
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureReservedIP(reservedIpName, true), "Release the reserved ip"); ;
                VerifyReservedIpRemoved(reservedIpName);
                pass = true;
                
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        #region Helper Methods

        /// <summary>
        /// Verify the properties of the reserved ip
        /// </summary>
        /// <param name="input">ReservedIpContext object containing expected values</param>
        private void VerifyReservedIp(ReservedIPContext input)
        {
            var reservedIps = vmPowershellCmdlets.GetAzureReservedIP(input.ReservedIPName);
            if (reservedIps.Count > 0)
            {
                var reservedIpContext = reservedIps[0];
                Utilities.PrintContext(reservedIpContext);
                Utilities.LogAssert(() => Assert.IsFalse(string.IsNullOrEmpty(reservedIpContext.Address)), "Address");
                Utilities.LogAssert(() => Assert.AreEqual(input.Location, reservedIpContext.Location), "Location");
                Utilities.LogAssert(() => Assert.AreEqual(input.ReservedIPName, reservedIpContext.ReservedIPName), "ReservedIPName");
                Utilities.LogAssert(() => Assert.AreEqual(input.State, reservedIpContext.State), "State");
                Utilities.LogAssert(() => Assert.AreEqual(input.DeploymentName, reservedIpContext.DeploymentName), "DeploymentName");
                Utilities.LogAssert(() => Assert.AreEqual(input.InUse, reservedIpContext.InUse), "InUse");
                Utilities.LogAssert(() => Assert.AreEqual(input.ServiceName, reservedIpContext.ServiceName), "ServiceName");
            }
            else
            {
                Assert.Fail("Didnt find reserved ip with name {0}", input.ReservedIPName);
            }
        }

        private void VerifyReservedIpNotInUse(ReservedIPContext input)
        {
            input.ServiceName = null;
            input.InUse = false;
            input.DeploymentName = null;
            Utilities.ExecuteAndLog(() => VerifyReservedIp(input), string.Format("Verify that the reserved ip {0} is not in use", input.ReservedIPName));
        }

        private void VerifyReservedIpInUse(string serviceName,ReservedIPContext input)
        {
            input.ServiceName = serviceName;
            input.InUse = true;
            input.DeploymentName = serviceName;
            Utilities.ExecuteAndLog(() => VerifyReservedIp(input), string.Format("Verify that the reserved ip {0} is in use", input.ReservedIPName));
        }

        private void VerifyReservedIpRemoved(string reservedIpName)
        {
            Utilities.VerifyFailure(() => vmPowershellCmdlets.GetAzureReservedIP(reservedIpName), ResourceNotFoundException);
        }

        private PersistentVM CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(string vmName, OS os)
        {
            string disk1 = "Disk1";
            int diskSize = 30;
            string availabilitySetName = Utilities.GetUniqueShortName("AvailSet");
            string img = string.Empty;
            
            bool isWindowsOs = false;
            if (os == OS.Windows)
            {
                img = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                isWindowsOs = true;
            }
            else
            {
                img = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);
                isWindowsOs = false;
            }

            PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, img, isWindowsOs,username, password);
            AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize, disk1, 0, HostCaching.ReadWrite.ToString());
            azureDataDiskConfigInfo1.Vm = vm;

            vm = vmPowershellCmdlets.SetAzureSubnet(vm, new string[] {subnet});
            vm = vmPowershellCmdlets.SetAzureAvailabilitySet(availabilitySetName, vm);
            return vm;
        }

        #endregion Helper Methods
    }
}
