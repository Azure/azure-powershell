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

<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{    
    public class PSFrontDoor: PSTrackedResource
    {
        public string FriendlyName { get; set; }

=======
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{
    public class PSFrontDoor : PSTrackedResource
    {
        public string FriendlyName { get; set; }

        public string FrontDoorId { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public List<PSRoutingRule> RoutingRules { get; set; }

        public List<PSBackendPool> BackendPools { get; set; }

<<<<<<< HEAD
=======
        public PSBackendPoolsSetting BackendPoolsSetting { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public PSEnforceCertificateNameCheck? EnforceCertificateNameCheck { get; set; }

        public List<PSHealthProbeSetting> HealthProbeSettings { get; set; }

        public List<PSLoadBalancingSetting> LoadBalancingSettings { get; set; }
<<<<<<< HEAD
        
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public List<PSFrontendEndpoint> FrontendEndpoints { get; set; }

        public PSEnabledState? EnabledState { get; set; }

        public string ResourceState { get; set; }

        public string ProvisioningState { get; set; }

        public string Cname { get; set; }
<<<<<<< HEAD
=======

        public List<PSRulesEngine> RulesEngine { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
