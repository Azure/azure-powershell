using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Commands.DataPlaneCommands.Artifact.Notebooks
{
    [Cmdlet(VerbsData.Export, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        DefaultParameterSetName = ExportByName)]
    [OutputType(typeof(FileInfo))]
    public class ExportAzureSynapseNotebook : SynapseArtifactsCmdletBase
    {
        private const string ExportByName = "ExportByName";
        private const string ExportByObject = "ExportByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ExportByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ExportByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NotebookName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.OutputFolder)]
        [ValidateNotNullOrEmpty]
        public string OutputFolder { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.Name))
            {
                var notebook = new PSNotebookResource(SynapseAnalyticsClient.GetNotebook(this.Name), this.WorkspaceName);
                WriteToFile(notebook);
            }
            else
            {
                var notebooks = SynapseAnalyticsClient.GetNotebooksByWorkspace()
                    .Select(element => new PSNotebookResource(element, this.WorkspaceName));
                foreach (var notebook in notebooks)
                {
                    WriteToFile(notebook);
                }
            }
            WriteObject(new DirectoryInfo(this.OutputFolder).EnumerateFiles());
        }

        private void WriteToFile(PSNotebookResource notebook)
        {
            string json = JsonConvert.SerializeObject(notebook.Properties, Formatting.Indented);
            File.WriteAllText(Path.Combine(this.OutputFolder, notebook.Name + ".ipynb"), json);
        }
    }
}
