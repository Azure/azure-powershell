using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkStatement, DefaultParameterSetName = StopSparkStatementByIdParameterSetName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseSparkStatement : SynapseSparkCmdletBase
    {
        private const string StopSparkStatementByIdParameterSetName = "StopSparkStatementByIdParameterSet";
        private const string StopSparkStatementByIdFromParentObjectParameterSet = "StopSparkStatementByIdFromParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkStatementByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkStatementByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopSparkStatementByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SessionObject)]
        [ValidateNotNull]
        public PSSynapseSparkSession SessionObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkStatementByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkStatementId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkStatementByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkStatementId)]
        [Alias("Id")]
        [ValidateRange(0, int.MaxValue)]
        public int LivyId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkStatementByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SessionId)]
        [ValidateRange(0, int.MaxValue)]
        public int SessionId { get; set; } = SynapseConstants.UnknownId;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SessionObject))
            {
                this.WorkspaceName = this.SessionObject.WorkspaceName;
                this.SparkPoolName = this.SessionObject.SparkPoolName;
                this.SessionId = this.SessionObject.Id.Value;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.ConfirmToStopSparkStatement, LivyId),
                string.Format(Resources.StoppingSparkStatement, LivyId),
                LivyId.ToString(),
                () =>
                {
                    SynapseAnalyticsClient.CancelSparkSessionStatement(WorkspaceName, SparkPoolName, SessionId, LivyId);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
