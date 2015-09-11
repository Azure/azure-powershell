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

using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    using NSM = Management.Compute.Models;

    /// <summary>
    /// This cmdlet is used to get the status of the DSC extension handler for all or for a given virtual machine(s)
    /// in a cloud service. When a configuration is applied this cmdlet produces output consistent with Start-DscConfiguration. 
    /// 
    ///  Not: To get detailed output -Verbose flag need to be specified
    /// 
    /// Example Usage:
    /// Get-AzureVMDscExtensionStatus -ServiceName service
    /// Get-AzureVMDscExtensionStatus -ServiceName service -Name VM-name
    /// Get-AzureVMDscExtensionStatus -VM vm
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get, 
        VirtualMachineDscStatusCmdletNoun, 
        DefaultParameterSetName = GetStatusByServiceAndVmNameParamSet), 
        OutputType(typeof(VirtualMachineDscExtensionStatusContext))]
    public class GetAzureVmDscExtensionStatusCommand : IaaSDeploymentManagementCmdletBase
    {
        /// <summary>
        /// Name of the cloud service for DSC Extension Status
        /// </summary>
        [Parameter(
            ParameterSetName = GetStatusByServiceAndVmNameParamSet, 
            Position = 0, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the cloud service for DSC Extension Status.")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName { get; set; }

        /// <summary>
        /// Name of the VM in a cloud service for DSC Extension Status 
        /// </summary>
        [Parameter(
            ParameterSetName = GetStatusByServiceAndVmNameParamSet, 
            Position = 1, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the deployment for the status.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// VM object returned by Get-AzureVM cmdlet for DSC Extension Status 
        /// </summary>
        [Parameter(
            ParameterSetName = GetStatusByVmParamSet, 
            Mandatory = true, 
            ValueFromPipeline = true, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Virtual machine object for the status.")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public IPersistentVM VM { get; set; }

        protected const string VirtualMachineDscStatusCmdletNoun = "AzureVMDscExtensionStatus";
        protected const string GetStatusByServiceAndVmNameParamSet = "GetStatusByServiceAndVMName";
        protected const string GetStatusByVmParamSet = "GetStatusByVM";

        internal string VmName;

        /// <summary>
        /// This method is the entry point for this cmdlet. It gets the deployment information based on the service name
        /// and/or vm name and returns the status information for the DSC Extension Handler.
        /// </summary>
        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            GetService(ServiceName, VM);

            base.ExecuteCommand();

            if (CurrentDeploymentNewSM == null)
            {
                return;
            }
            
            var vmDscStatusContexts = GetVirtualMachineDscStatusContextList(CurrentDeploymentNewSM);
            if (vmDscStatusContexts == null || vmDscStatusContexts.Count < 1)
            {
                WriteWarning(Resources.ResourceExtensionReferenceCannotBeFound);
            }
            WriteObject(vmDscStatusContexts, true);
        }

        /// <summary>
        /// Retrieves service name from the cmdlet's service name or virtual machine parameter 
        /// </summary>
        /// <param name="serviceName">Name of the cloud service for DSC Extension Status</param>
        /// <param name="vm">Name of the VM in a cloud service for DSC Extension Status </param>
        internal void GetService(String serviceName, IPersistentVM vm)
        {
            if (!string.IsNullOrEmpty(serviceName))
            {
                this.ServiceName = serviceName;
            }
            else
            {
                //get the service name from the VM object
                var vmRoleContext = vm as PersistentVMRoleContext;
                if (vmRoleContext == null)
                    return;

                this.ServiceName = vmRoleContext.ServiceName;
                VmName = vmRoleContext.Name;
            }
        }

        /// <summary>
        /// Retrieves dsc extension status for all virtual machine's in a cloud service or a given virtual machine from the deployment object
        /// </summary>
        /// <param name="deployment">Deployment that exists in the service</param>
        /// <returns></returns>
        internal List<VirtualMachineDscExtensionStatusContext> GetVirtualMachineDscStatusContextList(NSM.DeploymentGetResponse deployment)
        {
            var vmDscStatusContexts = new List<VirtualMachineDscExtensionStatusContext>();
            
            //filter the deployment info for a vm, if specified. 
            var vmRoles = new List<NSM.Role>(deployment.Roles.Where(
                r => (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(VmName))
                  || r.RoleName.Equals(Name, StringComparison.InvariantCultureIgnoreCase) 
                  || r.RoleName.Equals(VmName, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var vm in vmRoles)
            {
                var roleInstance = deployment.RoleInstances.FirstOrDefault(
                    r => r.RoleName == vm.RoleName);

                if (roleInstance == null)
                {
                    WriteWarning(
                        string.Format(CultureInfo.CurrentUICulture, Resources.RoleInstanceCanNotBeFoundWithName, vm.RoleName));
                }

                var vmDscStatusContext = CreateDscStatusContext(
                    vm,
                    roleInstance);

                if (vmDscStatusContext != null)
                    vmDscStatusContexts.Add(vmDscStatusContext);
            }

            return vmDscStatusContexts;
        }

        /// <summary>
        /// Creates dsc extension status object for a virtual machine
        /// </summary>
        /// <param name="vmRole">Details of a role in the deployment</param>
        /// <param name="roleInstance">Details of a specific role instance</param>
        /// <returns></returns>
        internal VirtualMachineDscExtensionStatusContext CreateDscStatusContext(NSM.Role vmRole, NSM.RoleInstance roleInstance) 
        {
            var message = string.Empty;
            var extension = DscExtensionCmdletConstants.ExtensionPublishedNamespace + "."
                               + DscExtensionCmdletConstants.ExtensionPublishedName;
            NSM.ResourceExtensionConfigurationStatus extensionSettingStatus = null;
            
            if (roleInstance != null && roleInstance.ResourceExtensionStatusList != null)
            {
                foreach (var resourceExtensionStatus in 
                    roleInstance.ResourceExtensionStatusList.Where(
                    resourceExtensionStatus => resourceExtensionStatus.HandlerName.Equals(
                        extension, StringComparison.InvariantCultureIgnoreCase)).
                        Where(resourceExtensionStatus => resourceExtensionStatus.ExtensionSettingStatus != null))
                {
                    extensionSettingStatus = resourceExtensionStatus.ExtensionSettingStatus;

                    if (extensionSettingStatus.SubStatusList == null) continue;
                    var resourceExtensionSubStatusList = extensionSettingStatus.SubStatusList;
                    var resourceExtensionSubStatus = resourceExtensionSubStatusList.FirstOrDefault();
                    if (resourceExtensionSubStatus == null || resourceExtensionSubStatus.FormattedMessage == null ||
                        resourceExtensionSubStatus.FormattedMessage.Message == null) continue;
                    message = resourceExtensionSubStatus.FormattedMessage.Message.ToString(CultureInfo.CurrentUICulture);
                    break;
                }
            }

            if (extensionSettingStatus == null)
                return null;

            var dscStatusContext = new VirtualMachineDscExtensionStatusContext
            {
                ServiceName = this.ServiceName,
                Name = vmRole == null ? string.Empty : vmRole.RoleName,
                Status = extensionSettingStatus.Status ?? string.Empty,
                StatusCode = extensionSettingStatus.Code ?? -1,
                StatusMessage = (extensionSettingStatus.FormattedMessage == null || 
                    extensionSettingStatus.FormattedMessage.Message == null) ? string.Empty : 
                    extensionSettingStatus.FormattedMessage.Message.ToString(CultureInfo.CurrentUICulture),
                DscConfigurationLog = !string.Empty.Equals(message) ? message.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None) : new List<String>().ToArray(),
                Timestamp = extensionSettingStatus.Timestamp == null ? DateTime.MinValue : extensionSettingStatus.Timestamp.Value
            };
            return dscStatusContext;
        }
    }
}

