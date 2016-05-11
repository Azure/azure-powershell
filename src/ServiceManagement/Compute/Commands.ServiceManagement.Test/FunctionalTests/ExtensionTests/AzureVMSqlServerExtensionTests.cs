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
    public class AzureVMSqlServerExtensionTests:ServiceManagementTest
    {
        private string serviceName;
        private string vmName;
        private const string referenceNamePrefix = "Reference";
        private string version;
        private string referenceName;
        private const string extensionName = "SqlIaaSAgent";
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
            GetExtensionInfo();
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            testStartTime = DateTime.Now;
        }

        

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanupService(serviceName);
        }


        [TestMethod(), TestCategory("Scenario"), TestProperty("Feature", "IAAS"), Priority(0), Owner("seths"), Description("Test the cmdlet ((Get,Set,Remove)-AzureVMSqlServerExtension)")]
        public void GetAzureVMSqlServerExtensionTest()
        {
            try
            {
                referenceName = Utilities.GetUniqueShortName(referenceNamePrefix);

                //Deploy a new IaaS VM with Extension using Set-AzureVMSqlServerExtension
                Console.WriteLine("Deploying a new vm with Sql Server extension.");
                var vm = CreateIaaSVMObject(vmName);
                vm = vmPowershellCmdlets.SetAzureVMSqlServerExtension(vm, version, referenceName, false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("Deployed a vm {0}with SQL Server extension.", vmName);

                
                var extension = GetSqlServerVMExtension(vmName, serviceName);
                VerifySqlServerExtension(extension);

                //Disable the extension
                Console.WriteLine("Disable SQL Server extension and update VM.");
                vm = vmPowershellCmdlets.SetAzureVMSqlServerExtension(vm, version, referenceName, true);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Console.WriteLine("Sql Server extension disabled");

                extension = GetSqlServerVMExtension(vmName, serviceName);
                VerifySqlServerExtension(extension,true);

                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                vmPowershellCmdlets.RemoveAzureVMSqlServerExtension(vmRoleContext.VM);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory("Scenario"), TestProperty("Feature", "IAAS"), Priority(0), Owner("seths"), Description("Test the cmdlet ((Get,Set)-AzureVMSqlServerExtension)")]
        public void UpdateVMWithSqlServerExtensionTest()
        {
            try
            {
                referenceName = extensionName;
                Console.WriteLine("Deploying a new vm {0}",vmName);
                var vm = CreateIaaSVMObject(vmName);
                vm = vmPowershellCmdlets.SetAzureAvailabilitySet("test", vm);
                vm = vmPowershellCmdlets.RemoveAzureVMExtension(vm, null, null, null, true);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("Deployed vm {0}", vmName);
                GetSqlServerVMExtension(vmName, serviceName, true);

                Console.WriteLine("Set SqlServer extension and update vm {0}." , vmName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);

                vm = vmPowershellCmdlets.SetAzureVMSqlServerExtension(vmRoleContext.VM, version, referenceName, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                Console.WriteLine("SqlServer extension set and updated vm {0}.", vmName);

                var extension = GetSqlServerVMExtension(vmName, serviceName);
                VerifySqlServerExtension(extension);
                
                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        [TestMethod(), TestCategory("Scenario"), TestProperty("Feature", "IAAS"), Priority(0), Owner("seths"), Description("Test the cmdlet ((Get,Set)-AzureVMSqlServerExtension)")]
        public void AddRoleWithSqlServerExtensionTest()
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
                Console.WriteLine("Deploying a new vm {0} with SQL Server extension", vmName2);
                var vm2 = CreateIaaSVMObject(vmName2);
                vm2 = vmPowershellCmdlets.SetAzureVMSqlServerExtension(vm2, version, referenceName, false);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm2 });

                var extension = GetSqlServerVMExtension(vmName2, serviceName);
                VerifySqlServerExtension(extension);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        [TestMethod(), TestCategory("Scenario"), TestProperty("Feature", "IAAS"), Priority(0), Owner("seths"), Description("Test the cmdlet ((Get,Set)-AzureVMSqlServerExtension)")]
        public void UpdateRoleWithSqlServerExtensionTest()
        {
            try
            {
                referenceName = extensionName;

                //Deploy a new IaaS VM 
                Console.WriteLine("Deploying a new vm {0}", vmName);
                var vm1 = CreateIaaSVMObject(vmName);

                //Add a role with extension config
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("Deploying a new vm {0}", vmName2);
                var vm2 = CreateIaaSVMObject(vmName2);

                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1,vm2 }, locationName);

                Console.WriteLine("Set SqlServer extension and update vm {0}.", vmName2);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName);
                vm2 = vmPowershellCmdlets.SetAzureVMSqlServerExtension(vm2, version, extensionName, false);
                vmPowershellCmdlets.UpdateAzureVM(vmName2, serviceName, vm2);
                Console.WriteLine("SqlServer extension set and updated vm {0}.", vmName2);

                var extension = GetSqlServerVMExtension(vmName2, serviceName);
                VerifySqlServerExtension(extension);

                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2,serviceName);
                vmPowershellCmdlets.RemoveAzureVMSqlServerExtension(vmRoleContext.VM);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private PersistentVM CreateIaaSVMObject(string vmName)
        {
            defaultAzureSubscription = vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionId, CredentialHelper.DefaultStorageName);
            vmPowershellCmdlets.SelectAzureSubscription(defaultAzureSubscription.SubscriptionId);


            //Create an IaaS VM with a static CA.
            var azureVMConfigInfo = new AzureVMConfigInfo(vmName, InstanceSize.Small.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            return vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
        }

        private VirtualMachineSqlServerExtensionContext GetSqlServerVMExtension(string vmName, 
            string serviceName, 
            bool shouldNotExist = false)
        {
            Console.WriteLine("Get Sql Server extension info.");
            var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
            try
            {
                var extension = vmPowershellCmdlets.GetAzureVMSqlServerExtension(vmRoleContext.VM);
                Utilities.PrintCompleteContext(extension);
                Console.WriteLine("Fetched SqlServer extension info successfully.");
                return extension;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("SqlServer Extension is not installed in the VM.");
                Console.WriteLine(e);
                if (!shouldNotExist)
                {
                    throw;
                }
                Console.WriteLine("This is expected.");
                return null;
            }
        }

        private void VerifySqlServerExtension(VirtualMachineSqlServerExtensionContext extension,bool disable=false)
        {
            Console.WriteLine("Verifying Sql Server extension info.");
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
            Console.WriteLine("Sql Server extension verified successfully.");
        }


        private void GetExtensionInfo()
        {
            var extensionInfo = Utilities.GetAzureVMExtenionInfo(extensionName);
            if (extensionInfo != null)
            {
                version = extensionInfo.Version;
            }
        }
        
    }
}
