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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", DefaultParameterSetName = ResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class StopAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        private const string ResourceGroupHibernateParamSet = "ResourceGroupHibernateParameterSet",
                             IdHibernateParamSet = "IdHibernateParameterSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupHibernateParamSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public new string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = ResourceGroupHibernateParamSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To force the stopping.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupNameParameterSet,
            HelpMessage = "To keep the VM provisioned.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = IdParameterSet,
            HelpMessage = "To keep the VM provisioned.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter StayProvisioned { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }
        
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupNameParameterSet,
            HelpMessage = "To request non-graceful VM shutdown when keeping the VM provisioned.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = IdParameterSet,
            HelpMessage = "To request non-graceful VM shutdown when keeping the VM provisioned.")]
        public SwitchParameter SkipShutdown { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupHibernateParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Optional parameter to hibernate a virtual machine. (Feature in Preview)")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = IdHibernateParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Optional parameter to hibernate a virtual machine. (Feature in Preview)")]
        public SwitchParameter Hibernate { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(Name, VerbsLifecycle.Stop) 
                    && (this.Force.IsPresent || this.ShouldContinue(Properties.Resources.VirtualMachineStoppingConfirmation, Properties.Resources.VirtualMachineStoppingCaption)))
                {
                    if (ParameterSetName.Equals(IdParameterSet) && string.IsNullOrEmpty(Name))
                    {
                        ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                        this.ResourceGroupName = parsedId.ResourceGroupName;
                        this.Name = parsedId.ResourceName;
                    }

                    Rest.Azure.AzureOperationResponse op;
                    if (this.StayProvisioned) 
                    {
                        bool? skipShutdown = this.SkipShutdown.IsPresent ? (bool?)true : null;
                        if (NoWait.IsPresent)
                        {
                            op = this.VirtualMachineClient.BeginPowerOffWithHttpMessagesAsync(this.ResourceGroupName, this.Name, skipShutdown, null, CancellationToken.None).GetAwaiter().GetResult();
                        }
                        else 
                        {
                            op = this.VirtualMachineClient.PowerOffWithHttpMessagesAsync(this.ResourceGroupName, this.Name, skipShutdown, null, CancellationToken.None).GetAwaiter().GetResult();
                        }
                    }
                    else if (this.IsParameterBound(c => c.Hibernate) && this.Hibernate)
                    {
                        if (NoWait.IsPresent)
                        {
                            op = this.VirtualMachineClient.BeginDeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, this.Hibernate, null, CancellationToken.None).GetAwaiter().GetResult();
                        }
                        else
                        {
                            op = this.VirtualMachineClient.DeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, this.Hibernate, null, CancellationToken.None).GetAwaiter().GetResult();
                        }
                    }
                    else
                    {
                        if (NoWait.IsPresent)
                        {
                            op = this.VirtualMachineClient.BeginDeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, null, CancellationToken.None).GetAwaiter().GetResult();
                        }
                        else
                        {
                            op = this.VirtualMachineClient.DeallocateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, null, CancellationToken.None).GetAwaiter().GetResult();
                        }

                    }
                    if (NoWait.IsPresent) {
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else 
                    {
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        result.StartTime = this.StartTime;
                        result.EndTime = DateTime.Now;
                        WriteObject(result);
                    }
                }
                else
                {
                    WriteDebugWithTimestamp("[Stop-AzVMJob]: ShouldMethod returned false");
                }
            });
        }
    }
}
