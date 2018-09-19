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

using System.Threading;

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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageReservedIP.csv", "packageReservedIP#csv", DataAccessMethod.Sequential)]
        public void CreateReservedIPThenPaaSVM()
        {
            try
            {
                string reservedIpName1 = Utilities.GetUniqueShortName("ResrvdIP1"); ;
                string reservedIpName2 = Utilities.GetUniqueShortName("ResrvdIP2"); ;
                string reservedIpLabel1 = Utilities.GetUniqueShortName("ResrvdIPLbl", 5);
                string reservedIpLabel2 = Utilities.GetUniqueShortName("ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string deploymentName1 = Utilities.GetUniqueShortName("Depl");
                string deploymentName2 = Utilities.GetUniqueShortName("Depl");

                var input1 = new ReservedIPContext()
                {
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel1,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName1,
                    State = "Created"
                };

                var input2 = new ReservedIPContext()
                {
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel2,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName2,
                    State = "Created"
                };

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName1, locationName, reservedIpLabel1), "Reserve a new IP");

                //Get the reserved ip and verify the reserved Ip properties.
                VerifyReservedIpNotInUse(input1);

                // Reserve a new IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName2, locationName, reservedIpLabel2), "Reserve a new IP");

                //Get the reserved ip and verify the reserved Ip properties.
                VerifyReservedIpNotInUse(input2);

                vmPowershellCmdlets.NewAzureService(serviceName, locationName);

                var _packageName = Convert.ToString(TestContext.DataRow["packageName"]);
                var _configName = Convert.ToString(TestContext.DataRow["configName"]);
                var _configNameupdate = Convert.ToString(TestContext.DataRow["updateConfig"]);

                string _packagePath = (new FileInfo(Directory.GetCurrentDirectory() + "\\" + _packageName)).FullName;
                string _configPath1 = StoreConfigFileWithReservedIp(_configName, reservedIpName1);
                string _configPath2 = StoreConfigFileWithReservedIp(_configName, reservedIpName2);
                string _configPath1update = StoreConfigFileWithReservedIp(_configNameupdate, reservedIpName1);
                string _configPath2update = StoreConfigFileWithReservedIp(_configNameupdate, reservedIpName2);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, _packagePath, _configPath1,
                    DeploymentSlotType.Production, "label", deploymentName1, false, false);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, _packagePath, _configPath2,
                    DeploymentSlotType.Staging, "label", deploymentName2, false, false);

                vmPowershellCmdlets.MoveAzureDeployment(serviceName);

                vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);

                vmPowershellCmdlets.SetAzureDeploymentConfig(serviceName, DeploymentSlotType.Production, _configPath1update);
                vmPowershellCmdlets.SetAzureDeploymentConfig(serviceName, DeploymentSlotType.Staging, _configPath2update);

                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private string StoreConfigFileWithReservedIp(string configFileName, string reservedIpName)
        {
            var originalConfigPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configFileName);
            var tempConfigPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + Utilities.GetUniqueShortName(configFileName));

            string _config1_format = File.ReadAllText(originalConfigPath.FullName);

            File.WriteAllText(tempConfigPath.FullName, string.Format(_config1_format, reservedIpName));
            return tempConfigPath.FullName;
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
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
                         PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows, username, password, subnet);
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Preview), Owner("avgupt"), Description("Test the cmdlets (Remove-AzureReservedIPAssociation, New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreatePaaSDeploymentAssociateAndDisassociateReservedIp()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName("ResrvdIPLbl", 5);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                string deploymentLabel = Utilities.GetUniqueShortName("DepLbl", 5);

                var input = new ReservedIPContext()
                {
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

                Utilities.ExecuteAndLog(() => 
                vmPowershellCmdlets.NewAzureService(serviceName, locationName),
                "Create a Hosted Service");

                Utilities.ExecuteAndLog(() => 
                    vmPowershellCmdlets.NewAzureDeployment(serviceName,
                    "HelloWorld_SDK20.cspkg", "ServiceConfiguration.cscfg", "Staging",
                    deploymentLabel, deploymentName, doNotStart: false, warning: false), 
                    "Create a PaaS deployment");


                Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.SetAzureReservedIPAssociation(reservedIpName,
                        serviceName, DeploymentSlotType.Staging);
                }, "Create a new Azure Reserved IP Association");
               

                VerifyReservedIpInUse(serviceName, input, deploymentName);

                Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.RemoveAzureReservedIPAssociation(reservedIpName,
                        serviceName, true, DeploymentSlotType.Staging);
                }, "Remove a new Azure Reserved IP Association");

                VerifyReservedIpNotInUse(input);

                Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.RemoveAzureDeployment(serviceName, "Staging", true);
                }, "Remove a new Azure Reserved IP Association");
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Preview), Owner("avgupt"), Description("Test the cmdlets (Set-AzureReservedIPAssociation, New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateWindowsVMThenAssociateReservedIP()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var input = new ReservedIPContext()
                {
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
                    PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows, username, password, subnet);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, location: locationName);
                }, "Create a new windows azure vm without reserved ip.");

                Utilities.ExecuteAndLog(() => { vmPowershellCmdlets.SetAzureReservedIPAssociation(reservedIpName, serviceName); }, "Create a new Azure Reserved IP Association");


                VerifyReservedIpInUse(serviceName, input);
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("avgupt"), Description("Expected failure when trying to associate to staging slot in IaaS (Set-AzureReservedIPAssociation, New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void TestAssociateReservedIPToStageSlotIaaSFails()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var input = new ReservedIPContext()
                {
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
                    PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows, username, password, subnet);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, location: locationName);
                }, "Create a new windows azure vm without reserved ip.");

                Utilities.ExecuteAndLog(() => { vmPowershellCmdlets.SetAzureReservedIPAssociation(reservedIpName, 
                    serviceName, DeploymentSlotType.Staging); }, "Create a new Azure Reserved IP Association");
            }
            catch (Exception ex)
            {
                pass = true;
                Console.WriteLine(ex.ToString());
                return;
            }
            throw new Exception("Test Did not fail as expected when association was tried on stage slot in IaaS");
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Preview), Owner("avgupt"), Description("Test the cmdlets (Remove-AzureReservedIPAssociation, New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateWindowsVMWithReservedIPThenDisassociateReservedIP()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var input = new ReservedIPContext()
                {
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
                    PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows, username, password, subnet);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, location: locationName, reservedIPName: reservedIpName);
                }, "Create a new windows azure vm with reserved ip.");

                VerifyReservedIpInUse(serviceName, input);

                Utilities.ExecuteAndLog(() => { vmPowershellCmdlets.RemoveAzureReservedIPAssociation(reservedIpName, serviceName, true); }, "Remove an Azure Reserved IP Association");

                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVM(vmName, serviceName, true), "Remove Azure VM and verify that a warning is given.");
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Preview), Owner("avgupt"), Description("Test the cmdlets (New-AzureReservedIP, Remove-AzureReservedIPAssociation, Get-AzureReservedIP,Remove-AzureReservedIP)")]
        public void CreateWindowsVMThenReservedExistingIP()
        {
            try
            {
                string reservedIpName = Utilities.GetUniqueShortName("ResrvdIP");
                string reservedIpLabel = Utilities.GetUniqueShortName(" ResrvdIPLbl", 5);
                string dnsName = Utilities.GetUniqueShortName("Dns");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string deploymentName = Utilities.GetUniqueShortName("Depl");
                var input = new ReservedIPContext()
                {
                    DeploymentName = string.Empty,
                    Label = reservedIpLabel,
                    InUse = false,
                    Location = locationName,
                    ReservedIPName = reservedIpName,
                    State = "Created"
                };

                // Create a new VM with the reserved ip.
                DnsServer dns = null;
                Utilities.ExecuteAndLog(() => { dns = vmPowershellCmdlets.NewAzureDns(dnsName, DNS_IP); }, "Create a new Azure DNS");
                Utilities.ExecuteAndLog(() =>
                {
                    PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Windows, username, password, subnet);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnet, new[] { dns }, location: locationName);
                }, "Create a new windows azure vm without reserved ip.");

                // Reserve an existing IP
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureReservedIP(reservedIpName, locationName, serviceName, reservedIpLabel), "Reserve existing deployment IP");

                VerifyReservedIpInUse(serviceName, input);

                Utilities.ExecuteAndLog(() => { vmPowershellCmdlets.RemoveAzureReservedIPAssociation(reservedIpName, serviceName, true); }, "Remove an Azure Reserved IP Association");

                VerifyReservedIpNotInUse(input);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVM(vmName, serviceName, true), "Remove Azure VM and verify that a warning is given.");
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

         [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
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
                        PersistentVM vm = Utilities.CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(vmName, OS.Linux, username, password, subnet);
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
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

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the cmdlets (New-AzureReservedIP,Get-AzureReservedIP,Remove-AzureReservedIP)")]
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
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.NewAzureQuickVM(OS.Linux,
                    vmName, serviceName, imageName, username, password, locationName,
                    InstanceSize.Small.ToString(), false,  reservedIpName),
                    "Create a new Azure windows Quick VM with reserved ip.");
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

        private void VerifyReservedIpInUse(string serviceName,ReservedIPContext input, string deploymentName = null)
        {
            input.ServiceName = serviceName;
            input.InUse = true;
            input.DeploymentName = deploymentName ?? serviceName;
            Utilities.ExecuteAndLog(() => VerifyReservedIp(input), string.Format("Verify that the reserved ip {0} is in use", input.ReservedIPName));
        }

        private void VerifyReservedIpRemoved(string reservedIpName)
        {
            Utilities.VerifyFailure(() => vmPowershellCmdlets.GetAzureReservedIP(reservedIpName), ResourceNotFoundException);
        }

        #endregion Helper Methods
    }
}
