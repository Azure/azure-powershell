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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight
{
    [GenericBreakingChangeWithVersionAttribute(Constants.diskEncryptionChangeInfo + Constants.workerNodeDataDisksGroupsChangeInfo,Constants.deprecateByAzVersion,Constants.deprecateByVersion)]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterAutoscaleConfiguration",
        DefaultParameterSetName = LoadAutoscaleByNameParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(AzureHDInsightCluster))]
    public class SetAzureHDInsightClusterAutoscaleConfigurationCommand : HDInsightCmdletBase
    {
        private const string LoadAutoscaleByNameParameterSet = "LoadAutoscaleByNameParameterSet";
        private const string LoadAutoscaleByResourceIdParameterSet = "LoadAutoscaleByResourceIdParameterSet";
        private const string LoadAutoscaleByInputObjectParameterSet = "LoadAutoscaleByInputObjectParameterSet";

        private const string ScheduleAutoscaleByNameParameterSet = "ScheduleAutoscaleByNameParameterSet";
        private const string ScheduleAutoscaleByResourceIdParameterSet = "ScheduleAutoscaleByResourceIdParameterSet";
        private const string ScheduleAutoscaleByInputObjectParameterSet = "ScheduleAutoscaleByInputObjectParameterSet";

        private const string AutoscaleConfigurationByNameParameterSet = "AutoscaleConfigurationByNameParameterSet";
        private const string AutoscaleConfigurationByResourceIdParameterSet = "AutoscaleConfigurationByResourceIdParameterSet";
        private const string AutoscaleConfigurationByInputObjectParameterSet = "AutoscaleConfigurationByInputObjectParameterSet";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = LoadAutoscaleByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ScheduleAutoscaleByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = AutoscaleConfigurationByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LoadAutoscaleByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ScheduleAutoscaleByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = AutoscaleConfigurationByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LoadAutoscaleByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ScheduleAutoscaleByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AutoscaleConfigurationByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LoadAutoscaleByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ScheduleAutoscaleByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = AutoscaleConfigurationByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the minimal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the minimal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByResourceIdParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the minimal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByInputObjectParameterSet)]
        public int MinWorkerNodeCount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the maximal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the maximal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByResourceIdParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the maximal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleByInputObjectParameterSet)]
        public int MaxWorkerNodeCount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the time zone of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the time zone of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByResourceIdParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the time zone of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByInputObjectParameterSet)]
        public string TimeZone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the condition of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the condition of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByResourceIdParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the condition of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleByInputObjectParameterSet)]
        public List<AzureHDInsightAutoscaleCondition> Condition { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Gets or sets the autoscale configuration",
            ParameterSetName = AutoscaleConfigurationByNameParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Gets or sets the autoscale configuration",
            ParameterSetName = AutoscaleConfigurationByResourceIdParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Gets or sets the autoscale configuration",
            ParameterSetName = AutoscaleConfigurationByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public AzureHDInsightAutoscale AutoscaleConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Set schedule-based parameters",
            ParameterSetName = ScheduleAutoscaleByNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Set schedule-based parameters",
            ParameterSetName = ScheduleAutoscaleByResourceIdParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Set schedule-based parameters",
            ParameterSetName = ScheduleAutoscaleByInputObjectParameterSet)]
        public SwitchParameter Schedule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.ClusterName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ClusterName = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroup;
            }

            if (ClusterName != null && ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var clusterBeforeUpdate = HDInsightManagementClient.Get(ResourceGroupName, ClusterName);
            Autoscale autoscaleConfig = Utils.ExtractRole(AzureHDInsightClusterNodeType.WorkerNode.ToString(), clusterBeforeUpdate.Properties.ComputeProfile)?.AutoscaleConfiguration;
            if (autoscaleConfig == null)
            {
                autoscaleConfig = new Autoscale();
            }

            switch (ParameterSetName)
            {
                case LoadAutoscaleByNameParameterSet:
                case LoadAutoscaleByResourceIdParameterSet:
                case LoadAutoscaleByInputObjectParameterSet:
                    // override Recurrence to support switch from schedule to load
                    autoscaleConfig.Recurrence = null;

                    if (autoscaleConfig.Capacity == null)
                    {
                        autoscaleConfig.Capacity = new AutoscaleCapacity(MinWorkerNodeCount, MaxWorkerNodeCount);
                    }
                    else
                    {
                        if (this.IsParameterBound(c => c.MinWorkerNodeCount))
                        {
                            autoscaleConfig.Capacity.MinInstanceCount = MinWorkerNodeCount;
                        }

                        if (this.IsParameterBound(c => c.MaxWorkerNodeCount))
                        {
                            autoscaleConfig.Capacity.MaxInstanceCount = MaxWorkerNodeCount;
                        }
                    }
                    break;

                case ScheduleAutoscaleByNameParameterSet:
                case ScheduleAutoscaleByResourceIdParameterSet:
                case ScheduleAutoscaleByInputObjectParameterSet:
                    // override Capacity to support switch from Load to Schedule
                    autoscaleConfig.Capacity = null;

                    if (autoscaleConfig.Recurrence == null)
                    {
                        var schedules = Condition?.Select(conditon => conditon.ToAutoscaleSchedule()).ToList();
                        autoscaleConfig.Recurrence = new AutoscaleRecurrence(TimeZone, schedules);
                    }
                    else
                    {
                        if (this.IsParameterBound(c => c.TimeZone))
                        {
                            autoscaleConfig.Recurrence.TimeZone = TimeZone;
                        }

                        if (this.IsParameterBound(c => c.Condition))
                        {
                            autoscaleConfig.Recurrence.Schedule = Condition?.Select(conditon => conditon.ToAutoscaleSchedule()).ToList();
                        }
                    }
                    break;

                case AutoscaleConfigurationByNameParameterSet:
                case AutoscaleConfigurationByResourceIdParameterSet:
                case AutoscaleConfigurationByInputObjectParameterSet:
                    autoscaleConfig = AutoscaleConfiguration?.ToAutoscale();
                    break;
                default:
                    break;
            }

            if (ShouldProcess(ClusterName))
            {
                HDInsightManagementClient.UpdateAutoScaleConfiguration(ResourceGroupName, ClusterName, new AutoscaleConfigurationUpdateParameter(autoscaleConfig));

                Cluster cluster = HDInsightManagementClient.Get(ResourceGroupName, ClusterName);
                WriteObject(new AzureHDInsightCluster(cluster));
            }
        }
    }
}
