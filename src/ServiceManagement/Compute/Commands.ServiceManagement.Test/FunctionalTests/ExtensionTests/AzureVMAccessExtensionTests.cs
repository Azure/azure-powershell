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
using System.Threading;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ExtensionTests
{
    [TestClass]
    public class AzureVMAccessExtensionTests: ServiceManagementTest
    {
        private string serviceName;
        private string vmName;
        private const string referenceNamePrefix = "Reference";
        private string vmAccessUserName;
        private string vmAccessPassword;
        private string publicConfiguration;
        private string privateConfiguration;
        private string publicConfigPath;
        private string privateConfigPath;
        private string version = "1.0";
        string rdpPath = @".\AzureVM.rdp";
        string dns;
        int port;
        private string referenceName;

        [ClassInitialize]
        public static void Intialize(TestContext context)
        {
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
        }

        [TestInitialize]
        public void TestIntialize()
        {
            pass = false;
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            testStartTime = DateTime.Now;
            GetVmAccessConfiguration();
            referenceName = Utilities.GetUniqueShortName(referenceNamePrefix);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanupService(serviceName);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }

        #region Test cases

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMAccessExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void CreateVMAccessExtensionTest()
        {
            try
            {
                    //Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                    Console.WriteLine("Create a new VM with VM access extension.");
                    var vm = CreateIaaSVMObject(vmName);
                    vm = vmPowershellCmdlets.SetAzureVMAccessExtension(vm, vmAccessUserName, vmAccessPassword, version, null,false);

                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName, true);
                    Console.WriteLine("Created a new VM {0} with VM access extension. Service Name : {1}", vmName, serviceName);

                    ValidateVMAccessExtension(vmName, serviceName, true);

                    Utilities.GetAzureVMAndWaitForReady(serviceName, vmName, 30000, 300000);
                    //Verify that the extension actually work
                    VerifyRDPExtension(vmName, serviceName);

                    //Disbale extesnion
                    DisableExtension(vmName, serviceName);
                    ValidateVMAccessExtension(vmName, serviceName, false);
                    pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureVMAccessExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void UpdateVMAccessExtensionTest()
        {
            try
            {
                //Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                var vm = CreateIaaSVMObject(vmName);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);

                vm = GetAzureVM(vmName, serviceName);
                //Set extension without version
                vm = vmPowershellCmdlets.SetAzureVMAccessExtension(vm, vmAccessUserName, vmAccessPassword, null, null, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);

                ValidateVMAccessExtension(vmName, serviceName, true);

                vmPowershellCmdlets.RemoveAzureVMAccessExtension(GetAzureVM(vmName, serviceName));
                    
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMAccessExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AddRoleVMAccessExtensionTest()
        {
            try
            {
                //Create an deployment
                var vm1 = CreateIaaSVMObject(vmName);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1 }, locationName);
                
                //Add a role with extension enabled.
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm2 = CreateIaaSVMObject(vmName2);
                vm2 = vmPowershellCmdlets.SetAzureVMAccessExtension(vm2, vmAccessUserName,vmAccessPassword, version, referenceName,false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm2 });

                ValidateVMAccessExtension(vmName2, serviceName, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMAccessExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void UpdateRoleVMAccessExtensionTest()
        {
            try
            {
                //Create an deployment and add 2 roles
                var vm1 = CreateIaaSVMObject(vmName);
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm2 = CreateIaaSVMObject(vmName2);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1, vm2 }, locationName);

                //Set VM Access extension to the VM
                var vmroleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName);
                vmPowershellCmdlets.SetAzureVMAccessExtension(vm2, vmAccessUserName, vmAccessPassword, version, referenceName, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName2, serviceName, vm2);

                var result = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName);
                Console.WriteLine("Role Instance  Status:{0} of VM {1}", result.InstanceStatus, vmName2);

                ValidateVMAccessExtension(vmName2, serviceName, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }
        #endregion Test cases

        #region Helper Methods

        private void GetVmAccessConfiguration()
        {
            privateConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "PrivateConfig.xml");
            publicConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "PublicConfig.xml");
            privateConfiguration = FileUtilities.DataStore.ReadFileAsText(privateConfigPath);
            publicConfiguration = FileUtilities.DataStore.ReadFileAsText(publicConfigPath);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicConfiguration);
            vmAccessUserName = doc.GetElementsByTagName("UserName")[0].InnerText;
            doc.LoadXml(privateConfiguration);
            vmAccessPassword = doc.GetElementsByTagName("Password")[0].InnerText;
        }

        private PersistentVM CreateIaaSVMObject(string vmName)
        {
            //Create an IaaS VM with a static CA.
            var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(ConfigDataInfo.OS.Windows, username, password);
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            return vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
        }

        private VirtualMachineAccessExtensionContext GetAzureVMAccessExtesnion(string vmName, string serviceName)
        {
            Console.WriteLine("Get Azure VM's extension");
            var vmExtension = vmPowershellCmdlets.GetAzureVMAccessExtension(GetAzureVM(vmName, serviceName));
            Utilities.PrintContext(vmExtension[0]);
            Console.WriteLine("Azure VM's extension info retrieved successfully.");
            return vmExtension[0];
        }

        private void ValidateVMAccessExtension(string vmName, string serviceName, bool enabled)
        {
            var vmAccessExtension = GetAzureVMAccessExtesnion(vmName,serviceName);
            Utilities.PrintContext(vmAccessExtension);
            Console.WriteLine("Verifying the enabled extension");
            if (enabled)
            {
                Assert.AreEqual(vmAccessUserName, vmAccessExtension.UserName, "Incorrect User name");
                Assert.AreEqual("Enable", vmAccessExtension.State, "State is not Enable");
                Assert.IsTrue(vmAccessExtension.Enabled, "Enabled is not true");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(vmAccessExtension.PublicConfiguration);
                Assert.AreEqual(vmAccessUserName, doc.GetElementsByTagName("UserName")[0].InnerText,"Incorrect User name in public configuration");
            }
            else
            {
                Assert.IsTrue(string.IsNullOrEmpty(vmAccessExtension.UserName), "Username is not empty");
                Assert.AreEqual("Disable", vmAccessExtension.State, "State is not Disable");
                Assert.IsFalse(vmAccessExtension.Enabled, "Enabled is not False");
            }
            if (vmAccessExtension.Password != null)
            {
                Assert.IsTrue(string.IsNullOrEmpty(vmAccessExtension.Password.ConvertToUnsecureString()), "Password should be null or empty");
            }
            if (vmAccessExtension.PrivateConfiguration != null)
            {
                Assert.IsTrue(string.IsNullOrEmpty(vmAccessExtension.PrivateConfiguration.ConvertToUnsecureString()), "PrivateConfiguration should be null or empty.");
            }
            Console.WriteLine("Verifed the enabled extension successfully.");
        }

        private PersistentVM GetAzureVM(string vmName, string serviceName)
        {
            Console.WriteLine("Fetch Azure VM details");
            var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
            Console.WriteLine("Azure VM details retreived successfully");
            return vmRoleContext.VM;
        }

        private void VerifyRDPExtension(string vmName, string serviceName)
        {
            Console.WriteLine("Fetching Azure VM RDP file");
            vmPowershellCmdlets.GetAzureRemoteDesktopFile(vmName, serviceName, rdpPath, false);
            using (StreamReader stream = new StreamReader(rdpPath))
            {
                string firstLine = stream.ReadLine();
                var dnsAndport = Utilities.FindSubstring(firstLine, ':', 2).Split(new char[] { ':' });
                dns = dnsAndport[0];
                port = int.Parse(dnsAndport[1]);
            }
            Console.WriteLine("Azure VM RDP file downloaded.");

            Console.WriteLine("Waiting to sleep for 4 mins before trying to login VM ");
            Thread.Sleep(300000);
            ValidateLogin(dns, port, vmAccessUserName, vmAccessPassword);

        }

        private void DisableExtension(string vmName, string serviceName)
        {
            var vm = GetAzureVM(vmName, serviceName);
            Console.WriteLine("Disabling the VM Access extesnion for the vm {0}",vmName);
            vm = vmPowershellCmdlets.SetAzureVMAccessExtension(vm,disable:true);
            vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
            Console.WriteLine("Disabled VM Access extesnion for the vm {0}", vmName);
        }


        private void ValidateLogin(string dns, int port, string vmAccessUserName, string vmAccessPassword)
        {
            Assert.IsTrue((Utilities.RDPtestIaaS(dns, port, vmAccessUserName, vmAccessPassword, true)), "Cannot RDP to the instance!!");
        }

        #endregion Helper Methods
    }
}
