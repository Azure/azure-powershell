using Azure.Analytics.Synapse.Spark.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkStatement, DefaultParameterSetName = RunSparkStatementByCodePathParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseExtendedSparkStatement))]
    public class InvokeAzureSynapseSparkStatement : SynapseSparkCmdletBase
    {
        private const string RunSparkStatementByCodeParameterSet = nameof(RunSparkStatementByCodeParameterSet);
        private const string RunSparkStatementByCodeAndInputObjectParameterSet = nameof(RunSparkStatementByCodeAndInputObjectParameterSet);
        private const string RunSparkStatementByCodePathParameterSet = nameof(RunSparkStatementByCodePathParameterSet);
        private const string RunSparkStatementByCodePathAndInputObjectParameterSet = nameof(RunSparkStatementByCodePathAndInputObjectParameterSet);

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodeParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodePathParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodeParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodePathParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodeParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.LanguageForExecutionCode)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = RunSparkStatementByCodeAndInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.LanguageForExecutionCode)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodePathParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.LanguageForExecutionCode)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = RunSparkStatementByCodePathAndInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.LanguageForExecutionCode)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Spark", "Scala", "PySpark", "Python", "SparkDotNet", "CSharp", "SQL", IgnoreCase = true)]
        public string Language { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RunSparkStatementByCodeAndInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SessionObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RunSparkStatementByCodePathAndInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SessionObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSparkSession SessionObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodeParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SessionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodeAndInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SessionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodePathParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SessionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkStatementByCodePathAndInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SessionId)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public int SessionId { get; set; }

        [Parameter(ParameterSetName = RunSparkStatementByCodeParameterSet, Mandatory = true, HelpMessage = HelpMessages.Code)]
        [Parameter(ParameterSetName = RunSparkStatementByCodeAndInputObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.Code)]
        [ValidateNotNullOrEmpty]
        public string Code { get; set; }

        [Parameter(ParameterSetName = RunSparkStatementByCodePathParameterSet, Mandatory = true, HelpMessage = HelpMessages.FilePath)]
        [Parameter(ParameterSetName = RunSparkStatementByCodePathAndInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FilePath)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Response)]
        public SwitchParameter Response { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Language = LanguageType.Parse(this.Language);
            if (this.IsParameterBound(c => c.SessionObject))
            {
                this.WorkspaceName = this.SessionObject.WorkspaceName;
                this.SparkPoolName = this.SessionObject.SparkPoolName;
                this.SessionId = this.IsParameterBound(c => c.SessionId) ? this.SessionId : this.SessionObject.Id.Value;
                this.Language = this.IsParameterBound(c => c.Language) ? this.Language : this.SessionObject.Language;
            }

            if (this.IsParameterBound(c => c.FilePath))
            {
                this.Code = this.ReadFileAsText(this.FilePath);
            }

            var livyRequest = new SparkStatementOptions
            {
                Kind = this.Language,
                Code = this.Code
            };

            if (this.ShouldProcess(this.SparkPoolName, string.Format(Resources.InvokingSparkStatement, this.SparkPoolName, this.WorkspaceName)))
            {
                var sessionStmt = SynapseAnalyticsClient.SubmitSparkSessionStatement(this.SessionId, livyRequest, waitForCompletion:true);
                var psSessionStmt = new PSSynapseExtendedSparkStatement(sessionStmt);
                WriteObject(psSessionStmt);
            }
        }
    }
}
