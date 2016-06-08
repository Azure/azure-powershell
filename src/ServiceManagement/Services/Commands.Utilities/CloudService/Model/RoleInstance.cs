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
using System.Net;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{
    public class RoleInstance
    {
        public RoleInstance()
        {
            InstanceEndpoints = new List<InstanceEndpoint>();
        }

        public RoleInstance(Management.Compute.Models.RoleInstance roleInstance)
            : this()
        {
            RoleName = roleInstance.RoleName;
            InstanceName = roleInstance.InstanceName;
            InstanceStatus = roleInstance.InstanceStatus;
            InstanceUpgradeDomain = roleInstance.InstanceUpgradeDomain.ToString();
            InstanceFaultDomain = roleInstance.InstanceFaultDomain.ToString();
            InstanceSize = roleInstance.InstanceSize.ToString();
            InstanceStateDetails = roleInstance.InstanceStateDetails;
            InstanceErrorCode = roleInstance.InstanceErrorCode;
            IPAddress = IPAddress.Parse(roleInstance.IPAddress);
            InstanceEndpoints = new List<InstanceEndpoint>(roleInstance.InstanceEndpoints.Select(ep => new InstanceEndpoint(ep)));
            PowerState = roleInstance.PowerState.ToString();
            HostName = roleInstance.HostName;
            RemoteAccessCertificateThumbprint = roleInstance.RemoteAccessCertificateThumbprint;
        }

        public string RoleName { get; set; }
        public string InstanceName { get; set; }
        public string InstanceStatus { get; set; }
        public string InstanceUpgradeDomain { get; set; }
        public string InstanceFaultDomain { get; set; }
        public string InstanceSize { get; set; }
        public string InstanceStateDetails { get; set; }
        public string InstanceErrorCode { get; set; }
        public IPAddress IPAddress { get; set; }
        public IList<InstanceEndpoint> InstanceEndpoints { get; private set; }
        public string PowerState { get; set; }
        public string HostName { get; set; }
        public string RemoteAccessCertificateThumbprint { get; set; }
    }
}
