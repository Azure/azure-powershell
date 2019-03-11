﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.Azure.Management.TrafficManager.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrafficManagerEndpoint
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProfileName { get; set; }

        public string ResourceGroupName { get; set; }

        public string Type { get; set; }

        public string TargetResourceId { get; set; }

        public string Target { get; set; }

        public string EndpointStatus { get; set; }

        public uint? Weight { get; set; }

        public uint? Priority { get; set; }

        public string Location { get; set; }

        public string EndpointMonitorStatus { get; set; }

        public uint? MinChildEndpoints { get; set; }

        public List<string> GeoMapping { get; set; }

        public List<TrafficManagerIpAddressRange> SubnetMapping { get; set; }

        public List<TrafficManagerCustomHeader> CustomHeaders { get; set; }

        public Endpoint ToSDKEndpoint()
        {
            Endpoint endpoint = new Endpoint(this.Id, this.Name, TrafficManagerEndpoint.ToFullEndpointType(this.Type));
            endpoint.EndpointLocation = this.Location;
            endpoint.EndpointStatus = this.EndpointStatus;
            endpoint.GeoMapping = this.GeoMapping;
            endpoint.MinChildEndpoints = this.MinChildEndpoints;
            endpoint.Priority = this.Priority;
            endpoint.Target = this.Target;
            endpoint.TargetResourceId = this.TargetResourceId;
            endpoint.Weight = this.Weight;
            endpoint.Subnets = this.SubnetMapping?.Select(ipAddressRange => ipAddressRange.ToSDKSubnetMapping()).ToList();
            endpoint.CustomHeaders = this.CustomHeaders?.Select(customHeader => customHeader.ToSDKEndpointPropertiesCustomHeadersItem()).ToList();
            return endpoint;
        }

        public Endpoint ToSDKEndpointForPatch()
        {
            return new Endpoint(this.Id, this.Name, TrafficManagerEndpoint.ToFullEndpointType(this.Type));
        }

        public static string ToFullEndpointType(string endpointType)
        {
            return
                !endpointType.StartsWith(Constants.ProfileType, StringComparison.OrdinalIgnoreCase) 
                    ? string.Format("{0}/{1}", Constants.ProfileType, endpointType) 
                    : endpointType;
        }

        public static string ToShortEndpointType(string endpointType)
        {
            string prefix = Constants.ProfileType + "/";
            return 
                endpointType.StartsWith(Constants.ProfileType + "/", StringComparison.OrdinalIgnoreCase) ?
                    endpointType.Substring(startIndex: prefix.Length) :
                    endpointType;
        }
    }
}
