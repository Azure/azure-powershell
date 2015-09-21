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
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class VMTemplateTests : ServiceManagementTest
    {
        string serviceName;
        string diskLabel1 = "disk1";
        int diskSize1 = 30;
        int lunSlot1 = 0;
        const string CONSTANT_SPECIALIZED = "Specialized";
        const string CONSTANT_GENERALIZED = "Generalized";
        const string CONSTANT_CATEGORY = "User";
        const string MachineNotReadyState = "VM did not reach one of the Started/Stopped/StoppedDeallocated/Running states.";
        HostCaching cahcing = HostCaching.ReadWrite;
        string vmImageName;

        [TestInitialize]
        public void TestIntialize()
        {
            testStartTime = DateTime.Now;
            pass = false;
            cleanupIfPassed = true;
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
        }

        #region TestCases
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void CaptureSpecializedVMAndDeploy()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string serviceName1 = Utilities.GetUniqueShortName(serviceNamePrefix);
            try
            {
                //      a.	Deploy a new IaaS VM
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0}--------------------------------", vmName);
                var vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0} completed.---------------------", vmName);
                //b.	Stop the VM
                Console.WriteLine("--------------------------------Stopping vm :{0}--------------------------------", vmName);
                vmPowershellCmdlets.StopAzureVM(vmName, serviceName, force: true);
                Console.WriteLine("--------------------------------Stopped vm :{0}--------------------------------", vmName);
                //c.	Save the VM image
                Console.WriteLine("--------------------------------Save the VM image--------------------------------");
                vmImageName = vmName + "Image";
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName, CONSTANT_SPECIALIZED, vmImageName);
                Console.WriteLine("--------------------------------Saved VM image with name {0}----------------------");
                //d.	Verify the VM image by Get-AzureVMImage
                Console.WriteLine("--------------------------------Verify the VM image--------------------------------");
                DataDiskConfigurationList diskConfig = new DataDiskConfigurationList();
                diskConfig.Add(new DataDiskConfiguration() { Lun = lunSlot1, LogicalDiskSizeInGB = diskSize1, HostCaching = cahcing.ToString() });
                VerifyVMImage(vmImageName, OS.Windows, vmImageName, CONSTANT_SPECIALIZED, cahcing, diskConfig);
                Console.WriteLine("--------------------------------Verified that the VM image is saved successfully--------------------------------");
                //e.	Deploy a new IaaS VM with the save VM image
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = Utilities.CreateIaaSVMObject(vmName1, InstanceSize.Small, vmImageName);
                vmPowershellCmdlets.NewAzureVM(serviceName1, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName1, vmImageName);
                //f.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName1, vmImageName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                VerifyVM(vmRoleContext.VM, OS.Windows, HostCaching.ReadWrite, diskSize1, 1);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName1);
                //g.	Add another IaaS VM with the save VM image to the existing service
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName2, serviceName1, vmImageName);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName2, vmImageName);
                //h.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName2, vmImageName);
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName1);
                VerifyVM(vmRoleContext.VM, OS.Windows, HostCaching.ReadWrite, diskSize1, 1);
                Utilities.PrintContext(vmRoleContext);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName2);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                CleanupService(serviceName1);
                //	Delete the VM image
                Console.WriteLine("------------------------------Delete the VM image---------------------------------");
                DeleteVMImageIfExists(vmImageName);
                Console.WriteLine("------------------------------Deleted the VM image---------------------------------");
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void CaptureGeneralizedVMAndDeploy()
        {
            string serviceName1 = Utilities.GetUniqueShortName(serviceNamePrefix);
            try
            {
                //        a.	Deploy a new IaaS VM
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0}--------------------------------", vmName);
                var vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0} completed.---------------------", vmName);
                //b.	RDP to the VM and sysprep

                //c.	Stop the VM
                Console.WriteLine("--------------------------------Stopping vm :{0}--------------------------------", vmName);
                vmPowershellCmdlets.StopAzureVM(vmName, serviceName, force: true);
                Console.WriteLine("--------------------------------Stopped vm :{0}--------------------------------", vmName);
                //d.	Save the VM image
                Console.WriteLine("--------------------------------Save the VM image as Generalized image --------------------------------");
                vmImageName = vmName + "Image";
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName, CONSTANT_GENERALIZED, vmImageName);
                Console.WriteLine("--------------------------------Saved VM image with name {0}----------------------");
                //e.	Verify the VM image by Get-AzureVMImage
                Console.WriteLine("--------------------------------Verify the VM image--------------------------------");
                DataDiskConfigurationList diskConfig = new DataDiskConfigurationList();
                diskConfig.Add(new DataDiskConfiguration() { Lun = lunSlot1, LogicalDiskSizeInGB = diskSize1, HostCaching = cahcing.ToString() });
                VerifyVMImage(vmImageName, OS.Windows, vmImageName, CONSTANT_GENERALIZED, cahcing, diskConfig);
                Console.WriteLine("--------------------------------Verified that the VM image is saved successfully--------------------------------");
                //f.	Deploy a new IaaS VM with the save VM image
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName1, serviceName1, vmImageName, username, password, locationName);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName1, vmImageName);
                //g.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName1, vmImageName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                VerifyVM(vmRoleContext.VM, OS.Windows, HostCaching.ReadWrite, diskSize1, 1);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName1);
                //h.	Add another IaaS VM with the save VM image to the existing service
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = Utilities.CreateIaaSVMObject(vmName2, InstanceSize.Small, vmImageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName1, new[] { vm });
                //i.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName2, vmImageName);
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                VerifyVM(vmRoleContext.VM, OS.Windows, HostCaching.ReadWrite, diskSize1, 1);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName2);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                CleanupService(serviceName1);
                //Delete the VM image
                Console.WriteLine("------------------------------Delete the VM image---------------------------------");
                vmPowershellCmdlets.RemoveAzureVMImage(vmImageName, true);
                Console.WriteLine("------------------------------Deleted the VM image---------------------------------");
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void CaptureSpecializedLinuxVMAndDeploy()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string serviceName1 = Utilities.GetUniqueShortName(serviceNamePrefix);
            string linuxImageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);
            try
            {
                //                a.	Deploy a new IaaS VM
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0}--------------------------------", vmName);
                var vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, linuxImageName, false, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0} completed.---------------------", vmName);
                //b.	Stop the VM
                Console.WriteLine("--------------------------------Stopping vm :{0}--------------------------------", vmName);
                vmPowershellCmdlets.StopAzureVM(vmName, serviceName, force: true);
                Console.WriteLine("--------------------------------Stopped vm :{0}--------------------------------", vmName);
                //c.	Save the VM image
                Console.WriteLine("--------------------------------Save the VM image--------------------------------");
                vmImageName = vmName + "Image";
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName, CONSTANT_SPECIALIZED, vmImageName);
                Console.WriteLine("--------------------------------Saved VM image with name {0}----------------------");
                //d.	Verify the VM image by Get-AzureVMImage
                Console.WriteLine("--------------------------------Verify the VM image--------------------------------");
                DataDiskConfigurationList diskConfig = new DataDiskConfigurationList();
                diskConfig.Add(new DataDiskConfiguration() { Lun = lunSlot1, LogicalDiskSizeInGB = diskSize1, HostCaching = cahcing.ToString() });
                VerifyVMImage(vmImageName, OS.Linux, vmImageName, CONSTANT_SPECIALIZED, cahcing, diskConfig);
                Console.WriteLine("--------------------------------Verified that the VM image is saved successfully--------------------------------");
                //e.	Deploy a new IaaS VM with the save VM image
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vmPowershellCmdlets.NewAzureQuickVM(OS.Linux, vmName1, serviceName1, vmImageName, null, null, locationName);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName1, vmImageName);
                //f.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName1, vmImageName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                VerifyVM(vmRoleContext.VM, OS.Linux, HostCaching.ReadWrite, diskSize1, 1);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName1);
                //g.	Add another IaaS VM with the save VM image to the existing service
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = Utilities.CreateIaaSVMObject(vmName2, InstanceSize.Small, vmImageName);
                vmPowershellCmdlets.NewAzureVM(serviceName1, new[] { vm });
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName2, vmImageName);
                //h.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName2, vmImageName);
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName1);
                VerifyVM(vmRoleContext.VM, OS.Linux, HostCaching.ReadWrite, diskSize1, 1);
                Utilities.PrintContext(vmRoleContext);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName2);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                CleanupService(serviceName1);
                //Delete the VM image
                Console.WriteLine("------------------------------Delete the VM image---------------------------------");
                vmPowershellCmdlets.RemoveAzureVMImage(vmImageName, true);
                Console.WriteLine("------------------------------Deleted the VM image---------------------------------");
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void CaptureGeneralizedLinuxVMAndDeploy()
        {
            string serviceName1 = Utilities.GetUniqueShortName(serviceNamePrefix);
            string linuxImageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);
            try
            {
                //                a.	Deploy a new IaaS VM
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0} completed.---------------------", vmName);
                PersistentVM vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, linuxImageName, false, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deploying a new IaaS VM :{0} completed.---------------------", vmName);
                //b.	Stop the VM
                Console.WriteLine("--------------------------------Stopping vm :{0}--------------------------------", vmName);
                vmPowershellCmdlets.StopAzureVM(vmName, serviceName, force: true);
                Console.WriteLine("--------------------------------Stopped vm :{0}--------------------------------", vmName);
                //c.	Save the VM image
                Console.WriteLine("--------------------------------Save the VM image--------------------------------");
                vmImageName = vmName + "Image";
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName, CONSTANT_GENERALIZED, vmImageName);
                Console.WriteLine("--------------------------------Saved VM image with name {0}----------------------");
                //d.	Verify the VM image by Get-AzureVMImage
                Console.WriteLine("--------------------------------Verify the VM image--------------------------------");
                DataDiskConfigurationList diskConfig = new DataDiskConfigurationList();
                diskConfig.Add(new DataDiskConfiguration() { Lun = lunSlot1, LogicalDiskSizeInGB = diskSize1, HostCaching = cahcing.ToString() });
                VerifyVMImage(vmImageName, OS.Linux, vmImageName, CONSTANT_GENERALIZED, cahcing, diskConfig);
                Console.WriteLine("--------------------------------Verified that the VM image is saved successfully--------------------------------");
                //e.	Deploy a new IaaS VM with the save VM image
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = Utilities.CreateIaaSVMObject(vmName1, InstanceSize.Small, vmImageName, false, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName1, new[] { vm }, locationName);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName1, vmImageName);
                //f.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName1, vmImageName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName1);
                //g.	Add another IaaS VM with the save VM image to the existing service
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("--------------------------------Deploy a new IaaS VM with the saved VM image {0}--------------------------------", vmImageName);
                vmPowershellCmdlets.NewAzureQuickVM(OS.Linux, vmName2, serviceName1, vmImageName, username, password);
                Console.WriteLine("--------------------------------Deployed a IaaS VM {0} with the saved VM image {1}--------------------------------", vmName2, vmImageName);
                //h.	Verify the VM by Get-AzureVM
                Console.WriteLine("--------------------------------Verify the VM by Get-AzureVM--------------------------------", vmName2, vmImageName);
                vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName2, serviceName1);
                Utilities.PrintContext(vmRoleContext);
                Console.WriteLine("--------------------------------Verified the VM {0} successfully--------------------------------", vmName2);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                CleanupService(serviceName1);
                //Delete the VM image
                Console.WriteLine("------------------------------Delete the VM image---------------------------------");
                vmPowershellCmdlets.RemoveAzureVMImage(vmImageName, true);
                Console.WriteLine("------------------------------Deleted the VM image---------------------------------");
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void AzureVMImageListRemoveTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string newImageName = Utilities.GetUniqueShortName("vmimage");
            string oldLabel = "old label";
            string newLabel = Utilities.GetUniqueShortName("vmimage");
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            string serviceName1 = Utilities.GetUniqueShortName("Pstestsvc"); 

            try
            {
                string mediaLocation = UploadVhdFile();
                Console.WriteLine("------------------------------Add an OS image---------------------------------");
                //      a.	Add an OS image
                var result = vmPowershellCmdlets.AddAzureVMImage(newImageName, mediaLocation, OS.Windows, newImageName);
                Console.WriteLine("------------------------------Add an OS image: Completed---------------------------------");
                //b.	Deploy a new IaaS VM
                Console.WriteLine("------------------------------Deploy a new IaaS VM---------------------------------");
                var vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, newImageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("------------------------------Deploy a new IaaS VM: Completed---------------------------------");
                //c.	Stop the VM
                Console.WriteLine("------------------------------Stop the VM---------------------------------");
                vmPowershellCmdlets.StopAzureVM(vm, serviceName, true);
                Console.WriteLine("------------------------------Stop the VM: Completed---------------------------------");
                //d.	Try to save the OS image with an existing os image name. (should fail)
                Console.WriteLine("------------------------------Try to save the OS image with an existing os image name---------------------------------");
                Utilities.VerifyFailure(() => vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, oldLabel, CONSTANT_SPECIALIZED, oldLabel), BadRequestException);
                Console.WriteLine("------------------------------Try to save the OS image with an existing os image name: Completed---------------------------------");
                //e.	Save the OS image with a new image name.
                Console.WriteLine("------------------------------Save the OS image with a new image name.---------------------------------");
                vmPowershellCmdlets.StopAzureVM(vm, serviceName, true);
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, newLabel);
                Console.WriteLine("------------------------------Save the OS image with a new image name: Completed---------------------------------");
                //f.	Deploy a new IaaS VM
                Console.WriteLine("------------------------------Deploy a new IaaS VM---------------------------------");
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = CreateIaaSVMObjectWithDisk(vmName1, InstanceSize.Small, newLabel, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName1, new[] { vm }, locationName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName1, serviceName1);
                Console.WriteLine("------------------------------Deploy a new IaaS VM: Completed---------------------------------");

                //g.	Stop the VM
                Console.WriteLine("------------------------------Stop the VM---------------------------------");
                vmPowershellCmdlets.StopAzureVM(vm, serviceName1, true);
                Console.WriteLine("------------------------------Stop the VM: Completed---------------------------------");
                //h.	Save the VM image with the existing os image name (should fail)
                Console.WriteLine("------------------------------Save the VM image with the existing os image name---------------------------------");
                vmImageName = vmName1 + "Image";
                Utilities.VerifyFailure(() => vmPowershellCmdlets.SaveAzureVMImage(serviceName1, vmName1, newLabel, CONSTANT_SPECIALIZED, vmImageName), "OSImage");
                Console.WriteLine("------------------------------Save the VM image with the existing os image name: Completed---------------------------------");
                //i.	List VM Images
                //i.	Get-AzureVMImage
                //VerifyVMImage(vmImageName, OS.Windows, vmImageName, CONSTANT_SPECIALIZED, cahcing, lunSlot1, diskSize1, 1);
                Console.WriteLine("------------------------------Get-AzureVMImage---------------------------------");
                VerifyOsImage(newLabel, new OSImageContext()
                {  
                    ImageName = newLabel,
                    Category = CONSTANT_CATEGORY,
                    Location = locationName,
                    Label = newLabel,
                    OS = OS.Windows.ToString()
               });
                Console.WriteLine("------------------------------Get-AzureVMImage: Completed---------------------------------");
                //j.	Try to remove a wrong vm
                Console.WriteLine("------------------------------Try to remove a wrong vm---------------------------------");
                Utilities.VerifyFailure(() => vmPowershellCmdlets.RemoveAzureVMImage(Utilities.GetUniqueShortName()),ResourceNotFoundException);
                Console.WriteLine("------------------------------Try to remove a wrong vm: Completed---------------------------------");
                pass = true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                //k.	Remove the VM Images
                DeleteVMImageIfExists(newLabel);
                vmPowershellCmdlets.RemoveAzureService(serviceName1);
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void GetAzureVMImageNegativeTest()
        {
            try
            {
                cleanupIfPassed = false;
                //  Try to get a wrong vm image.
                Utilities.VerifyFailure(() => vmPowershellCmdlets.GetAzureVMImage(Utilities.GetUniqueShortName(vmNamePrefix)), ResourceNotFoundException);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Ignore(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void RemoveAzureVMImageNegativeTest()
        {
            try
            {
                //      a.	Try to remove a wrong vm image
                //i.	Remove-AzureVMImage –VMImageName $wrongimgname
                //ii.	Remove-AzureVMImage –OSImageName $wrongimgname

                //Not Applicable yet as VMImageName,OSImageName parameters are not yet provided.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(1), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,i.	Remove-AzureVMImage)")]
        public void SaveAzureVMImageNegativeTest()
        {
            try
            {
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                //      Deploy a new IaaS VM
                Console.WriteLine("------------------------------Deploy a new IaaS VM---------------------------------");
                var vm = CreateIaaSVMObjectWithDisk(vmName, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                Console.WriteLine("------------------------------Deploy a new IaaS VM: completed---------------------------------");
                //b.	Stop the VM
                Console.WriteLine("------------------------------Stop the VM---------------------------------");
                vmPowershellCmdlets.StopAzureVM(vm, serviceName,force:true);
                Console.WriteLine("------------------------------Stop the VM: completed---------------------------------");
                //c.	Save the VM image
                Console.WriteLine("------------------------------Save the VM image---------------------------------");
                vmImageName = vmName + "Image";
                vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName,  CONSTANT_SPECIALIZED,vmImageName);
                Console.WriteLine("------------------------------Save the VM image: completed---------------------------------");
                //d.	Deploy another new IaaS VM
                Console.WriteLine("------------------------------Deploy another new IaaS VM---------------------------------");
                string vmName1 = Utilities.GetUniqueShortName(vmNamePrefix);
                vm = CreateIaaSVMObjectWithDisk(vmName1, InstanceSize.Small, imageName, true, username, password);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm });
                Console.WriteLine("------------------------------Deploy another new IaaS VM: completed---------------------------------");
                //e.	Stop the VM
                Console.WriteLine("------------------------------Stop the VM (for 2nd VM)---------------------------------");
                vmPowershellCmdlets.StopAzureVM(vm, serviceName,force:true);
                string testImageName = Utilities.GetUniqueShortName(vmNamePrefix);
                Console.WriteLine("------------------------------Stop the VM (for 2nd VM): completed---------------------------------");
                //f.	Try to save the VM image with the existing name (must fail)
                Console.WriteLine("------------------------------Save the VM image with the existing name (must fail)---------------------------------");
                Utilities.VerifyFailure(() => vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName1, vmImageName, CONSTANT_SPECIALIZED, vmImageName, false, false), ConflictErrorException);
                Console.WriteLine("------------------------------Save the VM image with the existing name (must fail): completed---------------------------------");
                //g.	Try to save the VM image with the wrong vm name (must fail)
                Console.WriteLine("------------------------------Save the VM image (must fail)---------------------------------");
                Utilities.VerifyFailure(() => vmPowershellCmdlets.SaveAzureVMImage(serviceName, Utilities.GetUniqueShortName(vmNamePrefix), testImageName, CONSTANT_SPECIALIZED, testImageName), ResourceNotFoundException);
                Console.WriteLine("------------------------------Save the VM image (must fail): completed---------------------------------");
                //h.	Try to save the VM image with the wrong service name (must fail)
                Console.WriteLine("------------------------------Save the VM image with wrong name (must fail)---------------------------------");
                string testVMIMage = Utilities.GetUniqueShortName("VMImage");
                vmPowershellCmdlets.SaveAzureVMImage(Utilities.GetUniqueShortName(vmNamePrefix), vmName1, testVMIMage, CONSTANT_SPECIALIZED, testVMIMage);
                Utilities.VerifyFailure(() => vmPowershellCmdlets.GetAzureVMImage(testVMIMage),ResourceNotFoundException);
                Console.WriteLine("------------------------------Save the VM image with wrong name (must fail): completed---------------------------------");
                //i.	Try to save the VM image with the label longer than maximum length of string (must fail)
                Console.WriteLine("------------------------------Save the VM image with long name (must fail)---------------------------------");
                string LongImageName = Utilities.GetUniqueShortName(length:30) + Utilities.GetUniqueShortName(length:30)+  Guid.NewGuid().ToString() + Guid.NewGuid().ToString() ;
                Console.WriteLine("Attempting to save a VMImage with name {0} of {1} characters and expecting it to fail.", LongImageName,LongImageName.Length);
                Utilities.VerifyFailure(() => vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName1, testImageName, CONSTANT_SPECIALIZED, LongImageName), BadRequestException);
                Console.WriteLine("------------------------------Save the VM image with long name (must fail): completed---------------------------------");
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                Console.WriteLine("------------------------------Delete the VM image (cleanup)---------------------------------");
                DeleteVMImageIfExists(vmImageName);
                Console.WriteLine("------------------------------Deleted the VM image (cleanup): completed---------------------------------");
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (New-AzureQuickVM,Get-AzureVMImage,New-AzureVM,New-AzureVMConfig,Add-AzureDataDisk,Stop-AzureVM,Save-AzureVMImage,Get-AzureVM,Get-AzureVMImage,Remove-AzureVMImage,Update-AzureVMImage)")]
        public void UpdateVMImageDataDiskAndOsDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, DateTime.Now);
            try
            {
                //Create a new vmImage with 2 data disks
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string disk1 = "Disk1";
                string disk2 = "Disk2";
                HostCaching disk1HostCaching = HostCaching.ReadOnly;
                HostCaching disk2HostCaching = HostCaching.None;

                //Creating VM with 2 data disks.;
                Utilities.ExecuteAndLog(() =>
                    {
                        PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);
                        //Attach disk 1 with hostcaching 'Readonly'
                        AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, disk1, 0, disk1HostCaching.ToString());
                        azureDataDiskConfigInfo1.Vm = vm;
                        vm = vmPowershellCmdlets.AddAzureDataDisk(azureDataDiskConfigInfo1);
                        //Attach disk 2 with hostcaching 'None'
                        AddAzureDataDiskConfig azureDataDiskConfigInfo2 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, disk2, 1, disk2HostCaching.ToString());
                        azureDataDiskConfigInfo2.Vm = vm;
                        vm = vmPowershellCmdlets.AddAzureDataDisk(azureDataDiskConfigInfo2);
                        //deploy the VM
                        vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                    },"Creating VM with 2 data disks.");

                //Save image of the VM as a Specialized vm image.
                vmImageName = vmName + "Image";
                Utilities.ExecuteAndLog(() => 
                {
                    Utilities.PrintHeader("Save specialized vm image of the deployed vm.");
                    vmPowershellCmdlets.StopAzureVM(vmPowershellCmdlets.GetAzureVM(vmName, serviceName).VM, serviceName,force:true);
                    vmPowershellCmdlets.SaveAzureVMImage(serviceName, vmName, vmImageName, "Specialized", vmImageName);
                },"Save specialized vm image of the deployed vm.");

                //Verify the saved vm Image
                DataDiskConfigurationList diskConfig = new DataDiskConfigurationList();
                Utilities.ExecuteAndLog(() => 
                {
                    diskConfig.Add(new DataDiskConfiguration() { Lun = 0, LogicalDiskSizeInGB = diskSize1, HostCaching = disk1HostCaching.ToString() });
                    diskConfig.Add(new DataDiskConfiguration() { Lun = 1, LogicalDiskSizeInGB = diskSize1, HostCaching = disk2HostCaching.ToString() });
                    VerifyVMImage(vmImageName, OS.Windows, vmImageName, "Specialized", cahcing, diskConfig);
                },"Fetch the saved vm image info and verify the vm image info.");


                UpdateAzureVMImageDetails(vmImageName);

                string disk1Name,disk2Name;
                UpdateVMImageOsAndDataDiskAnderifyChanges(diskConfig, out disk1Name, out disk2Name);

                //Update VMImage using DiskConfig set prepared manually.
                UpdateVmImageUsingDiskConfigSetAndVerifyChanges(diskConfig, disk1Name, disk2Name);
                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }

        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IaaS"), Priority(0), Owner("hylee"), Description("Test the cmdlets (Get-AzureVMImage, New-AzureVMConfig, New-AzureVM, Get-AzureVM, Remove-AzureVM, etc.)")]
        public void CreateVirtualMachineUsingVMImageWithDataDisks()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, DateTime.Now);
            
            try
            {
                // Try to get VM image with data disks
                var vmImages = vmPowershellCmdlets.GetAzureVMImageReturningVMImages();
                var vmImage = vmImages.Where(t => t.OS == "Windows" && t.Category == "Public" && t.DataDiskConfigurations != null
                    && t.Location.Contains(locationName) && t.DataDiskConfigurations.Any()).FirstOrDefault();

                // New-AzureService and verify with Get-AzureService
                vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);
                Assert.IsTrue(Verify.AzureService(serviceName, serviceName, locationName));

                // New-AzureVMConfig
                var vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var vmSize = InstanceSize.ExtraLarge.ToString();
                var currentStorage = vmPowershellCmdlets.GetAzureStorageAccount(defaultAzureSubscription.CurrentStorageAccountName).First();
                var mediaLocationStr = ("mloc" + vmName).ToLower();
                var vmMediaLocation = currentStorage.Endpoints.Where(p => p.Contains("blob")).First() + mediaLocationStr;
                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, vmSize, vmImage.ImageName, vmMediaLocation);
                PersistentVM vm = vmPowershellCmdlets.NewAzureVMConfig(azureVMConfigInfo);

                // Add-AzureProvisioningConfig
                AzureProvisioningConfigInfo azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password, true);
                azureProvisioningConfig.Vm = vm;
                vm = vmPowershellCmdlets.AddAzureProvisioningConfig(azureProvisioningConfig);

                // New-AzureVM
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, null, null, null, null, null, null, null, null, null, null, true);
                pass = true;

                // Get-AzureVM
                var returnedVM = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Assert.IsTrue(returnedVM.VM.DataVirtualHardDisks != null && returnedVM.VM.DataVirtualHardDisks.Count() == vmImage.DataDiskConfigurations.Count());
                Assert.IsTrue(returnedVM.VM.DataVirtualHardDisks.All(t => t.MediaLink.ToString().StartsWith(vmMediaLocation)));

                // Remove-AzureVM
                vmPowershellCmdlets.RemoveAzureVM(vmName, serviceName);

                // Remove-AzureService
                vmPowershellCmdlets.RemoveAzureService(serviceName, true);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private void UpdateVmImageUsingDiskConfigSetAndVerifyChanges(DataDiskConfigurationList diskConfig, string disk1Name, string disk2Name)
        {
            cahcing = GetAlternateHostCachingForOsDisk(cahcing.ToString());
            Utilities.PrintHeader("Update Azure VM image data disk 1 hostcaching to ReadOnly, data disk 2 hostcaching to None and OS disk host cahching to" + cahcing.ToString());
            var diskConfigSet = vmPowershellCmdlets.NewAzureVMImageDiskConfigSet();
            diskConfigSet.OSDiskConfiguration = new OSDiskConfiguration() { HostCaching = cahcing.ToString() };
            diskConfigSet.DataDiskConfigurations = new DataDiskConfigurationList();
            diskConfigSet.DataDiskConfigurations.Add(new DataDiskConfiguration()
            {
                Name = disk1Name,
                HostCaching = HostCaching.ReadOnly.ToString(),
                Lun = 0
            });
            diskConfigSet.DataDiskConfigurations.Add(new DataDiskConfiguration()
            {
                Name = disk2Name,
                HostCaching = HostCaching.None.ToString(),
                Lun = 1
            });
            //update Azure VM image.
            vmPowershellCmdlets.UpdateAzureVMImage(vmImageName, vmImageName, diskConfigSet);
            Utilities.PrintFooter(string.Format("Update Azure VM image data disk 1 hostcaching to ReadWrite, data disk 2 hostcaching to ReadOnly and OS disk host cahching to {0}. ", cahcing.ToString()));

            // Verify that the vm image disk 1 host caching is "ReadWrite".
            Utilities.PrintHeader("Verify that the vm image.");
            diskConfig[0].HostCaching = diskConfigSet.DataDiskConfigurations[0].HostCaching.ToString();
            diskConfig[1].HostCaching = diskConfigSet.DataDiskConfigurations[1].HostCaching.ToString();
            VerifyVMImage(vmImageName, OS.Windows, vmImageName, "Specialized", cahcing, diskConfig);
            Utilities.PrintFooter("Verify that the vm image.");
        }

        private void UpdateVMImageOsAndDataDiskAnderifyChanges( DataDiskConfigurationList diskConfig, out string disk1Name,out string disk2Name)
        {
            //Update Azure VM image disk 1 hostcaching to read write
            cahcing = GetAlternateHostCachingForOsDisk(cahcing.ToString());
            Utilities.PrintHeader(string.Format("Update Azure VM image data disk 1 hostcaching to ReadWrite, data disk 2 hostcaching to ReadOnly and OS disk host cahching to {0}. ", cahcing.ToString()));
            var vmImageContext = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(vmImageName);
            Utilities.PrintCompleteContext(vmImageContext);
            var vmImageInfo = vmImageContext[0];
            disk1Name = vmImageInfo.DataDiskConfigurations[0].Name;
            disk2Name = vmImageInfo.DataDiskConfigurations[1].Name;
            var disk1HostCaching = HostCaching.ReadWrite;
            var disk2HostCaching = HostCaching.ReadOnly;
            // get disk 1 configuration from vm image 
            var diskConfigSet = vmPowershellCmdlets.GetAzureVMImageDiskConfigSet(vmImageInfo);
            // set disk1 host caching to read write 
            diskConfigSet = vmPowershellCmdlets.SetAzureVMImageDataDiskConfig(diskConfigSet, disk1Name, 0, disk1HostCaching.ToString());
            //set disk 2 host caching to None
            diskConfigSet = vmPowershellCmdlets.SetAzureVMImageDataDiskConfig(diskConfigSet, disk2Name, 1, disk2HostCaching.ToString());
            // set os disk host caching to a differnt value.
            diskConfigSet = vmPowershellCmdlets.SetAzureVMImageOSDiskConfig(diskConfigSet, cahcing.ToString());
            //update Azure VM image.
            vmPowershellCmdlets.UpdateAzureVMImage(vmImageName, vmImageName, diskConfigSet);
            Utilities.PrintFooter(string.Format("Update Azure VM image data disk 1 hostcaching to ReadWrite, data disk 2 hostcaching to ReadOnly and OS disk host cahching to {0}. ", cahcing.ToString()));

            // Verify that the vm image disk 1 host caching is "ReadWrite".
            Utilities.PrintHeader("Verify the vm image.");
            diskConfig[0].HostCaching = disk1HostCaching.ToString();
            diskConfig[1].HostCaching = disk2HostCaching.ToString();
            VerifyVMImage(vmImageName, OS.Windows, vmImageName, "Specialized", cahcing, diskConfig);
            Utilities.PrintFooter("Verify the vm image.");
        }

        private void UpdateAzureVMImageDetails(string imageName)
        {
            VMImageContext imageContext = new VMImageContext()
            {
                Eula = "End user licensce agreement value",
                ImageFamily = OS.Windows.ToString(),
                Description = "Description",
                IconUri = "IconName",
                ImageName = imageName,
                Label = imageName,
                Language = "English",
                PrivacyUri = new Uri(@"http://www.bing.com"),
                PublishedDate = DateTime.Now,
                RecommendedVMSize = InstanceSize.Medium.ToString(),
                ShowInGui = false,
                SmallIconUri = "SmallIconName",
            };

            Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.UpdateAzureVMImage(imageName, imageName, imageContext.ImageFamily, imageContext.ShowInGui.Value, imageContext.RecommendedVMSize, imageContext.Description, imageContext.Eula,
                         imageContext.PrivacyUri, imageContext.PublishedDate, imageContext.Language, imageContext.IconName, imageContext.SmallIconName);
                }, "Update Azure VM Image details");

            VerifyVMImageProperties(imageContext);
        }

        private void VerifyVMImageProperties(VMImageContext imageContext)
        {
            Utilities.ExecuteAndLog(() =>
                {
                    var vmImages = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(imageContext.ImageName);
                    var vmImageContext = vmImages[0];

                    Utilities.PrintContext(vmImageContext);

                    Console.WriteLine("\n Verification:");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.Eula, vmImageContext.Eula), "Eula");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.Description, vmImageContext.Description), "Description");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.IconUri, vmImageContext.IconUri), "IconUri");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.IconName, vmImageContext.IconName), "IconName");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.ImageFamily, vmImageContext.ImageFamily), "ImageFamily");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.ImageName, vmImageContext.ImageName), "ImageName");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.Label, vmImageContext.Label), "Label");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.Language, vmImageContext.Language), "Language");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.PrivacyUri, vmImageContext.PrivacyUri), "PrivacyUri");
                    Utilities.LogAssert(() => Assert.IsTrue(imageContext.PublishedDate.Value.Date.Equals(vmImageContext.PublishedDate.Value.Date)), "PublishedDate");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.RecommendedVMSize, vmImageContext.RecommendedVMSize), "RecommendedVMSize");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.ShowInGui, vmImageContext.ShowInGui), "ShowInGui");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.SmallIconUri, vmImageContext.SmallIconUri), "SmallIconUri");
                    Utilities.LogAssert(() => Assert.AreEqual(imageContext.SmallIconName, vmImageContext.SmallIconName), "SmallIconName");
                }, "Verify VM image details");
        }


        #endregion TestCases

        [TestCleanup]
        public void TestCleanUp()
        {
            if (cleanupIfPassed)
                CleanupService(serviceName);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        #region Helper Methods
        public void VerifyVMImage(string vmImageName, OS ImageFamily, string imageLabel, string osState, HostCaching hostCaching, DataDiskConfigurationList diskConfigs)
        {
            var vmImages = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(vmImageName);
            Assert.IsTrue(vmImages.Count >= 1);
            var vmImageInfo = vmImages[0];
            Utilities.PrintContext(vmImageInfo);
            Utilities.PrintContext(vmImageInfo.OSDiskConfiguration);
            foreach (var disk in vmImageInfo.DataDiskConfigurations)
            {
                Utilities.PrintContext(disk);
            }
            //Verify ImageName
            Assert.IsTrue(vmImageName.Equals(vmImageInfo.ImageName));
            Assert.IsTrue(vmImageInfo.Label.Equals(imageLabel));
            //Verify Category
            Assert.IsTrue("User".Equals(vmImageInfo.Category, StringComparison.CurrentCultureIgnoreCase));
            //Verify LogicalDiskSizeInGB, HostCaching
            Assert.AreEqual(hostCaching.ToString(), vmImageInfo.OSDiskConfiguration.HostCaching, "Property HostCaching is not matching.");
            //Verify the no of the data disks 
            Assert.AreEqual(diskConfigs.Count, vmImageInfo.DataDiskConfigurations.Count);
            //Verify Data disks.
            VerifyDataDiskConfiguration(diskConfigs, vmImageInfo);
            //Verify OSstate
            Assert.AreEqual(osState, vmImageInfo.OSDiskConfiguration.OSState, "OsState is not matching.");
            //Verify OS
            Assert.AreEqual(ImageFamily.ToString(), vmImageInfo.OSDiskConfiguration.OS, "Os Family is not matching.");
        }

        private void VerifyDataDiskConfiguration(DataDiskConfigurationList dataDiskConfigs, VMImageContext vmImageInfo)
        {
            try
            {
                for (int i = 0; i < dataDiskConfigs.Count; i++)
                {
                    Assert.AreEqual(dataDiskConfigs[i].HostCaching.ToString(), vmImageInfo.DataDiskConfigurations[i].HostCaching, "Data disk HostCaching iproperty is not matching.");
                    //Verify LogicalDiskSizeInGB,
                    Assert.AreEqual(dataDiskConfigs[i].LogicalDiskSizeInGB, vmImageInfo.DataDiskConfigurations[i].LogicalDiskSizeInGB);
                    //Verify  LUN
                    Assert.AreEqual(dataDiskConfigs[i].Lun, vmImageInfo.DataDiskConfigurations[i].Lun);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void VerifyOsImage(string ImageName, OSImageContext imageContext)
        {
            var vmImage = vmPowershellCmdlets.GetAzureVMImage(ImageName);
            Utilities.PrintContext(vmImage[0]);
            Assert.AreEqual(imageContext.ImageName, vmImage[0].ImageName, "ImageName property of the saved os image is not matching.");
            Assert.AreEqual(imageContext.Category, vmImage[0].Category, "Category property of the saved os image is not matching.");
            Assert.AreEqual(imageContext.Location, vmImage[0].Location, "Location property of the saved os image is not matching.");
            Assert.AreEqual(imageContext.Label, vmImage[0].Label, "Label property of the saved os image is not matching.");
            Assert.AreEqual(imageContext.OS, vmImage[0].OS, "OS property of the saved os image is not matching.");
        }


        public PersistentVM CreateIaaSVMObjectWithDisk(string vmName, InstanceSize size, string imageName, bool isWindows, string username, string password)
        {
            PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, isWindows, username, password);
            AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize1, diskLabel1, lunSlot1,cahcing.ToString());
            azureDataDiskConfigInfo1.Vm = vm;
            return vmPowershellCmdlets.AddAzureDataDisk(azureDataDiskConfigInfo1);
        }

        public void DeleteVMImageIfExists(string vmImageName)
        {
            try
            {
                var vmImages = vmPowershellCmdlets.GetAzureVMImage(vmImageName);
                if (vmImages.Count > 0)
                {
                    vmPowershellCmdlets.RemoveAzureVMImage(vmImageName, true);
                }
            }
            catch (Exception)
            {
                /*GetAzureVMImage throws image if it doesnt not find any vm images with the given name.
                 Since it is an expected behaviour we cathc the exception here.*/
            }
            
            
        }

        public void VerifyVM(PersistentVM vm, OS ImageFamily, HostCaching hostCaching, int LogicalDiskSizeInGB, int noOfDataDisks)
        {
            //Verify OS Disk
            Console.WriteLine("VM OS Virtual Hard Disk properties:");
            Utilities.PrintContext(vm.OSVirtualHardDisk);
            Assert.AreEqual(HostCaching.ReadWrite.ToString(), vm.OSVirtualHardDisk.HostCaching, "Os disk Property HostCaching is not matching.");
            Assert.AreEqual(ImageFamily.ToString(), vm.OSVirtualHardDisk.OS,"ImageFamily property is not matching.");
            //Verify Data Disk
            Console.WriteLine("VM Data Hard Disk properties:");
            Utilities.PrintContext(vm.DataVirtualHardDisks[0]);
            Assert.AreEqual(hostCaching.ToString(), vm.DataVirtualHardDisks[0].HostCaching, "Data disk Property HostCaching is not matching.");
            Assert.AreEqual(LogicalDiskSizeInGB, vm.DataVirtualHardDisks[0].LogicalDiskSizeInGB,"Data disk size is not matching.");
            Assert.AreEqual(noOfDataDisks, vm.DataVirtualHardDisks.Count, "Data disks count is not matching.");
        }


        private HostCaching GetAlternateHostCachingForOsDisk(string currentValue)
        {
            return currentValue.Equals(HostCaching.ReadOnly.ToString()) ? HostCaching.ReadWrite : HostCaching.ReadOnly;
        }

        /// <summary>
        /// Waits for the VM to reach Started / Stopped / StoppedDeallocated state.
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="serviceName"></param>
        private void WaitForVmStartedState(string vmName, string serviceName)
        {
            PersistentVMRoleContext vm = null;
            //vmPowershellCmdlets.GetAzureVM(vmName,serviceName);
            Utilities.RetryActionUntilSuccess(() =>
            {
                Console.WriteLine("Fetching VM status");
                vm = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                if (!new[] { "Started", "Stopped", "StoppedDealocated", "Running" }.Contains(vm.Status))
                {
                    Console.WriteLine("VM status :{0}, ", vm.Status);
                    throw new Exception(MachineNotReadyState);
                }
                Console.WriteLine(" Exiting wait as VM reached {0}, ", vm.Status);
            }, MachineNotReadyState, 20, 5);
        }
        #endregion Helper Methods

    }
}
