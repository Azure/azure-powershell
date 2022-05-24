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
using Microsoft.Azure.Commands.EventHub;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;

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
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Namespace Location.")]
        [LocationCompleter("Microsoft.EventHub/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Namespace Sku Name.")]
        [ValidateSet(SKU.Basic,
          SKU.Standard,
          SKU.Premium,
          IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 4,HelpMessage = "The eventhub throughput units.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The eventhub throughput units.")]
        public int? SkuCapacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tag.")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "Hashtables which represents resource Tag.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AutoInflateParameterSet, HelpMessage = "Indicates whether AutoInflate is enabled")]
        public SwitchParameter EnableAutoInflate { get; set; }

        /// <summary>
        /// Upper limit of throughput units when AutoInflate is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.")]
        [ValidateRange(0,20)]        
        public int? MaximumThroughputUnits { get; set; }

        /// <summary>
        /// Indicates whether Kafka is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, HelpMessage = "enabling or disabling Kafka for namespace")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling Kafka for namespace")]
        public SwitchParameter EnableKafka { get; set; }


        /// <summary>
        /// Indicates whether DisableLocalAuth is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, HelpMessage = "enabling or disabling  SAS authentication for namespace")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, HelpMessage = "enabling or disabling SAS authentication for namespace")]
        public SwitchParameter DisableLocalAuth { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type ('SystemAssigned', 'UserAssigned', 'SystemAssigned', 'UserAssigned', 'None')")]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        public string[] IdentityId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        [Parameter(Mandatory = false, ParameterSetName = AutoInflateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }


        public override void ExecuteCmdlet()
        {
            // Update a EventHub namespace 
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateNamespace, Name, ResourceGroupName)))
            {
                try
                {
                    WriteObject(Client.BeginUpdateNamespace(resourceGroupName: ResourceGroupName,
                                                            namespaceName: Name,
                                                            location: Location,
                                                            skuName: SkuName,
                                                            skuCapacity: SkuCapacity,
                                                            tags: tagDictionary,
                                                            isAutoInflateEnabled: EnableAutoInflate.IsPresent,
                                                            maximumThroughputUnits: MaximumThroughputUnits,
                                                            isKafkaEnabled: EnableKafka.IsPresent,
                                                            isDisableLocalAuth: DisableLocalAuth.IsPresent,
                                                            identityId: IdentityId,
                                                            identityType: IdentityType,
                                                            encryptionConfigs: EncryptionConfig));                
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
