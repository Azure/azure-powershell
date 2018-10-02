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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.serviceBus
{
    /// <summary>
    /// 'Get-AzureRmServiceBusIPFilterRule' Cmdlet gives the details of a / List of IPFilterRule(s)
    /// <para> If IPFilterRule name provided, a single IPFilterRule detials will be returned</para>
    /// <para> If IPFilterRule name not provided, list of IPFilterRule will be returned</para>
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusIPFilterRule", DefaultParameterSetName = IpFilterRulePropertiesParameterSet), OutputType(typeof(PSIpFilterRuleAttributes))]
    public class GetAzureServiceBusIpFilterRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = IpFilterRulePropertiesParameterSet, HelpMessage = "IP Filter Rule Name")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRuleResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Ip Filter Rule Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
         
        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(IpFilterRuleResourceIdParameterSet))
                {
                    LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                    ResourceGroupName = identifier.ResourceGroupName;
                    Namespace = identifier.ParentResource;
                    Name = identifier.ResourceName;
                }

                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Ipfilter Rule
                    PSIpFilterRuleAttributes sbIPFilterRule = Client.GetIPFilterRule(ResourceGroupName, Namespace, Name);
                    WriteObject(sbIPFilterRule);
                }
                else
                {
                    IEnumerable<PSIpFilterRuleAttributes> sbIPFilterRulesList = Client.ListIPFilterRule(ResourceGroupName, Namespace);
                    WriteObject(sbIPFilterRulesList.ToList(), true);
                }
            }
            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBus.ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
