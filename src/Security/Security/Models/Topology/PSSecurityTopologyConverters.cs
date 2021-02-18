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
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.Topology
{
    public static class PSSecurityTopologyConverters
    {
        public static PSSecurityTopology ConvertToPSType(this TopologyResource value)
        {
            return new PSSecurityTopology()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                CalculatedDateTime = value.CalculatedDateTime,
                TopologyResources = value.TopologyResources.ConvertToPSType()
            };
        }

        public static List<PSSecurityTopology> ConvertToPSType(this IEnumerable<TopologyResource> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

        public static PSSecurityTopologySingleResource ConvertToPSType(this TopologySingleResource value)
        {
            return new PSSecurityTopologySingleResource()
            {
                ResourceId = value.ResourceId,
                Severity = value.Severity,
                RecommendationsExist = value.RecommendationsExist,
                NetworkZones = value.NetworkZones,
                TopologyScore = value.TopologyScore,
                Location = value.Location,
                Parents = value.Parents?.ConvertToPSType(),
                Children = value.Children?.ConvertToPSType()
            };
        }

        public static List<PSSecurityTopologySingleResource> ConvertToPSType(this IEnumerable<TopologySingleResource> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

        public static PSsecurityTopologySingleResourceParent ConvertToPSType(this TopologySingleResourceParent value)
        {
            return new PSsecurityTopologySingleResourceParent()
            {
                ResourceId = value.ResourceId
            };
        }

        public static List<PSsecurityTopologySingleResourceParent> ConvertToPSType(this IEnumerable<TopologySingleResourceParent> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

        public static PSSecurityTopologySingleResourceChild ConvertToPSType(this TopologySingleResourceChild value)
        {
            return new PSSecurityTopologySingleResourceChild()
            {
                ResourceId = value.ResourceId
            };
        }

        public static List<PSSecurityTopologySingleResourceChild> ConvertToPSType(this IEnumerable<TopologySingleResourceChild> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }
    }
}
