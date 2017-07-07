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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    public abstract class AzureSqlFailoverGroupCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlFailoverGroupModel>, AzureSqlFailoverGroupAdapter>
    {
        /// <summary>
        /// Initializes the Azure Sql Failover Group Adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlFailoverGroupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlFailoverGroupAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Interprets and returns the lossy automatic failover grace period provided by the user.
        /// </summary>
        /// <returns>The grace period</returns>
        protected int? ComputeEffectiveGracePeriod(FailoverPolicy policy, int? originalGracePeriod)
        {
            int? gracePeriod = null;

            object parameterValue;
            if (MyInvocation.BoundParameters.TryGetValue("GracePeriodWithDataLossHours", out parameterValue))
            {
                gracePeriod = (int)parameterValue;
            }

            if (!gracePeriod.HasValue && policy == FailoverPolicy.Automatic)
            {
                // If the policy is Automatic, the grace period must be non-null. If this is an update and the grace
                // period was non-null, use the existing grace period. Otherwise, use a default of 1.
                gracePeriod = originalGracePeriod ?? 1;
            }

            if (gracePeriod.HasValue && gracePeriod == 0)
            {
                // Use 1 if 0 is provided. They are equivalent from the service's perspective, but 1 is more
                // representative of what a user will see.
                WriteWarning(string.Format(Properties.Resources.FailoverGroupDataLossHoursUnsupportedLowValue, gracePeriod, 1));
                gracePeriod = 1;
            }

            int maxAllowedValue = int.MaxValue / 60;
            if (gracePeriod.HasValue && gracePeriod.Value > maxAllowedValue)
            {
                WriteWarning(string.Format(Properties.Resources.FailoverGroupDataLossHoursOverflow, gracePeriod, maxAllowedValue));
                gracePeriod = maxAllowedValue;
            }

            return gracePeriod;
        }
    }
}
