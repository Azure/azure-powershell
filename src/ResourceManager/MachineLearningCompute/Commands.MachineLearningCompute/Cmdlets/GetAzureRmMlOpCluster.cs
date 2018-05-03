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

using Microsoft.Azure.Management.MachineLearningCompute.Models;
using Microsoft.Azure.Management.MachineLearningCompute;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.MachineLearningCompute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, CmdletSuffix)]
    [OutputType(typeof(PSOperationalizationCluster), typeof(List<PSOperationalizationCluster>))]
    public class GetAzureRmMlOpCluster : MachineLearningComputeCmdletBase
    {
        protected const string GetByNameParameterSet = "GetByName";

        protected const string GetByResourceGroupOrSubscriptionParametersParameterSet = "GetByResourceGroup";

        [Parameter(ParameterSetName = GetByNameParameterSet,
            Mandatory = true, 
            HelpMessage = ResourceGroupParameterHelpMessage)]
        [Parameter(ParameterSetName = GetByResourceGroupOrSubscriptionParametersParameterSet,
            Mandatory = false, 
            HelpMessage = ResourceGroupParameterHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = GetByNameParameterSet,
            Mandatory = true, 
            HelpMessage = NameParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.Equals(this.ParameterSetName, GetByNameParameterSet, StringComparison.OrdinalIgnoreCase))
                {
                    WriteObject(new PSOperationalizationCluster(this.MachineLearningComputeManagementClient.OperationalizationClusters.Get(this.ResourceGroupName, this.Name)));
                }
                else if (string.Equals(this.ParameterSetName, GetByResourceGroupOrSubscriptionParametersParameterSet, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                    {
                        WriteClusterList(MachineLearningComputeManagementClient.OperationalizationClusters.ListByResourceGroup(this.ResourceGroupName));
                    }
                    else
                    {
                        WriteClusterList(this.MachineLearningComputeManagementClient.OperationalizationClusters.ListBySubscriptionId());
                    }
                }
            }
            catch (CloudException e)
            {
                HandleNestedExceptionMessages(e);
            }
        }

        private void WriteClusterList(IEnumerable<OperationalizationCluster> clusters)
        {
            List<PSOperationalizationCluster> output = new List<PSOperationalizationCluster>();
            clusters.ForEach(cluster => output.Add(new PSOperationalizationCluster(cluster)));

            WriteObject(output, true);
        }
    }
}
