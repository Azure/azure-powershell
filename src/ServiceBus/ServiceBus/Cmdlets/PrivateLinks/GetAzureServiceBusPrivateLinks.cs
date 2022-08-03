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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.PrivateLinks
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusPrivateLink", SupportsShouldProcess = true, DefaultParameterSetName = PrivateLinkPropertiesParameterSet), OutputType(typeof(PSServiceBusPrivateLinkResourceAttributes))]
    public class GetAzureServiceBusPrivateLinks : AzureServiceBusCmdletBase
    {

        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PrivateLinkPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = PrivateLinkPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: NamespaceName, action: string.Format(Resources.GetNamespacePrivateLinks, NamespaceName, ResourceGroupName)))
            {
                try
                {  
                    WriteObject(Client.GetPrivateLinkResource(ResourceGroupName, NamespaceName));
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
