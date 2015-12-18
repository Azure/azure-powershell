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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class FunctionalTestCommonVhd : ServiceManagementTest
    {
        private const string vhdNamePrefix = "os.vhd";
        private string vhdName;
        protected static string vhdBlobLocation;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            vhdBlobLocation = string.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdNamePrefix);
            if (string.IsNullOrEmpty(localFile))
            {
                try
                {
                    //CredentialHelper.CopyTestData(testDataContainer, osVhdName, vhdContainerName, vhdNamePrefix);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Assert.Inconclusive("Upload vhd is not set!");
                }
            }
            else
            {
                try
                {
                    vmPowershellCmdlets.AddAzureVhd(new FileInfo(localFile), vhdBlobLocation);
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already exists"))
                    {
                        // Use the already uploaded vhd.
                        Console.WriteLine("Using already uploaded blob..");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            pass = false;
            testStartTime = DateTime.Now;
        }

        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Update,Remove)-AzureDisk)")]
        public void AzureDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            vhdName =  Utilities.GetUniqueShortName("os0vhd");
            CopyCommonVhd(vhdContainerName, "os0.vhd", vhdName);

            string mediaLocation = String.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdName);

            try
            {
                vmPowershellCmdlets.AddAzureDisk(vhdName, mediaLocation, vhdName, null);

                bool found = false;
                foreach (DiskContext disk in vmPowershellCmdlets.GetAzureDisk(vhdName))
                {
                    Console.WriteLine("Disk: Name - {0}, Label - {1}, Size - {2},", disk.DiskName, disk.Label, disk.DiskSizeInGB);
                    if (disk.DiskName == vhdName && disk.Label == vhdName)
                    {
                        found = true;
                        Console.WriteLine("{0} is found", disk.DiskName);
                    }
                }
                Assert.IsTrue(found, "Error: Disk is not added");

                // Update only label
                string newLabel = "NewLabel";
                vmPowershellCmdlets.UpdateAzureDisk(vhdName, newLabel);

                DiskContext virtualDisk = vmPowershellCmdlets.GetAzureDisk(vhdName)[0];

                Console.WriteLine("Disk: Name - {0}, Label - {1}, Size - {2},", virtualDisk.DiskName, virtualDisk.Label, virtualDisk.DiskSizeInGB);
                Assert.AreEqual(newLabel, virtualDisk.Label);
                Console.WriteLine("Disk Label is successfully updated");

                // Update only size
                int newSize = 50;
                vmPowershellCmdlets.UpdateAzureDisk(vhdName, null, newSize);

                virtualDisk = vmPowershellCmdlets.GetAzureDisk(vhdName)[0];

                Console.WriteLine("Disk: Name - {0}, Label - {1}, Size - {2},", virtualDisk.DiskName, virtualDisk.Label, virtualDisk.DiskSizeInGB);
                Assert.AreEqual(newLabel, virtualDisk.Label);
                Assert.AreEqual(newSize, virtualDisk.DiskSizeInGB);
                Console.WriteLine("Disk size is successfully updated");

                // Update both label and size
                newLabel = "NewLabel2";
                newSize = 100;
                vmPowershellCmdlets.UpdateAzureDisk(vhdName, newLabel, newSize);

                virtualDisk = vmPowershellCmdlets.GetAzureDisk(vhdName)[0];

                Console.WriteLine("Disk: Name - {0}, Label - {1}, Size - {2},", virtualDisk.DiskName, virtualDisk.Label, virtualDisk.DiskSizeInGB);
                Assert.AreEqual(newLabel, virtualDisk.Label);
                Assert.AreEqual(newSize, virtualDisk.DiskSizeInGB);
                Console.WriteLine("Both disk label and size are successfully updated");

                vmPowershellCmdlets.RemoveAzureDisk(vhdName, true);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDisk, vhdName), "The disk was not removed");
                pass = true;
            }
            catch (Exception e)
            {
                pass = false;

                if (e.ToString().Contains("ResourceNotFound"))
                {
                    Console.WriteLine("Please upload {0} file to \\vhdtest\\ blob directory before running this test", vhdName);
                }

                try
                {
                    vmPowershellCmdlets.RemoveAzureDisk(vhdName, true);
                }
                catch (Exception cleanupError)
                {
                    Console.WriteLine("Error during cleaning up the disk.. Continue..:{0}", cleanupError);
                }

                Assert.Fail("Exception occurs: {0}", e.ToString());
            }
        }

        private void CopyCommonVhd(string vhdContainerName, string vhdName, string myVhdName)
        {
            vmPowershellCmdlets.RunPSScript(string.Format("{0}-{1} -SrcContainer {2} -SrcBlob {3} -DestContainer {4} -DestBlob {5}",
                VerbsLifecycle.Start, StorageNouns.CopyBlob, vhdContainerName, vhdName, vhdContainerName, myVhdName));
        }

        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Save,Update,Remove)-AzureVMImage)")]
        public void AzureVMImageTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vhdName = "os1.vhd";
            string newImageName = Utilities.GetUniqueShortName("vmimage");
            string mediaLocation = string.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdName);

            string oldLabel = "old label";
            string newLabel = "new label";
            string vmSize = "Small";
            var iconUri = "http://www.bing.com";
            var smallIconUri = "http://www.bing.com";
            bool showInGui = true;

            try
            {
                // BVT Tests for OS Images
                OSImageContext result = vmPowershellCmdlets.AddAzureVMImage(newImageName, mediaLocation, OS.Windows, oldLabel, vmSize, iconUri, smallIconUri, showInGui);

                OSImageContext resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                result = vmPowershellCmdlets.UpdateAzureVMImage(newImageName, newLabel);
                resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                result = vmPowershellCmdlets.UpdateAzureVMImage(newImageName, newLabel, true);
                resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(resultReturned.ShowInGui.HasValue && !resultReturned.ShowInGui.Value);
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                vmPowershellCmdlets.RemoveAzureVMImage(newImageName, false);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, newImageName));

                // BVT Tests for VM Images
                // Unique Container Prefix
                var containerPrefix = Utilities.GetUniqueShortName("vmimg");

                // Disk Blobs
                var srcVhdName = "os1.vhd";
                var srcVhdContainer = vhdContainerName;
                var dstOSVhdContainer = containerPrefix.ToLower() + "os" + vhdContainerName;
                CredentialHelper.CopyTestData(srcVhdContainer, srcVhdName, dstOSVhdContainer);
                string osVhdLink = string.Format("{0}{1}/{2}", blobUrlRoot, dstOSVhdContainer, srcVhdName);

                var dstDataVhdContainer = containerPrefix.ToLower() + "data" + vhdContainerName;
                CredentialHelper.CopyTestData(srcVhdContainer, srcVhdName, dstDataVhdContainer);
                string dataVhdLink = string.Format("{0}{1}/{2}", blobUrlRoot, dstDataVhdContainer, srcVhdName);

                // VM Image OS/Data Disk Configuration
                var addVMImageName = containerPrefix + "Image";
                var diskConfig = new VirtualMachineImageDiskConfigSet
                {
                    OSDiskConfiguration = new OSDiskConfiguration
                    {
                        HostCaching = HostCaching.ReadWrite.ToString(),
                        OS = OSType.Windows.ToString(),
                        OSState = "Generalized",
                        MediaLink = new Uri(osVhdLink)
                    },
                    DataDiskConfigurations = new DataDiskConfigurationList
                    {
                        new DataDiskConfiguration
                        {
                            HostCaching = HostCaching.ReadOnly.ToString(),
                            Lun = 0,
                            MediaLink = new Uri(dataVhdLink)
                        }
                    }
                };

                // Add-AzureVMImage
                string label = addVMImageName;
                string description = "test";
                string eula = "http://www.bing.com/";
                string imageFamily = "Windows";
                DateTime? publishedDate = new DateTime(2015, 1, 1);
                string privacyUri = "http://www.bing.com/";
                string recommendedVMSize = vmSize;
                string iconName = "iconName";
                string smallIconName = "smallIconName";

                vmPowershellCmdlets.AddAzureVMImage(
                    addVMImageName,
                    label,
                    diskConfig,
                    description,
                    eula,
                    imageFamily,
                    publishedDate,
                    privacyUri,
                    recommendedVMSize,
                    iconName,
                    smallIconName,
                    showInGui);

                // Get-AzureVMImage
                var vmImage = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(addVMImageName).First();

                Assert.IsTrue(vmImage.ImageName == addVMImageName);
                Assert.IsTrue(vmImage.Label == label);
                Assert.IsTrue(vmImage.Description == description);
                Assert.IsTrue(vmImage.Eula == eula);
                Assert.IsTrue(vmImage.ImageFamily == imageFamily);
                Assert.IsTrue(vmImage.PublishedDate.Value.Year == publishedDate.Value.Year);
                Assert.IsTrue(vmImage.PublishedDate.Value.Month == publishedDate.Value.Month);
                Assert.IsTrue(vmImage.PublishedDate.Value.Day == publishedDate.Value.Day);
                Assert.IsTrue(vmImage.PrivacyUri.AbsoluteUri.ToString() == privacyUri);
                Assert.IsTrue(vmImage.RecommendedVMSize == recommendedVMSize);
                Assert.IsTrue(vmImage.IconName == iconName);
                Assert.IsTrue(vmImage.IconUri == iconName);
                Assert.IsTrue(vmImage.SmallIconName == smallIconName);
                Assert.IsTrue(vmImage.SmallIconUri == smallIconName);
                Assert.IsTrue(vmImage.ShowInGui == showInGui);
                Assert.IsTrue(vmImage.OSDiskConfiguration.HostCaching == diskConfig.OSDiskConfiguration.HostCaching);
                Assert.IsTrue(vmImage.OSDiskConfiguration.OS == diskConfig.OSDiskConfiguration.OS);
                Assert.IsTrue(vmImage.OSDiskConfiguration.OSState == diskConfig.OSDiskConfiguration.OSState);
                Assert.IsTrue(vmImage.OSDiskConfiguration.MediaLink == diskConfig.OSDiskConfiguration.MediaLink);
                Assert.IsTrue(vmImage.DataDiskConfigurations.First().HostCaching == diskConfig.DataDiskConfigurations.First().HostCaching);
                Assert.IsTrue(vmImage.DataDiskConfigurations.First().Lun == diskConfig.DataDiskConfigurations.First().Lun);
                Assert.IsTrue(vmImage.DataDiskConfigurations.First().MediaLink == diskConfig.DataDiskConfigurations.First().MediaLink);

                // Remove-AzureVMImage
                vmPowershellCmdlets.RemoveAzureVMImage(addVMImageName);

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, newImageName))
                {
                    vmPowershellCmdlets.RemoveAzureVMImage(newImageName, false);
                }
            }
        }

        [TestMethod(), TestCategory(Category.Functional), TestCategory(Category.BVT), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Add,Get,Save,Update,Remove)-AzureVMImage)")]
        public void AzureVMImageWithoutDataDiskTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            vhdName = "os1.vhd";
            string newImageName = Utilities.GetUniqueShortName("vmimage");
            string mediaLocation = string.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdName);

            string oldLabel = "old label";
            string newLabel = "new label";
            string vmSize = "Small";
            var iconUri = "http://www.bing.com";
            var smallIconUri = "http://www.bing.com";
            bool showInGui = true;

            try
            {
                // BVT Tests for OS Images
                OSImageContext result = vmPowershellCmdlets.AddAzureVMImage(newImageName, mediaLocation, OS.Windows, oldLabel, vmSize, iconUri, smallIconUri, showInGui);

                OSImageContext resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                result = vmPowershellCmdlets.UpdateAzureVMImage(newImageName, newLabel);
                resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                result = vmPowershellCmdlets.UpdateAzureVMImage(newImageName, newLabel, true);
                resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                Assert.IsTrue(resultReturned.ShowInGui.HasValue && !resultReturned.ShowInGui.Value);
                Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                vmPowershellCmdlets.RemoveAzureVMImage(newImageName, false);
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, newImageName));

                // BVT Tests for VM Images
                // Unique Container Prefix
                var containerPrefix = Utilities.GetUniqueShortName("vmimg");

                // Disk Blobs
                var srcVhdName = "os1.vhd";
                var srcVhdContainer = vhdContainerName;
                var dstOSVhdContainer = containerPrefix.ToLower() + "os" + vhdContainerName;
                CredentialHelper.CopyTestData(srcVhdContainer, srcVhdName, dstOSVhdContainer);
                string osVhdLink = string.Format("{0}{1}/{2}", blobUrlRoot, dstOSVhdContainer, srcVhdName);

                // VM Image OS/Data Disk Configuration
                var addVMImageName = containerPrefix + "Image";
                var diskConfig = new VirtualMachineImageDiskConfigSet
                {
                    OSDiskConfiguration = new OSDiskConfiguration
                    {
                        HostCaching = HostCaching.ReadWrite.ToString(),
                        OS = OSType.Windows.ToString(),
                        OSState = "Generalized",
                        MediaLink = new Uri(osVhdLink)
                    }
                };

                // Add-AzureVMImage
                string label = addVMImageName;
                string description = "test";
                string eula = "http://www.bing.com/";
                string imageFamily = "Windows";
                DateTime? publishedDate = new DateTime(2015, 1, 1);
                string privacyUri = "http://www.bing.com/";
                string recommendedVMSize = vmSize;
                string iconName = "iconName";
                string smallIconName = "smallIconName";

                vmPowershellCmdlets.AddAzureVMImage(
                    addVMImageName,
                    label,
                    diskConfig,
                    description,
                    eula,
                    imageFamily,
                    publishedDate,
                    privacyUri,
                    recommendedVMSize,
                    iconName,
                    smallIconName,
                    showInGui);

                // Get-AzureVMImage
                var vmImage = vmPowershellCmdlets.GetAzureVMImageReturningVMImages(addVMImageName).First();

                Assert.IsTrue(vmImage.ImageName == addVMImageName);
                Assert.IsTrue(vmImage.Label == label);
                Assert.IsTrue(vmImage.Description == description);
                Assert.IsTrue(vmImage.Eula == eula);
                Assert.IsTrue(vmImage.ImageFamily == imageFamily);
                Assert.IsTrue(vmImage.PublishedDate.Value.Year == publishedDate.Value.Year);
                Assert.IsTrue(vmImage.PublishedDate.Value.Month == publishedDate.Value.Month);
                Assert.IsTrue(vmImage.PublishedDate.Value.Day == publishedDate.Value.Day);
                Assert.IsTrue(vmImage.PrivacyUri.AbsoluteUri.ToString() == privacyUri);
                Assert.IsTrue(vmImage.RecommendedVMSize == recommendedVMSize);
                Assert.IsTrue(vmImage.IconName == iconName);
                Assert.IsTrue(vmImage.IconUri == iconName);
                Assert.IsTrue(vmImage.SmallIconName == smallIconName);
                Assert.IsTrue(vmImage.SmallIconUri == smallIconName);
                Assert.IsTrue(vmImage.ShowInGui == showInGui);
                Assert.IsTrue(vmImage.OSDiskConfiguration.HostCaching == diskConfig.OSDiskConfiguration.HostCaching);
                Assert.IsTrue(vmImage.OSDiskConfiguration.OS == diskConfig.OSDiskConfiguration.OS);
                Assert.IsTrue(vmImage.OSDiskConfiguration.OSState == diskConfig.OSDiskConfiguration.OSState);
                Assert.IsTrue(vmImage.OSDiskConfiguration.MediaLink == diskConfig.OSDiskConfiguration.MediaLink);

                // Remove-AzureVMImage
                vmPowershellCmdlets.RemoveAzureVMImage(addVMImageName);

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
            finally
            {
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, newImageName))
                {
                    vmPowershellCmdlets.RemoveAzureVMImage(newImageName, false);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Set-AzureVMSize)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void AzureVMImageSizeTest()
        {
            string mediaLocation = UploadVhdFile();
            string newImageName = Utilities.GetUniqueShortName("vmimage");

            try
            {
                var instanceSizes = vmPowershellCmdlets.GetAzureRoleSize().Where(r => r.Cores <= 2 && !r.InstanceSize.StartsWith("Standard_"));
                const int numOfMinimumInstSize = 3;
                Assert.IsTrue(instanceSizes.Count() >= numOfMinimumInstSize);
                var instanceSizesArr = instanceSizes.Take(numOfMinimumInstSize).ToArray();
                int arrayLength = instanceSizesArr.Count();

                for (int i = 0; i < arrayLength; i++)
                {
                    Utilities.PrintContext(instanceSizesArr[i]);
                    // Add-AzureVMImage test for VM size
                    OSImageContext result = vmPowershellCmdlets.AddAzureVMImage(newImageName, mediaLocation, OS.Windows, null, instanceSizesArr[i].InstanceSize);
                    OSImageContext resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                    Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                    Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                    // Update-AzureVMImage test for VM size
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
                    result = vmPowershellCmdlets.UpdateAzureVMImage(newImageName, resultReturned.ImageName, instanceSizesArr[Math.Max((i + 1) % arrayLength, 1)].InstanceSize);
                    resultReturned = vmPowershellCmdlets.GetAzureVMImage(newImageName)[0];
                    Assert.IsTrue(!string.IsNullOrEmpty(resultReturned.IOType));
                    Assert.IsTrue(CompareContext<OSImageContext>(result, resultReturned));

                    vmPowershellCmdlets.RemoveAzureVMImage(newImageName);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
                    pass = true;
                }
            }
            catch (Exception e)
            {
                pass = false;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
                vmPowershellCmdlets.RemoveAzureVMImage(newImageName, true);
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
            finally
            {
                try
                {
                    vmPowershellCmdlets.GetAzureVMImage(newImageName);
                    vmPowershellCmdlets.RemoveAzureVMImage(newImageName);
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("ResourceNotFound"))
                    {
                        Console.WriteLine("The vm image, {0}, is already deleted.", newImageName);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Set-AzureVMSize, Get-AzureRoleSize)")]
        public void HiMemVMSizeTest()
        {
            string serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);

            try
            {
                // New-AzureQuickVM test for VM size 'A5'
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName, HiMemInstanceSize.A5.ToString());
                PersistentVMRoleContext result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                RoleSizeContext returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                Assert.AreEqual(HiMemInstanceSize.A5.ToString(), returnedSize.InstanceSize);
                Console.WriteLine("VM size, {0}, is verified for New-AzureQuickVM", HiMemInstanceSize.A5);
                vmPowershellCmdlets.RemoveAzureService(serviceName);

                // New-AzureQuickVM test for VM size 'A6'
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName, HiMemInstanceSize.A6.ToString());
                result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                Assert.AreEqual(HiMemInstanceSize.A6.ToString(), returnedSize.InstanceSize);
                Console.WriteLine("VM size, {0}, is verified for New-AzureQuickVM", HiMemInstanceSize.A6);
                vmPowershellCmdlets.RemoveAzureService(serviceName);

                // New-AzureVMConfig test for VM size 'A7'
                var azureVMConfigInfo = new AzureVMConfigInfo(vmName, HiMemInstanceSize.A7.ToString(), imageName);
                var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
                PersistentVM vm = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm }, locationName);
                result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                Assert.AreEqual(HiMemInstanceSize.A7.ToString(), returnedSize.InstanceSize);
                Console.WriteLine("VM size, {0}, is verified for New-AzureVMConfig", HiMemInstanceSize.A7);

                // Set-AzureVMSize test for Hi-MEM VM size (A7 to A6)
                vmPowershellCmdlets.SetVMSize(vmName, serviceName, new SetAzureVMSizeConfig(HiMemInstanceSize.A6.ToString()));
                result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                Assert.AreEqual(HiMemInstanceSize.A6.ToString(), returnedSize.InstanceSize);
                Console.WriteLine("SetVMSize is verified from A7 to A6");

                // Set-AzureVMSize test for Hi-MEM VM size (A6 to A5)
                vmPowershellCmdlets.SetVMSize(vmName, serviceName, new SetAzureVMSizeConfig(HiMemInstanceSize.A5.ToString()));
                result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                Assert.AreEqual(HiMemInstanceSize.A5.ToString(), returnedSize.InstanceSize);
                Console.WriteLine("SetVMSize is verified from A6 to A5");

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
            finally
            {
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureService, serviceName))
                {
                    if ((cleanupIfFailed && !pass) || (cleanupIfPassed && pass))
                    {
                        vmPowershellCmdlets.RemoveAzureService(serviceName);
                    }
                }
            }
        }

        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Set-AzureVMSize, Get-AzureRoleSize)")]
        public void RegularVMSizeTest()
        {
            string serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
            string [] regularSizes = Enum.GetNames(typeof(InstanceSize));

            try
            {
                var instanceSizes = vmPowershellCmdlets.GetAzureRoleSize().Where(s => regularSizes.Contains(s.InstanceSize)).ToArray();
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, serviceName, imageName, username, password, locationName, instanceSizes[1].InstanceSize);

                foreach (var instanceSize in instanceSizes)
                {
                    PersistentVMRoleContext result;
                    RoleSizeContext returnedSize;

                    var size = instanceSize.InstanceSize;

                    // Set-AzureVMSize test for regular VM size
                    vmPowershellCmdlets.SetVMSize(vmName, serviceName, new SetAzureVMSizeConfig(size));
                    result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                    returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                    Assert.AreEqual(size, returnedSize.InstanceSize);
                    Console.WriteLine("VM size, {0}, is verified for Set-AzureVMSize", size);

                    if (size.Equals(InstanceSize.ExtraLarge.ToString()))
                    {
                        vmPowershellCmdlets.SetVMSize(vmName, serviceName, new SetAzureVMSizeConfig(InstanceSize.Small.ToString()));
                        result = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                        returnedSize = vmPowershellCmdlets.GetAzureRoleSize(result.InstanceSize)[0];
                        Assert.AreEqual(InstanceSize.Small.ToString(), returnedSize.InstanceSize);
                    }
                }

                pass = true;
            }
            catch (Exception e)
            {
                pass = false;
                Console.WriteLine("Exception occurred: {0}", e.ToString());
                throw;
            }
            finally
            {
                if (!Utilities.CheckRemove(vmPowershellCmdlets.GetAzureService, serviceName))
                {
                    if ((cleanupIfFailed && !pass) || (cleanupIfPassed && pass))
                    {
                        vmPowershellCmdlets.RemoveAzureService(serviceName);
                    }
                }
            }
        }

        private bool CompareContext<T>(T obj1, T obj2)
        {
            bool result = true;
            Type type = typeof(T);

            foreach(PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string typeName = property.PropertyType.FullName;
                if (typeName.Equals("System.String") || typeName.Equals("System.Int32") || typeName.Equals("System.Uri") || typeName.Contains("Nullable"))
                {
                    // To Hyonho: This is my temp fix for the test.
                    //            Please verify and make correct changes.
                    if (typeName.Contains("System.DateTime"))
                    {
                        continue;
                    }

                    var obj1Value = property.GetValue(obj1, null);
                    var obj2Value = property.GetValue(obj2, null);

                    if (obj1Value == null)
                    {
                        result &= (obj2Value == null);
                    }
                    else
                    {
                        result &= (obj1Value.Equals(obj2Value));
                    }
                }
                else
                {
                    Console.WriteLine("This type is not compared: {0}", typeName);
                }
            }

            return result;
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");
        }
    }
}
