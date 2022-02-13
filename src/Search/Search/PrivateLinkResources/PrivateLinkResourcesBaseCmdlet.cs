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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Management.Search.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    public abstract class PrivateLinkResourcesBaseCmdlet : SearchServiceBaseCmdlet
    {
        protected void WritePrivateLinkResourcesList(IEnumerable<PrivateLinkResource> resources)
        {
            var output = new List<PSPrivateLinkResource>();
            if (resources != null)
            {
                output = resources.Select(r => (PSPrivateLinkResource)r).ToList();
            }

            WriteObject(output, true);
        }
    }
}
