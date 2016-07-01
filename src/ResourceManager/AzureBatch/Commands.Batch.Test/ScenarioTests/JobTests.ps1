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
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    
    $jobId1 = "simple"
    $jobId2 = "complex"

    try 
    {
        # Create a simple job
        $poolInformation1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
        $poolInformation1.PoolId = $poolId = "testPool"
        New-AzureBatchJob -Id $jobId1 -PoolInformation $poolInformation1 -BatchContext $context
        $job1 = Get-AzureBatchJob -Id $jobId1 -BatchContext $context

        # Verify created job matches expectations
        Assert-AreEqual $jobId1 $job1.Id
        Assert-AreEqual $poolId $job1.PoolInformation.PoolId

        # Create a complicated job
        $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
        $startTaskCmd = "cmd /c dir /s"
        $startTask.CommandLine = $startTaskCmd

        $osFamily = 4
        $targetOS = "*"
        $paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

        $poolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
        $poolSpec.TargetDedicated = $targetDedicated = 3
        $poolSpec.VirtualMachineSize = $vmSize = "small"
        $poolSpec.CloudServiceConfiguration = $paasConfiguration
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

        New-AzureBatchJob -Id $jobId2 -DisplayName $displayName -CommonEnvironmentSettings $commonEnvSettings -Constraints $jobConstraints -JobManagerTask $jobMgr -JobPreparationTask $jobPrep -JobReleaseTask $jobRelease -PoolInformation $poolInformation2 -Metadata $metadata -Priority $priority -BatchContext $context
        
        $job2 = Get-AzureBatchJob -Id $jobId2 -BatchContext $context
        
        # Verify created job matches expectations
        Assert-AreEqual $jobId2 $job2.Id
        Assert-AreEqual $displayName $job2.DisplayName
        Assert-AreEqual $autoPoolIdPrefix $job2.PoolInformation.AutoPoolSpecification.AutoPoolIdPrefix
        Assert-AreEqual $keepAlive $job2.PoolInformation.AutoPoolSpecification.KeepAlive
        Assert-AreEqual $poolLifeTime $job2.PoolInformation.AutoPoolSpecification.PoolLifeTimeOption
        Assert-AreEqual $targetDedicated $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetDedicated
        Assert-AreEqual $vmSize $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.VirtualMachineSize
        Assert-AreEqual $osFamily $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CloudServiceConfiguration.OSFamily
        Assert-AreEqual $targetOS $job2.PoolInformation.AutoPoolSpecification.PoolSpecification.CloudServiceConfiguration.TargetOSVersion
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
        Remove-AzureBatchJob -Id $jobId1 -Force -BatchContext $context
        Remove-AzureBatchJob -Id $jobId2 -Force -BatchContext $context
    }
}


<#
.SYNOPSIS
Tests querying for a Batch job by id
#>
function Test-GetJobById
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $job = Get-AzureBatchJob -Id $jobId -BatchContext $context

    Assert-AreEqual $jobId $job.Id

    # Verify positional parameters also work
    $job = Get-AzureBatchJob $jobId -BatchContext $context

    Assert-AreEqual $jobId $job.Id
}

<#
.SYNOPSIS
Tests querying for Batch jobs using a filter
#>
function Test-ListJobsByFilter
{
    param([string]$prefix, [string]$matches)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "startswith(id,'$prefix')"

    $jobs = Get-AzureBatchJob -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $jobs.Length
    foreach($job in $jobs)
    {
        Assert-True { $job.Id.StartsWith("$prefix") }
    }
}

<#
.SYNOPSIS
Tests querying for Batch job using a select clause
#>
function Test-GetAndListJobsWithSelect
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "id eq '$jobId'"
    $selectClause = "id,state"

    # Test with Get job API
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-AreNotEqual $null $job.ExecutionInformation
    Assert-AreEqual $jobId $job.Id

    $job = Get-AzureBatchJob $jobId -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $job.ExecutionInformation
    Assert-AreEqual $jobId $job.Id

    # Test with List jobs API
    $job = Get-AzureBatchJob -Filter $filter -BatchContext $context
    Assert-AreNotEqual $null $job.ExecutionInformation
    Assert-AreEqual $jobId $job.Id

    $job = Get-AzureBatchJob -Filter $filter -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $job.ExecutionInformation
    Assert-AreEqual $jobId $job.Id
}

