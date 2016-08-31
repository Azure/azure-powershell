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

using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Removes a data masking rule from a given database
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlDatabaseDataMaskingRule", SupportsShouldProcess = true)]
    public class RemoveAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Confirmation when a data masking rule is removed")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Calls the data masking removal API with the rule that this cmdlet operated on
        /// </summary>
        /// <param name="rules">A list consisting of a single rule - the rule that this cmdlet operated on</param>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> PersistChanges(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            if (!Force.IsPresent && !ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveDatabaseDataMaskingRuleDescription,
                                    ColumnName, TableName, SchemaName, DatabaseName),
                string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveDatabaseDataMaskingRuleWarning,
                                    ColumnName, TableName, SchemaName, DatabaseName),
                Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return null;
            }

            ModelAdapter.RemoveDatabaseDataMaskingRule(rules.First(), clientRequestId);

            return null;
        }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }
    }
}