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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Workspaces
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsLinkedService"), OutputType(typeof(PSLinkedService))]
    public class GetAzureOperationalInsightsLinkedServiceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The linked service name.")]
        [ValidateNotNullOrEmpty]
        public string LinkedServiceName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(this.OperationalInsightsClient.FilterLinkedServices( this.ResourceGroupName, this.WorkspaceName, this.LinkedServiceName), true);
        }
    }
}
