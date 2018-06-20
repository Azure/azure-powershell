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
using System.Linq;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Commands.Dns.Extensions
{
    public static class ListExtensions
    {
        public static IList<SubResource> ToVirtualNetworkResources(this IList<string> virtualNetworkIds)
        {
            return virtualNetworkIds?.Select(vn => new SubResource(vn)).ToList() ?? new List<SubResource>();
        }

        public static IList<string> ToVirtualNetworkIds(this IList<SubResource> virtualNetworks)
        {
            return virtualNetworks?.Select(vn => vn.Id).ToList() ?? new List<string>();
        }
    }
}
