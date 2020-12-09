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

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening
{
    public class PSSecurityAdaptiveNetworkHardeningsProperties
    {
        /// <summary>
        /// Gets the UTC time on which the rules were calculated.
        /// </summary>
        public DateTime? RulesCalculationTime { get; set; }

        /// <summary>
        /// Gets the security rules which are recommended to be effective on the VM.
        /// </summary>
        public IList<PSSecurityAdaptiveNetworkHardeningsRule> Rules { get; set; }

        /// <summary>
        /// Gets the Network Security Groups effective on the network interfaces of the protected resource.
        /// </summary>
        public IList<PSSecurityAdaptiveNetworkHardeningsEffectiveNetworkSecurityGroups> EffectiveNetworkSecurityGroups { get; set; }
    }
}
