
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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.NetApp.Models;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.NetAppFiles.ActiveDirectory
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesActiveDirectory",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesActiveDirectory))]
    [Alias("Update-AnfActiveDirectory")]
    public class UpdateAzureRmNetAppFilesActiveDirectory : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the ANF active directory",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the ANF active directory",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]        
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/activeDirectory",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string ActiveDirectoryId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Comma separated list of DNS server IP addresses (IPv4 only) for the Active Directory domain")]
        [ValidateNotNullOrEmpty]
        public string[] Dns { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the Active Directory domain")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Active Directory site the service will limit Domain Controller discovery to")]
        [ValidateNotNullOrEmpty]
        public string Site { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "NetBIOS name of the SMB server. This name will be registered as a computer account in the AD and used to mount volumes")]
        [ValidateNotNullOrEmpty]
        public string SmbServerName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Username of Active Directory domain administrator")]
        [ValidateNotNullOrEmpty]
        public string Username { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Plain text password of Active Directory domain administrator, value is masked in the response")]
        [ValidateNotNullOrEmpty]
        public SecureString Password { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Organizational Unit (OU) within the Windows Active Directory")]
        [ValidateNotNullOrEmpty]
        public string OrganizationalUnit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "kdc server IP addresses for the active directory machine. This optional parameter is used only while creating kerberos volume.")]
        [ValidateNotNullOrEmpty]
        public string KdcIP { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Users to be added to the Built-in Backup Operator active directory group. A list of unique usernames without domain specifier")]
        [ValidateNotNullOrEmpty]
        public string[] BackupOperator { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "When LDAP over SSL/TLS is enabled, the LDAP client is required to have base64 encoded Active Directory Certificate Service's self-signed root CA certificate, this optional parameter is used only for dual protocol with LDAP user-mapping volumes.")]
        [ValidateNotNullOrEmpty]
        public string ServerRootCACertificate { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the active directory machine. This optional parameter is used only while creating kerberos volume")]
        [ValidateNotNullOrEmpty]
        public string AdName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Domain Users in the Active directory to be given Security Privilege (Needed for SMB Continuously available shares for SQL). A list of unique usernames without domain specifier")]
        [ValidateNotNullOrEmpty]
        public string[] SecurityOperator { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "When AES is enabled, set if AES encryption will be enabled for SMB communication.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AesEncryption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "When LDAP over SSL/TLS is enabled, Specifies whether or not the LDAP traffic needs to be signed.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter LdapSigning { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "When LDAP over SSL/TLS is enabled, specifies whether or not the LDAP traffic needs to be secured via TLS.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter LdapOverTLS { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If enabled, NFS client local users can also (in addition to LDAP users) access the NFS volumes.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowLocalNfsUsersWithLdap { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Domain Users to be added to the Built-in Administrators Active Directory group. A list of unique usernames without domain specifier.")]
        [ValidateNotNullOrEmpty]
        public string[] Administrator { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If enabled, Traffic between the SMB server to Domain Controller (DC) will be encrypted.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EncryptDCConnection { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The account for the active directory object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The active directory object to remove")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesActiveDirectory InputObject { get; set; }

        public override void ExecuteCmdlet()
        {            
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                AccountName = InputObject.AccountName;
                ActiveDirectoryId = InputObject.ActiveDirectoryId;
            }

            if (ShouldProcess(ActiveDirectoryId, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                var anfAccount = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, AccountName);
                if (anfAccount == null)
                {
                    throw new ArgumentException($"Specified NetAppAccount with name '{this.AccountName}' does not extist in Resource Group '{this.ResourceGroupName}'");
                }
                string dnsStr = null;
                if (Dns != null)
                {
                    dnsStr = string.Join(",", Dns);
                }
                Management.NetApp.Models.ActiveDirectory anfADConfig = null;
                if (string.IsNullOrWhiteSpace(ActiveDirectoryId))
                {
                    anfADConfig = new Management.NetApp.Models.ActiveDirectory();
                }
                else
                {
                    anfADConfig = anfAccount.ActiveDirectories?.FirstOrDefault(a => a.ActiveDirectoryId == ActiveDirectoryId);
                    if (anfADConfig == null)
                    {
                        throw new ArgumentException($"ActiveDirectory configuration with ID '{this.ActiveDirectoryId}' in account '{this.AccountName}' is not found. Please use New-AzNetAppFilesActiveDirectory to Create a new ActiveDirectory configuration.");
                    }
                }

                anfADConfig.AdName = AdName ?? anfADConfig.AdName;
                anfADConfig.Dns = dnsStr ?? anfADConfig.Dns;
                anfADConfig.Domain = Domain ?? anfADConfig.Domain;
                anfADConfig.SmbServerName = SmbServerName ?? anfADConfig.SmbServerName;
                anfADConfig.Username = Username ?? anfADConfig.Username;
                anfADConfig.Password = Password.ConvertToString();
                anfADConfig.Site = Site ?? anfADConfig.Site;
                anfADConfig.OrganizationalUnit = OrganizationalUnit ?? anfADConfig.Site;
                anfADConfig.BackupOperators = BackupOperator ?? anfADConfig.BackupOperators;
                anfADConfig.KdcIP = KdcIP ?? anfADConfig.KdcIP;
                anfADConfig.ServerRootCACertificate = ServerRootCACertificate ?? anfADConfig.ServerRootCACertificate;
                anfADConfig.SecurityOperators = SecurityOperator ?? anfADConfig.SecurityOperators;
                if (AesEncryption)
                {
                    anfADConfig.AesEncryption = AesEncryption;
                }
                if (LdapSigning)
                {
                    anfADConfig.LdapSigning = LdapSigning;
                }
                if (LdapOverTLS)
                {
                    anfADConfig.LdapOverTLS = LdapOverTLS;
                }
                if (AllowLocalNfsUsersWithLdap)
                {
                    anfADConfig.AllowLocalNfsUsersWithLdap = AllowLocalNfsUsersWithLdap;
                }
                anfADConfig.Administrators = Administrator ?? anfADConfig.Administrators;
                if (EncryptDCConnection)
                {
                    anfADConfig.EncryptDCConnections = EncryptDCConnection;
                }

                var netAppAccountBody = new NetAppAccountPatch()
                {
                    ActiveDirectories = anfAccount.ActiveDirectories                    
                };

                var updatedAnfAccount = AzureNetAppFilesManagementClient.Accounts.Update(netAppAccountBody, ResourceGroupName, AccountName);
                var updatedActiveDirectory = updatedAnfAccount.ActiveDirectories.FirstOrDefault<Management.NetApp.Models.ActiveDirectory>(e => e.ActiveDirectoryId == ActiveDirectoryId);
                WriteObject(updatedActiveDirectory.ConvertToPs(ResourceGroupName, AccountName));
            }
        }
    }
}
