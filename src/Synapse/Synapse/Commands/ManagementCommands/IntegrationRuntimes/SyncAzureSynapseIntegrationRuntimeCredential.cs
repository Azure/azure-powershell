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
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Sync, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime + SynapseConstants.Credential,
        DefaultParameterSetName = StopByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class SyncAzureSynapseIntegrationRuntimeCredential : SynapseManagementCmdletBase
    {
        private const string StopByNameParameterSet = "StopByNameParameterSet";
        private const string StopByParentObjectParameterSet = "StopByParentObjectParameterSet";
        private const string StopByResourceIdParameterSet = "StopByResourceIdParameterSet";
        private const string StopByInputObjectParameterSet = "StopByInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.DontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.IntegrationRuntimeName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.WorkspaceName = InputObject.WorkspaceName;
                this.IntegrationRuntimeName = InputObject.Name;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeSyncNodeCredential,
                    IntegrationRuntimeName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SyncingIntegrationRuntimeNodeCredential,
                    IntegrationRuntimeName),
                IntegrationRuntimeName,
                () => SynapseAnalyticsClient.SyncIntegrationRuntimeCredentialInNodesAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    IntegrationRuntimeName).ConfigureAwait(true).GetAwaiter().GetResult());
        }
    }
}
