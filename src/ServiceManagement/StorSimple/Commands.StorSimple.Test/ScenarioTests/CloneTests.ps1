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

Import-Module .\BackupTests.ps1

<#
.SYNOPSIS
Gets device name to use for the test
#>
function Get-SecondDeviceName ()
{
	$selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
	$deviceName = (Get-AzureStorSimpleDevice) | Where{$_.Status -eq "Online"} | Select-Object -skip 1 -first 1 -wait | Select -ExpandProperty "FriendlyName"
	$pass = Assert-NotNull $deviceName
	$deviceName
}

<#
.SYNOPSIS
Tests create, get, clone, delete of backup.
#>
function Test-CloneSingleDeviceDefaultName
{
	# Unique object names
	$dcName = Generate-Name("VolumeContainer")
	$acrName = Generate-Name("ACR")
	$iqn = Generate-Name("IQN")
	$vdName = Generate-Name("Volume")
	$bpName = Generate-Name("BackupPolicy")

	# Setup
	$deviceName = Get-DeviceName
	SetupObjects-BackupScenario $deviceName $dcName $acrName $iqn $vdName
	
	# Test
	Create-CustomBackupPolicy $deviceName $vdName $bpName
	$bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	$bpId = $bpToUse.InstanceId

	Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete

	$retryCount = 0
	do {
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
		$backupToRestore = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 1
		$retryCount += 1
	} while(($backupToRestore -eq $null) -and ($retryCount -lt 10))
	Assert-NotNull $backupToRestore

	$backupId = $backupToRestore.InstanceId
	$snapshotToClone = $backupToRestore.Snapshots[0]
	$volumes = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	$volume = $volumes[0]
	$targetAcrList = $volume.AcrList

	Start-AzureStorSimpleDeviceCloneJob -SourceDeviceName $deviceName -TargetDeviceName $deviceName -BackupId $backupId  -Snapshot $backupToRestore.Snapshots[0] -TargetAccessControlRecords $targetAcrList -Force

	Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
	
	Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

	#Cleanup
	CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests create, get, clone, delete of backup.
#>
function Test-CloneSingleDeviceUserGivenName
{
	# Unique object names
	$dcName = Generate-Name("VolumeContainer")
	$acrName = Generate-Name("ACR")
	$iqn = Generate-Name("IQN")
	$vdName = Generate-Name("Volume")
	$bpName = Generate-Name("BackupPolicy")

	# Setup
	$deviceName = Get-DeviceName
	SetupObjects-BackupScenario $deviceName $dcName $acrName $iqn $vdName
	
	# Test
	Create-CustomBackupPolicy $deviceName $vdName $bpName
	$bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	$bpId = $bpToUse.InstanceId

	Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete

	$retryCount = 0
	do {
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
		$backupToRestore = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 1
		$retryCount += 1
	} while(($backupToRestore -eq $null) -and ($retryCount -lt 10))
	Assert-NotNull $backupToRestore

	$backupId = $backupToRestore.InstanceId
	$snapshotToClone = $backupToRestore.Snapshots[0]
	$volumes = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	$volume = $volumes[0]
	$targetAcrList = $volume.AcrList

	Start-AzureStorSimpleDeviceCloneJob -SourceDeviceName $deviceName -TargetDeviceName $deviceName -BackupId $backupId  -Snapshot $backupToRestore.Snapshots[0] -TargetAccessControlRecords $targetAcrList -CloneVolumeName $vdName + "_CustomName" -Force

	Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
	
	Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

	#Cleanup
	CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests create, get, clone, delete of backup.
#>
function Test-CloneMultipleDeviceUserGivenName
{
	# Unique object names
	$dcName = Generate-Name("VolumeContainer")
	$acrName = Generate-Name("ACR")
	$iqn = Generate-Name("IQN")
	$vdName = Generate-Name("Volume")
	$bpName = Generate-Name("BackupPolicy")

	# Setup
	$deviceName = Get-DeviceName
	$secondDeviceName = Get-SecondDeviceName
	SetupObjects-BackupScenario $deviceName $dcName $acrName $iqn $vdName
	
	# Test
	Create-CustomBackupPolicy $deviceName $vdName $bpName
	$bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	$bpId = $bpToUse.InstanceId

	Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete

	$retryCount = 0
	do {
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
		$backupToRestore = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 1
		$retryCount += 1
	} while(($backupToRestore -eq $null) -and ($retryCount -lt 10))
	Assert-NotNull $backupToRestore

	$backupId = $backupToRestore.InstanceId
	$snapshotToClone = $backupToRestore.Snapshots[0]
	$volumes = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	$volume = $volumes[0]
	$targetAcrList = $volume.AcrList

	Start-AzureStorSimpleDeviceCloneJob -SourceDeviceName $deviceName -TargetDeviceName $secondDeviceName -BackupId $backupId  -Snapshot $backupToRestore.Snapshots[0] -TargetAccessControlRecords $targetAcrList -CloneVolumeName $vdName + "_CustomName" -Force

	Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
	
	Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

	#Cleanup
	CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}
