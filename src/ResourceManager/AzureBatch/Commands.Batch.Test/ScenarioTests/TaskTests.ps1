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
Tests Task CRUD operations
#>
function Test-TaskCRUD
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $taskId1 = "task1"
    $taskId2 = "task2"

    try
    {
        # Create 2 tasks
        New-AzureBatchTask -Id $taskId1 -JobId $jobId -CommandLine "cmd /c echo task1" -BatchContext $context
        New-AzureBatchTask -Id $taskId2 -JobId $jobId -CommandLine "cmd /c echo task2" -BatchContext $context

        # List the tasks to ensure they were created
        $tasks = Get-AzureBatchTask -JobId $jobId -Filter "id eq '$taskId1' or id eq '$taskId2'" -BatchContext $context
        $task1 = $tasks | Where-Object { $_.Id -eq $taskId1 }
        $task2 = $tasks | Where-Object { $_.Id -eq $taskId2 }
        Assert-NotNull $task1
        Assert-NotNull $task2

        # Update a task
        $maxTaskRetryCount = 3
        $task2.Constraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @($null, $null, 3)
        $task2 | Set-AzureBatchTask -BatchContext $context
        $updatedTask = Get-AzureBatchTask -JobId $jobId -Id $taskId2 -BatchContext $context
        Assert-AreEqual $maxTaskRetryCount $updatedTask.Constraints.MaxTaskRetryCount
    }
    finally
    {
        # Delete the tasks
        Get-AzureBatchTask -JobId $jobId -BatchContext $context | Remove-AzureBatchTask -Force -BatchContext $context

        # Verify the tasks were deleted
        $tasks = Get-AzureBatchTask -JobId $jobId -BatchContext $context
        Assert-Null $tasks
    }
}

<#
.SYNOPSIS
Tests creating a collection of tasks
#>
function Test-CreateTaskCollection
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $taskId1 = "simple1"
    $taskId2 = "simple2"

    $cmd = "cmd /c dir /s"

    $task1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudTask($taskId1, $cmd)
    $task2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudTask($taskId2, $cmd)

    $taskCollection = @($task1, $task2)

    # Create a simple task collection and verify pipeline
    Get-AzureBatchJob -Id $jobId -BatchContext $context | New-AzureBatchTask -Tasks $taskCollection -BatchContext $context
    $task1 = Get-AzureBatchTask -JobId $jobId -Id $taskId1 -BatchContext $context
    $task2 = Get-AzureBatchTask -JobId $jobId -Id $taskId2 -BatchContext $context

    # Verify created task matches expectations
    Assert-AreEqual $taskId1 $task1.Id
    Assert-AreEqual $cmd $task1.CommandLine
    Assert-AreEqual $taskId2 $task2.Id
    Assert-AreEqual $cmd $task2.CommandLine

    # Create a complicated task collection
    $affinityId = "affinityId"
    $affinityInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSAffinityInformation -ArgumentList @($affinityId)

    $taskConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(1),[TimeSpan]::FromDays(2),5)
    $maxWallClockTime = $taskConstraints.MaxWallClockTime
    $retentionTime = $taskConstraints.RetentionTime
    $maxRetryCount = $taskConstraints.MaxRetryCount

    $resourceFiles = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
    $file = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile("https://testacct.blob.core.windows.net/", "file1")
    $resourceFiles.Add($file)

    $envSettings = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
    $env1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting("env1", "value1")
    $env2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting("env2", "value2")
    $envSettings.Add($env1)
    $envSettings.Add($env2)

    $numInstances = 3
    $multiInstanceSettings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @("cmd /c echo coordinating", $numInstances)
    $coordinationCommandLine = $multiInstanceSettings.CoordinationCommandLine
    $multiInstanceSettings.CommonResourceFiles = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
    $commonResourceBlob = "https://common.blob.core.windows.net/"
    $commonResourceFile = "common.exe"
    $commonResource = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList @($commonResourceBlob,$commonResourceFile)
    $multiInstanceSettings.CommonResourceFiles.Add($commonResource)

    $taskId3 = "complex1"
    $taskId4 = "simple3"

    $task3 = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudTask($taskId3, $cmd)
    $task4 = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudTask($taskId4, $cmd)

    $task3.AffinityInformation = $affinityInfo
    $task3.Constraints = $taskConstraints
    $task3.MultiInstanceSettings = $multiInstanceSettings
    $task3.EnvironmentSettings = $envSettings
    $task3.ResourceFiles = $resourceFiles

    $taskCollection = @($task3, $task4)

    # Create a task collection with the job id
    New-AzureBatchTask -JobId $jobId -Tasks $taskCollection -BatchContext $context

    $task3 = Get-AzureBatchTask -JobId $jobId -Id $taskId3 -BatchContext $context
    $task4 = Get-AzureBatchTask -JobId $jobId -Id $taskId4 -BatchContext $context

    # Verify created task matches expectations
    Assert-AreEqual $taskId3 $task3.Id
    Assert-AreEqual $cmd $task3.CommandLine
    Assert-AreEqual $affinityId $task3.AffinityInformation.AffinityId
    Assert-AreEqual $maxWallClockTime $task3.Constraints.MaxWallClockTime
    Assert-AreEqual $retentionTime $task3.Constraints.RetentionTime
    Assert-AreEqual $maxRetryCount $task3.Constraints.MaxRetryCount
    Assert-AreEqual $resourceFiles.Count $task3.ResourceFiles.Count

    Assert-AreEqual $envSettings.Count $task3.EnvironmentSettings.Count
    Assert-AreEqual $numInstances $task3.MultiInstanceSettings.NumberOfInstances
    Assert-AreEqual $coordinationCommandLine $task3.MultiInstanceSettings.CoordinationCommandLine
    Assert-AreEqual 1 $task3.MultiInstanceSettings.CommonResourceFiles.Count
    Assert-AreEqual $commonResourceBlob $task3.MultiInstanceSettings.CommonResourceFiles[0].BlobSource
    Assert-AreEqual $commonResourceFile $task3.MultiInstanceSettings.CommonResourceFiles[0].FilePath

    Assert-AreEqual $taskId4 $task4.Id
    Assert-AreEqual $cmd $task4.CommandLine
}

<#
.SYNOPSIS
Tests terminating a task
#>
function Test-TerminateTask
{
    param([string]$jobId, [string]$taskId1, [string]$taskId2)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    Stop-AzureBatchTask $jobId $taskId1 -BatchContext $context
    Get-AzureBatchTask $jobId $taskId2 -BatchContext $context | Stop-AzureBatchTask -BatchContext $context

    # Verify the tasks were terminated
    foreach ($task in Get-AzureBatchTask $jobId -BatchContext $context)
    {
        Assert-AreEqual 'completed' $task.State.ToString().ToLower()
    }
}

<#
.SYNOPSIS
Tests querying for all subtasks under a task
#>
function Test-ListAllSubtasks
{
    param([string] $jobId, [string]$taskId, [string]$numInstances)

    $numSubTasksExpected = $numInstances - 1

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $subtasks = Get-AzureBatchSubtask $jobId $taskId -BatchContext $context

    Assert-AreEqual $numSubTasksExpected $subtasks.Length

    # Verify pipeline also works
    $subtasks = Get-AzureBatchTask $jobId $taskId -BatchContext $context | Get-AzureBatchSubtask -BatchContext $context

    Assert-AreEqual $numSubTasksExpected $subtasks.Length
}
