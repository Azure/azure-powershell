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
    public class Verify : ServiceManagementTest
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="availabilitySetName"></param>
        /// <returns></returns>
        internal static bool AzureAvailabilitySet(PersistentVM vm, string availabilitySetName)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.AvailabilitySetName))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(availabilitySetName));
                }
                else
                {
                    Assert.IsTrue(vm.AvailabilitySetName.Equals(availabilitySetName, StringComparison.InvariantCultureIgnoreCase));
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (e is AssertFailedException)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="expThumbprint"></param>
        /// <param name="expAlgorithm"></param>
        /// <param name="expData"></param>
        /// <returns></returns>
        internal static bool AzureCertificate(string svc, string expThumbprint, string expAlgorithm, string expData)
        {
            try
            {
                CertificateContext result = vmPowershellCmdlets.GetAzureCertificate(svc)[0];

                Assert.AreEqual(expThumbprint, result.Thumbprint);
                Assert.AreEqual(expAlgorithm, result.ThumbprintAlgorithm);
                Assert.AreEqual(expData, result.Data);
                Assert.AreEqual(svc, result.ServiceName);
                //Assert.AreEqual(expUrl, result.Url);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="expLabel"></param>
        /// <param name="expSize"></param>
        /// <param name="expLun"></param>
        /// <param name="hc"></param>
        /// <returns></returns>
        internal static bool AzureDataDisk(PersistentVM vm, string expLabel, int expSize, int expLun, HostCaching hc)
        {
            bool found = false;
            foreach (DataVirtualHardDisk disk in vmPowershellCmdlets.GetAzureDataDisk(vm))
            {
                if (CheckDataDisk(disk, expLabel, expSize, expLun, hc))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private static bool CheckDataDisk(DataVirtualHardDisk disk, string expLabel, int expSize, int expLun, HostCaching hc)
        {
            Console.WriteLine("DataDisk - Name:{0}, Label:{1}, Size:{2}, LUN:{3}, HostCaching: {4}",
                disk.DiskName, disk.DiskLabel, disk.LogicalDiskSizeInGB, disk.Lun, disk.HostCaching);

            try
            {
                Assert.AreEqual(expLabel, disk.DiskLabel);
                Assert.AreEqual(expSize, disk.LogicalDiskSizeInGB);
                Assert.AreEqual(expLun, disk.Lun);
                if (disk.HostCaching == null && hc == HostCaching.None || disk.HostCaching == hc.ToString())
                {
                    Console.WriteLine("DataDisk found: {0}", disk.DiskLabel);
                }
                else
                {
                    Assert.Fail("HostCaching is not matched!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (e is AssertFailedException)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="resultSettings"></param>
        /// <param name="expDns"></param>
        /// <returns></returns>
        internal static bool AzureDns(DnsSettings resultSettings, DnsServer expDns)
        {
            try
            {
                DnsServerList dnsList = vmPowershellCmdlets.GetAzureDns(resultSettings);
                foreach (DnsServer dnsServer in dnsList)
                {
                    Console.WriteLine("DNS Server Name: {0}, DNS Server Address: {1}", dnsServer.Name, dnsServer.Address);
                    if (MatchDns(expDns, dnsServer))
                    {
                        Console.WriteLine("Matched Dns found!");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private static bool MatchDns(DnsServer expDns, DnsServer actualDns)
        {
            try
            {
                Assert.AreEqual(expDns.Name, actualDns.Name);
                Assert.AreEqual(expDns.Address, actualDns.Address);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (e is AssertFailedException)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="epInfos"></param>
        /// <returns></returns>
        internal static bool AzureEndpoint(PersistentVM vm, AzureEndPointConfigInfo[] epInfos)
        {
            try
            {
                var serverEndpoints = vmPowershellCmdlets.GetAzureEndPoint(vm);

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

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="expOS"></param>
        /// <param name="expHC"></param>
        /// <returns></returns>
        internal static bool AzureOsDisk(PersistentVM vm, string expOS, HostCaching expHC)
        {
            try
            {
                OSVirtualHardDisk osdisk = vmPowershellCmdlets.GetAzureOSDisk(vm);
                Console.WriteLine("OS Disk: Name - {0}, Label - {1}, HostCaching - {2}, OS - {3}", osdisk.DiskName, osdisk.DiskLabel, osdisk.HostCaching, osdisk.OS);
                Assert.IsTrue(osdisk.Equals(vm.OSVirtualHardDisk), "OS disk returned is not the same!");
                Assert.AreEqual(expOS, osdisk.OS);
                Assert.AreEqual(expHC.ToString(), osdisk.HostCaching);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (e is AssertFailedException)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="expLabel"></param>
        /// <param name="expLocation"></param>
        /// <param name="expAff"></param>
        /// <param name="expDescription"></param>
        /// <param name="expStatus"></param>
        /// <returns></returns>
        internal static bool AzureService(string svc, string expLabel, string expLocation = "West US", string expAff = null, string expDescription = null, string expStatus = "Created")
        {
            try
            {
                HostedServiceDetailedContext result = vmPowershellCmdlets.GetAzureService(svc);

                Assert.AreEqual(expLabel, result.Label);
                Assert.AreEqual(expDescription, result.Description);
                Assert.AreEqual(expAff, result.AffinityGroup);
                Assert.AreEqual(expLocation, result.Location);
                Assert.AreEqual(expStatus, result.Status);
                Assert.AreEqual(svc, result.ServiceName);
                //Assert.AreEqual(expDateCreated, result.DateCreated);
                //Assert.AreEqual(expDateModified, result.DateModified);
                //Assert.AreEqual(expUrl, result.Url);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        internal static bool AzureAclConfig(NetworkAclObject expectedAcl, NetworkAclObject actualAcl)
        {
            for (int i = 0; i < expectedAcl.Rules.Count; i++)
            {
                Assert.IsTrue(CompareContext(expectedAcl.Rules[i], actualAcl.Rules[i]));
            }
            return true;
        }

        internal static bool AzureReservedIP(ReservedIPContext rsvIP, string name, string label, string affname,
            string ip, string dep, string svcName, string id)
        {
            Utilities.PrintContext(rsvIP);
            Assert.AreEqual(name, rsvIP.ReservedIPName, "Reserved IP names are not equal!");
            Assert.AreEqual(label, rsvIP.Label, "Reserved IP labels are not equal!");
            Assert.AreEqual(affname, rsvIP.Location, "Reserved IP affinity groups are not equal!");
            if (!string.IsNullOrEmpty(ip))
            {
                Assert.AreEqual(ip, rsvIP.Address, "Reserved IP addresses are not equal!");
            }
            Assert.AreEqual(dep, rsvIP.DeploymentName, "Reserved IP deployment names are not equal!");
            Assert.AreEqual(svcName, rsvIP.ServiceName, "Reserved IP service names are not equal!");
            if (!string.IsNullOrEmpty(id))
            {
                Assert.AreEqual(id, rsvIP.Id, "Reserved IP IDs are not equal!");
            }
            return true;
        }

        internal static bool AzureReservedIPNotInUse(ReservedIPContext rsvIP, string name, string label, string affname,
            string id = null)
        {
            AzureReservedIP(rsvIP, name, label, affname, null, null, null, id);
            Assert.AreEqual(false, rsvIP.InUse);
            return true;
        }

        internal static bool AzureReservedIPInUse(ReservedIPContext rsvIP, string name, string label, string affname,
            string ip = null, string deploymentName =null, string svcName = null)
        {
            AzureReservedIP(rsvIP, name, label, affname, ip, deploymentName, svcName, null);
            Assert.AreEqual(true, rsvIP.InUse);
            return true;
        }
        
        

        private static bool CompareContext<T>(T obj1, T obj2)
        {
            bool result = true;
            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string typeName = property.PropertyType.FullName;
                if (typeName.Equals("System.String") || typeName.Equals("System.Int32") || typeName.Equals("System.Uri") || typeName.Contains("Nullable"))
                {
                    if (typeName.Contains("System.DateTime"))
                    {
                        continue;
                    }

                    var obj1Value = property.GetValue(obj1, null);
                    var obj2Value = property.GetValue(obj2, null);
                    Console.WriteLine("Expected: {0}", obj1Value);
                    Console.WriteLine("Acutal: {0}", obj2Value);

                    if (obj1Value == null)
                    {
                        result &= (obj2Value == null);
                    }
                    else if (typeName.Contains("System.String"))
                    {
                        result &= (string.Compare(obj1Value.ToString(), obj2Value.ToString(), StringComparison.CurrentCultureIgnoreCase) == 0);
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

        
    }
}
