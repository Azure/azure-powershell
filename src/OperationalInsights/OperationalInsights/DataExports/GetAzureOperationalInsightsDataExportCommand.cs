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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.OperationalInsights.DataExports
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsDataExport", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSDataExport))]
    public class GetAzureOperationalInsightsDataExportCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, 
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, 
            HelpMessage = "The name of the workspace that will contain the storage insight.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = "The data export name.")]
        [ValidateNotNullOrEmpty]
        public string DataExportName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource.ToLower().Replace("workspaces/", "");
                this.DataExportName = resourceIdentifier.ResourceName;
            }
            WriteObject(this.OperationalInsightsClient.FilterPSDataExports(ResourceGroupName, WorkspaceName, DataExportName), true);
        }

    }
}
