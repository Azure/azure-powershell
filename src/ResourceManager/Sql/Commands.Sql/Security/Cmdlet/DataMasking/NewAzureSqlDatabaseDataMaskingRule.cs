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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.DataMasking
{
    /// <summary>
    /// Returns a new data masking rule for a specific database
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSqlDatabaseDataMaskingRule")]
    public class NewAzureSqlDatabaseDataMaskingRule : BuildAzureSqlDatabaseDataMaskingRule
    {
        /// <summary>
        /// Gets or sets the masking function
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of the masking function")]
        [ValidateSet(Constants.NoMasking, Constants.Default, Constants.Text, Constants.Number, Constants.SSN, Constants.CCN, Constants.Email, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public override string MaskingFunction { get; set; }  // intentionally overriding the parent's Masking function property, to defined it here as a mandatory property

        protected override IEnumerable<DatabaseDataMaskingRuleModel> GetModel()
        {
            return ModelAdapter.GetDatabaseDataMaskingRule(ResourceGroupName, ServerName, DatabaseName, clientRequestId);
        }

        protected override string ValidateOperation(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            if(rules.Any(r=> r.RuleId == RuleId))
            {
                return string.Format(CultureInfo.InvariantCulture, Resources.NewDataMaskingRuleIdAlreadyExistError, RuleId);
            }
            return null;
        }

        protected override DatabaseDataMaskingRuleModel GetRule(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            DatabaseDataMaskingRuleModel rule = new DatabaseDataMaskingRuleModel();
            rule.ResourceGroupName = ResourceGroupName;
            rule.ServerName = ServerName;
            rule.DatabaseName = DatabaseName;
            rule.RuleId = RuleId;
            return rule;
        }

        protected override IEnumerable<DatabaseDataMaskingRuleModel> UpdateRuleList(IEnumerable<DatabaseDataMaskingRuleModel> rules, DatabaseDataMaskingRuleModel rule)
        {
            List<DatabaseDataMaskingRuleModel> rulesList = rules.ToList();
            rulesList.Add(rule);
            return rulesList;
        }
    }
}
