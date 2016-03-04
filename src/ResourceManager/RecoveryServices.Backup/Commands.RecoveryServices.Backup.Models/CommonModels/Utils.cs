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
        private static readonly Regex ResourceGroupRegex = new Regex(@"/subscriptions/(?<subscriptionsId>.+)/resourceGroups/(?<resourceGroupName>.+)/providers/(?<providersName>.+)/BackupVault/(?<BackupVaultName>.+)/containers/(?<containersName>.+)", RegexOptions.Compiled);

        public static string GetResourceGroupName(string id)
        {
            var match = ResourceGroupRegex.Match(id);
            if (match.Success)
            {
                var vmRGName = match.Groups["containersName"];
                if (vmRGName != null && vmRGName.Success)
                {
                    return vmRGName.Value;
                }
            }

            return null;
        }
    }
}
