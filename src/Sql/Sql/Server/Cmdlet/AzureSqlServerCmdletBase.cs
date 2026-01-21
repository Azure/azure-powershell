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
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Server.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    public abstract class AzureSqlServerCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerModel>, AzureSqlServerAdapter>
    {
        protected const int SoftDeleteRetentionDaysDisabled = 0;
        protected const int SoftDeleteRetentionDaysMinimum = 1;
        protected const int SoftDeleteRetentionDaysMaximum = 7;

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected override AzureSqlServerAdapter InitModelAdapter()
        {
            return new AzureSqlServerAdapter(DefaultContext);
        }

        /// <summary>
        /// Validates SoftDeleteRetentionDays and EnableSoftDelete parameters
        /// </summary>
        /// <param name="softDeleteRetentionDays">The soft delete retention days value</param>
        /// <param name="enableSoftDelete">The enable soft delete flag</param>
        protected void ValidateSoftDeleteParameters(int? softDeleteRetentionDays, bool? enableSoftDelete)
        {
            // Validate SoftDeleteRetentionDays range
            if (softDeleteRetentionDays.HasValue)
            {
                if (softDeleteRetentionDays.Value < SoftDeleteRetentionDaysDisabled || softDeleteRetentionDays.Value > SoftDeleteRetentionDaysMaximum)
                {
                    throw new PSArgumentException($"SoftDeleteRetentionDays must be between {SoftDeleteRetentionDaysDisabled} and {SoftDeleteRetentionDaysMaximum}.", "SoftDeleteRetentionDays");
                }
            }

            // If both EnableSoftDelete and SoftDeleteRetentionDays are specified, validate their combination
            if (enableSoftDelete.HasValue && softDeleteRetentionDays.HasValue)
            {
                if (enableSoftDelete == true && (softDeleteRetentionDays.Value < SoftDeleteRetentionDaysMinimum || softDeleteRetentionDays.Value > SoftDeleteRetentionDaysMaximum))
                {
                    throw new PSArgumentException($"When EnableSoftDelete is true, SoftDeleteRetentionDays must be between {SoftDeleteRetentionDaysMinimum} and {SoftDeleteRetentionDaysMaximum}.", "SoftDeleteRetentionDays");
                }
                else if (enableSoftDelete == false && softDeleteRetentionDays.Value != SoftDeleteRetentionDaysDisabled)
                {
                    throw new PSArgumentException($"When EnableSoftDelete is false, SoftDeleteRetentionDays must be {SoftDeleteRetentionDaysDisabled}.", "SoftDeleteRetentionDays");
                }
            }
        }

        /// <summary>
        /// Computes the SoftDeleteRetentionDays value based on provided parameters
        /// </summary>
        /// <param name="softDeleteRetentionDays">The explicitly provided retention days</param>
        /// <param name="enableSoftDelete">The enable soft delete flag</param>
        /// <returns>The computed retention days value</returns>
        protected int? ComputeSoftDeleteRetentionDays(int? softDeleteRetentionDays, bool? enableSoftDelete)
        {
            if (softDeleteRetentionDays.HasValue)
                return softDeleteRetentionDays.Value;

            if (enableSoftDelete.HasValue)
                return enableSoftDelete.Value ? SoftDeleteRetentionDaysMaximum : SoftDeleteRetentionDaysDisabled;

            return null;
        }
    }
}
