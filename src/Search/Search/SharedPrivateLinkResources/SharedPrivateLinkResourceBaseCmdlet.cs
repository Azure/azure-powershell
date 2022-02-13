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
    public abstract class SharedPrivateLinkResourceBaseCmdlet : SearchServiceBaseCmdlet
    {
        protected const string SharedPrivateLinkResourceNameHelpMessage = "Azure Cognitive Search Shared private link resource";
        protected const string PrivateLinkResourceIdHelpMessage = "Shared private link target resource id";
        protected const string GroupIdHelpMessage = "Shared private link resource group id";
        protected const string RequestMessageHelpMessage = "Shared private link resource request message";
        protected const string ResourceRegionHelpMessage = "(Optional) Shared private link resource region";
        protected const string SharedPrivateLinkResourceIdHelpMessage = "Shared private link resource id";
        protected const string SharedPrivateLinkInputObjectHelpMessage = "Shared private link resource input object";

        protected void WriteSharedPrivateLinkResource(SharedPrivateLinkResource resource)
        {
            if (resource != null)
            {
                WriteObject((PSSharedPrivateLinkResource)resource);
            }
        }

        protected void WriteSharedPrivateLinkResourceList(IEnumerable<SharedPrivateLinkResource> resources)
        {
            var output = new List<PSSharedPrivateLinkResource>();
            if (resources != null)
            {
                output = resources.Select(pe => (PSSharedPrivateLinkResource)pe).ToList();
            }

            WriteObject(output, true);
        }
    }
}
