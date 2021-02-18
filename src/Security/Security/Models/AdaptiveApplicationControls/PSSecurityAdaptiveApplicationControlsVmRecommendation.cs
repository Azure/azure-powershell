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

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveApplicationControls
{
    public class PSSecurityAdaptiveApplicationControlsVmRecommendation
    {
        /// <summary>
        /// The configuration status of the VM/server group or machine or rule on the machine.
        /// </summary>
        public string ConfigurationStatus { get; set; }

        /// <summary>
        /// The full azure resource id of the machine.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The recommendation action of the VM/server or rule.
        /// </summary>
        public string RecommendationAction { get; set; }

        /// <summary>
        /// The VM/server supportability of Enforce feature.
        /// </summary>
        public string EnforcementSupport { get; set; }
    }
}
