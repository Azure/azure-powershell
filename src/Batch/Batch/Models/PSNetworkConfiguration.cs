// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSNetworkConfiguration
    {
        internal NetworkConfiguration toMgmtNetworkConfiguration()
        {
            return new NetworkConfiguration()
            {
                SubnetId = this.SubnetId,
                PublicIPAddressConfiguration = (this.PublicIPAddressConfiguration != null) ? this.PublicIPAddressConfiguration.toMgmtPublicIPAddressConfiguration() : null,
                DynamicVnetAssignmentScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(this.DynamicVNetAssignmentScope),
                EndpointConfiguration = this.EndpointConfiguration?.toMgmtPoolEndpointConfiguration(),
                EnableAcceleratedNetworking = this.EnableAcceleratedNetworking
            };
        }

        internal static PSNetworkConfiguration fromMgmtNetworkConfiguration(NetworkConfiguration networkConfiguration)
        {
            if (networkConfiguration == null)
            {
                return null;
            }
            return new PSNetworkConfiguration()
            {
                SubnetId = networkConfiguration.SubnetId,
                PublicIPAddressConfiguration = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(networkConfiguration.PublicIPAddressConfiguration),
                DynamicVNetAssignmentScope = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(networkConfiguration.DynamicVnetAssignmentScope),
                EndpointConfiguration = PSPoolEndpointConfiguration.FromMgmtPoolEndpointConfiguration(networkConfiguration.EndpointConfiguration),
                EnableAcceleratedNetworking = networkConfiguration.EnableAcceleratedNetworking
            };
        }
    }
}
