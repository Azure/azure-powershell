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
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extesnions.CustomScript;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ExtensionTests
{
    [TestClass]
    public class CustomScriptExtesnionTests: ServiceManagementTest
    {
        string serviceName;
        string vmName;
        string containerName = "scripts";
        private string referenceName;
        private const string ConstCustomScriptExtensionPublisher = "Microsoft.Compute";
        private const string ConstCustomScriptExtensionName = "CustomScriptExtension";
        private VirtualMachineExtensionImageContext customScriptExtension;
        private string[] fileURI;
        private string runFileName = "test2.ps2";
        private string[] fileNames = {"test1.ps1","test2.ps1"};
        private string endpointSuffix = "";

        [TestInitialize]
        public void TestIntialization()
        {
            Utilities.PrintHeader("Test Initialize");
            testStartTime = DateTime.Now;
            pass = false;
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            referenceName = Utilities.GetUniqueShortName("ref");
            GetCustomScriptExtensionVersion();
            fileURI = GetSharedAccessSignatures(fileNames);
            runFileName = fileNames[new Random(0).Next(fileNames.Length - 1)];
            Utilities.PrintFooter("Test Initialize");
        }

        /// <summary>
        /// Deploys a new Azure VM with Custom Script extension and verifies that the script is applied and run as expected
        /// </summary>
        #region TestCases
        [TestMethod(), Priority(0), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVM,New-AzureVMConfig,Set/Get/Remove-AzureVMCustomScriptExtension)")]
        public void NewAzureVMwithCustomScriptExtesnionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm = CreateIaaSVMWithCustomScriptExtesnion(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetNameWithOutDefaultParameters,
                    vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetNameWithOutDefaultParameters);
                vm = SetCustomScripExtesnionToVM(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetNameWithOutDefaultParameters, Utilities.GetAzureVM(vmName, serviceName));
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetNameWithOutDefaultParameters);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVM,New-AzureVMConfig,Set/Get/Remove-AzureVMCustomScriptExtension)")]
        public void NewAzureVMwithCustomScriptExtesnionUsingFileURiTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm = CreateIaaSVMWithCustomScriptExtesnion(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetName,
                    vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetName);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        [TestMethod(), Priority(0), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVM,New-AzureVMConfig,Set/Get/Remove-AzureVMCustomScriptExtension)")]
        public void SetCustomScriptExtesnionToExistingVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                vm = Utilities.GetAzureVM(vmName, serviceName);
                vm = SetCustomScripExtesnionToVM(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetName, vm);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                vm = Utilities.GetAzureVM(vmName, serviceName);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetName);
                vm = SetCustomScripExtesnionToVM(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName, vm);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVM,New-AzureVMConfig,Set/Get/Remove-AzureVMCustomScriptExtension)")]
        public void SetCustomScriptExtesnionUsingFileURIToExistingVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small,imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                vm = Utilities.GetAzureVM(vmName, serviceName);
                vm = SetCustomScripExtesnionToVM(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetNameWithOutDefaultParameters, vm);
                vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                vm = Utilities.GetAzureVM(vmName, serviceName);
                VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetNameWithOutDefaultParameters);
                vmPowershellCmdlets.RemoveAzureVMCustomScriptExtension(vm);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        [TestMethod(), Priority(0), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Owner("hylee"),
        Description("Test the cmdlets (New-AzureVM,New-AzureVMConfig,Set/Get/Remove-AzureVMCustomScriptExtension)")]
        public void NewAzureVMWithEmptyCustomScriptConfigurationTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            try
            {
                vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);
                vm = vmPowershellCmdlets.SetAzureVMExtension(vm,
                    customScriptExtension.ExtensionName, customScriptExtension.Publisher, customScriptExtension.Version,
                    forceUpdate: true);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);

                var vmExtension = vmPowershellCmdlets.GetAzureVMCustomScriptExtension(Utilities.GetAzureVM(vmName, serviceName));
                Assert.IsTrue(string.IsNullOrEmpty(vmExtension.PublicConfiguration));
                Assert.IsNull(vmExtension.PrivateConfiguration);
                Assert.AreEqual(customScriptExtension.ExtensionName, vmExtension.ExtensionName);
                Assert.IsTrue(customScriptExtension.Publisher.Equals(vmExtension.Publisher));
                Assert.IsTrue(vmExtension.State.Equals("Enable"));
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        #endregion TestCases

        #region Helper Methods

        private void GetCustomScriptExtensionVersion()
        {
            Utilities.PrintHeader("Listing the available VM extensions");
            var extensionsInfo = vmPowershellCmdlets.GetAzureVMAvailableExtension(ConstCustomScriptExtensionName, ConstCustomScriptExtensionPublisher, true);
            customScriptExtension = extensionsInfo.Where(c => c.Version.Equals("1.1")).FirstOrDefault();

            Match m = Regex.Match(customScriptExtension.Version, @"((\.).*?){2}");
            if (m.Success)
            {
                customScriptExtension.Version = customScriptExtension.Version.Substring(0, m.Groups[2].Captures[1].Index);
            }

            Console.WriteLine("Using CustomScript Extension Version: {0}", customScriptExtension.Version);
            Utilities.PrintFooter("Listing the available VM extensions");
        }

        private PersistentVM CreateIaaSVMWithCustomScriptExtesnion(SetAzureVMCustomScriptExtensionCmdletParmaterSetType scriptParameterSet, string vmName, InstanceSize size, string imageName, bool isWindows, string username, string password)
        {
            Utilities.PrintHeader("Creating a new IaaS VM config with custom script extension.");
            PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, isWindows, username, password);
            vm = SetCustomScripExtesnionToVM(scriptParameterSet, vm);
            Utilities.PrintFooter("Creating a new IaaS VM config with custom script extension");
            return vm;
        }

        private PersistentVM SetCustomScripExtesnionToVM(SetAzureVMCustomScriptExtensionCmdletParmaterSetType type, PersistentVM vm)
        {
            switch (type)
            {
                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetName:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using SetCustomScriptExtensionByUrisParamSetName parameter set including all parameters.");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(
                        vm, fileURI, true, runFileName, referenceName, customScriptExtension.Version, null, true);

                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetNameWithOutDefaultParameters:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using SetCustomScriptExtensionByUrisParamSetName parameter set without optional parameters");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(
                        vm, fileURI, true, runFileName, null, null, null, true);

                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using DisableCustomScriptExtensionParamSetName parameter set including all parameters.");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(
                        vm, true, referenceName, customScriptExtension.Version, true);

                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetNameWithOutDefaultParameters:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using DisableCustomScriptExtensionParamSetName parameter set without optional parameters");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(vm, true, null, null, true);

                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetName:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using SetCustomScriptExtensionByContainerBlobsParamSetName parameter set including all parameters.");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(
                        vm, fileNames, runFileName, storageAccountKey.StorageAccountName, endpointSuffix,
                        containerName, storageAccountKey.Primary, referenceName, customScriptExtension.Version, null, true);

                case SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetNameWithOutDefaultParameters:
                    Console.WriteLine("Calling Set-AzureVMCustomScriptExtension cmdlet using SetCustomScriptExtensionByContainerBlobsParamSetName parameter set without optional parameters");
                    return vmPowershellCmdlets.SetAzureVMCustomScriptExtension(vm, fileNames, runFileName, containerName: containerName);

                default:
                    break;
            }

            return vm;
        }

        /// <summary>
        /// Get shared access for the scrip files in storage
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        private string[] GetSharedAccessSignatures(string[] fileNames)
        {
            List<string> sasUriList = new List<string>();
            foreach(var file in fileNames)
            {
                sasUriList.Add(Utilities.GetSASUri(blobUrlRoot, storageAccountKey.StorageAccountName,
                    storageAccountKey.Primary, containerName, file, new TimeSpan(2,0,0), SharedAccessBlobPermissions.Read));
            }
            return sasUriList.ToArray();
        }

        

        private void VerifyCustomScriptExtensionContext(SetAzureVMCustomScriptExtensionCmdletParmaterSetType type)
        {
            Utilities.PrintHeader("Verifiying Custom Script extesnion config.");
            var customScriptExtensionContext = vmPowershellCmdlets.GetAzureVMCustomScriptExtension(Utilities.GetAzureVM(vmName, serviceName));
            Utilities.PrintContext(customScriptExtensionContext);
            Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.ExtensionName, customScriptExtension.ExtensionName), "Verifiying ExtensionName");
            Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.RoleName, vmName), "Verifiying RoleName"); ;
            Utilities.LogAssert(() => Assert.IsTrue(customScriptExtensionContext.PrivateConfiguration == null ||
                string.IsNullOrEmpty(customScriptExtensionContext.PrivateConfiguration.ConvertToUnsecureString())), "Verifiying PrivateConfiguration"); ;
            Utilities.LogAssert(() => Assert.IsFalse(string.IsNullOrEmpty(customScriptExtensionContext.PublicConfiguration)), "Verifiying ExtensionName"); ;
            Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.Publisher, customScriptExtension.Publisher), "Verifiying PublisherName"); ;
            if(type != SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName 
                && type != SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByContainerBlobsParamSetName
                 && type != SetAzureVMCustomScriptExtensionCmdletParmaterSetType.SetCustomScriptExtensionByUrisParamSetName)
            {
                Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.ReferenceName, "CustomScriptExtension"), "Verifiying ReferenceName");
            }
            else
            {
                Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.ReferenceName, referenceName), "Verifiying ReferenceName");
            }

            if (type == SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName
                || type == SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetNameWithOutDefaultParameters)
            {
                Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.State, "Disable"), "Verifiying State");
            }
            else
            {
                Utilities.LogAssert(() => Assert.AreEqual(customScriptExtensionContext.State, "Enable"), "Verifiying State");
            }

            if (type != SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetName
                && type != SetAzureVMCustomScriptExtensionCmdletParmaterSetType.DisableCustomScriptExtensionParamSetNameWithOutDefaultParameters)
            {
                Utilities.LogAssert(() => Assert.IsTrue(customScriptExtensionContext.Uri != null), "Verifiying Uri");
                Utilities.LogAssert(() => Assert.IsTrue(customScriptExtensionContext.CommandToExecute.Contains(runFileName)), "Verifiying CommandToExecute");
                 
            }
            else
            {
                Utilities.LogAssert(() => Assert.IsTrue(customScriptExtensionContext.Uri == null), "Verifiying Uri");
                //Utilities.LogAssert(() => Assert.IsTrue(string.IsNullOrEmpty(customScriptExtensionContext.CommandToExecute)), "Verifiying CommandToExecute");
            }
            Utilities.PrintFooter("Verifiying Custom Script extesnion config.");
        }

        #endregion Helper Methods
        
        [TestCleanup]
        public void TestCleanUp()
        {
            Utilities.ExecuteAndLog(() => CleanupService(serviceName), "Check if service exists and  cleanup");
        }
    }
}

