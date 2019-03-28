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

namespace Microsoft.Azure.Commands.MixedReality.SpatialAnchorsAccount
{
    using Management.MixedReality.Models;

    public sealed class PSSpatialAnchorsAccount : SpatialAnchorsAccount
    {
        private ResourceId resourceId;

        public PSSpatialAnchorsAccount(SpatialAnchorsAccount another) : 
            base(
                location: another.Location,
                id: another.Id,
                name: another.Name,
                type: another.Type,
                tags: new Dictionary<string, string>(another.Tags),
                accountId: another.AccountId,
                accountDomain: another.AccountDomain)
        {
            resourceId = new ResourceId(this.Id);
        }

        public string ResourceGroupName
        {
            get
            {
                return resourceId.ResourceGroupName;
            }
        }
    }
}
