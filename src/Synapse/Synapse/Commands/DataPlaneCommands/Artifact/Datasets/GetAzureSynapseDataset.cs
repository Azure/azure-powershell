using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Dataset,
        DefaultParameterSetName = GetByName)]
    [OutputType(typeof(PSDatasetResource))]
    public class GetAzureSynapseDataset : SynapseArtifactsCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DatasetName)]
        [ValidateNotNullOrEmpty]
        [Alias("DatasetName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.Name))
            {
                WriteObject(new PSDatasetResource(SynapseAnalyticsClient.GetDataset(this.Name), this.WorkspaceName));
            }
            else
            {
                var datasets = SynapseAnalyticsClient.GetDatasetsByWorkspace()
                    .Select(element => new PSDatasetResource(element, this.WorkspaceName));
                WriteObject(datasets, true);
            }
        }
    }
}
