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

using System;
using System.Net;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;


namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    using NSM = Management.Compute.Models;

    [Cmdlet(VerbsCommon.Get, VirtualMachineDscStatusCmdletNoun, DefaultParameterSetName = GetStatusByServiceAndVmNameParamSet), OutputType(typeof(VirtualMachineDscExtensionStatusContext))]
    public class GetAzureVmDscExtensionStatusCommand : IaaSDeploymentManagementCmdletBase
    {
        [Parameter(ParameterSetName = GetStatusByServiceAndVmNameParamSet, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName { get; set; }
        
        [Parameter(ParameterSetName = GetStatusByServiceAndVmNameParamSet, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment for the status.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetStatusByVmParamSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Virtual machine object for the status.")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public IPersistentVM VM { get; set; }

        protected const string VirtualMachineDscStatusCmdletNoun = "AzureVMDscExtensionStatus";
        protected const string GetStatusByServiceAndVmNameParamSet = "GetStatusByServiceAndVMName";
        protected const string GetStatusByVmParamSet = "GetStatusByVM";
        protected string Service = null;
        protected string VmName = null;

        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            GetCurrentDeployment(this.ServiceName, this.VM);

            if (CurrentDeploymentNewSM == null)
            {
                WriteWarning(
                    string.Format(CultureInfo.CurrentUICulture, Resources.NoDeploymentFoundInService, Service));
                return;
            }
            
            var vmDscStatusContexts = GetVirtualMachineDscStatusContextList<VirtualMachineDscExtensionStatusContext>(CurrentDeploymentNewSM);
            if (vmDscStatusContexts == null || vmDscStatusContexts.Count < 1)
            {
                WriteWarning(Resources.ResourceExtensionReferenceCannotBeFound);
            }
            WriteObject(vmDscStatusContexts, true);
        }

        protected void GetCurrentDeployment(String serviceName, IPersistentVM vm)
        {
            InvokeInOperationContext(() =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(serviceName))
                    {
                        Service = serviceName;
                        CurrentDeploymentNewSM = this.ComputeClient.Deployments.GetBySlot(serviceName, NSM.DeploymentSlot.Production);
                    }
                    else
                    {
                        //get the service name from the VM object
                        var vmRoleContext = vm as PersistentVMRoleContext;
                        if (vmRoleContext == null)
                            return;

                        Service = vmRoleContext.ServiceName;
                        VmName = vmRoleContext.Name;
                        CurrentDeploymentNewSM = this.ComputeClient.Deployments.GetBySlot(vmRoleContext.ServiceName, NSM.DeploymentSlot.Production);
                    }

                    GetDeploymentOperationNewSM = GetOperationNewSM(CurrentDeploymentNewSM.RequestId);
                    WriteVerboseWithTimestamp(Resources.GetDeploymentCompletedOperation);
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw;
                    }
                }
            });
        }
        private List<T> GetVirtualMachineDscStatusContextList<T>(NSM.DeploymentGetResponse deployment)
            where T : VirtualMachineDscExtensionStatusContext, new()
        {
            var vmDscStatusContexts = new List<T>();
            var vmRoles = new List<NSM.Role>(deployment.Roles.Where(
                r => (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(VmName))
                  || r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase) || r.RoleName.Equals(VmName, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var vm in vmRoles)
            {
                var roleInstance = deployment.RoleInstances.FirstOrDefault(
                    r => r.RoleName == vm.RoleName);

                if (roleInstance == null)
                {
                    WriteWarning(
                        string.Format(CultureInfo.CurrentUICulture, Resources.RoleInstanceCanNotBeFoundWithName, vm.RoleName));
                }

                var vmDscStatusContext = CreateDscStatusContext<T>(
                    vm,
                    roleInstance,
                    deployment);

                if (vmDscStatusContext != null)
                    vmDscStatusContexts.Add(vmDscStatusContext);
            }

            return vmDscStatusContexts;
        }

        private T CreateDscStatusContext<T>(NSM.Role vmRole, NSM.RoleInstance roleInstance,
            NSM.DeploymentGetResponse deployment) where T : VirtualMachineDscExtensionStatusContext, new()
        {
            var message = string.Empty;
            NSM.ResourceExtensionConfigurationStatus extensionSettingStatus = null;
            
            if (roleInstance != null && roleInstance.ResourceExtensionStatusList != null)
            {
                foreach (var resourceExtensionStatus in roleInstance.ResourceExtensionStatusList.Where(resourceExtensionStatus => resourceExtensionStatus.HandlerName.Equals(VirtualMachineDscExtensionCmdletBase.ExtensionPublishedNamespace + "." + VirtualMachineDscExtensionCmdletBase.ExtensionPublishedName, StringComparison.InvariantCultureIgnoreCase)).Where(resourceExtensionStatus => resourceExtensionStatus.ExtensionSettingStatus != null))
                {
                    extensionSettingStatus = resourceExtensionStatus.ExtensionSettingStatus;

                    if (extensionSettingStatus.SubStatusList != null)
                    {
                        var resourceExtensionSubStatusList = extensionSettingStatus.SubStatusList;
                        var resourceExtensionSubStatus = resourceExtensionSubStatusList.FirstOrDefault();
                        if (resourceExtensionSubStatus != null && resourceExtensionSubStatus.FormattedMessage != null &&
                            resourceExtensionSubStatus.FormattedMessage.Message != null)
                        {
                            message = resourceExtensionSubStatus.FormattedMessage.Message.ToString(CultureInfo.CurrentUICulture);
                            break;
                        }
                    }
                }
            }

            if (extensionSettingStatus == null)
                return null;

            var dscStatusContext = new T
            {
                ServiceName = Service,
                Name = vmRole == null ? string.Empty : vmRole.RoleName,
                Status = extensionSettingStatus.Status ?? string.Empty,
                StatusCode = (int)(extensionSettingStatus.Code ?? -1),
                StatusMessage = (extensionSettingStatus.FormattedMessage == null || extensionSettingStatus.FormattedMessage.Message == null) ? string.Empty : extensionSettingStatus.FormattedMessage.Message.ToString(CultureInfo.CurrentUICulture),
                DscConfigurationLog = !string.Empty.Equals(message) ? message.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None) : new List<String>().ToArray(),
                Timestamp = extensionSettingStatus.Timestamp == null ? DateTime.MinValue : extensionSettingStatus.Timestamp.Value
            };
            return dscStatusContext;
        }

    }
}

