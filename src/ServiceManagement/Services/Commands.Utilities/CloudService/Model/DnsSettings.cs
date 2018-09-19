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
using System.Net;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{
    public class DnsSettings
    {
        public DnsSettings()
        {
            DnsServers = new Dictionary<string, IPAddress>();
        }

        public DnsSettings(Management.Compute.Models.DnsSettings settings)
            : this()
        {
            foreach (var server in settings.DnsServers)
            {
                DnsServers[server.Name] = IPAddress.Parse(server.Address);
            }
        }

        public IDictionary<string, IPAddress> DnsServers { get; private set; }
    }
}
