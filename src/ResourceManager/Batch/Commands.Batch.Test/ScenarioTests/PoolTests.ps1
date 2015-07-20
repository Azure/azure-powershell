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
Tests creating Batch Pools
#>
function Test-NewPool
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	
	$poolName1 = "simple"
	$poolName2 = "complex"

	try 
	{
		# Create a simple Pool using TargetDedicated parameter set
		$osFamily = "4"
		$targetDedicated = 1
		$resizeTimeout = ([TimeSpan]::FromMinutes(10))
		New-AzureBatchPool_ST $poolName1 -OSFamily $osFamily -TargetDedicated $targetDedicated -ResizeTimeout $resizeTimeout -BatchContext $context
		$pool1 = Get-AzureBatchPool_ST -Name $poolName1 -BatchContext $context

		# Verify created Pool matches expectations
		Assert-AreEqual $poolName1 $pool1.Name
		Assert-AreEqual $osFamily $pool1.OSFamily
		Assert-AreEqual $resizeTimeout $pool1.ResizeTimeout
		Assert-AreEqual $targetDedicated $pool1.TargetDedicated

		# Create a complicated Pool using AutoScale parameter set
		$vmSize = "small"
		$targetOSVersion = "*"
		$maxTasksPerVM = 2
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

		$vmFillType = ([Microsoft.Azure.Batch.Common.TVMFillType]::Pack)
		$schedulingPolicy = New-Object Microsoft.Azure.Commands.Batch.Models.PSSchedulingPolicy $vmFillType

		$metadata = @{"meta1"="value1";"meta2"="value2"}

		New-AzureBatchPool_ST -Name $poolName2 -VMSize $vmSize -OSFamily $osFamily -TargetOSVersion $targetOSVersion -MaxTasksPerVM $maxTasksPerVM -AutoScaleFormula $autoScaleFormula -StartTask $startTask -SchedulingPolicy $schedulingPolicy -CommunicationEnabled -Metadata $metadata -BatchContext $context
		
		$pool2 = Get-AzureBatchPool_ST -Name $poolName2 -BatchContext $context
		
		# Verify created Pool matches expectations
		Assert-AreEqual $poolName2 $pool2.Name
		Assert-AreEqual $vmSize $pool2.VMSize
		Assert-AreEqual $osFamily $pool2.OSFamily
		Assert-AreEqual $targetOSVersion $pool2.TargetOSVersion
		Assert-AreEqual $maxTasksPerVM $pool2.MaxTasksPerVM
		Assert-AreEqual $true $pool2.AutoScaleEnabled
		Assert-AreEqual $autoScaleFormula $pool2.AutoScaleFormula
		Assert-AreEqual $true $pool2.Communication
		Assert-AreEqual $startTaskCmd $pool2.StartTask.CommandLine
		Assert-AreEqual $resourceFileCount $startTask.ResourceFiles.Count
		Assert-AreEqual $blobSource1 $startTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $filePath1 $startTask.ResourceFiles[0].FilePath
		Assert-AreEqual $blobSource2 $startTask.ResourceFiles[1].BlobSource
		Assert-AreEqual $filePath2 $startTask.ResourceFiles[1].FilePath
		Assert-AreEqual $metadata.Count $pool2.Metadata.Count
		foreach($m in $pool2.Metadata)
		{
			Assert-AreEqual $metadata[$m.Name] $m.Value
		}
	}
	finally
	{
		Remove-AzureBatchPool_ST -Name $poolName1 -Force -BatchContext $context
		Remove-AzureBatchPool_ST -Name $poolName2 -Force -BatchContext $context
	}
}

<#
.SYNOPSIS
Tests querying for a Batch Pool by name
#>
function Test-GetPoolByName
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context

	Assert-AreEqual $poolName $pool.Name
}

<#
.SYNOPSIS
Tests querying for Batch Pools using a filter
#>
function Test-ListPoolsByFilter
{
	param([string]$accountName, [string]$poolPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$poolFilter = "startswith(name,'" + "$poolPrefix" + "')"
	$pools = Get-AzureBatchPool_ST -Filter $poolFilter -BatchContext $context

	Assert-AreEqual $matches $pools.Length
	foreach($pool in $pools)
	{
		Assert-True { $pool.Name.StartsWith("$poolPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch Pools and supplying a max count
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
Tests querying for all Pools under an account
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
Tests deleting a Pool
#>
function Test-DeletePool
{
	param([string]$accountName, [string]$poolName, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the Pool exists
	$pool = Get-AzureBatchPool_ST $poolName -BatchContext $context
	Assert-AreEqual $poolName $pool.Name

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchPool_ST -Name $poolName -BatchContext $context | Remove-AzureBatchPool_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchPool_ST -Name $poolName -Force -BatchContext $context
	}

	# Verify the Pool was deleted. Use the OData filter since the GetPool API will cause a 404 if the pool isn't found.
	$filter = "name eq '" + $poolName + "'"
	$pool = Get-AzureBatchPool_ST -Filter $filter -BatchContext $context
	
	Assert-True { $pool -eq $null -or $pool.State.ToString().ToLower() -eq 'deleting' }
}

<#
.SYNOPSIS
Tests resizing a pool specified by name
#>
function Test-ResizePoolByName
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get the initial TargetDedicated count
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 2
	Start-AzureBatchPoolResize_ST -Name $poolName -TargetDedicated $newTargetDedicated -BatchContext $context

	# Verify the TargetDedicated property was updated
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	Assert-AreEqual $newTargetDedicated $pool.TargetDedicated
}

<#
.SYNOPSIS
Tests resizing a pool specified by pipeline object
#>
function Test-ResizePoolByPipeline
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Get the initial TargetDedicated count
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 2
	$pool | Start-AzureBatchPoolResize_ST -TargetDedicated $newTargetDedicated -ResizeTimeout ([TimeSpan]::FromHours(1)) -DeallocationOption ([Microsoft.Azure.Batch.Common.TVMDeallocationOption]::Terminate) -BatchContext $context

	# Verify the TargetDedicated property was updated
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	Assert-AreEqual $newTargetDedicated $pool.TargetDedicated
}

<#
.SYNOPSIS
Tests stopping a pool resize operation using the pool name
#>
function Test-StopResizePoolByName
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Start a resize and then stop it
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 5
	Start-AzureBatchPoolResize_ST -Name $poolName -TargetDedicated $newTargetDedicated -BatchContext $context
	Stop-AzureBatchPoolResize_ST -Name $poolName -BatchContext $context

	# Verify the AllocationState changed to Stopping
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	Assert-AreEqual 'Stopping' $pool.AllocationState
}

<#
.SYNOPSIS
Tests stopping a pool resize operation using the pipeline
#>
function Test-StopResizePoolByPipeline
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Start a resize and then stop it
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	$initialTargetDedicated = $pool.TargetDedicated

	$newTargetDedicated = $initialTargetDedicated + 5
	$pool | Start-AzureBatchPoolResize_ST -TargetDedicated $newTargetDedicated -BatchContext $context
	$pool | Stop-AzureBatchPoolResize_ST -BatchContext $context

	# Verify the AllocationState changed to Stopping
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context
	Assert-AreEqual 'Stopping' $pool.AllocationState
}