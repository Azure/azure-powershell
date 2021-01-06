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

namespace Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules
{
    public class PSSentinelMicrosoftSecurityIncidentCreationRule : PSSentinelAlertRule
    {

        public string AlertRuleTemplateName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public DateTime? LastModifiedUtc { get; set; }

        public string ProductFilter { get; set; }

        public IList<string> DisplayNamesFilter { get; set; }

        public IList<string> DisplayNamesExcludeFilter { get; set; }

        public IList<string> SeveritiesFilter { get; set; }

    }
}
