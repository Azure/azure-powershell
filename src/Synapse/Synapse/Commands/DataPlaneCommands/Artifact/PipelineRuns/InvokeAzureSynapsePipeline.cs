using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Pipeline,
        DefaultParameterSetName = NewByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSCreateRunResponse))]
    public class InvokeAzureSynapsePipeline : SynapseArtifactsCmdletBase
    {
        private const string NewByName = "NewByName";
        private const string NewByObject = "NewByObject";
        private const string NewByInputObject = "NewByInputObject";

        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.PipelineRunObject)]
        [ValidateNotNull]
        public PSPipelineResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByName,
            Mandatory = true, HelpMessage = HelpMessages.PipelineName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByObject,
            Mandatory = true, HelpMessage = HelpMessages.PipelineName)]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ParametersForRun)]
        [ValidateNotNullOrEmpty]
        public Hashtable Parameter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.HelpParameterFileForRun)]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ReferencePipelineRunIdForRun)]
        [ValidateNotNullOrEmpty]
        public string ReferencePipelineRunId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.IsRecoveryForRun)]
        public SwitchParameter IsRecovery { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.StartActivityNameForRun)]
        [ValidateNotNullOrEmpty]
        public string StartActivityName { get; set; }

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
                this.PipelineName = this.InputObject.Name;
            }

            Dictionary<string, object> paramDictionary = null;
            if (Parameter == null && string.IsNullOrWhiteSpace(ParameterFile))
            {
                paramDictionary = new Dictionary<string, object>();
            }
            else if (Parameter != null)
            {
                try
                {
                    paramDictionary = Parameter.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => kvp.Value);
                }
                catch (InvalidCastException ex)
                {
                    throw new InvalidCastException(Resources.InvalidCastParameterKeyExceptionMessage, ex);
                }
            }
            else
            {
                paramDictionary = ReadParametersFromJson();
            }

            bool? isRecovery = null;
            if (IsRecovery.IsPresent)
            {
                isRecovery = true;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.CreatingSynapsePipelineRun, this.WorkspaceName, this.PipelineName)))
            {
                WriteObject(SynapseAnalyticsClient.CreatePipelineRun(this.PipelineName, this.ReferencePipelineRunId, isRecovery, this.StartActivityName, paramDictionary));
            }
        }

        private Dictionary<string, object> ReadParametersFromJson()
        {
            var parameters = new Dictionary<string, object>();
            string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(ParameterFile));
            if (!string.IsNullOrWhiteSpace(rawJsonContent))
            {
                parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(rawJsonContent);
            }
            return parameters;
        }
    }
}
