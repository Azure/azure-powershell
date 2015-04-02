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
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		Get-AzureBatchTaskFileContent_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -BatchContext $context -MemStream $stream
		
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
		Get-AzureBatchTaskFileContent_ST $wiName $jobName $taskName $taskFileName -BatchContext $context -MemStream $stream

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
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		$taskFile = Get-AzureBatchTaskFile_ST -WorkItemName $wiName -JobName $jobName -TaskName $taskName -Name $taskFileName -BatchContext $context
		$taskFile | Get-AzureBatchTaskFileContent_ST -BatchContext $context -MemStream $stream
		
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
Tests querying for a Batch vm file by name
#>
function Test-GetVMFileByName
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$vmFileName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vmFile = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -Name $vmFileName -BatchContext $context

	Assert-AreEqual $vmFileName $vmFile.Name

	# Verify positional parameters also work
	$vmFile = Get-AzureBatchVMFile_ST $poolName $vmName $vmFileName -BatchContext $context

	Assert-AreEqual $vmFileName $vmFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch vm files using a filter
#>
function Test-ListVMFilesByFilter
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$vmFilePrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$vmFilePrefix" + "')"

	$vmFiles = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $vmFiles.Length
	foreach($vmFile in $vmFiles)
	{
		Assert-True { $vmFile.Name.StartsWith("$vmFilePrefix") }
	}

	# Verify parent object parameter set also works
	$vm = Get-AzureBatchVM_ST $poolName $vmName -BatchContext $context
	$vmFiles = Get-AzureBatchVMFile_ST -VM $vm -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $vmFiles.Length
	foreach($vmFile in $vmFiles)
	{
		Assert-True { $vmFile.Name.StartsWith("$vmFilePrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch vm files and supplying a max count
#>
function Test-ListVMFilesWithMaxCount
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vmFiles = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $vmFiles.Length

	# Verify parent object parameter set also works
	$vm = Get-AzureBatchVM_ST $poolName $vmName -BatchContext $context
	$vmFiles = Get-AzureBatchVMFile_ST -VM $vm -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $vmFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch vm files with the Recursive switch
#>
function Test-ListVMFilesRecursive
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$startupFolder, [string]$recursiveCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$startupFolder" + "')"
	$vmFiles = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -Filter $filter -BatchContext $context

	# Only the directory itself is returned
	Assert-AreEqual 1 $vmFiles.Length
	Assert-True { $vmFiles[0].IsDirectory }

	# Verify the start task vm files are returned when using the Recursive switch
	$vmFiles = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -Filter $filter -Recursive -BatchContext $context

	Assert-AreEqual $recursiveCount $vmFiles.Length 
	$files = $vmFiles | Where-Object { $_.Name.StartsWith("startup\st") -eq $true }
	Assert-AreEqual 2 $files.Length # stdout, stderr
}

<#
.SYNOPSIS
Tests querying for all vm files under a VM
#>
function Test-ListAllVMFiles
{
	param([string]$accountName, [string]$poolName, [string] $vmName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vmFiles = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -BatchContext $context

	Assert-AreEqual $count $vmFiles.Length

	# Verify parent object parameter set also works
	$vm = Get-AzureBatchVM_ST $poolName $vmName -BatchContext $context
	$vmFiles = Get-AzureBatchVMFile_ST -VM $vm -BatchContext $context

	Assert-AreEqual $count $vmFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListVMFilePipeline
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get VM into Get VM File
	$vmFiles = Get-AzureBatchVM_ST -PoolName $poolName -Name $vmName -BatchContext $context | Get-AzureBatchVMFile_ST -BatchContext $context
	Assert-AreEqual $count $vmFiles.Length
}

<#
.SYNOPSIS
Tests downloading vm file contents by name
#>
function Test-GetVMFileContentByName
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$vmFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		Get-AzureBatchVMFileContent_ST -PoolName $poolName -VMName $vmName -Name $vmFileName -BatchContext $context -MemStream $stream
		
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
		Get-AzureBatchVMFileContent_ST $poolName $vmName $vmFileName -BatchContext $context -MemStream $stream

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
Tests downloading vm file contents using the pipeline
#>
function Test-GetVMFileContentPipeline
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$vmFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		$vmFile = Get-AzureBatchVMFile_ST -PoolName $poolName -VMName $vmName -Name $vmFileName -BatchContext $context
		$vmFile | Get-AzureBatchVMFileContent_ST -BatchContext $context -MemStream $stream
		
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
Tests downloading an RDP file by name
#>
function Test-GetRDPFileByName
{
	param([string]$accountName, [string]$poolName, [string]$vmName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 
	$rdpContents = "full address"

	try
	{
		Get-AzureBatchRDPFile_ST -PoolName $poolName -VMName $vmName -BatchContext $context -MemStream $stream
		
		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Verify RDP file contains some expected text
		Assert-True { $downloadedContents.Contains($rdpContents) }
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
		Get-AzureBatchRDPFile_ST $poolName $vmName -BatchContext $context -MemStream $stream

		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Verify RDP file contains some expected text
		Assert-True { $downloadedContents.Contains($rdpContents) }
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
Tests downloading an RDP file using the pipeline
#>
function Test-GetRDPFilePipeline
{
	param([string]$accountName, [string]$poolName, [string]$vmName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 
	$rdpContents = "full address"

	try
	{
		$vm = Get-AzureBatchVM_ST -PoolName $poolName -Name $vmName -BatchContext $context
		$vm | Get-AzureBatchRDPFile_ST -BatchContext $context -MemStream $stream
		
		$stream.Position = 0
		$sr = New-Object System.IO.StreamReader $stream
		$downloadedContents = $sr.ReadToEnd()

		# Verify RDP file contains some expected text
		Assert-True { $downloadedContents.Contains($rdpContents) }
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