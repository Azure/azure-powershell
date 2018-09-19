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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class NewAzureVmTests:ServiceManagementTest
    {
        private string _serviceName;
        private string _vmName;
        private string _linuxImageName;
        const string CerFileName = "testcert.cer";
        X509Certificate2 _installedCert;
        private StoreLocation certStoreLocation;
        private StoreName certStoreName;
        private string keyPath;

        [TestInitialize]
        public void Intialize()
        {
            pass = false;
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            _linuxImageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);
            InstallCertificate();
            keyPath = Directory.GetCurrentDirectory() + Utilities.GetUniqueShortName() + ".txt";
            _serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            _vmName = Utilities.GetUniqueShortName("vm");
        }


        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithResizeDiskTest()
        {
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false, 50);
            string newVMImageName = Utilities.GetUniqueShortName("vmimage");
            const int newDiskSize = 100;

            try
            {
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, _vmName, _serviceName, imageName, username, password, locationName);
                Console.WriteLine("Service Name: {0} is created.  VM: {1} is created.", _serviceName, _vmName);

                string diskLabel1 = "disk1";
                int diskSize1 = 30;
                int lunSlot1 = 0;

                string diskLabel2 = "disk2";
                int diskSize2 = 50;
                int lunSlot2 = 2;

                AddAzureDataDiskConfig dataDiskInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, diskLabel1, lunSlot1);
                AddAzureDataDiskConfig dataDiskInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize2, diskLabel2, lunSlot2);

                vmPowershellCmdlets.AddDataDisk(_vmName, _serviceName, new[] { dataDiskInfo1, dataDiskInfo2 });

                vmPowershellCmdlets.SaveAzureVMImage(_serviceName, _vmName, newVMImageName, "Specialized");

                var newImage = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(newVMImageName).FirstOrDefault();

                foreach (var disk in newImage.DataDiskConfigurations)
                {
                    Utilities.PrintContextAndItsBase(disk);
                }

                string disk1 = newImage.DataDiskConfigurations[0].Name;
                string disk2 = newImage.DataDiskConfigurations[1].Name;

                vmPowershellCmdlets.RemoveAzureService(_serviceName);

                // Add-AzureProvisioningConfig with NoSSHEndpoint
                var vm = vmPowershellCmdlets.NewAzureVMConfig(new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), newVMImageName));
                vm = vmPowershellCmdlets.SetAzureDataDisk(new SetAzureDataDiskResizeConfig(disk1, newDiskSize, vm));
                vm = vmPowershellCmdlets.SetAzureDataDisk(new SetAzureDataDiskResizeConfig(disk2, newDiskSize, vm));
                vm = vmPowershellCmdlets.SetAzureOSDisk(null, vm, newDiskSize);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);

                // Validate disk sizes
                var returnedVM = vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName);
                foreach (var disk in returnedVM.VM.DataVirtualHardDisks)
                {
                    Utilities.PrintContextAndItsBase(disk);
                }
                Assert.AreEqual(newDiskSize, returnedVM.VM.DataVirtualHardDisks[0].LogicalDiskSizeInGB);
                Assert.AreEqual(newDiskSize, returnedVM.VM.DataVirtualHardDisks[1].LogicalDiskSizeInGB);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException);
                }
                throw;
            }
            finally
            {
                vmPowershellCmdlets.RemoveAzureService(_serviceName);
                vmPowershellCmdlets.RemoveAzureVMImage(newVMImageName,true);
            }
        }



        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithLinuxAndNoSSHEnpoint()
        {
            try
            {
                // Add-AzureProvisioningConfig with NoSSHEndpoint
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, true);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));

                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(0, endpoints.Count);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM) and verifies a that a linux vm can be created with out password")]
        public void NewAzureLinuxVMWithoutPasswordAndNoSSHEnpoint()
        {
            try
            {
                //Create service
                vmPowershellCmdlets.NewAzureService(_serviceName, locationName);

                //Add installed certificate to the service
                PSObject certToUpload = vmPowershellCmdlets.RunPSScript(
                    String.Format("Get-Item cert:\\{0}\\{1}\\{2}", certStoreLocation.ToString(), certStoreName.ToString(), _installedCert.Thumbprint))[0];
                vmPowershellCmdlets.AddAzureCertificate(_serviceName, certToUpload);

                var key = vmPowershellCmdlets.NewAzureSSHKey(NewAzureSshKeyType.PublicKey, _installedCert.Thumbprint, keyPath);
                var sshKeysList = new Model.LinuxProvisioningConfigurationSet.SSHPublicKeyList();
                sshKeysList.Add(key);

                // Add-AzureProvisioningConfig without password and NoSSHEndpoint
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, noSshEndpoint: true, sSHPublicKeyList: sshKeysList);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm });
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));

                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(0, endpoints.Count);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithLinuxAndDisableSSH()
        {
            try
            {
                // Add-AzureProvisioningConfig with DisableSSH option
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, false, true);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));

                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(0, endpoints.Count);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets(New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM) with a WinRMCert")]
        public void NewAzureVMWithWindowsAndCustomData()
        {
            try
            {
                var customDataFile = @".\CustomData.bin";
                var customDataContent = File.ReadAllText(customDataFile);

                // Add-AzureProvisioningConfig with X509Certificate
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, customDataFile);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName, true);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);

                // Get-AzureVM
                var vmContext = vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName);

                // Get-AzureCertificate
                var winRmCert = vmPowershellCmdlets.GetAzureCertificate(_serviceName, vmContext.VM.DefaultWinRmCertificateThumbprint, "sha1").First();

                // Install the WinRM cert to the local machine's root location.
                InstallCertificate(winRmCert, StoreLocation.LocalMachine, StoreName.Root);

                var connUri = vmPowershellCmdlets.GetAzureWinRMUri(_serviceName, _vmName);
                var cred = new PSCredential(username, Utilities.convertToSecureString(password));

                Utilities.RetryActionUntilSuccess(() =>
                {
                    // Invoke Command
                    var scriptBlock = ScriptBlock.Create(@"Get-Content -Path 'C:\AzureData\CustomData.bin'");
                    var invokeInfo = new InvokeCommandCmdletInfo(connUri, cred, scriptBlock);
                    var invokeCmd = new PowershellCmdlet(invokeInfo);
                    var results = invokeCmd.Run(false);
                    Assert.IsTrue(customDataContent == results.First().BaseObject as string);
                }, "Access is denied", 10, 30);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")] 
        public void NewAzureVMWithLinuxAndCustomData()
        {
            try
            {
                // Add-AzureProvisioningConfig without NoSSHEndpoint or DisableSSH option
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, false, false, null, null, false, @".\cloudinittest.sh");
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
 
                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));
 
                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(1, endpoints.Count);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            } 
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithLinux()
        {
            try
            {
                // Add-AzureProvisioningConfig without NoSSHEndpoint or DisableSSH option
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));

                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(1, endpoints.Count);
                pass = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithLinuxAndNoSSHEnpointAndDisableSSH()
        {
            try
            {
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), _linuxImageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, true, true);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                Collection<InputEndpointContext> endpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName));

                Console.WriteLine("The number of endpoints: {0}", endpoints.Count);
                foreach (var ep in endpoints)
                {
                    Utilities.PrintContext(ep);
                }
                Assert.AreEqual(0, endpoints.Count);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithLocation()
        {
            string _altLocation = GetAlternateLocation(locationName);

            try
            {
                // New-AzureService
                vmPowershellCmdlets.NewAzureService(_serviceName, locationName);

                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                try
                {
                    vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, _altLocation);
                    Assert.Fail("Should fail, but succeeded!");
                }
                catch (Exception ex)
                {
                    if (ex is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failure is expected.  Continue the tests...");
                    }
                }

                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, locationName);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                var vmReturned = vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName);

                Utilities.PrintContext(vmReturned);
                Assert.AreEqual(_serviceName, vmReturned.ServiceName);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM)")]
        public void NewAzureVMWithAffinityGroup()
        {
            string _affiniyGroupName1 = Utilities.GetUniqueShortName("aff");
            string _affiniyGroupName2 = Utilities.GetUniqueShortName("aff");

            try
            {
                // New-AzureService
                vmPowershellCmdlets.NewAzureAffinityGroup(_affiniyGroupName1, locationName, "location1", "location1");
                vmPowershellCmdlets.NewAzureAffinityGroup(_affiniyGroupName2, locationName, "location2", "location2");
                vmPowershellCmdlets.NewAzureService(_serviceName, "service1", null, _affiniyGroupName1);

                // Add-AzureProvisioningConfig
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                try
                {
                    vmPowershellCmdlets.NewAzureVMWithAG(_serviceName, new[] { vm }, _affiniyGroupName2);
                    Assert.Fail("Should fail, but succeeded!");
                }
                catch (Exception ex)
                {
                    if (ex is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Failure is expected.  Continue the tests...");
                    }
                }

                vmPowershellCmdlets.NewAzureVMWithAG(_serviceName, new[] { vm }, _affiniyGroupName1);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                var vmReturned = vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName);

                Utilities.PrintContext(vmReturned);
                Assert.AreEqual(_serviceName, vmReturned.ServiceName);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "Iaas"), Priority(1), Owner("hylee"), Description("Test the cmdlets(New-AzureVMConfig,Add-AzureProvisioningConfig,New-AzureVM) with a WinRMCert")]
        [Ignore]
        public void NewAzureVMWithWinRMCertificateTest()
        {
            try
            {
                // Add-AzureProvisioningConfig with X509Certificate
                var azureVMConfigInfo = new AzureVMConfigInfo(_vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(username, password, _installedCert);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(_serviceName, new[] { vm }, null);
                Console.WriteLine("New Azure service with name:{0} created successfully.", _serviceName);
                var result = vmPowershellCmdlets.GetAzureVM(_vmName, _serviceName);
                Assert.AreEqual(_installedCert.Thumbprint, result.VM.WinRMCertificate.Thumbprint);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void InstallCertificate(CertificateContext certContext, StoreLocation loc, StoreName name)
        {
            File.WriteAllBytes(CerFileName, Convert.FromBase64String(certContext.Data));
            Utilities.InstallCert(CerFileName, loc, name);
        }

        private void InstallCertificate()
        {
            // Create a certificate
            X509Certificate2 certCreated = Utilities.CreateCertificate(password);
            byte[] certData2 = certCreated.Export(X509ContentType.Cert);
            File.WriteAllBytes(CerFileName, certData2);

            // Install the .cer file to local machine.
            certStoreLocation = StoreLocation.CurrentUser;
            certStoreName = StoreName.My;
            _installedCert = Utilities.InstallCert(CerFileName, certStoreLocation, certStoreName);
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Remove the service
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                CleanupService(_serviceName);
            }

            if(File.Exists(keyPath))
            {
                File.Delete(keyPath);
            }
        }

        public string GetAlternateLocation(string location)
        {
            foreach (var loc in vmPowershellCmdlets.GetAzureLocation())
            {
                if (! loc.Name.Equals(location) && ! loc.DisplayName.Equals(location))
                {
                    return loc.Name;
                }
            }
            return null;
        }
    }
}
