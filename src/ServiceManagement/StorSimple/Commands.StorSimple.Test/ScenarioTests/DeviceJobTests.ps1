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

import-module .\backuptests.ps1

<#
.SYNOPSIS
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
}

function Start-BackupJob($deviceName){
	# Unique object names
	$dcName = Generate-Name("VolumeContainer")
    $acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")
    $vdName = Generate-Name("Volume")
    $bpName = Generate-Name("BackupPolicy")

    # Setup a backup policy for use
    $deviceName = Get-DeviceName
    SetupObjects-BackupScenario $deviceName $dcName $acrName $iqn $vdName 100000000000
    Create-CustomBackupPolicy $deviceName $vdName $bpName
	$bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	$bpId = $bpToUse.InstanceId

    # Schedule a backup jobs
    Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete
}

function Get-OnlineDevice{
    # Get hold of an online device.
    $onlineDevices = @(Get-AzureStorSimpleDevice -Detailed | Where { $_.DeviceProperties.Status -eq "Online"})
    Assert-AreNotEqual $onlineDevices.Count 0 "No online devices found."
	return $onlineDevices[-1]
}

function Test-GetDeviceJobs{
    Set-DefaultResource 

    $onlineDevice = Get-OnlineDevice

    $deviceName = $onlineDevice.DeviceProperties.FriendlyName
    
    # Start a backup job on it.
    Start-BackupJob $deviceName

    # Fetch all backup jobs on this device. Make sure the list has >1 jobs.
    $jobs = Get-AzureStorSimpleJob -Type Backup -Skip 0 -First 10
    Assert-AreNotEqual 0 @($jobs).Count "Expected to find a backup job on the device."
    
    # Verify that all jobs returned have the type backup
    for($i=0; $i -lt $jobs.Count; $i++){
        Assert-AreEqual $jobs[$i].Type "Backup" 
    }
}

function Test-StopDeviceJob{
	Set-DefaultResource

    # Get hold of an online device.
    $onlineDevice = Get-OnlineDevice

	$deviceName = $onlineDevice.DeviceProperties.FriendlyName

	# Schedule a backup job
	Start-BackupJob $deviceName

	# Get all jobs on the device and find a running cancellable job
	$jobs = Get-AzureStorSimpleJob -DeviceName $deviceName -First 10
	Assert-AreNotEqual 0 @($jobs).Count "Expected to find a backup job on the device."

	#filter for cancellable jobs with status running
	$cancellableJobs = @($jobs | Where { $_.Status -eq "Running" -and $_.IsJobCancellable })
	Assert-AreNotEqual 0 $cancellableJobs.Count "No cancellable running jobs found"
	$cancellableJob = $cancellableJobs[-1]

	# cancel the job
	$result = Stop-AzureStorSimpleJob -JobId $cancellableJob.InstanceId

	Assert-AreNotEqual $result $null "Failed to stop the job, got a null object"
}

function Test-StopDeviceJobsNonCancellable{
	Set-DefaultResource

    # Get hold of an online device.
    $onlineDevice = Get-OnlineDevice

	$deviceName = $onlineDevice.DeviceProperties.FriendlyName

	# Get all jobs and find a non-cancellable job
	$jobs = Get-AzureStorSimpleJob -DeviceName $deviceName
	Assert-AreNotEqual 0 @($jobs).Count "No jobs available on device."

	$nonCancellableJobs = @($jobs | Where { $_.IsJobCancellable })
	Assert-AreNotEqual 0 $nonCancellableJobs.Count "No non-cancellable jobs found"
	$nonCancellableJob = $nonCancellableJobs[-1]
	
	$retVal = Stop-AzureStorSimpleJob -JobId $nonCancellableJob.InstanceId

	# Assert throws an exception if possible
	Assert-AreEqual $retVal $null
}

function Test-GetAzureStorSimpleJobPagination{
	Set-DefaultResource

    # Get hold of an online device.
    $onlineDevice = Get-OnlineDevice

	$deviceName = $onlineDevice.DeviceProperties.FriendlyName

	# Get all jobs and find a non-cancellable job
	$jobs = @(Get-AzureStorSimpleJob -DeviceName $deviceName -First 100)
	Assert-AreNotEqual $jobs.Count 0 "No jobs found"
	Assert-AreEqual ($jobs.Count -gt 3) $true "Need atleast 3 jobs on the device"

	$num_pages = [Math]::Ceiling(($jobs.Count-1)/3)
	for($i = 0; $i -lt $num_pages; $i++){
		$skip = 3 * $i
		$jobsInPage = @(Get-AzureStorSimpleJob -DeviceName $deviceName -skip $skip -First 3)
		$expected = 3
		if($i -eq $num_pages-1){
			$expected = ($jobs.Count-1) % 3
		}
		Assert-AreEqual ($jobsInPage.Count-1) $expected
	}
}


function Test-GetJobsByStatus{
	# It is expected that by the time this test runs, there will be some completed jobs in the resource

    Set-DefaultResource 

    $onlineDevice = Get-OnlineDevice

    $deviceName = $onlineDevice.DeviceProperties.FriendlyName
    
    # Fetch all backup jobs on this device. Make sure the list has >1 jobs.
    $jobs = Get-AzureStorSimpleJob -Status Completed -Skip 0 -First 10
    Assert-AreNotEqual 0 @($jobs).Count "No completed jobs found on the device."
    
    # Verify that all jobs returned have the type backup
    for($i=0; $i -lt $jobs.Count-1; $i++){
        Assert-AreEqual $jobs[$i].Status "Completed"
    }
}