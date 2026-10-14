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
        /// Validates the SoftDeleteRetentionDays parameter is within the supported range.
        /// A value of 0 disables soft-delete; values 1-7 enable soft-delete with the given retention period.
        /// </summary>
        /// <param name="softDeleteRetentionDays">The soft delete retention days value</param>
        protected void ValidateSoftDeleteRetentionDays(int? softDeleteRetentionDays)
        {
            if (softDeleteRetentionDays.HasValue)
            {
                if (softDeleteRetentionDays.Value < SoftDeleteRetentionDaysDisabled || softDeleteRetentionDays.Value > SoftDeleteRetentionDaysMaximum)
                {
                    throw new PSArgumentException($"SoftDeleteRetentionDays must be between {SoftDeleteRetentionDaysDisabled} and {SoftDeleteRetentionDaysMaximum}.", "SoftDeleteRetentionDays");
                }
            }
        }
    }
}
