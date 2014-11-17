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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class FunctionalTestCommonVM : ServiceManagementTest
    {
        private static string defaultService;
        private static string defaultVm;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            defaultService = Utilities.GetUniqueShortName(serviceNamePrefix);

            defaultVm = Utilities.GetUniqueShortName(vmNamePrefix);
            Assert.IsNull(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService));

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, defaultVm, defaultService, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.", defaultService);
        }

        [TestInitialize]
        public void Initialize()
        {
            pass = false;
            testStartTime = DateTime.Now;
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Remove)-AzureCertificate)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\certificateData.csv", "certificateData#csv", DataAccessMethod.Sequential)]
        public void AzureCertificateTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Certificate files to test
            string cerFileName = Convert.ToString(TestContext.DataRow["cerFileName"]);
            string pfxFileName = Convert.ToString(TestContext.DataRow["pfxFileName"]);
            string password = Convert.ToString(TestContext.DataRow["password"]);
            string thumbprintAlgorithm = Convert.ToString(TestContext.DataRow["algorithm"]);

            // Create a certificate
            X509Certificate2 certCreated = Utilities.CreateCertificate(password);
            byte[] certData = certCreated.Export(X509ContentType.Pfx, password);
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
            cert2.Import(pfxFileName, password, X509KeyStorageFlags.PersistKeySet);
            string cert2data = Convert.ToBase64String(cert2[0].RawData);

            // Certificate3: get it from .cer file.
            X509Certificate2Collection cert3 = new X509Certificate2Collection();
            cert3.Import(cerFileName);
            string cert3data = Convert.ToBase64String(cert3[0].RawData);

            try
            {
                RemoveAllExistingCerts(defaultService);
                Assert.Fail("Cert issue is fixed!");
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("InternalError"))
                {
                    Console.WriteLine("This exception is expected: {0}", e);
                }
                else
                {
                    throw;
                }
            }

            try
            {
                // Add a cert item
                vmPowershellCmdlets.AddAzureCertificate(defaultService, cert1);
                CertificateContext getCert1 = vmPowershellCmdlets.GetAzureCertificate(defaultService).FirstOrDefault(a => a.Thumbprint.Equals(installedCert.Thumbprint));
                Console.WriteLine("Cert is added: {0}", getCert1.Thumbprint);
                Assert.AreEqual(getCert1.Data, cert1data, "Cert is different!!");

                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(defaultService, getCert1.Thumbprint, thumbprintAlgorithm);
                pass = Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, defaultService, getCert1.Thumbprint, thumbprintAlgorithm);

                // Add .pfx file
                vmPowershellCmdlets.AddAzureCertificate(defaultService, pfxFileName, password);
                CertificateContext getCert2 = vmPowershellCmdlets.GetAzureCertificate(defaultService, cert2[0].Thumbprint, thumbprintAlgorithm)[0];
                Console.WriteLine("Cert is added: {0}", cert2[0].Thumbprint);
                Assert.AreEqual(getCert2.Data, cert2data, "Cert is different!!");
                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(defaultService, cert2[0].Thumbprint, thumbprintAlgorithm);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, defaultService, cert2[0].Thumbprint, thumbprintAlgorithm);


                // Add .cer file
                vmPowershellCmdlets.AddAzureCertificate(defaultService, cerFileName);
                CertificateContext getCert3 = vmPowershellCmdlets.GetAzureCertificate(defaultService, cert3[0].Thumbprint, thumbprintAlgorithm)[0];
                Console.WriteLine("Cert is added: {0}", cert3[0].Thumbprint);
                Assert.AreEqual(getCert3.Data, cert3data, "Cert is different!!");
                Thread.Sleep(TimeSpan.FromMinutes(2));
                vmPowershellCmdlets.RemoveAzureCertificate(defaultService, cert3[0].Thumbprint, thumbprintAlgorithm);
                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureCertificate, defaultService, cert3[0].Thumbprint, thumbprintAlgorithm);

                var certs = vmPowershellCmdlets.GetAzureCertificate(defaultService);
                Console.WriteLine("number of certs: {0}", certs.Count);
                Utilities.PrintContext(certs);
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail(e.ToString());
            }
        }

        private void RemoveAllExistingCerts(string serviceName)
        {
            vmPowershellCmdlets.RunPSScript(String.Format("{0} -ServiceName {1} | {2}", Utilities.GetAzureCertificateCmdletName, serviceName, Utilities.RemoveAzureCertificateCmdletName));
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Set,Remove)-AzureDataDisk)")]
        public void AzureDataDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

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

                vmPowershellCmdlets.AddDataDisk(defaultVm, defaultService, new [] {dataDiskInfo1, dataDiskInfo2}); // Add-AzureDataDisk with Get-AzureVM and Update-AzureVm

                Assert.IsTrue(CheckDataDisk(defaultVm, defaultService, dataDiskInfo1, HostCaching.None), "Data disk is not properly added");
                Console.WriteLine("Data disk added correctly.");

                Assert.IsTrue(CheckDataDisk(defaultVm, defaultService, dataDiskInfo2, HostCaching.None), "Data disk is not properly added");
                Console.WriteLine("Data disk added correctly.");

                vmPowershellCmdlets.SetDataDisk(defaultVm, defaultService, HostCaching.ReadOnly, lunSlot1);
                Assert.IsTrue(CheckDataDisk(defaultVm, defaultService, dataDiskInfo1, HostCaching.ReadOnly), "Data disk is not properly changed");
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
                foreach (DataVirtualHardDisk disk in vmPowershellCmdlets.GetAzureDataDisk(defaultVm, defaultService))
                {
                    vmPowershellCmdlets.RemoveDataDisk(defaultVm, defaultService, new[] { disk.Lun }); // Remove-AzureDataDisk
                    RemoveDisk(disk.DiskName, 10);
                }
                Assert.AreEqual(0, vmPowershellCmdlets.GetAzureDataDisk(defaultVm, defaultService).Count, "DataDisk is not removed.");
            }
        }

        private void RemoveDisk(string diskName, int maxTry)
        {
            for (int i = 0; i <= maxTry ; i++)
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

            string testAVSetName = "testAVSet1";

            try
            {
                var vm = vmPowershellCmdlets.SetAzureAvailabilitySet(defaultVm, defaultService, testAVSetName);
                vmPowershellCmdlets.UpdateAzureVM(defaultVm, defaultService, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM, testAVSetName));

                vm = vmPowershellCmdlets.SetAzureAvailabilitySet(defaultVm, defaultService, string.Empty);
                vmPowershellCmdlets.UpdateAzureVM(defaultVm, defaultService, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM, string.Empty));

                vm = vmPowershellCmdlets.SetAzureAvailabilitySet(defaultVm, defaultService, testAVSetName);
                vmPowershellCmdlets.UpdateAzureVM(defaultVm, defaultService, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM, testAVSetName));

                vm = vmPowershellCmdlets.SetAzureAvailabilitySet(defaultVm, defaultService, null);
                vmPowershellCmdlets.UpdateAzureVM(defaultVm, defaultService, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM, testAVSetName));

                vm = vmPowershellCmdlets.RemoveAzureAvailabilitySet(defaultVm, defaultService);
                vmPowershellCmdlets.UpdateAzureVM(defaultVm, defaultService, vm);
                Assert.IsTrue(Verify.AzureAvailabilitySet(vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM, testAVSetName));

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

            try
            {
                PersistentVM vm = vmPowershellCmdlets.GetAzureVM(defaultVm, defaultService).VM;
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

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            CleanupService(defaultService);
        }
    }
}
