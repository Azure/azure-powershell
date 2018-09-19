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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class AddAzureProvisioningConfigCmdletInfo : CmdletsInfo
    {
        public AddAzureProvisioningConfigCmdletInfo(AzureProvisioningConfigInfo provConfig)
        {
            this.cmdletName = Utilities.AddAzureProvisioningConfigCmdletName;

            this.cmdletParams.Add(new CmdletParam("VM", provConfig.Vm));

            var parameterSet = string.IsNullOrEmpty(provConfig.Option) ? provConfig.OS.ToString() : provConfig.Option;

            this.cmdletParams.Add(new CmdletParam(parameterSet));

            if (!string.IsNullOrEmpty(provConfig.Password))
            {
                this.cmdletParams.Add(new CmdletParam("Password", provConfig.Password));
            }

            if (!string.IsNullOrEmpty(provConfig.CustomDataFile))
            {
                this.cmdletParams.Add(new CmdletParam("CustomDataFile", provConfig.CustomDataFile));
            }

            // For Linux parameter set
            if (parameterSet.Equals(OS.Linux.ToString()))
            {
                this.cmdletParams.Add(new CmdletParam("LinuxUser", provConfig.LinuxUser));

                if (provConfig.DisableSSH)
                {
                    this.cmdletParams.Add(new CmdletParam("DisableSSH"));
                }
                if (provConfig.NoSSHEndpoint)
                {
                    this.cmdletParams.Add(new CmdletParam("NoSSHEndpoint"));
                }
                if (provConfig.SSHKeyPairs != null && provConfig.SSHKeyPairs.Count != 0)
                {
                    this.cmdletParams.Add(new CmdletParam("SSHKeyPairs", provConfig.SSHKeyPairs));
                }
                if (provConfig.SshPublicKeys != null && provConfig.SshPublicKeys.Count != 0)
                {
                    this.cmdletParams.Add(new CmdletParam("SSHPublicKeys", provConfig.SshPublicKeys));
                }
                if(provConfig.NoSSHPassword)
                {
                    this.cmdletParams.Add(new CmdletParam("NoSSHPassword"));
                }
            }

            // For Windows/WindowsDomain parameter set
            if (parameterSet.Equals(provConfig.WindowsDomain) || parameterSet.Equals(OS.Windows.ToString()))
            {
                this.cmdletParams.Add(new CmdletParam("AdminUsername", provConfig.AdminUsername));

                if (provConfig.DisableAutomaticUpdate)
                {
                    this.cmdletParams.Add(new CmdletParam("DisableAutomaticUpdates"));
                }
                if (provConfig.DisableGuestAgent)
                {
                    this.cmdletParams.Add(new CmdletParam("DisableGuestAgent"));
                }
                if (provConfig.DisableWinRMHttps)
                {
                    this.cmdletParams.Add(new CmdletParam("DisableWinRMHttps"));
                }
                if (provConfig.EnableWinRMHttp)
                {
                    this.cmdletParams.Add(new CmdletParam("EnableWinRMHttp"));
                }
                if (provConfig.NoWinRMEndpoint)
                {
                    this.cmdletParams.Add(new CmdletParam("NoWinRMEndpoint"));
                }
                if (provConfig.Reset)
                {
                    this.cmdletParams.Add(new CmdletParam("ResetPasswordOnFirstLogon"));
                }
                if (provConfig.NoExportPrivateKey)
                {
                    this.cmdletParams.Add(new CmdletParam("NoExportPrivateKey"));
                }
                if (provConfig.NoRDPEndpoint)
                {
                    this.cmdletParams.Add(new CmdletParam("NoRDPEndpoint"));
                }
                if (!string.IsNullOrEmpty(provConfig.TimeZone))
                {
                    this.cmdletParams.Add(new CmdletParam("TimeZone", provConfig.TimeZone));
                }

                if (provConfig.Certs != null && provConfig.Certs.Count != 0)
                {
                    this.cmdletParams.Add(new CmdletParam("Certificates", provConfig.Certs));
                }
                if (provConfig.WinRMCertificate != null)
                {
                    this.cmdletParams.Add(new CmdletParam("WinRMCertificate", provConfig.WinRMCertificate));
                }
                if (provConfig.X509Certificates != null)
                {
                    this.cmdletParams.Add(new CmdletParam("X509Certificates", provConfig.X509Certificates));
                }
            }

            // For WindowsDomain parameter set
            if (parameterSet.Equals(provConfig.WindowsDomain))
            {
                this.cmdletParams.Add(new CmdletParam("Domain", provConfig.Domain));
                this.cmdletParams.Add(new CmdletParam("JoinDomain", provConfig.JoinDomain));
                this.cmdletParams.Add(new CmdletParam("DomainUserName", provConfig.DomainUserName));
                this.cmdletParams.Add(new CmdletParam("DomainPassword", provConfig.DomainPassword));

                if (!string.IsNullOrEmpty(provConfig.MachineObjectOU))
                {
                    this.cmdletParams.Add(new CmdletParam("MachineObjectOU", provConfig.MachineObjectOU));
                }
            }
        }
    }
}
