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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSIdentity
    {
        public PSIdentity(Identity identity)
        {
            this.Type = identity.Type;
            this.IdentityIds = identity.IdentityIds;
        }

        /// <summary>
        /// Gets or sets the identity type.
        /// </summary>
        public string Type
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the list of identities.
		/// </summary>
		public IList<string> IdentityIds
		{
			get;
			set;
		}

        internal Identity ToSdkType()
        {
            return new Identity(
                type: this.Type, 
                identityIds: this.IdentityIds);
        }
    }
}
