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
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchPool, DefaultParameterSetName = TargetDedicatedParameterSet)]
    public class NewBatchPoolCommand : BatchObjectModelCmdletBase
    {
        internal const string TargetDedicatedParameterSet = "TargetDedicated";
        internal const string AutoScaleParameterSet = "AutoScale";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The id of the pool to create.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The size of the virtual machines in the pool.")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineSize { get; set; }

        [Parameter(Mandatory = true, 
            HelpMessage = "The Azure Guest OS family to be installed on the virtual machines in the pool.")]
        [ValidateNotNullOrEmpty]
        public string OSFamily { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TargetOSVersion { get; set; }

        [Parameter(ParameterSetName = TargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ResizeTimeout { get; set; }

        [Parameter(ParameterSetName = TargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? TargetDedicated { get; set; }

        [Parameter(ParameterSetName = AutoScaleParameterSet)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? AutoScaleEvaluationInterval { get; set; }

        [Parameter(ParameterSetName = AutoScaleParameterSet)]
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

        public override void ExecuteCmdlet()
        {
            NewPoolParameters parameters = new NewPoolParameters(this.BatchContext, this.Id, this.AdditionalBehaviors)
            {
                VirtualMachineSize = this.VirtualMachineSize,
                OSFamily = this.OSFamily,
                DisplayName = this.DisplayName,
                TargetOSVersion = this.TargetOSVersion,
                ResizeTimeout = this.ResizeTimeout,
                TargetDedicated = this.TargetDedicated,
                AutoScaleEvaluationInterval = this.AutoScaleEvaluationInterval,
                AutoScaleFormula = this.AutoScaleFormula,
                MaxTasksPerComputeNode = this.MaxTasksPerComputeNode,
                TaskSchedulingPolicy = this.TaskSchedulingPolicy,
                Metadata = this.Metadata,
                InterComputeNodeCommunicationEnabled = this.InterComputeNodeCommunicationEnabled.IsPresent,
                StartTask = this.StartTask,
                CertificateReferences = this.CertificateReferences
            };

            BatchClient.CreatePool(parameters);
        }
    }
}
