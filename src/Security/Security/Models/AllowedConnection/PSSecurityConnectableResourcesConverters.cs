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

namespace Microsoft.Azure.Commands.Security.Models.AllowedConnection
{
    public static class PSSecurityPSSecurityAllowedConnectionConverters
    {
        public static PSSecurityAllowedConnection ConvertToPSType(this AllowedConnectionsResource value)
        {
            return new PSSecurityAllowedConnection()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                CalculatedDateTime = value.CalculatedDateTime,
                ConnectableResources = value.ConnectableResources.ConvertToPSType()
            };
        }

        public static List<PSSecurityAllowedConnection> ConvertToPSType(this IEnumerable<AllowedConnectionsResource> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

        public static PSSecurityConnectableResources ConvertToPSType(this ConnectableResource value)
        {
            return new PSSecurityConnectableResources()
            {
                Id = value.Id,
                InboundConnectedResources = value.InboundConnectedResources?.ConvertToPSType(),
                OutboundConnectedResources = value.OutboundConnectedResources?.ConvertToPSType()
            };
        }

        public static List<PSSecurityConnectableResources> ConvertToPSType(this IEnumerable<ConnectableResource> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

        public static PSSecurityConnectedResource ConvertToPSType(this ConnectedResource value)
        {
            return new PSSecurityConnectedResource()
            {
                ConnectedResourceId = value.ConnectedResourceId,
                TcpPorts = value.TcpPorts,
                UdpPorts = value.UdpPorts
            };
        }

        public static List<PSSecurityConnectedResource> ConvertToPSType(this IEnumerable<ConnectedResource> value)
        {
            return value.Select(tor => tor.ConvertToPSType()).ToList();
        }

    }
}
