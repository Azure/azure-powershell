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

namespace Microsoft.Azure.Commands.Sql.DataMasking.Model
{
    /// <summary>
    /// Defines the set of supported masking function
    /// </summary>
    public enum MaskingFunction { Number, Text, CreditCardNumber, SocialSecurityNumber, Email, Default, NoMasking };

    /// <summary>
    /// The base class that defines the core properties of a data masking rule
    /// </summary>
    public class BaseDataMaskingRuleModel
    {
        /// <summary>
        /// Gets or sets the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the chema that contains the table on which the rule operates on
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// Gets or sets the name of the table that contains the column on which the rule operates on
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the column that this rule operates on
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the masking function of the current rule
        /// </summary>
        public MaskingFunction MaskingFunction { get; set; }

        /// <summary>
        /// Gets or sets the prefix size to be used in case this rule's masking function is Text
        /// </summary>
        public uint? PrefixSize { get; set; }

        /// <summary>
        /// Gets or sets the suffix size to be used in case this rule's masking function is Text
        /// </summary>
        public uint? SuffixSize { get; set; }

        /// <summary>
        /// Gets or sets the replacement string to be used in case this rule's masking function is Text
        /// </summary>
        public string ReplacementString { get; set; }

        /// <summary>
        /// Gets or sets the lower bound of the interval from which a random number is selected in case this rule's masking function is Number
        /// </summary>
        public double? NumberFrom { get; set; }

        /// <summary>
        /// Gets or sets the upper bound of the interval from which a random number is selected in case this rule's masking function is Number
        /// </summary>
        public double? NumberTo { get; set; }
    }
}