<#
.SYNOPSIS
Tests querying for Batch jobs and supplying a max count
#>
function Test-ListJobsWithMaxCount
{
    param([string]$maxCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $jobs = Get-AzureBatchJob -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $jobs.Length
}

<#
.SYNOPSIS
Tests querying for all jobs
#>
function Test-ListAllJobs
{
    param([string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $jobs = Get-AzureBatchJob -BatchContext $context

    Assert-AreEqual $count $jobs.Length
}

<#
.SYNOPSIS
Tests listing the jobs under a job schedule
#>
function Test-ListJobsUnderSchedule
{
    param([string]$jobScheduleId, [string]$jobId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $jobSchedule = Get-AzureBatchJobSchedule -Id $jobScheduleId -BatchContext $context

    # Verify that listing jobs works
    $allJobs = Get-AzureBatchJob -BatchContext $context
    $scheduleJobs = Get-AzureBatchJob -JobScheduleId $jobSchedule.Id -BatchContext $context

    Assert-AreEqual $count $scheduleJobs.Count
    Assert-True { $scheduleJobs.Count -lt $allJobs.Count }

    # Verify that pipelining also works
    $scheduleJobs = $jobSchedule | Get-AzureBatchJob -BatchContext $context
        
    Assert-AreEqual $count $scheduleJobs.Count
    Assert-True { $scheduleJobs.Count -lt $allJobs.Count }

    # Verify that filter works
    $filter = "id eq '" + $jobId + "'"
    $job = Get-AzureBatchJob -JobScheduleId $jobScheduleId -Filter $filter -BatchContext $context

    Assert-AreEqual $jobId $job.Id
}

<#
.SYNOPSIS
Tests updating a job
#>
function Test-UpdateJob
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $osFamily = 4
    $targetOS = "*"
    $paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

    # Create the job with an auto pool
    $poolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
    $poolSpec.TargetDedicated = 3
    $poolSpec.VirtualMachineSize = "small"
    $poolSpec.CloudServiceConfiguration = $paasConfiguration
    $poolSpec.Metadata = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSMetadataItem]
    $poolSpecMetaItem = New-Object Microsoft.Azure.Commands.Batch.Models.PSMetadataItem -ArgumentList "meta1","value1"
    $poolSpec.Metadata.Add($poolSpecMetaItem)

    $autoPoolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
    $autoPoolSpec.PoolSpecification = $poolSpec
    $autoPoolSpec.AutoPoolIdPrefix = $autoPoolIdPrefix = "TestSpecPrefix"
    $autoPoolSpec.KeepAlive = $keepAlive = $true
    $autoPoolSpec.PoolLifeTimeOption = ([Microsoft.Azure.Batch.Common.PoolLifeTimeOption]::Job)

    $poolInformation = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
    $poolInformation.AutoPoolSpecification = $autoPoolSpec

    try
    {
        New-AzureBatchJob -Id $jobId -PoolInformation $poolInformation -BatchContext $context

        # Update the job. On the PoolInformation property, only the AutoPoolSpecification.KeepAlive property can be updated, and only when the job is Disabled.
        $job = Get-AzureBatchJob $jobId -BatchContext $context
        $job | Disable-AzureBatchJob -DisableJobOption Terminate -BatchContext $context

        $priority = 3
        $newKeepAlive = !$keepAlive
        $jobConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSJobConstraints -ArgumentList @([TimeSpan]::FromDays(1),5)
        $maxWallClockTime = $jobConstraints.MaxWallClockTime
        $maxTaskRetry = $jobConstraints.MaxTaskRetryCount
        $jobMetadata = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSMetadataItem]
        $jobMetadataItem = New-Object Microsoft.Azure.Commands.Batch.Models.PSMetadataItem -ArgumentList "jobMeta1","jobValue1"
        $jobMetadata.Add($jobMetadataItem)

        $job.Priority = $priority
        $job.Constraints = $jobConstraints
        $job.PoolInformation.AutoPoolSpecification.KeepAlive = $newKeepAlive
        $job.Metadata = $jobMetadata

        $job | Set-AzureBatchJob -BatchContext $context

        # Verify the job was updated
        $job = Get-AzureBatchJob -BatchContext $context

        Assert-AreEqual $priority $job.Priority
        Assert-AreEqual $newKeepAlive $job.PoolInformation.AutoPoolSpecification.KeepAlive
        Assert-AreEqual $maxWallClockTime $job.Constraints.MaxWallClockTime
        Assert-AreEqual $maxTaskRetry $job.Constraints.MaxTaskRetryCount
        Assert-AreEqual $jobMetadata.Count $job.Metadata.Count
        Assert-AreEqual $jobMetadata[0].Name $job.Metadata[0].Name
        Assert-AreEqual $jobMetadata[0].Value $job.Metadata[0].Value
    }
    finally
    {
        # Cleanup job and autopool
        Remove-AzureBatchJob $jobId -Force -BatchContext $context
        Get-AzureBatchPool -Filter "startswith(id,'$autoPoolIdPrefix')" -BatchContext $context | Remove-AzureBatchPool -Force -BatchContext $context
    }

}


<#
.SYNOPSIS
Tests deleting a job
#>
function Test-DeleteJob
{
    param([string]$jobId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Verify the job exists
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-AreNotEqual $null $job

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchJob -Id $jobId -BatchContext $context | Remove-AzureBatchJob -Force -BatchContext $context
    }
    else
    {
        Remove-AzureBatchJob -Id $jobId -Force -BatchContext $context
    }

    # Verify the job was deleted
    $jobs = Get-AzureBatchJob -Filter "id eq '$jobId'" -BatchContext $context
    Assert-True { $jobs -eq $null -or $jobs[0].State.ToString().ToLower() -eq 'deleting' }
}

<#
.SYNOPSIS
Tests disabling and enabling a job
#>
function Test-DisableAndEnableJob
{
    param([string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Verify the job is Active
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-AreEqual 'Active' $job.State

    Disable-AzureBatchJob $jobId Terminate -BatchContext $context

    # Verify the job was Disabled
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-True { ($job.State.ToString().ToLower() -eq 'disabled') -or ($job.State.ToString().ToLower() -eq 'disabling') }

    Enable-AzureBatchJob $jobId -BatchContext $context

    # Verify the job is again active
    $job = Get-AzureBatchJob -Filter "id eq '$jobId'" -BatchContext $context
    Assert-AreEqual 'Active' $job.State

    # Verify using the pipeline
    $job | Disable-AzureBatchJob -DisableJobOption Terminate -BatchContext $context
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-True { ($job.State.ToString().ToLower() -eq 'disabled') -or ($job.State.ToString().ToLower() -eq 'disabling') }

    $job | Enable-AzureBatchJob -BatchContext $context
    $job = Get-AzureBatchJob -Filter "id eq '$jobId'" -BatchContext $context
    Assert-AreEqual 'Active' $job.State
}

<#
.SYNOPSIS
Tests terminating a job
#>
function Test-TerminateJob
{
    param([string]$jobId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $terminateReason = "test"

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchJob -Id $jobId -BatchContext $context | Stop-AzureBatchJob -TerminateReason $terminateReason -BatchContext $context
    }
    else
    {
        Stop-AzureBatchJob $jobId $terminateReason -BatchContext $context
    }

    # Verify the job was terminated and that the terminate reason was set
    $job = Get-AzureBatchJob $jobId -BatchContext $context
    Assert-True { ($job.State.ToString().ToLower() -eq 'terminating') -or ($job.State.ToString().ToLower() -eq 'completed') }
    Assert-AreEqual $terminateReason $job.ExecutionInformation.TerminateReason
}

<#
.SYNOPSIS
Tests create job with TaskDependencies
#>
function Test-JobWithTaskDependencies
{
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $jobId = "testJob4"

    try
    {
        $osFamily = 4
        $targetOS = "*"
        $cmd = "cmd /c dir /s"
        $taskId = "taskId1"

        $paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

        $poolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
        $poolSpec.TargetDedicated = $targetDedicated = 3
        $poolSpec.VirtualMachineSize = $vmSize = "small"
        $poolSpec.CloudServiceConfiguration = $paasConfiguration
        $autoPoolSpec = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
        $autoPoolSpec.PoolSpecification = $poolSpec
        $autoPoolSpec.AutoPoolIdPrefix = $autoPoolIdPrefix = "TestSpecPrefix"
        $autoPoolSpec.KeepAlive =  $FALSE
        $autoPoolSpec.PoolLifeTimeOption = $poolLifeTime = ([Microsoft.Azure.Batch.Common.PoolLifeTimeOption]::Job)
        $poolInformation = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
        $poolInformation.AutoPoolSpecification = $autoPoolSpec

        $taskIds = @("2","3")
        $taskIdRange = New-Object Microsoft.Azure.Batch.TaskIdRange(1,10)
        $dependsOn = New-Object Microsoft.Azure.Batch.TaskDependencies -ArgumentList @([string[]]$taskIds, [Microsoft.Azure.Batch.TaskIdRange[]]$taskIdRange)
        New-AzureBatchJob -Id $jobId -BatchContext $context -PoolInformation $poolInformation -usesTaskDependencies
        New-AzureBatchTask -Id $taskId -CommandLine $cmd -BatchContext $context -DependsOn $dependsOn -JobId $jobId
        $job = Get-AzureBatchJob -Id $jobId -BatchContext $context

        Assert-AreEqual $job.UsesTaskDependencies $TRUE
        $task = Get-AzureBatchTask -JobId $jobId -Id $taskId -BatchContext $context
        Assert-AreEqual $task.DependsOn.TaskIdRanges.End 10
        Assert-AreEqual $task.DependsOn.TaskIdRanges.Start 1
        Assert-AreEqual $task.DependsOn.TaskIds[0] 2
        Assert-AreEqual $task.DependsOn.TaskIds[1] 3
    }
    finally
    {
        Remove-AzureBatchJob -Id $jobId -Force -BatchContext $context
    }
}