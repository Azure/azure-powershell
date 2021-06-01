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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsLinkedStorageAccount", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureOperationalInsightsLinkedStorageAccountCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, 
                   Mandatory = true,
                   HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, 
                   Mandatory = true, 
                   HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "Data Source Type should be one of 'CustomLogs', 'AzureWatson', 'Query', 'Alerts'.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("CustomLogs", "AzureWatson", "Query", "Alerts", IgnoreCase = true)]
        public string DataSourceType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.WorkspaceName, string.Format("delete Linked Storage Account type: {0} from workspace: {1} under resource group", this.DataSourceType, this.WorkspaceName, this.ResourceGroupName)))
            {
                HttpStatusCode response = this.OperationalInsightsClient.DeleteLinkedStorageAccount(this.ResourceGroupName, this.WorkspaceName, this.DataSourceType);
                WriteObject(true);
            }
        }
    }
}
