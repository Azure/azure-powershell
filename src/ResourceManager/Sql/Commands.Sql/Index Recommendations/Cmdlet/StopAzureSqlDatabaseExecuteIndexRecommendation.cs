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

using Microsoft.Azure.Commands.Sql.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Cmdlet
{
    /// <summary>
    /// Defines the Stop-AzureRmSqlDatabaseExecuteIndexRecommendation cmdlet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmSqlDatabaseExecuteIndexRecommendation",
        ConfirmImpact = ConfirmImpact.Low)]
    public class StopAzureSqlDatabaseExecuteIndexRecommendation : AzureSqlDatabaseExecuteIndexRecommendationCmdletBase
    {
        /// <summary>
        /// Update model state
        /// </summary>
        /// <param name="recommendation">Update recommendation state</param>
        /// <returns>Recommendation with updated state</returns>
        protected override IndexRecommendation ApplyUserInputToModel(IndexRecommendation recommendation)
        {
            if (recommendation.State == IndexState.Pending)
            {
                recommendation.State = IndexState.Active;
                return recommendation;
            }
            else if (recommendation.State == IndexState.PendingRevert)
            {
                recommendation.State = IndexState.RevertCanceled;
                return recommendation;
            }
            else
            {
                throw new Exception("Index operation can only be stopped if recommendation is currently in 'Pending' or 'Pending Revert' state");
            }
        }
    }
}
