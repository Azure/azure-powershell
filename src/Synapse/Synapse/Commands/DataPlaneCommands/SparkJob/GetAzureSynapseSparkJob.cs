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

using Azure.Analytics.Synapse.Spark;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkJob,
        DefaultParameterSetName = GetSparkJobsByIdParameterSetName)]
    [OutputType(typeof(PSSynapseSparkJob))]
    public class GetAzureSynapseSparkJob : SynapseSparkCmdletBase
    {
        private const string GetSparkJobsByIdParameterSetName = "GetSparkJobsByIdParameterSet";
        private const string GetSparkJobsByIdFromParentObjectParameterSetName = "GetSparkJobsByIdFromParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetSparkJobsByIdFromParentObjectParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdFromParentObjectParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobId)]
        [Alias("Id")]
        [ValidateRange(0, int.MaxValue)]
        public int LivyId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdFromParentObjectParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.ApplicationId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkJobsByIdFromParentObjectParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.ApplicationId)]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SparkPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SparkPoolObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SparkPoolName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.LivyId))
            {
                // Get for single Spark batch job
                WriteObject(new PSSynapseSparkJob(SynapseAnalyticsClient.GetSparkBatchJob(this.LivyId)));
            }
            else
            {
                // List all Spark batch jobs in given Spark pool
                var batchJobs = SynapseAnalyticsClient.ListSparkBatchJobs()
                    .Select(element => new PSSynapseSparkJob(element));
                if (!string.IsNullOrEmpty(this.Name))
                {
                    batchJobs = batchJobs.Where(b => this.Name.Equals(b.Name, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(this.ApplicationId))
                {
                    batchJobs = batchJobs.Where(b => this.ApplicationId.Equals(b.AppId, StringComparison.OrdinalIgnoreCase));
                }

                WriteObject(batchJobs, true);
            }
        }
    }
}
