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
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkPool, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkPool))]
    public class UpdateAzureSynapseSparkPool : SynapseCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [Alias(SynapseConstants.SparkPoolName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.EnableAutoScale)]
        public SwitchParameter EnableAutoScale { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DisableAutoScale)]
        public SwitchParameter DisableAutoScale { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMinNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.AutoScaleMaxNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMaxNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.EnableAutoPause)]
        public SwitchParameter EnableAutoPause { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.DisableAutoPause)]
        public SwitchParameter DisableAutoPause { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoPauseDelayInMinutes)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(5, 10080)]
        public int AutoPauseDelayInMinutes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.NodeCount)]
        [ValidateRange(3, 200)]
        public int NodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.NodeSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string NodeSize { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.SparkVersion)]
        [ValidateNotNullOrEmpty]
        public string SparkVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.LibraryRequirementsFilePath)]
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

            LibraryRequirements libraryRequirements = null;
            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = this.InputObject.Name;
                this.Tag = this.IsParameterBound(c => c.Tag) ? this.Tag : this.InputObject.Tags;
                this.NodeCount = this.IsParameterBound(c => c.NodeCount) ? this.NodeCount : this.InputObject.NodeCount.Value;
                this.NodeSize = this.IsParameterBound(c => c.NodeSize) ? this.NodeSize : this.InputObject.NodeSize;
                this.AutoScaleMinNodeCount = this.IsParameterBound(c => c.AutoScaleMinNodeCount) ? this.AutoScaleMinNodeCount : (this.InputObject.AutoScale?.MinNodeCount ?? default);
                this.AutoScaleMaxNodeCount = this.IsParameterBound(c => c.AutoScaleMaxNodeCount) ? this.AutoScaleMaxNodeCount : (this.InputObject.AutoScale?.MaxNodeCount ?? default);
                this.AutoPauseDelayInMinutes = this.IsParameterBound(c => c.AutoPauseDelayInMinutes) ? this.AutoPauseDelayInMinutes : (this.InputObject.AutoPause?.DelayInMinutes ?? default);
                libraryRequirements = this.IsParameterBound(c => c.LibraryRequirementsFilePath)
                    ? CreateLibraryRequirements()
                    : (this.InputObject.LibraryRequirements == null ? null :
                        new LibraryRequirements
                        {
                            Filename = this.InputObject.LibraryRequirements.Filename,
                            Content = this.InputObject.LibraryRequirements.Content
                        });
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
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

            if (existingSparkPool == null)
            {
                throw new SynapseException(string.Format(Resources.FailedToDiscoverSparkPool, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            existingSparkPool.Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : existingSparkPool.Tags;
            existingSparkPool.NodeCount = this.IsParameterBound(c => c.NodeCount) ? this.NodeCount : existingSparkPool.NodeCount;
            existingSparkPool.NodeSizeFamily = NodeSizeFamily.MemoryOptimized;
            existingSparkPool.NodeSize = this.IsParameterBound(c => c.NodeSize) ? this.NodeSize : existingSparkPool.NodeSize;
            existingSparkPool.LibraryRequirements = libraryRequirements ?? existingSparkPool.LibraryRequirements;

            if (this.IsParameterBound(c => c.EnableAutoScale)
                || this.IsParameterBound(c => c.AutoScaleMinNodeCount)
                || this.IsParameterBound(c => c.AutoScaleMaxNodeCount))
            {
                existingSparkPool.AutoScale = new AutoScaleProperties
                {
                    Enabled = this.EnableAutoScale.IsPresent ? true : existingSparkPool.AutoScale?.Enabled ?? false,
                    MinNodeCount = this.IsParameterBound(c => c.AutoScaleMinNodeCount) ? AutoScaleMinNodeCount : existingSparkPool.AutoScale?.MinNodeCount ?? default,
                    MaxNodeCount = this.IsParameterBound(c => c.AutoScaleMaxNodeCount) ? AutoScaleMaxNodeCount : existingSparkPool.AutoScale?.MaxNodeCount ?? default
                };
            }

            if (this.IsParameterBound(c => c.DisableAutoScale))
            {
                if (existingSparkPool.AutoScale != null)
                {
                    existingSparkPool.AutoScale.Enabled = false;
                }
            }

            if (this.IsParameterBound(c => c.EnableAutoPause)
                || this.IsParameterBound(c => c.AutoPauseDelayInMinutes))
            {
                existingSparkPool.AutoPause = new AutoPauseProperties
                {
                    Enabled = this.EnableAutoPause.IsPresent ? true : existingSparkPool.AutoPause?.Enabled ?? false,
                    DelayInMinutes = this.IsParameterBound(c => c.AutoPauseDelayInMinutes)
                        ? this.AutoPauseDelayInMinutes
                        : existingSparkPool.AutoPause?.DelayInMinutes ?? default
                };
            }

            if (this.IsParameterBound(c => c.DisableAutoPause))
            {
                if (existingSparkPool.AutoPause != null)
                {
                    existingSparkPool.AutoPause.Enabled = false;
                }
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSparkPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = new PSSynapseSparkPool(this.SynapseAnalyticsClient.CreateOrUpdateSparkPool(this.ResourceGroupName, this.WorkspaceName, this.Name, existingSparkPool));
                WriteObject(result);
            }
        }

        private LibraryRequirements CreateLibraryRequirements()
        {
            var powerShellDestinationPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(LibraryRequirementsFilePath);

            return new LibraryRequirements
            {
                Filename = Path.GetFileName(powerShellDestinationPath),
                Content = this.ReadFileAsText(powerShellDestinationPath)
            };
        }
    }
}
