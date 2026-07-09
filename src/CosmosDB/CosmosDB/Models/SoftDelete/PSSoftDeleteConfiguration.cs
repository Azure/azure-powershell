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

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSSoftDeleteConfiguration
    {
        public PSSoftDeleteConfiguration()
        {
        }

        public PSSoftDeleteConfiguration(SoftDeleteConfiguration softDeleteConfiguration)
        {
            if (softDeleteConfiguration == null)
            {
                return;
            }

            SoftDeletionEnabled = softDeleteConfiguration.SoftDeletionEnabled;
            SoftDeleteRetentionPeriodInMinutes = softDeleteConfiguration.SoftDeleteRetentionPeriodInMinutes;
            MinMinutesBeforePermanentDeletionAllowed = softDeleteConfiguration.MinMinutesBeforePermanentDeletionAllowed;
        }

        /// <summary>
        /// Gets or sets whether soft delete is enabled on the account.
        /// </summary>
        public bool? SoftDeletionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the retention period (in minutes) for soft-deleted resources.
        /// </summary>
        public int? SoftDeleteRetentionPeriodInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the minimum minutes before permanent deletion is allowed.
        /// </summary>
        public int? MinMinutesBeforePermanentDeletionAllowed { get; set; }

        public static SoftDeleteConfiguration ToSDKModel(PSSoftDeleteConfiguration psSoftDeleteConfiguration)
        {
            if (psSoftDeleteConfiguration == null)
            {
                return null;
            }

            return new SoftDeleteConfiguration
            {
                SoftDeletionEnabled = psSoftDeleteConfiguration.SoftDeletionEnabled,
                SoftDeleteRetentionPeriodInMinutes = psSoftDeleteConfiguration.SoftDeleteRetentionPeriodInMinutes,
                MinMinutesBeforePermanentDeletionAllowed = psSoftDeleteConfiguration.MinMinutesBeforePermanentDeletionAllowed
            };
        }
    }
}
