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

using Microsoft.Azure.Commands.Sql.Security.Model;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Globalization;
using Microsoft.Azure.Commands.Sql.Security.Services;
using System;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.DataMasking
{
    /// <summary>
    /// Base for creation and update of data masking rule.
    /// </summary>
    
    public abstract class BuildAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {

        /// <summary>
        /// The name of the parameter set for data masking rule that specifies table and column names
        /// </summary>
        internal const string ByTableAndColumn = "ByTableAndColumn";

        /// <summary>
        /// The name of the parameter set for data masking rule that specifies alias
        /// </summary>
        internal const string ByAlias = "ByAlias";

        /// <summary>
        /// Gets or sets the table name
        /// </summary>
        [Parameter(ParameterSetName = ByTableAndColumn, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The table name.")]
        [ValidateNotNullOrEmpty]
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        [Parameter(ParameterSetName = ByTableAndColumn, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The column name.")]
        [ValidateNotNullOrEmpty]
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the alias name
        /// </summary>
        [Parameter(ParameterSetName = ByAlias, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alias name.")]
        [ValidateNotNullOrEmpty]
        public string AliasName { get; set; }

        /// <summary>
        /// Gets or sets the masking function - the definition of this property as a cmdlet parameter is done in the subclasses
        /// </summary>
        public virtual string MaskingFunction { get; set; }

        /// <summary>
        /// Gets or sets the prefix size when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The prefix size when using the text masking function.")]
        [ValidateNotNullOrEmpty]
        public uint? PrefixSize { get; set; }

        /// <summary>
        /// Gets or sets the replacement string when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The replacement string when using the text masking function.")]
        [ValidateNotNullOrEmpty]
        public string ReplacementString { get; set; }

        /// <summary>
        /// Gets or sets the suffix size when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The suffix size string when using the text masking function.")]
        [ValidateNotNullOrEmpty]
        public uint? SuffixSize { get; set; }

        /// <summary>
        /// Gets or sets the NumberFrom property, which is the lower bound of the random interval when using the number masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The lower bound of the random interval when using the number masking function.")]
        [ValidateNotNullOrEmpty]
        public double? NumberFrom { get; set; }

        /// <summary>
        /// Gets or sets the NumberTo property, which is the upper bound of the random interval when using the number masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The upper bound of the random interval when using the number masking function.")]
        [ValidateNotNullOrEmpty]
        public double? NumberTo { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
       
        protected override IEnumerable<DatabaseDataMaskingRuleModel> UpdateModel(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            string errorMessage = ValidateRuleTarget(rules);
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = ValidateOperation(rules);
            }
            
            if(!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
            DatabaseDataMaskingRuleModel rule = GetRule(rules);
            DatabaseDataMaskingRuleModel updatedRule = UpdateRule(rule);
            return UpdateRuleList(rules, rule);
        }

        protected string ValidateRuleTarget(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            if (AliasName != null) // using the alias parameter set
            {
                if(rules.Any(r => r.AliasName == AliasName && r.RuleId != RuleId))
                {
                    return string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.DataMaskingAliasAlreadyUsedError, AliasName);
                }
            }
            else
            {
                if (rules.Any(r => r.TableName == TableName && r.ColumnName == ColumnName && r.RuleId != RuleId))
                {
                    return string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.DataMaskingTableAndColumnUsedError, TableName, ColumnName);
                }
            }
            return null;
        }

        protected DatabaseDataMaskingRuleModel UpdateRule(DatabaseDataMaskingRuleModel rule)
        {
            if(!string.IsNullOrEmpty(AliasName))
            {
                rule.AliasName = AliasName;
                rule.TableName = null;
                rule.ColumnName = null;
            }
            else
            {
                rule.TableName = TableName;
                rule.ColumnName = ColumnName;
                rule.AliasName = null;
            }

            if(!string.IsNullOrEmpty(MaskingFunction)) // only update if the user provided this value
            {
                rule.MaskingFunction = ModelizeMaskingFunction();
            }

            if(rule.MaskingFunction == Model.MaskingFunction.Text)
            {
                if (PrefixSize != null) // only update if the user provided this value
                {
                    rule.PrefixSize = PrefixSize;
                }

                if (!string.IsNullOrEmpty(ReplacementString)) // only update if the user provided this value
                {
                    rule.ReplacementString = ReplacementString;
                }

                if (SuffixSize != null) // only update if the user provided this value
                {
                    rule.SuffixSize = SuffixSize;
                }

                if(rule.PrefixSize == null)
                {
                    rule.PrefixSize = Constants.PrefixSizeDefaultValue;
                }

                if (string.IsNullOrEmpty(rule.ReplacementString))
                {
                    rule.ReplacementString = Constants.ReplacementStringDefaultValue;
                }

                if (rule.SuffixSize == null)
                {
                    rule.SuffixSize = Constants.SuffixSizeDefaultValue;
                }
            }

            if (rule.MaskingFunction == Model.MaskingFunction.Number)
            {
                if (NumberFrom != null) // only update if the user provided this value
                {
                    rule.NumberFrom = NumberFrom;
                }

                if (NumberTo != null) // only update if the user provided this value
                {
                    rule.NumberTo = NumberTo;
                }

                if (rule.NumberFrom == null)
                {
                    rule.NumberFrom = Constants.NumberFromDefaultValue;
                }

                if (rule.NumberTo == null)
                {
                    rule.NumberTo = Constants.NumberToDefaultValue;
                }

                if(rule.NumberFrom > rule.NumberTo)
                {
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.DataMaskingNumberRuleIntervalDefinitionError));
                }
            }
            return rule;
        }

        private MaskingFunction ModelizeMaskingFunction()
        {
            if (MaskingFunction == Constants.CCN) return Model.MaskingFunction.CreditCardNumber;
            if (MaskingFunction == Constants.NoMasking) return Model.MaskingFunction.NoMasking;
            if (MaskingFunction == Constants.Number) return Model.MaskingFunction.Number;
            if (MaskingFunction == Constants.Text) return Model.MaskingFunction.Text;
            if (MaskingFunction == Constants.Email) return Model.MaskingFunction.Email;
            if (MaskingFunction == Constants.SSN) return Model.MaskingFunction.SocialSecurityNumber;
            return Model.MaskingFunction.Default;
        }

        protected abstract string ValidateOperation(IEnumerable<DatabaseDataMaskingRuleModel> rules);

        protected abstract DatabaseDataMaskingRuleModel GetRule(IEnumerable<DatabaseDataMaskingRuleModel> rules);

        protected abstract IEnumerable<DatabaseDataMaskingRuleModel> UpdateRuleList(IEnumerable<DatabaseDataMaskingRuleModel> rules, DatabaseDataMaskingRuleModel rule);
        

        protected override void SendModel(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            ModelAdapter.SetDatabaseDataMaskingRule(rules.First(r => r.RuleId == RuleId), clientRequestId);
        }

        protected override bool writeResult() { return PassThru; }
    }
}
