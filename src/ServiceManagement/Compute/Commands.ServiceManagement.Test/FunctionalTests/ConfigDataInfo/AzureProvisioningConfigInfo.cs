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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo
{
    public class AzureProvisioningConfigInfo
    {
        public string WindowsDomain = "WindowsDomain";

        public OS OS;
        public string Option = null;

        public readonly string Password;
        public CertificateSettingList Certs =  new CertificateSettingList();
        public string LinuxUser = null;
        public string AdminUsername = null;

        public string JoinDomain = null;
        public string Domain = null;
        public string DomainUserName = null;
        public string DomainPassword = null;
        public string MachineObjectOU = null;

        public bool Reset = false;
        public bool DisableAutomaticUpdate = false;
        public bool DisableSSH = false;

        public bool DisableGuestAgent = false;
        public bool DisableWinRMHttps = false;
        public bool EnableWinRMHttp = false;
        public bool NoWinRMEndpoint = false;
        public X509Certificate2 WinRMCertificate = null;
        public X509Certificate2[] X509Certificates = null;

        public bool NoExportPrivateKey = false;
        public bool NoRDPEndpoint = false;
        public bool NoSSHEndpoint = false;
        public bool NoSSHPassword;

        public LinuxProvisioningConfigurationSet.SSHKeyPairList SSHKeyPairs = null;
        public LinuxProvisioningConfigurationSet.SSHPublicKeyList SshPublicKeys = null;
        public string TimeZone = null;
        
        public string CustomDataFile = null;

        // WindowsDomain paramenter set
        public AzureProvisioningConfigInfo(string option, string user, string password, string joinDomain, string domain,
            string domainUserName, string domainPassword, string objectOU = null,bool disableGuestAgent = false)
        {
            if (string.Compare(option, WindowsDomain, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                this.Option = WindowsDomain;
                this.AdminUsername = user;
                this.Password = password;
                this.Domain = domain;
                this.JoinDomain = joinDomain;
                this.DomainUserName = domainUserName;
                this.DomainPassword = domainPassword;
                this.MachineObjectOU = objectOU;
                this.DisableGuestAgent = disableGuestAgent;
            }
        }

        public AzureProvisioningConfigInfo(OS os, string user, string password, bool disableGuestAgent = false)
        {
            this.OS = os;
            this.Password = password;
            if (os == OS.Windows)
            {
                this.AdminUsername = user;
                if (disableGuestAgent) this.DisableGuestAgent = true;
            }
            else
            {
                this.LinuxUser = user;
            }
        }

        public AzureProvisioningConfigInfo(OS os, CertificateSettingList certs, string user, string password)
        {
            this.OS = os;            
            this.Password = password;
            foreach (CertificateSetting cert in certs)
            {
                Certs.Add(cert);
            }
            if (os == OS.Windows)
            {
                this.AdminUsername = user;
            }
            else
            {
                this.LinuxUser = user;
            }

        }

        public AzureProvisioningConfigInfo(string linuxUser, string password = null, bool noSshEndpoint = false,
            bool disableSSH = false, LinuxProvisioningConfigurationSet.SSHKeyPairList sSHKeyPairList = null,
            LinuxProvisioningConfigurationSet.SSHPublicKeyList sSHPublicKeyList = null, bool noSSHPassword = false, string CustomDataFile = null)
        {
            this.OS = OS.Linux;
            this.LinuxUser = linuxUser;
            this.DisableSSH = disableSSH;
            this.NoSSHEndpoint = noSshEndpoint;
            if (!string.IsNullOrEmpty(password))
            {
                this.Password = password;
            }
            if (sSHKeyPairList != null)
            {
                this.SSHKeyPairs = sSHKeyPairList;
            }
            if (sSHPublicKeyList != null)
            {
                this.SshPublicKeys = sSHPublicKeyList;
            }
            if (noSSHPassword)
            {
                this.NoSSHPassword = noSSHPassword;
            }

            this.CustomDataFile = CustomDataFile;
        }

        public AzureProvisioningConfigInfo(string adminUsername, string password, X509Certificate2 winRMCertificate)
        {
            this.OS= OS.Windows;
            this.AdminUsername = adminUsername;
            this.Password = password;
            this.WinRMCertificate = winRMCertificate;
        }

        public AzureProvisioningConfigInfo(string adminUsername, string password, string customData)
        {
            this.OS = OS.Windows;
            this.AdminUsername = adminUsername;
            this.Password = password;
            this.CustomDataFile = customData;
        }

        public PersistentVM  Vm { get; set; }
    }
}
