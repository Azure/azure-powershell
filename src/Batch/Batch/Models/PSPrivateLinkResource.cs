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

using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSPrivateLinkResource
    {
        public string Id { get; }

        public string Name { get; }

        public string GroupId { get; }

        public IList<string> RequiredMembers { get; } 

        public IList<string> RequiredZoneNames { get; }

        public PSPrivateLinkResource(string id, string name, string groupId, IList<string> requiredMembers = null, IList<string> requiredZoneNames = null)
        {
            Id = id;
            Name = name;
            GroupId = groupId;
            RequiredMembers = requiredMembers;
            RequiredZoneNames = requiredZoneNames;
        }

        internal static PSPrivateLinkResource CreateFromPrivateLinkResource(PrivateLinkResource privateLinkResource)
        {
            if (privateLinkResource == null)
            {
                return null;
            }

            return new PSPrivateLinkResource(
                privateLinkResource.Id,
                privateLinkResource.Name,
                privateLinkResource.GroupId,
                privateLinkResource.RequiredMembers,
                privateLinkResource.RequiredZoneNames);
        }
    }
}
