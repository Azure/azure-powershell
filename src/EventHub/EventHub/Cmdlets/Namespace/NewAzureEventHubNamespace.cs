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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// this commandlet will let you Create Eventhub namespace.
    /// </summary>
    [CmdletOutputBreakingChange(typeof(PSNamespaceAttributes), DeprecatedOutputProperties = new string[] {"ResourceGroup", "Identity"}, NewOutputProperties = new string[] { "ResourceGroupName", "Tags", "IdentityType"})]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubNamespace", SupportsShouldProcess = true, DefaultParameterSetName = NamespaceParameterSet), OutputType(typeof(PSNamespaceAttributes))]
    public class NewAzureEventHubNamespace : AzureEventHubsCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }

        /// <summary>
        /// EventHub Namespace Location.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Namespace Sku Name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic, SKU.Standard, SKU.Premium, IgnoreCase = true)]
        public string SkuName { get; set; }

        /// <summary>
        /// The eventhub throughput units.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }

        /// <summary>
        /// Hashtables which represents resource Tags.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tags.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, HelpMessage = "Indicates whether AutoInflate is enabled")]
        public SwitchParameter EnableAutoInflate { get; set; }


        /// <summary>
        /// Upper limit of throughput units when AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 6, HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.")]
        [ValidateRange(0, 40)]
        public int? MaximumThroughputUnits { get; set; }


        /// <summary>
        /// Indicates whether Kafka is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, HelpMessage = "enabling or disabling Kafka for namespace")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling Kafka for namespace")]
        public SwitchParameter EnableKafka { get; set; }


        /// <summary>
        /// Indicates whether ZoneRedundant is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, HelpMessage = "enabling or disabling Zone Redundant for namespace")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling Zone Redundant for namespace")]
        public SwitchParameter ZoneRedundant { get; set; }


        /// <summary>
        /// Cluster ARM ID
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ARM ID of Cluster where namespace is to be created")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ARM ID of Cluster where namespace is to be created")]
        [ValidateNotNullOrEmpty]
        public string ClusterARMId { get; set; }


        /// <summary>
        /// Indicates whether DisableLocalAuth is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, HelpMessage = "enabling or disabling  SAS authentication for namespace")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling SAS authentication for namespace")]
        public SwitchParameter DisableLocalAuth { get; set; }


        /// <summary>
        /// Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')")]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }


        /// <summary>
        /// User Assigned Identity Id's
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        public string[] IdentityId { get; set; }


        /// <summary>
        /// List of KeyVaultProperties
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }


        /// <summary>
        /// List of KeyVaultProperties
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum TLS version for the namespace to support, e.g. '1.2'")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum TLS version for the namespace to support, e.g. '1.2'")]
        [ValidateSet("1.0", "1.1", "1.2", IgnoreCase = true)]
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateNamespace, Name, ResourceGroupName)))
            {
                try
                {
                    EHNamespace createNamespacePayload = CreateNamespacePayload();
                    PSNamespaceAttributes createdNamespace = UtilityClient.SendNamespaceCreateOrUpdateRequest(ResourceGroupName, Name, createNamespacePayload);
                    WriteObject(createdNamespace);
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }

        internal EHNamespace CreateNamespacePayload()
        {
            EHNamespace createNamespacePayload = new EHNamespace();

            createNamespacePayload.Location = Location;

            if (this.IsParameterBound(c => c.SkuName))
            {
                createNamespacePayload.Sku = new Sku()
                {
                    Name = SkuName,
                    Tier = SkuName
                };
            }

            if (this.IsParameterBound(c => c.SkuCapacity))
            {
                if (createNamespacePayload.Sku == null)
                {
                    throw new System.Exception("Missing -SkuName");
                }

                createNamespacePayload.Sku.Capacity = SkuCapacity;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

                createNamespacePayload.Tags = tagDictionary;
            }

            if (this.IsParameterBound(c => c.EnableAutoInflate))
            {
                createNamespacePayload.IsAutoInflateEnabled = EnableAutoInflate.IsPresent;
            }

            if (this.IsParameterBound(c => c.EnableKafka))
            {
                createNamespacePayload.KafkaEnabled = EnableKafka.IsPresent;
            }

            if (this.IsParameterBound(c => c.ZoneRedundant))
            {
                createNamespacePayload.ZoneRedundant = ZoneRedundant.IsPresent;
            }

            if (this.IsParameterBound(c => c.DisableLocalAuth))
            {
                createNamespacePayload.DisableLocalAuth = DisableLocalAuth.IsPresent;
            }

            if (this.IsParameterBound(c => c.MaximumThroughputUnits))
            {
                createNamespacePayload.MaximumThroughputUnits = MaximumThroughputUnits;
            }

            if (this.IsParameterBound(c => c.ClusterARMId))
            {
                createNamespacePayload.ClusterArmId = ClusterARMId;
            }

            if (this.IsParameterBound(c => c.MinimumTlsVersion))
            {
                createNamespacePayload.MinimumTlsVersion = MinimumTlsVersion;
            }

            if (this.IsParameterBound(c => c.IdentityType))
            {
                createNamespacePayload.Identity = new Identity()
                {
                    Type = UtilityClient.FindIdentity(IdentityType)
                };
            }

            if (this.IsParameterBound(c => c.IdentityId))
            {
                if (createNamespacePayload.Identity == null || createNamespacePayload.Identity.Type == ManagedServiceIdentityType.SystemAssigned || createNamespacePayload.Identity.Type == ManagedServiceIdentityType.None)
                {
                    UtilityClient.InvalidArgumentException("-IdentityType must be set to 'UserAssigned' or 'SystemAssigned, UserAssigned' to enable User Assigned Identitites");
                }

                createNamespacePayload.Identity.UserAssignedIdentities = UtilityClient.MapIdentityId(IdentityId);
            }

            if (this.IsParameterBound(c => c.EncryptionConfig))
            {
                createNamespacePayload.Encryption = new Encryption()
                {
                    KeyVaultProperties = UtilityClient.MapEncryptionConfig(EncryptionConfig),
                    KeySource = KeySource.MicrosoftKeyVault
                };
            }

            return createNamespacePayload;
        }
    }
}
