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

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the RuleCondition, but in the old namespace
    /// </summary>
    public class RuleCondition : Monitor.Models.RuleCondition
    {
        /// <summary>
        /// Gets or sets the DataSource of the Rule Condition
        /// </summary>
        public new RuleDataSource DataSource { get; set; }

        /// <summary>
        /// Initializes a new instance of the RuleCondition class.
        /// </summary>
        public RuleCondition()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the RuleCondition class.
        /// </summary>
        /// <param name="dataSource">The RuleDatasource of the RuleCOndition object</param>
        public RuleCondition(Monitor.Models.RuleDataSource dataSource)
            : base(dataSource: dataSource)
        {
            this.DataSource = dataSource == null ? null : new RuleDataSource(ruleDataSource: dataSource);
        }
    }
}
