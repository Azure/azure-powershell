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

using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Returns a new data masking rule for a specific database
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseDataMaskingRule", SupportsShouldProcess = true)]
    public class NewAzureSqlDatabaseDataMaskingRule : BuildAzureSqlDatabaseDataMaskingRule
    {
        /// <summary>
        /// Gets or sets the masking function
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of the masking function")]
        [ValidateSet(SecurityConstants.NoMasking, SecurityConstants.Default, SecurityConstants.Text, SecurityConstants.Number, SecurityConstants.SSN, SecurityConstants.CCN, SecurityConstants.Email, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public override string MaskingFunction { get; set; }  // intentionally overriding the parent's Masking function property, to defined it here as a mandatory property

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> GetEntity()
        {
            return ModelAdapter.GetDatabaseDataMaskingRules(ResourceGroupName, ServerName, DatabaseName, clientRequestId);
        }

        /// <summary>
        /// An additional validation to see that no rule with the user provided Id already exists.
        /// </summary>
        /// <param name="rules">The rule the cmdlet operates on</param>
        /// <returns>An error message or null if all is fine</returns>
        protected override string ValidateOperation(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            if (rules.Any(IsModelOfRule))
            {
                return string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.NewDataMaskingRuleIdAlreadyExistError, ColumnName, TableName, SchemaName);
            }
            return null;
        }

        /// <summary>
        /// Returns a new data masking rule model
        /// </summary>
        /// <param name="rules">The database's data masking rules</param>
        /// <returns>A data masking rule object, initialized for the user provided rule identity</returns>
        protected override DatabaseDataMaskingRuleModel GetRule(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            DatabaseDataMaskingRuleModel rule = new DatabaseDataMaskingRuleModel();
            rule.ResourceGroupName = ResourceGroupName;
            rule.ServerName = ServerName;
            rule.DatabaseName = DatabaseName;
            return rule;
        }

        /// <summary>
        /// Adds the data masking rule that this cmdlet operated on to the list of rules of this database
        /// </summary>
        /// <param name="rules">The data masking rules already defined for this database</param>
        /// <param name="rule">The rule that this cmdlet operated on</param>
        /// <returns>The updated list of data masking rules</returns>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> UpdateRuleList(IEnumerable<DatabaseDataMaskingRuleModel> rules, DatabaseDataMaskingRuleModel rule)
        {
            List<DatabaseDataMaskingRuleModel> rulesList = rules.ToList();
            rulesList.Add(rule);
            return rulesList;
        }
    }
}