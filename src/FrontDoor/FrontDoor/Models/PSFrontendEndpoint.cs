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
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{    
    public class PSFrontendEndpoint: PSResource
    {

        public string HostName { get; set; }

        public PSEnabledState? SessionAffinityEnabledState { get; set; }

        public int? SessionAffinityTtlSeconds { get; set; }

        public string WebApplicationFirewallPolicyLink { get; set; }

        public List<PSBackend> Backends { get; set; }

        public PSCustomHttpsProvisioningState? CustomHttpsProvisioningState { get; set; }

        public PSCustomHttpsProvisioningSubstate? CustomHttpsProvisioningSubstate { get; set; }

        public string CertificateSource { get; set; }

        public string ProtocolType { get; set; }

        public string Vault { get; set; }

        public string SecretName { get; set; }

        public string SecretVersion { get; set; }

        public string CertificateType { get; set; }

        public string ResourceState { get; set; }
    }
}
