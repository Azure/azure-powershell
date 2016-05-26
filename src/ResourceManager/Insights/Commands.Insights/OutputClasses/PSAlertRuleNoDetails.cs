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

using Microsoft.Azure.Management.Insights.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the RuleGetResponse
    /// </summary>
    public class PSAlertRuleNoDetails : PSManagementItemDescriptor
    {
        /// <summary>
        /// Gets or sets the Properties specification
        /// </summary>
        public Rule Properties { get; set; }

        /// <summary>
        /// Gets or sets the Tags of the rule
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSAlertRule class.
        /// </summary>
        /// <param name="ruleSpec"></param>
        public PSAlertRuleNoDetails(RuleGetResponse ruleSpec)
        {
            this.Id = ruleSpec.Id;
            this.Location = ruleSpec.Location;
            this.Name = ruleSpec.Name;
            this.Properties = ruleSpec.Properties;
            this.Tags = ruleSpec.Tags;
        }

        /// <summary>
        /// Initializes a new instance of the PSAlertRule class.
        /// </summary>
        /// <param name="ruleSpec"></param>
        public PSAlertRuleNoDetails(RuleResource ruleSpec)
        {
            this.Id = ruleSpec.Id;
            this.Location = ruleSpec.Location;
            this.Name = ruleSpec.Name;
            this.Properties = ruleSpec.Properties;
            this.Tags = ruleSpec.Tags;
        }
    }
}
