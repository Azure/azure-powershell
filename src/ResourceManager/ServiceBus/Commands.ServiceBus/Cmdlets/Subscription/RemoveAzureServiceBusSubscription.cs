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

using System.Management.Automation;
namespace Microsoft.Azure.Commands.ServiceBus.Commands.Subscription
{
    /// <summary>
    /// 'Remove-AzureRmServiceBusSubscription' Cmdlet removes the specified Subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ServicebusSubscriptionVerb, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmServiceBusSubscription : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Subscription Name.")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName { get; set; }

        public override void ExecuteCmdlet()
        {
            // delete a Subscription 
            if (ShouldProcess(target: SubscriptionName, action: string.Format("Deleting Subscription:{0} for Topic:{1} of NameSpace:{2}", SubscriptionName, TopicName, NamespaceName)))
            {
                WriteObject(Client.DeleteSubscription(ResourceGroup, NamespaceName, TopicName, SubscriptionName));
            }
        }
    }
}
