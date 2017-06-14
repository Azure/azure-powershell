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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class ScenarioTest : ServiceManagementTest
    {
        private const string ReadyState = "ReadyRole";
        private string serviceName;

        //string perfFile;

        [TestInitialize]
        public void Initialize()
        {
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);

            pass = false;
            testStartTime = DateTime.Now;
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestCategory(Category.BVT), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,Get-AzureVM,Get-AzureLocation,Import-AzurePublishSettingsFile,Get-AzureSubscription,Set-AzureSubscription)")]
        public void NewWindowsAzureQuickVM()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string newAzureQuickVMName1 = Utilities.GetUniqueShortName(vmNamePrefix);
            string newAzureQuickVMName2 = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                if (string.IsNullOrEmpty(imageName))
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] {"Windows"}, false);

                var retriableErrorMessages = new string[]
                {
                    "The server encountered an internal error. Please retry the request.",
                    "Windows Azure is currently performing an operation on this hosted service that requires exclusive access."
                };

                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureQuickVM(
                        OS.Windows, newAzureQuickVMName1, serviceName, imageName, username, password),
                    ""
                    );

                Utilities.RetryActionUntilSuccess(() =>
                {
                    var svcExists = vmPowershellCmdlets.TestAzureServiceName(serviceName);
                    if (svcExists)
                    {
                        // Try to delete the hosted service artifact in this subscription
                        vmPowershellCmdlets.RemoveAzureService(serviceName, true);
                    }

                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName1, serviceName, imageName,
                        username, password, locationName);
                }, retriableErrorMessages, 10, 30);

                // Verify
                var vm = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName1, serviceName);
                Assert.AreEqual(newAzureQuickVMName1, vm.Name, true);
                Assert.IsTrue(vm.VM.DebugSettings.BootDiagnosticsEnabled);

                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName2, serviceName, imageName,
                        username, password, locationName);
                }, retriableErrorMessages, 10, 30);

                // Verify
                Assert.AreEqual(newAzureQuickVMName2,
                    vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName).Name, true);

                try
                {
                    vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName1 + "wrongVMName", serviceName);
                    Assert.Fail("Should Fail!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail as expected: {0}", e.ToString());
                }

                // Cleanup 
                vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName1, serviceName);
                Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName1, serviceName));

                Assert.AreEqual(newAzureQuickVMName2,
                    vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName).Name, true);
                vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName2, serviceName);
                Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName));

                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName2, serviceName, imageName,
                        username, password);
                }, retriableErrorMessages, 10, 30);
                Assert.AreEqual(newAzureQuickVMName2,
                    vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName).Name, true);

                //Remove the service after removing the VM above
                vmPowershellCmdlets.RemoveAzureService(serviceName);

                //DisableWinRMHttps Test Case
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                    newAzureQuickVMName2, serviceName, imageName, username, password,
                    locationName, null, true);
                pass = true;
            }
            finally
            {
                vmPowershellCmdlets.RemoveAzureService(serviceName);
            }
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestCategory(Category.BVT), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,Get-AzureVM,Get-AzureLocation,Import-AzurePublishSettingsFile,Get-AzureSubscription,Set-AzureSubscription)")]
        public void NewWindowsAzureQuickVMAG()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string newAzureQuickVMName1 = Utilities.GetUniqueShortName(vmNamePrefix);
            string newAzureQuickVMName2 = Utilities.GetUniqueShortName(vmNamePrefix);
            string affName = Utilities.GetUniqueShortName("aff");

            try
            {
                if (string.IsNullOrEmpty(imageName))
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

                var retriableErrorMessages = new string[]
                {
                    "The server encountered an internal error. Please retry the request.",
                    "Windows Azure is currently performing an operation on this hosted service that requires exclusive access."
                };

                vmPowershellCmdlets.NewAzureAffinityGroup(affName, locationName, "testaff", "testaff");

                Utilities.VerifyFailure(
                    () => vmPowershellCmdlets.NewAzureQuickVM(
                        OS.Windows, newAzureQuickVMName1, serviceName, imageName, username, password),
                    ""
                    );

                // Create VM1
                Utilities.RetryActionUntilSuccess(() =>
                {
                    var svcExists = vmPowershellCmdlets.TestAzureServiceName(serviceName);
                    if (svcExists)
                    {
                        // Try to delete the hosted service artifact in this subscription
                        vmPowershellCmdlets.RemoveAzureService(serviceName, true);
                    }

                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                        newAzureQuickVMName1, serviceName, imageName, null,
                        InstanceSize.Small, username, password, null, affName);
                }, retriableErrorMessages, 10, 30);

                // Verify
                Assert.AreEqual(newAzureQuickVMName1, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName1, serviceName).Name, true);

                // Create VM2 without affinity group name
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                        newAzureQuickVMName2, serviceName, imageName, null,
                        InstanceSize.Small, username, password, null, null);
                }, retriableErrorMessages, 10, 30);

                // Verify
                Assert.AreEqual(newAzureQuickVMName2, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName).Name, true);

                // Remove VM2
                vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName2, serviceName);
                Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName));

                // Create VM2 with affinity group name
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                        newAzureQuickVMName2, serviceName, imageName, null,
                        InstanceSize.Small, username, password, null, affName);
                }, retriableErrorMessages, 10, 30);

                // Verify
                Assert.AreEqual(newAzureQuickVMName2, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName2, serviceName).Name, true);
            }
            finally
            {
                vmPowershellCmdlets.RemoveAzureService(serviceName);
                vmPowershellCmdlets.RemoveAzureAffinityGroup(affName);
            }
        }

        /// <summary>
        /// Get-AzureWinRMUri
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestCategory(Category.BVT), TestProperty("Feature", "IaaS"), Priority(1), Owner("v-rakonj"), Description("Test the cmdlets (Get-AzureWinRMUri)")]
        public void GetAzureWinRMUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                string newAzureQuickVMName = Utilities.GetUniqueShortName(vmNamePrefix);
                if (string.IsNullOrEmpty(imageName))
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

                Utilities.RetryActionUntilSuccess(() =>
                {
                    if (vmPowershellCmdlets.TestAzureServiceName(serviceName))
                    {
                        var op = vmPowershellCmdlets.RemoveAzureService(serviceName);
                    }
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName);
                }, "Windows Azure is currently performing an operation on this hosted service that requires exclusive access.", 10, 30);

                // Verify the VM
                var vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName);
                Assert.AreEqual(newAzureQuickVMName, vmRoleCtxt.Name, true, "VM names are not matched!");

                // Get the WinRM Uri
                var resultUri = vmPowershellCmdlets.GetAzureWinRMUri(serviceName, vmRoleCtxt.Name);

                // starting the test.
                InputEndpointContext winRMEndpoint = null;

                foreach (InputEndpointContext inputEndpointCtxt in vmPowershellCmdlets.GetAzureEndPoint(vmRoleCtxt))
                {
                    if (inputEndpointCtxt.Name.Equals(WinRmEndpointName))
                    {
                        winRMEndpoint = inputEndpointCtxt;
                    }
                }

                Assert.IsNotNull(winRMEndpoint, "There is no WinRM endpoint!");
                Assert.IsNotNull(resultUri, "No WinRM Uri!");

                Console.WriteLine("InputEndpointContext Name: {0}", winRMEndpoint.Name);
                Console.WriteLine("InputEndpointContext port: {0}", winRMEndpoint.Port);
                Console.WriteLine("InputEndpointContext protocol: {0}", winRMEndpoint.Protocol);

                Console.WriteLine("WinRM Uri: {0}", resultUri.AbsoluteUri);
                Console.WriteLine("WinRM Port: {0}", resultUri.Port);
                Console.WriteLine("WinRM Scheme: {0}", resultUri.Scheme);

                Assert.AreEqual(winRMEndpoint.Port, resultUri.Port, "Port numbers are not matched!");

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Basic Provisioning a Virtual Machine
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestCategory(Category.BVT), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (Get-AzureLocation,Test-AzureName ,Get-AzureVMImage,New-AzureQuickVM,Get-AzureVM ,Restart-AzureVM,Stop-AzureVM , Start-AzureVM)")]
        public void ProvisionLinuxVM()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureLinuxVMName = Utilities.GetUniqueShortName("PSLinuxVM");
            string linuxImageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);

            try
            {
                vmPowershellCmdlets.NewAzureQuickVM(OS.Linux, newAzureLinuxVMName, serviceName, linuxImageName, "user", password, locationName);
                // Verify
                PersistentVMRoleContext vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(newAzureLinuxVMName, serviceName);
                Assert.AreEqual(newAzureLinuxVMName, vmRoleCtxt.Name, true);
                try
                {
                    vmPowershellCmdlets.RemoveAzureVM(newAzureLinuxVMName + "wrongVMName", serviceName);
                    Assert.Fail("Should Fail!!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    Console.WriteLine("Fail as expected: {0}", e);
                }

                // Cleanup
                vmPowershellCmdlets.RemoveAzureVM(newAzureLinuxVMName, serviceName);
                Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureLinuxVMName, serviceName));
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Verify Advanced Provisioning for the Dev/Test Scenario
        /// Make an Service
        /// Make a VM
        /// Add 4 additonal endpoints
        /// Makes a storage account
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("msampson"), Description("Test the cmdlets (Get-AzureDeployment, New-AzureVMConfig, Add-AzureProvisioningConfig, Add-AzureEndpoint, New-AzureVM, New-AzureStorageAccount)")]
        public void DevTestProvisioning()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
            //Find a Windows VM Image
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            //Specify a small Windows image, with username and pw
            AzureVMConfigInfo azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
            AzureProvisioningConfigInfo azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            AzureEndPointConfigInfo azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp, 80, 80, "Http");

            PersistentVMConfigInfo persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, null, azureEndPointConfigInfo);
            PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

            //Add all the endpoints that are added by the Dev Test feature in Azure Tools
            azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp, 443, 443, "Https");
            azureEndPointConfigInfo.Vm = persistentVM1;
            persistentVM1 = vmPowershellCmdlets.AddAzureEndPoint(azureEndPointConfigInfo);
            azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp, 1433, 1433, "MSSQL");
            azureEndPointConfigInfo.Vm = persistentVM1;
            persistentVM1 = vmPowershellCmdlets.AddAzureEndPoint(azureEndPointConfigInfo);
            azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp, 8172, 8172, "WebDeploy");
            azureEndPointConfigInfo.Vm = persistentVM1;
            persistentVM1 = vmPowershellCmdlets.AddAzureEndPoint(azureEndPointConfigInfo);

            // Make a storage account named "devtestNNNNN"
            string storageAcctName = "devtest" + new Random().Next(10000, 99999);
            vmPowershellCmdlets.NewAzureStorageAccount(storageAcctName, locationName);

            // When making a new azure VM, you can't specify a location if you want to use the existing service
            PersistentVM[] VMs = { persistentVM1 };
            vmPowershellCmdlets.NewAzureVM(serviceName, VMs, locationName);

            var svcDeployment = vmPowershellCmdlets.GetAzureDeployment(serviceName);
            Assert.AreEqual(svcDeployment.ServiceName, serviceName);
            var vmDeployment = vmPowershellCmdlets.GetAzureVM(newAzureVM1Name, serviceName);
            Assert.AreEqual(vmDeployment.InstanceName, newAzureVM1Name);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, serviceName);
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVM1Name, serviceName));
            Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.RemoveAzureStorageAccount(storageAcctName), "in use", 10, 30);
            pass = true;
        }

        /// <summary>
        /// Verify Advanced Provisioning
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (New-AzureService,New-AzureVMConfig,Add-AzureProvisioningConfig ,Add-AzureDataDisk ,Add-AzureEndpoint,New-AzureVM)")]
        public void AdvancedProvisioning()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
            string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
            if (string.IsNullOrEmpty(imageName))
            {
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            }

            vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);

            var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
            var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.ExtraSmall.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
            var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.CustomProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", 80, ProtocolInfo.http, @"/", null, null);

            var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
            var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);

            PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
            PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

            PersistentVM[] VMs = { persistentVM1, persistentVM2 };
            vmPowershellCmdlets.NewAzureVM(serviceName, VMs);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, serviceName);
            vmPowershellCmdlets.RemoveAzureVM(newAzureVM2Name, serviceName);

            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVM1Name, serviceName));
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVM2Name, serviceName));
            pass = true;
        }

        /// <summary>
        /// Modifying Existing Virtual Machines
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig ,Add-AzureDataDisk ,Add-AzureEndpoint,New-AzureVM)")]
        public void ModifyingVM()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureQuickVMName = Utilities.GetUniqueShortName(vmNamePrefix);
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName);

            AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
            AddAzureDataDiskConfig azureDataDiskConfigInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk2", 1);
            AzureEndPointConfigInfo azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp, 1433, 2000, "sql");
            AddAzureDataDiskConfig[] dataDiskConfig = { azureDataDiskConfigInfo1, azureDataDiskConfigInfo2 };
            vmPowershellCmdlets.AddVMDataDisksAndEndPoint(newAzureQuickVMName, serviceName, dataDiskConfig, azureEndPointConfigInfo);

            SetAzureDataDiskConfig setAzureDataDiskConfig1 = new SetAzureDataDiskConfig(HostCaching.ReadWrite, 0);
            SetAzureDataDiskConfig setAzureDataDiskConfig2 = new SetAzureDataDiskConfig(HostCaching.ReadWrite, 0);
            SetAzureDataDiskConfig[] diskConfig = { setAzureDataDiskConfig1, setAzureDataDiskConfig2 };
            vmPowershellCmdlets.SetVMDataDisks(newAzureQuickVMName, serviceName, diskConfig);

            vmPowershellCmdlets.GetAzureDataDisk(newAzureQuickVMName, serviceName);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName);

            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));
            pass = true;
        }

        /// <summary>
        /// Changes that Require a Reboot
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("priya"), Description("Test the cmdlets (Get-AzureVM,Set-AzureDataDisk ,Update-AzureVM,Set-AzureVMSize)")]
        public void UpdateAndReboot()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureQuickVMName = Utilities.GetUniqueShortName("PSTestVM");
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName);

            var azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
            var azureDataDiskConfigInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk2", 1);
            AddAzureDataDiskConfig[] dataDiskConfig = { azureDataDiskConfigInfo1, azureDataDiskConfigInfo2 };
            vmPowershellCmdlets.AddVMDataDisks(newAzureQuickVMName, serviceName, dataDiskConfig);

            var setAzureDataDiskConfig1 = new SetAzureDataDiskConfig(HostCaching.ReadOnly, 0);
            var setAzureDataDiskConfig2 = new SetAzureDataDiskConfig(HostCaching.ReadOnly, 0);
            SetAzureDataDiskConfig[] diskConfig = { setAzureDataDiskConfig1, setAzureDataDiskConfig2 };
            vmPowershellCmdlets.SetVMDataDisks(newAzureQuickVMName, serviceName, diskConfig);

            var vmSizeConfig = new SetAzureVMSizeConfig(InstanceSize.Medium.ToString());
            vmPowershellCmdlets.SetVMSize(newAzureQuickVMName, serviceName, vmSizeConfig);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName);
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));
            pass = true;
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (Get-AzureDisk,Remove-AzureVM,Remove-AzureDisk,Get-AzureVMImage)")]
        public void ManagingDiskImages()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Create a unique VM name and Service Name
            string newAzureQuickVMName = Utilities.GetUniqueShortName(vmNamePrefix);
            if (string.IsNullOrEmpty(imageName))
            {
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            }

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName); // New-AzureQuickVM
            Console.WriteLine("VM is created successfully: -Name {0} -ServiceName {1}", newAzureQuickVMName, serviceName);

            // starting the test.
            Collection<DiskContext> vmDisks = vmPowershellCmdlets.GetAzureDiskAttachedToRoleName(new[] { newAzureQuickVMName });  // Get-AzureDisk | Where {$_.AttachedTo.RoleName -eq $vmname }

            foreach (var disk in vmDisks)
                Console.WriteLine("The disk, {0}, is created", disk.DiskName);

            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName);  // Remove-AzureVM
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));
            Console.WriteLine("The VM, {0}, is successfully removed.", newAzureQuickVMName);

            foreach (var disk in vmDisks)
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        vmPowershellCmdlets.RemoveAzureDisk(disk.DiskName, false); // Remove-AzureDisk
                        break;
                    }
                    catch (Exception e)
                    {
                        if (e.ToString().ToLowerInvariant().Contains("currently in use") && i != 2)
                        {
                            Console.WriteLine("The vhd, {0}, is still in the state of being used by the deleted VM", disk.DiskName);
                            Thread.Sleep(120000);
                            continue;
                        }
                        else
                        {
                            Assert.Fail("error during Remove-AzureDisk: {0}", e.ToString());
                        }
                    }
                }

                try
                {
                    vmPowershellCmdlets.GetAzureDisk(disk.DiskName); // Get-AzureDisk -DiskName (try to get the removed disk.)
                    Console.WriteLine("Disk is not removed: {0}", disk.DiskName);
                    pass = false;
                }
                catch (Exception e)
                {
                    if (e.ToString().ToLowerInvariant().Contains("does not exist"))
                    {
                        Console.WriteLine("The disk, {0}, is successfully removed.", disk.DiskName);
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Exception: {0}", e.ToString());
                    }
                }
            }
            pass = true;
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM,Save-AzureVMImage)")]
        public void CaptureImagingExportingImportingVMConfig()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Create a unique VM name
            string newAzureVMName = Utilities.GetUniqueShortName("PSTestVM");
            Console.WriteLine("VM Name: {0}", newAzureVMName);

            // Create a unique Service Name
            vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
            Console.WriteLine("Service Name: {0}", serviceName);
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            // starting the test.
            var azureVMConfigInfo = new AzureVMConfigInfo(newAzureVMName, InstanceSize.Small.ToString(), imageName); // parameters for New-AzureVMConfig (-Name -InstanceSize -ImageName)
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password); // parameters for Add-AzureProvisioningConfig (-Windows -Password)
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            PersistentVM persistentVM = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo); // New-AzureVMConfig & Add-AzureProvisioningConfig

            PersistentVM[] VMs = { persistentVM };
            vmPowershellCmdlets.NewAzureVM(serviceName, VMs); // New-AzureVM
            Console.WriteLine("The VM is successfully created: {0}", persistentVM.RoleName);
            PersistentVMRoleContext vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(persistentVM.RoleName, serviceName);
            Assert.AreEqual(vmRoleCtxt.Name, persistentVM.RoleName, true);


            vmPowershellCmdlets.StopAzureVM(newAzureVMName, serviceName, true); // Stop-AzureVM
            for (int i = 0; i < 3; i++)
            {
                vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(persistentVM.RoleName, serviceName);
                if (vmRoleCtxt.InstanceStatus == "StoppedVM")
                {
                    Console.WriteLine("The status of the VM {0} : {1}", persistentVM.RoleName, vmRoleCtxt.InstanceStatus);
                    break;
                }
                Console.WriteLine("The status of the VM {0} : {1}", persistentVM.RoleName, vmRoleCtxt.InstanceStatus);
                Thread.Sleep(120000);
            }
            Assert.AreEqual(vmRoleCtxt.InstanceStatus, "StoppedVM", true);

            // Save-AzureVMImage
            vmPowershellCmdlets.SaveAzureVMImage(serviceName, newAzureVMName, newAzureVMName);

            // Verify VM image.
            var image = vmPowershellCmdlets.GetAzureVMImage(newAzureVMName)[0];

            Assert.AreEqual("Windows", image.OS, "OS is not matching!");
            Assert.AreEqual(newAzureVMName, image.ImageName, "Names are not matching!");

            // Verify that the VM is removed
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(persistentVM.RoleName, serviceName));

            // Cleanup the registered image
            vmPowershellCmdlets.RemoveAzureVMImage(newAzureVMName, true);

            pass = true;
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (Export-AzureVM,Remove-AzureVM,Import-AzureVM,New-AzureVM)")]
        public void ExportingImportingVMConfigAsTemplateforRepeatableUsage()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Create a new Azure quick VM
            string newAzureQuickVMName = Utilities.GetUniqueShortName("PSTestVM");
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName); // New-AzureQuickVM
            Console.WriteLine("VM is created successfully: -Name {0} -ServiceName {1}", newAzureQuickVMName, serviceName);

            // starting the test.
            string path = ".\\mytestvmconfig1.xml";
            PersistentVMRoleContext vmRole = vmPowershellCmdlets.ExportAzureVM(newAzureQuickVMName, serviceName, path); // Export-AzureVM
            Console.WriteLine("Exporting VM is successfully done: path - {0}  Name - {1}", path, vmRole.Name);

            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName); // Remove-AzureVM
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));
            Console.WriteLine("The VM is successfully removed: {0}", newAzureQuickVMName);

            List<PersistentVM> VMs = new List<PersistentVM>();
            foreach (var pervm in vmPowershellCmdlets.ImportAzureVM(path)) // Import-AzureVM
            {
                VMs.Add(pervm);
                Console.WriteLine("The VM, {0}, is imported.", pervm.RoleName);
            }

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    vmPowershellCmdlets.NewAzureVM(serviceName, VMs.ToArray()); // New-AzureVM
                    Console.WriteLine("All VMs are successfully created.");
                    foreach (var vm in VMs)
                    {
                        Console.WriteLine("created VM: {0}", vm.RoleName);
                    }
                    break;
                }
                catch (Exception e)
                {
                    if (e.ToString().ToLowerInvariant().Contains("currently in use") && i != 2)
                    {
                        Console.WriteLine("The removed VM is still using the vhd");
                        Thread.Sleep(120000);
                        continue;
                    }
                    else
                    {
                        Assert.Fail("error during New-AzureVM: {0}", e.ToString());
                    }
                }
            }

            // Verify
            PersistentVMRoleContext vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName);
            Assert.AreEqual(newAzureQuickVMName, vmRoleCtxt.Name, true);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName);
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));

            pass = true;
        }

        /// <summary>
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (Get-AzureVM,Get-AzureEndpoint,Get-AzureRemoteDesktopFile)")]
        public void ManagingRDPSSHConnectivity()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Create a new Azure quick VM
            string newAzureQuickVMName = Utilities.GetUniqueShortName("PSTestVM");
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName); // New-AzureQuickVM
            Console.WriteLine("VM is created successfully: -Name {0} -ServiceName {1}", newAzureQuickVMName, serviceName);

            // starting the test.
            PersistentVMRoleContext vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName); // Get-AzureVM
            InputEndpointContext inputEndpointCtxt = vmPowershellCmdlets.GetAzureEndPoint(vmRoleCtxt)[0]; // Get-AzureEndpoint
            Console.WriteLine("InputEndpointContext Name: {0}", inputEndpointCtxt.Name);
            Console.WriteLine("InputEndpointContext port: {0}", inputEndpointCtxt.Port);
            Console.WriteLine("InputEndpointContext protocol: {0}", inputEndpointCtxt.Protocol);
            Assert.AreEqual(WinRmEndpointName, inputEndpointCtxt.Name, true);

            string path = ".\\myvmconnection.rdp";
            vmPowershellCmdlets.GetAzureRemoteDesktopFile(newAzureQuickVMName, serviceName, path, false); // Get-AzureRemoteDesktopFile
            Console.WriteLine("RDP file is successfully created at: {0}", path);

            // ToDo: Automate RDP.
            //vmPowershellCmdlets.GetAzureRemoteDesktopFile(newAzureQuickVMName, newAzureQuickVMSvcName, path, true); // Get-AzureRemoteDesktopFile -Launch

            Console.WriteLine("Test passed");

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureQuickVMName, serviceName);
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName));

            pass = true;
        }

        /// <summary>
        /// Basic Provisioning a Virtual Machine
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get,Set,Remove,Move)-AzureDeployment)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\packageScenario.csv", "packageScenario#csv", DataAccessMethod.Sequential)]
        public void DeploymentUpgrade()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string path = Convert.ToString(TestContext.DataRow["path"]);
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);

            var packagePath1 = new FileInfo(@path + packageName); // package with two roles
            var configPath1 = new FileInfo(@path + configName); // config with 2 roles, 4 instances each

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                // New deployment to Production
                DateTime start = DateTime.Now;
                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false);

                TimeSpan duration = DateTime.Now - start;
                Console.WriteLine("Time for all instances to become in ready state: {0}", DateTime.Now - start);

                // Auto-Upgrade the deployment
                start = DateTime.Now;
                vmPowershellCmdlets.SetAzureDeploymentUpgrade(serviceName, DeploymentSlotType.Production, UpgradeType.Auto, packagePath1.FullName, configPath1.FullName);
                duration = DateTime.Now - start;
                Console.WriteLine("Auto upgrade took {0}.", duration);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, serviceName, DeploymentSlotType.Production, null, 4);
                Console.WriteLine("successfully updated the deployment");

                // Manual-Upgrade the deployment
                start = DateTime.Now;
                vmPowershellCmdlets.SetAzureDeploymentUpgrade(serviceName, DeploymentSlotType.Production, UpgradeType.Manual, packagePath1.FullName, configPath1.FullName);
                vmPowershellCmdlets.SetAzureWalkUpgradeDomain(serviceName, DeploymentSlotType.Production, 0);
                vmPowershellCmdlets.SetAzureWalkUpgradeDomain(serviceName, DeploymentSlotType.Production, 1);
                vmPowershellCmdlets.SetAzureWalkUpgradeDomain(serviceName, DeploymentSlotType.Production, 2);
                duration = DateTime.Now - start;
                Console.WriteLine("Manual upgrade took {0}.", duration);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, serviceName, DeploymentSlotType.Production, null, 4);
                Console.WriteLine("successfully updated the deployment");

                // Simulatenous-Upgrade the deployment
                start = DateTime.Now;
                vmPowershellCmdlets.SetAzureDeploymentUpgrade(serviceName, DeploymentSlotType.Production, UpgradeType.Simultaneous, packagePath1.FullName, configPath1.FullName);
                duration = DateTime.Now - start;
                Console.WriteLine("Simulatenous upgrade took {0}.", duration);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, serviceName, DeploymentSlotType.Production, null, 4);
                Console.WriteLine("successfully updated the deployment");

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);
                pass = Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }


        /// <summary>
        /// AzureVNetGatewayTest()
        /// </summary>
        /// Note: Create a VNet, a LocalNet from the portal without creating a gateway.
        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"),
        Description("Test the cmdlet ((Set,Remove)-AzureVNetConfig, Get-AzureVNetSite, (New,Get,Set,Remove)-AzureVNetGateway, Get-AzureVNetConnection)")]
        public void VNetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureQuickVMName = Utilities.GetUniqueShortName(vmNamePrefix);
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            // Read the vnetconfig file and get the names of local networks, virtual networks and affinity groups.
            XDocument vnetconfigxml = XDocument.Load(vnetConfigFilePath);
            List<string> localNets = new List<string>();
            List<string> virtualNets = new List<string>();
            HashSet<string> affinityGroups = new HashSet<string>();
            Dictionary<string, string> dns = new Dictionary<string, string>();
            List<LocalNetworkSite> localNetworkSites = new List<LocalNetworkSite>();
            AddressPrefixList prefixlist = null;

            foreach (XElement el in vnetconfigxml.Descendants())
            {
                switch (el.Name.LocalName)
                {
                    case "LocalNetworkSite":
                        {
                            localNets.Add(el.FirstAttribute.Value);
                            List<XElement> elements = el.Elements().ToList<XElement>();
                            prefixlist = new AddressPrefixList();
                            prefixlist.Add(elements[0].Elements().First().Value);
                            localNetworkSites.Add(new LocalNetworkSite()
                            {
                                VpnGatewayAddress = elements[1].Value,
                                AddressSpace = new AddressSpace() { AddressPrefixes = prefixlist }
                            }
                            );
                        }
                        break;
                    case "VirtualNetworkSite":
                        virtualNets.Add(el.Attribute("name").Value);
                        affinityGroups.Add(el.Attribute("AffinityGroup").Value);
                        break;
                    case "DnsServer":
                        {
                            dns.Add(el.Attribute("name").Value, el.Attribute("IPAddress").Value);
                            break;
                        }
                    default:
                        break;
                }
            }

            foreach (string aff in affinityGroups)
            {
                if (Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, aff))
                {

                    vmPowershellCmdlets.NewAzureAffinityGroup(aff, locationName, null, null);
                }
            }

            string vnet1 = virtualNets[0];
            string lnet1 = localNets[0];

            try
            {
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username, password, locationName); // New-AzureQuickVM
                Console.WriteLine("VM is created successfully: -Name {0} -ServiceName {1}", newAzureQuickVMName, serviceName);

                vmPowershellCmdlets.SetAzureVNetConfig(vnetConfigFilePath);

                foreach (VirtualNetworkSiteContext site in vmPowershellCmdlets.GetAzureVNetSite(null))
                {
                    Console.WriteLine("Name: {0}, AffinityGroup: {1}", site.Name, site.AffinityGroup);
                    Console.WriteLine("Name: {0}, Location: {1}", site.Name, site.Location);
                }

                foreach (string vnet in virtualNets)
                {
                    VirtualNetworkSiteContext vnetsite = vmPowershellCmdlets.GetAzureVNetSite(vnet)[0];
                    Assert.AreEqual(vnet, vnetsite.Name);

                    //Verify DNS and IPAddress
                    Assert.AreEqual(1, vnetsite.DnsServers.Count());
                    Assert.IsTrue(dns.ContainsKey(vnetsite.DnsServers.First().Name));
                    Assert.AreEqual(dns[vnetsite.DnsServers.First().Name], vnetsite.DnsServers.First().Address);

                    //Verify the Gateway sites
                    Assert.AreEqual(1, vnetsite.GatewaySites.Count);
                    Assert.AreEqual(localNetworkSites[0].VpnGatewayAddress, vnetsite.GatewaySites[0].VpnGatewayAddress);
                    Assert.IsTrue(localNetworkSites[0].AddressSpace.AddressPrefixes.All(c => vnetsite.GatewaySites[0].AddressSpace.AddressPrefixes.Contains(c)));

                    Assert.AreEqual(Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState.NotProvisioned, vmPowershellCmdlets.GetAzureVNetGateway(vnet)[0].State);
                }

                vmPowershellCmdlets.NewAzureVNetGateway(vnet1);

                Assert.IsTrue(GetVNetState(vnet1, Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState.Provisioned, 12, 60));

                // Set-AzureVNetGateway -Connect Test
                vmPowershellCmdlets.SetAzureVNetGateway("connect", vnet1, lnet1);

                foreach (Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model.GatewayConnectionContext connection in vmPowershellCmdlets.GetAzureVNetConnection(vnet1))
                {
                    Console.WriteLine("Connectivity: {0}, LocalNetwork: {1}", connection.ConnectivityState, connection.LocalNetworkSiteName);
                    Assert.IsFalse(connection.ConnectivityState.ToLowerInvariant().Contains("notconnected"));
                }

                // Get-AzureVNetGatewayKey
                Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model.SharedKeyContext result = vmPowershellCmdlets.GetAzureVNetGatewayKey(vnet1,
                    vmPowershellCmdlets.GetAzureVNetConnection(vnet1).First().LocalNetworkSiteName);
                Console.WriteLine("Gateway Key: {0}", result.Value);


                // Set-AzureVNetGateway -Disconnect
                vmPowershellCmdlets.SetAzureVNetGateway("disconnect", vnet1, lnet1);

                foreach (Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model.GatewayConnectionContext connection in vmPowershellCmdlets.GetAzureVNetConnection(vnet1))
                {
                    Console.WriteLine("Connectivity: {0}, LocalNetwork: {1}", connection.ConnectivityState, connection.LocalNetworkSiteName);
                }

                // Remove-AzureVnetGateway
                vmPowershellCmdlets.RemoveAzureVNetGateway(vnet1);

                foreach (string vnet in virtualNets)
                {
                    Microsoft.WindowsAzure.Commands.ServiceManagement.Network.VirtualNetworkGatewayContext gateway = vmPowershellCmdlets.GetAzureVNetGateway(vnet)[0];

                    Console.WriteLine("State: {0}, VIP: {1}", gateway.State.ToString(), gateway.VIPAddress);
                    if (vnet.Equals(vnet1))
                    {
                        if (gateway.State != Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState.Deprovisioning &&
                            gateway.State != Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState.NotProvisioned)
                        {
                            Assert.Fail("The state of the gateway is neither Deprovisioning nor NotProvisioned!");
                        }
                    }
                    else
                    {
                        Assert.AreEqual(Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState.NotProvisioned, gateway.State);
                    }

                }

                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "in use", 10, 30);

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                if (cleanupIfFailed)
                {
                    try
                    {
                        vmPowershellCmdlets.RemoveAzureVNetGateway(vnet1);
                    }
                    catch { }
                    Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "in use", 10, 30);
                }
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                foreach (string aff in affinityGroups)
                {
                    try
                    {
                        vmPowershellCmdlets.RemoveAzureAffinityGroup(aff);
                    }
                    catch
                    {
                        // Some service uses the affinity group, so it cannot be deleted.  Just leave it.
                    }
                }
            }
        }

        #region AzureServiceDiagnosticsExtension Tests

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceRemoteDesktopConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\nodiagpackage.csv", "nodiagpackage#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void AzureServiceDiagnosticsExtensionConfigScenarioTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;
            string storage = defaultAzureSubscription.CurrentStorageAccountName;
            string daConfig = @".\da.xml";

            try
            {
                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                ExtensionConfigurationInput config = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, daConfig);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false, config);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                DiagnosticExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName)[0];

                VerifyDiagExtContext(resultContext, "AllRoles", "Default-Diagnostics-Production-Ext-0", storage, daConfig);

                vmPowershellCmdlets.RemoveAzureServiceDiagnosticsExtension(serviceName);

                Assert.AreEqual(vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName).Count, 0);

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceRemoteDesktopExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\nodiagpackage.csv", "nodiagpackage#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void AzureServiceDiagnosticsExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            string storage = defaultAzureSubscription.CurrentStorageAccountName;
            string daConfig = @"da.xml";

            string defaultExtensionId = string.Format("Default-{0}-Production-Ext-0", Utilities.PaaSDiagnosticsExtensionName);

            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
            Console.WriteLine("service, {0}, is created.", serviceName);

            vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false);

            result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
            pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
            Console.WriteLine("successfully deployed the package");

            string storageKey = vmPowershellCmdlets.GetAzureStorageAccountKey(storage).Primary;

            StorageCredentials creds = new StorageCredentials(storage, storageKey);
            CloudStorageAccount csa = new WindowsAzure.Storage.CloudStorageAccount(creds, true);
            var storageContext = new AzureStorageContext(csa);

            vmPowershellCmdlets.SetAzureServiceDiagnosticsExtension(serviceName, storageContext, daConfig, null, null);

            DiagnosticExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName)[0];

            VerifyDiagExtContext(resultContext, "AllRoles", defaultExtensionId, storage, daConfig);

            vmPowershellCmdlets.RemoveAzureServiceDiagnosticsExtension(serviceName, true);

            Assert.AreEqual(vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName).Count, 0);

            vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

            pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceRemoteDesktopExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\nodiagpackage.csv", "nodiagpackage#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void VipSwapWithDiagnosticsExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);
            var packagePath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath.FullName), "Package file not exist={0}", packagePath);
            Assert.IsTrue(File.Exists(configPath.FullName), "Config file not exist={0}", configPath);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            string storage = defaultAzureSubscription.CurrentStorageAccountName;
            string daConfig = @"da.xml";

            string storageKey = vmPowershellCmdlets.GetAzureStorageAccountKey(storage).Primary;
            StorageCredentials creds = new StorageCredentials(storage, storageKey);
            CloudStorageAccount csa = new WindowsAzure.Storage.CloudStorageAccount(creds, true);
            var storageContext = new AzureStorageContext(csa);

            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
            Console.WriteLine("service, {0}, is created.", serviceName);

            // deploy staging
            vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath.FullName, configPath.FullName, DeploymentSlotType.Staging, deploymentLabel, deploymentName, false, false);
            result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
            pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Staging, null, 2);
            Console.WriteLine("successfully deployed the package");

            vmPowershellCmdlets.SetAzureServiceDiagnosticsExtension(serviceName, storageContext, daConfig, null, slot: DeploymentSlotType.Staging);
            DiagnosticExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName, slot: DeploymentSlotType.Staging)[0];
            VerifyDiagExtContext(resultContext, "AllRoles", "Default-PaaSDiagnostics-Staging-Ext-0", storage, daConfig);

            // swap staging -> production
            // production will be retain diagnosting config from staging, named Default-PaaSDiagnostics-Staging-Ext-0
            vmPowershellCmdlets.MoveAzureDeployment(serviceName);

            // deploy a new staging
            deploymentName = "deployment2";
            deploymentLabel = "label2";

            vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath.FullName, configPath.FullName, DeploymentSlotType.Staging, deploymentLabel, deploymentName, false, false);
            result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
            pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Staging, null, 2);
            Console.WriteLine("successfully deployed the package");

            // should detect that Default-PaaSDiagnostics-Staging-Ext-0 is in use 
            vmPowershellCmdlets.SetAzureServiceDiagnosticsExtension(serviceName, storageContext, daConfig, null, slot: DeploymentSlotType.Staging);
            DiagnosticExtensionContext resultContext2 = vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName, slot: DeploymentSlotType.Staging)[0];
            VerifyDiagExtContext(resultContext2, "AllRoles", "Default-PaaSDiagnostics-Staging-Ext-1", storage, daConfig);

            // execute again to make sure max number of extensions will handled correctly (1 for production and 1 for staging, 1 unused)
            // should not fail due to ExtensionIdLiveCycleCount limit
            vmPowershellCmdlets.SetAzureServiceDiagnosticsExtension(serviceName, storageContext, daConfig, null, slot: DeploymentSlotType.Staging);
            DiagnosticExtensionContext resultContext3 = vmPowershellCmdlets.GetAzureServiceDiagnosticsExtension(serviceName, slot: DeploymentSlotType.Staging)[0];

            // azure splits config from All Roles to specific role in that case, so role name should not be validated
            VerifyDiagExtContext(resultContext3, null, "Default-PaaSDiagnostics-Staging-Ext-2", storage, daConfig);
            
            vmPowershellCmdlets.RemoveAzureService(serviceName, true);
        }

        #endregion



        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("huangpf"), Description("Test the ADDomain cmdlets.")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceADDomainExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));

            try
            {
                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                // Workgroup Config
                var workGroupName = "test";
                ExtensionConfigurationInput config = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    workGroupName, null, null, false, null, null, null);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false, config);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                var resultContext = vmPowershellCmdlets.GetAzureServiceDomainJoinExtension(serviceName);
                Assert.IsTrue(string.IsNullOrEmpty(resultContext.User));
                Assert.IsTrue(resultContext.Name == workGroupName);
                Assert.IsTrue(resultContext.Restart == false);

                vmPowershellCmdlets.RemoveAzureServiceDomainJoinExtension(serviceName, DeploymentSlotType.Production);

                // Join a Workgroup
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    workGroupName, serviceName, DeploymentSlotType.Production, null, null, false, null, null, "1.*");
                resultContext = vmPowershellCmdlets.GetAzureServiceDomainJoinExtension(serviceName);
                Assert.IsTrue(string.IsNullOrEmpty(resultContext.User));
                Assert.IsTrue(resultContext.Name == workGroupName);
                Assert.IsTrue(resultContext.Restart == false);
                Assert.IsTrue(resultContext.Version == "1.*");

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                // Domain Config
                var domainName = "test.bing.com";
                config = vmPowershellCmdlets.NewAzureServiceDomainJoinExtensionConfig(
                    domainName, null, null, null, null, null, 35, true, cred, "1.*");
                Assert.IsTrue(config.Roles.Any(r => r.Default));
                Assert.IsTrue(config.PublicConfiguration.Contains(cred.UserName));
                Assert.IsTrue(config.PublicConfiguration.Contains(domainName));
                Assert.IsTrue(config.PublicConfiguration.Contains("35"));

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false, config);

                vmPowershellCmdlets.RemoveAzureServiceDomainJoinExtension(serviceName, DeploymentSlotType.Production);

                // Join a Domain
                vmPowershellCmdlets.SetAzureServiceDomainJoinExtension(
                    domainName, cred, 35, false, serviceName, DeploymentSlotType.Production, null, (X509Certificate2)null, null, (PSCredential)null, null, "1.*");

                resultContext = vmPowershellCmdlets.GetAzureServiceDomainJoinExtension(serviceName);
                Assert.IsTrue(resultContext.User == cred.UserName);
                Assert.IsTrue(resultContext.Name == domainName);
                Assert.IsTrue(resultContext.JoinOption == 35);
                Assert.IsTrue(resultContext.Restart == false);
                Assert.IsTrue(resultContext.Version == "1.*");

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        #region AzureServiceRemoteDesktopExtension Tests

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceRemoteDesktopConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceRemoteDesktopExtensionConfigScenarioTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            string rdpPath = @".\WebRole1.rdp";

            try
            {

                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                ExtensionConfigurationInput config = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false, config);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(serviceName)[0];

                VerifyRDPExtContext(resultContext, "AllRoles", "Default-RDP-Production-Ext-0", username, DateTime.Now.AddYears(1));

                VerifyRDP(serviceName, rdpPath);

                vmPowershellCmdlets.RemoveAzureServiceRemoteDesktopExtension(serviceName);

                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failed to get RDP file as expected");
                    }
                }

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceRemoteDesktopConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceRemoteDesktopExtensionConfigWithVersionScenarioTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            string rdpPath = @".\WebRole1.rdp";
            string version10 = "1.0";

            try
            {

                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                ExtensionConfigurationInput config = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, null, null, version10);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false, config);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(serviceName)[0];

                VerifyRDPExtContext(resultContext, "AllRoles", "Default-RDP-Production-Ext-0", username, DateTime.Now.AddYears(1), version10);

                VerifyRDP(serviceName, rdpPath);

                vmPowershellCmdlets.RemoveAzureServiceRemoteDesktopExtension(serviceName);

                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failed to get RDP file as expected");
                    }
                }

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceRemoteDesktopExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceRemoteDesktopExtensionTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            string rdpPath = @".\WebRole1.rdp";

            try
            {
                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                vmPowershellCmdlets.SetAzureServiceRemoteDesktopExtension(serviceName, cred);

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(serviceName)[0];

                VerifyRDPExtContext(resultContext, "AllRoles", "Default-RDP-Production-Ext-0", username, DateTime.Now.AddYears(1));

                VerifyRDP(serviceName, rdpPath);

                vmPowershellCmdlets.RemoveAzureServiceRemoteDesktopExtension(serviceName, true);
                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failed to get RDP file as expected");
                    }
                }

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceRemoteDesktopExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceRemoteDesktopExtensionWithVersionTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            string rdpPath = @".\WebRole1.rdp";
            string version10 = "1.0";

            try
            {
                serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Production, deploymentLabel, deploymentName, false, false);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                vmPowershellCmdlets.SetAzureServiceRemoteDesktopExtension(serviceName, cred, null, null, null, version10);

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(serviceName)[0];

                VerifyRDPExtContext(resultContext, "AllRoles", "Default-RDP-Production-Ext-0", username, DateTime.Now.AddYears(1), version10);

                VerifyRDP(serviceName, rdpPath);

                vmPowershellCmdlets.RemoveAzureServiceRemoteDesktopExtension(serviceName, true);

                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failed to get RDP file as expected");
                    }
                }

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        #endregion

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Reset-AzureRoleInstanceTest with Reboot and Reimage paramaeters)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void ReSetAzureRoleInstanceTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow[2]);
            string configName = Convert.ToString(TestContext.DataRow[3]);

            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "file not exist={0}", configPath1);

            string deploymentName = Utilities.GetUniqueShortName("ResetRoleInst", 20);
            string deploymentLabel = Utilities.GetUniqueShortName("ResetRoleInstDepLabel", 20);
            DeploymentInfoContext result;

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Staging, deploymentLabel, deploymentName, false, false);
                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Staging, null, 2);
                Console.WriteLine("successfully deployed the package");

                //Reboot the role instance
                vmPowershellCmdlets.ResetAzureRoleInstance(serviceName, "WebRole1_IN_0", DeploymentSlotType.Staging, reboot: true);
                var deploymentContextInfo = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                //verify that other instances are in ready state
                string roleStatus = string.Empty;
                foreach (var instance in deploymentContextInfo.RoleInstanceList)
                {
                    if (instance.InstanceName.Equals("WebRole1_IN_1"))
                    {
                        roleStatus = instance.InstanceStatus;
                        break;
                    }
                }
                pass = roleStatus == ReadyState;

                //Reimage the role instance
                vmPowershellCmdlets.ResetAzureRoleInstance(serviceName, "WebRole1_IN_1", DeploymentSlotType.Staging, reimage: true);
                //verify that other instances are in ready state
                deploymentContextInfo = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                roleStatus = string.Empty;
                foreach (var instance in deploymentContextInfo.RoleInstanceList)
                {
                    if (instance.InstanceName.Equals("WebRole1_IN_0"))
                    {
                        roleStatus = instance.InstanceStatus;
                        break;
                    }
                }
                pass = roleStatus == ReadyState;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                //Ceanup service
                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Staging, true);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Staging);
            }
        }

        /// <summary>
        /// Deploy an IaaS VM with Domain Join
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMDomainJoinTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            var newAzureVMName = Utilities.GetUniqueShortName(vmNamePrefix);

            const string joinDomainStr = "www.microsoft.com";
            const string domainStr = "microsoft.com";
            const string domainUser = "pstestdomainuser";
            const string domainPassword = "p@ssw0rd";

            try
            {
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                }

                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);

                var azureVMConfigInfo = new AzureVMConfigInfo(newAzureVMName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo("WindowsDomain", username, password,
                                                                              joinDomainStr, domainStr, domainUser,
                                                                              domainPassword);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null,
                                                                        null);
                PersistentVM persistentVM = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                PersistentVM[] VMs = { persistentVM };
                vmPowershellCmdlets.NewAzureVM(serviceName, VMs);

                // Todo: Check the domain of the VM
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void SetProvisionGuestAgentTest()
        {
            try
            {
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("VM Name:{0}", vmName);
                PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password, true);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName, false);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Utilities.PrintContext(vmRoleContext);
                Assert.IsNotNull(vmRoleContext.VM.ProvisionGuestAgent, "ProvisionGuestAgent value cannot be null");
                Assert.IsFalse(vmRoleContext.VM.ProvisionGuestAgent.Value);
                Console.WriteLine("Guest Agent Status: {0}", vmRoleContext.VM.ProvisionGuestAgent.Value);
                vmRoleContext.VM.ProvisionGuestAgent = true;
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vmRoleContext.VM);
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Utilities.PrintContext(vmRoleContext);
                Assert.IsNotNull(vmRoleContext.VM.ProvisionGuestAgent, "ProvisionGuestAgent value cannot be null");
                Assert.IsTrue(vmRoleContext.VM.ProvisionGuestAgent.Value);
                Console.WriteLine("Guest Agent Status: {0}", vmRoleContext.VM.ProvisionGuestAgent.Value);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Remove the service
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                CleanupService(serviceName);
            }
        }

        private string GetSiteContent(Uri uri, int maxRetryTimes, bool holdConnection)
        {
            Console.WriteLine("GetSiteContent. uri={0} maxRetryTimes={1}", uri.AbsoluteUri, maxRetryTimes);

            HttpWebRequest request;
            HttpWebResponse response = null;

            var noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest.DefaultCachePolicy = noCachePolicy;

            int i;
            for (i = 1; i <= maxRetryTimes; i++)
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(uri);
                    request.Timeout = 10 * 60 * 1000; //set to 10 minutes, default 100 sec. default IE7/8 is 60 minutes
                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException e)
                {
                    Console.WriteLine("Exception Message: " + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code: {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description: {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    }
                }

                Thread.Sleep(30 * 1000);
            }

            if (i > maxRetryTimes)
            {
                throw new Exception("Web Site has error and reached maxRetryTimes");
            }

            Stream responseStream = response.GetResponseStream();
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[100];
            int length;
            while ((length = responseStream.Read(buf, 0, 100)) != 0)
            {
                if (holdConnection)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
                sb.Append(Encoding.UTF8.GetString(buf, 0, length));
            }

            string responseString = sb.ToString();
            Console.WriteLine("Site content: (IsFromCache={0})", response.IsFromCache);
            Console.WriteLine(responseString);

            return responseString;
        }

        private bool GetVNetState(string vnet, Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState expectedState, int maxTime, int intervalTime)
        {
            Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ProvisioningState vnetState;
            int i = 0;
            do
            {
                vnetState = vmPowershellCmdlets.GetAzureVNetGateway(vnet)[0].State;
                Thread.Sleep(intervalTime * 1000);
                i++;
            }
            while (!vnetState.Equals(expectedState) || i < maxTime);

            return vnetState.Equals(expectedState);
        }

        private void VerifyDiagExtContext(DiagnosticExtensionContext resultContext, string role, string extID, string storage, string config)
        {
            Utilities.PrintContext(resultContext);

            if (role != null)
            {
                Assert.AreEqual(role, resultContext.Role.RoleType.ToString(), "role is not same");
            }

            Assert.AreEqual(Utilities.PaaSDiagnosticsExtensionName, resultContext.Extension, "extension is not Diagnostics");

            Assert.AreEqual(extID, resultContext.Id, "extension id is not same");

            XmlDocument doc = new XmlDocument();
            doc.Load("da.xml");
            string inner = Utilities.GetInnerXml(resultContext.WadCfg, "WadCfg");
            Utilities.CompareWadCfg(inner, doc);
        }

        private void VerifyRDPExtContext(RemoteDesktopExtensionContext resultContext, string role, string extID, string userName, DateTime exp, string version = null)
        {
            Utilities.PrintContextAndItsBase(resultContext);

            Assert.AreEqual(role, resultContext.Role.RoleType.ToString(), "role is not same");
            Assert.AreEqual("RDP", resultContext.Extension, "extension is not RDP");
            Assert.AreEqual(extID, resultContext.Id, "extension id is not same");
            Assert.AreEqual(userName, resultContext.UserName, "storage account name is not same");
            Assert.IsTrue(Utilities.CompareDateTime(exp, resultContext.Expiration), "expiration is not same");
            if (!string.IsNullOrEmpty(version))
            {
                Assert.AreEqual(version, resultContext.Version, "version numbers are not same");
            }
        }
    }
}