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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkPool, DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkPool))]
    public class UpdateAzureSynapseSparkPool : SynapseManagementCmdletBase
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
        public bool? EnableAutoScale { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMinNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.AutoScaleMaxNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMaxNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.EnableAutoPause)]
        public bool? EnableAutoPause { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoPauseDelayInMinute)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(5, 10080)]
        public int AutoPauseDelayInMinute { get; set; }

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

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
           HelpMessage = HelpMessages.SparkConfigPropertiesFilePath)]
        public string SparkConfigFilePath { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.PackageAction)]
        public SynapseConstants.PackageActionType PackageAction { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.WorkspacePackages)]
        [Alias(SynapseConstants.WorkspacePackage)]
        [ValidateNotNullOrEmpty]
        public List<PSSynapseWorkspacePackage> Package { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.ForceApplySetting)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ForceApplySetting { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = this.InputObject.Name;
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
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.FailedToDiscoverSparkPool, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            existingSparkPool.Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : existingSparkPool.Tags;
            existingSparkPool.NodeCount = this.IsParameterBound(c => c.NodeCount) ? this.NodeCount : existingSparkPool.NodeCount;
            existingSparkPool.NodeSizeFamily = NodeSizeFamily.MemoryOptimized;
            existingSparkPool.NodeSize = this.IsParameterBound(c => c.NodeSize) ? this.NodeSize : existingSparkPool.NodeSize;
            existingSparkPool.LibraryRequirements = this.IsParameterBound(c => c.LibraryRequirementsFilePath) ? CreateLibraryRequirements() : existingSparkPool.LibraryRequirements;
            existingSparkPool.SparkConfigProperties = this.IsParameterBound(c => c.SparkConfigFilePath) ? CreateSparkConfigProperties() : existingSparkPool.SparkConfigProperties;
            existingSparkPool.SparkVersion = this.IsParameterBound(c => c.SparkVersion) ? this.SparkVersion : existingSparkPool.SparkVersion;

            if (this.IsParameterBound(c => c.EnableAutoScale)
                || this.IsParameterBound(c => c.AutoScaleMinNodeCount)
                || this.IsParameterBound(c => c.AutoScaleMaxNodeCount))
            {
                existingSparkPool.AutoScale = new AutoScaleProperties
                {
                    Enabled = this.EnableAutoScale != null ? this.EnableAutoScale : existingSparkPool.AutoScale?.Enabled ?? false,
                    MinNodeCount = this.IsParameterBound(c => c.AutoScaleMinNodeCount) ? AutoScaleMinNodeCount : existingSparkPool.AutoScale?.MinNodeCount ?? 0,
                    MaxNodeCount = this.IsParameterBound(c => c.AutoScaleMaxNodeCount) ? AutoScaleMaxNodeCount : existingSparkPool.AutoScale?.MaxNodeCount ?? 0
                };
            }

            if (this.IsParameterBound(c => c.EnableAutoPause)
                || this.IsParameterBound(c => c.AutoPauseDelayInMinute))
            {
                existingSparkPool.AutoPause = new AutoPauseProperties
                {
                    Enabled = this.EnableAutoPause != null ? this.EnableAutoPause : existingSparkPool.AutoPause?.Enabled ?? false,
                    DelayInMinutes = this.IsParameterBound(c => c.AutoPauseDelayInMinute)
                        ? this.AutoPauseDelayInMinute
                        : existingSparkPool.AutoPause?.DelayInMinutes ?? int.Parse(SynapseConstants.DefaultAutoPauseDelayInMinute)
                };
            }

            if ((!this.IsParameterBound(c => c.PackageAction) && this.IsParameterBound(c => c.Package))
                || ((this.IsParameterBound(c => c.PackageAction) && !this.IsParameterBound(c => c.Package))))
            {
                throw new AzPSInvalidOperationException(Resources.FailedToValidatePackageParameter);
            }

            if (this.IsParameterBound(c => c.PackageAction) && this.IsParameterBound(c => c.Package))
            {
                if (this.PackageAction == SynapseConstants.PackageActionType.Add)
                {
                    if (existingSparkPool.CustomLibraries == null)
                    {
                        existingSparkPool.CustomLibraries = new List<LibraryInfo>();
                    }

                    existingSparkPool.CustomLibraries = existingSparkPool.CustomLibraries.Union(this.Package.Select(psPackage => new LibraryInfo
                    {
                        Name = psPackage?.Name,
                        Type = psPackage?.PackageType,
                        Path = psPackage?.Path,
                        ContainerName = psPackage?.ContainerName,
                        UploadedTimestamp = DateTime.Parse(psPackage?.UploadedTimestamp).ToUniversalTime()
                    }), new LibraryComparer()).ToList();
                }
                else if (this.PackageAction == SynapseConstants.PackageActionType.Remove)
                {
                    existingSparkPool.CustomLibraries = existingSparkPool.CustomLibraries.Where(lib => !this.Package.Any(p => lib.Path.Equals(p.Path, System.StringComparison.OrdinalIgnoreCase))).ToList();
                }
            }

            bool? isForceApplySetting = false;
            if (ForceApplySetting.IsPresent)
            {
                isForceApplySetting = true;
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSparkPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = new PSSynapseSparkPool(this.SynapseAnalyticsClient.CreateOrUpdateSparkPool(this.ResourceGroupName, this.WorkspaceName, this.Name, existingSparkPool, isForceApplySetting));
                WriteObject(result);
            }
        }

        private LibraryRequirements CreateLibraryRequirements()
        {
            if (string.IsNullOrEmpty(LibraryRequirementsFilePath))
            {
                return null;
            }

            var powerShellDestinationPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(LibraryRequirementsFilePath);

            return new LibraryRequirements
            {
                Filename = Path.GetFileName(powerShellDestinationPath),
                Content = this.ReadFileAsText(powerShellDestinationPath)
            };
        }

        private SparkConfigProperties CreateSparkConfigProperties()
        {
            if (string.IsNullOrEmpty(SparkConfigFilePath))
            {
                return null;
            }

            var powerShellDestinationPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(SparkConfigFilePath);

            return new SparkConfigProperties
            {
                Filename = Path.GetFileName(powerShellDestinationPath),
                Content = this.ReadFileAsText(powerShellDestinationPath)
            };
        }

        private class LibraryComparer : IEqualityComparer<LibraryInfo>
        {
            public bool Equals(LibraryInfo x, LibraryInfo y)
            {
                //Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return x.Name == y.Name
                    && x.Path == y.Path
                    && x.ContainerName == y.ContainerName
                    && x.UploadedTimestamp == y.UploadedTimestamp
                    && x.Type == y.Type;

            }
            public int GetHashCode(LibraryInfo obj)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(obj, null)) return 0;

                //Get hash code for the object if it is not null.
                int hCode = obj.Name.GetHashCode() ^ obj.Path.GetHashCode() ^ obj.ContainerName.GetHashCode() ^ obj.UploadedTimestamp.GetHashCode() ^ obj.Type.GetHashCode();
                return hCode;
             }
        }
    }
}
