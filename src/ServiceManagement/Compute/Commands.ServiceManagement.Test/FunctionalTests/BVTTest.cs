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
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class BVTTest : ServiceManagementTest
    {
        private string serviceName;

        [TestInitialize]
        public void Initialize()
        {
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            pass = false;
            testStartTime = DateTime.Now;
        }

        /// <summary>
        /// BVT test for IaaS cmdlets.
        /// </summary>
        [TestMethod(), TestCategory(Category.BVT), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("BVT Test for IaaS")]
        public void AzureIaaSBVT()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            DateTime prevTime = DateTime.Now;

            string diskLabel1 = "disk1";
            int diskSize1 = 30;
            int lunSlot1 = 0;

            string diskLabel2 = "disk2";
            int diskSize2 = 50;
            int lunSlot2 = 2;

            string ep1Name = "tcp1";
            int ep1LocalPort = 60010;
            int ep1PublicPort = 60011;
            string ep1LBSetName = "lbset1";
            int ep1ProbePort = 60012;
            string ep1ProbePath = string.Empty;
            int? ep1ProbeInterval = 7;
            int? ep1ProbeTimeout = null;
            NetworkAclObject ep1AclObj = vmPowershellCmdlets.NewAzureAclConfig();
            bool ep1DirectServerReturn = false;

            string ep2Name = "tcp2";
            int ep2LocalPort = 60020;
            int ep2PublicPort = 60021;
            int ep2LocalPortChanged = 60030;
            int ep2PublicPortChanged = 60031;
            string ep2LBSetName = "lbset2";
            int ep2ProbePort = 60022;
            string ep2ProbePath = @"/";
            int? ep2ProbeInterval = null;
            int? ep2ProbeTimeout = 32;
            NetworkAclObject ep2AclObj = vmPowershellCmdlets.NewAzureAclConfig();
            bool ep2DirectServerReturn = false;

            string cerFileName = "testcert.cer";
            string thumbprintAlgorithm = "sha1";

            try
            {
                // Create a certificate
                X509Certificate2 certCreated = Utilities.CreateCertificate(password);
                byte[] certData2 = certCreated.Export(X509ContentType.Cert);
                File.WriteAllBytes(cerFileName, certData2);

                // Install the .cer file to local machine.
                StoreLocation certStoreLocation = StoreLocation.CurrentUser;
                StoreName certStoreName = StoreName.My;
                X509Certificate2 installedCert = Utilities.InstallCert(cerFileName, certStoreLocation, certStoreName);

                PSObject certToUpload = vmPowershellCmdlets.RunPSScript(
                    String.Format("Get-Item cert:\\{0}\\{1}\\{2}", certStoreLocation.ToString(), certStoreName.ToString(), installedCert.Thumbprint))[0];
                string certData = Convert.ToBase64String(((X509Certificate2)certToUpload.BaseObject).RawData);

                string newAzureVMName = Utilities.GetUniqueShortName(vmNamePrefix);

                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false, 50);

                RecordTimeTaken(ref prevTime);

                //
                // New-AzureService and verify with Get-AzureService
                //
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Assert.IsTrue(Verify.AzureService(serviceName, serviceName, locationName));
                RecordTimeTaken(ref prevTime);

                //
                // Add-AzureCertificate and verify with Get-AzureCertificate
                //
                vmPowershellCmdlets.AddAzureCertificate(serviceName, certToUpload);
                Assert.IsTrue(Verify.AzureCertificate(serviceName, certCreated.Thumbprint, thumbprintAlgorithm, certData));
                RecordTimeTaken(ref prevTime);

                //
                // Remove-AzureCertificate
                //
                vmPowershellCmdlets.RemoveAzureCertificate(serviceName, certCreated.Thumbprint, thumbprintAlgorithm);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, serviceName, certCreated.Thumbprint, thumbprintAlgorithm));
                RecordTimeTaken(ref prevTime);

                //
                // New-AzureVMConfig
                //
                var azureVMConfigInfo = new AzureVMConfigInfo(newAzureVMName, InstanceSize.Small.ToString(), imageName);
                PersistentVM vm = vmPowershellCmdlets.NewAzureVMConfig(azureVMConfigInfo);

                RecordTimeTaken(ref prevTime);

                //
                // Add-AzureCertificate
                //
                vmPowershellCmdlets.AddAzureCertificate(serviceName, certToUpload);

                //
                // New-AzureCertificateSetting
                //
                CertificateSettingList certList = new CertificateSettingList();
                certList.Add(vmPowershellCmdlets.NewAzureCertificateSetting(certStoreName.ToString(), installedCert.Thumbprint));
                RecordTimeTaken(ref prevTime);

                //
                // Add-AzureProvisioningConfig
                //
                AzureProvisioningConfigInfo azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, certList, username, password);
                azureProvisioningConfig.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureProvisioningConfig(azureProvisioningConfig);
                RecordTimeTaken(ref prevTime);

                //
                // Add-AzureDataDisk (two disks)
                //
                AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, diskLabel1, lunSlot1);
                azureDataDiskConfigInfo1.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureDataDisk(azureDataDiskConfigInfo1);

                AddAzureDataDiskConfig azureDataDiskConfigInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize2, diskLabel2, lunSlot2);
                azureDataDiskConfigInfo2.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureDataDisk(azureDataDiskConfigInfo2);

                RecordTimeTaken(ref prevTime);

                //
                // Add-AzureEndpoint (two endpoints)
                //
                AzureEndPointConfigInfo azureEndPointConfigInfo1 = new AzureEndPointConfigInfo(
                    AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                    ProtocolInfo.tcp,
                    ep1LocalPort,
                    ep1PublicPort,
                    ep1Name,
                    ep1LBSetName,
                    ep1ProbePort,
                    ProtocolInfo.tcp,
                    ep1ProbePath,
                    ep1ProbeInterval,
                    ep1ProbeTimeout,
                    ep1AclObj,
                    ep1DirectServerReturn,
                    null,
                    null,
                    LoadBalancerDistribution.SourceIP);

                azureEndPointConfigInfo1.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureEndPoint(azureEndPointConfigInfo1);

                AzureEndPointConfigInfo azureEndPointConfigInfo2 = new AzureEndPointConfigInfo(
                    AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                    ProtocolInfo.tcp,
                    ep2LocalPort,
                    ep2PublicPort,
                    ep2Name,
                    ep2LBSetName,
                    ep2ProbePort,
                    ProtocolInfo.http,
                    ep2ProbePath,
                    ep2ProbeInterval,
                    ep2ProbeTimeout,
                    ep2AclObj,
                    ep2DirectServerReturn);

                azureEndPointConfigInfo2.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureEndPoint(azureEndPointConfigInfo2);

                RecordTimeTaken(ref prevTime);

                //
                // Set-AzureAvailabilitySet
                //

                string testAVSetName = "testAVSet1";
                vm = vmPowershellCmdlets.SetAzureAvailabilitySet(testAVSetName, vm);
                RecordTimeTaken(ref prevTime);

                //
                // Set-AzureOSDisk
                //
                vm = vmPowershellCmdlets.SetAzureOSDisk(null, vm, 100);

                //
                // New-AzureDns
                //
                string dnsName = "OpenDns1";
                string ipAddress = "208.67.222.222";

                DnsServer dns = vmPowershellCmdlets.NewAzureDns(dnsName, ipAddress);

                RecordTimeTaken(ref prevTime);

                //
                // New-AzureVM
                //
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, null, new[] { dns }, null, null, null, null);
                RecordTimeTaken(ref prevTime);

                //
                // Get-AzureVM without any parameter (List VMs)
                //
                var vmlist = vmPowershellCmdlets.GetAzureVM();
                Console.WriteLine("The number of VMs: {0}", vmlist.Count);
                Assert.AreNotSame(0, vmlist.Count, "No VM exists!!!");
                PersistentVMRoleListContext returnedVMlist =
                    vmlist.First(item => item.ServiceName.Equals(serviceName) && item.Name.Equals(newAzureVMName));
                Assert.IsNotNull(returnedVMlist, "Created VM does not exist!!!");
                Utilities.PrintContext((PersistentVMRoleContext) returnedVMlist);

                //
                // Get-AzureVM
                //
                PersistentVMRoleContext returnedVM = vmPowershellCmdlets.GetAzureVM(newAzureVMName, serviceName);
                vm = returnedVM.VM;
                RecordTimeTaken(ref prevTime);

                //
                // Verify AzureDataDisk
                //
                Assert.IsTrue(Verify.AzureDataDisk(vm, diskLabel1, diskSize1, lunSlot1, HostCaching.None), "Data disk is not properly added");
                Assert.IsTrue(Verify.AzureDataDisk(vm, diskLabel2, diskSize2, lunSlot2, HostCaching.None), "Data disk is not properly added");
                Console.WriteLine("Data disk added correctly.");

                RecordTimeTaken(ref prevTime);

                //
                // Verify AzureEndpoint
                //
                Assert.IsTrue(Verify.AzureEndpoint(vm, new[]{azureEndPointConfigInfo1, azureEndPointConfigInfo2}));

                //
                // Verify RDP & PowerShell Endpoints
                //
                var endpoints = vmPowershellCmdlets.GetAzureEndPoint(vm);
                Assert.IsTrue(endpoints.Count(e => e.Name == "PowerShell" && e.LocalPort == 5986 && e.Protocol == "tcp") == 1);
                Assert.IsTrue(endpoints.Count(e => e.Name == "RemoteDesktop" && e.LocalPort == 3389 && e.Protocol == "tcp") == 1);

                //
                // Verify DebugSettings
                //
                Assert.IsTrue(vm.DebugSettings.BootDiagnosticsEnabled);

                //
                // Verify AzureDns
                //
                Assert.IsTrue(Verify.AzureDns(vmPowershellCmdlets.GetAzureDeployment(serviceName).DnsSettings, dns));

                //
                // Verify AzureAvailibilitySet
                //
                Assert.IsTrue(Verify.AzureAvailabilitySet(vm, testAVSetName));

                //
                // Verify AzureOsDisk
                //
                Assert.IsTrue(Verify.AzureOsDisk(vm, "Windows", HostCaching.ReadWrite));

                //
                // Set-AzureDataDisk
                //
                SetAzureDataDiskConfig setAzureDataDiskConfigInfo = new SetAzureDataDiskConfig(HostCaching.ReadOnly, lunSlot1);
                setAzureDataDiskConfigInfo.Vm = vm;
                vm = vmPowershellCmdlets.SetAzureDataDisk(setAzureDataDiskConfigInfo);
                RecordTimeTaken(ref prevTime);

                //
                // Remove-AzureDataDisk
                //
                RemoveAzureDataDiskConfig removeAzureDataDiskConfig = new RemoveAzureDataDiskConfig(lunSlot2, vm);
                vm = vmPowershellCmdlets.RemoveAzureDataDisk(removeAzureDataDiskConfig);
                RecordTimeTaken(ref prevTime);

                //
                // Set-AzureEndpoint
                //
                azureEndPointConfigInfo2 = new AzureEndPointConfigInfo(
                    AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                    ProtocolInfo.tcp,
                    ep2LocalPortChanged,
                    ep2PublicPortChanged,
                    ep2Name,
                    ep2LBSetName,
                    ep2ProbePort,
                    ProtocolInfo.http,
                    ep2ProbePath,
                    ep2ProbeInterval,
                    ep2ProbeTimeout,
                    ep2AclObj,
                    ep2DirectServerReturn);

                azureEndPointConfigInfo2.Vm = vm;
                vm = vmPowershellCmdlets.SetAzureEndPoint(azureEndPointConfigInfo2);
                RecordTimeTaken(ref prevTime);

                //
                // Remove-AzureEndpoint
                //
                vm = vmPowershellCmdlets.RemoveAzureEndPoint(azureEndPointConfigInfo1.EndpointName, vm);
                RecordTimeTaken(ref prevTime);

                //
                // Set-AzureVMSize
                //
                var vmSizeConfig = new SetAzureVMSizeConfig(InstanceSize.Medium.ToString());
                vmSizeConfig.Vm = vm;
                vm = vmPowershellCmdlets.SetAzureVMSize(vmSizeConfig);
                RecordTimeTaken(ref prevTime);

                //
                // Set-AzureOSDisk
                //
                vm = vmPowershellCmdlets.SetAzureOSDisk(HostCaching.ReadOnly, vm);

                //
                // Update-AzureVM
                //
                vmPowershellCmdlets.UpdateAzureVM(newAzureVMName, serviceName, vm);
                RecordTimeTaken(ref prevTime);

                //
                // Get-AzureVM and Verify the VM
                //
                vm = vmPowershellCmdlets.GetAzureVM(newAzureVMName, serviceName).VM;

                // Verify setting data disk
                Assert.IsTrue(Verify.AzureDataDisk(vm, diskLabel1, diskSize1, lunSlot1, HostCaching.ReadOnly), "Data disk is not properly added");

                // Verify removing a data disk
                Assert.AreEqual(1, vmPowershellCmdlets.GetAzureDataDisk(vm).Count, "DataDisk is not removed.");

                // Verify setting an endpoint
                Assert.IsTrue(Verify.AzureEndpoint(vm, new[]{azureEndPointConfigInfo2}));

                // Verify removing an endpoint
                Assert.IsFalse(Verify.AzureEndpoint(vm, new[] { azureEndPointConfigInfo1 }));

                // Verify os disk
                Assert.IsTrue(Verify.AzureOsDisk(vm, "Windows", HostCaching.ReadOnly));

                //
                // Remove-AzureVM
                //
                vmPowershellCmdlets.RemoveAzureVM(newAzureVMName, serviceName, false, true);
                Assert.AreNotEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVMName, serviceName));

                vmPowershellCmdlets.RemoveAzureVM(newAzureVMName, serviceName);

                RecordTimeTaken(ref prevTime);

                Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVMName, serviceName));
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
                try
                {
                    vmPowershellCmdlets.RemoveAzureService(serviceName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred while deleting service: {0}", e.ToString());

                }
                try
                {
                    vmPowershellCmdlets.GetAzureService(serviceName);
                    Console.WriteLine("The service, {0}, is not removed", serviceName);
                }
                catch (Exception e)
                {
                    if (e.ToString().ToLowerInvariant().Contains("does not exist"))
                    {
                        Console.WriteLine("The service, {0}, is successfully removed", serviceName);
                    }
                    else
                    {
                        Console.WriteLine("Error occurred: {0}", e.ToString());
                    }
                }
            }
        }

        private void RecordTimeTaken(ref DateTime prev)
        {
            var period = DateTime.Now - prev;
            Console.WriteLine("{0} seconds and {1} ms passed...", period.Seconds.ToString(), period.Milliseconds.ToString());
            prev = DateTime.Now;
        }
    }
}
