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
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding
{
    /// <summary>
    /// Adds dedicated caching node worker role.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureCacheWorkerRole"), OutputType(typeof(WorkerRole))]
    public class AddAzureCacheWorkerRoleCommand : AzurePSCmdlet
    {
        [Parameter(Position = 0, HelpMessage = "Role name")]
        [Alias("n")]
        public string Name { get; set; }

        [Parameter(Position = 1, HelpMessage = "Instances count")]
        [Alias("i")]
        public int Instances { get; set; }

        /// <summary>
        /// Creates new instance from AddAzureCacheWorkerRoleCommand
        /// </summary>
        public AddAzureCacheWorkerRoleCommand()
        {
            Instances = 1;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            WriteWarning("This cmdlet will be removed in a future release as we are retiring Managed Cache scaffolding support.");
            AddAzureCacheWorkerRoleProcess(Name, Instances, CommonUtilities.GetServiceRootPath(CurrentPath()));
        }

        /// <summary>
        /// Process for creating caching worker role.
        /// </summary>
        /// <param name="workerRoleName">The cache worker role name</param>
        /// <param name="instances">The instance count</param>
        /// <param name="rootPath">The service root path</param>
        /// <returns>The added cache worker role</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public WorkerRole AddAzureCacheWorkerRoleProcess(string workerRoleName, int instances, string rootPath)
        {
            // Create cache worker role.
            Action<string, RoleInfo> cacheWorkerRoleAction = CacheConfigurationFactory.GetCacheRoleConfigurationAction(
                AzureTool.GetAzureSdkVersion());

            CloudServiceProject cloudServiceProject = new CloudServiceProject(rootPath, null);
            
            RoleInfo genericWorkerRole = cloudServiceProject.AddWorkerRole(
                Path.Combine(Resources.GeneralScaffolding, RoleType.WorkerRole.ToString()),
                workerRoleName,
                instances);

            // Dedicate the worker role for caching.
            cacheWorkerRoleAction(cloudServiceProject.Paths.RootPath, genericWorkerRole);

            cloudServiceProject.Reload();
            WorkerRole cacheWorkerRole = cloudServiceProject.Components.GetWorkerRole(genericWorkerRole.Name);

            // Write output
            SafeWriteOutputPSObject(
                cacheWorkerRole.GetType().FullName,
                Parameters.CacheWorkerRoleName, genericWorkerRole.Name,
                Parameters.Instances, genericWorkerRole.InstanceCount
                );

            return cloudServiceProject.Components.GetWorkerRole(workerRoleName);
        }
    }
}
