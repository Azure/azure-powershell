using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript,
           DefaultParameterSetName = ExportByName)]
    [OutputType(typeof(PSSqlScriptResource))]
    public class ExportAzureSynapseSqlScript: SynapseArtifactsCmdletBase
    {
        private const string ExportByName = "ExportByName";
        private const string ExportByObject = "ExportByObject";
        private const string ExportByInputObject = "ExportByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ExportByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ExportByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ExportByInputObject,
         Mandatory = true, HelpMessage = HelpMessages.SqlScriptObject)]
        [ValidateNotNull]
        public PSSqlScriptResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SqlScriptOutputFolder)]
        [ValidateNotNullOrEmpty]
        public string OutputFolder { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = ExportByName,
            HelpMessage = HelpMessages.SqlScriptName)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = ExportByObject,
            HelpMessage = HelpMessages.SqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("SqlScriptName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            var fileExtension = ".sql";
            if (this.IsParameterBound(c => c.InputObject))
            {
                WriteToFile(this.InputObject);
                WriteObject(new FileInfo(Path.Combine(this.OutputFolder, this.InputObject.Name + fileExtension)));
            }
            else 
            {
                if (this.IsParameterBound(c => c.Name))
                {
                    var sqlscript = new PSSqlScriptResource(SynapseAnalyticsClient.GetSqlScript(this.Name),this.WorkspaceName);
                    WriteToFile(sqlscript);
                    WriteObject(new FileInfo(Path.Combine(this.OutputFolder, sqlscript.Name + fileExtension)));
                }
                else
                {
                    var infoList = new List<FileInfo>();
                    var sqlscripts = SynapseAnalyticsClient.GetSqlScriptsByWorkspace()
                        .Select(element => new PSSqlScriptResource(element, this.WorkspaceName));
                    foreach (var sqlscript in sqlscripts)
                    {
                        WriteToFile(sqlscript);
                        infoList.Add(new FileInfo(Path.Combine(this.OutputFolder, sqlscript.Name + fileExtension)));
                    }
                    WriteObject(infoList, true);
                }
            }
        }

        private void WriteToFile(PSSqlScriptResource sqlscript)
        {
            var sqlquery = sqlscript?.Properties?.Content?.Query;
            File.WriteAllText(Path.Combine(this.OutputFolder, sqlscript.Name + ".sql"), sqlquery);
        }
    }
}
