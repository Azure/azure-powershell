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
Tests creating Batch job schedules
#>
function Test-NewJobSchedule
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	
	$jsId1 = "simple"
	$jsId2 = "complex"

	try 
	{
		# Create a simple job schedule
		$jobSpec1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobSpecification
		$jobSpec1.PoolInformation = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
		$jobSpec1.PoolInformation.PoolId = $poolId = "testPool"
		$schedule1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSSchedule
		New-AzureBatchJobSchedule_ST -Id $jsId1 -JobSpecification $jobSpec1 -Schedule $schedule1 -BatchContext $context
		$jobSchedule1 = Get-AzureBatchJobSchedule_ST -Id $jsId1 -BatchContext $context

		# Verify created job schedule matches expectations
		Assert-AreEqual $jsId1 $jobSchedule1.Id
		Assert-AreEqual $poolId $jobSchedule1.JobSpecification.PoolInformation.PoolId

		# Create a complicated job schedule
		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTaskCmd = "cmd /c dir /s"
		$startTask.CommandLine = $startTaskCmd

		$poolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
		$poolSpec.TargetDedicated = $targetDedicated = 3
		$poolSpec.VirtualMachineSize = $vmSize = "small"
		$poolSpec.OSFamily = $osFamily = "4"
		$poolSpec.TargetOSVersion = $targetOS = "*"
		$poolSpec.StartTask = $startTask

		$poolSpec.CertificateReferences = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSCertificateReference]
		$certRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSCertificateReference
		$certRef.StoreLocation = $storeLocation = ([Microsoft.Azure.Batch.Common.CertStoreLocation]::LocalMachine)
		$certRef.StoreName = $storeName = "certStore"
		$certRef.Thumbprint = $thumbprint = "0123456789ABCDEF"
		$certRef.ThumbprintAlgorithm = $thumbprintAlgorithm = "sha1"
		$certRef.Visibility = $visibility = ([Microsoft.Azure.Batch.Common.CertificateVisibility]::StartTask)
		$poolSpec.CertificateReferences.Add($certRef)
		$certRefCount = $poolSpec.CertificateReferences.Count

		$autoPoolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
		$autoPoolSpec.PoolSpecification = $poolSpec
		$autoPoolSpec.AutoPoolIdPrefix = $autoPoolIdPrefix = "TestSpecPrefix"
		$autoPoolSpec.KeepAlive = $keepAlive = $false
		$autoPoolSpec.PoolLifeTimeOption = $poolLifeTime = ([Microsoft.Azure.Batch.Common.PoolLifeTimeOption]::JobSchedule)

		$poolInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
		$poolInfo.AutoPoolSpecification = $autoPoolSpec

		$jobMgr = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobManagerTask
		$jobMgr.CommandLine = $jobMgrCmd = "cmd /c dir /s"
		$jobMgr.EnvironmentSettings = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
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
		$jobMgr.Id = $jobMgrId = "jobManager"
		$jobMgr.DisplayName = $jobMgrDisplay = "jobManagerDisplay"
		$jobMgr.RunElevated = $runElevated = $false
		$jobMgrMaxWallClockTime = [TimeSpan]::FromHours(1)
		$jobMgr.Constraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @($jobMgrMaxWallClockTime,$null,$null)

		$jobPrep = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobPreparationTask
		$jobPrep.CommandLine = $jobPrepCmd = "cmd /c dir /s"
		$jobPrep.EnvironmentSettings = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
		$jobPrepEnv1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "jobPrepName1","jobPrepValue1"
		$jobPrepEnv2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "jobPrepName2","jobPrepValue2"
		$jobPrepEnv1Name = $jobPrepEnv1.Name
		$jobPrepEnv1Value = $jobPrepEnv1.Value
		$jobPrepEnv2Name = $jobPrepEnv2.Name
		$jobPrepEnv2Value = $jobPrepEnv2.Value
		$jobPrep.EnvironmentSettings.Add($jobPrepEnv1)
		$jobPrep.EnvironmentSettings.Add($jobPrepEnv2)
		$jobPrepEnvCount = $jobPrep.EnvironmentSettings.Count
		$jobPrep.ResourceFiles = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
		$jobPrepR1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList "https://testacct.blob.core.windows.net/","jobPrepFilePath"
		$jobPrepBlobSource = $jobPrepR1.BlobSource
		$jobPrepFilePath = $jobPrepR1.FilePath
		$jobPrep.ResourceFiles.Add($jobPrepR1)
		$jobPrepResourceFileCount = $jobPrep.ResourceFiles.Count
		$jobPrep.Id = $jobPrepId = "jobPrep"
		$jobPrep.RunElevated = $jobPrepRunElevated = $false
		$jobPrepRetryCount = 2
		$jobPrep.Constraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @($null,$null,$jobPrepRetryCount)

		$jobRelease = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobReleaseTask
		$jobRelease.CommandLine = $jobReleaseCmd = "cmd /c dir /s"
		$jobRelease.EnvironmentSettings = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
		$jobReleaseEnv1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "jobReleaseName1","jobReleaseValue1"
		$jobReleaseEnv2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "jobReleaseName2","jobReleaseValue2"
		$jobReleaseEnv1Name = $jobReleaseEnv1.Name
		$jobReleaseEnv1Value = $jobReleaseEnv1.Value
		$jobReleaseEnv2Name = $jobReleaseEnv2.Name
		$jobReleaseEnv2Value = $jobReleaseEnv2.Value
		$jobRelease.EnvironmentSettings.Add($jobReleaseEnv1)
		$jobRelease.EnvironmentSettings.Add($jobReleaseEnv2)
		$jobReleaseEnvCount = $jobRelease.EnvironmentSettings.Count
		$jobRelease.ResourceFiles = new-object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
		$jobReleaseR1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList "https://testacct.blob.core.windows.net/","jobReleaseFilePath"
		$jobReleaseBlobSource = $jobReleaseR1.BlobSource
		$jobReleaseFilePath = $jobReleaseR1.FilePath
		$jobRelease.ResourceFiles.Add($jobReleaseR1)
		$jobReleaseResourceFileCount = $jobRelease.ResourceFiles.Count
		$jobRelease.Id = $jobReleaseId = "jobRelease"
		$jobRelease.RunElevated = $jobReleaseRunElevated = $false

		$jobConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobConstraints -ArgumentList @([TimeSpan]::FromDays(1),5)
		$maxWallClockTime = $jobConstraints.MaxWallClockTime
		$maxTaskRetry = $jobConstraints.MaxTaskRetryCount

		$jobSpec2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobSpecification
		$jobSpec2.JobManagerTask = $jobMgr
		$jobSpec2.JobPreparationTask = $jobPrep
		$jobSpec2.JobReleaseTask = $jobRelease
		$jobSpec2.Constraints = $jobConstraints
		$jobSpec2.PoolInformation = $poolInfo
		$jobSpec2.CommonEnvironmentSettings = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting]
		$commonEnv1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "commonName1","commonValue1"
		$commonEnv2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSEnvironmentSetting -ArgumentList "commonName2","commonValue2"
		$commonEnv1Name = $commonEnv1.Name
		$commonEnv1Value = $commonEnv1.Value
		$commonEnv2Name = $commonEnv2.Name
		$commonEnv2Value = $commonEnv2.Value
		$jobSpec2.CommonEnvironmentSettings.Add($commonEnv1)
		$jobSpec2.CommonEnvironmentSettings.Add($commonEnv2)
		$commonEnvCount = $jobSpec2.CommonEnvironmentSettings.Count
		$jobSpec2.DisplayName = $jobSpec2DisplayName = "jobSpecDisplayName"
		$jobSpec2.Priority = $jobSpec2Pri = 1
		$jobSpec2.Metadata = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSMetadataItem]
		$jobSpecMeta1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSMetadataItem -ArgumentList "specMeta1","specMetaValue1"
		$jobSpecMeta2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSMetadataItem -ArgumentList "specMeta2","specMetaValue2"
		$jobSpecMeta1Name = $jobSpecMeta1.Name
		$jobSpecMeta1Value = $jobSpecMeta1.Value
		$jobSpecMeta2Name = $jobSpecMeta2.Name
		$jobSpecMeta2Value = $jobSpecMeta2.Value
		$jobSpec2.Metadata.Add($jobSpecMeta1)
		$jobSpec2.Metadata.Add($jobSpecMeta2)
		$jobSpecMetaCount = $jobSpec2.Metadata.Count

		$schedule2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSSchedule
		$schedule2.RecurrenceInterval = $recurrence = [TimeSpan]::FromDays(2)
		$schedule2.StartWindow = $startWindow = [TimeSpan]::FromDays(1)

		$metadata = @{"meta1"="value1";"meta2"="value2"}

		$displayName = "displayName"

		New-AzureBatchJobSchedule_ST -Id $jsId2 -DisplayName $displayName -Schedule $schedule2 -JobSpecification $jobSpec2 -Metadata $metadata -BatchContext $context
		
		$jobSchedule2 = Get-AzureBatchJobSchedule_ST -Id $jsId2 -BatchContext $context
		
		# Verify created job schedule matches expectations
		Assert-AreEqual $jsId2 $jobSchedule2.Id
		Assert-AreEqual $displayName $jobSchedule2.DisplayName
		Assert-AreEqual $autoPoolIdPrefix $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.AutoPoolIdPrefix
		Assert-AreEqual $keepAlive $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.KeepAlive
		Assert-AreEqual $poolLifeTime $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolLifeTimeOption
		Assert-AreEqual $targetDedicated $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetDedicated
		Assert-AreEqual $vmSize $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.VirtualMachineSize
		Assert-AreEqual $osFamily $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.OSFamily
		Assert-AreEqual $targetOS $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetOSVersion
		Assert-AreEqual $certRefCount $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences.Count
		Assert-AreEqual $storeLocation $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreLocation
		Assert-AreEqual $storeName $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreName
		Assert-AreEqual $thumbprint $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Thumbprint
		Assert-AreEqual $thumbprintAlgorithm $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].ThumbprintAlgorithm
		Assert-AreEqual $visibility $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Visibility
		Assert-AreEqual $startTaskCmd $jobSchedule2.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.CommandLine
		Assert-AreEqual $commonEnvCount $jobSchedule2.JobSpecification.CommonEnvironmentSettings.Count
		Assert-AreEqual $commonEnv1Name $jobSchedule2.JobSpecification.CommonEnvironmentSettings[0].Name
		Assert-AreEqual $commonEnv1Value $jobSchedule2.JobSpecification.CommonEnvironmentSettings[0].Value
		Assert-AreEqual $commonEnv2Name $jobSchedule2.JobSpecification.CommonEnvironmentSettings[1].Name
		Assert-AreEqual $commonEnv2Value $jobSchedule2.JobSpecification.CommonEnvironmentSettings[1].Value
		Assert-AreEqual $jobSpec2DisplayName $jobSchedule2.JobSpecification.DisplayName
		Assert-AreEqual $jobMgrCmd $jobSchedule2.JobSpecification.JobManagerTask.CommandLine
		Assert-AreEqual $envCount $jobSchedule2.JobSpecification.JobManagerTask.EnvironmentSettings.Count
		Assert-AreEqual $env1Name $jobSchedule2.JobSpecification.JobManagerTask.EnvironmentSettings[0].Name
		Assert-AreEqual $env1Value $jobSchedule2.JobSpecification.JobManagerTask.EnvironmentSettings[0].Value
		Assert-AreEqual $env2Name $jobSchedule2.JobSpecification.JobManagerTask.EnvironmentSettings[1].Name
		Assert-AreEqual $env2Value $jobSchedule2.JobSpecification.JobManagerTask.EnvironmentSettings[1].Value
		Assert-AreEqual $resourceFileCount $jobSchedule2.JobSpecification.JobManagerTask.ResourceFiles.Count
		Assert-AreEqual $blobSource $jobSchedule2.JobSpecification.JobManagerTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $filePath $jobSchedule2.JobSpecification.JobManagerTask.ResourceFiles[0].FilePath
		Assert-AreEqual $killOnCompletion $jobSchedule2.JobSpecification.JobManagerTask.KillJobOnCompletion
		Assert-AreEqual $jobMgrId $jobSchedule2.JobSpecification.JobManagerTask.Id
		Assert-AreEqual $jobMgrDisplay $jobSchedule2.JobSpecification.JobManagerTask.DisplayName
		Assert-AreEqual $runElevated $jobSchedule2.JobSpecification.JobManagerTask.RunElevated
		Assert-AreEqual $jobMgrMaxWallClockTime $jobSchedule2.JobSpecification.JobManagerTask.Constraints.MaxWallClockTime
		Assert-AreEqual $jobPrepCmd $jobSchedule2.JobSpecification.JobPreparationTask.CommandLine
		Assert-AreEqual $jobPrepEnvCount $jobSchedule2.JobSpecification.JobPreparationTask.EnvironmentSettings.Count
		Assert-AreEqual $jobPrepEnv1Name $jobSchedule2.JobSpecification.JobPreparationTask.EnvironmentSettings[0].Name
		Assert-AreEqual $jobPrepEnv1Value $jobSchedule2.JobSpecification.JobPreparationTask.EnvironmentSettings[0].Value
		Assert-AreEqual $jobPrepEnv2Name $jobSchedule2.JobSpecification.JobPreparationTask.EnvironmentSettings[1].Name
		Assert-AreEqual $jobPrepEnv2Value $jobSchedule2.JobSpecification.JobPreparationTask.EnvironmentSettings[1].Value
		Assert-AreEqual $jobPrepResourceFileCount $jobSchedule2.JobSpecification.JobPreparationTask.ResourceFiles.Count
		Assert-AreEqual $jobPrepBlobSource $jobSchedule2.JobSpecification.JobPreparationTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $jobPrepFilePath $jobSchedule2.JobSpecification.JobPreparationTask.ResourceFiles[0].FilePath
		Assert-AreEqual $jobPrepId $jobSchedule2.JobSpecification.JobPreparationTask.Id
		Assert-AreEqual $jobPrepRunElevated $jobSchedule2.JobSpecification.JobPreparationTask.RunElevated
		Assert-AreEqual $jobPrepRetryCount $jobSchedule2.JobSpecification.JobPreparationTask.Constraints.MaxTaskRetryCount
		Assert-AreEqual $jobReleaseCmd $jobSchedule2.JobSpecification.JobReleaseTask.CommandLine
		Assert-AreEqual $jobReleaseEnvCount $jobSchedule2.JobSpecification.JobReleaseTask.EnvironmentSettings.Count
		Assert-AreEqual $jobReleaseEnv1Name $jobSchedule2.JobSpecification.JobReleaseTask.EnvironmentSettings[0].Name
		Assert-AreEqual $jobReleaseEnv1Value $jobSchedule2.JobSpecification.JobReleaseTask.EnvironmentSettings[0].Value
		Assert-AreEqual $jobReleaseEnv2Name $jobSchedule2.JobSpecification.JobReleaseTask.EnvironmentSettings[1].Name
		Assert-AreEqual $jobReleaseEnv2Value $jobSchedule2.JobSpecification.JobReleaseTask.EnvironmentSettings[1].Value
		Assert-AreEqual $jobReleaseResourceFileCount $jobSchedule2.JobSpecification.JobReleaseTask.ResourceFiles.Count
		Assert-AreEqual $jobReleaseBlobSource $jobSchedule2.JobSpecification.JobReleaseTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $jobReleaseFilePath $jobSchedule2.JobSpecification.JobReleaseTask.ResourceFiles[0].FilePath
		Assert-AreEqual $jobReleaseId $jobSchedule2.JobSpecification.JobReleaseTask.Id
		Assert-AreEqual $jobReleaseRunElevated $jobSchedule2.JobSpecification.JobReleaseTask.RunElevated
		Assert-AreEqual $maxTaskRetry $jobSchedule2.JobSpecification.Constraints.MaxTaskRetryCount
		Assert-AreEqual $maxWallClockTime $jobSchedule2.JobSpecification.Constraints.MaxWallClockTime
		Assert-AreEqual $jobSpecMetaCount $jobSchedule2.JobSpecification.Metadata.Count
		Assert-AreEqual $jobSpecMeta1Name $jobSchedule2.JobSpecification.Metadata[0].Name
		Assert-AreEqual $jobSpecMeta1Value $jobSchedule2.JobSpecification.Metadata[0].Value
		Assert-AreEqual $jobSpecMeta2Name $jobSchedule2.JobSpecification.Metadata[1].Name
		Assert-AreEqual $jobSpecMeta2Value $jobSchedule2.JobSpecification.Metadata[1].Value
		Assert-AreEqual $jobSpec2Pri $jobSchedule2.JobSpecification.Priority
		Assert-AreEqual $recurrence $jobSchedule2.Schedule.RecurrenceInterval
		Assert-AreEqual $startWindow $jobSchedule2.Schedule.StartWindow
		Assert-AreEqual $metadata.Count $jobSchedule2.Metadata.Count
		foreach($m in $jobSchedule2.Metadata)
		{
			Assert-AreEqual $metadata[$m.Name] $m.Value
		}
	}
	finally
	{
		Remove-AzureBatchJobSchedule_ST -Id $jsId1 -Force -BatchContext $context
		Remove-AzureBatchJobSchedule_ST -Id $jsId2 -Force -BatchContext $context
	}
}

