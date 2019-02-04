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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.OperationalInsights.Properties;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsApplicationInsightsDataSource", SupportsShouldProcess = true, DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class NewAzureOperationalInsightsApplicationInsightsDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObject, Mandatory = true, ValueFromPipeline = true, 
            HelpMessage = "The workspace that will contain the data source.")]
        [ValidateNotNull]
        public override PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the workspace that will contain the data source.")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The subscription id of the linked application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationSubscriptionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the linked application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the linked application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationName { get; set; }

        [Parameter(Mandatory = false, 
            HelpMessage = "Don't ask for confirmation.")]
        public override SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Name = PSDataSourceKinds.ApplicationInsights;
            var applicationInsightsProperties = new PSApplicationInsightsDataSourceProperties()
            {
                LinkedResourceId = string.Format(Resources.ApplicationInsightsArmResourceFormat,
                    ApplicationSubscriptionId, ApplicationResourceGroupName, ApplicationName)
            };
            CreatePSDataSourceWithProperties(applicationInsightsProperties);
        }
    }
}
