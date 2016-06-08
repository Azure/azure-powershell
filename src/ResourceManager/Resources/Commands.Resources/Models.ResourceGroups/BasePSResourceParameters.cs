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

using System.Collections;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public class BasePSResourceParameters
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string ResourceType { get; set; }

        public string ParentResource { get; set; }

        public string ApiVersion { get; set; }

        public Hashtable[] Tag { get; set; }

        public ResourceIdentity ToResourceIdentity()
        {
            return new ResourceIdentifier()
            {
                ParentResource = ParentResource,
                ResourceGroupName = ResourceGroupName,
                ResourceName = Name,
                ResourceType = ResourceType
            }.ToResourceIdentity(ApiVersion);
        }
    }
}