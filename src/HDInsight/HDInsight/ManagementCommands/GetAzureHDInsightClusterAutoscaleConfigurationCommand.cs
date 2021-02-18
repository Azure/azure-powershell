﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterAutoscaleConfiguration", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(AzureHDInsightAutoscale))]
    public class GetAzureHDInsightClusterAutoscaleConfigurationCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByInputObjectParameterSet = "GetByInputObjectParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            AzureHDInsightAutoscale autoscaleConfiguration = null;
            if (this.IsParameterBound(c => c.InputObject))
            {
                autoscaleConfiguration = InputObject?.ComputeProfile?.Roles?.FirstOrDefault(role => role.Name.Equals("workernode"))?.AutoscaleConfiguration;
            }
            else
            {
                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);
                    this.ClusterName = resourceIdentifier.ResourceName;
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                }

                if (ClusterName != null && ResourceGroupName == null)
                {
                    ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
                }
                var cluster = HDInsightManagementClient.Get(ResourceGroupName, ClusterName);
                var autoscale = Utils.ExtractRole(AzureHDInsightClusterNodeType.WorkerNode.ToString(), cluster.Properties.ComputeProfile)?.AutoscaleConfiguration;
                autoscaleConfiguration = autoscale != null ? new AzureHDInsightAutoscale(autoscale) : null;
            }

            WriteObject(autoscaleConfiguration);
        }
    }
}
