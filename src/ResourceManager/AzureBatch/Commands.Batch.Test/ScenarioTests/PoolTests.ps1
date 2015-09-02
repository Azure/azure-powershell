﻿# ----------------------------------------------------------------------------------
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
Tests creating Batch Pools
#>
function Test-NewPool
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	
	$poolId1 = "simple"
	$poolId2 = "complex"

	try 
	{
		# Create a simple pool using TargetDedicated parameter set
		$osFamily = "4"
		$targetOSVersion = "*"
		$targetDedicated = 1
		$resizeTimeout = ([TimeSpan]::FromMinutes(10))
		$vmSize = "small"
		New-AzureBatchPool_ST $poolId1 -OSFamily $osFamily -TargetOSVersion $targetOSVersion -TargetDedicated $targetDedicated -VirtualMachineSize $vmSize -ResizeTimeout $resizeTimeout -BatchContext $context
		$pool1 = Get-AzureBatchPool_ST -Id $poolId1 -BatchContext $context

		# Verify created pool matches expectations
		Assert-AreEqual $poolId1 $pool1.Id
		Assert-AreEqual $osFamily $pool1.OSFamily
		Assert-AreEqual $targetOSVersion $pool1.TargetOSVersion
		Assert-AreEqual $resizeTimeout $pool1.ResizeTimeout
		Assert-AreEqual $targetDedicated $pool1.TargetDedicated
		Assert-AreEqual $vmSize $pool1.VirtualMachineSize

		# Create a complicated pool using AutoScale parameter set
		$maxTasksPerComputeNode = 2
		$autoScaleFormula = '$TargetDedicated=2'
		
		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTaskCmd = "cmd /c dir /s"
		$startTask.CommandLine = $startTaskCmd
		$startTask.ResourceFiles = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
		$blobSource1 = "https://testacct1.blob.core.windows.net/"
		$filePath1 = "filePath1"
		$blobSource2 = "https://testacct2.blob.core.windows.net/"
		$filePath2 = "filePath2"
		$r1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList @($blobSource1,$filePath1)
		$r2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList @($blobSource2,$filePath2)
		$startTask.ResourceFiles.Add($r1)
		$startTask.ResourceFiles.Add($r2)
		$resourceFileCount = $startTask.ResourceFiles.Count

		$computeNodeFillType = ([Microsoft.Azure.Batch.Common.ComputeNodeFillType]::Pack)
		$schedulingPolicy = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskSchedulingPolicy $computeNodeFillType

		$metadata = @{"meta1"="value1";"meta2"="value2"}
		
		$displayName = "displayName"

		New-AzureBatchPool_ST -Id $poolId2 -VirtualMachineSize $vmSize -OSFamily $osFamily -TargetOSVersion $targetOSVersion -DisplayName $displayName -MaxTasksPerComputeNode $maxTasksPerComputeNode -AutoScaleFormula $autoScaleFormula -StartTask $startTask -TaskSchedulingPolicy $schedulingPolicy -InterComputeNodeCommunicationEnabled -Metadata $metadata -BatchContext $context
		
		$pool2 = Get-AzureBatchPool_ST -Id $poolId2 -BatchContext $context
		
		# Verify created pool matches expectations
		Assert-AreEqual $poolId2 $pool2.Id
		Assert-AreEqual $displayName $pool2.DisplayName
		Assert-AreEqual $vmSize $pool2.VirtualMachineSize
		Assert-AreEqual $osFamily $pool2.OSFamily
		Assert-AreEqual $targetOSVersion $pool2.TargetOSVersion
		Assert-AreEqual $maxTasksPerComputeNOde $pool2.MaxTasksPerComputeNode
		Assert-AreEqual $true $pool2.AutoScaleEnabled
		Assert-AreEqual $autoScaleFormula $pool2.AutoScaleFormula
		Assert-AreEqual $true $pool2.InterComputeNodeCommunicationEnabled
		Assert-AreEqual $startTaskCmd $pool2.StartTask.CommandLine
		Assert-AreEqual $resourceFileCount $pool2.StartTask.ResourceFiles.Count
		Assert-AreEqual $blobSource1 $pool2.StartTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $filePath1 $pool2.StartTask.ResourceFiles[0].FilePath
		Assert-AreEqual $blobSource2 $pool2.StartTask.ResourceFiles[1].BlobSource
		Assert-AreEqual $filePath2 $pool2.StartTask.ResourceFiles[1].FilePath
		Assert-AreEqual $computeNodeFillType $pool2.TaskSchedulingPolicy.ComputeNodeFillType
		Assert-AreEqual $metadata.Count $pool2.Metadata.Count
		foreach($m in $pool2.Metadata)
		{
			Assert-AreEqual $metadata[$m.Name] $m.Value
		}
	}
	finally
	{
		Remove-AzureBatchPool_ST -Id $poolId1 -Force -BatchContext $context
		Remove-AzureBatchPool_ST -Id $poolId2 -Force -BatchContext $context
	}
}

