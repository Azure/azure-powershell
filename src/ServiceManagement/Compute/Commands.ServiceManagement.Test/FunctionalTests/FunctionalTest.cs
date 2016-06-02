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
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml;
using Hyak.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class FunctionalTest : ServiceManagementTest
    {
        private string serviceName;
        private string vmName;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            pass = false;
            testStartTime = DateTime.Now;
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Cleanup
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                Console.WriteLine("Starting to clean up created VM and service...");
                CleanupService(serviceName);
            }
        }

        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get-AzureStorageAccount)")]
        [Ignore]
        public void ScriptTestSample()
        {
            vmPowershellCmdlets.RunPSScript("Get-Help Save-AzureVhd -full");
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Remove)-AzureCertificate)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\certificateData.csv", "certificateData#csv", DataAccessMethod.Sequential)]
        public void AzureCertificateTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.  VM: {1} is created.", serviceName, vmName);

            // Certificate files to test
            string cerFileName = Convert.ToString(TestContext.DataRow["cerFileName"]);
            string pfxFileName = Convert.ToString(TestContext.DataRow["pfxFileName"]);
            string psswrd = Convert.ToString(TestContext.DataRow["password"]);
            string thumbprintAlgorithm = Convert.ToString(TestContext.DataRow["algorithm"]);

            // Create a certificate
            X509Certificate2 certCreated = Utilities.CreateCertificate(psswrd);
            byte[] certData = certCreated.Export(X509ContentType.Pfx, psswrd);
            File.WriteAllBytes(pfxFileName, certData);
            byte[] certData2 = certCreated.Export(X509ContentType.Cert);
            File.WriteAllBytes(cerFileName, certData2);

            // Install the .cer file to local machine.
            StoreLocation certStoreLocation = StoreLocation.CurrentUser;
            StoreName certStoreName = StoreName.My;
            X509Certificate2 installedCert = Utilities.InstallCert(cerFileName, certStoreLocation, certStoreName);

            // Certificate1: get it from the installed certificate.
            PSObject cert1 = vmPowershellCmdlets.RunPSScript(
                String.Format("Get-Item cert:\\{0}\\{1}\\{2}", certStoreLocation.ToString(), certStoreName.ToString(), installedCert.Thumbprint))[0];
            string cert1data = Convert.ToBase64String(((X509Certificate2)cert1.BaseObject).RawData);

            // Certificate2: get it from .pfx file.
            X509Certificate2Collection cert2 = new X509Certificate2Collection();
            cert2.Import(pfxFileName, psswrd, X509KeyStorageFlags.PersistKeySet);
            string cert2data = Convert.ToBase64String(cert2[0].RawData);

            // Certificate3: get it from .cer file.
            X509Certificate2Collection cert3 = new X509Certificate2Collection();
            cert3.Import(cerFileName);
            string cert3data = Convert.ToBase64String(cert3[0].RawData);

            try
            {
                // Add a cert item
                vmPowershellCmdlets.AddAzureCertificate(serviceName, cert1);
                CertificateContext getCert1 = vmPowershellCmdlets.GetAzureCertificate(serviceName).FirstOrDefault(a => a.Thumbprint.Equals(installedCert.Thumbprint));
                Console.WriteLine("Cert is added: {0}", getCert1.Thumbprint);
                Assert.AreEqual(getCert1.Data, cert1data, "Cert is different!!");

                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(serviceName, getCert1.Thumbprint, thumbprintAlgorithm);
                pass = Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, serviceName, getCert1.Thumbprint, thumbprintAlgorithm);

                // Add .pfx file
                vmPowershellCmdlets.AddAzureCertificate(serviceName, pfxFileName, psswrd);
                CertificateContext getCert2 = vmPowershellCmdlets.GetAzureCertificate(serviceName, cert2[0].Thumbprint, thumbprintAlgorithm)[0];
                Console.WriteLine("Cert is added: {0}", cert2[0].Thumbprint);
                Assert.AreEqual(getCert2.Data, cert2data, "Cert is different!!");
                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(serviceName, cert2[0].Thumbprint, thumbprintAlgorithm);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, serviceName, cert2[0].Thumbprint, thumbprintAlgorithm);

                // Add .cer file
                vmPowershellCmdlets.AddAzureCertificate(serviceName, cerFileName);
                CertificateContext getCert3 = vmPowershellCmdlets.GetAzureCertificate(serviceName, cert3[0].Thumbprint, thumbprintAlgorithm)[0];
                Console.WriteLine("Cert is added: {0}", cert3[0].Thumbprint);
                Assert.AreEqual(getCert3.Data, cert3data, "Cert is different!!");
                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(serviceName, cert3[0].Thumbprint, thumbprintAlgorithm);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, serviceName, cert3[0].Thumbprint, thumbprintAlgorithm);

                var certs = vmPowershellCmdlets.GetAzureCertificate(serviceName);
                Console.WriteLine("number of certs: {0}", certs.Count);
                Utilities.PrintContext(certs);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Set,Remove)-AzureDataDisk)")]
        public void AzureDataDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.  VM: {1} is created.", serviceName, vmName);

            string diskLabel1 = "disk1";
            int diskSize1 = 30;
            int lunSlot1 = 0;

            string diskLabel2 = "disk2";
            int diskSize2 = 50;
            int lunSlot2 = 2;


            try
            {
                AddAzureDataDiskConfig dataDiskInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, diskLabel1, lunSlot1);
                AddAzureDataDiskConfig dataDiskInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize2, diskLabel2, lunSlot2);

                vmPowershellCmdlets.AddDataDisk(vmName, serviceName, new[] { dataDiskInfo1, dataDiskInfo2 }); // Add-AzureDataDisk with Get-AzureVM and Update-AzureVm

                Assert.IsTrue(CheckDataDisk(vmName, serviceName, dataDiskInfo1, HostCaching.None), "Data disk is not properly added");
                Console.WriteLine("Data disk added correctly.");

                Assert.IsTrue(CheckDataDisk(vmName, serviceName, dataDiskInfo2, HostCaching.None), "Data disk is not properly added");
                Console.WriteLine("Data disk added correctly.");

                vmPowershellCmdlets.SetDataDisk(vmName, serviceName, HostCaching.ReadOnly, lunSlot1);
                Assert.IsTrue(CheckDataDisk(vmName, serviceName, dataDiskInfo1, HostCaching.ReadOnly), "Data disk is not properly changed");
                Console.WriteLine("Data disk is changed correctly.");

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                // Remove DataDisks created
                foreach (DataVirtualHardDisk disk in vmPowershellCmdlets.GetAzureDataDisk(vmName, serviceName))
                {
                    vmPowershellCmdlets.RemoveDataDisk(vmName, serviceName, new[] { disk.Lun }); // Remove-AzureDataDisk
                    RemoveDisk(disk.DiskName, 10);
                }
                Assert.AreEqual(0, vmPowershellCmdlets.GetAzureDataDisk(vmName, serviceName).Count, "DataDisk is not removed.");
            }
        }

        private void RemoveDisk(string diskName, int maxTry)
        {
            for (int i = 0; i <= maxTry; i++)
            {
                try
                {
                    vmPowershellCmdlets.RemoveAzureDisk(diskName, false);
                    break;
                }
                catch (Exception e)
                {
                    if (i == maxTry)
                    {
                        Console.WriteLine("Max try reached.  Couldn't delete the Virtual disk");
                    }
                    if (e.ToString().Contains("currently in use"))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                        continue;
                    }
                }
            }
        }

        private bool CheckDataDisk(string vmName, string serviceName, AddAzureDataDiskConfig dataDiskInfo, HostCaching hc)
        {
            bool found = false;
            foreach (DataVirtualHardDisk disk in vmPowershellCmdlets.GetAzureDataDisk(vmName, serviceName))
            {
                Console.WriteLine("DataDisk - Name:{0}, Label:{1}, Size:{2}, LUN:{3}, HostCaching: {4}", disk.DiskName, disk.DiskLabel, disk.LogicalDiskSizeInGB, disk.Lun, disk.HostCaching);
                if (disk.DiskLabel == dataDiskInfo.DiskLabel && disk.LogicalDiskSizeInGB == dataDiskInfo.DiskSizeGB && disk.Lun == dataDiskInfo.LunSlot)
                {
                    if (disk.HostCaching == hc.ToString())
                    {
                        found = true;
                        Console.WriteLine("DataDisk found: {0}", disk.DiskLabel);
                    }
                }
            }
            return found;
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet Set-AzureAvailabilitySet)")]
        public void AzureAvailabilitySetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.  VM: {1} is created.", serviceName, vmName);

            string testAVSetName = "testAVSet1";

            try
            {
                var vm = vmPowershellCmdlets.SetAzureAvailabilitySet(vmName, serviceName, testAVSetName);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(vmName, serviceName).VM, testAVSetName));

                vm = vmPowershellCmdlets.SetAzureAvailabilitySet(vmName, serviceName, null);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(vmName, serviceName).VM, testAVSetName));

                vm = vmPowershellCmdlets.RemoveAzureAvailabilitySet(vmName, serviceName);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(vmName, serviceName).VM, null));

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureOSDisk)")]
        public void AzureOSDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.  VM: {1} is created.", serviceName, vmName);

            try
            {
                PersistentVM vm = vmPowershellCmdlets.GetAzureVM(vmName, serviceName).VM;
                Assert.IsTrue(Verify.AzureOsDisk(vm, "Windows", HostCaching.ReadWrite));

                PersistentVM vm2 = vmPowershellCmdlets.SetAzureOSDisk(HostCaching.ReadOnly, vm);
                Assert.IsTrue(Verify.AzureOsDisk(vm2, "Windows", HostCaching.ReadOnly));

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }


        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get,Set,Remove)-AzureAffinityGroup)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\affinityGroupData.csv", "affinityGroupData#csv", DataAccessMethod.Sequential)]
        public void AzureAffinityGroupTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string affinityName1 = Convert.ToString(TestContext.DataRow["affinityName1"]);
            string affinityLabel1 = Convert.ToString(TestContext.DataRow["affinityLabel1"]);
            string location1 = CheckLocation(Convert.ToString(TestContext.DataRow["location1"]));
            string description1 = Convert.ToString(TestContext.DataRow["description1"]);

            string affinityName2 = Convert.ToString(TestContext.DataRow["affinityName2"]);
            string affinityLabel2 = Convert.ToString(TestContext.DataRow["affinityLabel2"]);
            string location2 = CheckLocation(Convert.ToString(TestContext.DataRow["location2"]));
            string description2 = Convert.ToString(TestContext.DataRow["description2"]);

            try
            {
                ServiceManagementCmdletTestHelper vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();

                // Remove previously created affinity groups
                foreach (var aff in vmPowershellCmdlets.GetAzureAffinityGroup(null))
                {
                    if (aff.Name == affinityName1 || aff.Name == affinityName2)
                    {
                        vmPowershellCmdlets.RemoveAzureAffinityGroup(aff.Name);
                    }
                }

                // New-AzureAffinityGroup
                vmPowershellCmdlets.NewAzureAffinityGroup(affinityName1, location1, affinityLabel1, description1);
                vmPowershellCmdlets.NewAzureAffinityGroup(affinityName2, location2, affinityLabel2, description2);
                Console.WriteLine("Affinity groups created: {0}, {1}", affinityName1, affinityName2);

                // Get-AzureAffinityGroup

                pass = AffinityGroupVerify(vmPowershellCmdlets.GetAzureAffinityGroup(affinityName1)[0], affinityName1, affinityLabel1, location1, description1);
                pass &= AffinityGroupVerify(vmPowershellCmdlets.GetAzureAffinityGroup(affinityName2)[0], affinityName2, affinityLabel2, location2, description2);


                // Set-AzureAffinityGroup
                vmPowershellCmdlets.SetAzureAffinityGroup(affinityName2, affinityLabel1, description1);
                Console.WriteLine("update affinity group: {0}", affinityName2);

                pass &= AffinityGroupVerify(vmPowershellCmdlets.GetAzureAffinityGroup(affinityName2)[0], affinityName2, affinityLabel1, location2, description1);


                // Remove-AzureAffinityGroup
                vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityName2);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, affinityName2);
                vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityName1);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, affinityName1);

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail(e.ToString());
            }
        }

        private bool AffinityGroupVerify(AffinityGroupContext affContext, string name, string label, string location, string description)
        {
            bool result = true;

            Console.WriteLine("AffinityGroup: Name - {0}, Location - {1}, Label - {2}, Description - {3}", affContext.Name, affContext.Location, affContext.Label, affContext.Description);
            try
            {
                Assert.AreEqual(affContext.Name, name, "Error: Affinity Name is not equal!");
                Assert.AreEqual(affContext.Label, label, "Error: Affinity Label is not equal!");
                Assert.AreEqual(affContext.Location, location, "Error: Affinity Location is not equal!");
                Assert.AreEqual(affContext.Description, description, "Error: Affinity Description is not equal!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = false;
            }
            return result;
        }

        private string CheckLocation(string loc)
        {
            string checkLoc = vmPowershellCmdlets.GetAzureLocationName(new string[] { loc });
            if (string.IsNullOrEmpty(checkLoc))
            {
                foreach (LocationsContext l in vmPowershellCmdlets.GetAzureLocation())
                {
                    if (l.AvailableServices.Contains("Storage"))
                    {
                        return l.Name;
                    }
                }
                return null;
            }
            else
            {
                return checkLoc;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureCertificateSetting)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\certificateData.csv", "certificateData#csv", DataAccessMethod.Sequential)]
        public void AzureCertificateSettingTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Create a certificate
            string cerFileName = Convert.ToString(TestContext.DataRow["cerFileName"]);
            X509Certificate2 certCreated = Utilities.CreateCertificate(password);
            byte[] certData2 = certCreated.Export(X509ContentType.Cert);
            File.WriteAllBytes(cerFileName, certData2);

            // Install the .cer file to local machine.
            StoreLocation certStoreLocation = StoreLocation.CurrentUser;
            StoreName certStoreName = StoreName.My;
            X509Certificate2 installedCert = Utilities.InstallCert(cerFileName, certStoreLocation, certStoreName);

            PSObject certToUpload = vmPowershellCmdlets.RunPSScript(
                String.Format("Get-Item cert:\\{0}\\{1}\\{2}", certStoreLocation.ToString(), certStoreName.ToString(), installedCert.Thumbprint))[0];

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, locationName);
                var certList = new CertificateSettingList();
                certList.Add(vmPowershellCmdlets.NewAzureCertificateSetting(certStoreName.ToString(), installedCert.Thumbprint));

                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, certList, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                // Negative Test:
                //   Try to deploy a VM with a certificate that does not exist in the hosted service.
                //   This should fail.
                try
                {
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm });
                    Assert.Fail(
                        "Should have failed, but it succeeded !!  New-AzureVM should fail if it contains a thumbprint that does not exist in the hosted service.");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    Console.WriteLine("This exception is expected: {0}", e);
                }

                // Now we add the certificate to the hosted service.
                vmPowershellCmdlets.AddAzureCertificate(serviceName, certToUpload);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm });

                PersistentVMRoleContext result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Console.WriteLine("{0} is created", result.Name);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.InnerException);
                throw;
            }
            finally
            {
                Utilities.UninstallCert(installedCert, certStoreLocation, certStoreName);
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get,Set,Remove,Move)-AzureDeployment)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureDeploymentTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);
            string upgradePackageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string upgradeConfigName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            string upgradeConfigName2 = Convert.ToString(TestContext.DataRow["upgradeConfig2"]);

            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);
            var packagePath2 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + upgradePackageName);
            var configPath2 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + upgradeConfigName);
            var configPath3 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + upgradeConfigName2);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(packagePath2.FullName), "file not exist={0}", packagePath2);
            Assert.IsTrue(File.Exists(configPath1.FullName), "file not exist={0}", configPath1);
            Assert.IsTrue(File.Exists(configPath2.FullName), "file not exist={0}", configPath2);
            Assert.IsTrue(File.Exists(configPath3.FullName), "file not exist={0}", configPath3);

            string deploymentName = "deployment1";
            string deploymentName2 = "deployment2";
            string deploymentLabel = "label1";
            DeploymentInfoContext result;

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            ExtensionConfigurationInput rdpExtCfg = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred);

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", serviceName);

                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, DeploymentSlotType.Staging, deploymentLabel, deploymentName, false, false, rdpExtCfg);
                }, "Windows Azure is currently performing an operation on this hosted service that requires exclusive access.", 10, 30);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Staging, null, 1);
                Console.WriteLine("successfully deployed the package");

                ExtensionContext extResult0 = vmPowershellCmdlets.GetAzureServiceExtension(serviceName, DeploymentSlotType.Staging)[0];
                Utilities.PrintContext(extResult0);

                // Move the deployment from 'Staging' to 'Production'
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.MoveAzureDeployment(serviceName);
                }, "The server encountered an internal error. Please retry the request.", 10, 30);
                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass &= Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 1);
                Console.WriteLine("successfully moved.");

                ExtensionContext extResult1 = vmPowershellCmdlets.GetAzureServiceExtension(serviceName, DeploymentSlotType.Production)[0];
                Utilities.PrintContext(extResult1);

                Assert.IsTrue(string.Equals(extResult0.Id, extResult1.Id));

                // Check until the deployment moving is done, and the staging slot is empty.
                Utilities.RetryActionUntilSuccess(() =>
                {
                    try
                    {
                        result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                        Assert.IsNull(result);
                    }
                    catch (Exception e)
                    {
                        const string errorMessage = "No deployments were found.";
                        Assert.IsTrue(e.ToString().Contains(errorMessage) || (e.InnerException != null && e.InnerException.ToString().Contains(errorMessage)));
                    }
                }, "Assert", 10, 60);
                Console.WriteLine("successfully checked original deployment has been moved away.");

                // Re-create the Staging depoyment with the extension
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath2.FullName, configPath2.FullName, DeploymentSlotType.Staging, deploymentLabel, deploymentName2, false, false, rdpExtCfg);
                }, "Windows Azure is currently performing an operation on this hosted service that requires exclusive access.", 10, 60);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                pass = Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName2, deploymentLabel, DeploymentSlotType.Staging, null, 2);
                Console.WriteLine(string.Format("Successfully re-deployed the package #2 to the {0} slot.", DeploymentSlotType.Staging));

                ExtensionContext extResult2 = vmPowershellCmdlets.GetAzureServiceExtension(serviceName, DeploymentSlotType.Staging)[0];
                Utilities.PrintContext(extResult2);

                // Update the deployment with the extension
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.SetAzureDeploymentConfig(serviceName, DeploymentSlotType.Staging, configPath2.FullName, rdpExtCfg);
                }, "The server encountered an internal error. Please retry the request.", 10, 30);
                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Staging);
                pass &= Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName2, deploymentLabel, DeploymentSlotType.Staging, null, 2);
                Console.WriteLine("successfully updated the deployment #2");

                ExtensionContext extResult3 = vmPowershellCmdlets.GetAzureServiceExtension(serviceName, DeploymentSlotType.Staging)[0];
                Utilities.PrintContext(extResult3);

                Assert.IsTrue(!string.Equals(extResult2.Id, extResult3.Id));

                // Remove the deployment #2
                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Staging, true);

                // Set the deployment #1 status to 'Suspended'
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.SetAzureDeploymentStatus(serviceName, DeploymentSlotType.Production, DeploymentStatus.Suspended);
                }, "The server encountered an internal error. Please retry the request.", 10, 30);
                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass &= Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, DeploymentStatus.Suspended, 1);
                Console.WriteLine("successfully changed the status");

                // Update the deployment #1
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.SetAzureDeploymentConfig(serviceName, DeploymentSlotType.Production, configPath2.FullName);
                }, "The server encountered an internal error. Please retry the request.", 10, 30);
                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass &= Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, deploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully updated the deployment");

                // Upgrade the deployment #1
                DateTime start = DateTime.Now;
                Utilities.RetryActionUntilSuccess(() =>
                {
                    vmPowershellCmdlets.SetAzureDeploymentUpgrade(serviceName, DeploymentSlotType.Production, UpgradeType.Simultaneous, packagePath2.FullName, configPath3.FullName);
                }, "The server encountered an internal error. Please retry the request.", 10, 30);
                TimeSpan duration = DateTime.Now - start;
                Console.WriteLine("Auto upgrade took {0}.", duration);

                result = vmPowershellCmdlets.GetAzureDeployment(serviceName, DeploymentSlotType.Production);
                pass &= Utilities.PrintAndCompareDeployment(result, serviceName, deploymentName, serviceName, DeploymentSlotType.Production, null, 4);
                Console.WriteLine("successfully updated the deployment");

                var date = DateTime.Now.AddMonths(-1);
                // Get Deployment Events by Name
                var events = vmPowershellCmdlets.GetAzureDeploymentEvent(serviceName, deploymentName, date, date.AddHours(1));
                Assert.IsTrue(!events.Any() || events.All(e => e.DeploymentName == deploymentName
                    && !string.IsNullOrEmpty(e.InstanceName) && !string.IsNullOrEmpty(e.RebootReason) && !string.IsNullOrEmpty(e.RoleName)
                    && (!e.RebootStartTime.HasValue || (e.RebootStartTime >= date && e.RebootStartTime <= date.AddHours(1)))));
                // Get Deployment Events by Slot
                events = vmPowershellCmdlets.GetAzureDeploymentEventBySlot(serviceName, DeploymentSlotType.Production, date, date.AddHours(1));
                Assert.IsTrue(!events.Any() || events.All(e => e.DeploymentSlot == DeploymentSlotType.Production
                    && !string.IsNullOrEmpty(e.InstanceName) && !string.IsNullOrEmpty(e.RebootReason) && !string.IsNullOrEmpty(e.RoleName)
                    && (!e.RebootStartTime.HasValue || (e.RebootStartTime >= date && e.RebootStartTime <= date.AddHours(1)))));
                // Get Deployment Events default by Production Slot
                events = vmPowershellCmdlets.GetAzureDeploymentEventBySlot(serviceName, null, date, date.AddHours(1));
                Assert.IsTrue(!events.Any() || events.All(e => e.DeploymentSlot == DeploymentSlotType.Production
                    && !string.IsNullOrEmpty(e.InstanceName) && !string.IsNullOrEmpty(e.RebootReason) && !string.IsNullOrEmpty(e.RoleName)
                    && (!e.RebootStartTime.HasValue || (e.RebootStartTime >= date && e.RebootStartTime <= date.AddHours(1)))));

                try
                {
                    // Negative test for invalid date range
                    events = vmPowershellCmdlets.GetAzureDeploymentEvent(serviceName, deploymentName, date, date.AddHours(-1));
                }
                catch (Exception ex)
                {
                    Func<Exception, string, bool> containMessage = (e, s) => e != null && e.Message != null && e.Message.Contains(s);
                    string msgStr = "The date specified in parameter EndTime is not within the correct range.";
                    Assert.IsTrue(containMessage(ex, msgStr) || (ex.InnerException != null && containMessage(ex.InnerException, msgStr)));
                }

                // Negative test for Get-AzureVM
                var vmRoleList1 = vmPowershellCmdlets.GetAzureVM();
                Assert.IsFalse(vmRoleList1.Any(r => r.DeploymentName == deploymentName));
                var vmRoleList2 = vmPowershellCmdlets.GetAzureVM(serviceName);
                Assert.IsFalse(vmRoleList2.Any(r => r.DeploymentName == deploymentName));

                vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
            finally
            {
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, serviceName, DeploymentSlotType.Production))
                {
                    vmPowershellCmdlets.RemoveAzureDeployment(serviceName, DeploymentSlotType.Production, true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get)-AzureDns)")]
        public void AzureDnsTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            const string dnsName = "OpenDns1";
            const string ipAddress = "208.67.222.222";

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, locationName);

                DnsServer dns = vmPowershellCmdlets.NewAzureDns(dnsName, ipAddress);

                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, null, new[] { dns }, null, null, null, null);

                Assert.IsTrue(Verify.AzureDns(vmPowershellCmdlets.GetAzureDeployment(serviceName).DnsSettings, dns));
                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("derajen"), Description("Test the cmdlet ((Add,Set,Remove)-AzureDns)")]
        public void AzureDnsTest2()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            const string dnsName = "OpenDns1";
            const string ipAddress = "208.67.222.222";
            const string ipAddress2 = "127.0.0.1";

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, locationName);

                // Create a VM
                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm });

                // Add a DNS server
                vmPowershellCmdlets.AddAzureDns(dnsName, ipAddress, serviceName);

                var dnsServer = vmPowershellCmdlets.GetAzureDeployment(serviceName).DnsSettings.DnsServers[0];
                Assert.AreEqual(dnsName, dnsServer.Name);
                Assert.AreEqual(ipAddress, dnsServer.Address);

                // Edit the DNS server 
                vmPowershellCmdlets.SetAzureDns(dnsName, ipAddress2, serviceName);

                dnsServer = vmPowershellCmdlets.GetAzureDeployment(serviceName).DnsSettings.DnsServers[0];
                Assert.AreEqual(dnsName, dnsServer.Name);
                Assert.AreEqual(ipAddress2, dnsServer.Address);

                // Remove the DNS server 
                vmPowershellCmdlets.RemoveAzureDns(dnsName, serviceName, force:true);

                Assert.IsNull(vmPowershellCmdlets.GetAzureDeployment(serviceName).DnsSettings);

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Test to validate creation of multiple network interfaces on a vm
        /// </summary>
        [TestMethod(), TestCategory(Category.Preview), TestProperty("Feature", "IAAS"), Priority(1), Owner("derajen"), Description("Test the cmdlet ((Add,Set,Remove)-AzureNetworkInterfaceConfig)")]
        public void AzureMultiNicTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                var nic1 = "eth1";
                var nic2 = "eth2";

                var nic1Address = "10.0.1.40";
                var nic2Address = "10.0.1.39";

                // Create a VNet
                var vnetConfig = vmPowershellCmdlets.GetAzureVNetConfig(null);
                vmPowershellCmdlets.SetAzureVNetConfig(Directory.GetCurrentDirectory() + "\\VnetconfigWithLocation.netcfg");
                var sites = vmPowershellCmdlets.GetAzureVNetSite(null);
                var subnet = sites[0].Subnets.First().Name;
                var vnetName = sites[0].Name;

                // Create a new service
                vmPowershellCmdlets.NewAzureService(serviceName, locationName);

                // Create the VM
                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Large.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
                vm = (PersistentVM)vmPowershellCmdlets.SetAzureSubnet(vm, new string[] {subnet});

                // AddNetworkInterfaceConfig
                vm = (PersistentVM)vmPowershellCmdlets.AddAzureNetworkInterfaceConfig(nic1, subnet, nic1Address, vm);
                vm = (PersistentVM)vmPowershellCmdlets.AddAzureNetworkInterfaceConfig(nic2, subnet, vm);

                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces.Count, 2);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[0].Name, nic1);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[0].IPConfigurations[0].SubnetName, subnet);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[0].IPConfigurations[0].StaticVirtualNetworkIPAddress, nic1Address);

                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].Name, nic2);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].IPConfigurations[0].SubnetName, subnet);
                Assert.IsNull(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].IPConfigurations[0].StaticVirtualNetworkIPAddress);

                // Verify SetNetworkInterfaceConfig
                vm = (PersistentVM)vmPowershellCmdlets.SetAzureNetworkInterfaceConfig(nic2, subnet, nic2Address, vm);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].Name, nic2);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].IPConfigurations[0].SubnetName, subnet);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[1].IPConfigurations[0].StaticVirtualNetworkIPAddress, nic2Address);

                // Verify RemoveNetworkInterfaceConfig
                vm = (PersistentVM)vmPowershellCmdlets.RemoveAzureNetworkInterfaceConfig(nic2, vm);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces.Count, 1);
                Assert.AreEqual(((NetworkConfigurationSet)vm.ConfigurationSets[1]).NetworkInterfaces[0].Name, nic1);

                // Verify the create vm using NIC
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, vnetName, null, null, null, null, null, null, null, null, null, false );

                // Verify GetNetworkInterfaceConfig
                var getVM = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);

                Assert.AreEqual(getVM.NetworkInterfaces[0].Name, nic1);
                Assert.AreEqual(getVM.NetworkInterfaces[0].IpConfigurations[0].SubnetName, subnet);
                Assert.IsNotNull(getVM.NetworkInterfaces[0].MacAddress);

                var getNic = vmPowershellCmdlets.GetAzureNetworkInterfaceConfig(nic1, getVM);
                Assert.AreEqual(getNic.Name, nic1);
                Assert.AreEqual(getNic.IpConfigurations[0].SubnetName, subnet);
                Assert.IsNotNull(getNic.MacAddress);

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get-AzureLocation)")]
        public void AzureLocationTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                foreach (LocationsContext loc in vmPowershellCmdlets.GetAzureLocation())
                {
                    Console.WriteLine("Location: Name - {0}, DisplayName - {1}", loc.Name, loc.DisplayName);
                }

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get-AzureOSVersion)")]
        public void AzureOSVersionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                foreach (OSVersionsContext osVersions in vmPowershellCmdlets.GetAzureOSVersion())
                {
                    Console.WriteLine("OS Version: Family - {0}, FamilyLabel - {1}, Version - {2}", osVersions.Family, osVersions.FamilyLabel, osVersions.Version);
                }

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }


        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureRole)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureRoleTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the package and config files from local machine
            string packageName = Convert.ToString(TestContext.DataRow["packageName"]);
            string configName = Convert.ToString(TestContext.DataRow["configName"]);
            string upgradePackageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            string upgradeConfigName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);

            var packagePath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + packageName);
            var configPath1 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + configName);

            Assert.IsTrue(File.Exists(packagePath1.FullName), "VHD file not exist={0}", packagePath1);
            Assert.IsTrue(File.Exists(configPath1.FullName), "VHD file not exist={0}", configPath1);

            string deploymentName = "deployment1";
            string deploymentLabel = "label1";
            string slot = DeploymentSlotType.Production;

            //DeploymentInfoContext result;
            string roleName = "";

            try
            {
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);

                vmPowershellCmdlets.NewAzureDeployment(serviceName, packagePath1.FullName, configPath1.FullName, slot, deploymentLabel, deploymentName, false, false);


                foreach (RoleContext role in vmPowershellCmdlets.GetAzureRole(serviceName, slot, null, false))
                {
                    Console.WriteLine("Role: Name - {0}, ServiceName - {1}, DeploymenntID - {2}, InstanceCount - {3}", role.RoleName, role.ServiceName, role.DeploymentID, role.InstanceCount);
                    Assert.AreEqual(serviceName, role.ServiceName);
                    roleName = role.RoleName;
                }

                vmPowershellCmdlets.SetAzureRole(serviceName, slot, roleName, 2);

                foreach (RoleContext role in vmPowershellCmdlets.GetAzureRole(serviceName, slot, null, false))
                {
                    Console.WriteLine("Role: Name - {0}, ServiceName - {1}, DeploymenntID - {2}, InstanceCount - {3}", role.RoleName, role.ServiceName, role.DeploymentID, role.InstanceCount);
                    Assert.AreEqual(serviceName, role.ServiceName);
                    Assert.AreEqual(2, role.InstanceCount);
                }

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceRemoteDesktopConfig)")]
        [Ignore]
        public void AzureServiceDiagnosticsExtensionConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            List<string> defaultRoles = new List<string>(new string[] { "AllRoles" });
            string[] roles = new string[] { "WebRole1", "WorkerRole2" };
            string thumb = "abc";
            string alg = "sha1";

            // Create a certificate
            X509Certificate2 cert = Utilities.CreateCertificate(password);

            string storage = defaultAzureSubscription.CurrentStorageAccountName;
            XmlDocument daConfig = new XmlDocument();
            daConfig.Load(@".\da.xml");

            try
            {
                //// Case 1: No thumbprint, no Certificate
                ExtensionConfigurationInput resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, daConfig);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, daConfig));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, null, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles)));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, daConfig, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), daConfig));

                // Case 2: Thumbprint, no algorithm
                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, null);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, null, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, null, daConfig);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, daConfig, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, null, null, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), null, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, null, daConfig, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), daConfig, thumb));

                // Case 3: Thumbprint and algorithm
                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, alg);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, null, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, alg, daConfig);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, daConfig, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, alg, null, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), null, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, thumb, alg, daConfig, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), daConfig, thumb, alg));

                // Case 4: Certificate
                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, cert);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, null, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, cert, daConfig);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, defaultRoles, daConfig, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, cert, null, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), null, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceDiagnosticsExtensionConfig(storage, cert, daConfig, roles);
                Assert.IsTrue(VerifyExtensionConfigDiag(resultConfig, storage, new List<string>(roles), daConfig, cert.Thumbprint, null, cert));

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        private bool VerifyExtensionConfigDiag(ExtensionConfigurationInput resultConfig, string storage, List<string> roles, XmlDocument wadconfig = null, string thumbprint = null, string algorithm = null, X509Certificate2 cert = null)
        {
            try
            {
                string resultStorageAccount = GetInnerText(resultConfig.PublicConfiguration, "StorageAccount");
                string resultWadCfg = Utilities.GetInnerXml(resultConfig.PublicConfiguration, "WadCfg");
                if (string.IsNullOrWhiteSpace(resultWadCfg))
                {
                    resultWadCfg = null;
                }
                string resultStorageKey = GetInnerValue(resultConfig.PrivateConfiguration, "StorageAccount", "key");

                Console.WriteLine("Type: {0}, StorageAccountName:{1}, StorageKey: {2}, WadCfg: {3}, CertificateThumbprint: {4}, ThumbprintAlgorithm: {5}, X509Certificate: {6}",
                    resultConfig.Type, resultStorageAccount, resultStorageKey, resultWadCfg, resultConfig.CertificateThumbprint, resultConfig.ThumbprintAlgorithm, resultConfig.X509Certificate);

                Assert.AreEqual("PaaSDiagnostics", resultConfig.Type, "Type is not equal!");
                Assert.AreEqual(storage, resultStorageAccount);
                Utilities.CompareWadCfg(resultWadCfg, wadconfig);

                if (string.IsNullOrWhiteSpace(thumbprint))
                {
                    Assert.IsTrue(string.IsNullOrWhiteSpace(resultConfig.CertificateThumbprint));
                }
                else
                {
                    Assert.AreEqual(thumbprint, resultConfig.CertificateThumbprint, "Certificate thumbprint is not equal!");
                }
                if (string.IsNullOrWhiteSpace(algorithm))
                {
                    Assert.IsTrue(string.IsNullOrWhiteSpace(resultConfig.ThumbprintAlgorithm));
                }
                else
                {
                    Assert.AreEqual(algorithm, resultConfig.ThumbprintAlgorithm, "Thumbprint algorithm is not equal!");
                }
                Assert.AreEqual(cert, resultConfig.X509Certificate, "X509Certificate is not equal!");
                if (resultConfig.Roles.Count == 1 && string.IsNullOrEmpty(resultConfig.Roles[0].RoleName))
                {
                    Assert.IsTrue(roles.Contains(resultConfig.Roles[0].RoleType.ToString()));
                }
                else
                {
                    foreach (ExtensionRole role in resultConfig.Roles)
                    {
                        Assert.IsTrue(roles.Contains(role.RoleName));
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceRemoteDesktopConfig)")]
        public void AzureServiceRemoteDesktopExtensionConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            PSCredential cred = new PSCredential(username, Utilities.convertToSecureString(password));
            DateTime exp = DateTime.Now.AddMonths(18);
            DateTime defaultExp = DateTime.Now.AddMonths(12);
            List<string> defaultRoles = new List<string>(new string[] { "AllRoles" });
            string[] roles = new string[] { "WebRole1", "WorkerRole2" };
            string thumb = "abc";
            string alg = "sha1";

            // Create a certificate
            X509Certificate2 cert = Utilities.CreateCertificate(password);

            try
            {
                // Case 1: No thumbprint, no Certificate
                ExtensionConfigurationInput resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, defaultExp));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, exp);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, exp));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, null, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), defaultExp));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, exp, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), exp));

                // Case 2: Thumbprint, no algorithm
                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, null);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, defaultExp, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, null, exp);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, exp, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, null, null, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), defaultExp, thumb));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, null, exp, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), exp, thumb));

                // Case 3: Thumbprint and algorithm
                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, alg);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, defaultExp, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, alg, exp);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, exp, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, alg, null, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), defaultExp, thumb, alg));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, thumb, alg, exp, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), exp, thumb, alg));

                // Case 4: Certificate
                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, cert);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, defaultExp, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, cert, null, exp);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, defaultRoles, exp, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, cert, null, null, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), defaultExp, cert.Thumbprint, null, cert));

                resultConfig = vmPowershellCmdlets.NewAzureServiceRemoteDesktopExtensionConfig(cred, cert, null, exp, roles);
                Assert.IsTrue(VerifyExtensionConfigRDP(resultConfig, username, password, new List<string>(roles), exp, cert.Thumbprint, null, cert));

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        private bool VerifyExtensionConfigRDP(ExtensionConfigurationInput resultConfig, string user, string pass, List<string> roles, DateTime exp, string thumbprint = null, string algorithm = null, X509Certificate2 cert = null)
        {
            try
            {
                string resultUserName = GetInnerText(resultConfig.PublicConfiguration, "UserName");
                string resultPassword = GetInnerText(resultConfig.PrivateConfiguration, "Password");
                string resultExpDate = GetInnerText(resultConfig.PublicConfiguration, "Expiration");

                Console.WriteLine("Type: {0}, UserName:{1}, Password: {2}, ExpirationDate: {3}, CertificateThumbprint: {4}, ThumbprintAlgorithm: {5}, X509Certificate: {6}",
                    resultConfig.Type, resultUserName, resultPassword, resultExpDate, resultConfig.CertificateThumbprint, resultConfig.ThumbprintAlgorithm, resultConfig.X509Certificate);

                Assert.AreEqual(resultConfig.Type, "RDP", "Type is not equal!");
                Assert.AreEqual(resultUserName, user);
                Assert.AreEqual(resultPassword, pass);
                Assert.IsTrue(Utilities.CompareDateTime(exp, resultExpDate));

                if (string.IsNullOrWhiteSpace(thumbprint))
                {
                    Assert.IsTrue(string.IsNullOrWhiteSpace(resultConfig.CertificateThumbprint));
                }
                else
                {
                    Assert.AreEqual(resultConfig.CertificateThumbprint, thumbprint, "Certificate thumbprint is not equal!");
                }

                if (string.IsNullOrWhiteSpace(algorithm))
                {
                    Assert.IsTrue(string.IsNullOrWhiteSpace(resultConfig.ThumbprintAlgorithm));
                }
                else
                {
                    Assert.AreEqual(resultConfig.ThumbprintAlgorithm, algorithm, "Thumbprint algorithm is not equal!");
                }
                Assert.AreEqual(resultConfig.X509Certificate, cert, "X509Certificate is not equal!");
                if (resultConfig.Roles.Count == 1 && string.IsNullOrEmpty(resultConfig.Roles[0].RoleName))
                {
                    Assert.IsTrue(roles.Contains(resultConfig.Roles[0].RoleType.ToString()));
                }
                else
                {
                    foreach (ExtensionRole role in resultConfig.Roles)
                    {
                        Assert.IsTrue(roles.Contains(role.RoleName));
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetInnerText(string xmlString, string tag)
        {
            string removedHeader = xmlString.Substring(xmlString.IndexOf('<', 2));

            byte[] encodedString = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream stream = new MemoryStream(encodedString);
            stream.Flush();
            stream.Position = 0;

            XmlDocument xml = new XmlDocument();
            xml.Load(stream);
            return xml.GetElementsByTagName(tag)[0].InnerText;
        }

        private string GetInnerValue(string xmlString, string tag, string attribute)
        {
            string removedHeader = xmlString.Substring(xmlString.IndexOf('<', 2));

            byte[] encodedString = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream stream = new MemoryStream(encodedString);
            stream.Flush();
            stream.Position = 0;

            XmlDocument xml = new XmlDocument();
            xml.Load(stream);
            return xml.GetElementsByTagName(tag)[0].Attributes[attribute].Value;
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureSubnet)")]
        public void AzureSubnetTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                //vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);

                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);

                string[] subs = { "subnet1", "subnet2", "subnet3" };
                PersistentVM vm = vmPowershellCmdlets.SetAzureSubnet(vmPowershellCmdlets.AddAzureProvisioningConfig(azureProvisioningConfig), subs);

                SubnetNamesCollection subnets = vmPowershellCmdlets.GetAzureSubnet(vm);
                foreach (string subnet in subnets)
                {
                    Console.WriteLine("Subnet: {0}", subnet);
                }
                CollectionAssert.AreEqual(subnets, subs);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get)-AzureStorageKey)")]
        public void AzureStorageKeyTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                StorageServiceKeyOperationContext key1 = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName); // Get-AzureStorageAccountKey
                Console.WriteLine("Primary - {0}", key1.Primary);
                Console.WriteLine("Secondary - {0}", key1.Secondary);

                StorageServiceKeyOperationContext key2 = vmPowershellCmdlets.NewAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName, KeyType.Secondary);
                Console.WriteLine("Primary - {0}", key2.Primary);
                Console.WriteLine("Secondary - {0}", key2.Secondary);

                Assert.AreEqual(key1.Primary, key2.Primary);
                Assert.AreNotEqual(key1.Secondary, key2.Secondary);

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get,Remove)-AzureStorageAccount)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\storageAccountTestData.csv", "storageAccountTestData#csv", DataAccessMethod.Sequential)]
        public void AzureStorageAccountBVTTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string storageAccountPrefix = Convert.ToString(TestContext.DataRow["NamePrefix"]);
            string location = CheckLocation(Convert.ToString(TestContext.DataRow["Location1"]));
            var storageName = Utilities.GetUniqueShortName(storageAccountPrefix);
            var grsAccountType = "Standard_GRS";
            string[] storageStaticProperties = new string[3] { storageName, location, null };

            try
            {
                // New-AzureStorageAccount test for default 'Standard_GRS'
                vmPowershellCmdlets.NewAzureStorageAccount(storageName, location, null, null, null);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName)[0],
                    storageStaticProperties, storageName, null, true, grsAccountType));
                Console.WriteLine("{0} is created", storageName);

                vmPowershellCmdlets.SetAzureStorageAccount(storageName, "test", "test", (string)null);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName)[0],
                    storageStaticProperties, "test", "test", true, grsAccountType));
                Console.WriteLine("{0} is updated", storageName);

                vmPowershellCmdlets.RemoveAzureStorageAccount(storageName);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, storageName), "The storage account was not removed");
                Console.WriteLine("{0} is removed", storageName);

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                Console.WriteLine("Starts cleaning up...");
                // Clean-up storage if it is not removed.
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, storageName))
                {
                    vmPowershellCmdlets.RemoveAzureStorageAccount(storageName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((New,Get,Set,Remove)-AzureStorageAccount)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\storageAccountTestData.csv", "storageAccountTestData#csv", DataAccessMethod.Sequential)]
        public void AzureStorageAccountTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string storageAccountPrefix = Convert.ToString(TestContext.DataRow["NamePrefix"]);
            string locationName1 = CheckLocation(Convert.ToString(TestContext.DataRow["Location1"]));
            string locationName2 = CheckLocation(Convert.ToString(TestContext.DataRow["Location2"]));
            string affinityGroupName = Convert.ToString(TestContext.DataRow["AffinityGroupName"]);

            string[] label = new string[3] {
                Convert.ToString(TestContext.DataRow["Label1"]),
                Convert.ToString(TestContext.DataRow["Label2"]),
                Convert.ToString(TestContext.DataRow["Label3"])};
            string[] description = new string[3] {
                Convert.ToString(TestContext.DataRow["Description1"]),
                Convert.ToString(TestContext.DataRow["Description2"]),
                Convert.ToString(TestContext.DataRow["Description3"])};
            bool?[] geoReplicationSettings = new bool?[3] { true, false, null };

            bool geoReplicationEnabled = true;
            string zrsAccountType = "Standard_ZRS";
            string grsAccountType = "Standard_GRS";
            string[] accountTypes = new string[3] {
                "Standard_LRS",
                "Standard_GRS",
                "Standard_RAGRS"
            };

            string[] storageName = new string[3] {
                Utilities.GetUniqueShortName(storageAccountPrefix),
                Utilities.GetUniqueShortName(storageAccountPrefix),
                Utilities.GetUniqueShortName(storageAccountPrefix)};

            string[][] storageStaticProperties = new string[3][] {
                new string[3] {storageName[0], locationName1, null},
                new string [3] {storageName[1], null, affinityGroupName},
                new string[3] {storageName[2], locationName1, null},};

            try
            {
                // New-AzureStorageAccount test for 'Standard_ZRS'
                var zrsStorageName = Utilities.GetUniqueShortName(storageAccountPrefix);
                string[] zrsStorageStaticProperties = new string[3] { zrsStorageName, locationName1, null };
                vmPowershellCmdlets.NewAzureStorageAccount(zrsStorageName, locationName1, null, null, null, zrsAccountType);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(zrsStorageName)[0],
                    zrsStorageStaticProperties, zrsStorageName, null, null, zrsAccountType));
                Console.WriteLine("{0} is created", zrsStorageName);

                vmPowershellCmdlets.RemoveAzureStorageAccount(zrsStorageName);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, zrsStorageName), "The storage account was not removed");

                // New-AzureStorageAccount test for default 'Standard_GRS'
                vmPowershellCmdlets.NewAzureStorageAccount(storageName[0], locationName1, null, null, null);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[0])[0],
                    storageStaticProperties[0], storageName[0], null, true, grsAccountType));
                Console.WriteLine("{0} is created", storageName[0]);

                if (Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, affinityGroupName))
                {
                    vmPowershellCmdlets.NewAzureAffinityGroup(affinityGroupName, locationName2, label[0], description[0]);
                }

                vmPowershellCmdlets.NewAzureStorageAccount(storageName[1], null, affinityGroupName, null, null);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[1])[0],
                    storageStaticProperties[1], storageName[1], null, true, grsAccountType));
                Console.WriteLine("{0} is created", storageName[1]);

                // Set-AzureStorageAccount & Remove-AzureStorageAccount test
                for (int i = 0; i < 2; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        vmPowershellCmdlets.SetAzureStorageAccount(storageName[i], label[j], null, geoReplicationSettings[j]);
                        if (geoReplicationSettings[j] != null)
                        {
                            geoReplicationEnabled = geoReplicationSettings[j].Value;
                        }
                        Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[i])[0],
                            storageStaticProperties[i], label[j], null, true, grsAccountType));
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        vmPowershellCmdlets.SetAzureStorageAccount(storageName[i], null, description[j], geoReplicationSettings[j]);
                        if (geoReplicationSettings[j] != null)
                        {
                            geoReplicationEnabled = geoReplicationSettings[j].Value;
                        }
                        Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[i])[0],
                            storageStaticProperties[i], label[2], description[j], true, grsAccountType));
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        vmPowershellCmdlets.SetAzureStorageAccount(storageName[i], null, null, geoReplicationSettings[j]);
                        if (geoReplicationSettings[j] != null)
                        {
                            geoReplicationEnabled = geoReplicationSettings[j].Value;
                        }
                        Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[i])[0],
                            storageStaticProperties[i], label[2], description[2], true, grsAccountType));
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        vmPowershellCmdlets.SetAzureStorageAccount(storageName[i], label[j], description[j], geoReplicationSettings[j]);
                        if (geoReplicationSettings[j] != null)
                        {
                            geoReplicationEnabled = geoReplicationSettings[j].Value;
                        }
                        Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[i])[0],
                            storageStaticProperties[i], label[j], description[j], true, grsAccountType));
                    }

                    vmPowershellCmdlets.RemoveAzureStorageAccount(storageName[i]);
                    Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, storageName[i]), "The storage account was not removed");
                }

                vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityGroupName);

                // Test Setting and Updating Account Types
                vmPowershellCmdlets.NewAzureStorageAccount(storageName[2], locationName1, null, null, null, accountTypes[0]);
                Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[2])[0],
                    storageStaticProperties[2], storageName[2], null, accountTypes[0] == grsAccountType ? (bool?)true : null, accountTypes[0]));
                Console.WriteLine("{0} is created", storageName[2]);

                for (int j = 0; j < accountTypes.Length; j++)
                {
                    vmPowershellCmdlets.SetAzureStorageAccount(storageName[2], label[j], null, accountTypes[j]);
                    Assert.IsTrue(StorageAccountVerify(vmPowershellCmdlets.GetAzureStorageAccount(storageName[2])[0],
                        storageStaticProperties[2], label[j], null, accountTypes[j] == grsAccountType ? (bool?)true : null, accountTypes[j]));
                }

                vmPowershellCmdlets.RemoveAzureStorageAccount(storageName[2]);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, storageName[2]), "The storage account was not removed");

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;

                Assert.Fail("Exception occurred: {0}", e);
            }
            finally
            {
                Console.WriteLine("Starts cleaning up...");
                // Clean-up storage if it is not removed.
                foreach (string storage in storageName)
                {

                    if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureStorageAccount, storage))
                    {
                        vmPowershellCmdlets.RemoveAzureStorageAccount(storage);
                    }
                }

                // Clean-up affinity group created.
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, affinityGroupName))
                {
                    vmPowershellCmdlets.RemoveAzureAffinityGroup(affinityGroupName);
                }
            }
        }

        private bool StorageAccountVerify(StorageServicePropertiesOperationContext storageContext,
            string[] staticParameters, string label, string description, bool? geoReplicationEnabled, string accountType)
        {
            string name = staticParameters[0];
            string location = staticParameters[1];
            string affinity = staticParameters[2];

            Console.WriteLine("Name: {0}, Label: {1}, Description: {2}, AffinityGroup: {3}, Location: {4}, AccountType: {5}",
                storageContext.StorageAccountName,
                storageContext.Label,
                storageContext.StorageAccountDescription,
                storageContext.AffinityGroup,
                storageContext.Location,
                storageContext.AccountType);

            try
            {
                Assert.AreEqual(name, storageContext.StorageAccountName, "Error: Storage Account Name is not equal!");
                Assert.AreEqual(label, storageContext.Label, "Error: Storage Account Label is not equal!");
                Assert.AreEqual(description, storageContext.StorageAccountDescription, "Error: Storage Account Description is not equal!");
                Assert.AreEqual(affinity, storageContext.AffinityGroup, "Error: Affinity Group is not equal!");
                Assert.AreEqual(location, storageContext.Location, "Error: Location is not equal!");
                Assert.AreEqual(accountType, storageContext.AccountType, "Error: AccountType is not equal!");
                Console.WriteLine("All contexts are matched!!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Network), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureVNetConfig)")]
        public void AzureVNetConfigTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string affinityGroup = "WestUsAffinityGroup";

            try
            {
                // Test Wide VNet
                string wideVnetConfigFilePathCopy = Directory.GetCurrentDirectory() + "\\VnetconfigWithLocation.netcfg";
                Console.WriteLine("Test wide VNet using the following config:");
                Console.WriteLine(File.ReadAllText(wideVnetConfigFilePathCopy));
                vmPowershellCmdlets.SetAzureVNetConfig(wideVnetConfigFilePathCopy);

                var locations = vmPowershellCmdlets.GetAzureLocation();
                var wideVnetSites = vmPowershellCmdlets.GetAzureVNetSite(null);

                foreach (var re in wideVnetSites)
                {
                    Assert.IsTrue(string.IsNullOrEmpty(re.AffinityGroup));
                    Assert.IsTrue(!string.IsNullOrEmpty(re.Location));
                    Assert.IsTrue(locations.Any(t => string.Equals(t.Name, re.Location, StringComparison.OrdinalIgnoreCase)));
                }
                
                vmPowershellCmdlets.RemoveAzureVNetConfig();

                // Test Narrow VNet
                if (Utilities.CheckRemove(vmPowershellCmdlets.GetAzureAffinityGroup, affinityGroup))
                {
                    vmPowershellCmdlets.NewAzureAffinityGroup(affinityGroup, locationName, null, null);
                }

                vmPowershellCmdlets.SetAzureVNetConfig(vnetConfigFilePath);

                string vnetConfigFilePathCopy = Directory.GetCurrentDirectory() + "\\vnetconfigCopy.netcfg";

                var result = vmPowershellCmdlets.GetAzureVNetConfig(vnetConfigFilePathCopy);
                var streamReader = new StreamReader(vnetConfigFilePathCopy);
                string text = streamReader.ReadToEnd();
                streamReader.Close();
                Assert.AreEqual(text, result[0].XMLConfiguration, string.Format("netcfg does not match!!!\n Original:{0}\n Returned:{1}\n", text, result[0].XMLConfiguration));



                vmPowershellCmdlets.SetAzureVNetConfig(vnetConfigFilePathCopy);

                Collection<VirtualNetworkSiteContext> vnetSites = vmPowershellCmdlets.GetAzureVNetSite(null);

                foreach (var re in vnetSites)
                {
                    Console.WriteLine("VNet Name: {0}", re.Name);
                    Console.WriteLine("ID: {0}", re.Id);
                    Console.WriteLine("Affinity Group: {0}", re.AffinityGroup);
                    Console.WriteLine("Gateway Profile: {0}", re.GatewayProfile);
                    Console.WriteLine("InUse: {0}", re.InUse.ToString());
                    Console.WriteLine("State: {0}", re.State);
                    Console.WriteLine("Label: {0}", re.Label);

                    foreach (var prefix in re.AddressSpacePrefixes)
                    {
                        Console.WriteLine("Address Prefix: {0}", prefix);
                    }

                    foreach (var dns in re.DnsServers)
                    {
                        Console.WriteLine("DNS name: {0}", dns.Name);
                        Console.WriteLine("DNS address: {0}", dns.Address);
                        Assert.AreEqual("open", dns.Name);
                    }
                    Assert.AreEqual(1, re.DnsServers.Count());

                    foreach (var gatewaysite in re.GatewaySites)
                    {
                        Console.WriteLine("Gateway Site Name: {0}", gatewaysite.Name);
                        foreach (var prefix in gatewaysite.AddressSpace.AddressPrefixes)
                        {
                            Console.WriteLine("Gateway Site Address Space Prefix: {0}", prefix);
                        }
                        Console.WriteLine("VPN Gateway Address: {0}", gatewaysite.VpnGatewayAddress);
                        Assert.AreEqual("LocalNet1", gatewaysite.Name);
                    }
                    Assert.AreEqual(1, re.GatewaySites.Count);

                    foreach (var subnet in re.Subnets)
                    {
                        Console.WriteLine("Subnet Name: {0}", subnet.Name);
                        Console.WriteLine("Subnet Address Prefix: {0}", subnet.AddressPrefix);
                    }
                    Console.WriteLine();
                }

                // Remove Vnet config
                vmPowershellCmdlets.RemoveAzureVNetConfig();

                Collection<VirtualNetworkSiteContext> vnetSitesAfter = vmPowershellCmdlets.GetAzureVNetSite(null);

                Assert.AreNotEqual(vnetSites.Count, vnetSitesAfter.Count, "No Vnet is removed");

                foreach (var re in vnetSitesAfter)
                {
                    Console.WriteLine("VNet: {0}", re.Name);
                }

                pass = true;

            }
            catch (Exception e)
            {
                if (e.ToString().Contains("while in use"))
                {
                    Console.WriteLine(e.InnerException.ToString());
                }
                else
                {
                    pass = false;
                    Assert.Fail("Exception occurred: {0}", e.ToString());
                }
            }
        }

        /// <summary>
        /// This test covers negative test on Set-AzurePlatformVMImage cmdlets
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get,Set,Remove)-AzurePlatformVMImage)")]
        public void AzurePlatformVMImageNegativeTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            Func<string, string[]> getScripts = img => new string[]
                {
                    "Import-Module '.\\" + Utilities.AzurePowershellModuleServiceManagementPirModule + "';",
                    "$c1 = New-AzurePlatformComputeImageConfig -Offer test -Sku test -Version test;",
                    "$c2 = New-AzurePlatformMarketplaceImageConfig -PlanName test -Product test -Publisher test -PublisherId test;",
                    "$vmImgLoc = (Get-AzureLocation | where { $_.Name -like '*US*' } | select -ExpandProperty Name)[0];",
                    "Set-AzurePlatformVMImage -ImageName " + img + " -ReplicaLocations $vmImgLoc -ComputeImageConfig $c1 -MarketplaceImageConfig $c2;"
                };

            var imgName = Utilities.GetUniqueShortName("img");

            try
            {
                var scripts = getScripts(imgName);
                vmPowershellCmdlets.RunPSScript(string.Join(System.Environment.NewLine, scripts), true);
            }
            catch (Exception e)
            {
                var expectedMsg = "ResourceNotFound: The image with the specified name does not exist.";
                if (e.InnerException != null && e.InnerException.Message != null && e.InnerException.Message.Contains(expectedMsg))
                {
                    pass = true;
                    Console.WriteLine(e.InnerException.ToString());
                }
                else
                {
                    pass = false;
                    Assert.Fail("Exception occurred: {0}", e.ToString());
                }
            }

            // OS Image
            var osImages = vmPowershellCmdlets.GetAzureVMImage();
            imgName = osImages.First().ImageName;

            try
            {
                var scripts = getScripts(imgName);
                vmPowershellCmdlets.RunPSScript(string.Join(System.Environment.NewLine, scripts), true);
            }
            catch (Exception e)
            {
                var expectedMsg = "ForbiddenError: This operation is not allowed for this subscription.";
                if (e.InnerException != null && e.InnerException.Message != null && e.InnerException.Message.Contains(expectedMsg))
                {
                    pass = true;
                    Console.WriteLine(e.InnerException.ToString());
                }
                else
                {
                    pass = false;
                    Assert.Fail("Exception occurred: {0}", e.ToString());
                }
            }

            // VM Image
            var vmImages = vmPowershellCmdlets.GetAzureVMImageReturningVMImages();
            imgName = vmImages.First().ImageName;

            try
            {
                var scripts = getScripts(imgName);
                vmPowershellCmdlets.RunPSScript(string.Join(System.Environment.NewLine, scripts), true);
            }
            catch (Exception e)
            {
                var expectedMsg = "ForbiddenError: This operation is not allowed for this subscription.";
                if (e.InnerException != null && e.InnerException.Message != null && e.InnerException.Message.Contains(expectedMsg))
                {
                    pass = true;
                    Console.WriteLine(e.InnerException.ToString());
                }
                else
                {
                    pass = false;
                    Assert.Fail("Exception occurred: {0}", e.ToString());
                }
            }
        }
    }
}
