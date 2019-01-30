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
#>
function Test-E2ESchedules
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $StartTime = Get-Date "13:00:00"
    $StartTime = $StartTime.AddDays(1)
    $EndTime = $StartTime.AddYears(1)
    $ScheduleName = "Schedule3"

    New-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name "Schedule3" `
                                  -StartTime $StartTime `
                                  -ExpiryTime $EndTime `
                                  -DayInterval 1 `
                                  -Description "Hello"
   
    New-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $ScheduleName `
                                  -StartTime $StartTime `
                                  -ExpiryTime $EndTime `
                                  -WeekInterval 3 `
                                  -Description "Hello Again"

    $getSchedule = Get-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -Name $ScheduleName

    Assert-AreEqual "Hello Again"  $getSchedule.Description
    Assert-AreEqual 3 $getSchedule.Interval

    Set-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $ScheduleName `
                                  -Description "Goodbye" `
                                  -IsEnabled $FALSE 

    $getSchedule = Get-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -Name $ScheduleName

    Assert-AreEqual "Goodbye"  $getSchedule.Description
    Assert-AreEqual $FALSE  $getSchedule.IsEnabled

    Remove-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $ScheduleName `
                                     -Force

    $getSchedule = Get-AzAutomationSchedule -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -Name $ScheduleName -ErrorAction SilentlyContinue

    Assert-True {$getSchedule -eq $null}
 }
