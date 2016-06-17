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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using PVM = Model;

    [Cmdlet(VerbsData.Export, ProfileNouns.VirtualMachine)]
    public class ExportAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the virtual machine to get.")]
        public virtual string Name
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The file path in which serialize the persistent VM role state.")]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get;
            set;
        }

        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            base.ExecuteCommand();
            if (CurrentDeploymentNewSM == null)
            {
                return;
            }

            var role = CurrentDeploymentNewSM.Roles.FirstOrDefault(r => r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase));
            if(role == null)
            {
                throw new ApplicationException(string.Format(Resources.NoCorrespondingRoleCanBeFoundInDeployment, Name));
            }
            try
            {
                var vm = role;
                var roleInstance = CurrentDeploymentNewSM.RoleInstances.First(r => r.RoleName == vm.RoleName);
                var vmContext = new PVM.PersistentVMRoleContext
                {
                    ServiceName = ServiceName,
                    Name = vm.RoleName,
                    DeploymentName = CurrentDeploymentNewSM.Name,
                    AvailabilitySetName = vm.AvailabilitySetName,
                    Label = vm.Label,
                    InstanceSize = vm.RoleSize.ToString(),
                    InstanceStatus = roleInstance.InstanceStatus,
                    IpAddress = roleInstance.IPAddress,
                    InstanceStateDetails = roleInstance.InstanceStateDetails,
                    PowerState = roleInstance.PowerState.ToString(),
                    InstanceErrorCode = roleInstance.InstanceErrorCode,
                    InstanceName = roleInstance.InstanceName,
                    InstanceFaultDomain = roleInstance.InstanceFaultDomain.HasValue ? roleInstance.InstanceFaultDomain.Value.ToString(CultureInfo.InvariantCulture) : null,
                    InstanceUpgradeDomain = roleInstance.InstanceUpgradeDomain.HasValue ? roleInstance.InstanceUpgradeDomain.Value.ToString(CultureInfo.InvariantCulture) : null,
                    OperationDescription = CommandRuntime.ToString(),
                    OperationId = GetDeploymentOperationNewSM.Id,
                    OperationStatus = GetDeploymentOperationNewSM.Status.ToString(),
                    VM = new PVM.PersistentVM
                    {
                        AvailabilitySetName = vm.AvailabilitySetName,
                        ConfigurationSets = PersistentVMHelper.MapConfigurationSets(vm.ConfigurationSets),
                        DataVirtualHardDisks = new Collection<PVM.DataVirtualHardDisk>(),
                        Label = vm.Label,
                        OSVirtualHardDisk = Mapper.Map(vm.OSVirtualHardDisk, new PVM.OSVirtualHardDisk()),
                        RoleName = vm.RoleName,
                        RoleSize = vm.RoleSize.ToString(),
                        RoleType = vm.RoleType,
                        DefaultWinRmCertificateThumbprint = vm.DefaultWinRmCertificateThumbprint,
                        ProvisionGuestAgent = vm.ProvisionGuestAgent,
                        ResourceExtensionReferences = Mapper.Map<PVM.ResourceExtensionReferenceList>(vm.ResourceExtensionReferences),
                        DebugSettings = Mapper.Map<PVM.DebugSettings>(vm.DebugSettings)
                    }
                };

                if (vm.DataVirtualHardDisks != null)
                {
                    vm.DataVirtualHardDisks.ForEach(
                        d => vmContext.VM.DataVirtualHardDisks.Add(Mapper.Map<PVM.DataVirtualHardDisk>(d)));
                }
                else
                {
                    vmContext.VM.DataVirtualHardDisks = null;
                }

                PersistentVMHelper.SaveStateToFile(vmContext.VM, Path);
                WriteObject(vmContext, true);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format(Resources.VMPropertiesCanNotBeRead, role.RoleName), e);
            }
        }
    }
}
