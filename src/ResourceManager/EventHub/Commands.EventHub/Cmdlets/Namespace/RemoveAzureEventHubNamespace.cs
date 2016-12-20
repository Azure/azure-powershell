﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Remove-AzureRmEventHubNamespace' Cmdlet deletes the specified Eventhub Namespace
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubNamespaceVerb, SupportsShouldProcess = true)]
    public class RemoveAzureRmEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            // delete a EventHub namespace 
            if(ShouldProcess(target:NamespaceName,action:string.Format("Delete NameSpace:{0} from ResourceGroup:{1}",NamespaceName,ResourceGroupName)))
            {
                Client.BeginDeleteNamespace(ResourceGroupName, NamespaceName);
            }            
        }
    }
}
