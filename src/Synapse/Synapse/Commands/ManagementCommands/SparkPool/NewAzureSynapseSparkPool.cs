using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkPool, DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkPool))]
    public class NewAzureSynapseSparkPool : SynapseCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [Alias(SynapseConstants.SparkPoolName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.NodeCount)]
        [ValidateRange(3, 200)]
        public int NodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.NodeSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string NodeSize { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.EnableAutoScale)]
        public SwitchParameter EnableAutoScale { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMinNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoScaleMaxNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMaxNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.EnableAutoPause)]
        public SwitchParameter EnableAutoPause { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoPauseDelayInMinute)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(5, 10080)]
        public int AutoPauseDelayInMinute { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.SparkVersion)]
        [ValidateNotNullOrEmpty]
        public string SparkVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.LibraryRequirementsFilePath)]
        [ValidateNotNullOrEmpty]
        public string LibraryRequirementsFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            BigDataPoolResourceInfo existingSparkPool = null;
            try
            {
                existingSparkPool = this.SynapseAnalyticsClient.GetSparkPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
            }
            catch
            {
                existingSparkPool = null;
            }

            if (existingSparkPool != null)
            {
                throw new SynapseException(string.Format(Resources.SynapseSparkPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            Workspace existingWorkspace = null;
            try
            {
                existingWorkspace = this.SynapseAnalyticsClient.GetWorkspace(this.ResourceGroupName, this.WorkspaceName);
            }
            catch
            {
                existingWorkspace = null;
            }

            if (existingWorkspace == null)
            {
                throw new SynapseException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            LibraryRequirements libraryRequirements = null;
            if (this.IsParameterBound(c => c.LibraryRequirementsFilePath))
            {
                var powerShellDestinationPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(LibraryRequirementsFilePath);

                libraryRequirements = new LibraryRequirements
                {
                    Filename = Path.GetFileName(powerShellDestinationPath),
                    Content = this.ReadFileAsText(powerShellDestinationPath),
                };
            }

            var createParams = new BigDataPoolResourceInfo
            {
                Location = existingWorkspace.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                NodeCount = this.NodeCount,
                NodeSizeFamily = NodeSizeFamily.MemoryOptimized,
                NodeSize = NodeSize,
                AutoScale = !EnableAutoScale.IsPresent ? null : new AutoScaleProperties
                {
                    Enabled = EnableAutoScale.IsPresent,
                    MinNodeCount = AutoScaleMinNodeCount,
                    MaxNodeCount = AutoScaleMaxNodeCount
                },
                AutoPause = !EnableAutoPause ? null : new AutoPauseProperties
                {
                    Enabled = EnableAutoPause.IsPresent,
                    DelayInMinutes = AutoPauseDelayInMinute
                },
                SparkVersion = this.SparkVersion,
                LibraryRequirements = libraryRequirements
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSparkPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSparkPool(this.SynapseAnalyticsClient.CreateOrUpdateSparkPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
