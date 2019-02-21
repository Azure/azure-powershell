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
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// SSH configuration for Linux-based VMs running on Azure.
    /// </summary>
    public partial class PSContainerServiceSshConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the PSContainerServiceSshConfiguration
        /// class.
        /// </summary>
        public PSContainerServiceSshConfiguration(){}

        /// <summary>
        /// Initializes a new instance of the PSContainerServiceSshConfiguration
        /// class.
        /// </summary>
        /// <param name="publicKeys">The list of SSH public keys used to
        /// authenticate with Linux-based VMs. Only expect one key
        /// specified.</param>
        public PSContainerServiceSshConfiguration(IList<PSContainerServiceSshPublicKey> publicKeys)
        {
            PublicKeys = publicKeys;
        }

        /// <summary>
        /// Gets or sets the list of SSH public keys used to authenticate with
        /// Linux-based VMs. Only expect one key specified.
        /// </summary>
        public IList<PSContainerServiceSshPublicKey> PublicKeys { get; set; }
    }
}