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
    public class PSIdentity
    {
        /// <summary>
        /// Gets the principal ID of resource identity.
        /// </summary>     
        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets the tenant ID of resource.
        /// </summary>        
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the identity type. Possible values include: 'None',
        /// 'SystemAssigned', 'UserAssigned', 'SystemAssigned,UserAssigned'
        /// </summary>        
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the set of
        /// User Assigned identities that will be used with this storage
        /// account. The key is the ARM resource identifier of the identity.
        /// Only 1 User Assigned identity is permitted here.
        /// </summary>        
        public string UserAssignedIdentity { get; set; }
    }
}
