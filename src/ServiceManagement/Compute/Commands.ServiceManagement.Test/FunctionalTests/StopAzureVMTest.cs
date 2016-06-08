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
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class StopAzureVMTest : ServiceManagementTest
    {
        string svcName;
        string vmName1;
        string vmName2;

        const string prefixVMName = "PSTestVM";

        const string unknownState = "RoleStateUnknown";
        const string creatingState = "CreatingVM";
        const string provisioningState = "Provisioning";
        const string readyState = "ReadyRole";
        const string startingState = "StartingVM";
        const string stoppedProvisionedState = "StoppedVM";
        const string stoppedDeallocatedState = "StoppedDeallocated";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            pass = false;
            testStartTime = DateTime.Now;

            // Create a unique service name
            svcName = Utilities.GetUniqueShortName("PSTestService");
            Console.WriteLine("Service Name: {0}", svcName);

            // Create a unique VM name
            vmName1 = Utilities.GetUniqueShortName(prefixVMName);
            Console.WriteLine("VM Name: {0}", vmName1);

            // Create a unique VM name
            vmName2 = Utilities.GetUniqueShortName(prefixVMName);
            Console.WriteLine("VM Name: {0}", vmName2);

            // Create a service
            try
            {
                vmPowershellCmdlets.NewAzureService(svcName, svcName, locationName);
                Console.WriteLine("Service Name: {0}", svcName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Could not create a service!!");
                Assert.Inconclusive();
            }
        }

        /// <summary>
        /// This test covers Stop-AzureVM -StayProvisioned with both parameter sets.
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void StopAzureVMStayProvisionedTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                WaitForStartingState(svcName, vmName1);
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, true); // Stop-AzureVM -StayProvisioned against VM1

                for (int i = 0; i < 10 ; i++)
                {
                    if (CheckRoleInstanceState(svcName, vmName1, new string[] {stoppedProvisionedState}))
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                // Stop-AzureVM -StayProvisioned against VM2
                vmPowershellCmdlets.RunPSScript(string.Format("{0} -ServiceName {1} -Name {2} | {3} -StayProvisioned",
                    Utilities.GetAzureVMCmdletName, svcName, vmName2, Utilities.StopAzureVMCmdletName));

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string [] {stoppedProvisionedState}));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string [] {stoppedProvisionedState}));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void StopAzureVMsStayProvisionedTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                WaitForStartingState(svcName, vmName1);
                WaitForStartingState(svcName, vmName2);

                vmPowershellCmdlets.StopAzureVM("*", svcName, true, true);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedProvisionedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        /// This test covers Stop-AzureVM with both parameter sets.
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void StopAzureVMDeprovisionedTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                // Stop and deallocate VM1
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                WaitForStartedState(svcName, vmName2);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState, provisioningState }));

                try
                {
                    // Try to Stop and deallocate VM2 without Force.  Should fail and give a warning message.
                    vmPowershellCmdlets.RunPSScript(string.Format("{0} -ServiceName {1} -Name {2} | {3}",
                        Utilities.GetAzureVMCmdletName, svcName, vmName2, Utilities.StopAzureVMCmdletName));
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState, provisioningState }));

                // Stop and deallocate VM2
                vmPowershellCmdlets.StopAzureVM(vmName2, svcName, false, true);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void StopAzureVMsDeprovisionedTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                WaitForReadyState(svcName, vmName1);
                WaitForReadyState(svcName, vmName2);

                var vm1 = vmPowershellCmdlets.GetAzureVM(vmName1, svcName);
                var vm2 = vmPowershellCmdlets.GetAzureVM(vmName2, svcName);

                Assert.AreEqual(vm1.HostName, vmName1);
                Assert.AreEqual(vm2.HostName, vmName2);

                // Stop and deallocate the VMs
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                // Start the VMs
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StartAzureVM("*", svcName), "HTTP Status Code: 409", 10, 60);
                //StartAzureVMs("*", svcName);

                WaitForStartedState(svcName, vmName1);
                WaitForStartedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState, provisioningState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState, provisioningState }));

                try
                {
                    // Try to Stop and deallocate VM2 without Force.  Should fail and give a warning message.
                    vmPowershellCmdlets.StopAzureVM("*", svcName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState, provisioningState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState, provisioningState }));

                // Stop and deallocate VMs
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        /// This test covers Stop-AzureVM -Force with both parameter sets
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void StopAzureVMOnStoppedVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                PersistentVM[] VMs = { persistentVM1 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);

                WaitForStartingState(svcName, vmName1);

                // Stop the VM with StayProvisioned
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                // Try to stop it again.  Should not change the state.
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                try
                {
                    // Try to stop without any option.  Should fail with a warning message.
                    vmPowershellCmdlets.StopAzureVM(vmName1, svcName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                // Stop the VM with Force option.   Should deallocate the VM.
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, false, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void StopAzureVMsOnStoppedVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // Configure VM1
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                // Configure VM2
                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                WaitForStartingState(svcName, vmName1);
                WaitForStartingState(svcName, vmName2);

                // Stop the VMs with StayProvisioned
                vmPowershellCmdlets.StopAzureVM("*", svcName, true, true);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedProvisionedState }));

                // Try to stop again.  Should not change the state.
                vmPowershellCmdlets.StopAzureVM("*", svcName, true, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedProvisionedState }));

                try
                {
                    // Try to stop without any option.  Should fail with a warning message.
                    vmPowershellCmdlets.StopAzureVM("*", svcName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedProvisionedState }));

                // Stop the VM with Force option.   Should deallocate the VM.
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void StopAzureVMOnDeallocatedVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                PersistentVM[] VMs = { persistentVM1 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);

                //WaitForStartingState(svcName, vmName1);

                // Stop and deallocate the VM
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, false, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                try
                {
                    // Try to stop the VM with StayProvisioned.  Should fail.
                    vmPowershellCmdlets.StopAzureVM(vmName1, svcName, true);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                try
                {
                    // Try to stop the VM without any option.  Should fail and give a warning message.
                    vmPowershellCmdlets.StopAzureVM(vmName1, svcName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                // Try to stop and deallocate the VM again.
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, false, true);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void StopAzureVMsOnDeallocatedVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // Configure VM1
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                // Configure VM2
                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };
                vmPowershellCmdlets.NewAzureVM(svcName, VMs, null, true);
                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                // Stop and deallocate the VMs
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);
                
                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                try
                {
                    // Try to stop the VMs with StayProvisioned.  Should fail.
                    vmPowershellCmdlets.StopAzureVM("*", svcName, true, true);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                try
                {
                    // Try to stop the VMs without any option.  Should fail and give a warning message.
                    vmPowershellCmdlets.StopAzureVM("*", svcName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                // Try to stop and deallocate the VM again.
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);
                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void RestartAzureVMTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                DateTime prevTime = DateTime.Now;

                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                PersistentVM[] VMs = { persistentVM1 };

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.NewAzureVM(svcName, VMs, null, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName1, svcName).InstanceStatus);

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.StartAzureVM(vmName1, svcName);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForReadyState(svcName, vmName1);
                Utilities.RecordTimeTaken(ref prevTime);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void RestartAzureVMsTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                DateTime prevTime = DateTime.Now;

                // Configure VM1
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                // Configure VM2
                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.NewAzureVM(svcName, VMs, null, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName1, svcName).InstanceStatus);
                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName2, svcName).InstanceStatus);

                // Stop VM1 one only using wildcard name
                string vm1WildcardName = vmName1.Replace(prefixVMName, "*");
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StopAzureVM(vm1WildcardName, svcName, true, true), "HTTP Status Code: 409", 10, 60);
                //StopAzureVMs(vm1WildcardName, svcName, true, true);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForStoppedState(svcName, vmName1);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));

                // Start VM1 one only using wildcard name
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StartAzureVM(vm1WildcardName, svcName), "HTTP Status Code: 409", 10, 60);                
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForReadyState(svcName, vmName1);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState }));
                
                // Stop all VM's
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StopAzureVM("*", svcName, true, true), "HTTP Status Code: 409", 10, 60);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedProvisionedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedProvisionedState }));

                //Start all VM's
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StartAzureVM("*", svcName), "HTTP Status Code: 409", 10, 60);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForReadyState(svcName, vmName1);
                WaitForReadyState(svcName, vmName2);

                Utilities.RecordTimeTaken(ref prevTime);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM)")]
        public void RestartAzureVMAfterDeallocateTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                DateTime prevTime = DateTime.Now;

                // starting the test.
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                PersistentVM[] VMs = { persistentVM1 };

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.NewAzureVM(svcName, VMs, null, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Console.WriteLine("The VM is successfully created: {0}", vmName1);

                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName1, svcName).InstanceStatus);

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.StopAzureVM(vmName1, svcName, false, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                for (int i = 0 ; i < 10 ; i++)
                {
                    try
                    {
                        Utilities.RecordTimeTaken(ref prevTime);
                        vmPowershellCmdlets.StartAzureVM(vmName1, svcName);
                        Utilities.RecordTimeTaken(ref prevTime);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Thread.Sleep(60 * 1000);
                    }
                }

                WaitForReadyState(svcName, vmName1);
                Utilities.RecordTimeTaken(ref prevTime);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new [] { readyState }));

                var vm = vmPowershellCmdlets.GetAzureVM(vmName1, svcName).VM;
                var vmSizeConfig = new SetAzureVMSizeConfig(InstanceSize.Medium.ToString());
                vmSizeConfig.Vm = vm;
                vm = vmPowershellCmdlets.SetAzureVMSize(vmSizeConfig);
                vmPowershellCmdlets.UpdateAzureVM(vmName1, svcName, vm);

                vm = vmPowershellCmdlets.GetAzureVM(vmName1, svcName).VM;
                Console.WriteLine("RoleSize: {0}", vm.RoleSize);
                Assert.AreEqual(InstanceSize.Medium.ToString(), vm.RoleSize);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }


        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Stop-AzureVM) using wildcard syntax")]
        public void RestartAzureVMsAfterDeallocateTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                // starting the test.
                DateTime prevTime = DateTime.Now;

                // Configure VM1
                var azureVMConfigInfo1 = new AzureVMConfigInfo(vmName1, InstanceSize.ExtraSmall.ToString(), imageName);
                var azureProvisioningConfig1 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig1, null, null);
                PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);

                // Configure VM2
                var azureVMConfigInfo2 = new AzureVMConfigInfo(vmName2, InstanceSize.Small.ToString(), imageName);
                var azureProvisioningConfig2 = new AzureProvisioningConfigInfo(OS.Windows, username, password);
                var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig2, null, null);
                PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

                PersistentVM[] VMs = { persistentVM1, persistentVM2 };

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.NewAzureVM(svcName, VMs, null, true);
                Utilities.RecordTimeTaken(ref prevTime);

                Console.WriteLine("The VM is successfully created: {0}", vmName1);
                Console.WriteLine("The VM is successfully created: {0}", vmName2);

                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName1, svcName).InstanceStatus);
                Console.WriteLine(vmPowershellCmdlets.GetAzureVM(vmName2, svcName).InstanceStatus);

                // Stop VM1 one only using wildcard name
                string vm1WildcardName = vmName1.Replace(prefixVMName, "*");
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StopAzureVM(vm1WildcardName, svcName, false, true), "HTTP Status Code: 409", 10, 60);                
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForStoppedState(svcName, vmName1);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));

                // Start VM1 one only using wildcard name
                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StartAzureVM(vm1WildcardName, svcName), "HTTP Status Code: 409", 10, 60);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForReadyState(svcName, vmName1);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState }));

                Utilities.RecordTimeTaken(ref prevTime);
                vmPowershellCmdlets.StopAzureVM("*", svcName, false, true);
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForStoppedState(svcName, vmName1);
                WaitForStoppedState(svcName, vmName2);

                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { stoppedDeallocatedState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { stoppedDeallocatedState }));

                Utilities.RecordTimeTaken(ref prevTime);
                Utilities.RetryActionUntilSuccess(() => vmPowershellCmdlets.StartAzureVM("*", svcName), "HTTP Status Code: 409", 10, 60);                
                Utilities.RecordTimeTaken(ref prevTime);

                WaitForReadyState(svcName, vmName1);
                WaitForReadyState(svcName, vmName2);
                Utilities.RecordTimeTaken(ref prevTime);
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName1, new string[] { readyState }));
                Assert.IsTrue(CheckRoleInstanceState(svcName, vmName2, new string[] { readyState }));

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
                {
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="svc">Service Name</param>
        /// <param name="vm">VM Name</param>
        /// <param name="expStates">An array of expected states. This should not be null</param>
        /// <returns></returns>
        private bool CheckRoleInstanceState(string svc, string vm, string[] expStates)
        {
            List<string> exps = new List<string>(expStates);
            string instanceState = vmPowershellCmdlets.GetAzureVM(vm, svc).InstanceStatus;
            var vmRoleCOntext = vmPowershellCmdlets.GetAzureVM(vm, svc);
            Console.WriteLine("Role instaces: {0}", vmRoleCOntext.InstanceStatus);
            return exps.Contains(vmRoleCOntext.InstanceStatus);
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                try
                {
                    Console.WriteLine("Starting to clean up created VM and service.");
                    vmPowershellCmdlets.RemoveAzureService(svcName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
        }

        internal static void WaitForStatus(string svcName, string vmName, string[] expStatus, string[] skipStatus, int interval, int maxTry)
        {
            string vmStatus = string.Empty;

            List<string> exps = new List<string>(expStatus);
            List<string> skips = null;
            if (skipStatus != null)
            {
                skips = new List<string>(skipStatus);
            }

            int totalWaitTimeInSeconds = 0;
            for (int i = 0; i < maxTry; i++)
            {
                var vm = vmPowershellCmdlets.GetAzureVM(vmName, svcName);
                if (vm == null)
                {
                    Assert.Fail("The VM is deleted!!!");
                }
                else
                {
                    vmStatus = vmPowershellCmdlets.GetAzureVM(vmName, svcName).InstanceStatus;
                }

                if (exps.Contains(vmStatus))
                {
                    Console.WriteLine("The VM is in {0} state after {1} seconds", vmStatus, totalWaitTimeInSeconds);
                    return;
                }
                else if (skips == null || skips.Contains(vmStatus))
                {
                    // waitTimeInSeconds = interval * (2 ^ (i / 10))
                    int waitTimeInSeconds = interval * (1 << (i / 10));
                    totalWaitTimeInSeconds += waitTimeInSeconds;
                    Console.WriteLine("Total wait time = {0} second(s), by {1} {2}.", totalWaitTimeInSeconds, (i + 1), i == 0 ? "retry" : "retries");
                    Console.WriteLine("Current VM state is {0}. Keep waiting for {1} second(s)...", vmStatus, waitTimeInSeconds);
                    Thread.Sleep(TimeSpan.FromSeconds(waitTimeInSeconds));
                }
                else
                {
                    Console.WriteLine("Role status is {0}", vmStatus);
                    Assert.Fail("The VM does not become ready.");
                }
            }

            Console.WriteLine("Role status is still {0} after {1} seconds", vmStatus, totalWaitTimeInSeconds);
            Assert.Fail("The VM does not become ready within a given time.");
        }

        internal static void WaitForReadyState(string svc, string vm, int interval = 20, int maxTry = 30)
        {
            //WaitForStatus(svc, vm, new string[] { readyState }, new string[] { unknownState, creatingState, provisioningState, startingState }, interval, maxTry);
            WaitForStatus(svc, vm, new string[] { readyState }, null, interval, maxTry);
        }

        internal static void WaitForStartedState(string svc, string vm, int interval = 20, int maxTry = 30)
        {
            //WaitForStatus(svc, vm, new string[] { readyState, provisioningState }, new string[] { unknownState, creatingState, startingState }, interval, maxTry);
            WaitForStatus(svc, vm, new string[] { readyState, provisioningState }, null, interval, maxTry);
        }

        internal static void WaitForStartingState(string svc, string vm, int interval = 20, int maxTry = 30)
        {
            //WaitForStatus(svc, vm, new string[] { creatingState, provisioningState, readyState, startingState }, new string[] { unknownState }, interval, maxTry);
            WaitForStatus(svc, vm, new string[] { creatingState, provisioningState, readyState, startingState }, null, interval, maxTry);
        }

        internal static void WaitForStoppedState(string svc, string vm, int interval = 20, int maxTry = 30)
        {
            //WaitForStatus(svc, vm, new string[] { stoppedDeallocatedState, stoppedProvisionedState }, new string[] { unknownState, provisioningState, readyState }, interval, maxTry);
            WaitForStatus(svc, vm, new string[] { stoppedDeallocatedState, stoppedProvisionedState }, null, interval, maxTry);
        }
    }
}
