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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Base for creation and update of data masking rule.
    /// </summary>
    public abstract class BuildAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the masking function - the definition of this property as a cmdlet parameter is done in the subclasses
        /// </summary>
        public virtual string MaskingFunction { get; set; }

        /// <summary>
        /// Gets or sets the prefix size when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The prefix size when using the text masking function.")]
        public uint? PrefixSize { get; set; }

        /// <summary>
        /// Gets or sets the replacement string when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The replacement string when using the text masking function.")]
        public string ReplacementString { get; set; }

        /// <summary>
        /// Gets or sets the suffix size when using the text masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The suffix size string when using the text masking function.")]
        public uint? SuffixSize { get; set; }

        /// <summary>
        /// Gets or sets the NumberFrom property, which is the lower bound of the random interval when using the number masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The lower bound of the random interval when using the number masking function.")]
        public double? NumberFrom { get; set; }

        /// <summary>
        /// Gets or sets the NumberTo property, which is the upper bound of the random interval when using the number masking function
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The upper bound of the random interval when using the number masking function.")]
        public double? NumberTo { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> ApplyUserInputToModel(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            string errorMessage = ValidateOperation(rules);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
            DatabaseDataMaskingRuleModel rule = GetRule(rules);
            DatabaseDataMaskingRuleModel updatedRule = UpdateRule(rule);
            return UpdateRuleList(rules, rule);
        }

        /// <summary>
        /// Update the rule this cmdlet is operating on based on the values provided by the user
        /// </summary>
        /// <param name="rule">The rule this cmdlet operates on</param>
        /// <returns>An updated rule model</returns>
        protected DatabaseDataMaskingRuleModel UpdateRule(DatabaseDataMaskingRuleModel rule)
        {
            if (!string.IsNullOrEmpty(SchemaName)) // only update if the user provided this value
            {
                rule.SchemaName = SchemaName;
            }

            if (!string.IsNullOrEmpty(TableName)) // only update if the user provided this value
            {
                rule.TableName = TableName;
            }

            if (!string.IsNullOrEmpty(ColumnName)) // only update if the user provided this value
            {
                rule.ColumnName = ColumnName;
            }

            if (!string.IsNullOrEmpty(MaskingFunction)) // only update if the user provided this value
            {
                rule.MaskingFunction = ModelizeMaskingFunction();
            }

            if (rule.MaskingFunction == Model.MaskingFunction.Text)
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

                if (rule.PrefixSize == null)
                {
                    rule.PrefixSize = SecurityConstants.PrefixSizeDefaultValue;
                }

                if (string.IsNullOrEmpty(rule.ReplacementString))
                {
                    rule.ReplacementString = SecurityConstants.ReplacementStringDefaultValue;
                }

                if (rule.SuffixSize == null)
                {
                    rule.SuffixSize = SecurityConstants.SuffixSizeDefaultValue;
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
                    rule.NumberFrom = SecurityConstants.NumberFromDefaultValue;
                }

                if (rule.NumberTo == null)
                {
                    rule.NumberTo = SecurityConstants.NumberToDefaultValue;
                }

                if (rule.NumberFrom > rule.NumberTo)
                {
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.DataMaskingNumberRuleIntervalDefinitionError));
                }
            }
            return rule;
        }

        /// <summary>
        /// Transforms the user given data masking function to its model representation
        /// </summary>
        /// <returns>The model representation of the user provided masking function</returns>
        private MaskingFunction ModelizeMaskingFunction()
        {
            if (MaskingFunction == SecurityConstants.CCN) return Model.MaskingFunction.CreditCardNumber;
            if (MaskingFunction == SecurityConstants.NoMasking) return Model.MaskingFunction.NoMasking;
            if (MaskingFunction == SecurityConstants.Number) return Model.MaskingFunction.Number;
            if (MaskingFunction == SecurityConstants.Text) return Model.MaskingFunction.Text;
            if (MaskingFunction == SecurityConstants.Email) return Model.MaskingFunction.Email;
            if (MaskingFunction == SecurityConstants.SSN) return Model.MaskingFunction.SocialSecurityNumber;
            return Model.MaskingFunction.Default;
        }

        /// <summary>
        /// An additional validation hook for inheriting classes to provide specific validation.
        /// </summary>
        /// <param name="rules">The rule the cmdlet operates on</param>
        /// <returns>An error message or null if all is fine</returns>
        protected abstract string ValidateOperation(IEnumerable<DatabaseDataMaskingRuleModel> rules);

        /// <summary>
        /// Returns the rule that this cmdlet operates on
        /// </summary>
        /// <param name="rules">All the data masking rules of the database</param>
        /// <returns>The rule that this cmdlet operates on</returns>
        protected abstract DatabaseDataMaskingRuleModel GetRule(IEnumerable<DatabaseDataMaskingRuleModel> rules);

        /// <summary>
        /// Update the rule that this cmdlet operates on based on the user provided values
        /// </summary>
        /// <param name="rules">The data masking rules of the database</param>
        /// <param name="rule">The rule that this cmdlet operates on</param>
        /// <returns>The update list of the database's data masking rules</returns>
        protected abstract IEnumerable<DatabaseDataMaskingRuleModel> UpdateRuleList(IEnumerable<DatabaseDataMaskingRuleModel> rules, DatabaseDataMaskingRuleModel rule);

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> PersistChanges(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            ModelAdapter.SetDatabaseDataMaskingRule(rules.First(IsModelOfRule), clientRequestId);
            return null;
        }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }
    }
}