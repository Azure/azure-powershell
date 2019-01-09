# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests create new automation variable with string value.

Playback error:
    Message: System.Management.Automation.ActionPreferenceStopException : 
    The running command stopped because the preference variable "ErrorActionPreference" or common parameter 
    is set to Stop: Unable to find a matching HTTP request for URL 
    'PUT /subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/to-delete-01/providers/Microsoft.Automation/automationAccounts/fbs-aa-01/jobSchedules/05dc7bfb-6c17-4311-8722-3c37e69f3780?api-version=2015-10-31'. 
    Calling method Item().
#>
function Test-E2EJobSchedules
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $StartTime = Get-Date "13:00:00"
    $StartTime = $StartTime.AddDays(1)
    $EndTime = $StartTime.AddYears(1)
    $ScheduleName = "ScheduleForRunbookAssociation"
    $runbookName =  "RunbookForScheduleAssociation"

    Register-AzAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
                                               -AutomationAccountName $automationAccountName `
                                               -RunbookName $runbookName `
                                               -ScheduleName $ScheduleName

    $jobSchedule = Get-AzAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
                                                         -AutomationAccountName $automationAccountName `
                                                         -RunbookName $runbookName `
                                                         -ScheduleName $ScheduleName


    Assert-AreEqual $ScheduleName  $jobSchedule.ScheduleName 
    Assert-AreEqual $runbookName $jobSchedule.RunbookName

    Unregister-AzAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -RunbookName $runbookName `
                                                 -ScheduleName $ScheduleName -Force

    $jobSchedule = Get-AzAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
                                                         -AutomationAccountName $automationAccountName `
                                                         -RunbookName $runbookName `
                                                         -ScheduleName $ScheduleName -ErrorAction SilentlyContinue

    Assert-True {$jobSchedule -eq $null}
 }

