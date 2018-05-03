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
    using Microsoft.Azure.Commands.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Azure.Management.Redis.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using DayOfWeekEnum = Management.Redis.Models.DayOfWeek;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCachePatchSchedule", SupportsShouldProcess = true), OutputType(typeof(List<PSScheduleEntry>))]
    public class NewAzureRedisCachePatchSchedule : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "List of patch schedules (PSScheduleEntry) that needed to be set on redis cache.")]
        [ValidateNotNullOrEmpty]
        public PSScheduleEntry[] Entries { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);
            
            // Convert from PSScheduleEntry to ScheduleEntry
            List<ScheduleEntry> requestData = new List<ScheduleEntry>();
            foreach (var schedule in Entries)
            {
                requestData.Add(new ScheduleEntry
                {
                    DayOfWeek = (DayOfWeekEnum)Enum.Parse(typeof(DayOfWeekEnum), schedule.DayOfWeek, true),
                    StartHourUtc = schedule.StartHourUtc,
                    MaintenanceWindow = schedule.MaintenanceWindow
                });
            }

            ConfirmAction(
              string.Format(Resources.CreatePatchSchedule, Name),
              Name,
              () => 
              {
                  IList<ScheduleEntry> response = CacheClient.SetPatchSchedules(ResourceGroupName, Name, requestData);
                  List<PSScheduleEntry> returnValue = new List<PSScheduleEntry>();
                  foreach (var schedule in response)
                  {
                      returnValue.Add(new PSScheduleEntry
                      {
                          DayOfWeek = schedule.DayOfWeek.ToString(),
                          StartHourUtc = schedule.StartHourUtc,
                          MaintenanceWindow = schedule.MaintenanceWindow
                      });
                  }
                  WriteObject(returnValue);
              });
        }
    }
}