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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleDefinition,
        DefaultParameterSetName = GetByWorkspaceNameAndIdParameterSet)]
    [OutputType(typeof(PSSynapseRole))]
    public class GetAzureSynapseRoleDefinition : SynapseRoleCmdletBase
    {
        private const string GetByWorkspaceNameAndIdParameterSet = "GetByWorkspaceNameAndIdParameterSet";
        private const string GetByWorkspaceObjectAndIdParameterSet = "GetByWorkspaceObjectAndIdParameterSet";
        private const string GetByWorkspaceNameAndNameParameterSet = "GetByWorkspaceNameAndNameParameterSet";
        private const string GetByWorkspaceObjectAndNameParameterSet = "GetByWorkspaceObjectAndNameParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.Id))
            {
                WriteObject(new PSSynapseRole(SynapseAnalyticsClient.GetRoleDefinitionById(this.Id)));
            }
            else
            {
                var roleDefinitions = SynapseAnalyticsClient.GetRoleDefinitions()
                    .Select(element => new PSSynapseRole(element));
                if (this.IsParameterBound(c => c.Name))
                {
                    PSSynapseRole role = roleDefinitions.SingleOrDefault(element => element.Name == this.Name);
                    if (role == null)
                    {
                        throw new AzPSInvalidOperationException(String.Format(Resources.RoleDefinitionNameDoesNotExist, this.Name));
                    }
                    WriteObject(role);
                }
                else
                {
                    WriteObject(roleDefinitions, true);
                }
            } 
        }
    }
}
