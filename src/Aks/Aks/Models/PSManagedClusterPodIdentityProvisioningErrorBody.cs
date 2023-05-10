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

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// An error response from the pod identity provisioning.
    /// </summary>
    public partial class PSManagedClusterPodIdentityProvisioningErrorBody
    {
        /// <summary>
        /// Gets or sets an identifier for the error. Codes are invariant and are intended
        /// to be consumed programmatically.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a message describing the error, intended to be suitable for display
        /// in a user interface.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the target of the particular error. For example, the name of the
        /// property in error.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets a list of additional details about the error.
        /// </summary>
        public IList<PSManagedClusterPodIdentityProvisioningErrorBody> Details { get; set; }
    }
}
