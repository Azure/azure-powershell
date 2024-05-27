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


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualApplianceNetworkProfile
    {
        public List<PSVirtualApplianceNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get; set; }
    }

    public class PSVirtualApplianceNetworkInterfaceConfiguration
    {
        public string NicType { get; set; }
        public PSVirtualApplianceNetworkInterfaceConfigurationProperties Properties { get; set; }
    }

    public class PSVirtualApplianceNetworkInterfaceConfigurationProperties
    {
        public List<PSVirtualApplianceIpConfiguration> IpConfigurations { get; set; }
    }

    public class PSVirtualApplianceIpConfiguration
    {
        public string Name { get; set; }
        public PSVirtualApplianceIpConfigurationProperties Properties { get; set; }
    }

    public class PSVirtualApplianceIpConfigurationProperties
    {
        public bool Primary { get; set; }
    }
}