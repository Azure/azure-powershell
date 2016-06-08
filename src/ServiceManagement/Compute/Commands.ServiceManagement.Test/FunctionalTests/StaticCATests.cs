
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class StaticCATests:ServiceManagementTest
    {
        //Give  affintiy group name
        private const string AffinityGroup = "WestUsAffinityGroup";
        private const string VNetName = "NewVNet1";
        private static readonly List<string> LocalNets = new List<string>();
        private static readonly List<string> VirtualNets = new List<string>();
        private static readonly HashSet<string> AffinityGroups = new HashSet<string>();
        static readonly List<DnsServer> DnsServers = new List<DnsServer>();
        private static readonly List<LocalNetworkSite> LocalNetworkSites = new List<LocalNetworkSite>();
        static string serviceName;
        const string StaticCASubnet0 = "Subnet1";
        const string StaticCASubnet1 = "GatewaySubnet";
        const string IPUnavaialbleExceptionMessage = "Networking.DeploymentVNetAddressAllocationFailure";

        [ClassInitialize]
        public static void Intialize(TestContext context)
        {
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            var vnetConfig = vmPowershellCmdlets.GetAzureVNetConfig(null);
            ReadVnetConfig();
            SetVNetForStaticCAtest();
        }

        [TestInitialize]
        public void TestIntialize()
        {
            pass = false;
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            testStartTime = DateTime.Now;
        }

        #region Test cases
        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void DeployVMWithStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Test a static CA
                const string ipaddress = "10.0.0.5";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM with a static CA.
                var vm = CreatIaasVMObject(vmName, ipaddress, StaticCASubnet0);

                vmPowershellCmdlets.NewAzureVM(serviceName, new[] {vm}, vnet1, new DnsServer[1] {DnsServers[0]},
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup,
                    null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);

                //Verfications
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                var vmContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                vmPowershellCmdlets.RemoveAzureStaticVNetIP(vmContext.VM);
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void AddVMWithStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
            string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                const string ipaddress = "10.0.0.6";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName1, serviceName, imageName, new string[1] { StaticCASubnet0 }, InstanceSize.Small, username, password, VNetName, AffinityGroup);

                //Add an IaaS VM with a static CA
                var vm = CreatIaasVMObject(vmName2, ipaddress, StaticCASubnet0);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, null); 

                //Verify that the DIP of the VM2 is reserved.
                VerifyVmWithStaticCAIsReserved(vmName2, serviceName, ipaddress);

                //Verify that the DIP of the VM1 is NOT reserved.
                VerfiyVmWithoutStaticCAIsNotReserved(vmName1, serviceName);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                var vmContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName);
                vmPowershellCmdlets.RemoveAzureStaticVNetIP(vmContext.VM);
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]        
        public void UpdateVMWithNewStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                const string ipaddress = "10.0.0.7";
                //Test a static CA
                Console.WriteLine("Checking if ipaddress {0} is available", ipaddress);
                CheckAvailabilityofIpAddress(vnet1, ipaddress);
                Console.WriteLine("ipaddress {0} is available", ipaddress);

                //Create an IaaS VM
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName1, serviceName, imageName, new string[1] { StaticCASubnet0 }, InstanceSize.Small, username, password, VNetName, AffinityGroup);

                //Update the IaaS VM with a static CA
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName);
                string nonStaticIpAddress = vmRoleContext.IpAddress;
                Console.WriteLine("Non static IpAddress of the vm {0} is {1}", vmName1, nonStaticIpAddress);
                var vm = vmPowershellCmdlets.SetAzureStaticVNetIP(ipaddress, vmRoleContext.VM);
                vmPowershellCmdlets.UpdateAzureVM(vmName1, serviceName, vm);

                //Verify that the DIP of the VM is matched with an input.
                VerifyVmWithStaticCAIsReserved(vmName1, serviceName, ipaddress);

                //Verify that the first DIP is released.
                Console.WriteLine("Checking for the availability of non static IpAdress after giving a static CA to the VM");

                Thread.Sleep(TimeSpan.FromMinutes(2));

                var availabilityContext = vmPowershellCmdlets.TestAzureStaticVNetIP(vnet1, nonStaticIpAddress);

                Utilities.RetryActionUntilSuccess(
                    () => Assert.IsTrue(availabilityContext.IsAvailable, "Non static IpAddress {0} is not realesed.",nonStaticIpAddress),
                    "Non static IpAddress", 3, 60);
                //Assert.IsTrue(availabilityContext.IsAvailable, "Non static IpAddress {0} is not realesed.",nonStaticIpAddress);
                Utilities.PrintContext(availabilityContext);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void UpdateToStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            //string vnet1 = virtualNets[0];
            string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Create an IaaS VM
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName1, serviceName, imageName, new string[1] { StaticCASubnet0 }, InstanceSize.Small, username, password, VNetName, AffinityGroup);

                //Update the IaaS VM with a static CA
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName);
                string ipaddress = vmRoleContext.IpAddress;
                Console.WriteLine("Non static IpAddress of the vm {0} is {1}", vmName1, ipaddress);
                PersistentVM vm = vmPowershellCmdlets.SetAzureStaticVNetIP(ipaddress, vmRoleContext.VM);
                vmPowershellCmdlets.UpdateAzureVM(vmName1, serviceName, vm);

                //Verify that the DIP of the VM is matched with an input.
                VerifyVmWithStaticCAIsReserved(vmName1, serviceName, ipaddress);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void UnreserveStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Test a static CA
                const string ipaddress = "10.0.0.9";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM with a static CA.
                var vm = CreatIaasVMObject(vmName, ipaddress, StaticCASubnet0);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup, null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);

                //Verfications
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);

                //Remove-AzureStaticIP
                Console.WriteLine("Removing Static CA for the VM {0}", vmName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName,serviceName);
                vm = vmPowershellCmdlets.RemoveAzureStaticVNetIP(vmRoleContext.VM);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Console.WriteLine("Static CA for the VM {0} removed", vmName);

                //Verify that VM doesnt have a static VNet IP address anymore.
                Console.WriteLine("Verifying that the DIP of the VM is not Static CA");
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Assert.IsNull(vmPowershellCmdlets.GetAzureStaticVNetIP(vmRoleContext.VM), "VM has Static Vnet IP Address after executing Remove-AzureStaticVNetIP command also.");
                Console.WriteLine("No static IP is assigned to the VM.");
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void TryToReserveExistingCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string serviceName2  = Utilities.GetUniqueShortName(serviceNamePrefix);
            string serviceName3  = Utilities.GetUniqueShortName(serviceNamePrefix);
            string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
            string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
            string vmName3 = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                string nonStaticIpAddress = string.Empty;

                //Create an IaaS VM
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName1, serviceName, imageName, new string[1] { StaticCASubnet0 }, InstanceSize.Small, username, password, VNetName, AffinityGroup);
                //Get the DIP of the VM (Get-AzureVM)
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName);
                nonStaticIpAddress = vmRoleContext.IpAddress;

                //Assert that the DIP is not available (Test-AzureStaticVNetIP)
                CheckAvailabilityOfIpAddressAndAssertFalse(vnet1, nonStaticIpAddress);

                //Try to deploy an IaaS VM with the same static CA (CreateDeployment) and Verify that the deployment failed
                //Add an IaaS VM with a static CA
                Console.WriteLine("Deploying an IaaS VM with the same static CA {0} (CreateDeployment)", nonStaticIpAddress);
                var vm = CreatIaasVMObject(vmName2, nonStaticIpAddress, StaticCASubnet0);
                //Verify that the deployment failed.
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureVM(serviceName2, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                        serviceName, "service for AddVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup),
                        IPUnavaialbleExceptionMessage);
                Console.WriteLine("Deployment with Static CA {0} failed as expectd", nonStaticIpAddress);

                //Try to deploy an IaaS VM with the same static CA (AddRole) and verify that the deployment fails
                //Add an IaaS VM with a static CA
                Console.WriteLine("Deploying an IaaS VM with the same static CA {0} (AddRole)", nonStaticIpAddress);
                vm = CreatIaasVMObject(vmName3, nonStaticIpAddress, StaticCASubnet0);
                //Verify that the deployment failed.
                Utilities.VerifyFailure(() => vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }),IPUnavaialbleExceptionMessage);
                Console.WriteLine("Deployment with Static CA {0} failed as expectd", nonStaticIpAddress);

                Console.WriteLine("Waiting for 2 minutes...");
                Thread.Sleep(TimeSpan.FromMinutes(2));
                //Reserve the DIP of the VM1
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1,serviceName);
                vm = vmPowershellCmdlets.SetAzureStaticVNetIP(nonStaticIpAddress, vmRoleContext.VM);
                vmPowershellCmdlets.UpdateAzureVM(vmName1, serviceName, vm);

                //Verify that the DIP is reserved
                VerifyVmWithStaticCAIsReserved(vmName1, serviceName, nonStaticIpAddress);

                //Try to deploy an IaaS VM with the same static CA (CreateDeployment)
                Console.WriteLine("Deploying an IaaS VM with the same static CA {0} (CreateDeployment)", nonStaticIpAddress);
                vm = CreatIaasVMObject(vmName2, nonStaticIpAddress, StaticCASubnet0);
                Utilities.VerifyFailure(() => vmPowershellCmdlets.NewAzureVM(serviceName3, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                        serviceName, "service for AddVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup), IPUnavaialbleExceptionMessage);
                Console.WriteLine("Deployment with Static CA {0} failed as expectd", nonStaticIpAddress);

                //Add an IaaS VM with a static CA
                Console.WriteLine("Deploying an IaaS VM with the same static CA {0} (AddRole)", nonStaticIpAddress);
                vm = CreatIaasVMObject(vmName3, nonStaticIpAddress, StaticCASubnet0);
                Utilities.VerifyFailure(() => vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }),IPUnavaialbleExceptionMessage);
                Console.WriteLine("Deployment with Static CA {0} failed as expectd", nonStaticIpAddress);
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                CleanupService(serviceName);
                CleanupService(serviceName2);
                CleanupService(serviceName3);
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void StopStayProvisionedVMWithStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Test a static CA
                //Test-AzureStaticVNetIP-VNetName $vnet -IPAddress “10.0.0.5”
                const string ipaddress = "10.0.0.10";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM with a static CA.
                PersistentVM vm = CreatIaasVMObject(vmName, ipaddress, StaticCASubnet0);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup, null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);

                //Verfications
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);

                //StopStayProvisioned the VM (Stop-AzureVM –StayProvisioned)
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                vmPowershellCmdlets.StopAzureVM(vmRoleContext.VM, serviceName, true, false);

                CheckAvailabilityOfIpAddressAndAssertFalse(vnet1, ipaddress);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void StopDeallocateVMWithStaticCATest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Test a static CA
                //Test-AzureStaticVNetIP-VNetName $vnet -IPAddress “10.0.0.5”
                const string ipaddress = "10.0.0.5";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM with a static CA.
                PersistentVM vm = CreatIaasVMObject(vmName, ipaddress, StaticCASubnet0);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup, null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);

                //Verfications
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);

                //StopDeallocate the VM
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                vmPowershellCmdlets.StopAzureVM(vmRoleContext.VM, serviceName, false, true);

                CheckAvailabilityOfIpAddressAndAssertFalse(vnet1, ipaddress);
                pass = true;
            }
            catch (Exception)
            {
                pass = false;
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void UpdateVMWithStaticCA()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                //Test a static CA
                //Test-AzureStaticVNetIP-VNetName $vnet -IPAddress “10.0.0.5”
                string ipaddress = "10.0.0.10";
                CheckAvailabilityofIpAddress(vnet1, ipaddress);

                //Create an IaaS VM with a static CA.
                var vm = CreatIaasVMObject(vmName, ipaddress, StaticCASubnet0);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup, null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);

                //Verfications
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);

                //Update the instance size of the VM (Get-AzureVM | Set-AzureVMSize | Update-AzureVM
                vmPowershellCmdlets.SetVMSize(vmName, serviceName,
                    new SetAzureVMSizeConfig(InstanceSize.Medium.ToString()));

                //Verify that the DIP of the VM is still reserved.
                VerifyVmWithStaticCAIsReserved(vmName, serviceName, ipaddress);
                pass = true;
            }
            catch (Exception)
            {
                pass = false;
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Network), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove,Test)-AzureStaticVnetIP)")]
        public void StaticCAExhautionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string vnet1 = VirtualNets[0];
            string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
            try
            {
                //Test a static CA
                //Test-AzureStaticVNetIP-VNetName $vnet -IPAddress “10.0.0.5”
                const string ipaddress = "10.64.0.5";
                var availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(vnet1, ipaddress);
                //Assert that it is available.
                Assert.IsTrue(availibiltyContext.IsAvailable);

                var vm = CreatIaasVMObject(vmName1, ipaddress, StaticCASubnet1);

                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet1, new DnsServer[1] { DnsServers[0] },
                    serviceName, "service for DeployVMWithStaticCATest", string.Empty, string.Empty, null, AffinityGroup);
                Console.WriteLine("New Azure service with name:{0} created successfully.", serviceName);


                availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(vnet1, ipaddress);
                int availableVIPsCount = availibiltyContext.AvailableAddresses.Count();
                Console.WriteLine(string.Format("AvailableAddresses:{0}{1}", Environment.NewLine, availibiltyContext.AvailableAddresses.Aggregate((current, next) => current + Environment.NewLine + next)));
                Console.WriteLine("VIPs avilable now:{0}", availableVIPsCount);
                int i = 0;
                foreach (string ip in availibiltyContext.AvailableAddresses)
                {
                    Console.WriteLine("Creating VM-{0} with IP: {1}", ++i,ip);
                    vm = CreatIaasVMObject(Utilities.GetUniqueShortName(vmNamePrefix), ip, StaticCASubnet1);
                    vmPowershellCmdlets.NewAzureVM(serviceName,new[] {vm},null);
                    Console.WriteLine("Created VM-{0} with IP: {1}", i,ip);
                }

                //try to create an vm and verify that it fails
                Console.WriteLine("Creating VM-{0}", ++i);
                vm = vmPowershellCmdlets.NewAzureVMConfig(new AzureVMConfigInfo(Utilities.GetUniqueShortName(vmNamePrefix), InstanceSize.Small.ToString(), imageName));
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                azureProvisioningConfig.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureProvisioningConfig(azureProvisioningConfig);
                vm = vmPowershellCmdlets.SetAzureSubnet(vm, new [] { StaticCASubnet1 });
                Utilities.VerifyFailure(() => vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }),BadRequestException);
                Console.WriteLine("Creating VM-{0} failed as expected.",i);
                pass = true;
            }
            catch (Exception)
            {
                pass = false;
                throw;
            }
        }
        #endregion Test cases

        #region Verifications Methods
        static private void VerifyVmWithStaticCAIsReserved(string vmName,string svcName,string inputDip)
        {
            //Get the DIP of the VM (Get-AzureVM) VirtualNetworkStaticIPContext ipContext
            PersistentVMRoleContext vm = vmPowershellCmdlets.GetAzureVM(vmName, svcName);
            string confirguredVip = vm.IpAddress;

            if (!string.IsNullOrEmpty(confirguredVip))
            {
                //Verify that the DIP of the VM is matched with an input DIP.
                Console.WriteLine("Verifying that the DIP of the VM {0} is matched with input DIP {1}.", inputDip, confirguredVip);
                Assert.AreEqual(inputDip,confirguredVip, string.Format("Static CA IpAddress {0} is not the same as the Input DIP {1}", confirguredVip, inputDip));
                Console.WriteLine("Verifyied that the DIP of the VM {0} is matched with input DIP {1}.", inputDip, confirguredVip);

                //Verify that the DIP is actually reserved.
                Console.WriteLine("Verifying that the DIP of the VM is actually reserved");
                var ipContext = vmPowershellCmdlets.GetAzureStaticVNetIP(vm.VM);
                Utilities.PrintContext(ipContext);
                Assert.AreEqual(inputDip,ipContext.IPAddress, string.Format("Reserved IPAddress {0}  is not equal to the input DIP {1}", ipContext.IPAddress, inputDip));
                Console.WriteLine("Verifyied that the DIP of the VM is actually reserved");

                //Verify that the IP is not available (Test-AzureStaticVNetIP –VnetName $vnet –IPAddress “10.0.0.5”)
                Console.WriteLine("Verifing that the IP {0} is not available", inputDip);
                VirtualNetworkStaticIPAvailabilityContext availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(VNetName, inputDip);
                Console.WriteLine("IsAvailable:{0}", availibiltyContext.IsAvailable);
                Console.WriteLine("AvailableAddresses:{0}{1}", Environment.NewLine, availibiltyContext.AvailableAddresses.Aggregate((current, next) => current + Environment.NewLine + next));
                Assert.IsFalse(availibiltyContext.IsAvailable, string.Format("Test-AzureStaticVNetIP should return true as {0} is reserved", inputDip,vm.Name));
                Assert.IsFalse(availibiltyContext.AvailableAddresses.Contains(inputDip),string.Format("{0} is reserved for vm {1} and should not be in available addresses.",inputDip,vmName));
                Console.WriteLine("Verified that the IP {0} is not available", inputDip);
            }
            else
            {
                throw new Exception("Configured IPAddres value is null or empty");
            }
        }

        static private void VerfiyVmWithoutStaticCAIsNotReserved(string vmName, string serviceName)
        {

            //Get the DIP of the VM (Get-AzureVM)
            Console.WriteLine("Getting the DIP of the VM");
            var vm = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
            Console.WriteLine("IpAddress of the VM : {0}", vm.IpAddress);

            //Verify that the DIP is NOT reserved
            Console.WriteLine("Verifying that the DIP is NOT reserved");
            Assert.IsNull(vmPowershellCmdlets.GetAzureStaticVNetIP(vm.VM),"Reserved IPAddress should be null or empty for a VM without static CA");
            Console.WriteLine("Verified that the DIP {0} is NOT reserved", vm.IpAddress);

            //Verify that the IP is not available (Test-AzureStaticVNetIP –VnetName $vnet –IPAddress “10.0.0.6”)
            Console.WriteLine("Verifying that the IP is not available");
            var availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(VNetName, vm.IpAddress);
            Console.WriteLine("IsAvailable:{0}", availibiltyContext.IsAvailable);
            Console.WriteLine("AvailableAddresses:{0}{1}", Environment.NewLine, availibiltyContext.AvailableAddresses.Aggregate((current, next) => current + Environment.NewLine + next));
            Assert.IsFalse(availibiltyContext.IsAvailable, string.Format("Test-AzureStaticVNetIP should return true as {0} is reserved", vm.IpAddress, vm.Name));
            Assert.IsFalse(availibiltyContext.AvailableAddresses.Contains(vm.IpAddress), string.Format("{0} is reserved for vm {1} and should not be in available addresses.", vm.IpAddress, vmName));
            Console.WriteLine("Verified that IP {0} is not available", vm.IpAddress);
        }

        #endregion Verifications Methods

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanupService(serviceName);
        }


        [ClassCleanup]
        public static void ClassCleanUp()
        {
            CleanUpVnetConfigForStaticCA();
        }

        private static void ReadVnetConfig()
        {
            // Read the vnetconfig file and get the names of local networks, virtual networks and affinity groups.
            XDocument vnetconfigxml = XDocument.Load(vnetConfigFilePath);

            foreach (XElement el in vnetconfigxml.Descendants())
            {
                switch (el.Name.LocalName)
                {
                    case "LocalNetworkSite":
                        LocalNets.Add(el.FirstAttribute.Value);
                        List<XElement> elements = el.Elements().ToList();
                        var prefixlist = new AddressPrefixList();
                        prefixlist.Add(elements[0].Elements().First().Value);
                        LocalNetworkSites.Add(new LocalNetworkSite()
                        {
                            Name = el.FirstAttribute.Value,
                            VpnGatewayAddress = elements[1].Value,
                            AddressSpace = new AddressSpace() {AddressPrefixes = prefixlist}
                        });
                        break;
                    case "VirtualNetworkSite":
                        VirtualNets.Add(el.Attribute("name").Value);
                        AffinityGroups.Add(el.Attribute("AffinityGroup").Value);
                        break;
                    case "DnsServer":
                        DnsServers.Add(new DnsServer() { Name = el.Attribute("name").Value, Address = el.Attribute("IPAddress").Value });
                        break;
                }
            }

            foreach (string aff in AffinityGroups)
            {
                if (Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, aff))
                {
                    vmPowershellCmdlets.NewAzureAffinityGroup(aff, locationName, null, null);
                }
            }
        }

        private static void SetVNetForStaticCAtest()
        {
            Utilities.RetryActionUntilSuccess(
                () => vmPowershellCmdlets.SetAzureVNetConfig(Directory.GetCurrentDirectory() + "\\StaticCAvnetconfig.netcfg"),
                "in use", 10, 30);
        }

        private static void CleanUpVnetConfigForStaticCA()
        {
            Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "in use", 10, 30);
        }


        private void CheckAvailabilityofIpAddress(string vnetName, string ipaddress)
        {
            Console.WriteLine("Checking if VIP {0} is available and unreserved", ipaddress);
            VirtualNetworkStaticIPAvailabilityContext availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(vnetName, ipaddress);
            Utilities.PrintContext(availibiltyContext);

            //Assert that it is available.
            Assert.IsTrue(availibiltyContext.IsAvailable,"ipaddress {0} is expected to be available",ipaddress);
            Console.WriteLine("Ip address {0} is available", ipaddress);
        }

        private void CheckAvailabilityOfIpAddressAndAssertFalse(string vnetName, string ipaddress)
        {
            var availibiltyContext = vmPowershellCmdlets.TestAzureStaticVNetIP(vnetName, ipaddress);
            Utilities.PrintContext(availibiltyContext);
            Console.WriteLine("AvailableAddresses:{0}{1}", Environment.NewLine,
                availibiltyContext.AvailableAddresses.Aggregate((current, next) => current + Environment.NewLine + next));
            Assert.IsFalse(availibiltyContext.IsAvailable, "Ipaddress {0} is avialable.", ipaddress);
        }
        private PersistentVM CreatIaasVMObject(string vmName, string ipaddress, string subnet)
        {
            //Create an IaaS VM with a static CA.
            var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

            //Set-AzureSubnet
            vm = vmPowershellCmdlets.SetAzureSubnet(vm, new [] { subnet });

            //Set-AzureStaticVNetIP
            vm = vmPowershellCmdlets.SetAzureStaticVNetIP(ipaddress, vm);
            return vm;
        }

    }
}
