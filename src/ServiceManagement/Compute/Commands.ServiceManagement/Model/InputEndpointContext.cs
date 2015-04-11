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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class InputEndpointContext
    {
        public string LBSetName { get; set; }

        public int LocalPort { get; set; }

        public string Name { get; set; }

        public int? Port { get; set; }

        public string Protocol { get; set; }

        public string Vip { get; set; }

        public string ProbePath { get; set; }

        public int ProbePort { get; set; }

        public string ProbeProtocol { get; set; }

        public int? ProbeIntervalInSeconds { get; set; }

        public int? ProbeTimeoutInSeconds { get; set; }

        public bool? EnableDirectServerReturn { get; set; }

        public NetworkAclObject Acl { get; set; }

        public string InternalLoadBalancerName { get; set; }

        public int? IdleTimeoutInMinutes { get; set; }

        public string LoadBalancerDistribution { get; set; }

        public string VirtualIPName { get; set; }
    }
}