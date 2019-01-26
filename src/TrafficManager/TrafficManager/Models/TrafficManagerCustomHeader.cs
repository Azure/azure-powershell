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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Management.TrafficManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TrafficManagerCustomHeader
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public EndpointPropertiesCustomHeadersItem ToSDKEndpointPropertiesCustomHeadersItem()
        {
            return new EndpointPropertiesCustomHeadersItem
            {
                Name = this.Name,
                Value = this.Value,
            };
        }

        public static TrafficManagerCustomHeader FromSDKEndpointPropertiesCustomHeadersItem(
            EndpointPropertiesCustomHeadersItem endpointPropertiesCustomHeadersItem)
        {
            return new TrafficManagerCustomHeader
            {
                Name = endpointPropertiesCustomHeadersItem.Name,
                Value = endpointPropertiesCustomHeadersItem.Value,
            };
        }

        public MonitorConfigCustomHeadersItem ToSDKMonitorConfigCustomHeadersItem()
        {
            return new MonitorConfigCustomHeadersItem
            {
                Name = this.Name,
                Value = this.Value,
            };
        }

        public static TrafficManagerCustomHeader FromSDKMonitorConfigCustomHeadersItem(
            MonitorConfigCustomHeadersItem monitorConfigCustomHeadersItem)
        {
            return new TrafficManagerCustomHeader
            {
                Name = monitorConfigCustomHeadersItem.Name,
                Value = monitorConfigCustomHeadersItem.Value,
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" {");
            sb.Append($"Name:{this.Name ?? "null"}, Value:{this.Value ?? "null"}");
            sb.Append("} ");
            return sb.ToString();
        }
    }
}