<#
.SYNOPSIS
Tests querying for a Batch job schedule by id
#>
function Test-GetJobScheduleById
{
	param([string]$accountName, [string]$jsId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobSchedule = Get-AzureBatchJobSchedule_ST -Id $jsId -BatchContext $context

	Assert-AreEqual $jsId $jobSchedule.Id
}

<#
.SYNOPSIS
Tests querying for Batch job schedules using a filter
#>
function Test-ListJobSchedulesByFilter
{
	param([string]$accountName, [string]$jsPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jsFilter = "startswith(id,'" + "$jsPrefix" + "')"
	$jobSchedules = Get-AzureBatchJobSchedule_ST -Filter $jsFilter -BatchContext $context

	Assert-AreEqual $matches $jobSchedules.Length
	foreach($jobSchedule in $jobSchedules)
	{
		Assert-True { $jobSchedule.Id.StartsWith("$jsPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch job schedules and supplying a max count
#>
function Test-ListJobSchedulesWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobSchedules = Get-AzureBatchJobSchedule_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $jobSchedules.Length
}

<#
.SYNOPSIS
Tests querying for all job schedules under an account
#>
function Test-ListAllJobSchedules
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobSchedules = Get-AzureBatchJobSchedule_ST -BatchContext $context

	Assert-AreEqual $count $jobSchedules.Length
}

<#
.SYNOPSIS
Tests deleting a job schedule
#>
function Test-DeleteJobSchedule
{
	param([string]$accountName, [string]$jobScheduleId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the job schedule exists
	$jobSchedules = Get-AzureBatchJobSchedule_ST -BatchContext $context
	Assert-AreEqual 1 $jobSchedules.Count

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchJobSchedule_ST -Id $jobScheduleId -BatchContext $context | Remove-AzureBatchJobSchedule_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchJobSchedule_ST -Id $jobScheduleId -Force -BatchContext $context
	}

	# Verify the job schedule was deleted
	$jobSchedules = Get-AzureBatchJobSchedule_ST -BatchContext $context
	Assert-True { $jobSchedules -eq $null -or $jobSchedules[0].State.ToString().ToLower() -eq 'deleting' }
}

<#
.SYNOPSIS
Tests disabling and enabling a job schedule
#>
function Test-DisableAndEnableJobSchedule
{
	param([string]$accountName, [string]$jobScheduleId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the job schedule is Active
	$jobSchedule = Get-AzureBatchJobSchedule_ST $jobScheduleId -BatchContext $context
	Assert-AreEqual 'Active' $jobSchedule.State

	Disable-AzureBatchJobSchedule_ST $jobScheduleId -BatchContext $context

	# Verify the job schedule was Disabled
	$jobSchedule = Get-AzureBatchJobSchedule_ST $jobScheduleId -BatchContext $context
	Assert-AreEqual 'Disabled' $jobSchedule.State

	Enable-AzureBatchJobSchedule_ST $jobScheduleId -BatchContext $context

	# Verify the job schedule is again Active
	$jobSchedule = Get-AzureBatchJobSchedule_ST -Filter "id eq '$jobScheduleId'" -BatchContext $context
	Assert-AreEqual 'Active' $jobSchedule.State

	# Verify using the pipeline
	$jobSchedule | Disable-AzureBatchJobSchedule_ST -BatchContext $context
	$jobSchedule = Get-AzureBatchJobSchedule_ST $jobScheduleId -BatchContext $context
	Assert-AreEqual 'Disabled' $jobSchedule.State

	$jobSchedule | Enable-AzureBatchJobSchedule_ST -BatchContext $context
	$jobSchedule = Get-AzureBatchJobSchedule_ST -Filter "id eq '$jobScheduleId'" -BatchContext $context
	Assert-AreEqual 'Active' $jobSchedule.State
}