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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class LBandEndPointACLsTest : ServiceManagementTest
    {
        private string serviceName;

        [TestInitialize]
        public void Initialize()
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            testStartTime = DateTime.Now;

            pass = false;
        }

        /// <summary>
        /// Test NoLB, NoProbe, DefaultProbe, CustomProbe parameter sets of Azure Endpoint cmdlets and Set-AzureLoadBalancedEndpoint cmdlet
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("priya"), Description("Test the cmdlets ((Add,Get,Set,Remove)-AzureEndpoint), & Set-AzureLoadBalancedEndpoint")]
        public void AzureEndpointTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string ep1Name = "tcp1";
            int ep1LocalPort = 60010;
            int ep1PublicPort = 60011;
            string ep1LBSetName = "lbset1";
            int ep1ProbePort = 60012;
            string ep1ProbePath = string.Empty;
            int? ep1ProbeInterval = 7;
            int? ep1ProbeTimeout = null;
            NetworkAclObject ep1AclObj = null;
            bool ep1DirectServerReturn = false;

            string ep2Name = "tcp2";
            int ep2LocalPort = 60020;
            int ep2PublicPort = 60021;
            int ep2LocalPortChanged = 60030;
            int ep2PublicPortChanged = 60031;
            string ep2LBSetName = "lbset2";
            int ep2ProbePort = 60022;
            string ep2ProbePath = @"/";
            int? ep2ProbeInterval = null;
            int? ep2ProbeTimeout = 32;
            NetworkAclObject ep2AclObj = null;
            bool ep2DirectServerReturn = false;


            AzureEndPointConfigInfo ep1Info = new AzureEndPointConfigInfo(
                AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                ProtocolInfo.tcp,
                ep1LocalPort,
                ep1PublicPort,
                ep1Name,
                ep1LBSetName,
                ep1ProbePort,
                ProtocolInfo.tcp,
                ep1ProbePath,
                ep1ProbeInterval,
                ep1ProbeTimeout,
                ep1AclObj,
                ep1DirectServerReturn);

            AzureEndPointConfigInfo ep2Info = new AzureEndPointConfigInfo(
                AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                ProtocolInfo.tcp,
                ep2LocalPort,
                ep2PublicPort,
                ep2Name,
                ep2LBSetName,
                ep2ProbePort,
                ProtocolInfo.http,
                ep2ProbePath,
                ep2ProbeInterval,
                ep2ProbeTimeout,
                ep2AclObj,
                ep2DirectServerReturn);

            string defaultVm = Utilities.GetUniqueShortName(vmNamePrefix);
            Assert.IsNull(vmPowershellCmdlets.GetAzureVM(defaultVm, serviceName));

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, defaultVm, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.", serviceName);

            try
            {
                foreach (AzureEndPointConfigInfo.ParameterSet p in Enum.GetValues(typeof(AzureEndPointConfigInfo.ParameterSet)))
                {
                    string pSetName = Enum.GetName(typeof(AzureEndPointConfigInfo.ParameterSet), p);
                    Console.WriteLine("--Begin Endpoint Test with '{0}' parameter set.", pSetName);

                    ep1Info.ParamSet = p;
                    ep2Info.ParamSet = p;
                    ep1Info.Acl = vmPowershellCmdlets.NewAzureAclConfig();
                    ep2Info.Acl = vmPowershellCmdlets.NewAzureAclConfig();
                    ep2Info.EndpointLocalPort = ep2LocalPort;
                    ep2Info.EndpointPublicPort = ep2PublicPort;

                    // Add two new endpoints
                    Console.WriteLine("-----Add 2 new endpoints.");
                    vmPowershellCmdlets.AddEndPoint(defaultVm, serviceName, new[] { ep1Info, ep2Info }); // Add-AzureEndpoint with Get-AzureVM and Update-AzureVm                             
                    CheckEndpoint(defaultVm, serviceName, new[] { ep1Info, ep2Info });

                    // Change the endpoint
                    if (p == AzureEndPointConfigInfo.ParameterSet.NoLB)
                    {
                        Console.WriteLine("-----Change the second endpoint.");
                        ep2Info.EndpointLocalPort = ep2LocalPortChanged;
                        ep2Info.EndpointPublicPort = ep2PublicPortChanged;
                        vmPowershellCmdlets.SetEndPoint(defaultVm, serviceName, ep2Info); // Set-AzureEndpoint with Get-AzureVM and Update-AzureVm                 
                        CheckEndpoint(defaultVm, serviceName, new[] { ep2Info });
                    }
                    else
                    {
                        Console.WriteLine("-----Change the second endpoint.");
                        ep2Info.ServiceName = serviceName;
                        ep2Info.EndpointLocalPort = ep2LocalPortChanged;
                        ep2Info.EndpointPublicPort = ep2PublicPortChanged;
                        vmPowershellCmdlets.SetLBEndPoint(defaultVm, serviceName, ep2Info, p);

                        CheckEndpoint(defaultVm, serviceName, new[] { ep2Info });
                    }

                    // Remove Endpoint
                    Console.WriteLine("-----Remove endpoints.");
                    vmPowershellCmdlets.RemoveEndPoint(defaultVm, serviceName, new[] { ep1Name, ep2Name }); // Remove-AzureEndpoint                
                    CheckEndpointRemoved(defaultVm, serviceName, new[] { ep1Info, ep2Info });

                    Console.WriteLine("Endpoint Test passed with '{0}' parameter set.", pSetName);
                }

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        /// <summary>
        /// Test NoLB, NoProbe, DefaultProbe, CustomProbe parameter sets of Azure Endpoint cmdlets and Set-AzureLoadBalancedEndpoint cmdlet
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("priya"), Description("Test the cmdlets ((Add,Get,Set,Remove)-AzureEndpoint), & Set-AzureLoadBalancedEndpoint")]
        public void AzureEndpointLBDTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string ep1Name = "tcp1";
            int ep1LocalPort = 60010;
            int ep1PublicPort = 60011;
            string ep1LBSetName = "lbset1";
            int ep1ProbePort = 60012;
            string ep1ProbePath = string.Empty;
            int? ep1ProbeInterval = 7;
            int? ep1ProbeTimeout = null;
            NetworkAclObject ep1AclObj = null;
            bool ep1DirectServerReturn = false;

            string ep2Name = "tcp2";
            int ep2LocalPort = 60020;
            int ep2PublicPort = 60021;
            int ep2LocalPortChanged = 60030;
            int ep2PublicPortChanged = 60031;
            string ep2LBSetName = "lbset2";
            int ep2ProbePort = 60022;
            string ep2ProbePath = @"/";
            int? ep2ProbeInterval = null;
            int? ep2ProbeTimeout = 32;
            NetworkAclObject ep2AclObj = null;
            bool ep2DirectServerReturn = false;

            AzureEndPointConfigInfo ep1Info = new AzureEndPointConfigInfo(
                AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                ProtocolInfo.tcp,
                ep1LocalPort,
                ep1PublicPort,
                ep1Name,
                ep1LBSetName,
                ep1ProbePort,
                ProtocolInfo.tcp,
                ep1ProbePath,
                ep1ProbeInterval,
                ep1ProbeTimeout,
                ep1AclObj,
                ep1DirectServerReturn,
                null,
                null,
                LoadBalancerDistribution.SourceIP);

            AzureEndPointConfigInfo ep2Info = new AzureEndPointConfigInfo(
                AzureEndPointConfigInfo.ParameterSet.CustomProbe,
                ProtocolInfo.tcp,
                ep2LocalPort,
                ep2PublicPort,
                ep2Name,
                ep2LBSetName,
                ep2ProbePort,
                ProtocolInfo.http,
                ep2ProbePath,
                ep2ProbeInterval,
                ep2ProbeTimeout,
                ep2AclObj,
                ep2DirectServerReturn,
                null,
                null,
                LoadBalancerDistribution.SourceIPProtorol);

            string defaultVm = Utilities.GetUniqueShortName(vmNamePrefix);
            Assert.IsNull(vmPowershellCmdlets.GetAzureVM(defaultVm, serviceName));

            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, defaultVm, serviceName, imageName, username, password, locationName);
            Console.WriteLine("Service Name: {0} is created.", serviceName);

            try
            {
                foreach (AzureEndPointConfigInfo.ParameterSet p in Enum.GetValues(typeof(AzureEndPointConfigInfo.ParameterSet)))
                {
                    string pSetName = Enum.GetName(typeof(AzureEndPointConfigInfo.ParameterSet), p);
                    Console.WriteLine("--Begin Endpoint Test with '{0}' parameter set.", pSetName);

                    ep1Info.ParamSet = p;
                    ep2Info.ParamSet = p;
                    //ep3Info.ParamSet = p;
                    ep1Info.Acl = vmPowershellCmdlets.NewAzureAclConfig();
                    ep2Info.Acl = vmPowershellCmdlets.NewAzureAclConfig();
                    ep2Info.EndpointLocalPort = ep2LocalPort;
                    ep2Info.EndpointPublicPort = ep2PublicPort;

                    // Add two new endpoints
                    Console.WriteLine("-----Add 2 new endpoints.");
                    vmPowershellCmdlets.AddEndPoint(defaultVm, serviceName, new[] { ep1Info, ep2Info }); // Add-AzureEndpoint with Get-AzureVM and Update-AzureVm                             
                    CheckEndpoint(defaultVm, serviceName, new[] { ep1Info, ep2Info });

                    // Change the endpoint
                    if (p == AzureEndPointConfigInfo.ParameterSet.NoLB)
                    {
                        Console.WriteLine("Skipping None until the bug is fixed..");
                    }
                    else
                    {
                        Console.WriteLine("-----Change the second endpoint.");
                        ep2Info.ServiceName = serviceName;
                        ep2Info.EndpointLocalPort = ep2LocalPortChanged;
                        ep2Info.EndpointPublicPort = ep2PublicPortChanged;
                        ep2Info.LoadBalancerDistribution = LoadBalancerDistribution.SourceIP;
                        vmPowershellCmdlets.SetLBEndPoint(defaultVm, serviceName, ep2Info, p);

                        CheckEndpoint(defaultVm, serviceName, new[] { ep2Info });
                    }

                    // Remove Endpoint
                    Console.WriteLine("-----Remove endpoints.");
                    vmPowershellCmdlets.RemoveEndPoint(defaultVm, serviceName, new[] { ep1Name, ep2Name }); // Remove-AzureEndpoint
                    CheckEndpointRemoved(defaultVm, serviceName, new[] { ep1Info, ep2Info });

                    Console.WriteLine("Endpoint Test passed with '{0}' parameter set.", pSetName);
                }

                pass = true;

            }
            catch (Exception e)
            {
                pass = false;
                Assert.Fail("Exception occurred: {0}", e.ToString());
            }
        }

        private bool CheckEndpoint(string vmName, string serviceName, AzureEndPointConfigInfo[] epInfos)
        {
            var serverEndpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(vmName, serviceName));

            // List the endpoints found for debugging.
            Console.WriteLine("***** Checking for Endpoints **************************************************");
            Console.WriteLine("***** Listing Returned Endpoints");
            foreach (InputEndpointContext ep in serverEndpoints)
            {
                Console.WriteLine("Endpoint - Name:{0} Protocol:{1} Port:{2} LocalPort:{3} Vip:{4}", ep.Name, ep.Protocol, ep.Port, ep.LocalPort, ep.Vip);

                if (!string.IsNullOrEmpty(ep.LBSetName))
                {
                    Console.WriteLine("\t- LBSetName:{0}", ep.LBSetName);
                    Console.WriteLine("\t- Probe - Port:{0} Protocol:{1} Interval:{2} Timeout:{3}", ep.ProbePort, ep.ProbeProtocol, ep.ProbeIntervalInSeconds, ep.ProbeTimeoutInSeconds);
                }
            }

            Console.WriteLine("*******************************************************************************");

            // Check if the specified endpoints were found.
            foreach (AzureEndPointConfigInfo epInfo in epInfos)
            {
                bool found = false;

                foreach (InputEndpointContext ep in serverEndpoints)
                {
                    if (epInfo.CheckInputEndpointContext(ep))
                    {
                        found = true;
                        Console.WriteLine("Endpoint found: {0}", epInfo.EndpointName);
                        break;
                    }
                }

                Assert.IsTrue(found, string.Format("Error: Endpoint '{0}' was not found!", epInfo.EndpointName));
            }

            return true;
        }

        private bool CheckEndpointRemoved(string vmName, string serviceName, AzureEndPointConfigInfo[] epInfos)
        {
            var serverEndpoints = vmPowershellCmdlets.GetAzureEndPoint(vmPowershellCmdlets.GetAzureVM(vmName, serviceName));

            // List the endpoints found for debugging.
            Console.WriteLine("***** Checking for Removed Endpoints ******************************************");
            Console.WriteLine("***** Listing Returned Endpoints");
            foreach (InputEndpointContext ep in serverEndpoints)
            {
                Console.WriteLine("Endpoint - Name:{0} Protocol:{1} Port:{2} LocalPort:{3} Vip:{4}", ep.Name, ep.Protocol, ep.Port, ep.LocalPort, ep.Vip);

                if (!string.IsNullOrEmpty(ep.LBSetName))
                {
                    Console.WriteLine("\t- LBSetName:{0}", ep.LBSetName);
                    Console.WriteLine("\t- Probe - Port:{0} Protocol:{1} Interval:{2} Timeout:{3}", ep.ProbePort, ep.ProbeProtocol, ep.ProbeIntervalInSeconds, ep.ProbeTimeoutInSeconds);
                }
            }

            Console.WriteLine("*******************************************************************************");

            // Check if the specified endpoints were found.
            foreach (AzureEndPointConfigInfo epInfo in epInfos)
            {
                bool found = false;

                foreach (InputEndpointContext ep in serverEndpoints)
                {
                    if (epInfo.CheckInputEndpointContext(ep))
                    {
                        found = true;
                        Console.WriteLine("Endpoint found: {0}", epInfo.EndpointName);
                        break;
                    }
                }

                Assert.IsFalse(found, string.Format("Error: Endpoint '{0}' was found!", epInfo.EndpointName));
            }

            return true;
        }

        /// <summary>
        /// Add an Endpoint with ACLs during deployment
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("priya"), Description("Test ACLs cmdlets New-AzureAclConfig, Set-AzureAclConfig")]
        public void AddEndPointACLsWithNewDeployment()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            string newAzureVM1Name = Utilities.GetUniqueShortName(vmNamePrefix);
            string newAzureVM2Name = Utilities.GetUniqueShortName(vmNamePrefix);
            if (string.IsNullOrEmpty(imageName))
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);

            vmPowershellCmdlets.NewAzureService(serviceName, serviceName, locationName);

            NetworkAclObject aclObj = vmPowershellCmdlets.NewAzureAclConfig();
            vmPowershellCmdlets.SetAzureAclConfig(SetACLConfig.AddRule, aclObj, 100, ACLAction.Permit, "172.0.0.0/8", "notes1");
            vmPowershellCmdlets.SetAzureAclConfig(SetACLConfig.AddRule, aclObj, 200, ACLAction.Deny, "10.0.0.0/8", "notes2");

            var azureVMConfigInfo1 = new AzureVMConfigInfo(newAzureVM1Name, InstanceSize.ExtraSmall.ToString(), imageName);
            var azureVMConfigInfo2 = new AzureVMConfigInfo(newAzureVM2Name, InstanceSize.ExtraSmall.ToString(), imageName);
            var azureProvisioningConfig = new AzureProvisioningConfigInfo(OS.Windows, username, password);
            var azureDataDiskConfigInfo = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 50, "datadisk1", 0);
            var azureEndPointConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.DefaultProbe, ProtocolInfo.tcp, 80, 80, "web", "lbweb", aclObj, true);

            var persistentVMConfigInfo1 = new PersistentVMConfigInfo(azureVMConfigInfo1, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);
            var persistentVMConfigInfo2 = new PersistentVMConfigInfo(azureVMConfigInfo2, azureProvisioningConfig, azureDataDiskConfigInfo, azureEndPointConfigInfo);

            PersistentVM persistentVM1 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo1);
            PersistentVM persistentVM2 = vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo2);

            PersistentVM[] VMs = { persistentVM1, persistentVM2 };
            vmPowershellCmdlets.NewAzureVM(serviceName, VMs);

            // Cleanup
            vmPowershellCmdlets.RemoveAzureVM(newAzureVM1Name, serviceName);
            vmPowershellCmdlets.RemoveAzureVM(newAzureVM2Name, serviceName);

            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVM1Name, serviceName));
            Assert.AreEqual(null, vmPowershellCmdlets.GetAzureVM(newAzureVM2Name, serviceName));
            pass = true;
        }

        /// <summary>
        /// Add an Endpoint with ACLs to an existing deployment
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("priya"), Description("Test ACLs cmdlets New-AzureAclConfig, Set-AzureAclConfig")]
        public void AddEndPointACLsonExistingDeployment()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            string newAzureQuickVMName = Utilities.GetUniqueShortName(vmNamePrefix);
            const string endpointName = "web";
            imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
            vmPowershellCmdlets.NewAzureQuickVM(OS.Windows, newAzureQuickVMName, serviceName, imageName, username,
                password, locationName);

            PersistentVMRoleContext vmRoleCtxt = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName);
            Assert.AreEqual(newAzureQuickVMName, vmRoleCtxt.Name, true);

            NetworkAclObject aclObj = vmPowershellCmdlets.NewAzureAclConfig();
            vmPowershellCmdlets.SetAzureAclConfig(SetACLConfig.AddRule, aclObj, 100, ACLAction.Deny, "172.0.0.0/8", "notes3");

            var epConfigInfo = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, ProtocolInfo.tcp,
                80, 80, endpointName, aclObj);

            vmPowershellCmdlets.AddEndPoint(newAzureQuickVMName, serviceName, new[] { epConfigInfo });

            var returnedVm = vmPowershellCmdlets.GetAzureVM(newAzureQuickVMName, serviceName);
            var returnedAclContext = vmPowershellCmdlets.GetAzureAclConfig(returnedVm.VM, endpointName);

            Assert.IsTrue(Verify.AzureAclConfig(aclObj, returnedAclContext));

            pass = true;
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Cleanup
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                Console.WriteLine("Starting to clean up created VM and service.");

                try
                {
                    vmPowershellCmdlets.RemoveAzureService(serviceName);
                    Console.WriteLine("Service, {0}, is deleted", serviceName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error during removing VM: {0}", e.ToString());
                }
            }
        }
    }
}
