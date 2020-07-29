using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        DefaultParameterSetName = GetByName)]
    [Alias("Export-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook)]
    [OutputType(typeof(PSNotebookResource))]
    public class GetAzureSynapseNotebook : SynapseArtifactsCmdletBase
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

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NotebookName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.OutputFolder)]
        [ValidateNotNullOrEmpty]
        public string OutputFolder { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.Name))
            {
                var notebook = new PSNotebookResource(SynapseAnalyticsClient.GetNotebook(this.Name), this.WorkspaceName);
                if (this.IsParameterBound(c => c.OutputFolder))
                {
                    string json = JsonConvert.SerializeObject(notebook.Properties, Formatting.Indented);
                    File.WriteAllText(this.OutputFolder + notebook.Name + ".ipynb", json);
                }
                else
                {
                    WriteObject(notebook);
                }
            }
            else
            {
                var notebooks = SynapseAnalyticsClient.GetNotebooksByWorkspace()
                    .Select(element => new PSNotebookResource(element, this.WorkspaceName));
                if (this.IsParameterBound(c => c.OutputFolder))
                {
                    foreach(var notebook in notebooks)
                    {
                        string json = JsonConvert.SerializeObject(notebook.Properties, Formatting.Indented);
                        File.WriteAllText(this.OutputFolder + notebook.Name + ".ipynb", json);
                    }
                }
                else
                {
                    WriteObject(notebooks, true);
                }
            }
        }
    }
}
