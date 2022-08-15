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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.NetworkruleSet
{    
    /// <summary>
    /// 'Get-AzureRmEventHub' Cmdlet gives the details of a / List of EventHub(s)
    /// <para> If EventHub name provided, a single EventHub detials will be returned</para>
    /// <para> If EventHub name not provided, list of EventHub will be returned</para>
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusNetworkRuleSet", DefaultParameterSetName = NetworkRuleSetPropertiesParameterSet), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class GetAzureServiceBusNetworkRuleSet : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = false, ParameterSetName = NetworkRuleSetNamespacePropertiesParameterSet, HelpMessage = "Resource Group Name")]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetPropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetNamespacePropertiesParameterSet, Position = 0, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                string test = ResourceId;
               if (ParameterSetName.Equals(NetworkRuleSetResourceIdParameterSet))
                {
                    ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = identifier.ResourceGroupName;
                    Namespace = identifier.ResourceName;

                    PSNetworkRuleSetAttributes networkruleSet = Client.GetNetworkRuleSet(ResourceGroupName, Namespace);
                    WriteObject(networkruleSet);
                }

                if (ParameterSetName.Equals(NetworkRuleSetPropertiesParameterSet))
                {
                    // Get a VNet Rule
                    PSNetworkRuleSetAttributes networkruleSet = Client.GetNetworkRuleSet(ResourceGroupName, Namespace);
                    WriteObject(networkruleSet);
                }

                // only Namespacename provided
                if (ParameterSetName.Equals(NetworkRuleSetNamespacePropertiesParameterSet))
                {
                    var namespaceNames = Client.ListAllNamespaces();
                    IEnumerable<string>  ResourceGrouplst = from nsName in namespaceNames
                                        where nsName.Name == Namespace
                                        select nsName.ResourceGroup;

                    PSNetworkRuleSetAttributes networkruleSet = Client.GetNetworkRuleSet(ResourceGrouplst.FirstOrDefault(), Namespace);
                    WriteObject(networkruleSet);                    
                }

            }
            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
