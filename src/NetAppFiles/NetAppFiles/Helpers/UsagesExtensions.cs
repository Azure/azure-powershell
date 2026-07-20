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
    public static class UsagesExtensions
    {
        public static PSNetAppFilesUsages ConvertToPs(this Management.NetApp.Models.UsageResult usageResult)
        {
            var psUsage = new PSNetAppFilesUsages
            {
                Id = usageResult.Id,
                CurrentValue = usageResult.CurrentValue,
                Limit = usageResult.Limit,
                Name = usageResult.Name.ConvertToPs(),
                Unit = usageResult.Unit
            };
            return psUsage;
        }

        public static List<PSNetAppFilesUsages> ConvertToPs(this IList<Management.NetApp.Models.UsageResult> usagesResultList)
        {
            return usagesResultList.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesUsageName ConvertToPs(this Management.NetApp.Models.UsageName usageName)
        {
            var psUsageName = new PSNetAppFilesUsageName()
            {
                LocalizedValue = usageName.LocalizedValue,
                Value = usageName.Value
            };
            return psUsageName;
        }

        public static Management.NetApp.Models.UsageName ConvertFromPs(this PSNetAppFilesUsageName  psUsageName)
        {
            var usageName = new Management.NetApp.Models.UsageName()
            {
                LocalizedValue = psUsageName.LocalizedValue,
                Value = psUsageName.Value
            };
            return usageName;
        }
    }
}