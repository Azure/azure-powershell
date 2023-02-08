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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSEncryptionIdentity
    {
        /// <summary>
        /// Gets the principal ID (object ID) of the identity used to
        /// authenticate with key vault. Read-only.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource identifier of the user assigned
        /// identity used to authenticate with key vault. Applicable if
        /// identity.type has 'UserAssigned'. It should match key of
        /// identity.userAssignedIdentities.
        /// </summary>        
        public string UserAssignedIdentity { get; set; }
    }
}
