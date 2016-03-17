﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class PolicyConstants
    {
        public const int MaxAllowedRetentionDurationCount = 9999;
        public const int MaxAllowedDateInMonth = 28;

        // day constants
        public const int NumOfDaysInWeek = 7;
        public const int NumOfDaysInMonth = 31;
        public const int NumOfDaysInYear = 366;

        // week constants
        public const int NumOfWeeksInMonth = 4;
        public const int NumOfWeeksInYear = 52;

        // month constants
        public const int NumOfMonthsInYear = 12;
    }

    public class TraceUtils
    {
        public static string GetString(IEnumerable<Object> objList)
        {
            return (objList == null) ? "null" : "{" + string.Join("}, {", objList) + "}";
        }

        public static string GetString(IEnumerable<DateTime> objList)
        {
            return (objList == null) ? "null" : "{" + string.Join("}, {", objList) + "}";
        }

        public static string GetString(IEnumerable<DayOfWeek> objList)
        {
            return (objList == null) ? "null" : "{" + string.Join("}, {", objList) + "}";
        }
    }

    public class IdUtils
    {
        static readonly Regex ResourceGroupRegex = new Regex(@"/Subscriptions/(?<subscriptionsId>.+)/resourceGroups/(?<resourceGroupName>.+)/providers/(?<providersName>.+)/vaults/(?<BackupVaultName>.+)/backupFabrics/(?<BackupFabricName>.+)/protectionContainers/(?<containersName>.+)", RegexOptions.Compiled);
        const string NameDelimiter = ";";

        public static string GetResourceGroupName(string id)
        {
            var match = ResourceGroupRegex.Match(id);
            if (match.Success)
            {
                var vmUniqueName = match.Groups["containersName"];
                if (vmUniqueName != null && vmUniqueName.Success)
                {
                    var vmNameInfo = vmUniqueName.Value.Split(NameDelimiter.ToCharArray());
                    if (vmNameInfo.Length == 3)
                    {
                        return vmNameInfo[1];
                    }
                    else if (vmNameInfo.Length == 4)
                    {
                        return vmNameInfo[2];
                    }
                    else
                    {
                        throw new Exception("Container name not in the expected format");
                    }
                }
            }

            return null;
        }
    }
}
