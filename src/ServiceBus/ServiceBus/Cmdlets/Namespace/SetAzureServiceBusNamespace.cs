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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ServiceBus.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'Set-AzServiceBusNamespace' Cmdlet updates the specified ServiceBus Namespace
    /// </summary>
    [CmdletOutputBreakingChange(typeof(PSNamespaceAttributes), DeprecatedOutputProperties = new string[] { "ResourceGroup" }, NewOutputProperties = new string[] { "ResourceGroupName" })]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusNamespace", SupportsShouldProcess = true), OutputType(typeof(PSNamespaceAttributes))]
    public class SetAzureRmServiceBusNamespace : AzureServiceBusCmdletBase
    {
        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]        
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// ServiceBus Namespace Location.
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ServiceBus Namespace Location")]
        [LocationCompleter("Microsoft.ServiceBus/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// ServiceBus Namespace Name.
        /// </summary>
        [Parameter( Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "ServiceBus Namespace Name")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Namespace Sku Name.
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace Sku Name")]
        [ValidateSet(SKU.Basic, SKU.Standard, SKU.Premium, IgnoreCase = true)]
        public string SkuName { get; set; }

        /// <summary>
        /// Namespace Sku Capacity.
        /// </summary>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Namespace Sku Capacity.")]        
        public int? SkuCapacity { get; set; }

        /// <summary>
        /// Hashtables which represents resource Tags.
        /// </summary>
        [Parameter( Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Hashtables which represents resource Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Indicates whether DisableLocalAuth is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "enabling or disabling SAS authentication for the Service Bus namespace")]
        public SwitchParameter DisableLocalAuth { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Identity Type")]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "List of user assigned Identity Ids")]
        public string[] IdentityId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Property")]
        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {

                if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateNamespace, Name, ResourceGroupName)))
                {
                    try
                    {
                        WriteObject(Client.UpdateNamespace(resourceGroupName: ResourceGroupName, 
                                                           namespaceName: Name, 
                                                           location :Location, 
                                                           skuName: SkuName, 
                                                           skuCapacity: SkuCapacity, 
                                                           tags: Tag, 
                                                           isDisableLocalAuth: DisableLocalAuth.IsPresent, 
                                                           identityType: IdentityType, 
                                                           identityIds: IdentityId, 
                                                           encryptionconfigs: EncryptionConfig));
                    }
                    catch (Management.ServiceBus.Models.ErrorResponseException ex)
                    {
                        WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
