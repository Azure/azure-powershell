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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, "AzureBatchPool", DefaultParameterSetName = TargetDedicatedParameterSet)]
    public class NewBatchPoolCommand : BatchObjectModelCmdletBase
    {
        internal const string TargetDedicatedParameterSet = "TargetDedicated";
        internal const string AutoScaleParameterSet = "AutoScale";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the Pool to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The size of the VMs in the Pool.")]
        [ValidateNotNullOrEmpty]
        public string VMSize { get; set; }

        [Parameter(HelpMessage = "The OS family of the VMs in the Pool. You can learn more about OS families and versions at http://azure.microsoft.com/en-us/documentation/articles/cloud-services-guestos-update-matrix/")]
        [ValidateNotNullOrEmpty]
        public string OSFamily { get; set; }

        [Parameter(HelpMessage = "The target OS version of the VMs in the Pool. Use \"*\" for the latest OS version for the specified family. You can learn more about OS families and versions at http://azure.microsoft.com/en-us/documentation/articles/cloud-services-guestos-update-matrix/")]
        [ValidateNotNullOrEmpty]
        public string TargetOSVersion { get; set; }

        [Parameter(ParameterSetName = TargetDedicatedParameterSet, HelpMessage = "The timeout for allocating VMs to the Pool.")]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ResizeTimeout { get; set; }

        [Parameter(ParameterSetName = TargetDedicatedParameterSet, HelpMessage = "The target number of VMs to allocate to the Pool.")]
        [ValidateNotNullOrEmpty]
        public int? TargetDedicated { get; set; }

        [Parameter(ParameterSetName = AutoScaleParameterSet, HelpMessage = "The formula for automatically scaling the Pool.")]
        [ValidateNotNullOrEmpty]
        public string AutoScaleFormula { get; set; }

        [Parameter(HelpMessage = "The maximum number of Tasks that can run on a single VM.")]
        [ValidateNotNullOrEmpty]
        public int? MaxTasksPerVM { get; set; }

        [Parameter(HelpMessage = "The scheduling policy.")]
        [ValidateNotNullOrEmpty]
        public PSSchedulingPolicy SchedulingPolicy { get; set; }

        [Parameter(HelpMessage = "Metadata to add to the new Pool. For each key/value pair, set the key to the Metadata name, and the value to the Metadata value.")]
        [ValidateNotNullOrEmpty]
        public IDictionary Metadata { get; set; }

        [Parameter(HelpMessage = "Set up the Pool for direct communication between dedicated VMs.")]
        public SwitchParameter CommunicationEnabled { get; set; }

        [Parameter(HelpMessage = "The start task specification for the Pool. The start task is run when a VM joins the Pool, or when the VM is rebooted or reimaged.")]
        [ValidateNotNullOrEmpty]
        public PSStartTask StartTask { get; set; }

        [Parameter(HelpMessage = "Certificates associated with the Pool.")]
        [ValidateNotNullOrEmpty]
        public PSCertificateReference[] CertificateReferences { get; set; }

        public override void ExecuteCmdlet()
        {
            NewPoolParameters parameters = new NewPoolParameters()
            {
                Context = this.BatchContext,
                PoolName = this.Name,
                VMSize = this.VMSize,
                OSFamily = this.OSFamily,
                TargetOSVersion = this.TargetOSVersion,
                ResizeTimeout = this.ResizeTimeout,
                TargetDedicated = this.TargetDedicated,
                AutoScaleFormula = this.AutoScaleFormula,
                MaxTasksPerVM = this.MaxTasksPerVM,
                SchedulingPolicy = this.SchedulingPolicy,
                Metadata = this.Metadata,
                Communication = this.CommunicationEnabled.IsPresent,
                StartTask = this.StartTask,
                CertificateReferences = this.CertificateReferences,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            BatchClient.CreatePool(parameters);
        }
    }
}
