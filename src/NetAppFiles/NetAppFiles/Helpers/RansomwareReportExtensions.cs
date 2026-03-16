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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class RansomwareReportExtensions
    {
        public static PSNetAppFilesRansomwareReport ConvertToPs(this Management.NetApp.Models.RansomwareReport ransomwareReport)
        {
            return new PSNetAppFilesRansomwareReport()
            {
                ResourceGroupName = new ResourceIdentifier(ransomwareReport.Id).ResourceGroupName,
                Id = ransomwareReport.Id,
                Name = ransomwareReport.Name,
                Type = ransomwareReport.Type,
                EventTime = ransomwareReport.Properties?.EventTime,
                State = ransomwareReport.Properties?.State,
                Severity = ransomwareReport.Properties?.Severity,
                ClearedCount = ransomwareReport.Properties?.ClearedCount,
                ReportedCount = ransomwareReport.Properties?.ReportedCount,
                Suspects = ransomwareReport.Properties?.Suspects?.Select(s => s.ConvertToPs()).ToList(),
                ProvisioningState = ransomwareReport.Properties?.ProvisioningState
            };
        }

        public static PSNetAppFilesRansomwareSuspect ConvertToPs(this Management.NetApp.Models.RansomwareSuspects suspect)
        {
            return new PSNetAppFilesRansomwareSuspect()
            {
                Extension = suspect.Extension,
                Resolution = suspect.Resolution,
                FileCount = suspect.FileCount,
                SuspectFiles = suspect.SuspectFiles?.Select(f => f.ConvertToPs()).ToList()
            };
        }

        public static PSNetAppFilesRansomwareSuspectFile ConvertToPs(this Management.NetApp.Models.SuspectFile suspectFile)
        {
            return new PSNetAppFilesRansomwareSuspectFile()
            {
                SuspectFileName = suspectFile.SuspectFileName,
                FileTimestamp = suspectFile.FileTimestamp
            };
        }

        public static List<PSNetAppFilesRansomwareReport> ConvertToPS(this IList<Management.NetApp.Models.RansomwareReport> ransomwareReports)
        {
            return ransomwareReports.Select(e => e.ConvertToPs()).ToList();
        }
    }
}
