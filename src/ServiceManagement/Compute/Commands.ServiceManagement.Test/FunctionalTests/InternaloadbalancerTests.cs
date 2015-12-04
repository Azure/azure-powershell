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
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class InternalLoadBalancerTests : ServiceManagementTest
    {
        private static string vnetName;
        private static string subNet;
        private const ProtocolInfo TCP_PROTOCAL = ProtocolInfo.tcp;
        private const ProtocolInfo UDP_PROTOCAL = ProtocolInfo.udp;
        private const int LOCAL_PORT_NUMBER1 = 60010;
        private const int PUBLIC_PORT_NUMBER1 = 60011;
        private const int LOCAL_PORT_NUMBER2 = 60012;
        private const int PUBLIC_PORT_NUMBER2 = 60013;
        private const int LOCAL_PORT_NUMBER3 = 60014;
        private const int PUBLIC_PORT_NUMBER3 = 60015;
        private string ipAddress;
        private string serviceName;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var vnetConfig = vmPowershellCmdlets.GetAzureVNetConfig(null);
            vmPowershellCmdlets.SetAzureVNetConfig(Directory.GetCurrentDirectory() + "\\VnetconfigWithLocation.netcfg");
            var sites = vmPowershellCmdlets.GetAzureVNetSite(null);
            subNet = sites[0].Subnets.First().Name;
            vnetName = sites[0].Name;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureVNetConfig(), "Remove Azure Vnet config after tests");
        }

        [TestInitialize]
        public void Intialize()
        {
            pass = false;
            cleanupIfPassed = true;
            serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);
            testStartTime = DateTime.Now;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (cleanupIfPassed)
                Utilities.ExecuteAndLog(() => CleanupService(serviceName), "Cleanup service");
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the New-AzureInternalLoadBalancerConfig,Add,Get,Remove-AzureInternalLoadBalancer cmdlets")]
        public void CreateDeploymentWithILBAndRemoveILB()
        {
            try
            {
                string ilbName = Utilities.GetUniqueShortName("ILB");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                var ilbConfig = vmPowershellCmdlets.NewAzureInternalLoadBalancerConfig(ilbName);

                Utilities.ExecuteAndLog(() =>
                {
                    var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password, false);
                    vmPowershellCmdlets.NewAzureVMWithInternalLoadBalancer(serviceName, new[] { vm }, ilbConfig, location: locationName);
                }, string.Format("Create a Vm with Internal load balancer {0}", ilbName));

                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);
                VerifyDeployment("Verify internal load balancer name of the deployment", ilbName);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureInternalLoadBalancer(serviceName), "Remove  Azure Internal Load Balancer");
                VerifyDeployment("Get azure deployment and verify that the deployment doesnt have ILB");
                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.InnerException.ToString());
                throw ex;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the New-AzureInternalLoadBalancerConfig,Add,Get,Remove-AzureInternalLoadBalancer cmdlets")]
        public void CreateDeploymentWithILBSubnetAndAddILBEndpoint()
        {
            try
            {
                string ilbName = Utilities.GetUniqueShortName("ILB");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string endpointName = Utilities.GetUniqueShortName("endpoint");

                var ilbConfig = vmPowershellCmdlets.NewAzureInternalLoadBalancerConfig(ilbName, subNet);

                Utilities.ExecuteAndLog(() =>
                {
                    var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password, false);
                    vm = vmPowershellCmdlets.SetAzureSubnet(vm, new string[] { subNet });
                    vmPowershellCmdlets.NewAzureVMWithInternalLoadBalancer(serviceName, new[] { vm }, ilbConfig, vnetName, locationName);
                }, string.Format("Create a Vm with Internal load balancer {0}", ilbName));

                ilbConfig.SubnetName = subNet;

                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);

                var endpointConfig = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, TCP_PROTOCAL, LOCAL_PORT_NUMBER1, PUBLIC_PORT_NUMBER1, endpointName, internalLoadBalancer: ilbName);
                Utilities.ExecuteAndLog(() =>
                {
                    var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                    endpointConfig.Vm = vmRoleContext.VM;
                    var vm = vmPowershellCmdlets.AddAzureEndPoint(endpointConfig);
                    vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                }, "Add Azure endpoint to the vm");

                VerifyEndpoint("Verify Azure endpoint", vmName, endpointConfig);
                VerifyDeployment("Verify internal load balancer name and vnet name of the deployment", ilbName, vnetName);
                ilbConfig.IPAddress = ipAddress;
                VerifyInternalLoadBalancer("Verify ILB name, subnet, ip address of the ILB", ilbConfig);
                pass = true;

            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.InnerException.ToString());
                throw ex;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the New-AzureInternalLoadBalancerConfig,Add,Get,Remove-AzureInternalLoadBalancer cmdlets")]
        public void CreateDeploymentWithILBIPaddressAndSetILBEndpoint()
        {
            try
            {
                string ilbName = Utilities.GetUniqueShortName("ILB");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string endpointName = Utilities.GetUniqueShortName("endpoint");
                IPAddress ipAddress = IPAddress.Parse(GetAvailableIpAddressinVnet());
                string lbsetName = Utilities.GetUniqueShortName("LbSet");

                var ilbConfig = vmPowershellCmdlets.NewAzureInternalLoadBalancerConfig(ilbName, subNet, ipAddress);

                Utilities.ExecuteAndLog(() =>
                {
                    var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password, false);
                    var endpointConfiginput = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.LoadBalancedNoProbe, TCP_PROTOCAL, LOCAL_PORT_NUMBER1, PUBLIC_PORT_NUMBER1, endpointName, lbsetName, null, false, ilbName);
                    endpointConfiginput.Vm = vm;
                    vm = vmPowershellCmdlets.AddAzureEndPoint(endpointConfiginput);
                    vmPowershellCmdlets.NewAzureVMWithInternalLoadBalancer(serviceName, new[] { vm }, ilbConfig, vnetName, locationName);
                }, string.Format("Create a Vm with Internal load balancer {0}", ilbName));

                ilbConfig.SubnetName = subNet;
                ilbConfig.IPAddress = ipAddress.ToString();
                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);


                var loadBalancerEndpointConfig = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.LoadBalancedNoProbe, UDP_PROTOCAL, LOCAL_PORT_NUMBER2, PUBLIC_PORT_NUMBER2, endpointName, lbsetName, internalLoadBalancer: ilbName, serviceName: serviceName);
                vmPowershellCmdlets.SetAzureLoadBalancedEndPoint(loadBalancerEndpointConfig, AzureEndPointConfigInfo.ParameterSet.LoadBalancedNoProbe);
                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);

                VerifyEndpoint("Verify Azure endpoint", vmName, loadBalancerEndpointConfig);
                VerifyDeployment("Verify internal load balancer name and vnet name of the deployment", ilbName, vnetName);
                ilbConfig.IPAddress = ipAddress.ToString();
                VerifyInternalLoadBalancer("Verify ILB name, subnet, ip address of the ILB", ilbConfig);
                pass = true;

            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.InnerException.ToString());
                throw ex;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the New-AzureInternalLoadBalancerConfig,Add,Get,Remove-AzureInternalLoadBalancer cmdlets")]
        public void ILBonExistingDeploymentAndDelete()
        {
            try
            {
                string ilbName = Utilities.GetUniqueShortName("ILB");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string endpointName = Utilities.GetUniqueShortName("endpoint");
                IPAddress ipAddress = IPAddress.Parse(GetAvailableIpAddressinVnet());
                string lbsetName = Utilities.GetUniqueShortName("LbSet");

                var ilbConfig = vmPowershellCmdlets.NewAzureInternalLoadBalancerConfig(ilbName, subNet, ipAddress);

                Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                        vmName, serviceName, imageName, username, password,
                        locationName, InstanceSize.Small.ToString(), false, null, vnetName);
                }, "Create a Vm using New-AzureQuickVM");

                vmPowershellCmdlets.AddAzureInternalLoadBalancer(ilbName, serviceName, subNet, ipAddress);
                ilbConfig.SubnetName = subNet;
                ilbConfig.IPAddress = ipAddress.ToString();
                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);
                Utilities.ExecuteAndLog(() => vmPowershellCmdlets.RemoveAzureInternalLoadBalancer(serviceName), "Remove  Azure Internal Load Balancer");
                pass = true;

            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.InnerException.ToString());
                throw ex;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the New-AzureInternalLoadBalancerConfig,Add,Get,Remove-AzureInternalLoadBalancer cmdlets")]
        public void ILBonExistingDeploymentWithVnet()
        {
            try
            {
                string ilbName = Utilities.GetUniqueShortName("ILB");
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string endpointName = Utilities.GetUniqueShortName("endpoint");
                IPAddress ipAddress = IPAddress.Parse(GetAvailableIpAddressinVnet());
                string lbsetName = Utilities.GetUniqueShortName("LbSet");

                var ilbConfig = vmPowershellCmdlets.NewAzureInternalLoadBalancerConfig(ilbName, subNet, ipAddress);

                Utilities.ExecuteAndLog(() =>
                {
                    vmPowershellCmdlets.NewAzureQuickVM(OS.Windows,
                        vmName, serviceName, imageName, username, password,
                        locationName, InstanceSize.Small.ToString(), false, null, vnetName);
                }, "Create a Vm using New-AzureQuickVM");

                vmPowershellCmdlets.AddAzureInternalLoadBalancer(ilbName, serviceName, subNet, ipAddress);
                ilbConfig.SubnetName = subNet;
                ilbConfig.IPAddress = ipAddress.ToString();
                VerifyInternalLoadBalancer("Verify Internal Load Balancer", ilbConfig);

                var endpointConfig = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, TCP_PROTOCAL, LOCAL_PORT_NUMBER1, PUBLIC_PORT_NUMBER1, endpointName, internalLoadBalancer: ilbName);
                Utilities.ExecuteAndLog(() =>
                {
                    var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                    endpointConfig.Vm = vmRoleContext.VM;
                    var vm = vmPowershellCmdlets.AddAzureEndPoint(endpointConfig);
                    vmPowershellCmdlets.UpdateAzureVM(vmName, serviceName, vm);
                }, "Add Azure endpoint to the vm");

                VerifyEndpoint("Verify Azure endpoint", vmName, endpointConfig);
                pass = true;

            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex.InnerException.ToString());
                throw ex;
            }
        }

        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("hylee"), Description("Test the Get/Set-AzurePublicIP cmdlets")]
        public void PublicIpPerVMTest()
        {
            try
            {
                string vmName = Utilities.GetUniqueShortName(vmNamePrefix);
                string vmName2 = Utilities.GetUniqueShortName(vmNamePrefix);

                string endpointName = Utilities.GetUniqueShortName("endpoint");
                string endpointName2 = Utilities.GetUniqueShortName("endpoint");

                string disklabel1 = Utilities.GetUniqueShortName("disk");
                string disklabel2 = Utilities.GetUniqueShortName("disk");

                string publicIpName = Utilities.GetUniqueShortName("publicIp");
                string publicIpName2 = Utilities.GetUniqueShortName("publicIp");

                vmPowershellCmdlets.NewAzureService(serviceName, locationName);
                var vm1 = CreateVMWithEndpointDataDiskAndPublicIP(vmName, endpointName, disklabel1, publicIpName, serviceName, LOCAL_PORT_NUMBER1, PUBLIC_PORT_NUMBER1);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm1 });

                VerifyPublicIP(publicIpName, vm1);

                var vm2 = CreateVMWithEndpointDataDiskAndPublicIP(vmName2, endpointName2, disklabel2, publicIpName2, serviceName, LOCAL_PORT_NUMBER2, PUBLIC_PORT_NUMBER2);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm2 });
                VerifyPublicIP(publicIpName2, vm2);
                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException);
                }
                throw ex;
            }
        }


        // The dns name on publicIP is currently in beta, remove Ignore flag once feature is in public
        [Ignore]
        [TestMethod(), Priority(0), TestProperty("Feature", "IaaS"), TestCategory(Category.Network), Owner("derajen"), Description("Test the Get/Set-AzurePublicIP cmdlets with domainNameLabel")]
        public void PublicIpDomainNameLabelVMTest()
        {
            try
            {
                string vmname = Utilities.GetUniqueShortName(vmNamePrefix);
                string endpointName = Utilities.GetUniqueShortName("endpoint");
                string disklabel1 = Utilities.GetUniqueShortName("disk");
                string publicIpName = Utilities.GetUniqueShortName("publicIp");
                string publicIpDomainNameLabel = Utilities.GetUniqueShortName("publicIpdns");

                vmPowershellCmdlets.NewAzureService(serviceName, locationName);
                var vm = CreateVMWithEndpointDataDiskAndPublicIP(vmname, endpointName, disklabel1, publicIpName, serviceName, LOCAL_PORT_NUMBER1, PUBLIC_PORT_NUMBER1, publicIpDomainNameLabel);
                vmPowershellCmdlets.NewAzureVM(serviceName, new[] { vm });

                VerifyPublicIP(publicIpName, vm);

                // Get azure VM
                var virtualMachine = vmPowershellCmdlets.GetAzureVM(vmname, serviceName);
                Assert.AreEqual(publicIpDomainNameLabel, virtualMachine.PublicIPDomainNameLabel);
                Assert.AreEqual(string.Format("{0}.{1}.cloudapp.net", publicIpDomainNameLabel, serviceName), virtualMachine.PublicIPFqdns[0]);
                Assert.AreEqual(string.Format("{0}.0.{1}.cloudapp.net", publicIpDomainNameLabel, serviceName), virtualMachine.PublicIPFqdns[1]);

                pass = true;
            }
            catch (Exception ex)
            {
                pass = false;
                Console.WriteLine(ex);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException);
                }
                throw ex;
            }
        }

        private static PersistentVM CreateVMWithEndpointDataDiskAndPublicIP(string vmName, string endpointName, string disklabel1, string publicIpName, string serviceName, int localPort, int publicport, string publicIpDomainNameLabel = null)
        {
            var vm1 = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);
            var endpointConfiginput = new AzureEndPointConfigInfo(AzureEndPointConfigInfo.ParameterSet.NoLB, TCP_PROTOCAL, localPort, publicport, endpointName, serviceName: serviceName);
            endpointConfiginput.Vm = vm1;
            vm1 = vmPowershellCmdlets.AddAzureEndPoint(endpointConfiginput);
            var dataDiskConfig1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, 128, disklabel1, 0);
            dataDiskConfig1.Vm = vm1;
            vm1 = vmPowershellCmdlets.AddAzureDataDisk(dataDiskConfig1);
            vm1 = (PersistentVM)vmPowershellCmdlets.SetAzurePublicIp(publicIpName, vm1, publicIpDomainNameLabel);
            return vm1;
        }

        private string GetAvailableIpAddressinVnet()
        {
            string[] ipList = new string[] { "10.0.0.5", "10.0.0.6", "10.0.0.7", "10.0.0.8", "10.0.0.9" };
            var result = vmPowershellCmdlets.TestAzureStaticVNetIP(vnetName, ipList[0]);
            if (result.IsAvailable)
                return ipList[0];
            else
                return result.AvailableAddresses[0];

        }



        private void VerifyEndpoint(string verificationMessage, string vmName, AzureEndPointConfigInfo endpointConfig)
        {
            Utilities.ExecuteAndLog(() =>
            {
                var vmRole = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                var endpointCollection = vmPowershellCmdlets.GetAzureEndPoint(vmRole.VM);

                var inputEndpointCollection = from c in endpointCollection where c.Name.Equals(endpointConfig.EndpointName) select c;
                var endpointConfigInfo = inputEndpointCollection.First();
                Console.WriteLine("Endpoint Configuraion Properties:");
                Utilities.PrintContext(endpointConfigInfo);
                ipAddress = endpointConfigInfo.Vip;
                Console.WriteLine("\n Verifing recquired properties");
                Utilities.LogAssert(() => Assert.AreEqual(string.IsNullOrEmpty(endpointConfig.LBSetName) ? null : endpointConfig.LBSetName, endpointConfigInfo.LBSetName), "LBSetName");
                Utilities.LogAssert(() => Assert.AreEqual(endpointConfig.EndpointLocalPort, endpointConfig.EndpointLocalPort), "EndpointLocalPort");
                Utilities.LogAssert(() => Assert.AreEqual(endpointConfig.EndpointName, endpointConfig.EndpointName), "EndpointName");
                Utilities.LogAssert(() => Assert.AreEqual(endpointConfig.EndpointProtocol, endpointConfig.EndpointProtocol), "EndpointProtocol");
                Utilities.LogAssert(() => Assert.AreEqual(endpointConfig.InternalLoadBalancerName, endpointConfig.InternalLoadBalancerName), "InternalLoadBalancerName");
            }, verificationMessage);
        }

        /// <summary>
        /// Verifies that the properties of the result of Get-azureInternalLoadBalancer is same as expected.
        /// </summary>
        /// <param name="ilbName"></param>
        private void VerifyInternalLoadBalancer(string verificationMessage, InternalLoadBalancerConfig expectedIlbConfig)
        {
            Utilities.ExecuteAndLog(() =>
            {
                var ilbConfig = vmPowershellCmdlets.GetAzureInternalLoadBalancer(serviceName);
                Console.WriteLine("ILB Context Properties:");
                Utilities.PrintContext(ilbConfig);
                Console.WriteLine("\n Verifing recquired properties");
                Utilities.LogAssert(() => Assert.AreEqual(expectedIlbConfig.InternalLoadBalancerName, ilbConfig.InternalLoadBalancerName), "InternalLoadBalancerName");
                Utilities.LogAssert(() => Assert.AreEqual(serviceName, ilbConfig.ServiceName), "ServiceName");
                Utilities.LogAssert(() => Assert.AreEqual(serviceName, ilbConfig.DeploymentName), "DeploymentName");
                Utilities.LogAssert(() => Assert.AreEqual(expectedIlbConfig.IPAddress, ilbConfig.IPAddress), "IPAddress");
                Utilities.LogAssert(() => Assert.AreEqual(expectedIlbConfig.SubnetName, ilbConfig.SubnetName), "SubnetName");

            }, verificationMessage);

        }

        private static void VerifyPublicIP(string publicIpName, PersistentVM vm1)
        {
            Utilities.ExecuteAndLog(() =>
            {
                var publicIpContext = vmPowershellCmdlets.GetAzurePublicIpName(publicIpName, vm1);
                Console.WriteLine("Public IP Context Properties:");
                Utilities.PrintContext(publicIpContext);
                Console.WriteLine("\n Verifing recquired properties");
                Utilities.LogAssert(() => Assert.AreEqual(publicIpName, publicIpContext.Name), "Public IP Name");
            }, "Verify Public ip of the VM");
        }

        private void VerifyDeployment(string verificationMessage, string internalLoadBalancerName = null, string vnet = null)
        {
            Utilities.ExecuteAndLog(() =>
            {
                var deploymentContext = vmPowershellCmdlets.GetAzureDeployment(serviceName);
                Console.WriteLine("Deployment Context Properties:");
                Utilities.PrintContext(deploymentContext);
                Console.WriteLine("\n Verifing recquired properties");
                Utilities.LogAssert(() => Assert.AreEqual(internalLoadBalancerName, deploymentContext.InternalLoadBalancerName), "InternalLoadBalancerName");
                Utilities.LogAssert(() =>
                {
                    if (internalLoadBalancerName == null)
                    {
                        Assert.AreEqual(deploymentContext.LoadBalancers.Count, 0);
                    }
                    else
                    {
                        Assert.AreEqual(internalLoadBalancerName, deploymentContext.LoadBalancers[0].Name);
                    }

                }, "LoadBalancers");
                Utilities.LogAssert(() => Assert.AreEqual(vnet, deploymentContext.VNetName), "VNetName");
            }, verificationMessage);
        }
    }
}
