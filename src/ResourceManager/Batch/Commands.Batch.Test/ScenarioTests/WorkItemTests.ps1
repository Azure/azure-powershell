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
Tests creating Batch WorkItems
#>
function Test-NewWorkItem
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	
	$wiName1 = "simple"
	$wiName2 = "complex"

	try 
	{
		# Create a simple WorkItem
		$jee1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobExecutionEnvironment
		$jee1.PoolName = $poolName = "testPool"
		New-AzureBatchWorkItem_ST -Name $wiName1 -JobExecutionEnvironment $jee1 -BatchContext $context
		$workItem1 = Get-AzureBatchWorkItem_ST -Name $wiName1 -BatchContext $context

		# Verify created WorkItem matches expectations
		Assert-AreEqual $wiName1 $workItem1.Name
		Assert-AreEqual $poolName $workItem1.JobExecutionEnvironment.PoolName

		# Create a complicated WorkItem
		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTaskCmd = "cmd /c dir /s"
		$startTask.CommandLine = $startTaskCmd

		$poolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
		$poolSpec.TargetDedicated = $targetDedicated = 3
		$poolSpec.VMSize = $vmSize = "small"
		$poolSpec.OSFamily = $osFamily = "4"
		$poolSpec.TargetOSVersion = $targetOS = "*"
		$poolSpec.StartTask = $startTask

		$poolSpec.CertificateReferences = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSCertificateReference]
		$certRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSCertificateReference
		$certRef.StoreLocation = $storeLocation = ([Microsoft.Azure.Batch.Common.CertStoreLocation]::LocalMachine)
		$certRef.StoreName = $storeName = "certStore"
		$certRef.Thumbprint = $thumbprint = "0123456789ABCDEF"
		$certRef.ThumbprintAlgorithm = $thumbprintAlgorithm = "sha1"
		$certRef.Visibility = $visibility = ([Microsoft.Azure.Batch.Common.CertVisibility]::StartTask)
		$poolSpec.CertificateReferences.Add($certRef)
		$certRefCount = $poolSpec.CertificateReferences.Count

		$autoPoolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
		$autoPoolSpec.PoolSpecification = $poolSpec
		$autoPoolSpec.AutoPoolNamePrefix = $autoPoolNamePrefix = "TestSpecPrefix"
		$autoPoolSpec.KeepAlive = $keepAlive = $false
		$autoPoolSpec.PoolLifeTimeOption = $poolLifeTime = ([Microsoft.Azure.Batch.Common.PoolLifeTimeOption]::WorkItem)

		$jee2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobExecutionEnvironment
		$jee2.AutoPoolSpecification = $autoPoolSpec

		$jobMgr = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobMAnager
		$jobMgr.CommandLine = $jobMgrCmd = "cmd /c dir /s"
		$jobMgr.EnvironmentSettings = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
		$env1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "name1","value1"
		$env2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "name2","value2"
		$env1Name = $env1.Name
		$env1Value = $env1.Value
		$env2Name = $env2.Name
		$env2Value = $env2.Value
		$jobMgr.EnvironmentSettings.Add($env1)
		$jobMgr.EnvironmentSettings.Add($env2)
		$envCount = $jobMgr.EnvironmentSettings.Count
		$jobMgr.ResourceFiles = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
		$r1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList "https://testacct.blob.core.windows.net/","filePath"
		$blobSource = $r1.BlobSource
		$filePath = $r1.FilePath
		$jobMgr.ResourceFiles.Add($r1)
		$resourceFileCount = $jobMgr.ResourceFiles.Count
		$jobMgr.KillJobOnCompletion = $killOnCompletion = $false
		$jobMgr.Name = $jobMgrName = "jobManager"
		$jobMgr.RunElevated = $runElevated = $false

		$jobConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobConstraints -ArgumentList @([TimeSpan]::FromDays(1),5)
		$maxWallClockTime = $jobConstraints.MaxWallClockTime
		$maxTaskRetry = $jobConstraints.MaxTaskRetryCount

		$jobSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobSpecification
		$jobSpec.JobManager = $jobMgr
		$jobSpec.JobConstraints = $jobConstraints

		$wiSchedule = New-Object Microsoft.Azure.Commands.Batch.Models.PSWorkItemSchedule
		$wiSchedule.RecurrenceInterval = $recurrence = [TimeSpan]::FromDays(1)

		$metadata = @{"meta1"="value1";"meta2"="value2"}

		New-AzureBatchWorkItem_ST -Name $wiName2 -JobExecutionEnvironment $jee2 -Schedule $wiSchedule -JobSpecification $jobSpec -Metadata $metadata -BatchContext $context
		
		$workItem2 = Get-AzureBatchWorkItem_ST -Name $wiName2 -BatchContext $context
		
		# Verify created WorkItem matches expectations
		Assert-AreEqual $wiName2 $workItem2.Name
		Assert-AreEqual $jee2.PoolName $workItem2.JobExecutionEnvironment.PoolName
		Assert-AreEqual $autoPoolNamePrefix $workItem2.JobExecutionEnvironment.AutoPoolSpecification.AutoPoolNamePrefix
		Assert-AreEqual $keepAlive $workItem2.JobExecutionEnvironment.AutoPoolSpecification.KeepAlive
		Assert-AreEqual $poolLifeTime $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolLifeTimeOption
		Assert-AreEqual $targetDedicated $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.TargetDedicated
		Assert-AreEqual $vmSize $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.VMSize
		Assert-AreEqual $osFamily $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.OSFamily
		Assert-AreEqual $targetOS $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.TargetOSVersion
		Assert-AreEqual $certRefCount $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences.Count
		Assert-AreEqual $storeLocation $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreLocation
		Assert-AreEqual $storeName $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreName
		Assert-AreEqual $thumbprint $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Thumbprint
		Assert-AreEqual $thumbprintAlgorithm $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].ThumbprintAlgorithm
		Assert-AreEqual $visibility $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Visibility
		Assert-AreEqual $startTaskCmd $workItem2.JobExecutionEnvironment.AutoPoolSpecification.PoolSpecification.StartTask.CommandLine
		Assert-AreEqual $jobMgrCmd $workItem2.JobSpecification.JobManager.CommandLine
		Assert-AreEqual $envCount $workItem2.JobSpecification.JobManager.EnvironmentSettings.Count
		Assert-AreEqual $env1Name $workItem2.JobSpecification.JobManager.EnvironmentSettings[0].Name
		Assert-AreEqual $env1Value $workItem2.JobSpecification.JobManager.EnvironmentSettings[0].Value
		Assert-AreEqual $env2Name $workItem2.JobSpecification.JobManager.EnvironmentSettings[1].Name
		Assert-AreEqual $env2Value $workItem2.JobSpecification.JobManager.EnvironmentSettings[1].Value
		Assert-AreEqual $resourceFileCount $workItem2.JobSpecification.JobManager.ResourceFiles.Count
		Assert-AreEqual $blobSource $workItem2.JobSpecification.JobManager.ResourceFiles[0].BlobSource
		Assert-AreEqual $filePath $workItem2.JobSpecification.JobManager.ResourceFiles[0].FilePath
		Assert-AreEqual $killOnCompletion $workItem2.JobSpecification.JobManager.KillJobOnCompletion
		Assert-AreEqual $jobMgrName $workItem2.JobSpecification.JobManager.Name
		Assert-AreEqual $runElevated $workItem2.JobSpecification.JobManager.RunElevated
		Assert-AreEqual $jobMgrCmd $workItem2.JobSpecification.JobManager.CommandLine
		Assert-AreEqual $maxTaskRetry $workItem2.JobSpecification.JobConstraints.MaxTaskRetryCount
		Assert-AreEqual $maxWallClockTime $workItem2.JobSpecification.JobConstraints.MaxWallClockTime
		Assert-AreEqual $recurrence $workItem2.Schedule.RecurrenceInterval
		Assert-AreEqual $metadata.Count $workItem2.Metadata.Count
		foreach($m in $workItem2.Metadata)
		{
			Assert-AreEqual $metadata[$m.Name] $m.Value
		}
	}
	finally
	{
		Remove-AzureBatchWorkItem_ST -Name $wiName1 -Force -BatchContext $context
		Remove-AzureBatchWorkItem_ST -Name $wiName2 -Force -BatchContext $context
	}
}

