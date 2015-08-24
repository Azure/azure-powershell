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
Tests creating Batch jobs
#>
function Test-NewJob
{
	param([string]$accountName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	
	$jobId1 = "simple"
	$jobId2 = "complex"

	try 
	{
		# Create a simple job
		$poolInformation1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
		$poolInformation1.PoolId = $poolId = "testPool"
		New-AzureBatchJob_ST -Id $jobId1 -PoolInformation $poolInformation1 -BatchContext $context
		$job1 = Get-AzureBatchJob_ST -Id $jobId1 -BatchContext $context

		# Verify created job matches expectations
		Assert-AreEqual $jobId1 $job1.Id
		Assert-AreEqual $poolId $job1.PoolInformation.PoolId

		# Create a complicated job
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
		$autoPoolSpec.PoolLifeTimeOption = $poolLifeTime = ([Microsoft.Azure.Batch.Common.PoolLifeTimeOption]::Job)

		$poolInformation2 = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
		$poolInformation2.AutoPoolSpecification = $autoPoolSpec

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

		$metadata = @{"meta1"="value1";"meta2"="value2"}
		$commonEnvSettings = @{"commonEnv1"="envValue1";"commonEnv2"="envValue2"}

		$displayName = "displayName"
		$priority = 1

		New-AzureBatchJob_ST -Id $jobId2 -DisplayName $displayName -CommonEnvironmentSettings $commonEnvSettings -Constraints $jobConstraints -JobManagerTask $jobMgr -JobPreparationTask $jobPrep -JobReleaseTask $jobRelease -PoolInformation $poolInformation2 -Metadata $metadata -Priority $priority -BatchContext $context
		
		$job2 = Get-AzureBatchJob_ST -Id $jobId2 -BatchContext $context
		
		# Verify created job matches expectations
		Assert-AreEqual $jobId2 $job2.Id
		Assert-AreEqual $displayName $job2.DisplayName
		Assert-AreEqual $autoPoolIdPrefix $job2.PoolInformation.AutoPoolSpecification.AutoPoolIdPrefix
		Assert-AreEqual $keepAlive $job2.PoolInformation.AutoPoolSpecification.KeepAlive
		Assert-AreEqual $poolLifeTime $job2.PoolInformation.AutoPoolSpecification.PoolLifeTimeOption
		Assert-AreEqual $targetDedicated $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetDedicated
		Assert-AreEqual $vmSize $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.VirtualMachineSize
		Assert-AreEqual $osFamily $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.OSFamily
		Assert-AreEqual $targetOS $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetOSVersion
		Assert-AreEqual $certRefCount $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences.Count
		Assert-AreEqual $storeLocation $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreLocation
		Assert-AreEqual $storeName $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].StoreName
		Assert-AreEqual $thumbprint $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Thumbprint
		Assert-AreEqual $thumbprintAlgorithm $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].ThumbprintAlgorithm
		Assert-AreEqual $visibility $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences[0].Visibility
		Assert-AreEqual $startTaskCmd $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.CommandLine
		Assert-AreEqual $jobMgrCmd $job2.JobManagerTask.CommandLine
		Assert-AreEqual $envCount $job2.JobManagerTask.EnvironmentSettings.Count
		Assert-AreEqual $env1Name $job2.JobManagerTask.EnvironmentSettings[0].Name
		Assert-AreEqual $env1Value $job2.JobManagerTask.EnvironmentSettings[0].Value
		Assert-AreEqual $env2Name $job2.JobManagerTask.EnvironmentSettings[1].Name
		Assert-AreEqual $env2Value $job2.JobManagerTask.EnvironmentSettings[1].Value
		Assert-AreEqual $resourceFileCount $job2.JobManagerTask.ResourceFiles.Count
		Assert-AreEqual $blobSource $job2.JobManagerTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $filePath $job2.JobManagerTask.ResourceFiles[0].FilePath
		Assert-AreEqual $killOnCompletion $job2.JobManagerTask.KillJobOnCompletion
		Assert-AreEqual $jobMgrId $job2.JobManagerTask.Id
		Assert-AreEqual $jobMgrDisplay $job2.JobManagerTask.DisplayName
		Assert-AreEqual $runElevated $job2.JobManagerTask.RunElevated
		Assert-AreEqual $jobMgrMaxWallClockTime $job2.JobManagerTask.Constraints.MaxWallClockTime
		Assert-AreEqual $jobPrepCmd $job2.JobPreparationTask.CommandLine
		Assert-AreEqual $jobPrepEnvCount $job2.JobPreparationTask.EnvironmentSettings.Count
		Assert-AreEqual $jobPrepEnv1Name $job2.JobPreparationTask.EnvironmentSettings[0].Name
		Assert-AreEqual $jobPrepEnv1Value $job2.JobPreparationTask.EnvironmentSettings[0].Value
		Assert-AreEqual $jobPrepEnv2Name $job2.JobPreparationTask.EnvironmentSettings[1].Name
		Assert-AreEqual $jobPrepEnv2Value $job2.JobPreparationTask.EnvironmentSettings[1].Value
		Assert-AreEqual $jobPrepResourceFileCount $job2.JobPreparationTask.ResourceFiles.Count
		Assert-AreEqual $jobPrepBlobSource $job2.JobPreparationTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $jobPrepFilePath $job2.JobPreparationTask.ResourceFiles[0].FilePath
		Assert-AreEqual $jobPrepId $job2.JobPreparationTask.Id
		Assert-AreEqual $jobPrepRunElevated $job2.JobPreparationTask.RunElevated
		Assert-AreEqual $jobPrepRetryCount $job2.JobPreparationTask.Constraints.MaxTaskRetryCount
		Assert-AreEqual $jobReleaseCmd $job2.JobReleaseTask.CommandLine
		Assert-AreEqual $jobReleaseEnvCount $job2.JobReleaseTask.EnvironmentSettings.Count
		Assert-AreEqual $jobReleaseEnv1Name $job2.JobReleaseTask.EnvironmentSettings[0].Name
		Assert-AreEqual $jobReleaseEnv1Value $job2.JobReleaseTask.EnvironmentSettings[0].Value
		Assert-AreEqual $jobReleaseEnv2Name $job2.JobReleaseTask.EnvironmentSettings[1].Name
		Assert-AreEqual $jobReleaseEnv2Value $job2.JobReleaseTask.EnvironmentSettings[1].Value
		Assert-AreEqual $jobReleaseResourceFileCount $job2.JobReleaseTask.ResourceFiles.Count
		Assert-AreEqual $jobReleaseBlobSource $job2.JobReleaseTask.ResourceFiles[0].BlobSource
		Assert-AreEqual $jobReleaseFilePath $job2.JobReleaseTask.ResourceFiles[0].FilePath
		Assert-AreEqual $jobReleaseId $job2.JobReleaseTask.Id
		Assert-AreEqual $jobReleaseRunElevated $job2.JobReleaseTask.RunElevated
		Assert-AreEqual $maxTaskRetry $job2.Constraints.MaxTaskRetryCount
		Assert-AreEqual $maxWallClockTime $job2.Constraints.MaxWallClockTime
		Assert-AreEqual $priority $job2.Priority
		Assert-AreEqual $metadata.Count $job2.Metadata.Count
		foreach($m in $job2.Metadata)
		{
			Assert-AreEqual $metadata[$m.Name] $m.Value
		}
		Assert-AreEqual $commonEnvSettings.Count $job2.CommonEnvironmentSettings.Count
		foreach($e in $job2.CommonEnvironmentSettings)
		{
			Assert-AreEqual $commonEnvSettings[$e.Name] $e.Value
		}
	}
	finally
	{
		Remove-AzureBatchJob_ST -Id $jobId1 -Force -BatchContext $context
		Remove-AzureBatchJob_ST -Id $jobId2 -Force -BatchContext $context
	}
}


