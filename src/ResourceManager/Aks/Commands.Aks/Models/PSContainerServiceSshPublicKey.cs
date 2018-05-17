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
using Microsoft.Azure.Commands.Aks.Generated.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Aks.Models
{

    /// <summary>
    /// Contains information about SSH certificate public key data.
    /// </summary>
    public partial class PSContainerServiceSshPublicKey
    {
        /// <summary>
        /// Initializes a new instance of the PSContainerServiceSshPublicKey
        /// class.
        /// </summary>
        public PSContainerServiceSshPublicKey()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSContainerServiceSshPublicKey
        /// class.
        /// </summary>
        /// <param name="keyData">Certificate public key used to authenticate
        /// with VMs through SSH. The certificate must be in PEM format with or
        /// without headers.</param>
        public PSContainerServiceSshPublicKey(string keyData)
        {
            KeyData = keyData;
        }

        /// <summary>
        /// Gets or sets certificate public key used to authenticate with VMs
        /// through SSH. The certificate must be in PEM format with or without
        /// headers.
        /// </summary>
        public string KeyData { get; set; }
    }
}