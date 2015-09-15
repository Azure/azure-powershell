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
using Microsoft.Azure.Commands.Sql.DataMasking.Services;
using Microsoft.Azure.Common.Authentication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Database data masking rules cmdlets
    /// </summary>
    public abstract class SqlDatabaseDataMaskingRuleCmdletBase : AzureSqlDatabaseCmdletBase<IEnumerable<DatabaseDataMaskingRuleModel>, SqlDataMaskingAdapter>
    {
        /// <summary>
        /// Gets or sets the id of the rule use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Data Masking rule Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string RuleId { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override IEnumerable<DatabaseDataMaskingRuleModel> GetEntity()
        {
            return ModelAdapter.GetDatabaseDataMaskingRule(ResourceGroupName, ServerName, DatabaseName, clientRequestId, RuleId);
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
            return new SqlDataMaskingAdapter(Profile, subscription);
        }
    }
}