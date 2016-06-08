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

using AutoMapper;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsData.Update, ProfileNouns.VirtualMachine), OutputType(typeof(ManagementOperationContext))]
    public class UpdateAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Virtual Machine to update.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Virtual Machine to update.")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public Model.PersistentVM VM
        {
            get;
            set;
        }

        internal void ExecuteCommandNewSM()
        {
            ServiceManagementProfile.Initialize();

            base.ExecuteCommand();

            AzureSubscription currentSubscription = Profile.Context.Subscription;
            if (CurrentDeploymentNewSM == null)
            {
                throw new ApplicationException(String.Format(Resources.CouldNotFindDeployment, ServiceName, Model.DeploymentSlotType.Production));
            }

            // Auto generate disk names based off of default storage account 
            foreach (var datadisk in this.VM.DataVirtualHardDisks)
            {
                if (datadisk.MediaLink == null && string.IsNullOrEmpty(datadisk.DiskName))
                {
                    CloudStorageAccount currentStorage = currentSubscription.GetCloudStorageAccount(Profile);
                    if (currentStorage == null)
                    {
                        throw new ArgumentException(Resources.CurrentStorageAccountIsNotAccessible);
                    }

                    string diskPartName = VM.RoleName;
                    if (datadisk.DiskLabel != null)
                    {
                        diskPartName += "-" + datadisk.DiskLabel;
                    }

                    var mediaLinkFactory = new MediaLinkFactory(currentStorage, this.ServiceName, diskPartName);
                    datadisk.MediaLink = mediaLinkFactory.Create();
                }

                if (VM.DataVirtualHardDisks.Count > 1)
                {
                    // To avoid duplicate disk names
                    System.Threading.Thread.Sleep(1);
                }
            }

            var parameters = new VirtualMachineUpdateParameters
            {
                AvailabilitySetName = VM.AvailabilitySetName,
                Label = VM.Label,
                OSVirtualHardDisk = Mapper.Map<OSVirtualHardDisk>(VM.OSVirtualHardDisk),
                RoleName = VM.RoleName,
                RoleSize = VM.RoleSize,
                ProvisionGuestAgent = VM.ProvisionGuestAgent,
                ResourceExtensionReferences = VM.ProvisionGuestAgent != null && VM.ProvisionGuestAgent.Value ? Mapper.Map<List<ResourceExtensionReference>>(VM.ResourceExtensionReferences) : null
            };

            if (parameters.OSVirtualHardDisk != null)
            {
                parameters.OSVirtualHardDisk.IOType = null;
            }

            if (VM.DataVirtualHardDisks != null)
            {
                parameters.DataVirtualHardDisks = new List<DataVirtualHardDisk>();
                VM.DataVirtualHardDisks.ForEach(c =>
                {
                    var dataDisk = Mapper.Map<DataVirtualHardDisk>(c);
                    dataDisk.LogicalUnitNumber = dataDisk.LogicalUnitNumber;
                    parameters.DataVirtualHardDisks.Add(dataDisk);
                });
                parameters.DataVirtualHardDisks.ForEach(d => d.IOType = null);
            }

            if (VM.ConfigurationSets != null)
            {
                PersistentVMHelper.MapConfigurationSets(VM.ConfigurationSets).ForEach(c => parameters.ConfigurationSets.Add(c));
            }

            if (VM.DataVirtualHardDisksToBeDeleted != null && VM.DataVirtualHardDisksToBeDeleted.Any())
            {
                var vmRole = CurrentDeploymentNewSM.Roles.First(r => r.RoleName == this.Name);
                if (vmRole != null)
                {
                    foreach (var dataDiskToBeDeleted in VM.DataVirtualHardDisksToBeDeleted)
                    {
                        int lun = dataDiskToBeDeleted.Lun;
                        try
                        {
                            this.ComputeClient.VirtualMachineDisks.DeleteDataDisk(
                                this.ServiceName,
                                CurrentDeploymentNewSM.Name,
                                vmRole.RoleName,
                                lun,
                                true);
                        }
                        catch (CloudException ex)
                        {
                            WriteWarning(string.Format(Resources.CannotDeleteVirtualMachineDataDiskForLUN, lun));

                            if (ex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                            {
                                throw;
                            }
                        }
                    }
                }
            }

            if (VM.DebugSettings != null)
            {
                parameters.DebugSettings = new DebugSettings
                {
                    BootDiagnosticsEnabled = VM.DebugSettings.BootDiagnosticsEnabled
                };
            }

            ExecuteClientActionNewSM(
                parameters,
                CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.Update(this.ServiceName, CurrentDeploymentNewSM.Name, this.Name, parameters));
        }

        protected override void ExecuteCommand()
        {
            this.ExecuteCommandNewSM();
        }
    }
}
