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

using Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters;
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Create a new Cognitive Services Account, specify it's type (resource kind)
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccount", SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
    public class NewAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        /// <summary>
        /// CognitiveServices Encryption parameter set name
        /// </summary>
        private const string CognitiveServicesEncryptionParameterSet = "CognitiveServicesEncryption";

        /// <summary>
        /// KeyVault Encryption parameter set name
        /// </summary>
        private const string KeyVaultEncryptionParameterSet = "KeyVaultEncryption";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Type.")]
        [Alias(CognitiveServicesAccountTypeAlias, AccountTypeAlias, KindAlias)]
        [AccountTypeCompleter()]
        public string Type { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Sku Name.")]
        [AccountSkuCompleter()]
        public string SkuName { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Tags.")]
        [Alias(TagsAlias)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Subdomain Name.")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public string CustomSubdomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate and assign a new Cognitive Services Account Identity for this storage account for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource ids for the the new Cognitive Services Account user assigned Identity, the identity will be used with key management services like Azure KeyVault.")]
        [ValidateNotNullOrEmpty]
        [AllowEmptyCollection]
        public string[] UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set the new Cognitive Services Account Identity type, the idenetity is for use with key management services like Azure KeyVault.")]
        public IdentityType? IdentityType { get; set; }

        [Parameter(
            HelpMessage = "List of User Owned Storage Accounts.",
            Mandatory = false)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public string[] StorageAccountId { get; set; }

        [Parameter(HelpMessage = "Whether to set Cognitive Services Account Encryption KeySource to Microsoft.CognitiveServices or not.",
            Mandatory = false,
            ParameterSetName = CognitiveServicesEncryptionParameterSet)]
        public SwitchParameter CognitiveServicesEncryption { get; set; }

        [Parameter(HelpMessage = "Whether to set Cognitive Services Account encryption keySource to Microsoft.KeyVault or not.",
            Mandatory = false,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        public SwitchParameter KeyVaultEncryption { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyName",
                    Mandatory = true,
                    ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyVersion",
            Mandatory = true,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyVaultUri",
            Mandatory = true,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set IdentityClientId to access Azure KeyVault of Cognitive Services Account Encryption.",
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNull]
        public string KeyVaultIdentityClientId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "NetworkRuleSet is used to define a set of configuration rules for firewalls and virtual networks, as well as to set values for network properties such as how to handle requests that don't match any of the defined rules")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public PSNetworkRuleSet NetworkRuleSet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The network access type for Cognitive Services Account. Commonly `Enabled` or `Disabled`.")]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        public string PublicNetworkAccess { get; set; }

        [Parameter(HelpMessage = "True if disable Local authentication methods.", Mandatory = false)]
        public bool? DisableLocalAuth { get; set; }

        [Parameter(HelpMessage = "True if restrict outbound network access.", Mandatory = false)]
        public bool? RestrictOutboundNetworkAccess { get; set; }

        [Parameter(HelpMessage = "List of Allowed FQDN.", Mandatory = false)]
        [AllowEmptyCollection]
        public string[] AllowedFqdnList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ApiProperties of Cognitive Services Account. Required by specific account types.")]
        public CognitiveServicesAccountApiProperties ApiProperty { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var properties = new AccountProperties();
                if (!string.IsNullOrWhiteSpace(CustomSubdomainName))
                {
                    properties.CustomSubDomainName = CustomSubdomainName;
                }

                if (NetworkRuleSet != null)
                {
                    properties.NetworkAcls = NetworkRuleSet.ToNetworkRuleSet();
                }

                if (ApiProperty != null)
                {
                    properties.ApiProperties = ApiProperty;
                }

                var createParameters = new Account()
                {
                    Location = Location,
                    Kind = Type, // must have value, mandatory parameter
                    Sku = new Sku(SkuName, null),
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag),
                    Properties = properties
                };

                if (!string.IsNullOrEmpty(PublicNetworkAccess))
                {
                    createParameters.Properties.PublicNetworkAccess = PublicNetworkAccess;
                }

                if (DisableLocalAuth != null)
                {
                    createParameters.Properties.DisableLocalAuth = DisableLocalAuth;
                }

                if (RestrictOutboundNetworkAccess != null)
                {
                    createParameters.Properties.RestrictOutboundNetworkAccess = RestrictOutboundNetworkAccess;
                }

                if (AllowedFqdnList != null)
                {
                    createParameters.Properties.AllowedFqdnList = AllowedFqdnList;
                }

                if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
                {
                    ResourceIdentityType resourceIdentityType = ResourceIdentityType.SystemAssigned;
                    if (this.IdentityType == null || !Enum.TryParse(this.IdentityType.ToString(), out resourceIdentityType))
                    {
                        resourceIdentityType = ResourceIdentityType.SystemAssigned;
                    }

                    createParameters.Identity = new Identity(resourceIdentityType);
                    if (this.UserAssignedIdentityId != null)
                    {
                        createParameters.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                        foreach (var userAssignedIdentityId in this.UserAssignedIdentityId)
                        {
                            createParameters.Identity.UserAssignedIdentities.Add(userAssignedIdentityId, new UserAssignedIdentity());
                        }
                    }
                }

                if (CognitiveServicesEncryption.IsPresent)
                {
                    createParameters.Properties.Encryption = new Encryption(null, KeySource.MicrosoftCognitiveServices);
                }

                if (ParameterSetName == KeyVaultEncryptionParameterSet)
                {
                    createParameters.Properties.Encryption = new Encryption(
                        new KeyVaultProperties()
                        {
                            KeyName = KeyName,
                            KeyVersion = KeyVersion,
                            KeyVaultUri = KeyVaultUri,
                            IdentityClientId = KeyVaultIdentityClientId
                        }, 
                        KeySource.MicrosoftKeyVault);
                }


                if (StorageAccountId != null && StorageAccountId.Length > 0)
                {
                    createParameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>();
                    foreach(var storageAccountId in StorageAccountId)
                    {
                        createParameters.Properties.UserOwnedStorage.Add(new UserOwnedStorage(storageAccountId));
                    }
                }

                if (ShouldProcess(
                    Name, string.Format(CultureInfo.CurrentCulture, Resources.NewAccount_ProcessMessage, Name, Type, SkuName, Location)))
                {
                    if (Type.StartsWith("Bing.", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (Force.IsPresent)
                        {
                            WriteWarning(Resources.NewAccount_Notice);
                        }
                        else
                        {
                            bool yesToAll = false, noToAll = false;
                            if (!ShouldContinue(Resources.NewAccount_Notice, "Notice", true, ref yesToAll, ref noToAll))
                            {
                                return;
                            }
                        }
                    }

                    if (Type.Equals("Face", StringComparison.InvariantCultureIgnoreCase) || Type.Equals("CognitiveServices", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (Force.IsPresent)
                        {
                            WriteWarning(Resources.NewAccount_LegalTerm_NotPolice);
                        }
                        else
                        {
                            bool yesToAll = false, noToAll = false;
                            if (!ShouldContinue(Resources.NewAccount_LegalTerm_NotPolice, "Notice", true, ref yesToAll, ref noToAll))
                            {
                                return;
                            }
                        }
                    }

                    var createAccountResponse = CognitiveServicesClient.Accounts.Create(
                                    ResourceGroupName,
                                    Name,
                                    createParameters);

                    var cognitiveServicesAccount = CognitiveServicesClient.Accounts.Get(ResourceGroupName, Name);

                    WriteCognitiveServicesAccount(cognitiveServicesAccount);
                }
            });
        }
    }
}
