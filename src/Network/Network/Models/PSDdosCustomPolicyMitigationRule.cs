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

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSDdosCustomPolicyMitigationRule : PSChildResource
    {
        public string Type { get; set; }

        public PSDdosCustomPolicyMitigationRuleProperties Properties { get; set; }
    }

    public class PSDdosCustomPolicyMitigationRuleProperties
    {
        public string ProvisioningState { get; set; }

        public string TrafficScope { get; set; }

        public PSDdosCustomPolicyTcpDefaultMitigations TcpDefaultMitigations { get; set; }

        public PSDdosCustomPolicyUdpDefaultMitigations UdpDefaultMitigations { get; set; }

        public List<PSDdosCustomPolicySourcePolicyOverride> SourcePolicyOverrides { get; set; }
    }

    public class PSDdosCustomPolicyTcpDefaultMitigations
    {
        public PSDdosCustomPolicyTcpPerSourceRateLimitPolicy PerSourceRateLimiting { get; set; }

        public PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy PerSourceConnectionRateLimiting { get; set; }
    }

    public class PSDdosCustomPolicyUdpDefaultMitigations
    {
        public PSDdosCustomPolicyUdpPerSourceRateLimitPolicy PerSourceRateLimiting { get; set; }
    }

    public class PSDdosCustomPolicyTcpPerSourceRateLimitPolicy
    {
        public int PacketsPerSecond { get; set; }
    }

    public class PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy
    {
        public int ConnectionsPerSecond { get; set; }
    }

    public class PSDdosCustomPolicyUdpPerSourceRateLimitPolicy
    {
        public int PacketsPerSecond { get; set; }
    }
}
