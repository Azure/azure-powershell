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
	param([string]$accountName, [string]$jobId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	$taskId1 = "simple"
	$taskId2= "complex"
	$cmd = "cmd /c dir /s"

	# Create a simple task and verify pipeline
	Get-AzureBatchJob_ST -Id $jobId -BatchContext $context | New-AzureBatchTask_ST -Id $taskId1 -CommandLine $cmd -BatchContext $context
	$task1 = Get-AzureBatchTask_ST -JobId $jobId -Id $taskId1 -BatchContext $context

	# Verify created task matches expectations
	Assert-AreEqual $taskId1 $task1.Id
	Assert-AreEqual $cmd $task1.CommandLine

	# Create a complicated task
	$affinityInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSAffinityInformation
	$affinityInfo.AffinityId = $affinityId = "affinityId"

	$taskConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(1),[TimeSpan]::FromDays(2),5)
	$maxWallClockTime = $taskConstraints.MaxWallClockTime
	$retentionTime = $taskConstraints.RetentionTime
	$maxRetryCount = $taskConstraints.MaxRetryCount

	$resourceFiles = @{"file1"="https://testacct.blob.core.windows.net/"}

	$envSettings = @{"env1"="value1";"env2"="value2"}

	New-AzureBatchTask_ST -JobId $jobId -Id $taskId2 -CommandLine $cmd -RunElevated -EnvironmentSettings $envSettings -ResourceFiles $resourceFiles -AffinityInformation $affinityInfo -Constraints $taskConstraints -BatchContext $context
		
	$task2 = Get-AzureBatchTask_ST -JobId $jobId -Id $taskId2 -BatchContext $context
		
	# Verify created task matches expectations
	Assert-AreEqual $taskId2 $task2.Id
	Assert-AreEqual $cmd $task2.CommandLine
	Assert-AreEqual $true $task2.RunElevated
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
}

<#
.SYNOPSIS
Tests querying for a Batch task by id
#>
function Test-GetTaskById
{
	param([string]$accountName, [string]$jobId, [string]$taskId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$task = Get-AzureBatchTask_ST -JobId $jobId -Id $taskId -BatchContext $context

	Assert-AreEqual $taskId $task.Id

	# Verify positional parameters also work
	$task = Get-AzureBatchTask_ST $jobId $taskId -BatchContext $context

	Assert-AreEqual $taskId $task.Id
}

<#
.SYNOPSIS
Tests querying for Batch tasks using a filter
#>
function Test-ListTasksByFilter
{
	param([string]$accountName, [string]$jobId, [string]$taskPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(id,'" + "$taskPrefix" + "')"

	$tasks = Get-AzureBatchTask_ST -JobId $jobId -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $tasks.Length
	foreach($task in $tasks)
	{
		Assert-True { $task.Id.StartsWith("$taskPrefix") }
	}

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $tasks.Length
	foreach($task in $tasks)
	{
		Assert-True { $task.Id.StartsWith("$taskPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch tasks and supplying a max count
#>
function Test-ListTasksWithMaxCount
{
	param([string]$accountName, [string]$jobId, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$tasks = Get-AzureBatchTask_ST -JobId $jobId -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $tasks.Length

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $tasks.Length
}

<#
.SYNOPSIS
Tests querying for all tasks under a job
#>
function Test-ListAllTasks
{
	param([string]$accountName, [string] $jobId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$tasks = Get-AzureBatchTask_ST -JobId $jobId -BatchContext $context

	Assert-AreEqual $count $tasks.Length

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -BatchContext $context

	Assert-AreEqual $count $tasks.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListTaskPipeline
{
	param([string]$accountName, [string]$jobId, [string]$taskId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get Job into Get Task
	$task = Get-AzureBatchJob_ST -Id $jobId -BatchContext $context | Get-AzureBatchTask_ST -BatchContext $context
	Assert-AreEqual $taskId $task.Id
}

<#
.SYNOPSIS
Tests deleting a task
#>
function Test-DeleteTask
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the task exists
	$tasks = Get-AzureBatchTask_ST -JobId $jobId -BatchContext $context
	Assert-AreEqual 1 $tasks.Count

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchTask_ST -JobId $jobId -Id $taskId -BatchContext $context | Remove-AzureBatchTask_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchTask_ST -JobId $jobId -Id $taskId -Force -BatchContext $context
	}

	# Verify the task was deleted
	$tasks = Get-AzureBatchTask_ST -JobId $jobId -BatchContext $context
	Assert-Null $tasks
}