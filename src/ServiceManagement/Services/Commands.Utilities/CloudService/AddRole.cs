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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    /// <summary>
    /// Creates basic scaffolding structure for azure web/worker role.
    /// </summary>
    public abstract class AddRole : AzureSMCmdlet
    {
        private string successMessage;

        private bool isWebRole;

        protected string Scaffolding { set; get; }

        public string RootPath { set; get; }

        [Parameter(Position = 0, HelpMessage = "Role name")]
        [Alias("n")]
        public string Name { get; set; }

        [Parameter(Position = 1, HelpMessage = "Instances count")]
        [Alias("i")]
        public int Instances { get; set; }

        /// <summary>
        /// Constructs new AddRole instance.
        /// </summary>
        /// <param name="scaffolding">The scaffolding path</param>
        /// <param name="successMessage">The verbose message to emit when the cmdlet succeed</param>
        /// <param name="isWebRole">Flag that indicates role is web or worker</param>
        /// <param name="rootPath">The service root path</param>
        public AddRole(string scaffolding, string successMessage, bool isWebRole)
        {
            this.Scaffolding = scaffolding;
            this.isWebRole = isWebRole;
            this.successMessage = successMessage;
            this.Instances = 1;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            RootPath = RootPath ?? CommonUtilities.GetServiceRootPath(CurrentPath());
            CloudServiceProject service = new CloudServiceProject(RootPath, null);
            RoleInfo roleInfo = null;
            
            if (isWebRole)
            {
                roleInfo = service.AddWebRole(Scaffolding, Name, Instances);
            }
            else
            {
                roleInfo = service.AddWorkerRole(Scaffolding, Name, Instances);
            }

            OnProcessing(roleInfo);

            try
            {
                service.ChangeRolePermissions(roleInfo);
                SafeWriteOutputPSObject(typeof(RoleSettings).FullName, Parameters.RoleName, roleInfo.Name);
                WriteVerbose(string.Format(successMessage, RootPath, roleInfo.Name));
            }
            catch (UnauthorizedAccessException)
            {
                WriteWarning(Resources.AddRoleMessageInsufficientPermissions);
            }
        }

        protected virtual void OnProcessing(RoleInfo roleInfo)
        {
            // Placeholder for work to do after adding the role scaffolding.
        }
    }
}