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

using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class QuotaReportExtensions
    {
        public static PSNetAppFilesQuotaReport ConvertToPs(this Management.NetApp.Models.QuotaReport quotaReport)
        {
            return new PSNetAppFilesQuotaReport()
            {
                QuotaType = quotaReport.QuotaType,
                QuotaTarget = quotaReport.QuotaTarget,
                QuotaLimitUsedInKiBs = quotaReport.QuotaLimitUsedInKiBs,
                QuotaLimitTotalInKiBs = quotaReport.QuotaLimitTotalInKiBs,
                PercentageUsed = quotaReport.PercentageUsed,
                IsDerivedQuota = quotaReport.IsDerivedQuota
            };
        }

        public static PSNetAppFilesListQuotaReportResponse ConvertToPs(this Management.NetApp.Models.ListQuotaReportResult listQuotaReportResponse)
        {
            return new PSNetAppFilesListQuotaReportResponse()
            {
                Value = listQuotaReportResponse?.Properties?.QuotaReportRecords?.Select(e => e.ConvertToPs()).ToList()
            };
        }
    }
}
