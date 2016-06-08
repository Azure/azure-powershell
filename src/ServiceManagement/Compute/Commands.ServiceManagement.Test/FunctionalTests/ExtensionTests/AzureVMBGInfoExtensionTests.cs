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
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ExtensionTests
{
    [TestClass]
    public class AzureVMBGInfoExtensionTests:ServiceManagementTest
    {
        private string serviceName;
        private string vmName;
        private const string referenceNamePrefix = "Reference";
        private string version;
        private string referenceName;
        private const string extensionName = "BGInfo";
        private const string DisabledState = "Disable";
        private const string EnableState = "Enable";

        [ClassInitialize]
        public static void Intialize(TestContext context)
        {
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
        }

        [TestInitialize]
        public void TestIntialize()
        {
            pass = false;
            GetExtesnionInfo();
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            testStartTime = DateTime.Now;
        }

        

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanupService(serviceName);
        }


        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureVMBGInfoExtension)")]
        public void GetAzureVMBGInfoExtensionTest()
        {
            try
            {
                referenceName = Utilities.GetUniqueShortName(referenceNamePrefix);
                //Deploy a new IaaS VM with Extension using Set-AzureVMExtension
                Console.WriteLine("Deploying a new vm with BGIinfo extension.");
                var vm = CreateIaaSVMObject(vmName);
                vm = vmPowershellCmdlets.SetAzureVMBGInfoExtension(vm, version, referenceName, false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("Deployed a vm {0}with BGIinfo extension.", vmName);

                
                var extesnion = GetBGInfo(vmName, serviceName);
                VerifyExtension(extesnion);

                //Disable the extension
                Console.WriteLine("Disable BGIinfo extension and update VM.");
                vm = vmPowershellCmdlets.SetAzureVMBGInfoExtension(vm, version, referenceName, true);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Console.WriteLine("BGIinfo extension disabled");

                extesnion = GetBGInfo(vmName, serviceName);
                VerifyExtension(extesnion,true);

                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                vmPowershellCmdlets.RemoveAzureVMBGInfoExtension(vmRoleContext.VM);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMBGInfoExtension)")]
        public void UpdateVMWithBgInfoExtensionTest()
        {
            try
            {
                /*Iaas VM with GA enabled will have BGInfo extension enabled by default with reference name "BGInfo"
                 * So for this test case referenceName will be the default reference name */
                referenceName = extensionName;
                Console.WriteLine("Deploying a new vm {0}",vmName);
                var vm = CreateIaaSVMObject(vmName);
                vm = vmPowershellCmdlets.SetAzureAvailabilitySet("test", vm);
                vm = vmPowershellCmdlets.RemoveAzureVMExtension(vm, null, null, null, true);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("Deployed vm {0}", vmName);
                GetBGInfo(vmName, serviceName, true);

                Console.WriteLine("Set BGInfo extension and update vm {0}." , vmName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);

                vm = vmPowershellCmdlets.SetAzureVMBGInfoExtension(vmRoleContext.VM, version, referenceName, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Console.WriteLine("BGInfo extension set and updated vm {0}.", vmName);

                var extesnion = GetBGInfo(vmName, serviceName);
                VerifyExtension(extesnion);
                
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMBGInfoExtension)")]
        public void AddRoleWithBgInfoExtensionTest()
        {
            try
            {
                //Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                Console.WriteLine("Deploying a new vm {0}", vmName);
                var vm1 = CreateIaaSVMObject(vmName);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1 }, locationName);

                //Add a role with extension config
                referenceName = Utilities.GetUniqueShortName(referenceNamePrefix);
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("Deploying a new vm {0} with BGIinfo extension", vmName2);
                var vm2 = CreateIaaSVMObject(vmName2);
                vm2 = vmPowershellCmdlets.SetAzureVMBGInfoExtension(vm2, version, referenceName, false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm2 });

                var extesnion = GetBGInfo(vmName2, serviceName);
                VerifyExtension(extesnion);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IAAS"), Priority(0), Owner("hylee"), Description("Test the cmdlet ((Get,Set)-AzureVMBGInfoExtension)")]
        public void UpdateRoleWithBgInfoExtensionTest()
        {
            try
            {
                /*Iaas VM with GA enabled will have BGInfo extension enabled by default with reference name "BGInfo"
                 * So for this test case referenceName will be the default reference name */
                referenceName = extensionName;

                //Deploy a new IaaS VM with Extension using Add-AzureVMExtension
                Console.WriteLine("Deploying a new vm {0}", vmName);
                var vm1 = CreateIaaSVMObject(vmName);

                //Add a role with extension config
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("Deploying a new vm {0}", vmName2);
                var vm2 = CreateIaaSVMObject(vmName2);

                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1,vm2 }, locationName);

                Console.WriteLine("Set BGInfo extension and update vm {0}.", vmName2);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName);
                vm2 = vmPowershellCmdlets.SetAzureVMBGInfoExtension(vm2, version, extensionName, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName2, serviceName, vm2);
                Console.WriteLine("BGInfo extension set and updated vm {0}.", vmName2);

                var extesnion = GetBGInfo(vmName2, serviceName);
                VerifyExtension(extesnion);

                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2,serviceName);
                vmPowershellCmdlets.RemoveAzureVMBGInfoExtension(vmRoleContext.VM);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Sequential),TestProperty("Feature","IAAS"),Priority(0),Owner("hylee"),Description("Verifies that BGInfo extension is applied by default to Azure IaaS VM with GA enabled.")]
        public void BGInfoEnabledForNewAzureVMWithGATest()
        {
            try
            {
                StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
                //Create a new Iaas VM with GA enabled
                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                var customScriptExtenion = vmPowershellCmdlets.GetAzureVMBGInfoExtension(Utilities.GetAzureVM(vmName, serviceName));
                VerifyExtension(customScriptExtenion);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        [TestMethod(), TestCategory(Category.Sequential), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Verifies that BGInfo extension is not applied by default to Azure IaaS VM with GA disabled.")]
        public void BGInfoDisabledForNewAzureVMWithoutGATest()
        {
            try
            {
                StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password,false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Assert.IsNull(vmPowershellCmdlets.GetAzureVMBGInfoExtension(Utilities.GetAzureVM(vmName, serviceName),"BGInfo extension is applied to a VM with GA disabled."));
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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

        private VirtualMachineBGInfoExtensionContext GetBGInfo(string vmName, string serviceName, bool shouldNotExist = false)
        {
            Console.WriteLine("Get BGIinfo extension info.");
            var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
            try
            {
                var extension = vmPowershellCmdlets.GetAzureVMBGInfoExtension(vmRoleContext.VM);
                Utilities.PrintCompleteContext(extension);
                Console.WriteLine("Fetched BGIinfo extension info successfully.");
                return extension;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("BGInfo Extension is not installed in the VM.");
                Console.WriteLine(e);
                if (!shouldNotExist)
                {
                    throw;
                }
                Console.WriteLine("This is expected.");
                return null;
            }
        }

        private void VerifyExtension(VirtualMachineBGInfoExtensionContext extension,bool disable=false)
        {
            Console.WriteLine("Verifying BGIinfo extension info.");
            Assert.AreEqual(version, extension.Version);
            Assert.AreEqual(string.IsNullOrEmpty(referenceName) ? extensionName : referenceName, extension.ReferenceName);
            if (disable)
            {
                Assert.AreEqual(DisabledState, extension.State);
            }
            else
            {
                Assert.AreEqual(EnableState, extension.State);
            }
            Console.WriteLine("BGIinfo extension verified successfully.");
        }


        private void GetExtesnionInfo()
        {
            var extensionInfo = Utilities.GetAzureVMExtenionInfo(extensionName);
            if (extensionInfo != null)
            {
                version = extensionInfo.Version;
            }
        }
        
    }
}
