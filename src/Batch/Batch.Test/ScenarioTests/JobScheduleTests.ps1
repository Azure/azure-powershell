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
Tests basic CRUD operations on Batch job schedules
#>
function Test-JobScheduleCRUD
{
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $jsId1 = "jobSchedule1"
    $jsId2 = "jobSchedule2"

    try
    {
        # Create 2 job schedules
        $jobSpec1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobSpecification
        $jobSpec1.PoolInformation = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
        $jobSpec1.PoolInformation.PoolId = "testPool"
        $schedule1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSSchedule
        New-AzBatchJobSchedule -Id $jsId1 -JobSpecification $jobSpec1 -Schedule $schedule1 -BatchContext $context

        $jobSpec2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobSpecification
        $jobSpec2.PoolInformation = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
        $jobSpec2.PoolInformation.PoolId = "testPool2"
        $schedule2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSSchedule
        $schedule2.DoNotRunUntil = New-Object System.DateTime -ArgumentList @(2024, 12, 01, 12, 30, 0)
        New-AzBatchJobSchedule -Id $jsId2 -JobSpecification $jobSpec2 -Schedule $schedule2 -BatchContext $context

        # List the job schedules to ensure they were created
        $jobSchedules = Get-AzBatchJobSchedule -Filter "id eq '$jsId1' or id eq '$jsId2'" -BatchContext $context
        $jobSchedule1 = $jobSchedules | Where-Object { $_.Id -eq $jsId1 }
        $jobSchedule2 = $jobSchedules | Where-Object { $_.Id -eq $jsId2 }
        Assert-NotNull $jobSchedule1
        Assert-NotNull $jobSchedule2

        # Update a job schedule
        $jobSchedule2.Schedule.DoNotRunUntil = $newDoNotRunUntil = New-Object System.DateTime -ArgumentList @(2025, 01, 01, 12, 30, 0)
        $jobSchedule2 | Set-AzBatchJobSchedule -BatchContext $context
        $updatedJobSchedule = Get-AzBatchJobSchedule -Id $jsId2 -BatchContext $context
        Assert-AreEqual $newDoNotRunUntil $updatedJobSchedule.Schedule.DoNotRunUntil
    }
    finally
    {
        # Delete the job schedules
        Remove-AzBatchJobSchedule -Id $jsId1 -Force -BatchContext $context
        Remove-AzBatchJobSchedule -Id $jsId2 -Force -BatchContext $context

        foreach ($js in Get-AzBatchJobSchedule -BatchContext $context)
        {
            Assert-True { ($js.Id -ne $jsId1 -and $js.Id -ne $jsId2) -or ($js.State.ToString().ToLower() -eq 'deleting') }
        }
    }
}

<#
.SYNOPSIS
Tests disabling, enabling, and terminating a job schedule
#>
function Test-DisableEnableTerminateJobSchedule
{
    param([string]$jobScheduleId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    Disable-AzBatchJobSchedule $jobScheduleId -BatchContext $context

    # Verify the job schedule was Disabled
    $jobSchedule = Get-AzBatchJobSchedule $jobScheduleId -BatchContext $context
    Assert-AreEqual 'Disabled' $jobSchedule.State

    $jobSchedule | Enable-AzBatchJobSchedule -BatchContext $context

    # Verify the job schedule is Active
    $jobSchedule = Get-AzBatchJobSchedule -Filter "id eq '$jobScheduleId'" -BatchContext $context
    Assert-AreEqual 'Active' $jobSchedule.State

    # Terminate the job schedule
    $jobSchedule | Stop-AzBatchJobSchedule -BatchContext $context

    # Verify the job schedule was terminated
    $jobSchedule = Get-AzBatchJobSchedule $jobScheduleId -BatchContext $context
    Assert-True { ($jobSchedule.State.ToString().ToLower() -eq 'terminating') -or ($jobSchedule.State.ToString().ToLower() -eq 'completed') }
}