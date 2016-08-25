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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    /// <summary>
    /// Base class for describing roles that we will create.
    /// </summary>
    public abstract class RoleInfo
    {
        public int InstanceCount { get; private set; }
        public string Name { get; private set; }

        public RoleInfo(string name, int instanceCount)
        {
            Name = name;
            InstanceCount = instanceCount;
        }

        internal virtual void AddRoleToDefinition(ServiceDefinition serviceDefinition, object template)
        {
            Validate.ValidateNullArgument(template, string.Format(Resources.NullRoleSettingsMessage, "service definition"));
            Validate.ValidateNullArgument(serviceDefinition, Resources.NullServiceDefinitionMessage);
        }

        /// <summary>
        /// Checks for equality between provided object and this object
        /// </summary>
        /// <param name="obj">This object can be type of RoleInfo, WebRoleInfo, WorkerRoleInfo, WebRole or WorkerRole</param>
        /// <returns>True if they are equals, false if not</returns>
        public override bool Equals(object obj)
        {
            Validate.ValidateNullArgument(obj, string.Empty);
            bool equals;
            RoleInfo roleInfo = obj as RoleInfo;
            WebRole webRole = obj as WebRole;
            WorkerRole workerRole = obj as WorkerRole;
            RoleSettings role = obj as RoleSettings;

            if (roleInfo != null)
            {
                equals = this.InstanceCount.Equals(roleInfo.InstanceCount) &&
                    this.Name.Equals(roleInfo.Name);
            }
            else if (webRole != null)
            {
                equals = this.Name.Equals(webRole.name);
            }
            else if (workerRole != null)
            {
                equals = this.Name.Equals(workerRole.name);
            }
            else if (role != null)
            {
                equals = this.Name.Equals(role.name) &&
                    this.InstanceCount.Equals(role.Instances.count);
            }
            else
            {
                equals = false;
            }

            return equals;
        }

        public override int GetHashCode()
        {
            return
                InstanceCount.GetHashCode() ^
                Name.GetHashCode();
        }
    }
}