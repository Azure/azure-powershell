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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network.Models;
using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network
{
    public class GetVirtualNetworkGatewayConnectionContext : ManagementOperationContext
    {
        public string GatewayConnectionName { get; set; }

        public string VirtualNetworkGatewayId { get; set; }

        public string ConnectedEntityId { get; set; }

        public string GatewayConnectionType { get; set; }

        public int RoutingWeight { get; set; }

        public string SharedKey { get; set; }

        public string EnableBgp { get; set; }
    }
}