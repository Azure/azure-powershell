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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchPool, DefaultParameterSetName = CloudServiceTargetDedicatedParameterSet, SupportsShouldProcess=true)]
    public class NewBatchPoolCommand : BatchObjectModelCmdletBase
    {
        internal const string CloudServiceTargetDedicatedParameterSet = "CloudServiceAndTargetDedicated";
        internal const string CloudServiceAutoScaleParameterSet = "CloudServiceAndAutoScale";
        internal const string VirtualMachineTargetDedicatedParameterSet = "VirtualMachineAndTargetDedicated";
        internal const string VirtualMachineAutoScaleParameterSet = "VirtualMachineAndAutoScale";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The id of the pool to create.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The size of the virtual machines in the pool.")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineSize { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = VirtualMachineTargetDedicatedParameterSet)]
        [Parameter(ParameterSetName = CloudServiceTargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ResizeTimeout { get; set; }

        [Parameter(ParameterSetName = VirtualMachineTargetDedicatedParameterSet)]
        [Parameter(ParameterSetName = CloudServiceTargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? TargetDedicated { get; set; }

        [Parameter(ParameterSetName = CloudServiceAutoScaleParameterSet)]
        [Parameter(ParameterSetName = VirtualMachineAutoScaleParameterSet)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? AutoScaleEvaluationInterval { get; set; }

        [Parameter(ParameterSetName = CloudServiceAutoScaleParameterSet)]
        [Parameter(ParameterSetName = VirtualMachineAutoScaleParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AutoScaleFormula { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public int? MaxTasksPerComputeNode { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSTaskSchedulingPolicy TaskSchedulingPolicy { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary Metadata { get; set; }

        [Parameter]
        public SwitchParameter InterComputeNodeCommunicationEnabled { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSStartTask StartTask { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSCertificateReference[] CertificateReferences { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSApplicationPackageReference[] ApplicationPackageReferences { get; set; }

        [Parameter(ParameterSetName = VirtualMachineAutoScaleParameterSet)]
        [Parameter(ParameterSetName = VirtualMachineTargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineConfiguration VirtualMachineConfiguration { get; set; }

        [Parameter(ParameterSetName = CloudServiceAutoScaleParameterSet)]
        [Parameter(ParameterSetName = CloudServiceTargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSCloudServiceConfiguration CloudServiceConfiguration { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSNetworkConfiguration NetworkConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            NewPoolParameters parameters = new NewPoolParameters(this.BatchContext, this.Id, this.AdditionalBehaviors)
            {
                VirtualMachineSize = this.VirtualMachineSize,
                DisplayName = this.DisplayName,
                ResizeTimeout = this.ResizeTimeout,
                TargetDedicated = this.TargetDedicated,
                AutoScaleEvaluationInterval = this.AutoScaleEvaluationInterval,
                AutoScaleFormula = this.AutoScaleFormula,
                MaxTasksPerComputeNode = this.MaxTasksPerComputeNode,
                TaskSchedulingPolicy = this.TaskSchedulingPolicy,
                Metadata = this.Metadata,
                InterComputeNodeCommunicationEnabled = this.InterComputeNodeCommunicationEnabled.IsPresent,
                StartTask = this.StartTask,
                CertificateReferences = this.CertificateReferences,
                ApplicationPackageReferences = this.ApplicationPackageReferences,
                VirtualMachineConfiguration =  this.VirtualMachineConfiguration,
                CloudServiceConfiguration = this.CloudServiceConfiguration,
                NetworkConfiguration = this.NetworkConfiguration
            };

            if (ShouldProcess("AzureBatchPool"))
            {
                BatchClient.CreatePool(parameters);
            }
        }
    }
}
