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

namespace Microsoft.Azure.Commands.RedisCache
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.RedisCache.Models;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCacheScheduleEntry"), OutputType(typeof(PSScheduleEntry))]
    public class NewAzureRedisCacheScheduleEntry : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Day of week for which want to create schedule entry")]
        [ValidateSet("Everyday", "Weekend", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]      
        [ValidateNotNullOrEmpty]
        public string DayOfWeek { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Hour of day when schedule starts in UTC")]
        public int StartHourUtc { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Window of time while patching is allowed")]
        public TimeSpan? MaintenanceWindow { get; set; }
        
        public override void ExecuteCmdlet()
        {
            WriteObject(new PSScheduleEntry()
            {
                DayOfWeek = DayOfWeek,
                StartHourUtc = StartHourUtc,
                MaintenanceWindow = MaintenanceWindow
            });
        }
    }
}