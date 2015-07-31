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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Returns a data masking rule or all the rules for a given database
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseDataMaskingRule"), OutputType(typeof(IEnumerable<DatabaseDataMaskingRuleModel>))]
    public class GetAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the id of the rule use, if not provided then the list of rules for this DB is returned
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Data Masking rule Id.")]
        public override string RuleId { get; set; } // intentionally overiding to make this property non mandatory (thus allow a LIST call)

        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> PersistChanges(IEnumerable<DatabaseDataMaskingRuleModel> model) 
        {
            return null;
        }
    }
}