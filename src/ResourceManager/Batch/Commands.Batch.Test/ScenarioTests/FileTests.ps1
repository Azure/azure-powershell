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
Tests querying for a Batch node file by task by name
#>
function Test-GetNodeFileByTaskByName
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$nodeFileName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFile = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context

	Assert-AreEqual $nodeFileName $nodeFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch node files by task using a filter
#>
function Test-ListNodeFilesByTaskByFilter
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$nodeFilePrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$nodeFilePrefix" + "')"

	$nodeFiles = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $nodeFiles.Length
	foreach($nodeFile in $nodeFiles)
	{
		Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
	}

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $jobId $taskId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -Task $task -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $nodeFiles.Length
	foreach($nodeFile in $nodeFiles)
	{
		Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch node files by task and supplying a max count
#>
function Test-ListNodeFilesByTaskWithMaxCount
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFiles = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $nodeFiles.Length

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $jobId $taskId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -Task $task -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $nodeFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch node files by task with the Recursive switch
#>
function Test-ListNodeFilesByTaskRecursive
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$newfile)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'wd')"
	$nodeFiles = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Filter $filter -BatchContext $context

	# Only the directory itself is returned
	Assert-AreEqual 1 $nodeFiles.Length
	Assert-True { $nodeFiles[0].IsDirectory }

	# Verify the new file is returned when using the Recursive switch
	$nodeFiles = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Filter $filter -Recursive -BatchContext $context

	Assert-AreEqual 2 $nodeFiles.Length
	$file = $nodeFiles | Where-Object { $_.IsDirectory -eq $false }
	Assert-AreEqual "wd\$newFile" $file.Name
}

