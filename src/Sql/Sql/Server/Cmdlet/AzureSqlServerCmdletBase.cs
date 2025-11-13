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
        /// <summary>
        /// Validates soft delete retention parameters and throws appropriate exceptions if invalid
        /// </summary>
        /// <param name="enableSoftDelete">Whether soft delete is enabled</param>
        /// <param name="softDeleteRetentionDays">Number of retention days specified</param>
        protected void ValidateSoftDeleteParameters(bool? enableSoftDelete, int? softDeleteRetentionDays)
        {
            if (softDeleteRetentionDays.HasValue)
            {
                if (enableSoftDelete == true)
                {
                    if (softDeleteRetentionDays.Value < 1 || softDeleteRetentionDays.Value > 7)
                    {
                        throw new PSArgumentException(Properties.Resources.InvalidSoftDeleteRetentionDaysRange, "SoftDeleteRetentionDays");
                    }
                }
                else if (enableSoftDelete == false)
                {
                    if (softDeleteRetentionDays.Value != 0)
                    {
                        throw new PSArgumentException(Properties.Resources.InvalidSoftDeleteRetentionDaysForDisablingSoftDelete, "SoftDeleteRetentionDays");
                    }
                }
                else
                {
                    throw new PSArgumentException(Properties.Resources.MissingEnableSoftDelete, "EnableSoftDelete");
                }
            }
        }

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected override AzureSqlServerAdapter InitModelAdapter()
        {
            return new AzureSqlServerAdapter(DefaultContext);
        }
    }
}
