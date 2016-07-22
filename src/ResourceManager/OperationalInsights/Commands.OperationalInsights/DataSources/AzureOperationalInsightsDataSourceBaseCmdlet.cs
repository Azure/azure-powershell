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
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    public abstract class AzureOperationalInsightsDataSourceBaseCmdlet : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that will contain the data source.")]
        [ValidateNotNull]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the data source.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected void CreatePSDataSourceWithProperties(PSDataSourcePropertiesBase createParameters, string dataSourceName)
        {
            CreatePSDataSourceParameters parameters = new CreatePSDataSourceParameters()
            {
                Name = dataSourceName,
                Properties = createParameters,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };
            if (ParameterSetName == ByWorkspaceObject)
            {
                parameters.ResourceGroupName = Workspace.ResourceGroupName;
                parameters.WorkspaceName = Workspace.Name;
            }
            else
            {
                parameters.ResourceGroupName = ResourceGroupName;
                parameters.WorkspaceName = WorkspaceName;
            }
            WriteObject(OperationalInsightsClient.CreatePSDataSource(parameters));
        }

    }
}