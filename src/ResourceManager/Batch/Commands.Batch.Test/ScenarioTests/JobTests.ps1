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
Tests that calling Get-AzureBatchJob without required parameters throws error
#>
function Test-GetJobRequiredParameters
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	Assert-Throws { Get-AzureBatchJob_ST -BatchContext $context }
}

<#
.SYNOPSIS
Tests querying for a Batch Job by name
#>
function Test-GetJobByName
{
	param([string]$accountName, [string]$wiName, [string]$jobName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$job = Get-AzureBatchJob_ST -WorkItemName $wiName -Name $jobName -BatchContext $context

	Assert-AreEqual $jobName $job.Name

	# Verify positional parameters also work
	$job = Get-AzureBatchJob_ST $wiName $jobName -BatchContext $context

	Assert-AreEqual $jobName $job.Name
}

<#
.SYNOPSIS
Tests querying for Batch Jobs using a filter
#>
function Test-ListJobsByFilter
{
	param([string]$accountName, [string]$workItemName, [string]$state, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "state eq '" + "$state" + "'"

	$jobs = Get-AzureBatchJob_ST -WorkItemName $workItemName -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $jobs.Length
	foreach($job in $jobs)
	{
		Assert-AreEqual $state $job.State.ToString().ToLower()
	}

	# Verify parent object parameter set also works
	$workItem = Get-AzureBatchWorkItem_ST $workItemName -BatchContext $context
	$jobs = Get-AzureBatchJob_ST -WorkItem $workItem -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $jobs.Length
	foreach($job in $jobs)
	{
		Assert-AreEqual $state $job.State.ToString().ToLower()
	}
}

<#
.SYNOPSIS
Tests querying for Batch Jobs and supplying a max count
#>
function Test-ListJobsWithMaxCount
{
	param([string]$accountName, [string]$workItemName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobs = Get-AzureBatchJob_ST -WorkItemName $workItemName -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $jobs.Length

	# Verify parent object parameter set also works
	$workItem = Get-AzureBatchWorkItem_ST $workItemName -BatchContext $context
	$jobs = Get-AzureBatchJob_ST -WorkItem $workItem -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $jobs.Length
}

<#
.SYNOPSIS
Tests querying for all Jobs under a WorkItem
#>
function Test-ListAllJobs
{
	param([string]$accountName, [string]$workItemName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobs = Get-AzureBatchJob_ST -WorkItemName $workItemName -BatchContext $context

	Assert-AreEqual $count $jobs.Length

	# Verify parent object parameter set also works
	$workItem = Get-AzureBatchWorkItem_ST $workItemName -BatchContext $context
	$jobs = Get-AzureBatchJob_ST -WorkItem $workItem -BatchContext $context

	Assert-AreEqual $count $jobs.Length
}

<#
.SYNOPSIS
Tests piping Get-AzureBatchWorkItem into Get-AzureBatchJob
#>
function Test-ListJobPipeline
{
	param([string]$accountName, [string]$workItemName, [string]$jobName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$job = Get-AzureBatchWorkItem_ST -Name $workItemName -BatchContext $context | Get-AzureBatchJob_ST -BatchContext $context

	Assert-AreEqual $jobName $job.Name
}