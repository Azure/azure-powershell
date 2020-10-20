using Azure.Analytics.Synapse.Spark.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkSession, DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkSession))]
    public class StartAzureSynapseSparkSession : SynapseSparkCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.LanguageForExecutionCode)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Spark", "Scala", "PySpark", "Python", "SparkDotNet", "CSharp", "SQL", IgnoreCase = true)]
        public string Language { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SessionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ReferenceFile)]
        [ValidateNotNullOrEmpty]
        public string[] ReferenceFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, 80)]
        public int ExecutorCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.ExecutorSize)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(NodeSize.Small, NodeSize.Medium, NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(NodeSize.Small, NodeSize.Medium, NodeSize.Large)]
        public string ExecutorSize { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Configuration)]
        [ValidateNotNullOrEmpty]
        public Hashtable Configuration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SparkPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SparkPoolObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SparkPoolName = resourceIdentifier.ResourceName;
            }

            if (this.ReferenceFile != null)
            {
                for (int i = 0; i < this.ReferenceFile.Length; i++)
                {
                    this.ReferenceFile[i] = Utils.NormalizeUrl(this.ReferenceFile[i]);
                }
            }

            Utils.CategorizedFiles(this.ReferenceFile, out IList<string> jars, out IList<string> files);
            var livyRequest = new SparkSessionOptions(this.Name)
            {
                Jars = jars,
                Files = files,
                Configuration = this.Configuration?.ToDictionary(),
                ExecutorMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                ExecutorCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                DriverMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                DriverCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                ExecutorCount = this.ExecutorCount
            };

            if (this.ShouldProcess(this.SparkPoolName, string.Format(Resources.StartingSynapseSparkSession, this.SparkPoolName, this.WorkspaceName)))
            {
                var sparkSession = SynapseAnalyticsClient.CreateSparkSession(livyRequest, waitForCompletion: true);

                PSSynapseSparkSession psSparkSession = null;
                if (this.IsParameterBound(c => c.Language))
                {
                    this.Language = LanguageType.Parse(this.Language);
                    psSparkSession = new PSSynapseSparkSession(this.Language, sparkSession);
                }
                else
                {
                    psSparkSession = new PSSynapseSparkSession(sparkSession);
                }

                WriteObject(psSparkSession);
            }
        }
    }
}
