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

namespace Microsoft.Azure.Commands.Security.Models.Automations
{
    public class PSSecurityAutomationSource
    {
        /// <summary>
        /// Gets or sets a valid event source type. Possible values include:
        /// 'Assessments', 'AssessmentsSnapshot', 'SubAssessments',
        /// 'SubAssessmentsSnapshot', 'Alerts', 'SecureScores',
        /// 'SecureScoresSnapshot', 'SecureScoreControls',
        /// 'SecureScoreControlsSnapshot', 'RegulatoryComplianceAssessment',
        /// 'RegulatoryComplianceAssessmentSnapshot'
        /// </summary>
        public string EventSource { get; set; }

        /// <summary>
        /// Gets or sets a set of rules which evaluate upon event interception.
        /// A logical disjunction is applied between defined rule sets (logical
        /// 'or').
        /// </summary>
        public IList<PSSecurityAutomationRuleSet> RuleSets { get; set; }
    }
}
