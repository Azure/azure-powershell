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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{    
    /// <summary>
    /// 'Get-AzEventHub' Cmdlet gives the details of a / List of EventHub(s)
    /// <para> If EventHub name provided, a single EventHub detials will be returned</para>
    /// <para> If EventHub name not provided, list of EventHub will be returned</para>
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHub", DefaultParameterSetName = EventhubPropertiesParameterSet), OutputType(typeof(PSEventHubAttributes))]
    public class GetAzureRmEventHub : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Resource Group Name", ParameterSetName= EventhubPropertiesParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Namespace Name", ParameterSetName = EventhubPropertiesParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = false, Position = 2, HelpMessage = "EventHub Name", ParameterSetName = EventhubPropertiesParameterSet)]
        [Parameter(Mandatory = false,  Position = 1, HelpMessage = "EventHub Name", ParameterSetName = NamespaceInputObjectParameterSet)]
        [Alias(AliasEventHubName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of EventHubs to return.", ParameterSetName = EventhubPropertiesParameterSet)]
        [ValidateNotNull]
        public int? MaxCount { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "Namespace object", ParameterSetName = NamespaceInputObjectParameterSet)]
        [ValidateNotNull]
        public PSNamespaceAttributes NamespaceObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => c.NamespaceObject))
                {
                    this.ResourceGroupName = this.NamespaceObject.ResourceGroupName;
                    this.Namespace = this.NamespaceObject.Name;
                }

                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a EventHub
                    PSEventHubAttributes eventHub = Client.GetEventHub(ResourceGroupName, Namespace, Name);
                    WriteObject(eventHub);
                }
                else
                {
                    if (MaxCount.HasValue)
                    {
                        IEnumerable<PSEventHubAttributes> eventHubsList = Client.ListAllEventHubs(ResourceGroupName, Namespace, MaxCount);
                        WriteObject(eventHubsList.ToList(), true);
                    }
                    else
                    {
                        // Get all EventHubs
                        IEnumerable<PSEventHubAttributes> eventHubsList = Client.ListAllEventHubs(ResourceGroupName, Namespace);
                        WriteObject(eventHubsList.ToList(), true);
                    }
                }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
