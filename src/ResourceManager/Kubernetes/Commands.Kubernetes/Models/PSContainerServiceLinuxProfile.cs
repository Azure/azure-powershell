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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Kubernetes.Models
{
    /// <summary>
    /// Profile for Linux VMs in the container service cluster.
    /// </summary>
    public partial class PSContainerServiceLinuxProfile
    {
        /// <summary>
        /// Initializes a new instance of the PSContainerServiceLinuxProfile
        /// class.
        /// </summary>
        public PSContainerServiceLinuxProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSContainerServiceLinuxProfile
        /// class.
        /// </summary>
        /// <param name="adminUsername">The administrator username to use for
        /// Linux VMs.</param>
        /// <param name="ssh">SSH configuration for Linux-based VMs running on
        /// Azure.</param>
        public PSContainerServiceLinuxProfile(string adminUsername, PSContainerServiceSshConfiguration ssh)
        {
            AdminUsername = adminUsername;
            Ssh = ssh;
        }

        /// <summary>
        /// Gets or sets the administrator username to use for Linux VMs.
        /// </summary>
        public string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets SSH configuration for Linux-based VMs running on
        /// Azure.
        /// </summary>
        public PSContainerServiceSshConfiguration Ssh { get; set; }
    }
}