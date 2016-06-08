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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class NewAzureQuickVMCmdletInfo : CmdletsInfo
    {
        public NewAzureQuickVMCmdletInfo(OS os, string name, string serviceName, string imageName, string userName, string password)
        {
            cmdletName = Utilities.NewAzureQuickVMCmdletName;

            if (os == OS.Windows)
            {
                cmdletParams.Add(new CmdletParam("Windows", null));
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    cmdletParams.Add(new CmdletParam("AdminUsername", userName));
                }
            }
            else
            {
                cmdletParams.Add(new CmdletParam("Linux", null));
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    cmdletParams.Add(new CmdletParam("LinuxUser", userName));
                }
            }
            cmdletParams.Add(new CmdletParam("ImageName", imageName));
            cmdletParams.Add(new CmdletParam("Name", name));
            cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
            if (!string.IsNullOrEmpty(password))
            {
                cmdletParams.Add(new CmdletParam("Password", password));
            }
        }

        public NewAzureQuickVMCmdletInfo(OS os, string name, string serviceName, string imageName, string userName,
            string password, string locationName)
            : this(os, name, serviceName, imageName, userName, password)
        {
            if (!string.IsNullOrEmpty(locationName))
            {
                cmdletParams.Add(new CmdletParam("Location", locationName));
            }
        }

        public NewAzureQuickVMCmdletInfo(OS os, string name, string serviceName, string imageName, string userName,
            string password, string locationName, string instanceSize)
            : this(os, name, serviceName, imageName, userName, password, locationName)
        {
            if (!string.IsNullOrEmpty(instanceSize))
            {
                cmdletParams.Add(new CmdletParam("InstanceSize", instanceSize));
            }
        }

        public NewAzureQuickVMCmdletInfo(OS os, string name, string serviceName, string imageName, string userName,
            string password, string locationName, string instanceSize, bool disableWinRMHttps, string reservedIpName, string vnetName)
            : this(os, name, serviceName, imageName, userName, password, locationName, instanceSize)
        {
            if (disableWinRMHttps)
            {
                cmdletParams.Add(new CmdletParam("DisableWinRMHttps"));
            }
            if (!string.IsNullOrEmpty(reservedIpName))
            {
                cmdletParams.Add(new CmdletParam("ReservedIPName", reservedIpName));
            }
            if (!string.IsNullOrEmpty(vnetName))
            {
                cmdletParams.Add(new CmdletParam("VNetName", vnetName));
            }
        }

        public NewAzureQuickVMCmdletInfo(OS os, string name, string serviceName, string imageName, string instanceSize,
            string userName, string password, string vNetName, string[] subnetNames, string affinityGroup, string reservedIP)
            : this(os, name, serviceName, imageName, userName, password)
        {
            if (!string.IsNullOrEmpty(affinityGroup))
            {
                cmdletParams.Add(new CmdletParam("AffinityGroup", affinityGroup));
            }
            if (!string.IsNullOrEmpty(instanceSize))
            {
                cmdletParams.Add(new CmdletParam("InstanceSize", instanceSize));
            }
            if (!string.IsNullOrEmpty(vNetName))
            {
                cmdletParams.Add(new CmdletParam("VNetName", vNetName));
            }
            if (subnetNames != null)
            {
                cmdletParams.Add(new CmdletParam("SubnetNames", subnetNames));
            }
            if (!string.IsNullOrEmpty(reservedIP))
            {
                cmdletParams.Add(new CmdletParam("ReservedIPName", reservedIP));
            }
        }

		public NewAzureQuickVMCmdletInfo(
            OS os,
            string name,
            string serviceName,
            string imageName,
            string userName,
            string password,
            string location,
            string instanceSize,
            string vnetName,
            string[] subnetNames,
            string affinityGroup, 
            string availabilitySetName, 
            CertificateSettingList certificates, 
            DnsServer[] dnsSettings,
            string hostCaching,
            string mediaLocation,
            LinuxProvisioningConfigurationSet.SSHKeyPairList sshKeyPairs,
            LinuxProvisioningConfigurationSet.SSHPublicKeyList sshPublicKeys,
            string customDataFileName)
            : this(os, name, serviceName, imageName, userName, password, location, instanceSize)
        {
            
            if (!string.IsNullOrEmpty(affinityGroup))
            {
                cmdletParams.Add(new CmdletParam("AffinityGroup", affinityGroup));
            }
            if (!string.IsNullOrEmpty(availabilitySetName))
            {
                cmdletParams.Add(new CmdletParam("AvailabilitySetName", availabilitySetName));
            }
            if (certificates != null)
            {
                cmdletParams.Add(new CmdletParam("Certificates", certificates));
            }
            if (dnsSettings != null)
            {
                cmdletParams.Add(new CmdletParam("DnsSettings", dnsSettings));
            }
            if (!string.IsNullOrEmpty(hostCaching))
            {
                cmdletParams.Add(new CmdletParam("HostCaching", hostCaching));
            }                                                                     
            if (!string.IsNullOrEmpty(mediaLocation))
            {
                cmdletParams.Add(new CmdletParam("MediaLocation", mediaLocation));
            }                                    
            if (sshKeyPairs != null)
            {
                cmdletParams.Add(new CmdletParam("SSHKeyPairs", sshKeyPairs));
            }
            if (sshPublicKeys != null)
            {
                cmdletParams.Add(new CmdletParam("SSHPublicKeys", sshPublicKeys));
            }
            if (subnetNames != null)
            {
                cmdletParams.Add(new CmdletParam("SubnetNames", subnetNames));
            }
            if (!string.IsNullOrEmpty(vnetName))
            {
                cmdletParams.Add(new CmdletParam("VNetName", vnetName));
            } 
            if (!string.IsNullOrEmpty(customDataFileName))
            {
                cmdletParams.Add(new CmdletParam("CustomData", customDataFileName));
            }
        }
    }
}