<#
.SYNOPSIS
Tests querying for all node files under a task
#>
function Test-ListAllNodeFilesByTask
{
	param([string]$accountName, [string] $jobId, [string]$taskId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFiles = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Filter $null -BatchContext $context

	Assert-AreEqual $count $nodeFiles.Length

	# Verify parent object parameter set also works
	$task = Get-AzureBatchTask_ST $jobId $taskId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -Task $task -BatchContext $context

	Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListNodeFileByTaskPipeline
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get Task into Get Node File
	$nodeFiles = Get-AzureBatchTask_ST -JobId $jobId -Id $taskId -BatchContext $context | Get-AzureBatchNodeFile_ST -BatchContext $context
	Assert-AreEqual $count $nodeFiles.Length

	# Get Job into Get Task into Get Node file
	$nodeFiles = Get-AzureBatchJob_ST $jobId -BatchContext $context | Get-AzureBatchTask_ST -BatchContext $context | Get-AzureBatchNodeFile_ST -BatchContext $context
	Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests downloading node file contents by task by name
#>
function Test-GetNodeFileContentByTaskByName
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$nodeFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		Get-AzureBatchNodeFileContent_ST -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context -DestinationStream $stream
		
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
Tests downloading node file contents by task using the pipeline
#>
function Test-GetNodeFileContentByTaskPipeline
{
	param([string]$accountName, [string]$jobId, [string]$taskId, [string]$nodeFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		$nodeFile = Get-AzureBatchNodeFile_ST -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context
		$nodeFile | Get-AzureBatchNodeFileContent_ST -BatchContext $context -DestinationStream $stream
		
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
Tests querying for a Batch node file by compute node by name
#>
function Test-GetNodeFileByComputeNodeByName
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$nodeFileName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFile = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context

	Assert-AreEqual $nodeFileName $nodeFile.Name

	# Verify positional parameters also work
	$nodeFile = Get-AzureBatchNodeFile_ST $poolId $computeNodeId $nodeFileName -BatchContext $context

	Assert-AreEqual $nodeFileName $nodeFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch node files by compute node using a filter
#>
function Test-ListNodeFilesByComputeNodeByFilter
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$nodeFilePrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$nodeFilePrefix" + "')"

	$nodeFiles = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $nodeFiles.Length
	foreach($nodeFile in $nodeFiles)
	{
		Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
	}

	# Verify parent object parameter set also works
	$computeNode = Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -ComputeNode $computeNode -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $nodeFiles.Length
	foreach($nodeFile in $nodeFiles)
	{
		Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch node files by compute node and supplying a max count
#>
function Test-ListNodeFilesByComputeNodeWithMaxCount
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFiles = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $nodeFiles.Length

	# Verify parent object parameter set also works
	$computeNode = Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -ComputeNode $computeNode -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $nodeFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch node files by compute node with the Recursive switch
#>
function Test-ListNodeFilesByComputeNodeRecursive
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$startupFolder, [string]$recursiveCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "startswith(name,'" + "$startupFolder" + "')"
	$nodeFiles = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -BatchContext $context

	# Only the directory itself is returned
	Assert-AreEqual 1 $nodeFiles.Length
	Assert-True { $nodeFiles[0].IsDirectory }

	# Verify the start task node files are returned when using the Recursive switch
	$nodeFiles = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -Recursive -BatchContext $context

	Assert-AreEqual $recursiveCount $nodeFiles.Length 
	$files = $nodeFiles | Where-Object { $_.Name.StartsWith("startup\st") -eq $true }
	Assert-AreEqual 2 $files.Length # stdout, stderr
}

<#
.SYNOPSIS
Tests querying for all node files under a compute node
#>
function Test-ListAllNodeFilesByComputeNode
{
	param([string]$accountName, [string]$poolId, [string] $computeNodeId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$nodeFiles = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -BatchContext $context

	Assert-AreEqual $count $nodeFiles.Length

	# Verify parent object parameter set also works
	$computeNode = Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context
	$nodeFiles = Get-AzureBatchNodeFile_ST -ComputeNode $computeNode -BatchContext $context

	Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListNodeFileByComputeNodePipeline
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get Compute Node into Get Node File
	$nodeFiles = Get-AzureBatchComputeNode_ST -PoolId $poolId -Id $computeNodeId -BatchContext $context | Get-AzureBatchNodeFile_ST -BatchContext $context
	Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests downloading node file contents by compute node by name
#>
function Test-GetNodeFileContentByComputeNodeByName
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$nodeFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		Get-AzureBatchNodeFileContent_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context -DestinationStream $stream
		
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
		Get-AzureBatchNodeFileContent_ST $poolId $computeNodeId $nodeFileName -BatchContext $context -DestinationStream $stream

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
Tests downloading node file contents by compute node using the pipeline
#>
function Test-GetNodeFileContentByComputeNodePipeline
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$nodeFileName, [string]$fileContent)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 

	try
	{
		$nodeFile = Get-AzureBatchNodeFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context
		$nodeFile | Get-AzureBatchNodeFileContent_ST -BatchContext $context -DestinationStream $stream
		
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
Tests downloading a Remote Desktop Protocol file by compute node id
#>
function Test-GetRDPFileById
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 
	$rdpContents = "full address"

	try
	{
		Get-AzureBatchRemoteDesktopProtocolFile_ST -PoolId $poolId -ComputeNodeId $computeNodeId -BatchContext $context -DestinationStream $stream
		
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
		Get-AzureBatchRemoteDesktopProtocolFile_ST $poolId $computeNodeId -BatchContext $context -DestinationStream $stream

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
Tests downloading a Remote DesktopProtocol file using the pipeline
#>
function Test-GetRDPFilePipeline
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$stream = New-Object System.IO.MemoryStream 
	$rdpContents = "full address"

	try
	{
		$computeNode = Get-AzureBatchComputeNode_ST -PoolId $poolId -Id $computeNodeId -BatchContext $context
		$computeNode | Get-AzureBatchRemoteDesktopProtocolFile_ST -BatchContext $context -DestinationStream $stream
		
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