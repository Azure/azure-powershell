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
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Wait, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkJob, DefaultParameterSetName = WaitSparkJobByIdParameterSetName)]
    [OutputType(typeof(bool))]
    public class WaitAzureSynapseSparkJob : SynapseSparkCmdletBase
    {
        private const string WaitSparkJobByIdParameterSetName = "WaitSparkJobByIdParameterSet";
        private const string WaitSparkJobByIdFromParentObjectParameterSet = "WaitSparkJobByIdFromParentObjectParameterSet";
        private const string WaitSparkJobByIdFromInputObjectParameterSet = "WaitSparkJobByIdFromInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = WaitSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = WaitSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = WaitSparkJobByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = WaitSparkJobByIdFromInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobObject)]
        [ValidateNotNull]
        public PSSynapseSparkJob SparkJobObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = WaitSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = WaitSparkJobByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = WaitSparkJobByIdFromInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobId)]
        [Alias("Id")]
        [ValidateRange(0, int.MaxValue)]
        public int LivyId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.WaitIntervalInSeconds)]
        [ValidateRange(0, int.MaxValue / 10000)]
        public int WaitIntervalInSeconds { get; set; } = SynapseConstants.DefaultPollingInterval / 1000;

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false,
            HelpMessage = HelpMessages.TimeoutInSeconds)]
        [ValidateRange(0, int.MaxValue / 10000)]
        public int TimeoutInSeconds { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SparkPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SparkPoolObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SparkPoolName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.SparkJobObject))
            {
                this.WorkspaceName = this.SparkJobObject.WorkspaceName;
                this.SparkPoolName = this.SparkJobObject.SparkPoolName;
                this.LivyId = this.IsParameterBound(c => c.LivyId) ? this.LivyId : this.SparkJobObject.Id.Value;
            }

            var sparkJob = this.SynapseAnalyticsClient.GetSparkBatchJob(this.LivyId);
            try
            {
                sparkJob = this.SynapseAnalyticsClient.PollSparkBatchJobExecution(
                    sparkJob,
                    this.WaitIntervalInSeconds,
                    this.TimeoutInSeconds,
                    this.WriteVerboseWithTimestamp);
                WriteObject(new PSSynapseSparkJob(sparkJob));
            }
            catch (TimeoutException)
            {
                throw new AzPSInvalidOperationException(string.Format(Resources.WaitJobTimeoutExceeded, this.LivyId, TimeoutInSeconds));
            }
        }
    }
}
