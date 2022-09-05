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
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkPool, DefaultParameterSetName = CreateByNameAndEnableAutoScaleParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkPool))]
    public class NewAzureSynapseSparkPool : SynapseManagementCmdletBase
    {
        private const string CreateByNameAndEnableAutoScaleParameterSet = "CreateByNameAndEnableAutoScaleParameterSet";
        private const string CreateByNameAndDisableAutoScaleParameterSet = "CreateByNameAndDisableAutoScaleParameterSet";
        private const string CreateByParentObjectAndEnableAutoScaleParameterSet = "CreateByParentObjectAndEnableAutoScaleParameterSet";
        private const string CreateByParentObjectAndDisableAutoScaleParameterSet = "CreateByParentObjectAndDisableAutoScaleParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndEnableAutoScaleParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndDisableAutoScaleParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndDisableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectAndDisableAutoScaleParameterSet,
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

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndDisableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.NodeCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByParentObjectAndDisableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.NodeCount)]
        [ValidateRange(3, 200)]
        public int NodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.NodeSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string NodeSize { get; set; }

        private SwitchParameter enableAutoScale;

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByParentObjectAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMinNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByParentObjectAndEnableAutoScaleParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.AutoScaleMinNodeCount)]
        [ValidateRange(3, 200)]
        public int AutoScaleMaxNodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.EnableAutoPause)]
        public SwitchParameter EnableAutoPause { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.AutoPauseDelayInMinute)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(5, 10080)]
        public int AutoPauseDelayInMinute { get; set; } = int.Parse(SynapseConstants.DefaultAutoPauseDelayInMinute);
       
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.EnableDynamicExecutorAllocation)]
        public SwitchParameter EnableDynamicExecutorAllocation { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.MinExecutorCount)]
        [ValidateNotNullOrEmpty]
        public int MinExecutorCount { get; set; } = int.Parse(SynapseConstants.DefaultMinExecutorCount);

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.MaxExecutorCount)]
        [ValidateNotNullOrEmpty]
        public int MaxExecutorCount { get; set; } = int.Parse(SynapseConstants.DefaultMaxExecutorCount);

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.SparkVersion)]
        [ValidateNotNullOrEmpty]
        public string SparkVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.SparkConfigPropertiesFilePath)]
        [ValidateNotNullOrEmpty]
        public string SparkConfigFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CreateByNameAndEnableAutoScaleParameterSet:
                case CreateByParentObjectAndEnableAutoScaleParameterSet:
                    this.enableAutoScale = true;
                    break;
            }

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
                throw new AzPSInvalidOperationException(string.Format(Resources.SynapseSparkPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
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
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            SparkConfigProperties sparkConfigProperties = null;
            if (this.IsParameterBound(c => c.SparkConfigFilePath))
            {
                string path = this.TryResolvePath(SparkConfigFilePath);
                string filename = Path.GetFileNameWithoutExtension(path);
                sparkConfigProperties = new SparkConfigProperties()
                {
                    Content = this.ReadFileAsText(this.SparkConfigFilePath),
                    Filename = filename
                };
            }

            var createParams = new BigDataPoolResourceInfo
            {
                Location = existingWorkspace.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                NodeCount = this.enableAutoScale ? (int?)null : this.NodeCount,
                NodeSizeFamily = NodeSizeFamily.MemoryOptimized,
                NodeSize = NodeSize,
                AutoScale = !this.enableAutoScale ? new AutoScaleProperties { Enabled = false } : new AutoScaleProperties
                {
                    Enabled = this.enableAutoScale,
                    MinNodeCount = AutoScaleMinNodeCount,
                    MaxNodeCount = AutoScaleMaxNodeCount
                },
                AutoPause = !EnableAutoPause ? new AutoPauseProperties { Enabled = false } : new AutoPauseProperties
                {
                    Enabled = EnableAutoPause.IsPresent,
                    DelayInMinutes = AutoPauseDelayInMinute
                },
                DynamicExecutorAllocation = !EnableDynamicExecutorAllocation ? new DynamicExecutorAllocation { Enabled = false } : new DynamicExecutorAllocation
                { 
                    Enabled = EnableDynamicExecutorAllocation.IsPresent,
                    MinExecutors = MinExecutorCount,
                    MaxExecutors = MaxExecutorCount
                },
                SparkVersion = this.SparkVersion,
                SparkConfigProperties = sparkConfigProperties
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSparkPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSparkPool(this.SynapseAnalyticsClient.CreateOrUpdateSparkPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
