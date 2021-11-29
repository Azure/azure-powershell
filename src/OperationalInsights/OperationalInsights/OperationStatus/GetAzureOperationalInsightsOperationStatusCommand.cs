// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.OperationStatus
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsOperationStatus", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSOperationStatus))]
    public class GetAzureOperationalInsightsOperationStatusCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = "The region name of operation.")]
        [LocationCompleter("Microsoft.OperationalInsights/workspaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = "The Id (Guid) of the operation.")]
        [ValidateNotNullOrEmpty]
        public string OperationId { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(this.OperationalInsightsClient.GetOperationStatus(this.OperationId, this.Location), true);
        }
    }
}
