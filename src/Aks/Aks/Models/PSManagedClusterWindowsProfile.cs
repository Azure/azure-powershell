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

using Microsoft.Azure.Management.ContainerService.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Profile for Windows VMs in the container service cluster.
    /// </summary>
    public partial class PSManagedClusterWindowsProfile
    {
        /// <summary>
        /// Gets or sets the administrator username to use for Windows VMs.
        /// </summary>
        public string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the administrator password to use for Windows VMs.
        /// </summary>
        public string AdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the license type to use for Windows VMs. See [Azure
        /// Hybrid User
        /// Benefits](https://azure.microsoft.com/pricing/hybrid-benefit/faq/)
        /// for more details. Possible values include: 'None', 'Windows_Server'
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets whether to enable CSI proxy.
        /// </summary>
        /// <remarks>
        /// For more details on CSI proxy, see the [CSI proxy GitHub
        /// repo](https://github.com/kubernetes-csi/csi-proxy).
        /// </remarks>
        public bool? EnableCSIProxy { get; set; }

        /// <summary>
        /// Gets or sets the Windows gMSA Profile in the Managed Cluster.
        /// </summary>
        public WindowsGmsaProfile GmsaProfile { get; set; }

    }
}
