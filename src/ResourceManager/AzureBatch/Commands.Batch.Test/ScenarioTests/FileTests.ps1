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
Tests downloading node file contents by task
#>
function Test-GetNodeFileContentByTask
{
    param([string]$jobId, [string]$taskId, [string]$nodeFilePath, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        $nodeFile = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Path $nodeFilePath -BatchContext $context
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
Tests downloading node file contents by compute node
#>
function Test-GetNodeFileContentByComputeNode
{
    param([string]$poolId, [string]$computeNodeId, [string]$nodeFilePath, [string]$fileContent)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $stream = New-Object System.IO.MemoryStream 

    try
    {
        $nodeFile = Get-AzureBatchNodeFile -PoolId $poolId -ComputeNodeId $computeNodeId -Path $nodeFilePath -BatchContext $context
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
Tests downloading a Remote Desktop Protocol file
#>
function Test-GetRDPFile
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
    param([string]$jobId, [string]$taskId, [string]$filePath)
    
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Path $filePath -BatchContext $context | Remove-AzureBatchNodeFile -Force -BatchContext $context
    
    # Use filter to avoid 404 from GET
    $file = Get-AzureBatchNodeFile -JobId $jobId -TaskId $taskId -Filter "startswith(name,'$filePath')" -BatchContext $context

    Assert-AreEqual $null $file
}

<#
.SYNOPSIS
Tests deleting a node file from a compute node
#>
function Test-DeleteNodeFileByComputeNode 
{
    param([string]$poolId, [string]$computeNodeId, [string]$filePath)
    
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Get-AzureBatchNodeFile $poolId $computeNodeId $filePath -BatchContext $context | Remove-AzureBatchNodeFile -Force -BatchContext $context

    # Use filter to avoid 404 from GET
    $file = Get-AzureBatchNodeFile $poolId $computeNodeId -Filter "startswith(name,'$filePath')" -BatchContext $context

    Assert-AreEqual $null $file
}