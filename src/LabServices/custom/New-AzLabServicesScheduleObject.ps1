
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for Lab Services Schedule.
.Description
Create a in-memory object for Lab Services Schedule.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule
.Link
https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesScheduleObject
#>
function New-AzLabServicesScheduleObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory)]
        [DateTime]        
        ${StartAt},

        [Parameter(Mandatory)]
        [DateTime]        
        ${StopAt},

        [Parameter(Mandatory)]
        [DateTime]        
        ${RecurrencePatternExpirationDate},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.RecurrenceFrequency])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.RecurrenceFrequency]
        ${RecurrencePatternFrequency},

        [Parameter(Mandatory)]
        [Int32]        
        ${RecurrencePatternInterval},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.WeekDay])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.WeekDay[]]
        ${RecurrencePatternWeekDay},

        [Parameter(Mandatory)]
        [String]        
        ${TimeZoneId}
    )

    process {

        $scheduleBody = @{
            properties = @{
                startAt = $StartAt
                stopAt = $StopAt
                recurrencePattern = @{
                  frequency = $($RecurrencePatternFrequency.ToString())
                  interval = $RecurrencePatternInterval
                  expirationDate = $RecurrencePatternExpirationDate
                }
                timeZoneId = $TimeZoneId
              }
        }
        return $scheduleBody | ConvertTo-Json -Depth 10
    }
}
