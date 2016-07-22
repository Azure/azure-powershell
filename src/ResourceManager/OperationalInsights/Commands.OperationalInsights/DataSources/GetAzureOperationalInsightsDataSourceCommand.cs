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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Get, Constants.DataSource, DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(List<PSDataSource>), typeof(PSDataSource))]
    public class GetAzureOperationalInsightsDataSourceCommand : OperationalInsightsBaseCmdlet
    {
        const string ByWorkspaceObjectByName = "ByWorkspaceObjectByName";
        const string ByWorkspaceObjectByKind = "ByWorkspaceObjectByKind";
        const string ByWorkspaceNameByKind = "ByWorkspaceNameByKind";
        const string ByWorkspaceNameByName = "ByWorkspaceNameByName";

        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObjectByName, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that containts the datasource(s).")]
        [Parameter(ParameterSetName = ByWorkspaceObjectByKind)]
        [ValidateNotNull]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceNameByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ByWorkspaceNameByKind)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceNameByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that contains the datasource(s).")]
        [Parameter(ParameterSetName = ByWorkspaceNameByKind)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 3, ParameterSetName = ByWorkspaceNameByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data source name.")]
        [Parameter(ParameterSetName = ByWorkspaceObjectByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        // ValidateSet below should exclude the singleton data source kinds, those kind are well covered by Enable- , Disable- cmdlets.
        [Parameter(Position = 4, ParameterSetName = ByWorkspaceNameByKind, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The data source name.")]
        [Parameter(ParameterSetName = ByWorkspaceObjectByKind)]
        [ValidateSet(
            PSDataSourceKinds.AzureAuditLog,
            PSDataSourceKinds.CustomLog,
            PSDataSourceKinds.LinuxPerformanceObject,
            PSDataSourceKinds.LinuxSyslog,
            PSDataSourceKinds.WindowsEvent,
            PSDataSourceKinds.WindowsPerformanceCounter)]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByWorkspaceObjectByName || ParameterSetName == ByWorkspaceObjectByKind)
            {
                ResourceGroupName = Workspace.ResourceGroupName;
                WorkspaceName = Workspace.Name;
            }

            if (ParameterSetName == ByWorkspaceObjectByName || ParameterSetName == ByWorkspaceNameByName) {
                WriteObject(OperationalInsightsClient.GetDataSource(ResourceGroupName, WorkspaceName, Name), true);
                return;
            }

            if (ParameterSetName == ByWorkspaceObjectByKind || ParameterSetName == ByWorkspaceNameByKind) {
                WriteObject(OperationalInsightsClient.FilterPSDataSources(ResourceGroupName, WorkspaceName, Kind), true);
                return;
            }
            
        }
    }
}