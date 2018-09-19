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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development
{
    /// <summary>
    /// Configure the number of instances or installed runtimes for a web/worker role. Updates the cscfg with the number of instances
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureServiceProjectRole"), OutputType(typeof(RoleSettings))]
    public class SetAzureServiceProjectRoleCommand : AzureSMCmdlet
    {
        const string InstancesParameterSet = "Instances";

        const string RuntimeParameterSet = "Runtime";

        const string VMSizeParameterSet = "VMSize";

        /// <summary>
        /// The role name to edit
        /// </summary>
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string RoleName { get; set; }

        /// <summary>
        /// The number of instances for the role - parameter set for instances contains role name and instances only
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InstancesParameterSet, ValueFromPipelineByPropertyName = true)]
        public int Instances { get; set; }

        /// <summary>
        /// Runtime identifier for the runtime to add. The Runtime parameter set takes rolename, runtime, and version
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RuntimeParameterSet, ValueFromPipelineByPropertyName = true)]
        public string Runtime { get; set; }

        /// <summary>
        /// The version of the runtime to install
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = RuntimeParameterSet, ValueFromPipelineByPropertyName = true)]
        public string Version { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// The size of the role - parameter set for instances contains role name and instance size only.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = VMSizeParameterSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string VMSize { get; set; }

        /// <summary>
        /// The code to run if setting azure instances
        /// </summary>
        /// <param name="roleName">The name of the role to update</param>
        /// <param name="instances">The new number of instances for the role</param>
        /// <param name="rootPath">The root path to the service containing the role</param>
        /// <returns>Role after updating instance count</returns>
        public RoleSettings SetAzureInstancesProcess(string roleName, int instances, string rootPath)
        {
            CloudServiceProject service = new CloudServiceProject(rootPath, null);
            service.SetRoleInstances(service.Paths, roleName, instances);

            if (PassThru)
            {
                SafeWriteOutputPSObject(typeof(RoleSettings).FullName, Parameters.RoleName, roleName);
            }

            return service.Components.GetCloudConfigRole(roleName);
        }

        /// <summary>
        /// Sets the VM size of the role.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="vmSize">The vm size</param>
        /// <param name="rootPath">The service root path</param>
        /// <returns>Role after updating VM size</returns>
        public RoleSettings SetAzureVMSizeProcess(string roleName, string vmSize, string rootPath)
        {
            CloudServiceProject service = new CloudServiceProject(rootPath, null);
            service.SetRoleVMSize(service.Paths, roleName, vmSize);

            if (PassThru)
            {
                SafeWriteOutputPSObject(typeof(RoleSettings).FullName, Parameters.RoleName, roleName);
            }

            return service.Components.GetCloudConfigRole(roleName);
        }

        /// <summary>
        /// The function to run if setting the runtime for a role
        /// </summary>
        /// <param name="roleName">The name of the role to modify</param>
        /// <param name="runtimeType">The type f role runtiem to configure</param>
        /// <param name="runtimeVersion">The version of the runtime</param>
        /// <param name="rootPath">The path to the service containing the role</param>
        /// <param name="manifest">The manifest containing available runtimes, defaults to the cloud manifest
        /// mainly used a s a test hook</param>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public RoleSettings SetAzureRuntimesProcess(
            string roleName,
            string runtimeType,
            string runtimeVersion,
            string rootPath,
            string manifest = null)
        {
            CloudServiceProject service = new CloudServiceProject(rootPath, null);
            service.AddRoleRuntime(service.Paths, roleName, runtimeType, runtimeVersion, manifest);

            if (PassThru)
            {
                SafeWriteOutputPSObject(typeof(RoleSettings).FullName, Parameters.RoleName, roleName);
            }

            return service.Components.GetCloudConfigRole(roleName);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void  ExecuteCmdlet()
        {
            string rootPath = CommonUtilities.GetServiceRootPath(CurrentPath());
            RoleName = string.IsNullOrEmpty(RoleName) ? CommonUtilities.GetRoleName(rootPath, CurrentPath()) : RoleName;

            if (string.Equals(this.ParameterSetName, InstancesParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                this.SetAzureInstancesProcess(RoleName, Instances, rootPath);
            }
            else if (string.Equals(this.ParameterSetName, VMSizeParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                this.SetAzureVMSizeProcess(RoleName, VMSize, rootPath);
            }
            else
            {
                this.SetAzureRuntimesProcess(RoleName, Runtime, Version, rootPath);
            }
        }
    }
}