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

namespace Microsoft.Azure.Commands.FrontDoor.Models
{
    public class PSCustomRule
    {
        public string RuleType { get; set; }

        public string Action { get; set; }

        public List<PSMatchCondition> MatchConditions { get; set; }

        public int Priority { get; set; }

        public int? RateLimitDurationInMinutes { get; set; }

        public int? RateLimitThreshold { get; set; }

        public string Name { get; set; }

        public string EnabledState { get; set; }

        public PSFrontDoorWafCustomRuleGroupByVariable[] CustomRule { get; set;}
    }
}
