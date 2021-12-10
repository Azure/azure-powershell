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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsCluster", DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureOperationalInsightsClusterCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = DeleteByNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = DeleteByNameParameterSet,
            HelpMessage = "The cluster name.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSCluster InputCluster { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputCluster))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputCluster.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ClusterName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ClusterName = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(this.ClusterName,
                string.Format("delete cluster: {0} in resource group: {1}", this.ClusterName, this.ResourceGroupName)))
            {
                HttpStatusCode response = this.OperationalInsightsClient.DeletePSCluster(this.ResourceGroupName, this.ClusterName);
                WriteObject(true);
            }
        }
    }
}