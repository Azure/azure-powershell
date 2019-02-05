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

using System;
using System.Linq;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.OperationalInsights.Properties;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsApplicationInsightsDataSource", SupportsShouldProcess = true, DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class NewAzureOperationalInsightsApplicationInsightsDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        const string ByWorkspaceNameByApplicationResourceId = "ByWorkspaceNameByApplicationResourceId";
        const string ByWorkspaceObjectByApplicationResourceId = "ByWorkspaceObjectByApplicationResourceId";
        const string ByWorkspaceNameByApplicationParameters = "ByWorkspaceNameByApplicationParameters";
        const string ByWorkspaceObjectByApplicationParameters = "ByWorkspaceObjectByApplicationParameters";

        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObjectByApplicationParameters, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that will contain the data source.")]
        [Parameter(ParameterSetName = ByWorkspaceObjectByApplicationResourceId)]
        [ValidateNotNull]
        public override PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceNameByApplicationParameters, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ByWorkspaceNameByApplicationResourceId)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceNameByApplicationParameters, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the workspace that will contain the data source.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = ByWorkspaceNameByApplicationResourceId)]
        public override string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByWorkspaceNameByApplicationParameters, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The subscription id of the linked application.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = ByWorkspaceObjectByApplicationParameters)]
        public string ApplicationSubscriptionId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByWorkspaceNameByApplicationParameters, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the linked application.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = ByWorkspaceObjectByApplicationParameters)]
        public string ApplicationResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByWorkspaceNameByApplicationParameters, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the linked application.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = ByWorkspaceObjectByApplicationParameters)]
        public string ApplicationName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByWorkspaceNameByApplicationResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The linked application resource id.")]
        [Parameter(ParameterSetName = ByWorkspaceObjectByApplicationResourceId)]
        [ValidateNotNullOrEmpty]
        public string ApplicationResourceId { get; set; }

        [Parameter(Mandatory = false, 
            HelpMessage = "Don't ask for confirmation.")]
        public override SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Name = PSDataSourceKinds.ApplicationInsights;
            if (ParameterSetName == ByWorkspaceObjectByApplicationParameters || ParameterSetName == ByWorkspaceObjectByApplicationResourceId)
            {
                ResourceGroupName = Workspace.ResourceGroupName;
                WorkspaceName = Workspace.Name;
            }

            var resourceId = default(string);

            if (ParameterSetName == ByWorkspaceObjectByApplicationParameters || ParameterSetName == ByWorkspaceNameByApplicationParameters)
            {
                resourceId = string.Format(Resources.ApplicationInsightsArmResourceFormat, ApplicationSubscriptionId, ApplicationResourceGroupName, ApplicationName);
            }

            if (ParameterSetName == ByWorkspaceObjectByApplicationResourceId || ParameterSetName == ByWorkspaceNameByApplicationResourceId)
            {
                ValidateResourceId(ApplicationResourceId);
                resourceId = ApplicationResourceId;
            }

            var applicationInsightsProperties = new PSApplicationInsightsDataSourceProperties()
            {
                LinkedResourceId = resourceId
            };
            CreatePSDataSourceWithProperties(applicationInsightsProperties);
        }

        private void ValidateResourceId(string resourceId)
        {
            int[] indicesToRemove = {1, 3, 7};
            // get only constant tokens in arm url template and compare
            var actualTokens = resourceId.Trim('/').Split('/').Where((token, idx) => !indicesToRemove.Contains(idx)).ToArray();
            var expectedTokens = Resources.ApplicationInsightsArmResourceFormat.Trim('/').Split('/').Where((token, idx) => !indicesToRemove.Contains(idx)).ToArray();
            if (actualTokens.Except(expectedTokens).Any())
            {
                throw new ArgumentException(Resources.DataSourceInvalidApplicationInsightsResourceId);
            }
        }
    }
}
