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
using System.Threading;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class GenericIaaSExtensionTests:ServiceManagementTest
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
        private VirtualMachineExtensionImageContext vmAccessExtension;
        private string version = "1.0";
        string rdpPath = @".\AzureVM.rdp";
        private string referenceName;
        string localPath;
        private const string publisher = "Microsoft.Compute";
        private const string VmAccessAgentExtensionName = "VMAccessAgent";

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
            localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, serviceName + ".xml").ToString();
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

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureVMExtensionTest()
        {
            try
            {
                // Get the available VM Extension
                var availableExtensions =  vmPowershellCmdlets.GetAzureVMAvailableExtension();
                vmAccessExtension = availableExtensions.First(extension => extension.ExtensionName.Equals(VmAccessAgentExtensionName));
                if (availableExtensions.Count > 0)
                {
                    // Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                    Console.WriteLine("Create a new VM with VM access extension.");
                    var vm = CreateIaaSVMObject(vmName);
                    vm = vmPowershellCmdlets.SetAzureVMExtension(vm,
                        vmAccessExtension.ExtensionName,
                        vmAccessExtension.Publisher,
                        version,
                        referenceName,
                        publicConfigPath: publicConfigPath,
                        privateConfigPath:privateConfigPath,
                        disable: false,
                        forceUpdate: true);
                    
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] {vm}, locationName);
                    Console.WriteLine("Created a new VM {0} with VM access extension. Service Name : {1}",vmName,serviceName);

                    ValidateVMAccessExtension(vmName, serviceName, true);
                    // Verify that the extension actually work
                    VerifyRDPExtension(vmName, serviceName);

                    // Disbale extesnion
                    DisableExtension(vmName, serviceName);

                    ValidateVMAccessExtension(vmName, serviceName, false);
                    pass = true;
                }
                else
                {
                    Console.WriteLine("There are no Azure VM extension available");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMExtension)")]
        public void UpdateVMWithExtensionTest()
        {
            try
            {
                var availableExtensions = vmPowershellCmdlets.GetAzureVMAvailableExtension();

                if (availableExtensions.Count > 0)
                {
                    vmAccessExtension = availableExtensions.First(extension => extension.ExtensionName.Equals(VmAccessAgentExtensionName));

                    // Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                    var vm = CreateIaaSVMObject(vmName);
                    vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);

                    vm = GetAzureVM(vmName, serviceName);

                    vm = vmPowershellCmdlets.SetAzureVMExtension(vm,
                        vmAccessExtension.ExtensionName,
                        vmAccessExtension.Publisher,
                        version,
                        referenceName,
                        publicConfiguration,
                        privateConfiguration,
                        "pubkey1",
                        "prikey1",
                        forceUpdate: true);
                    vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);

                    var updatedVM = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                    var updatedExt = updatedVM.VM.ResourceExtensionReferences.First(
                        e => e.Name == vmAccessExtension.ExtensionName &&
                             e.Publisher == vmAccessExtension.Publisher &&
                             e.Version == version);
                    Assert.IsTrue(updatedExt.ResourceExtensionParameterValues.Any(r => r.Type == "Public" && r.Key == "pubkey1"));

                    ValidateVMAccessExtension(vmName, serviceName, true);

                    vmPowershellCmdlets.RemoveAzureVMExtension(GetAzureVM(vmName, serviceName), vmAccessExtension.ExtensionName, vmAccessExtension.Publisher);
                    pass = true;
                }
                else
                {
                    Console.WriteLine("There are no Azure VM extension available");
                }
                pass = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMExtension)")]
        public void AddRoleWithExtensionTest()
        {
            try
            {
                var availableExtensions = vmPowershellCmdlets.GetAzureVMAvailableExtension();
                vmAccessExtension = availableExtensions.First(extension => extension.ExtensionName.Equals(VmAccessAgentExtensionName));

                //Create an deployment
                var vm1 = CreateIaaSVMObject(vmName);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1 }, locationName);

                //Add a role with extension enabled.
                string referenceName = Utilities.GetUniqueShortName(referenceNamePrefix);
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm2 = CreateIaaSVMObject(vmName2);
                vm2 = vmPowershellCmdlets.SetAzureVMExtension(vm2,
                    vmAccessExtension.ExtensionName,
                    vmAccessExtension.Publisher,
                    version, referenceName,
                    publicConfiguration,
                    privateConfiguration,
                    disable: false,
                    forceUpdate: true);
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

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMExtension)")]
        public void UpdateRoleWithExtensionTest()
        {
            try
            {
                var availableExtensions = vmPowershellCmdlets.GetAzureVMAvailableExtension();
                var vmAccessExtension = availableExtensions.First(extension => extension.ExtensionName.Equals(VmAccessAgentExtensionName));
                
                var vm1 = CreateIaaSVMObject(vmName);
                
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm2 = CreateIaaSVMObject(vmName2);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1, vm2 }, locationName);
                
                vm2 = GetAzureVM(vmName2, serviceName);
                vm2 = vmPowershellCmdlets.SetAzureVMExtension(vm2,
                    vmAccessExtension.ExtensionName,
                    vmAccessExtension.Publisher,
                    version,
                    referenceName,
                    publicConfiguration,
                    privateConfiguration,
                    disable: false,
                    forceUpdate: true);
                vmPowershellCmdlets.UpdateAzureVM(vmName2, serviceName, vm2);

                ValidateVMAccessExtension(vmName2, serviceName, true);
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet (Get-AzureVMAvailableExtension)")]
        public void GetAzureVMAvailableExtensionTest()
        {
            try
            {
                var availableExtensions = vmPowershellCmdlets.GetAzureVMAvailableExtension();
                foreach (var extension in availableExtensions)
                {
                    ValidateAvailableExtesnion(extension);
                }
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public void ValidateAvailableExtesnion(VirtualMachineExtensionImageContext extension)
        {
            Utilities.PrintContext(extension);
            Assert.IsFalse(string.IsNullOrEmpty(extension.ExtensionName));
            Assert.IsFalse(string.IsNullOrEmpty(extension.Publisher));
            Assert.IsFalse(string.IsNullOrEmpty(extension.Version));

            if (! extension.IsJsonExtension)
            {
                switch (extension.ExtensionName)
                {
                    case "DiagnosticsAgent":
                        {
                            Assert.IsFalse(string.IsNullOrEmpty(extension.PublicConfigurationSchema));
                            break;
                        }
                    case "VMAccessAgent":
                        {
                            Assert.IsFalse(string.IsNullOrEmpty(extension.PublicConfigurationSchema));
                            Assert.IsFalse(string.IsNullOrEmpty(extension.PrivateConfigurationSchema));
                            break;
                        }
                }
            }
        }

        private PersistentVM CreateIaaSVMObject(string vmName)
        {
            //Create an IaaS VM with a static CA.
            var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            return vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
        }

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

        private VirtualMachineExtensionContext GetAzureVMAccessExtesnion(string vmName, string serviceName)
        {
            Console.WriteLine("Get Azure VM's extension");
            var vmExtensions = vmPowershellCmdlets.GetAzureVMExtension(GetAzureVM(vmName, serviceName), VmAccessAgentExtensionName, publisher);
            var vmExtension = vmExtensions !=null ? vmExtensions[0] : null;
            if (vmExtension != null)
            {
                Utilities.PrintContext(vmExtension);
                Console.WriteLine("Azure VM's extension info retrieved successfully.");
            }
            else
            {
                Console.WriteLine("VM Access extesnion is not applied to the VM");
            }
            return vmExtension;
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
            Console.WriteLine("Azure VM RDP file downloaded.");
        }

        private void DisableExtension(string vmName, string serviceName)
        {
            var vm = GetAzureVM(vmName, serviceName);
            Console.WriteLine("Disabling the VM Access extesnion for the vm {0}", vmName);
            vm = vmPowershellCmdlets.SetAzureVMExtension(vm,
                vmAccessExtension.ExtensionName,
                vmAccessExtension.Publisher,
                version,
                referenceName,
                disable: true,
                forceUpdate: true);
            vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
            Console.WriteLine("Disabled VM Access extesnion for the vm {0}", vmName);
        }

        private void ValidateVMAccessExtension(string vmName, string serviceName, bool enabled)
        {
            var vmExtension = GetAzureVMAccessExtesnion(vmName, serviceName);
            Utilities.PrintContext(vmExtension);
            if(enabled)
            {
                Console.WriteLine("Verifying the enabled extension");
                Assert.AreEqual("Enable", vmExtension.State, "State is not Enable");
                //Assert.IsFalse(string.IsNullOrEmpty(vmExtension.PublicConfiguration), "PublicConfiguration is empty.");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(vmExtension.PublicConfiguration);
                XmlDocument inputPublicConfigDoc = new XmlDocument();
                inputPublicConfigDoc.LoadXml(publicConfiguration);
                Assert.AreEqual(inputPublicConfigDoc.GetElementsByTagName("PublicConfig")[0].InnerXml, doc.GetElementsByTagName("PublicConfig")[0].InnerXml);
                Console.WriteLine("Verifed the enabled extension successfully.");
            }
            else
            {
                Console.WriteLine("Verifying the disabled extension");
                Assert.AreEqual("Disable", vmExtension.State, "State is not Disable");
                Console.WriteLine("Verifed the disabled extension successfully.");
            }
            Assert.IsNull(vmExtension.PrivateConfiguration);
        }

    }
}