<#
.SYNOPSIS
Tests querying for a Batch pool by id
#>
function Test-GetPoolById
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context

	Assert-AreEqual $poolId $pool.Id
}

<#
.SYNOPSIS
Tests querying for Batch pools using a filter
#>
function Test-ListPoolsByFilter
{
	param([string]$accountName, [string]$poolPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$poolFilter = "startswith(id,'" + "$poolPrefix" + "')"
	$pools = Get-AzureBatchPool_ST -Filter $poolFilter -BatchContext $context

	Assert-AreEqual $matches $pools.Length
	foreach($pool in $pools)
	{
		Assert-True { $pool.Id.StartsWith("$poolPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch pools and supplying a max count
#>
function Test-ListPoolsWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pools = Get-AzureBatchPool_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $pools.Length
}

<#
.SYNOPSIS
Tests querying for all pools under an account
#>
function Test-ListAllPools
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pools = Get-AzureBatchPool_ST -BatchContext $context

	Assert-AreEqual $count $pools.Length
}

<#
.SYNOPSIS
Tests deleting a pool
#>
function Test-DeletePool
{
	param([string]$accountName, [string]$poolId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the pool exists
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-AreEqual $poolId $pool.Id

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchPool_ST -Id $poolId -BatchContext $context | Remove-AzureBatchPool_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchPool_ST -Id $poolId -Force -BatchContext $context
	}

	# Verify the pool was deleted. Use the OData filter since the GetPool API will cause a 404 if the pool isn't found.
	$filter = "id eq '" + $poolId + "'"
	$pool = Get-AzureBatchPool_ST -Filter $filter -BatchContext $context
	
	Assert-True { $pool -eq $null -or $pool.State.ToString().ToLower() -eq 'deleting' }
}

<#
.SYNOPSIS
Tests resizing a pool specified by id
#>
function Test-ResizePoolById
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get the initial TargetDedicated count
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 1
	Start-AzureBatchPoolResize_ST -Id $poolId -TargetDedicated $newTargetDedicated -BatchContext $context

	# Verify the TargetDedicated property was updated
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	Assert-AreEqual $newTargetDedicated $pool.TargetDedicated
}

<#
.SYNOPSIS
Tests resizing a pool specified by pipeline object
#>
function Test-ResizePoolByPipeline
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get the initial TargetDedicated count
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated - 1
	$pool | Start-AzureBatchPoolResize_ST -TargetDedicated $newTargetDedicated -ResizeTimeout ([TimeSpan]::FromHours(1)) -ComputeNodeDeallocationOption ([Microsoft.Azure.Batch.Common.ComputeNodeDeallocationOption]::Terminate) -BatchContext $context

	# Verify the TargetDedicated property was updated
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	Assert-AreEqual $newTargetDedicated $pool.TargetDedicated
}

<#
.SYNOPSIS
Tests stopping a pool resize operation using the pool id
#>
function Test-StopResizePoolById
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys $accountName

	# Start a resize and then stop it
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 2
	Start-AzureBatchPoolResize_ST -Id $poolId -TargetDedicated $newTargetDedicated -BatchContext $context
	Stop-AzureBatchPoolResize_ST -Id $poolId -BatchContext $context

	# Verify the AllocationState changed to Stopping
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	Assert-AreEqual 'Stopping' $pool.AllocationState
}

