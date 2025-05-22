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
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.Linq;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Account
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesAccount",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesAccount))]
    [Alias("New-AnfAccount")]
    public class NewAzureRmNetAppFilesAccount : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the active directories")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesActiveDirectory[] ActiveDirectory { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents the Encryption settings")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccountEncryption Encryption { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The encryption keySource (provider). Possible values: Microsoft.NetApp, Microsoft.KeyVault")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Microsoft.NetApp, Microsoft.KeyVault")]
        public string EncryptionKeySource { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The name of KeyVault key")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultKeyName { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The resource ID of KeyVault.")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultResourceId { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The Uri of KeyVault.")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "None", "SystemAssigned,UserAssigned")]
        public string IdentityType { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The ARM resource identifier of the user assigned identity used to authenticate with key vault. Applicable if identity.type has 'UserAssigned'. It should match key of identity.userAssignedIdentities")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "ClientId of the multi-tenant AAD Application. Used to access cross-tenant KeyVaults.")]
        [ValidateNotNullOrEmpty]
        public string FederatedClientId { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Domain for NFSv4 user ID mapping. This property will be set for all NetApp accounts in the subscription and region and only affect non ldap NFSv4 volumes.")]
        [ValidateNotNullOrEmpty]
        public string NfsV4IdDomain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }
            NetAppAccount existingAccount = null;

            try
            {
                existingAccount = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, Name);
            }
            catch
            {
                existingAccount = null;
            }
            if (existingAccount != null)
            {
                throw new AzPSResourceNotFoundCloudException($"A NetAppAccount with name '{this.Name}' in resource group '{this.ResourceGroupName}' already exists. Please use Set/Update-AzNetAppFilesAccount to update an existing NetAppAccount.");
            }
            if ((new object[] { EncryptionKeySource, KeyVaultKeyName, KeyVaultResourceId, KeyVaultUri }).Any(v => v != null))
            {
                if (Encryption == null)
                {
                    Encryption = new PSNetAppFilesAccountEncryption()
                    {
                        KeySource = EncryptionKeySource,
                        KeyVaultProperties = new PSNetAppFilesKeyVaultProperties() { KeyName = KeyVaultKeyName, KeyVaultResourceId = KeyVaultResourceId, KeyVaultUri = KeyVaultUri },
                        Identity = new PSEncryptionIdentity() { UserAssignedIdentity = UserAssignedIdentity, FederatedClientId = FederatedClientId }
                    };
                }
            }
            var netAppAccountBody = new NetAppAccount()
            {
                Location = Location,
                ActiveDirectories = ActiveDirectory?.ConvertFromPs(),
                Tags = tagPairs,
                Encryption = Encryption?.ConvertFromPs(),
                NfsV4IdDomain = NfsV4IdDomain
            };
            if (IdentityType != null && IdentityType.Contains("UserAssigned"))
            {
                var userAssingedIdentitiesDict = new Dictionary<string, UserAssignedIdentity>();
                userAssingedIdentitiesDict.Add(UserAssignedIdentity, new Management.NetApp.Models.UserAssignedIdentity());
                netAppAccountBody.Identity = new ManagedServiceIdentity()
                {
                    Type = IdentityType,
                    UserAssignedIdentities = userAssingedIdentitiesDict
                };
            }
            else if (IdentityType == "SystemAssigned")
            {
                netAppAccountBody.Identity = new ManagedServiceIdentity()
                {
                    Type = IdentityType
                };
            }
            
            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                try
                {
                    var anfAccount = AzureNetAppFilesManagementClient.Accounts.CreateOrUpdate(ResourceGroupName, Name, netAppAccountBody);
                    WriteObject(anfAccount.ConvertToPs());
                }
                catch(ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);                    
                }
            }
        }
    }
}
