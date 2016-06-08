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

using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Models
{
    public class TrafficManagerEndpoint
    {
        [DataMember(IsRequired = true)]
        public string DomainName { get; set; }

        [DataMember(IsRequired = true)]
        public string Location { get; set; }

        [DataMember(IsRequired = true)]
        public EndpointType Type { get; set; }

        [DataMember(IsRequired = true)]
        public EndpointStatus Status { get; set; }

        [DataMember(IsRequired = true)]
        public DefinitionEndpointMonitorStatus MonitorStatus { get; set; }

        [DataMember(IsRequired = true)]
        public int? Weight { get; set; }

        [DataMember(IsRequired = true)]
        public int? MinChildEndpoints { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TrafficManagerEndpoint endpoint = obj as TrafficManagerEndpoint;
            if (endpoint == null)
            {
                return false;
            }

            return DomainName == endpoint.DomainName &&
                   Location == endpoint.Location &&
                   Type == endpoint.Type &&
                   Status == endpoint.Status &&
                   MonitorStatus == endpoint.MonitorStatus &&
                   Weight == endpoint.Weight &&
                   MinChildEndpoints == endpoint.MinChildEndpoints;
        }

        public override int GetHashCode()
        {
            int result = DomainName != null ? DomainName.GetHashCode() : 0;
            result = (result * 397) ^ (Location != null ? Location.GetHashCode() : 0);
            result = (result * 397) ^ Type.GetHashCode();
            result = (result * 397) ^ Status.GetHashCode();
            result = (result * 397) ^ MonitorStatus.GetHashCode();
            if (Weight.HasValue)
            {
                result = (result * 397) ^ Weight.GetHashCode();
            }
            if (MinChildEndpoints.HasValue)
            {
                result = (result * 397) ^ MinChildEndpoints.GetHashCode();
            }
            return result;
        }
    }
}