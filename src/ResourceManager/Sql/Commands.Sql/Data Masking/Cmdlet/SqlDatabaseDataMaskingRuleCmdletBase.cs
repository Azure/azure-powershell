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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using Microsoft.Azure.Commands.Sql.DataMasking.Services;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Database data masking rules cmdlets
    /// </summary>
    public abstract class SqlDatabaseDataMaskingRuleCmdletBase : AzureSqlDatabaseCmdletBase<IEnumerable<DatabaseDataMaskingRuleModel>, SqlDataMaskingAdapter>
    {
        /// <summary>
        /// Gets or sets the schema name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schema name.")]
        [ValidateNotNullOrEmpty]
        public virtual string SchemaName { get; set; }

        /// <summary>
        /// Gets or sets the table name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The table name.")]
        [ValidateNotNullOrEmpty]
        public virtual string TableName { get; set; }

        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The column name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ColumnName { get; set; }

        /// <summary>
        ///  Checks whether the model of the current cmdlet is the same as the model of the given rule
        /// </summary>
        protected bool IsModelOfRule(BaseDataMaskingRuleModel rule)
        {
            return rule.ColumnName == ColumnName && rule.TableName == TableName && rule.SchemaName == SchemaName;
        }

        /// <summary>
        ///  The model is a list of rules. This method would return the specific rule that was updated
        /// </summary>
        protected override object TransformModelToOutputObject(IEnumerable<DatabaseDataMaskingRuleModel> model)
        {
            return model.FirstOrDefault(IsModelOfRule);
        }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> GetEntity()
        {
            return ModelAdapter.GetDatabaseDataMaskingRules(ResourceGroupName, ServerName, DatabaseName, clientRequestId);
        }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> PersistChanges(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            DatabaseDataMaskingRuleModel model = rules.First();
            ModelAdapter.SetDatabaseDataMaskingRule(model, clientRequestId);
            return null;
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlDataMaskingAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new SqlDataMaskingAdapter(DefaultProfile.Context);
        }
    }
}