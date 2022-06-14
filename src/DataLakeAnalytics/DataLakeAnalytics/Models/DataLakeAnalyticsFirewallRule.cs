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

using Microsoft.Azure.Management.DataLake.Analytics.Models;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders.
    /// </summary>
    public class DataLakeAnalyticsFirewallRule
    {
        public string Name { get; set; }

        public string StartIpAddress { get; set; }

        public string EndIpAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAnalyticsFirewallRule" /> class.
        /// </summary>
        /// <param name="baseRule"></param>
        public DataLakeAnalyticsFirewallRule(FirewallRule baseRule)
        {
            Name = baseRule.Name;
            StartIpAddress = baseRule.StartIpAddress;
            EndIpAddress = baseRule.EndIpAddress;
        }
    }
}