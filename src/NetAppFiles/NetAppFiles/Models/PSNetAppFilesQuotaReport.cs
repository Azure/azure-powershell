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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// Quota report record properties
    /// </summary>
    public class PSNetAppFilesQuotaReport
    {
        /// <summary>
        /// Gets or sets type of quota
        /// </summary>
        public string QuotaType { get; set; }

        /// <summary>
        /// Gets or sets UserID/GroupID/SID based on the quota target type
        /// </summary>
        public string QuotaTarget { get; set; }

        /// <summary>
        /// Gets or sets specifies the current usage in kibibytes for the user/group quota
        /// </summary>
        public long? QuotaLimitUsedInKiBs { get; set; }

        /// <summary>
        /// Gets or sets specifies the total size limit in kibibytes for the user/group quota
        /// </summary>
        public long? QuotaLimitTotalInKiBs { get; set; }

        /// <summary>
        /// Gets or sets percentage of used size compared to total size
        /// </summary>
        public double? PercentageUsed { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate whether the quota is derived from default quota
        /// </summary>
        public bool? IsDerivedQuota { get; set; }
    }

    /// <summary>
    /// Quota Report for volume
    /// </summary>
    public class PSNetAppFilesListQuotaReportResponse
    {
        /// <summary>
        /// Gets or sets list of quota reports
        /// </summary>
        public IList<PSNetAppFilesQuotaReport> Value { get; set; }
    }
}
