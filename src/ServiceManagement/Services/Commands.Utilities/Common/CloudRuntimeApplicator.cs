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

using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    /// <summary>
    /// Used to delay application of runtime until the user has acknowledged she wants the change
    /// </summary>
    public class CloudRuntimeApplicator
    {
        CloudRuntime Runtime { get; set; }

        CloudRuntimePackage Package { get; set; }

        WebRole WebRole { get; set; }

        WorkerRole WorkerRole { get; set; }

        private CloudRuntimeApplicator()
        {
        }

        /// <summary>
        /// Create a cloud runtime application, essentialy this is a tuple of runtime X package X role
        /// </summary>
        /// <param name="cloudRuntime">The runtime in the tuple</param>
        /// <param name="cloudRuntimePackage">The package in the tuple</param>
        /// <param name="role">The role to apply the package to</param>
        /// <returns>The tuple, use the apply method to apply the runtime as specified</returns>
        public static CloudRuntimeApplicator CreateCloudRuntimeApplicator(CloudRuntime cloudRuntime, CloudRuntimePackage cloudRuntimePackage, WebRole role)
        {
            CloudRuntimeApplicator applicator = new CloudRuntimeApplicator
            {
                Runtime = cloudRuntime,
                Package = cloudRuntimePackage,
                WebRole = role
            };

            return applicator;
        }

        /// <summary>
        /// Create a cloud runtime application, essentialy this is a tuple of runtime X package X role
        /// </summary>
        /// <param name="cloudRuntime">The runtime in the tuple</param>
        /// <param name="cloudRuntimePackage">The package in the tuple</param>
        /// <param name="role">The role to apply the package to</param>
        /// <returns>The tuple, use the apply method to apply the runtime as specified</returns>
        public static CloudRuntimeApplicator CreateCloudRuntimeApplicator(CloudRuntime cloudRuntime, CloudRuntimePackage cloudRuntimePackage, WorkerRole role)
        {
            CloudRuntimeApplicator applicator = new CloudRuntimeApplicator
            {
                Runtime = cloudRuntime,
                Package = cloudRuntimePackage,
                WorkerRole = role
            };

            return applicator;
        }

        /// <summary>
        /// Apply the cloud runtime to the package as specified when creating the applicator
        /// </summary>
        public void Apply()
        {
            if (this.WorkerRole != null)
            {
                this.Runtime.ApplyRuntime(this.Package, this.WorkerRole);
            }
            else if (this.WebRole != null)
            {
                this.Runtime.ApplyRuntime(this.Package, this.WebRole);
            }
        }
    }
}