<#
.SYNOPSIS
Tests querying for a Batch job by id
#>
function Test-GetJobById
{
	param([string]$accountName, [string]$jobId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$job = Get-AzureBatchJob_ST -Id $jobId -BatchContext $context

	Assert-AreEqual $jobId $job.Id

	# Verify positional parameters also work
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context

	Assert-AreEqual $jobId $job.Id
}

<#
.SYNOPSIS
Tests querying for Batch jobs using a filter
#>
function Test-ListJobsByFilter
{
	param([string]$accountName, [string]$state, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "state eq'" + "$state" + "'"

	$jobs = Get-AzureBatchJob_ST -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $jobs.Length
	foreach($job in $jobs)
	{
		Assert-True { $job.Id.StartsWith("$idPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch jobs and supplying a max count
#>
function Test-ListJobsWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobs = Get-AzureBatchJob_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $jobs.Length
}

<#
.SYNOPSIS
Tests querying for all jobs
#>
function Test-ListAllJobs
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobs = Get-AzureBatchJob_ST -BatchContext $context

	Assert-AreEqual $count $jobs.Length
}

<#
.SYNOPSIS
Tests listing the jobs under a job schedule
#>
function Test-ListJobsUnderSchedule
{
	param([string]$accountName, [string]$jobScheduleId, [string]$jobId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$jobSchedule = Get-AzureBatchJobSchedule_ST -Id $jobScheduleId -BatchContext $context

	# Verify that listing jobs works
	$allJobs = Get-AzureBatchJob_ST -BatchContext $context
	$scheduleJobs = Get-AzureBatchJob_ST -JobScheduleId $jobSchedule.Id -BatchContext $context

	Assert-AreEqual $count $scheduleJobs.Count
	Assert-True { $scheduleJobs.Count -lt $allJobs.Count }

	# Verify that pipelining also works
	$scheduleJobs = $jobSchedule | Get-AzureBatchJob_ST -BatchContext $context
		
	Assert-AreEqual $count $scheduleJobs.Count
	Assert-True { $scheduleJobs.Count -lt $allJobs.Count }

	# Verify that filter works
	$filter = "id eq '" + $jobId + "'"
	$job = Get-AzureBatchJob_ST -JobScheduleId $jobScheduleId -Filter $filter -BatchContext $context

	Assert-AreEqual $jobId $job.Id
}

<#
.SYNOPSIS
Tests deleting a job
#>
function Test-DeleteJob
{
	param([string]$accountName, [string]$jobId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the job exists
	$jobs = Get-AzureBatchJob_ST -BatchContext $context
	Assert-AreEqual 1 $jobs.Count

	if ($usePipeline -eq '1')
	{
		Get-AzureBatchJob_ST -Id $jobId -BatchContext $context | Remove-AzureBatchJob_ST -Force -BatchContext $context
	}
	else
	{
		Remove-AzureBatchJob_ST -Id $jobId -Force -BatchContext $context
	}

	# Verify the job was deleted
	$jobs = Get-AzureBatchJob_ST -BatchContext $context
	Assert-True { $jobs -eq $null -or $jobs[0].State.ToString().ToLower() -eq 'deleting' }
}

<#
.SYNOPSIS
Tests disabling and enabling a job
#>
function Test-DisableAndEnableJob
{
	param([string]$accountName, [string]$jobId)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	# Verify the job is Active
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	Assert-AreEqual 'Active' $job.State

	Disable-AzureBatchJob_ST $jobId Terminate -BatchContext $context

	# Verify the job was Disabled
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	Assert-AreEqual 'Disabled' $job.State

	Enable-AzureBatchJob_ST $jobId -BatchContext $context

	# Verify the job is again active
	$job = Get-AzureBatchJob_ST -Filter "id eq '$jobId'" -BatchContext $context
	Assert-AreEqual 'Active' $job.State

	# Verify using the pipeline
	$job | Disable-AzureBatchJob_ST -DisableJobOption Terminate -BatchContext $context
	$job = Get-AzureBatchJob_ST $jobId -BatchContext $context
	Assert-AreEqual 'Disabled' $job.State

	$job | Enable-AzureBatchJob_ST -BatchContext $context
	$job = Get-AzureBatchJob_ST -Filter "id eq '$jobId'" -BatchContext $context
	Assert-AreEqual 'Active' $job.State
}