<#
.SYNOPSIS
Tests querying for a Batch WorkItem by name
#>
function Test-GetWorkItemByName
{
	param([string]$accountName, [string]$wiName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItem = Get-AzureBatchWorkItem_ST -Name $wiName -BatchContext $context

	Assert-AreEqual $wiName $workItem.Name
}

<#
.SYNOPSIS
Tests querying for Batch WorkItems using a filter
#>
function Test-ListWorkItemsByFilter
{
	param([string]$accountName, [string]$wiPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$wiFilter = "startswith(name,'" + "$wiPrefix" + "')"
	$workItems = Get-AzureBatchWorkItem_ST -Filter $wiFilter -BatchContext $context

	Assert-AreEqual $matches $workItems.Length
	foreach($workItem in $workItems)
	{
		Assert-True { $workItem.Name.StartsWith("$wiPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch WorkItems and supplying a max count
#>
function Test-ListWorkItemsWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItems = Get-AzureBatchWorkItem_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $workItems.Length
}

<#
.SYNOPSIS
Tests querying for all WorkItems under an account
#>
function Test-ListAllWorkItems
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItems = Get-AzureBatchWorkItem_ST -BatchContext $context

	Assert-AreEqual $count $workItems.Length
}

<#
.SYNOPSIS
Tests deleting a WorkItem
#>
function Test-DeleteWorkItem
{
	param([string]$accountName, [string]$workItemName, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the WorkItem exists
	$workItems = Get-AzureBatchWorkItem_ST -BatchContext $context
	Assert-AreEqual 1 $workItems.Count

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchWorkItem_ST -Name $workItemName -BatchContext $context | Remove-AzureBatchWorkItem_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchWorkItem_ST -Name $workItemName -Force -BatchContext $context
	}

	# Verify the WorkItem was deleted
	$workItems = Get-AzureBatchWorkItem_ST -BatchContext $context
	Assert-True { $workItems -eq $null -or $workItems[0].State.ToString().ToLower() -eq 'deleting' }
}