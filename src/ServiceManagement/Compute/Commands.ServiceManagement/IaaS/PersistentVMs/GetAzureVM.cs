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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using AutoMapper;
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using PVM = Model;
    using NSM = Management.Compute.Models;

    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachine, DefaultParameterSetName = ListVMParamSet), OutputType(typeof(PVM.PersistentVMRoleContext))]
    public class GetAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        protected const string PersistentVMRoleStr = "PersistentVMRole";
        protected const string ListVMParamSet = "ListAllVMs";
        protected const string GetVMParamSet = "GetVMByServiceAndVMName";

        [Parameter(ParameterSetName = GetVMParamSet, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName { get; set; }

        [Parameter(ParameterSetName = GetVMParamSet, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the virtual machine to get.")]
        public virtual string Name { get; set; }

        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            base.ExecuteCommand();

            if (string.IsNullOrEmpty(ServiceName))
            {
                var roleContexts = new List<PVM.PersistentVMRoleListContext>();

                foreach (var service in this.ComputeClient.HostedServices.List())
                {
                    NSM.DeploymentGetResponse deployment = null;

                    try
                    {
                        deployment = this.ComputeClient.Deployments.GetBySlot(
                            service.ServiceName,
                            NSM.DeploymentSlot.Production);
                    }
                    catch (CloudException e)
                    {
                        if (e.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }

                    if (deployment != null)
                    {
                        roleContexts.AddRange(
                            GetVMContextList<PVM.PersistentVMRoleListContext>(
                                service.ServiceName,
                                deployment).AsEnumerable());
                    }
                }

                WriteObject(roleContexts, true);
            }
            else if (CurrentDeploymentNewSM != null)
            {
                var roleContexts = GetVMContextList<PVM.PersistentVMRoleContext>(
                        ServiceName,
                        CurrentDeploymentNewSM);

                WriteObject(roleContexts, true);
            }
        }

        private List<T> GetVMContextList<T>(string serviceName, NSM.DeploymentGetResponse deployment)
            where T : PVM.PersistentVMRoleContext, new()
        {
            Func<NSM.Role, bool> typeMatched =
                r => string.Equals(r.RoleType, PersistentVMRoleStr, StringComparison.OrdinalIgnoreCase);

            Func<NSM.Role, bool> nameMatched =
                r => string.IsNullOrEmpty(this.Name) || r.RoleName.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase);

            var vmRoles = new List<NSM.Role>(deployment.Roles.Where(r => typeMatched(r) && nameMatched(r)));

            return CreateVMContextList<T>(serviceName, deployment, vmRoles);
        }

        private List<T> CreateVMContextList<T>(string serviceName, NSM.DeploymentGetResponse deployment, List<NSM.Role> vmRoles)
            where T : PVM.PersistentVMRoleContext, new()
        {
            var roleContexts = new List<T>();

            foreach (var vm in vmRoles)
            {
                var roleInstance = deployment.RoleInstances.FirstOrDefault(
                    r => r.RoleName == vm.RoleName);

                if (roleInstance == null)
                {
                    WriteWarning(
                        string.Format(Resources.RoleInstanceCanNotBeFoundWithName, vm.RoleName));
                }

                roleContexts.Add(
                    CreateVMContext<T>(
                        serviceName,
                        vm,
                        roleInstance,
                        deployment));
            }

            return roleContexts;
        }

        private T CreateVMContext<T>(string serviceName, NSM.Role vmRole, NSM.RoleInstance roleInstance, NSM.DeploymentGetResponse deployment)
            where T : PVM.PersistentVMRoleContext, new()
        {
            var vmContext = new T
            {
                ServiceName                 = serviceName,
                DeploymentName              = deployment == null ? string.Empty : deployment.Name,
                DNSName                     = deployment == null || deployment.Uri == null ? string.Empty : deployment.Uri.AbsoluteUri,
                Name                        = vmRole == null ? string.Empty : vmRole.RoleName,
                AvailabilitySetName         = vmRole == null ? string.Empty : vmRole.AvailabilitySetName,
                Label                       = vmRole == null ? string.Empty : vmRole.Label,
                InstanceSize                = vmRole == null ? string.Empty : vmRole.RoleSize,
                InstanceStatus              = roleInstance == null ? string.Empty : roleInstance.InstanceStatus,
                IpAddress                   = roleInstance == null ? string.Empty : roleInstance.IPAddress,
                PublicIPAddress             = roleInstance == null ? string.Empty
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? string.Empty
                                            : roleInstance.PublicIPs.First().Address,
                PublicIPName                = roleInstance == null ? string.Empty
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? string.Empty
                                            : !string.IsNullOrEmpty(roleInstance.PublicIPs.First().Name) ? roleInstance.PublicIPs.First().Name
                                            : PersistentVMHelper.GetPublicIPName(vmRole),
                PublicIPDomainNameLabel     = roleInstance == null ? string.Empty
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? string.Empty
                                            : roleInstance.PublicIPs.First().DomainNameLabel,
                PublicIPFqdns               = roleInstance == null ? new List<string>()
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? new List<string>()
                                            : roleInstance.PublicIPs.First().Fqdns.ToList(),
                InstanceStateDetails        = roleInstance == null ? string.Empty : roleInstance.InstanceStateDetails,
                PowerState                  = roleInstance == null ? string.Empty : roleInstance.PowerState.ToString(),
                HostName                    = roleInstance == null ? string.Empty : roleInstance.HostName,
                InstanceErrorCode           = roleInstance == null ? string.Empty : roleInstance.InstanceErrorCode,
                InstanceName                = roleInstance == null ? string.Empty : roleInstance.InstanceName,
                InstanceFaultDomain         = roleInstance == null ? string.Empty : roleInstance.InstanceFaultDomain.HasValue
                                                                                  ? roleInstance.InstanceFaultDomain.Value.ToString(CultureInfo.InvariantCulture) : null,
                InstanceUpgradeDomain       = roleInstance == null ? string.Empty : roleInstance.InstanceUpgradeDomain.HasValue
                                                                                  ? roleInstance.InstanceUpgradeDomain.Value.ToString(CultureInfo.InvariantCulture) : null,
                Status                      = roleInstance == null ? string.Empty : roleInstance.InstanceStatus,
                GuestAgentStatus            = roleInstance == null ? null : Mapper.Map<PVM.GuestAgentStatus>(roleInstance.GuestAgentStatus),
                ResourceExtensionStatusList = roleInstance == null ? null : Mapper.Map<List<PVM.ResourceExtensionStatus>>(roleInstance.ResourceExtensionStatusList),
                OperationId                 = deployment == null ? string.Empty : deployment.RequestId,
                OperationStatus             = deployment == null ? string.Empty : deployment.StatusCode.ToString(),
                OperationDescription        = CommandRuntime.ToString(),
                NetworkInterfaces           = roleInstance == null ? null : Mapper.Map<PVM.NetworkInterfaceList>(roleInstance.NetworkInterfaces),
                VirtualNetworkName          = deployment == null ? null : deployment.VirtualNetworkName,
                RemoteAccessCertificateThumbprint =  roleInstance == null ? string.Empty : roleInstance.RemoteAccessCertificateThumbprint,
                VM = new PVM.PersistentVM
                {
                    AvailabilitySetName               = vmRole == null ? string.Empty : vmRole.AvailabilitySetName,
                    Label                             = vmRole == null ? string.Empty : vmRole.Label,
                    RoleName                          = vmRole == null ? string.Empty : vmRole.RoleName,
                    RoleSize                          = vmRole == null ? string.Empty : vmRole.RoleSize,
                    RoleType                          = vmRole == null ? string.Empty : vmRole.RoleType,
                    DefaultWinRmCertificateThumbprint = vmRole == null ? string.Empty : vmRole.DefaultWinRmCertificateThumbprint,
                    ProvisionGuestAgent               = vmRole == null ? null : vmRole.ProvisionGuestAgent,
                    ResourceExtensionReferences       = vmRole == null ? null : Mapper.Map<PVM.ResourceExtensionReferenceList>(vmRole.ResourceExtensionReferences),
                    DataVirtualHardDisks              = vmRole == null ? null : Mapper.Map<Collection<PVM.DataVirtualHardDisk>>(vmRole.DataVirtualHardDisks),
                    OSVirtualHardDisk                 = vmRole == null ? null : Mapper.Map<PVM.OSVirtualHardDisk>(vmRole.OSVirtualHardDisk),
                    ConfigurationSets                 = vmRole == null ? null : PersistentVMHelper.MapConfigurationSets(vmRole.ConfigurationSets),
                    DebugSettings                     = (vmRole == null || vmRole.DebugSettings == null) ? null : Mapper.Map<PVM.DebugSettings>(vmRole.DebugSettings),
                    MigrationState                    = vmRole == null ? string.Empty : vmRole.MigrationState,
                    LicenseType                       = vmRole == null ? string.Empty : vmRole.LicenseType
                }
            };

            return vmContext;
        }
    }
}
