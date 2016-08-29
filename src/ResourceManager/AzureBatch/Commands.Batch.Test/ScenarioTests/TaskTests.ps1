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
Tests creating a Task
#>
function Test-CreateTask
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $taskId1 = "simple"
    $taskId2= "complex"
    $cmd = "cmd /c dir /s"

    # Create a simple task and verify pipeline
    Get-AzureBatchJob -Id $jobId -BatchContext $context | New-AzureBatchTask -Id $taskId1 -CommandLine $cmd -BatchContext $context
    $task1 = Get-AzureBatchTask -JobId $jobId -Id $taskId1 -BatchContext $context

    # Verify created task matches expectations
    Assert-AreEqual $taskId1 $task1.Id
    Assert-AreEqual $cmd $task1.CommandLine

    # Create a complicated task
	$affinityId = "affinityId"
    $affinityInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSAffinityInformation -ArgumentList @($affinityId)

    $taskConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(1),[TimeSpan]::FromDays(2),5)
    $maxWallClockTime = $taskConstraints.MaxWallClockTime
    $retentionTime = $taskConstraints.RetentionTime
    $maxRetryCount = $taskConstraints.MaxRetryCount

    $resourceFiles = @{"file1"="https://testacct.blob.core.windows.net/"}

    $envSettings = @{"env1"="value1";"env2"="value2"}

    $numInstances = 3
    $multiInstanceSettings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @($numInstances)
    $multiInstanceSettings.CoordinationCommandLine = $coordinationCommandLine = "cmd /c echo coordinating"
    $multiInstanceSettings.CommonResourceFiles = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
    $commonResourceBlob = "https://common.blob.core.windows.net/"
    $commonResourceFile = "common.exe"
    $commonResource = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList @($commonResourceBlob,$commonResourceFile)
    $multiInstanceSettings.CommonResourceFiles.Add($commonResource)

    New-AzureBatchTask -JobId $jobId -Id $taskId2 -CommandLine $cmd -EnvironmentSettings $envSettings -ResourceFiles $resourceFiles -AffinityInformation $affinityInfo -Constraints $taskConstraints -MultiInstanceSettings $multiInstanceSettings -BatchContext $context
        
    $task2 = Get-AzureBatchTask -JobId $jobId -Id $taskId2 -BatchContext $context
        
    # Verify created task matches expectations
    Assert-AreEqual $taskId2 $task2.Id
    Assert-AreEqual $cmd $task2.CommandLine
    Assert-AreEqual $false $task2.RunElevated
    Assert-AreEqual $affinityId $task2.AffinityInformation.AffinityId
    Assert-AreEqual $maxWallClockTime $task2.Constraints.MaxWallClockTime
    Assert-AreEqual $retentionTime $task2.Constraints.RetentionTime
    Assert-AreEqual $maxRetryCount $task2.Constraints.MaxRetryCount
    Assert-AreEqual $resourceFiles.Count $task2.ResourceFiles.Count
    foreach($r in $task2.ResourceFiles)
    {
        Assert-AreEqual $resourceFiles[$r.FilePath] $r.BlobSource
    }
    Assert-AreEqual $envSettings.Count $task2.EnvironmentSettings.Count
    foreach($e in $task2.EnvironmentSettings)
    {
        Assert-AreEqual $envSettings[$e.Name] $e.Value
    }
    Assert-AreEqual $numInstances $task2.MultiInstanceSettings.NumberOfInstances
    Assert-AreEqual $coordinationCommandLine $task2.MultiInstanceSettings.CoordinationCommandLine
    Assert-AreEqual 1 $task2.MultiInstanceSettings.CommonResourceFiles.Count
    Assert-AreEqual $commonResourceBlob $task2.MultiInstanceSettings.CommonResourceFiles[0].BlobSource
    Assert-AreEqual $commonResourceFile $task2.MultiInstanceSettings.CommonResourceFiles[0].FilePath
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
    $multiInstanceSettings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @($numInstances)
    $multiInstanceSettings.CoordinationCommandLine = $coordinationCommandLine = "cmd /c echo coordinating"
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
Tests querying for a Batch task by id
#>
function Test-GetTaskById
{
    param([string]$jobId, [string]$taskId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $task = Get-AzureBatchTask -JobId $jobId -Id $taskId -BatchContext $context

    Assert-AreEqual $taskId $task.Id

    # Verify positional parameters also work
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context

    Assert-AreEqual $taskId $task.Id
}

<#
.SYNOPSIS
Tests querying for Batch tasks using a filter
#>
function Test-ListTasksByFilter
{
    param([string]$jobId, [string]$taskPrefix, [string]$matches)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(id,'" + "$taskPrefix" + "')"

    $tasks = Get-AzureBatchTask -JobId $jobId -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $tasks.Length
    foreach($task in $tasks)
    {
        Assert-True { $task.Id.StartsWith("$taskPrefix") }
    }

    # Verify parent object parameter set also works
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    $tasks = Get-AzureBatchTask -Job $job -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $tasks.Length
    foreach($task in $tasks)
    {
        Assert-True { $task.Id.StartsWith("$taskPrefix") }
    }
}

<#
.SYNOPSIS
Tests querying for tasks using a select clause
#>
function Test-GetAndListTasksWithSelect
{
    param([string]$jobId, [string]$taskId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "id eq '$taskId'"
    $selectClause = "id,state"

    # Test with Get task API
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context
    Assert-AreNotEqual $null $task.CommandLine
    Assert-AreEqual $taskId $task.Id

    $task = Get-AzureBatchTask $jobId $taskId -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $task.CommandLine
    Assert-AreEqual $taskId $task.Id

    # Test with List tasks API
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    $task = $job | Get-AzureBatchTask -Filter $filter -BatchContext $context
    Assert-AreNotEqual $null $task.CommandLine
    Assert-AreEqual $taskId $task.Id

    $task = $job | Get-AzureBatchTask -Filter $filter -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $task.CommandLine
    Assert-AreEqual $taskId $task.Id
}

<#
.SYNOPSIS
Tests querying for Batch tasks and supplying a max count
#>
function Test-ListTasksWithMaxCount
{
    param([string]$jobId, [string]$maxCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $tasks = Get-AzureBatchTask -JobId $jobId -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $tasks.Length

    # Verify parent object parameter set also works
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    $tasks = Get-AzureBatchTask -Job $job -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $tasks.Length
}

<#
.SYNOPSIS
Tests querying for all tasks under a job
#>
function Test-ListAllTasks
{
    param([string] $jobId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $tasks = Get-AzureBatchTask -JobId $jobId -BatchContext $context

    Assert-AreEqual $count $tasks.Length

    # Verify parent object parameter set also works
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    $tasks = Get-AzureBatchTask -Job $job -BatchContext $context

    Assert-AreEqual $count $tasks.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListTaskPipeline
{
    param([string]$jobId, [string]$taskId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Get Job into Get Task
    $task = Get-AzureBatchJob -Id $jobId -BatchContext $context | Get-AzureBatchTask -BatchContext $context
    Assert-AreEqual $taskId $task.Id
}

<#
.SYNOPSIS
Tests updating a task
#>
function Test-UpdateTask
{
    param([string]$jobId, [string]$taskId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context

    # Define new task constraints
    $constraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(10),[TimeSpan]::FromDays(2),5)
    $maxWallClockTime = $constraints.MaxWallClockTime
    $retentionTime = $constraints.RetentionTime
    $maxRetryCount = $constraints.MaxRetryCount

    # Update and refresh task
    $task.Constraints = $constraints
    $task | Set-AzureBatchTask -BatchContext $context
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context

    # Verify task was updated
    Assert-AreEqual $maxWallClockTime $task.Constraints.MaxWallClockTime
    Assert-AreEqual $retentionTime $task.Constraints.RetentionTime
    Assert-AreEqual $maxRetryCount $constraints.MaxRetryCount
}

<#
.SYNOPSIS
Tests deleting a task
#>
function Test-DeleteTask
{
    param([string]$jobId, [string]$taskId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Verify the task exists
    $tasks = Get-AzureBatchTask -JobId $jobId -BatchContext $context
    Assert-AreEqual 1 $tasks.Count

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchTask -JobId $jobId -Id $taskId -BatchContext $context | Remove-AzureBatchTask -Force -BatchContext $context
    }
    else
    {
        Remove-AzureBatchTask -JobId $jobId -Id $taskId -Force -BatchContext $context
    }

    # Verify the task was deleted
    $tasks = Get-AzureBatchTask -JobId $jobId -BatchContext $context
    Assert-Null $tasks
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
