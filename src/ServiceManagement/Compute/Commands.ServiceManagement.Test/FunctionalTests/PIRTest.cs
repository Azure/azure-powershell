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
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class PIRTest : ServiceManagementTest
    {
        private const string vhdNamePrefix = "pirtestosvhd";
        private const string imageNamePrefix = "pirtestosimage";

        private string vhdName;
        private string vhdBlobLocation;
        private string image;

        private const string location1 = "West US";
        private const string location2 = "North Central US";
        private const string location3 = "East US";

        private static string publisher = "publisher1";
        private static string publisherSubId = "602258C5-52EC-46B3-A49A-7587A764AC84";
        private static string normaluser = "normaluser2";
        private const string normaluserSubId = "602258C5-52EC-46B3-A49A-7587A764AC84";

        private const string storageNormalUser = "normalstorage";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            if (vmPowershellCmdlets.GetAzureSubscription(publisherSubId) == null)
            {
                publisher = defaultAzureSubscription.SubscriptionName;
            }

            if (vmPowershellCmdlets.GetAzureSubscription(normaluserSubId) == null)
            {
                normaluser = defaultAzureSubscription.SubscriptionName;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            vhdName = Utilities.GetUniqueShortName(vhdNamePrefix);
            image = Utilities.GetUniqueShortName(imageNamePrefix);
            
            vhdBlobLocation = string.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdName);

            try
            {
                if (string.IsNullOrEmpty(localFile))
                {
                    vmPowershellCmdlets.AddAzureVhd(new FileInfo(osVhdName), vhdBlobLocation);
                }
                else
                {
                    vmPowershellCmdlets.AddAzureVhd(new FileInfo(localFile), vhdBlobLocation);
                }
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("already exists") || e.ToString().Contains("currently a lease"))
                {
                    // Use the already uploaded vhd.
                    Console.WriteLine("Using already uploaded blob..");
                }
                else
                {
                    Console.WriteLine(e.ToString());
                    Assert.Inconclusive("Upload vhd is not set!");
                }
            }

            try
            {
                vmPowershellCmdlets.AddAzureVMImage(image, vhdBlobLocation, OS.Windows);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            pass = false;
            testStartTime = DateTime.Now;
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            SwitchToPublisher();
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                Console.WriteLine("Starting to clean up created VM and service.");

                try
                {
                    vmPowershellCmdlets.RemoveAzureVMImage(image, false);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occurs during cleanup: {0}", e.ToString());
                }

                try
                {
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// This test covers Get-AzurePlatformVMImage, Set-AzurePlatformVMImage and Remove-AzurePlatformVMImage cmdlets
        /// </summary>
        [TestMethod(), TestCategory("PIRTest"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get,Set,Remove)-AzurePlatformVMImage)")]
        public void AzurePlatformVMImageSingleLocationTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                // Replicate the user image to "West US" and wait until the replication process is completed.
                ComputeImageConfig compCfg = new ComputeImageConfig
                {
                    Offer = "test",
                    Sku = "test",
                    Version = "test"
                };
                MarketplaceImageConfig marketCfg = null;
                vmPowershellCmdlets.SetAzurePlatformVMImageReplicate(image, new string[] { location1 }, compCfg, marketCfg);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));
                WaitForReplicationComplete(image);

                // Make the replicated image public and wait until the PIR image shows up.
                vmPowershellCmdlets.SetAzurePlatformVMImagePublic(image);
                OSImageContext pirImage = WaitForPIRAppear(image, publisher);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                // Check the locations of the PIR image.
                string pirlocations = vmPowershellCmdlets.GetAzureVMImage(pirImage.ImageName)[0].Location;
                Assert.IsTrue(pirlocations.Contains(location1));
                Assert.IsFalse(pirlocations.Contains(location2));
                Assert.IsFalse(pirlocations.Contains(location3));

                // Switch to the normal User and check the PIR image.
                SwitchToNormalUser();
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, image));
                WaitForPIRAppear(image, publisher);

                // Switch to the publisher and make the PIR image private
                SwitchToPublisher();
                vmPowershellCmdlets.SetAzurePlatformVMImagePrivate(image);

                // Switch to the normal User and wait until the PIR image disapper
                SwitchToNormalUser();
                WaitForPIRDisappear(pirImage.ImageName);

                // Switch to the publisher and remove the PIR image.
                SwitchToPublisher();
                vmPowershellCmdlets.RemoveAzurePlatformVMImage(image);
                Assert.AreEqual(0, vmPowershellCmdlets.GetAzurePlatformVMImage(image).ReplicationProgress.Count);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// This test covers Get-AzurePlatformVMImage, Set-AzurePlatformVMImage and Remove-AzurePlatformVMImage cmdlets
        /// </summary>
        [TestMethod(), TestCategory("PIRTest"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get,Set,Remove)-AzurePlatformVMImage)")]
        public void AzurePlatformVMImageMultipleLocationsTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                // Replicate the user image to "West US" and wait until the replication process is completed.
                ComputeImageConfig compCfg = new ComputeImageConfig
                {
                    Offer = "test",
                    Sku = "test",
                    Version = "test"
                };
                MarketplaceImageConfig marketCfg = null;
                vmPowershellCmdlets.SetAzurePlatformVMImageReplicate(image, new string[] { location1, location2 }, compCfg, marketCfg);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));
                WaitForReplicationComplete(image);

                // Make the replicated image public and wait until the PIR image shows up.
                vmPowershellCmdlets.SetAzurePlatformVMImagePublic(image);
                OSImageContext pirImage = WaitForPIRAppear(image, publisher);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                // Check the locations of the PIR image.
                string pirlocations = vmPowershellCmdlets.GetAzureVMImage(pirImage.ImageName)[0].Location;
                Assert.IsTrue(pirlocations.Contains(location1));
                Assert.IsTrue(pirlocations.Contains(location2));
                Assert.IsFalse(pirlocations.Contains(location3));

                // Switch to the normal User and check the PIR image.
                SwitchToNormalUser();
                Assert.IsTrue(Utilities.CheckRemove(vmPowershellCmdlets.GetAzureVMImage, image));
                WaitForPIRAppear(image, publisher);

                // Switch to the publisher and make the PIR image private
                SwitchToPublisher();
                vmPowershellCmdlets.SetAzurePlatformVMImagePrivate(image);

                // Switch to the normal User and wait until the PIR image disapper
                SwitchToNormalUser();
                WaitForPIRDisappear(pirImage.ImageName);

                // Switch to the publisher and remove the PIR image.
                SwitchToPublisher();
                vmPowershellCmdlets.RemoveAzurePlatformVMImage(image);
                Assert.AreEqual(0, vmPowershellCmdlets.GetAzurePlatformVMImage(image).ReplicationProgress.Count);
                PrintOSImageDetailsContext(vmPowershellCmdlets.GetAzurePlatformVMImage(image));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// This test covers Get-AzurePlatformVMImage, Set-AzurePlatformVMImage and Remove-AzurePlatformVMImage cmdlets
        /// </summary>
        [TestMethod(), TestCategory("PIRTest"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get,Set,Remove)-AzurePlatformVMImage)")]
        public void AzurePlatformVMImageScenarioTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string vmName = Utilities.GetUniqueShortName("pirtestvm");
            string svcName = Utilities.GetUniqueShortName("pirtestservice");

            try
            {
                SwitchToNormalUser();

                try
                {
                    vmPowershellCmdlets.GetAzureStorageAccount(storageNormalUser);
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("ResourceNotFound"))
                    {
                        vmPowershellCmdlets.NewAzureStorageAccount(storageNormalUser, location1);
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                        throw;
                    }
                }
                vmPowershellCmdlets.SetAzureSubscription(normaluserSubId, storageNormalUser);

                // Replicate the user image to "West US" and wait until the replication process is completed.
                SwitchToPublisher();
                ComputeImageConfig compCfg = new ComputeImageConfig
                {
                    Offer = "test",
                    Sku = "test",
                    Version = "test"
                };
                MarketplaceImageConfig marketCfg = null;
                vmPowershellCmdlets.SetAzurePlatformVMImageReplicate(image, new string[] { location1 }, compCfg, marketCfg);

                // Make the replicated image public and wait until the PIR image shows up.
                vmPowershellCmdlets.SetAzurePlatformVMImagePublic(image);
                OSImageContext pirImage = WaitForPIRAppear(image, publisher);

                // Switch to the normal User and check the PIR image.
                SwitchToNormalUser();
                WaitForPIRAppear(image, publisher);

                // Create a VM using the PIR image
                vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, vmName, svcName, pirImage.ImageName, username, password, location1);
                Console.WriteLine("VM, {0}, is successfully created using the uploaded PIR image", vmPowershellCmdlets.GetAzureVM(vmName, svcName).Name);

                // Remove the service and VM
                vmPowershellCmdlets.RemoveAzureService(svcName);

                // Switch to the publisher and remove the PIR image
                SwitchToPublisher();
                vmPowershellCmdlets.RemoveAzurePlatformVMImage(image);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private void SwitchToPublisher()
        {
            vmPowershellCmdlets.SetDefaultAzureSubscription(publisherSubId);
        }

        private void SwitchToNormalUser()
        {
            vmPowershellCmdlets.SetDefaultAzureSubscription(normaluserSubId);
        }

        private void WaitForReplicationComplete(string imageName)
        {
            DateTime startTime = DateTime.Now;
            OSImageDetailsContext state;
            try
            {
                do
                {
                    state = vmPowershellCmdlets.GetAzurePlatformVMImage(imageName);
                    foreach(var repro in state.ReplicationProgress)
                    {
                        Console.WriteLine(repro.ToString());
                    }
                }
                while (!state.ReplicationProgress.TrueForAll((s) => (s.Progress.Equals("100"))));

                Console.WriteLine("Replication completed after {0} minutes.", (DateTime.Now - startTime).TotalMinutes);
                PrintOSImageDetailsContext(state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private OSImageContext WaitForPIRAppear(string imageName, string publisherName, int waitTimeInMin = 1, int maxWaitTimeInMin = 30)
        {

            DateTime startTime = DateTime.Now;
            while (true)
            {
                Collection<OSImageContext> vmImages = vmPowershellCmdlets.GetAzureVMImage();
                foreach (OSImageContext image in vmImages)
                {
                    if (Utilities.MatchKeywords(image.ImageName, new[]{imageName}, false) >= 0 && image.PublisherName.Equals(publisherName))
                    {
                        Console.WriteLine("MATCHED PIR image found after {0} minutes:", (DateTime.Now - startTime).TotalMinutes);
                        PrintContext<OSImageContext>(image);
                        return image;
                    }
                }

                if ((DateTime.Now - startTime).TotalMinutes < maxWaitTimeInMin)
                {
                    Thread.Sleep(waitTimeInMin * 1000 * 60);
                }
                else
                {
                    Assert.Fail("Cannot get PIR image, {0}, within {1} minutes!", imageName, maxWaitTimeInMin);
                }
            }
        }

        private bool WaitForPIRDisappear(string imageName, int waitTimeInMin = 1, int maxWaitTimeInMin = 30)
        {

            DateTime startTime = DateTime.Now;
            while (true)
            {
                try
                {
                    OSImageContext imageContext = vmPowershellCmdlets.GetAzureVMImage(imageName)[0];

                    if ((DateTime.Now - startTime).TotalMinutes < maxWaitTimeInMin)
                    {
                        Thread.Sleep(waitTimeInMin * 1000 * 60);
                    }
                    else
                    {
                        Assert.Fail("Still has image, {0}, after {1} minutes!", imageName, maxWaitTimeInMin);
                    }
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("ResourceNotFound"))
                    {
                        Console.WriteLine("Image {0} disappered after {1} minutes.", imageName, (DateTime.Now - startTime).TotalMinutes);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                        throw;
                    }
                }
            }
        }

        private void PrintContext<T>(T obj)
        {
            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string typeName = property.PropertyType.FullName;
                if (typeName.Equals("System.String") || typeName.Equals("System.Int32") || typeName.Equals("System.Uri") || typeName.Contains("Nullable"))
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(obj, null));
                }
            }
        }

        private void PrintOSImageDetailsContext(OSImageDetailsContext context)
        {
            PrintContext<OSImageContext>(context);
            foreach (var repro in context.ReplicationProgress)
            {
                Console.WriteLine("ReplicationProgress: {0}", repro.ToString());
            }
            if (context.ReplicationProgress.Count == 0)
            {
                Console.WriteLine("There is no replication!");
            }

            Console.WriteLine("IsCorrupted {0}", context.IsCorrupted);
        }
    }
}
