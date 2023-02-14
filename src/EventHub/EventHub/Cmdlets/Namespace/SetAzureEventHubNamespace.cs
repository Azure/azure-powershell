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
using Microsoft.Azure.Commands.Eventhub;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [CmdletOutputBreakingChange(typeof(PSNamespaceAttributes), DeprecatedOutputProperties = new string[] { "ResourceGroup", "IdentityUserDefined", "Identity", "KeyProperty" }, NewOutputProperties = new string[] { "ResourceGroupName", "Tags", "IdentityType", "EncryptionConfig" })]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubNamespace", SupportsShouldProcess = true, DefaultParameterSetName = NamespaceParameterSet), OutputType(typeof(PSNamespaceAttributes))]
    public class SetAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4,HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tag.")]
        public Hashtable Tag { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "Indicates whether AutoInflate is enabled")]
        public SwitchParameter EnableAutoInflate { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.")]
        [ValidateRange(0,40)]        
        public int? MaximumThroughputUnits { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling Kafka for namespace")]
        public SwitchParameter EnableKafka { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling SAS authentication for namespace")]
        public SwitchParameter DisableLocalAuth { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')")]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        public string[] IdentityId { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }

        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [ValidateSet("1.0", "1.1", "1.2", IgnoreCase = true)]
        public string MinimumTlsVersion { get; set; }


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateNamespace, Name, ResourceGroupName)))
            {
                try
                {
                    EHNamespace NamespacePayload = UtilityClient.GetEventHubNamespace(ResourceGroupName, Name);
                    NamespacePayload = UpdateNamespacePayload(NamespacePayload);
                    PSNamespaceAttributes createdNamespace = UtilityClient.SendNamespaceCreateOrUpdateRequest(ResourceGroupName, Name, NamespacePayload);
                    WriteObject(createdNamespace);
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }

        internal EHNamespace UpdateNamespacePayload(EHNamespace currentNamespacePayload)
        {
            if (this.IsParameterBound(c => c.Location))
            {
                currentNamespacePayload.Location = Location;
            }

            if (this.IsParameterBound(c => c.SkuName))
            {
                currentNamespacePayload.Sku.Name = SkuName;
                currentNamespacePayload.Sku.Tier = SkuName;
            }

            if (this.IsParameterBound(c => c.SkuCapacity))
            {
                currentNamespacePayload.Sku.Capacity = SkuCapacity;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

                currentNamespacePayload.Tags = tagDictionary;
            }

            if (this.IsParameterBound(c => c.EnableAutoInflate))
            {
                currentNamespacePayload.IsAutoInflateEnabled = EnableAutoInflate.IsPresent;
            }

            if (this.IsParameterBound(c => c.EnableKafka))
            {
                currentNamespacePayload.KafkaEnabled = EnableKafka.IsPresent;
            }

            if (this.IsParameterBound(c => c.DisableLocalAuth))
            {
                currentNamespacePayload.DisableLocalAuth = DisableLocalAuth.IsPresent;
            }

            if (this.IsParameterBound(c => c.MaximumThroughputUnits))
            {
                currentNamespacePayload.MaximumThroughputUnits = MaximumThroughputUnits;
            }

            if (this.IsParameterBound(c => c.MinimumTlsVersion))
            {
                currentNamespacePayload.MinimumTlsVersion = MinimumTlsVersion;
            }

            if (this.IsParameterBound(c => c.IdentityType))
            {
                if(currentNamespacePayload.Identity == null)
                {
                    currentNamespacePayload.Identity = new Identity()
                    {
                        Type = UtilityClient.FindIdentity(IdentityType)
                    };
                }
                else
                {
                    currentNamespacePayload.Identity.Type = UtilityClient.FindIdentity(IdentityType);
                }
            }

            if (this.IsParameterBound(c => c.IdentityId))
            {
                if(currentNamespacePayload.Identity == null)
                {
                    UtilityClient.InvalidArgumentException("-IdentityType must be set to 'UserAssigned' or 'SystemAssigned, UserAssigned' to enable User Assigned Identitites");
                }

                if(!(IdentityId?.Length > 0))
                {
                    if(currentNamespacePayload.Identity.Type == ManagedServiceIdentityType.UserAssigned || currentNamespacePayload.Identity.Type == ManagedServiceIdentityType.SystemAssignedUserAssigned)
                    {
                        UtilityClient.InvalidArgumentException("-IdentityType cannot be " + currentNamespacePayload.Identity.Type + " to remove User Assigned Identities");
                    }

                    currentNamespacePayload.Identity.UserAssignedIdentities = null;
                }

                else
                {
                    if (currentNamespacePayload.Identity.Type == ManagedServiceIdentityType.SystemAssigned || currentNamespacePayload.Identity.Type == ManagedServiceIdentityType.None)
                    {
                        UtilityClient.InvalidArgumentException("-IdentityType must be set to 'UserAssigned' or 'SystemAssigned, UserAssigned' to enable User Assigned Identitites");
                    }

                    currentNamespacePayload.Identity.UserAssignedIdentities = UtilityClient.MapIdentityId(IdentityId);
                }

            }

            if (this.IsParameterBound(c => c.EncryptionConfig))
            {
                if(currentNamespacePayload.Encryption == null)
                {
                    currentNamespacePayload.Encryption = new Encryption()
                    {
                        KeyVaultProperties = UtilityClient.MapEncryptionConfig(EncryptionConfig),
                        KeySource = KeySource.MicrosoftKeyVault
                    };
                }
                else
                {
                    currentNamespacePayload.Encryption.KeyVaultProperties = UtilityClient.MapEncryptionConfig(EncryptionConfig);
                }
            }

            return currentNamespacePayload;
        }
    }
}
