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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkJob, DefaultParameterSetName = StopSparkJobByIdParameterSetName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseSparkJob : SynapseSparkCmdletBase
    {
        private const string StopSparkJobByIdParameterSetName = "StopSparkJobByIdParameterSet";
        private const string StopSparkJobByIdFromParentObjectParameterSet = "StopSparkJobByIdFromParentObjectParameterSet";
        private const string StopSparkJobByIdFromInputObjectParameterSet = "StopSparkJobByIdFromInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopSparkJobByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopSparkJobByIdFromInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobObject)]
        [ValidateNotNull]
        public PSSynapseSparkJob SparkJobObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkJobByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkJobByIdFromParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopSparkJobByIdFromInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SparkJobId)]
        [Alias("Id")]
        [ValidateRange(0, int.MaxValue)]
        public int LivyId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

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

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.ConfirmToStopSparkJob, LivyId),
                string.Format(Resources.StoppingSparkJob, LivyId),
                LivyId.ToString(),
                () =>
                {
                    SynapseAnalyticsClient.CancelSparkBatchJob(LivyId, waitForCompletion: false);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
