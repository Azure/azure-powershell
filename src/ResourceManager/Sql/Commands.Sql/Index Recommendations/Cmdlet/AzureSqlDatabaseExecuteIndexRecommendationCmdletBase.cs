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
using Microsoft.Azure.Commands.Sql.Model;
using Microsoft.Azure.Commands.Sql.Service;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Cmdlet
{
    /// <summary>
    /// The base class of cmdlets for Azure SQL Recommended Index
    /// </summary>
    public abstract class AzureSqlDatabaseExecuteIndexRecommendationCmdletBase : AzureSqlCmdletBase<IndexRecommendation, AzureSqlDatabaseIndexRecommendationAdapter>
    {
        /// <summary>
        /// String constants for different error states.
        /// </summary>
        public class IndexState
        {
            public const string Active = "Active";
            public const string Pending = "Pending";
            public const string Error = "Error";
            public const string PendingRevert = "Pending Revert";
            public const string RevertCanceled = "Revert Canceled";
        }

        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the index recommendation.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Index Recommendation name.")]
        [ValidateNotNullOrEmpty]
        public string IndexRecommendationName { get; set; }

        /// <summary>
        /// Return index recommendation with IndexRecommendationName name.
        /// </summary>
        /// <returns>Index recommendation with IndexRecommendationName name</returns>
        protected override IndexRecommendation GetEntity()
        {
            var indexRecommendation = ModelAdapter.ListRecommendedIndexes(ResourceGroupName, ServerName, DatabaseName)
                .Single(i => i.Name == IndexRecommendationName);
            return indexRecommendation;
        }

        /// <summary>
        /// Sends the changes to the service, this will trigger applying action.
        /// </summary>
        /// <param name="recommendation">Index recommendation</param>
        /// <returns>Index recommendation</returns>
        protected override IndexRecommendation PersistChanges(IndexRecommendation recommendation)
        {
            ModelAdapter.UpdateRecommendationState(ResourceGroupName, ServerName, recommendation);
            return recommendation;
        }

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The recommended index adapter</returns>
        protected override AzureSqlDatabaseIndexRecommendationAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseIndexRecommendationAdapter(DefaultProfile.Context);
        }
    }
}
