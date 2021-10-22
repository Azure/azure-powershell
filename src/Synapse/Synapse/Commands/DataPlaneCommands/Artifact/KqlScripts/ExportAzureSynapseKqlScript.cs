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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Export, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.KqlScript,
        DefaultParameterSetName = ExportByName)]
    [OutputType(typeof(FileInfo))]
    public class ExportAzureSynapseKqlScript : SynapseArtifactsCmdletBase
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

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = ExportByName,
            HelpMessage = HelpMessages.KqlScriptName)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = ExportByObject,
            HelpMessage = HelpMessages.KqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("KqlScriptName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ExportByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.KqlScriptObject)]
        [ValidateNotNull]
        public PSKqlScriptResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.KqlScriptOutputFolder)]
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

            var fileExtension = ".kql";
            if (this.IsParameterBound(c => c.InputObject))
            {
                WriteToFile(this.InputObject);
                WriteObject(new FileInfo(Path.Combine(this.OutputFolder, this.InputObject.Name + fileExtension)));
            }
            else
            {
                if (this.IsParameterBound(c => c.Name))
                {
                    var kqlScript = new PSKqlScriptResource(SynapseAnalyticsClient.GetKqlScript(this.Name), this.WorkspaceName);
                    WriteToFile(kqlScript);
                    WriteObject(new FileInfo(Path.Combine(this.OutputFolder, kqlScript.Name + fileExtension)));
                }
                else
                {
                    var infoList = new List<FileInfo>();
                    var kqlScripts = SynapseAnalyticsClient.GetKqlScriptsByWorkspace()
                        .Select(element => new PSKqlScriptResource(element, this.WorkspaceName));
                    foreach (var kqlScript in kqlScripts)
                    {
                        WriteToFile(kqlScript);
                        infoList.Add(new FileInfo(Path.Combine(this.OutputFolder, kqlScript.Name + fileExtension)));
                    }
                    WriteObject(infoList, true);
                }
            }
        }

        private void WriteToFile(PSKqlScriptResource kqlScript)
        {
            string query = kqlScript?.Properties?.Content?.Query;
            File.WriteAllText(Path.Combine(this.OutputFolder, kqlScript.Name + ".kql"), query);
        }
    }
}
