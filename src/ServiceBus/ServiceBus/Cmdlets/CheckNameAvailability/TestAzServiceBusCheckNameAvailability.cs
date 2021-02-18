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
using Microsoft.Azure.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ServiceBus.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'Test-AzureRmCheckNameAvailability' Cmdlet Check Availability of the NameSpace Name
    /// </summary>
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusNameAvailability", DefaultParameterSetName = QueueCheckNameAvailabilityParameterSet), OutputType(typeof(bool))]
    public class TestAzServiceBusCheckNameAvailability : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [Alias("ResourceGroup")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]        
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Servicebus Namespace Name")]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Queue or Topic Name to check the Name Availability")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueCheckNameAvailabilityParameterSet, HelpMessage = "To Check Name Availability for Queue Name")]
        public SwitchParameter Queue { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TopicCheckNameAvailabilityParameterSet, HelpMessage = "To Check Name Availability for Topic Name")]
        public SwitchParameter Topic { get; set; }


        public override void ExecuteCmdlet()
        {
            try
            {
                PSCheckNameAvailabilityResultAttributes checkNameresult = new PSCheckNameAvailabilityResultAttributes();
                try
                {
                    if (ParameterSetName.Equals(QueueCheckNameAvailabilityParameterSet) && Queue.IsPresent)
                    {
                        PSQueueAttributes getQueueResult = Client.GetQueue(ResourceGroupName, Namespace, Name);
                        if (getQueueResult.Name.Equals(Name))
                        {
                            WriteObject(false);
                        }
                    }

                    if (ParameterSetName.Equals(TopicCheckNameAvailabilityParameterSet) && Topic.IsPresent)
                    {
                        PSTopicAttributes getTopicResult = Client.GetTopic(ResourceGroupName, Namespace, Name);
                        if (getTopicResult.Name.Equals(Name))
                        {                            
                            WriteObject(false);
                        }
                    }

                }
                catch (ErrorResponseException ex)
                {
                    if (ex.Message.ToLower().Contains("notfound"))
                    {
                        WriteObject(true);
                    }
                }                
            }
            catch (ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
