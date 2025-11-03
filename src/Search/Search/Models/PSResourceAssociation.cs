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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSResourceAssociation
    {
        [Ps1Xml(Label = "Resource association name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Resource association access mode", Target = ViewControl.List, Position = 1)]
        public string AccessMode { get; private set; }

        public static explicit operator PSResourceAssociation(ResourceAssociation v)
        {
            return new PSResourceAssociation()
            {
                Name = v.Name,
                AccessMode = v.AccessMode,
            };
        }

        public static explicit operator ResourceAssociation(PSResourceAssociation v)
        {
            return new ResourceAssociation()
            {
                Name = v.Name,
                AccessMode = v.AccessMode,
            };
        }
    }
}
