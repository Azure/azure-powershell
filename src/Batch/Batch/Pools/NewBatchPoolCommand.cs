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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchPool", DefaultParameterSetName = CloudServiceTargetDedicatedParameterSet, SupportsShouldProcess=true), OutputType(typeof(void))]
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
        [Alias("TargetDedicated")]
        public int? TargetDedicatedComputeNodes { get; set; }

        [Parameter(ParameterSetName = VirtualMachineTargetDedicatedParameterSet)]
        [Parameter(ParameterSetName = CloudServiceTargetDedicatedParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? TargetLowPriorityComputeNodes { get; set; }

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
        [Alias("MaxTasksPerComputeNode")]
        public int? TaskSlotsPerNode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The upgrade policy for the pool")]
        [ValidateNotNullOrEmpty]
        public PSUpgradePolicy UpgradePolicy { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSTaskSchedulingPolicy TaskSchedulingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The user  defined tags to be associated with the Azure Batch Pool.When specified, these tags are propagated to the backing Azure resources associated with the pool.This property can only be specified when the Batch account was created with the poolAllocationMode property set to 'UserSubscription'.")]
        [ValidateNotNullOrEmpty]
        public IDictionary ResourceTag { get; set; }

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
        [Alias("CertificateReference")]
        public PSCertificateReference[] CertificateReferences { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationPackageReference")]
        public PSApplicationPackageReference[] ApplicationPackageReferences { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationLicense")]
        public List<string> ApplicationLicenses { get; set; }

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

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSMountConfiguration[] MountConfiguration { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public PSUserAccount[] UserAccount { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public NodeCommunicationMode CurrentNodeCommunicationMode { get; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Default", "Classic", "Simplified")]
        public NodeCommunicationMode TargetNodeCommunicationMode { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            NewPoolParameters parameters = new NewPoolParameters(this.BatchContext, this.Id, this.AdditionalBehaviors)
            {
                VirtualMachineSize = this.VirtualMachineSize,
                DisplayName = this.DisplayName,
                ResizeTimeout = this.ResizeTimeout,
                TargetDedicatedComputeNodes = this.TargetDedicatedComputeNodes,
                TargetLowPriorityComputeNodes = this.TargetLowPriorityComputeNodes,
                AutoScaleEvaluationInterval = this.AutoScaleEvaluationInterval,
                AutoScaleFormula = this.AutoScaleFormula,
                TaskSlotsPerNode = this.TaskSlotsPerNode,
                TaskSchedulingPolicy = this.TaskSchedulingPolicy,
                UpgradePolicy = this.UpgradePolicy,
                Metadata = this.Metadata,
                InterComputeNodeCommunicationEnabled = this.InterComputeNodeCommunicationEnabled.IsPresent,
                StartTask = this.StartTask,
                CertificateReferences = this.CertificateReferences,
                ApplicationPackageReferences = this.ApplicationPackageReferences,
                VirtualMachineConfiguration =  this.VirtualMachineConfiguration,
                CloudServiceConfiguration = this.CloudServiceConfiguration,
                NetworkConfiguration = this.NetworkConfiguration,
                UserAccounts = this.UserAccount,
                ApplicationLicenses = this.ApplicationLicenses,
                MountConfiguration = this.MountConfiguration,
                TargetCommunicationMode = this.TargetNodeCommunicationMode,
                ResourceTags = this.ResourceTag,
            };

            if (ShouldProcess("AzureBatchPool"))
            {
                BatchClient.CreatePool(parameters);
            }
        }
    }
}
