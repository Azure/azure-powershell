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
Tests querying for a Batch Task file by name
#>
function Test-GetTaskFileByName
{
	param([string]$accountName, [string]$wiName, [string]$jobName, [string]$taskName, [string]$taskFileName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$taskFile = Get-AzureBatchTaskFile_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -BatchContext $context

	Assert-AreEqual $taskFileName $taskFile.Name

	# Verify positional parameters also work
	$task = Get-AzureBatchTaskFile_ST $wiName $jobName $taskName $taskFileName -BatchContext $context

	Assert-AreEqual $taskFileName $taskFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch Task Files using a filter
#>
function Test-ListTaskFilesByFilter
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName, [string]$taskFilePrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$taskFilePrefix" + "')"

	$taskFiles = Get-AzureBatchTaskFile_ST -WorkItemName $workItemName -JobName $jobName -TaskName $taskName -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $taskFiles.Length
	foreach($taskFile in $taskFiles)
	{
		Assert-True { $taskFile.Name.StartsWith("$taskFilePrefix") }
	}

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $workItemName $jobName $taskName -BatchContext $context
	$taskFiles = Get-AzureBatchTaskFile_ST -Task $task -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $taskFiles.Length
	foreach($taskFile in $taskFiles)
	{
		Assert-True { $taskFile.Name.StartsWith("$taskFilePrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch Task Files and supplying a max count
#>
function Test-ListTaskFilesWithMaxCount
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$taskFiles = Get-AzureBatchTaskFile_ST -WorkItemName $workItemName -JobName $jobName -TaskName $taskName -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $taskFiles.Length

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $workItemName $jobName $taskName -BatchContext $context
	$taskFiles = Get-AzureBatchTaskFile_ST -Task $task -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $taskFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch Task Files with the Recursive switch
#>
function Test-ListTaskFilesRecursive
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName, [string]$newfile)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'wd')"
	$taskFiles = Get-AzureBatchTaskFile_ST -WorkItemName $workItemName -JobName $jobName -TaskName $taskName -Filter $filter -BatchContext $context

	# Only the directory itself is returned
	Assert-AreEqual 1 $taskFiles.Length
	Assert-True { $taskFiles[0].IsDirectory }

	# Verify the new file is returned when using the Recursive switch
	$taskFiles = Get-AzureBatchTaskFile_ST -WorkItemName $workItemName -JobName $jobName -TaskName $taskName -Filter $filter -Recursive -BatchContext $context

	Assert-AreEqual 2 $taskFiles.Length
	$file = $taskFiles | Where-Object { $_.IsDirectory -eq $false }
	Assert-AreEqual "wd\$newFile" $file.Name
}

<#
.SYNOPSIS
Tests querying for all Task Files under a Task
#>
function Test-ListAllTaskFiles
{
	param([string]$accountName, [string]$workItemName, [string] $jobName, [string]$taskName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$taskFiles = Get-AzureBatchTaskFile_ST -WorkItemName $workItemName -JobName $jobName -TaskName $taskName -BatchContext $context

	Assert-AreEqual $count $taskFiles.Length

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $workItemName $jobName $taskName -BatchContext $context
	$taskFiles = Get-AzureBatchTaskFile_ST -Task $task -BatchContext $context

	Assert-AreEqual $count $taskFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListTaskFilePipeline
{
	param([string]$accountName, [string]$workItemName, [string]$jobName, [string]$taskName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get Task into Get Task File
	$taskFiles = Get-AzureBatchTask_ST -WorkItemName $workItemName -JobName $jobName -Name $taskName -BatchContext $context | Get-AzureBatchTaskFile_ST -BatchContext $context
	Assert-AreEqual $count $taskFiles.Length

	# Get WorkItem into Get Job into Get Task into Get Task file
	$taskFiles = Get-AzureBatchWorkItem_ST -Name $workItemName -BatchContext $context | Get-AzureBatchJob_ST -BatchContext $context | Get-AzureBatchTask_ST -BatchContext $context | Get-AzureBatchTaskFile_ST -BatchContext $context
	Assert-AreEqual $count $taskFiles.Length
}

<#
.SYNOPSIS
Tests downloading Task file contents by name
#>
function Test-GetTaskFileContentByName
{
	param([string]$accountName, [string]$wiName, [string]$jobName, [string]$taskName, [string]$taskFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$path = "localFile.txt"
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		Get-AzureBatchTaskFileContent_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -DestinationPath $path -BatchContext $context -MemStream $stream
		
		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Don't do strict equality check since extra newline characters get added to the end of the file
		Assert-True { $downloadedContents.Contains($fileContent) }
	}
	finally
	{
		if ($sr -ne $null)
		{
			$sr.Dispose()
		}
		$stream.Dispose()
	}

	# Verify positional parameters also work
	$stream = New-Object System.IO.MemoryStream 
	try
	{
		Get-AzureBatchTaskFileContent_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -DestinationPath $path -BatchContext $context -MemStream $stream

		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Don't do strict equality check since extra newline characters get added to the end of the file
		Assert-True { $downloadedContents.Contains($fileContent) }
	}
	finally
	{
		if ($sr -ne $null)
		{
			$sr.Dispose()
		}
		$stream.Dispose()
	}
}

<#
.SYNOPSIS
Tests downloading Task file contents using the pipeline
#>
function Test-GetTaskFileContentPipeline
{
	param([string]$accountName, [string]$wiName, [string]$jobName, [string]$taskName, [string]$taskFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$path = "localFile.txt"
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		$taskFile = Get-AzureBatchTaskFile_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -BatchContext $context
		$taskFile | Get-AzureBatchTaskFileContent_ST -DestinationPath $path -BatchContext $context -MemStream $stream
		
		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Don't do strict equality check since extra newline characters get added to the end of the file
		Assert-True { $downloadedContents.Contains($fileContent) }
	}
	finally
	{
		if ($sr -ne $null)
		{
			$sr.Dispose()
		}
		$stream.Dispose()
	}
}