<#
.SYNOPSIS
Tests stopping a pool resize operation using the pipeline
#>
function Test-StopResizePoolByPipeline
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Start a resize and then stop it
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 2
	$pool | Start-AzureBatchPoolResize_ST -TargetDedicated $newTargetDedicated -BatchContext $context
	$pool | Stop-AzureBatchPoolResize_ST -BatchContext $context

	# Verify the AllocationState changed to Stopping
	$pool = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context
	Assert-AreEqual 'Stopping' $pool.AllocationState
}

<#
.SYNOPSIS
Tests enabling autoscale
#>
function Test-EnableAutoScale
{
	param([string]$accountName, [string]$poolId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys $accountName

	$formula = '$TargetDedicated=2'

	# Verify pool starts with autoscale disabled
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-False { $pool.AutoScaleEnabled }

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchPool_ST -Id $poolId -BatchContext $context | Enable-AzureBatchAutoScale_ST -AutoScaleFormula $formula -BatchContext $context
	}
	else
	{
		Enable-AzureBatchAutoScale_ST $poolId $formula -BatchContext $context
	}

	# Verify that autoscale was enabled. 
	# Use a filter because it seems that the recorder sometimes gets confused when two identical URLs are sent too close together
	$pool = Get-AzureBatchPool_ST -Filter "id eq '$poolId'" -BatchContext $context
	Assert-True { $pool.AutoScaleEnabled }
}

<#
.SYNOPSIS
Tests disabling autoscale
#>
function Test-DisableAutoScale
{
	param([string]$accountName, [string]$poolId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys $accountName

	# Verify pool starts with autoscale enabled
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-True { $pool.AutoScaleEnabled }

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchPool_ST -Id $poolId -BatchContext $context | Disable-AzureBatchAutoScale_ST -BatchContext $context
	}
	else
	{
		Disable-AzureBatchAutoScale_ST $poolId -BatchContext $context
	}

	# Verify that autoscale was disabled
	# Use a filter because it seems that the recorder sometimes gets confused when two identical URLs are sent too close together
	$pool = Get-AzureBatchPool_ST -Filter "id eq '$poolId'" -BatchContext $context
	Assert-False { $pool.AutoScaleEnabled }
}

<#
.SYNOPSIS
Tests evaluating an autoscale formula
#>
function Test-EvaluateAutoScale
{
	param([string]$accountName, [string]$poolId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys $accountName

	$formula = '$TargetDedicated=2'

	# Verify pool starts with autoscale enabled
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-True { $pool.AutoScaleEnabled }

	if ($usePipeline -eq '1')
	{
		$evalResult = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context | Test-AzureBatchAutoScale_ST -AutoScaleFormula $formula -BatchContext $context
	}
	else
	{
		$evalResult = Test-AzureBatchAutoScale_ST $poolId $formula -BatchContext $context
	}

	# Verify that the evaluation result matches expectation
	Assert-True { $evalResult.AutoScaleRun.Results.Contains($formula) }
}

<#
.SYNOPSIS
Tests changing the pool OS version
#>
function Test-ChangeOSVersion
{
	param([string]$accountName, [string]$poolId, [string]$targetOSVersion, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys $accountName

	# Verify that we start with a different target OS
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-AreNotEqual $targetOSVersion $pool.TargetOSVersion

	if ($usePipeline -eq '1')
	{
	    Get-AzureBatchPool_ST -Filter "id eq '$poolId'" -BatchContext $context | Set-AzureBatchPoolOSVersion_ST -TargetOSVersion $targetOSVersion -BatchContext $context
	}
	else
	{
	    Set-AzureBatchPoolOSVersion_ST $poolId $targetOSVersion -BatchContext $context
	}

	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	Assert-AreEqual $targetOSVersion $pool.TargetOSVersion
}