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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{ 
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Trigger + SynapseConstants.Subscription,
        DefaultParameterSetName = AddByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSTriggerSubscriptionOperationStatus))]
    public class AddAzureSynapseTriggerSubscription : SynapseArtifactsCmdletBase
    {
        private const string AddByName = "AddByName";
        private const string AddByObject = "AddByObject";
        private const string AddByInputObject = "AddByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = AddByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByName,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias("TriggerName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = AddByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerObject)]
        [ValidateNotNull]
        public PSTriggerResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.WorkspaceName = this.InputObject.WorkspaceName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.Name, String.Format(Resources.AddingSynapseTriggerSubscribe, this.Name)))
            {
                WriteObject(new PSTriggerSubscriptionOperationStatus(SynapseAnalyticsClient.SubscribeTriggerToEvents(this.Name)));
            }
        }
    }
}
