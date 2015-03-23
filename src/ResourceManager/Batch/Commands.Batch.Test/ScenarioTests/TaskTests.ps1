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
	param([string]$accountName, [string]$workItemName, [string]$jobName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	$taskName1 = "simple"
	$taskName2= "complex"
	$cmd = "cmd /c dir /s"

	# Create a simple Task and verify pipeline
	Get-AzureBatchJob_ST -WorkItemName $workItemName -Name $jobName -BatchContext $context | New-AzureBatchTask_ST -Name $taskName1 -CommandLine $cmd -BatchContext $context
	$task1 = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName1 -BatchContext $context

	# Verify created Task matches expectations
	Assert-AreEqual $taskName1 $task1.Name
	Assert-AreEqual $cmd $task1.CommandLine

	# Create a complicated Task
	$affinityInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSAffinityInformation
	$affinityInfo.AffinityId = $affinityId = "affinityId"

	$taskConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(1),[TimeSpan]::FromDays(2),5)
	$maxWallClockTime = $taskConstraints.MaxWallClockTime
	$retentionTime = $taskConstraints.RetentionTime
	$maxRetryCount = $taskConstraints.MaxRetryCount

	$resourceFiles = @{"file1"="https://testacct.blob.core.windows.net/"}

	$envSettings = @{"env1"="value1";"env2"="value2"}

	New-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName2 -CommandLine $cmd -RunElevated -EnvironmentSettings $envSettings -ResourceFiles $resourceFiles -AffinityInformation $affinityInfo -TaskConstraints $taskConstraints -BatchContext $context
		
	$task2 = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName2 -BatchContext $context
		
	# Verify created Task matches expectations
	Assert-AreEqual $taskName2 $task2.Name
	Assert-AreEqual $cmd $task2.CommandLine
	Assert-AreEqual $true $task2.RunElevated
	Assert-AreEqual $affinityId $task2.AffinityInformation.AffinityId
	Assert-AreEqual $maxWallClockTime $task2.TaskConstraints.MaxWallClockTime
	Assert-AreEqual $retentionTime $task2.TaskConstraints.RetentionTime
	Assert-AreEqual $maxRetryCount $task2.TaskConstraints.MaxRetryCount
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
Tests that calling Get-AzureBatchTask without required parameters throws error
#>
function Test-GetTaskRequiredParameters
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	Assert-Throws { Get-AzureBatchTask_ST -BatchContext $context }
	Assert-Throws { Get-AzureBatchTask_ST -WorkItemName "wi" -BatchContext $context }
	Assert-Throws { Get-AzureBatchTask_ST -JobName "job" -BatchContext $context }
}

<#
.SYNOPSIS
Tests querying for a Batch Task by name
#>
function Test-GetTaskByName
{
	param([string]$accountName, [string]$wiName, [string]$jobName, [string]$taskName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$task = Get-AzureBatchTask_ST -WorkItemName $wiName -JobName $jobName -Name $taskName -BatchContext $context

	Assert-AreEqual $taskName $task.Name

	# Verify positional parameters also work
	$task = Get-AzureBatchTask_ST $wiName $jobName $taskName -BatchContext $context

	Assert-AreEqual $taskName $task.Name
}

<#
.SYNOPSIS
Tests querying for Batch Tasks using a filter
#>
function Test-ListTasksByFilter
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$taskPrefix" + "')"

	$tasks = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $tasks.Length
	foreach($task in $tasks)
	{
		Assert-True { $task.Name.StartsWith("$taskPrefix") }
	}

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $workItemName $jobName -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $tasks.Length
	foreach($task in $tasks)
	{
		Assert-True { $task.Name.StartsWith("$taskPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch Tasks and supplying a max count
#>
function Test-ListTasksWithMaxCount
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$tasks = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $tasks.Length

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $workItemName $jobName -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $tasks.Length
}

<#
.SYNOPSIS
Tests querying for all Tasks under a WorkItem
#>
function Test-ListAllTasks
{
	param([string]$accountName, [string]$workItemName, [string] $jobName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$tasks = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -BatchContext $context

	Assert-AreEqual $count $tasks.Length

	# Verify parent object parameter set also works
	$job = Get-AzureBatchJob_ST $workItemName $jobName -BatchContext $context
	$tasks = Get-AzureBatchTask_ST -Job $job -BatchContext $context

	Assert-AreEqual $count $tasks.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListTaskPipeline
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get Job into Get Task
	$task = Get-AzureBatchJob_ST -WorkItemName $workItemName -Name $jobName -BatchContext $context | Get-AzureBatchTask_ST -BatchContext $context
	Assert-AreEqual $taskName $task.Name

	# Get WorkItem into Get Job into Get Task
	$task = Get-AzureBatchWorkItem_ST -Name $workItemName -BatchContext $context | Get-AzureBatchJob_ST -BatchContext $context | Get-AzureBatchTask_ST -BatchContext $context
	Assert-AreEqual $taskName $task.Name
}

<#
.SYNOPSIS
Tests deleting a Task
#>
function Test-DeleteTask
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the task exists
	$tasks = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -BatchContext $context
	Assert-AreEqual 1 $tasks.Count

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName -BatchContext $context | Remove-AzureBatchTask_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName -Force -BatchContext $context
	}

	# Verify the job was deleted
	$tasks = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -BatchContext $context
	Assert-Null $tasks
}