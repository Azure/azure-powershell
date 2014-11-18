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
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class ReservedIPTest : ServiceManagementTest
    {          
        private string rsvIpName1;
        private string rsvIpName2;
        private string affName1;
        private string affName2;
        private string rsvIPLabel;
        private string svcNameLoc; // a service using location
        private string svcNameAG; // a service using AG
        private string vmName;

        private const string rsvIpNamePrefix = "PSReservedIP";
        private const string affNamePrefix = "PSAffinity";
        private const string rsvIPLabelPrefix = "PSReservedIPLabel";
        
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }
            RemoveAllReservedIP();
        }

        [TestInitialize]
        public void Initialize()
        {
            rsvIpName1 = Utilities.GetUniqueShortName(rsvIpNamePrefix);
            rsvIpName2 = Utilities.GetUniqueShortName(rsvIpNamePrefix);
            affName1 = Utilities.GetUniqueShortName(affNamePrefix);
            affName2 = Utilities.GetUniqueShortName(affNamePrefix);
            rsvIPLabel = Utilities.GetUniqueShortName(rsvIPLabelPrefix);
            svcNameLoc = Utilities.GetUniqueShortName(serviceNamePrefix);
            svcNameAG = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            testStartTime = DateTime.Now;
        }

        /// <summary>
        /// This tests New-AzureReservedIP, Get-AzureReservedIP and Remove-AzureReservedIP
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New,Get,Remove)-AzureReservedIP)")]
        public void AzureReservedIPTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            
            try
            {
                // IP1 and IP2 on AG1                  
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, rsvIPLabel);                
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName2, affName1, rsvIPLabel);
                
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Create an affinity group in another location
                var anotherLocation = GetLocation("PersistentVMRole", locationName);
                vmPowershellCmdlets.NewAzureAffinityGroup(affName2, anotherLocation.Name, null, null);

                string rsvIpName3 = rsvIpNamePrefix + Utilities.GetUniqueShortName();
                string rsvIpName4 = rsvIpNamePrefix + Utilities.GetUniqueShortName();
                var rsvIPNames = new[] {rsvIpName1, rsvIpName2, rsvIpName3, rsvIpName4};
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName3, affName2, rsvIPLabel); // IP3 on AG2
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName4, affName2, rsvIPLabel); // IP4 on AG2

                var rsvIPs = vmPowershellCmdlets.GetAzureReservedIP();
                foreach (var ip in rsvIPs)
                {
                    if (rsvIPNames.Contains(ip.ReservedIPName))
                    {
                        reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(ip.ReservedIPName)[0];
                        Verify.AzureReservedIPNotInUse(reservedIPReturned, ip.ReservedIPName, ip.Label, ip.Location,
                            ip.Id);
                    }
                }
                
                // Remove IP1
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.CheckRemove(vmPowershellCmdlets.GetAzureReservedIP, rsvIpName1);

                rsvIPs = vmPowershellCmdlets.GetAzureReservedIP();
                foreach (var ip in rsvIPs)
                {
                    if (rsvIPNames.Contains(ip.ReservedIPName))
                    {
                        reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(ip.ReservedIPName)[0];
                        Verify.AzureReservedIPNotInUse(reservedIPReturned, ip.ReservedIPName, ip.Label, ip.Location,
                            ip.Id);
                    }
                }
                
                // Remove IP3
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName3);
                Utilities.CheckRemove(vmPowershellCmdlets.GetAzureReservedIP, rsvIpName3);

                rsvIPs = vmPowershellCmdlets.GetAzureReservedIP();
                foreach (var ip in rsvIPs)
                {
                    if (rsvIPNames.Contains(ip.ReservedIPName))
                    {
                        reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(ip.ReservedIPName)[0];
                        Verify.AzureReservedIPNotInUse(reservedIPReturned, ip.ReservedIPName, ip.Label, ip.Location,
                            ip.Id);
                    }
                }

                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName4);
                Utilities.CheckRemove(vmPowershellCmdlets.GetAzureReservedIP, rsvIpName4);
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName2);
                Utilities.CheckRemove(vmPowershellCmdlets.GetAzureReservedIP, rsvIpName2);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// This is negative tests for ReservedIP
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New,Get,Remove)-AzureReservedIP)")]
        public void AzureReservedIPNegativeTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                string wrongAffName = "AffinityNotExist";
                string wrongDeploymentName = "DeploymentNotExist";
                string wrongServiceName = "ServiceNotExist";
                string wrongReservedIPName = "ReservedIPNotExist";

                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);

                // Try to create a reserved IP with a wrong affinity group name
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, wrongAffName, rsvIPLabel),
                    BadRequestException);
                
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, rsvIPLabel);
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Try to remove an affinity group that holds a reserved IP.
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.RemoveAzureAffinityGroup(affName1),
                    BadRequestException);
                
                // Try to create a reserved IP with an existing reserved ip name
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, rsvIPLabel),
                    ConflictErrorException);

                // Try to create a reserved IP with a deployment name that does not exist
                Utilities.VerifyFailure(
                    () =>
                        vmPowershellCmdlets.NewAzureReservedIP(rsvIpName2, affName1, wrongServiceName,
                            wrongDeploymentName,
                            rsvIPLabel),
                    BadRequestException);
            
                // Try to get a reserved IP that does not exist
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.GetAzureReservedIP(wrongReservedIPName), ResourceNotFoundException);                

                // Try to remove a reserved IP that does not exist
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.RemoveAzureReservedIP(wrongReservedIPName), ResourceNotFoundException);                

                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                vmPowershellCmdlets.RemoveAzureAffinityGroup(affName1);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }            
        }

        /// <summary>
        /// First reserve an IP and then create a deployment with the reserved ip.
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("First reserve an IP and then create a deployment with the reserved ip.")]
        public void CreateDeploymentWithReservedIPTest()
        {
            try
            {
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, rsvIPLabel);

                // Verify the reserved ip
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);


                // Create a new deployment with the reserved ip
                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
                string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }                

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);
                var azureEndPointConfigInfo2 = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 81, "web2", "lbweb2", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo2);

                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };                
                vmPowershellCmdlets.NewAzureVMWithReservedIP(svcNameAG, VMs, rsvIpName1, affName1);

                // Get the deployment and verify
                var deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameAG);
                Utilities.PrintContext(deploymentReturned);


                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);
                
                // Remove the VM1 and verify

                Console.WriteLine("Removing the first VM...\n");
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, svcNameAG);
                
                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Remove the VM2 and verify
                Console.WriteLine("Removing the second VM...\n");
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM2Name, svcNameAG);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);


                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);                
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// First create a deployment and then reserve the ip of the deployment.
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("First create a deployment and then reserve the ip of the deployment")]
        public void CreateDeploymentAndReserveIPTest()
        {
            try
            {

                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
                string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }                

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);

                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                
                // Create a new deployment
                vmPowershellCmdlets.NewAzureVM(svcNameLoc, VMs, locationName);

                // Get the deployment and verify
                var deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);

                // Reserve the ip of the deployment
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, svcNameLoc, deploymentReturned.DeploymentName, rsvIPLabel);

                // Get the deployment and verify
                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);
                Assert.AreEqual(rsvIpName1, deploymentReturned.ReservedIPName, "Reserved IP names are different!");

                // Verify the reserved ip
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);
                
                // Remove the first VM and verify the reserved ip
                Console.WriteLine("Removing the first VM...");
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, svcNameLoc);

                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);
                Assert.AreEqual(rsvIpName1, deploymentReturned.ReservedIPName, "Reserved IP names are different!");

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);
                
                // Remove the second VM and verify the reserved ip
                Console.WriteLine("Removing the second VM...");
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM2Name, svcNameLoc);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                        () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);

                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }

        /// <summary>
        /// Try to reserve an ip of a deployment when the reserved ip and deployment are in different AG/location
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("Try to reserve an ip of a deployment when the reserved ip and deployment are in different AG/location")]
        public void CreateDeploymentWithReservedIPNegativeTest()
        {
            try
            {

                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
                string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, null);

                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };


                // AG1 on location 1
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);

                // AG2 on location 2
                var anotherLocation = GetLocation("PersistentVMRole", locationName);
                vmPowershellCmdlets.NewAzureAffinityGroup(affName2, anotherLocation.Name, null, null);

                // Reserve an ip on AG1
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName2);
                var rsvIPreturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(rsvIPreturned, rsvIpName1, null, affName2);
                
                // Try to create a new deployment with AG2 and the reserved IP 
                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureVMWithReservedIP(svcNameAG, VMs, rsvIpName1, affName1),
                    BadRequestException);

                // Create a new deployment with location 2, and then reserved the IP of it
                vmPowershellCmdlets.NewAzureVM(svcNameLoc, VMs, locationName);

                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureReservedIP(rsvIpName2, affName2, svcNameLoc, svcNameLoc),
                    BadRequestException);

                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                        () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);

                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Reserve an IP of a deployment and stop-deallocate the VMs of the deployment
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("Reserve an IP of a deployment and stop-deallocate the VMs of the deployment")]
        public void StopDeallocationReservedIPTest()
        {
            try
            {
                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
                string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, null);

                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };

                // Create a new deployment
                vmPowershellCmdlets.NewAzureVM(svcNameLoc, VMs, locationName);

                // Reserve the ip of the deployment
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, svcNameLoc, svcNameLoc, rsvIPLabel);

                // Get the deployment and verify
                var deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);

                // Verify the reserved ip
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Stop the first VM and verify the reserved ip
                Console.WriteLine("Stopping the first VM...");
                vmPowershellCmdlets.StopAzureVM(newAzureVM1Name, svcNameLoc);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                     deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                     deploymentReturned.ServiceName);

                // Stop the second VM and verify the reserved ip
                Console.WriteLine("Stopping the second VM...");
                vmPowershellCmdlets.StopAzureVM(newAzureVM2Name, svcNameLoc, false, true);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);
                Assert.AreEqual(0, deploymentReturned.VirtualIPs.Count, "The deployment still holds a VIP!");

                // Restart the VM and verify
                vmPowershellCmdlets.StartAzureVM(newAzureVM1Name, svcNameLoc);

                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);

                // Remove all VMs and service
                vmPowershellCmdlets.RemoveAzureService(svcNameLoc);
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                        () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Remove a deployment that has a reserve ip, and then create another deployment using the reserved ip
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("Remove a deployment that has a reserve ip, and then create another deployment using the reserved ip")]
        public void RemoveAndCreateDeploymentWithReservedIP()
        {
            try
            {

                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);

                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);                
                string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo =
                    new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80,
                        80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                

                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);                
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                // Create a new deployment
                vmPowershellCmdlets.NewAzureVM(svcNameLoc, new [] {persistentVM1}, locationName);                

                // Reserve the ip of the deployment                
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, svcNameLoc, svcNameLoc, rsvIPLabel);

                // Get the deployment and verify
                var deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameLoc);
                Utilities.PrintContext(deploymentReturned);

                // Verify the reserved ip
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Remove the VMs and verify
                Console.WriteLine("\nRemoving VMs...\n");
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, svcNameLoc);                

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);
                
                // Remove the service
                Console.WriteLine("\nRemoving the service...\n");
                vmPowershellCmdlets.RemoveAzureService(svcNameLoc);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Re-deploy the VM and verify
                vmPowershellCmdlets.NewAzureVMWithReservedIP(svcNameAG, new[] { persistentVM2 },rsvIpName1, affName1);

                // Get the deployment and verify
                deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameAG);
                Utilities.PrintContext(deploymentReturned);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Remove the VM
                vmPowershellCmdlets.RemoveAzureService(svcNameAG);

                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                        () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// /// Try to delete reserved ip while the ip is used by a deployment 
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
         Description("Try to delete reserved ip while the ip is used by a deployment")]
        public void RemoveAzureReservedIPWithDeploymentTest()
        {
            try
            {
                vmPowershellCmdlets.NewAzureAffinityGroup(affName1, locationName, null, null);

                string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
                
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }

                var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
                var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
                
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
                

                //PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                PersistentVM[] VMs = { persistentVM1 };

                // Create a new deployment
                vmPowershellCmdlets.NewAzureVMWithAG(svcNameAG, VMs, affName1);

                // Reserve the ip of the deployment                
                vmPowershellCmdlets.NewAzureReservedIP(rsvIpName1, affName1, svcNameAG, svcNameAG, rsvIPLabel);

                // Get the deployment and verify
                var deploymentReturned = vmPowershellCmdlets.GetAzureDeployment(svcNameAG);

                // Verify the reserved ip
                var reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Stop-deallocate the first VM and verify reserved ip
                Utilities.VerifyFailure(() => vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1), BadRequestException);
                
                vmPowershellCmdlets.StopAzureVM(newAzureVM1Name, svcNameAG, false, true);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1,
                    deploymentReturned.VirtualIPs[0].Address, deploymentReturned.DeploymentName,
                    deploymentReturned.ServiceName);

                // Stop-deallocate the second VM and verify reserved ip
                Utilities.VerifyFailure(() => vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1), BadRequestException);
                
                // Remove all VMs and service and verify reserved ip
                vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, svcNameAG, true);

                // Verify the reserved ip
                reservedIPReturned = vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1)[0];
                Verify.AzureReservedIPNotInUse(reservedIPReturned, rsvIpName1, rsvIPLabel, affName1);

                // Remove the reserved IP and verify
                vmPowershellCmdlets.RemoveAzureReservedIP(rsvIpName1);
                Utilities.VerifyFailure(
                        () => vmPowershellCmdlets.GetAzureReservedIP(rsvIpName1), ResourceNotFoundException);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                Console.WriteLine("Starting to clean up created VM and service...");

                CleanupService(svcNameLoc);
                CleanupService(svcNameAG);
            }
        }
        
        [ClassCleanup]
        public static void ClassCleanup()
        {
            RemoveAllReservedIP();
        }

        /// <summary>
        /// Remove all reserved ips under this subscription
        /// </summary>
        private static void RemoveAllReservedIP()
        {           
            var reservedIPs = vmPowershellCmdlets.GetAzureReservedIP();
            
            if (reservedIPs.Count > 0)
            {
                foreach (var ip in reservedIPs)
                {
                    vmPowershellCmdlets.RemoveAzureReservedIP(ip.ReservedIPName);
                }
            }

            reservedIPs = vmPowershellCmdlets.GetAzureReservedIP();
            Assert.AreEqual(0, reservedIPs.Count, "There are still {0} reserved IPs.", reservedIPs.Count);
        }
        
        /// <summary>
        /// Returns a location with a given feature that is different with a given location.
        /// </summary>
        /// <param name="reqSvc">Required feature</param>
        /// <param name="excludeLoc">Excluding location</param>
        /// <returns></returns>
        private LocationsContext GetLocation(string reqSvc, string excludeLoc)
        {            
            var locations = vmPowershellCmdlets.GetAzureLocation();
            foreach (var loc in locations)
            {
                if (! loc.Name.ToLowerInvariant().Equals(excludeLoc.ToLowerInvariant()))
                {
                    if (loc.AvailableServices.Contains(reqSvc))
                    {
                        return loc;
                    }                    
                }                
            }
            return null;
        }     
    }
}
