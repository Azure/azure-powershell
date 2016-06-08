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
    param([string]$jobId, [string]$taskId, [string]$nodeFileName)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFile = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context

    Assert-AreEqual $nodeFileName $nodeFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch node files by task using a filter
#>
function Test-ListNodeFilesByTaskByFilter
{
    param([string]$jobId, [string]$taskId, [string]$nodeFilePrefix, [string]$matches)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(name,'" + "$nodeFilePrefix" + "')"

    $nodeFiles = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $nodeFiles.Length
    foreach($nodeFile in $nodeFiles)
    {
        Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
    }

    # Verify parent object parameter set also works
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -Task $task -Filter $filter -BatchContext $context

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
    param([string]$jobId, [string]$taskId, [string]$maxCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFiles = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $nodeFiles.Length

    # Verify parent object parameter set also works
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -Task $task -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $nodeFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch node files by task with the Recursive switch
#>
function Test-ListNodeFilesByTaskRecursive
{
    param([string]$jobId, [string]$taskId, [string]$newfile)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(name,'wd')"
    $nodeFiles = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter $filter -BatchContext $context

    # Only the directory itself is returned
    Assert-AreEqual 1 $nodeFiles.Length
    Assert-True { $nodeFiles[0].IsDirectory }

    # Verify the new file is returned when using the Recursive switch
    $nodeFiles = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter $filter -Recursive -BatchContext $context

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
    param([string] $jobId, [string]$taskId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFiles = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter $null -BatchContext $context

    Assert-AreEqual $count $nodeFiles.Length

    # Verify parent object parameter set also works
    $task = Get-AzureBatchTask $jobId $taskId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -Task $task -BatchContext $context

    Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListNodeFileByTaskPipeline
{
    param([string]$jobId, [string]$taskId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Get Task into Get Node File
    $nodeFiles = Get-AzureBatchTask -JobId $jobId -Id $taskId -BatchContext $context | Get-AzureBatchNodeFile -BatchContext $context
    Assert-AreEqual $count $nodeFiles.Length

    # Get Job into Get Task into Get Node file
    $nodeFiles = Get-AzureBatchJob $jobId -BatchContext $context | Get-AzureBatchTask -BatchContext $context | Get-AzureBatchNodeFile -BatchContext $context
    Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests downloading node file contents by task by name
#>
function Test-GetNodeFileContentByTaskByName
{
    param([string]$jobId, [string]$taskId, [string]$nodeFileName, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        Get-AzureBatchNodeFileContent -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context -DestinationStream $stream
        
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
    param([string]$jobId, [string]$taskId, [string]$nodeFileName, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        $nodeFile = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Name $nodeFileName -BatchContext $context
        $nodeFile | Get-AzureBatchNodeFileContent -BatchContext $context -DestinationStream $stream
        
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
    param([string]$poolId, [string]$computeNodeId, [string]$nodeFileName)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFile = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context

    Assert-AreEqual $nodeFileName $nodeFile.Name

    # Verify positional parameters also work
    $nodeFile = Get-AzureBatchNodeFile $poolId $computeNodeId $nodeFileName -BatchContext $context

    Assert-AreEqual $nodeFileName $nodeFile.Name
}

<#
.SYNOPSIS
Tests querying for Batch node files by compute node using a filter
#>
function Test-ListNodeFilesByComputeNodeByFilter
{
    param([string]$poolId, [string]$computeNodeId, [string]$nodeFilePrefix, [string]$matches)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(name,'" + "$nodeFilePrefix" + "')"

    $nodeFiles = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $nodeFiles.Length
    foreach($nodeFile in $nodeFiles)
    {
        Assert-True { $nodeFile.Name.StartsWith("$nodeFilePrefix") }
    }

    # Verify parent object parameter set also works
    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -ComputeNode $computeNode -Filter $filter -BatchContext $context

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
    param([string]$poolId, [string]$computeNodeId, [string]$maxCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFiles = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $nodeFiles.Length

    # Verify parent object parameter set also works
    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -ComputeNode $computeNode -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $nodeFiles.Length
}

<#
.SYNOPSIS
Tests querying for Batch node files by compute node with the Recursive switch
#>
function Test-ListNodeFilesByComputeNodeRecursive
{
    param([string]$poolId, [string]$computeNodeId, [string]$startupFolder, [string]$recursiveCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(name,'" + "$startupFolder" + "')"
    $nodeFiles = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -BatchContext $context

    # Only the directory itself is returned
    Assert-AreEqual 1 $nodeFiles.Length
    Assert-True { $nodeFiles[0].IsDirectory }

    # Verify the start task node files are returned when using the Recursive switch
    $nodeFiles = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Filter $filter -Recursive -BatchContext $context

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
    param([string]$poolId, [string] $computeNodeId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $nodeFiles = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -BatchContext $context

    Assert-AreEqual $count $nodeFiles.Length

    # Verify parent object parameter set also works
    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context
    $nodeFiles = Get-AzureBatchNodeFile -ComputeNode $computeNode -BatchContext $context

    Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests pipelining scenarios
#>
function Test-ListNodeFileByComputeNodePipeline
{
    param([string]$poolId, [string]$computeNodeId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Get Compute Node into Get Node File
    $nodeFiles = Get-AzureBatchComputeNode -PoolId $poolId -Id $computeNodeId -BatchContext $context | Get-AzureBatchNodeFile -BatchContext $context
    Assert-AreEqual $count $nodeFiles.Length
}

<#
.SYNOPSIS
Tests downloading node file contents by compute node by name
#>
function Test-GetNodeFileContentByComputeNodeByName
{
    param([string]$poolId, [string]$computeNodeId, [string]$nodeFileName, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        Get-AzureBatchNodeFileContent -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context -DestinationStream $stream
        
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
        Get-AzureBatchNodeFileContent $poolId $computeNodeId $nodeFileName -BatchContext $context -DestinationStream $stream

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
    param([string]$poolId, [string]$computeNodeId, [string]$nodeFileName, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        $nodeFile = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Name $nodeFileName -BatchContext $context
        $nodeFile | Get-AzureBatchNodeFileContent -BatchContext $context -DestinationStream $stream
        
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
    param([string]$poolId, [string]$computeNodeId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 
    $rdpContents = "full address"

    try
    {
        Get-AzureBatchRemoteDesktopProtocolFile -PoolId $poolId -ComputeNodeId $computeNodeId -BatchContext $context -DestinationStream $stream
        
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
        Get-AzureBatchRemoteDesktopProtocolFile $poolId $computeNodeId -BatchContext $context -DestinationStream $stream

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
    param([string]$poolId, [string]$computeNodeId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 
    $rdpContents = "full address"

    try
    {
        $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Id $computeNodeId -BatchContext $context
        $computeNode | Get-AzureBatchRemoteDesktopProtocolFile -BatchContext $context -DestinationStream $stream
        
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
Tests deleting a node file associated with a task
#>
function Test-DeleteNodeFileByTask 
{
    param([string]$jobId, [string]$taskId, [string]$filePath, [string]$usePipeline)
    
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    if ($usePipeline -eq '1')
    {
        Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Name $filePath -BatchContext $context | Remove-AzureBatchNodeFile -Force -BatchContext $context
    }
    else
    {
        Remove-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Name $filePath -Force -BatchContext $context
    }

    $file = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter "startswith(name,'$filePath')" -BatchContext $context

    Assert-AreEqual $null $file
}

<#
.SYNOPSIS
Tests deleting a node file from a compute node
#>
function Test-DeleteNodeFileByComputeNode 
{
    param([string]$poolId, [string]$computeNodeId, [string]$filePath, [string]$usePipeline)
    
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    if ($usePipeline -eq '1')
    {
        Get-AzureBatchNodeFile $poolId $computeNodeId $filePath -BatchContext $context | Remove-AzureBatchNodeFile -Force -BatchContext $context
    }
    else
    {
        Remove-AzureBatchNodeFile $poolId $computeNodeId $filePath -Force -BatchContext $context
    }

    $file = Get-AzureBatchNodeFile $poolId $computeNodeId -Filter "startswith(name,'$filePath')" -BatchContext $context

    Assert-AreEqual $null $file
}