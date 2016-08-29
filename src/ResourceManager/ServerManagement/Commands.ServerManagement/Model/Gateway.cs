// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Model
{
    using Management.ServerManagement.Models;
    using Utility;

    public class Gateway : GatewayResource
    {
        public string ResourceGroupName { get; set; }

        protected Gateway(GatewayResource resource)
        {
            // copy data from API object.
            resource.CloneInto(this);

            ResourceGroupName = Id.ExtractFieldFromResourceId("resourcegroups");
        }

        public static Gateway Create(GatewayResource resource)
        {
            return resource == null ? null : new Gateway(resource);
        }
    }
}