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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Returns a data masking rule or all the rules for a given database
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseDataMaskingRule", SupportsShouldProcess = true), OutputType(typeof(IEnumerable<DatabaseDataMaskingRuleModel>))]
    public class GetAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the schema name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schema name.")]
        [ValidateNotNullOrEmpty]
        public override string SchemaName { get; set; }

        /// <summary>
        /// Gets or sets the table name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The table name.")]
        [ValidateNotNullOrEmpty]
        public override string TableName { get; set; }

        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The column name.")]
        [ValidateNotNullOrEmpty]
        public override string ColumnName { get; set; }

        protected override object TransformModelToOutputObject(IEnumerable<DatabaseDataMaskingRuleModel> model)
        {
            Predicate<DatabaseDataMaskingRuleModel> colPred = (DatabaseDataMaskingRuleModel r) => { return string.IsNullOrEmpty(ColumnName) ? true : r.ColumnName == ColumnName; };
            Predicate<DatabaseDataMaskingRuleModel> tablePred = (DatabaseDataMaskingRuleModel r) => { return string.IsNullOrEmpty(TableName) ? true : r.TableName == TableName; };
            Predicate<DatabaseDataMaskingRuleModel> schemaPred = (DatabaseDataMaskingRuleModel r) => { return string.IsNullOrEmpty(SchemaName) ? true : r.SchemaName == SchemaName; };
            return model.Where(r => { return colPred(r) && tablePred(r) && schemaPred(r); }).ToList();
        }


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