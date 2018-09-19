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
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    public class ProvisioningConfigurationCmdletBase : ServiceManagementBaseCmdlet
    {
        public const string LinuxParameterSetName = OS.Linux;
        public const string WindowsParameterSetName = OS.Windows;
        public const string WindowsDomainParameterSetName = "WindowsDomain";

        [Parameter(Mandatory = true, ParameterSetName = LinuxParameterSetName, HelpMessage = "Set configuration to Linux.")]
        public SwitchParameter Linux
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "User to Create")]
        [ValidateNotNullOrEmpty]
        public string LinuxUser
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "Disable SSH Password Authentication.")]
        public SwitchParameter DisableSSH
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "Do not create an SSH Endpoint.")]
        public SwitchParameter NoSSHEndpoint
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "Allow to create passwordless VM")]
        public SwitchParameter NoSSHPassword
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "SSH Public Key List")]
        public LinuxProvisioningConfigurationSet.SSHPublicKeyList SSHPublicKeys
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "SSH Key Pairs")]
        public LinuxProvisioningConfigurationSet.SSHKeyPairList SSHKeyPairs
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Custom Data file")]
        public string CustomDataFile
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsParameterSetName, HelpMessage = "Set configuration to Windows.")]
        public SwitchParameter Windows
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Specifies the Administrator to create.")]
        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Specifies the Administrator to create.")]
        [ValidateNotNullOrEmpty]
        public string AdminUsername
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Set configuration to Windows with Domain Join.")]
        public SwitchParameter WindowsDomain
        {
            get;
            set;
        }
        
        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Administrator password to use for the role.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Administrator password to use for the role.")]
        [Parameter(Mandatory = false, ParameterSetName = LinuxParameterSetName, HelpMessage = "Default password for linux user created.")]
        [ValidateNotNullOrEmpty]
        public string Password
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Specify to force the user to change the password on first logon.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Specify to force the user to change the password on first logon.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ResetPasswordOnFirstLogon
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Disable Automatic Updates.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Disable Automatic Updates.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableAutomaticUpdates
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Do No Create an RDP Endpoint.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Do Not Create an RDP Endpoint.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NoRDPEndpoint
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Specify the time zone for the virtual machine.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Specify the time zone for the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string TimeZone
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Set of certificates to install in the VM.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Set of certificates to install in the VM.")]
        [ValidateNotNullOrEmpty]
        public CertificateSettingList Certificates
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Domain to join (FQDN).")]
        [ValidateNotNullOrEmpty]
        public string JoinDomain
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Domain name.")]
        [ValidateNotNullOrEmpty]
        public string Domain
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Domain user name.")]
        [ValidateNotNullOrEmpty]
        public string DomainUserName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Domain password.")]
        [ValidateNotNullOrEmpty]
        public string DomainPassword
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Machine object organization unit.")]
        [ValidateNotNullOrEmpty]
        public string MachineObjectOU
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Enables WinRM over http")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Enables WinRM over http")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableWinRMHttp
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Disables WinRM on http/https")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Disables WinRM on http/https")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableWinRMHttps
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Certificate that will be associated with WinRM endpoint.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Certificate that will be associated with WinRM endpoint.")]
        [ValidateNotNullOrEmpty]
        public X509Certificate2 WinRMCertificate
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "X509Certificates that will be deployed to hosted service.")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "X509Certificates that will be deployed to hosted service.")]
        [ValidateNotNullOrEmpty]
        public X509Certificate2[] X509Certificates
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Prevents the private key from being uploaded")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Prevents the private key from being uploaded")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NoExportPrivateKey
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParameterSetName, HelpMessage = "Prevents the WinRM endpoint from being added")]
        [Parameter(Mandatory = false, ParameterSetName = WindowsDomainParameterSetName, HelpMessage = "Prevents the WinRM endpoint from being added")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NoWinRMEndpoint
        {
            get;
            set;
        }

        protected void SetProvisioningConfiguration(LinuxProvisioningConfigurationSet provisioningConfiguration)
        {
            provisioningConfiguration.UserName = LinuxUser;
            provisioningConfiguration.UserPassword = SecureStringHelper.GetSecureString(Password);
            if (NoSSHPassword.IsPresent)
            {
                provisioningConfiguration.UserPassword = SecureStringHelper.GetSecureString(String.Empty);
            }

            if (DisableSSH.IsPresent || NoSSHPassword.IsPresent)
            {
                provisioningConfiguration.DisableSshPasswordAuthentication = true;
            }
            else
            {
                provisioningConfiguration.DisableSshPasswordAuthentication = false;
            }

            if (SSHKeyPairs != null && SSHKeyPairs.Count > 0 || SSHPublicKeys != null && SSHPublicKeys.Count > 0)
            {
                provisioningConfiguration.SSH = new LinuxProvisioningConfigurationSet.SSHSettings { PublicKeys = SSHPublicKeys, KeyPairs = SSHKeyPairs };
            }

            if (!string.IsNullOrEmpty(CustomDataFile))
            {
                string fileName = this.TryResolvePath(this.CustomDataFile);
                provisioningConfiguration.CustomData = PersistentVMHelper.ConvertCustomDataFileToBase64(fileName);
            }
        }

        protected void SetProvisioningConfiguration(WindowsProvisioningConfigurationSet provisioningConfiguration)
        {
            provisioningConfiguration.AdminUsername = AdminUsername;
            provisioningConfiguration.AdminPassword = SecureStringHelper.GetSecureString(Password);
            provisioningConfiguration.ResetPasswordOnFirstLogon = ResetPasswordOnFirstLogon.IsPresent;
            provisioningConfiguration.StoredCertificateSettings = CertUtilsNewSM.GetCertificateSettings(Certificates, X509Certificates);
            provisioningConfiguration.EnableAutomaticUpdates = !DisableAutomaticUpdates.IsPresent;

            if (provisioningConfiguration.StoredCertificateSettings == null)
            {
                provisioningConfiguration.StoredCertificateSettings = new CertificateSettingList();
            }

            if (!string.IsNullOrEmpty(TimeZone))
            {
                provisioningConfiguration.TimeZone = TimeZone;
            }

            if (WindowsDomainParameterSetName.Equals(ParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                provisioningConfiguration.DomainJoin = new WindowsProvisioningConfigurationSet.DomainJoinSettings
                {
                    Credentials = new WindowsProvisioningConfigurationSet.DomainJoinCredentials
                    {
                        Username = DomainUserName,
                        Password = SecureStringHelper.GetSecureString(DomainPassword),
                        Domain = Domain
                    },
                    MachineObjectOU = MachineObjectOU,
                    JoinDomain = JoinDomain
                };
            }

            if (!string.IsNullOrEmpty(CustomDataFile))
            {
                string fileName = this.TryResolvePath(this.CustomDataFile);
                provisioningConfiguration.CustomData = PersistentVMHelper.ConvertCustomDataFileToBase64(fileName);
            }
        }
    }
}
