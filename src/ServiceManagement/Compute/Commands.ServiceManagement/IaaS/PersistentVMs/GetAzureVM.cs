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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using PVM = Model;
    using NSM = Management.Compute.Models;

    [Cmdlet(VerbsCommon.Get, AzureVMNoun, DefaultParameterSetName = ListVMParamSet), OutputType(typeof(PVM.PersistentVMRoleContext))]
    public class GetAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        protected const string AzureVMNoun = "AzureVM";
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
            else
            {
                WriteWarning(
                    string.Format(Resources.NoDeploymentFoundInService, ServiceName));
            }
        }

        private List<T> GetVMContextList<T>(string serviceName, NSM.DeploymentGetResponse deployment)
            where T : PVM.PersistentVMRoleContext, new()
        {
            var vmRoles = new List<NSM.Role>(deployment.Roles.Where(
                r => string.IsNullOrEmpty(Name)
                  || r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase)));

            return GetVMContextList<T>(serviceName, deployment, vmRoles);
        }

        private List<T> GetVMContextList<T>(string serviceName, NSM.DeploymentGetResponse deployment, List<NSM.Role> vmRoles)
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
                DeploymentName              = deployment.Name,
                DNSName                     = deployment.Uri.AbsoluteUri,
                Name                        = vmRole.RoleName,
                AvailabilitySetName         = vmRole.AvailabilitySetName,
                Label                       = vmRole.Label,
                InstanceSize                = vmRole.RoleSize,
                InstanceStatus              = roleInstance == null ? string.Empty : roleInstance.InstanceStatus,
                IpAddress                   = roleInstance == null ? string.Empty : roleInstance.IPAddress,
                PublicIPAddress             = roleInstance == null ? null
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? null
                                            : roleInstance.PublicIPs.First().Address,
                PublicIPName                = roleInstance == null ? null
                                            : roleInstance.PublicIPs == null || !roleInstance.PublicIPs.Any() ? null
                                            : !string.IsNullOrEmpty(roleInstance.PublicIPs.First().Name) ? roleInstance.PublicIPs.First().Name
                                            : PersistentVMHelper.GetPublicIPName(vmRole),
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
                OperationId                 = deployment.RequestId,
                OperationStatus             = deployment.StatusCode.ToString(),
                OperationDescription        = CommandRuntime.ToString(),
                VM = new PVM.PersistentVM
                {
                    AvailabilitySetName               = vmRole.AvailabilitySetName,
                    Label                             = vmRole.Label,
                    RoleName                          = vmRole.RoleName,
                    RoleSize                          = vmRole.RoleSize,
                    RoleType                          = vmRole.RoleType,
                    DefaultWinRmCertificateThumbprint = vmRole.DefaultWinRmCertificateThumbprint,
                    ProvisionGuestAgent               = vmRole.ProvisionGuestAgent,
                    ResourceExtensionReferences       = Mapper.Map<PVM.ResourceExtensionReferenceList>(vmRole.ResourceExtensionReferences),
                    DataVirtualHardDisks              = Mapper.Map<Collection<PVM.DataVirtualHardDisk>>(vmRole.DataVirtualHardDisks),
                    OSVirtualHardDisk                 = Mapper.Map<PVM.OSVirtualHardDisk>(vmRole.OSVirtualHardDisk),
                    ConfigurationSets                 = PersistentVMHelper.MapConfigurationSets(vmRole.ConfigurationSets)
                }
            };

            return vmContext;
        }
    }
}
