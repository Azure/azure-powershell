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
    public class PSFrontDoor: PSTrackedResource
    {
        public string FriendlyName { get; set; }

        public List<PSRoutingRule> RoutingRules { get; set; }

        public List<PSBackendPool> BackendPools { get; set; }

        public PSEnforceCertificateNameCheck? EnforceCertificateNameCheck { get; set; }

        public List<PSHealthProbeSetting> HealthProbeSettings { get; set; }

        public List<PSLoadBalancingSetting> LoadBalancingSettings { get; set; }
        
        public List<PSFrontendEndpoint> FrontendEndpoints { get; set; }

        public PSEnabledState? EnabledState { get; set; }

        public string ResourceState { get; set; }

        public string ProvisioningState { get; set; }

        public string Cname { get; set; }
    }
}
