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
Generates unique name with given prefix
#>
function Generate-Name ($prefix)
{
    $s = "Test" + $prefix
    #$s += "_"
    #$s += Get-Random
    $s
}

<#
.SYNOPSIS
Polls for a job to finish, and returns the JobStatus object
#>
function Wait-Job ($taskId)
{
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(3000) #sleep for 3sec
        $taskStatus = Get-AzureStorSimpleTask -InstanceId $taskId
        $result = $taskStatus.AsyncTaskAggregatedResult
    } while($result -eq [Microsoft.WindowsAzure.Management.StorSimple.Models.AsyncTaskAggregatedResult]"InProgress")
    Assert-AreEqual $result ([Microsoft.WindowsAzure.Management.StorSimple.Models.AsyncTaskAggregatedResult]"Succeeded")
}

<#
.SYNOPSIS
Returns default values for the test
#>
function Get-DefaultValue ($key)
{
    $defaults = @{
		StorageAccountName = "wuscisclcis1diagj5sy4";
		StorageAccountPrimaryAccessKey = "gLm0tjCPJAUKzBFEVjN92ZtEwKnQK8MLasuX/ymNwMRQWFGmUA5sWZUZt9u8JfouhhYyzb3v5RQWtZSX+GxMbg==";
		StorageAccountSecondaryAccessKey = "zLo+ziNdEX86ffu6OURQFNRL5lrLJpf9J9T8TOk6ne/Mpl7syq1DUp4TIprBt+DGPzo4ytAON+H1N4p6GRwVHg=="
	}

	return $defaults[$key];
}

<#
.SYNOPSIS
Gets device name to use for the test
#>
function Get-DeviceName ()
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
	$deviceName = (Get-AzureStorSimpleDevice) | Where{$_.Status -eq "Online"} | Select-Object -first 1 -wait | Select -ExpandProperty "FriendlyName"
    $pass = Assert-NotNull $deviceName
    $deviceName
}

<#
.SYNOPSIS
Creates pre-req objects for backup related tests
#>
function SetupObjects-BackupScenario($deviceName, $dcName, $acrName, $iqn, $vdName)
{
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
    $sacToUse = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName
    if($sacToUse -eq $null)
    {
        New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey -UseSSL $true -WaitForComplete
		$sacToUse = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName
    }
    Assert-NotNull $sacToUse

    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
    Assert-NotNull $dcToUse

    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    $acrList = @()
    $acrList += Get-AzureStorSimpleAccessControlRecord -ACRName $acrName
    Assert-AreNotEqual 0 @($acrList).Count
    
    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
    Assert-NotNull $vdToUse
}

<#
.SYNOPSIS
Deletes pre-req objects for backup related tests
#>
function CleanupObjects-BackupScenario($deviceName, $dcName, $acrName, $vdName)
{
    Set-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Online $false -WaitForComplete
    Remove-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Force -WaitForComplete

    Remove-AzureStorSimpleAccessControlRecord -Name $acrName -Force -WaitForComplete
    
	[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(90000)
	Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Name $dcName | Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete
}

<#
.SYNOPSIS
Creates a custom backup policy
#>
function Create-CustomBackupPolicy($deviceName, $vdName, $bpName)
{
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
    Assert-NotNull $vdToUse

    $schedule1 = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType LocalSnapshot -RecurrenceType Daily -RecurrenceValue 10 -RetentionCount 5 -Enabled $true
    $schedule2 = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType CloudSnapshot -RecurrenceType Hourly -RecurrenceValue 1 -RetentionCount 5 -Enabled $true
    $scheduleArray = @()
    $scheduleArray += $schedule1
    $scheduleArray += $schedule2
    $volumeArray = @()
    $volumeArray += $vdToUse.InstanceId
    
    New-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName -BackupSchedulesToAdd $scheduleArray -VolumeIdsToAdd $volumeArray -WaitForComplete
    $bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	Assert-NotNull $bpToUse
}

<#
.SYNOPSIS
Tests create, get and delete of backup policy.
#>
function Test-CreateGetDeleteBackupPolicy
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
    $bpList = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName
    Assert-AreNotEqual 0 @($bpList).Count
    $bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	$bpId = $bpToUse.InstanceId
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests renaming of backup policy.
#>
function Test-RenameBackupPolicy
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

    $updatedBpName = $bpName + "_updated"
    Set-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -BackupPolicyName $updatedBpName -WaitForComplete
    
    (Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $updatedBpName) | Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests addition of a volume to a backup policy.
#>
function Test-AddVolumeToBackupPolicy
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

    $vdNameToAdd = Generate-Name("VolumeToAdd")
    $acrList = @()
    $acrList += Get-AzureStorSimpleAccessControlRecord -ACRName $acrName
    (Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName) | 
        New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdNameToAdd -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
    $vdCreated = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdNameToAdd
    Assert-NotNull $vdCreated

    #FIX
    $volumeIds = @()
    foreach($volume in $bpToUse.Volumes) 
    {
        $volumeIds += $volume.InstanceId
    }
    $volumeIds += $vdCreated.InstanceId
    Set-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -BackupPolicyName $bpName -VolumeIdsToUpdate $volumeIds -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    Set-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdNameToAdd -Online $false -WaitForComplete
    Remove-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdNameToAdd -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests add, update and delete of schedule in a backup policy.
#>
function Test-AddUpdateDeleteScheduleInBackupPolicy
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

    $addArray = @()
    $updateArray=@()
    $deleteArray = @()

    $addConfig = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType CloudSnapshot -RecurrenceType Daily -RecurrenceValue 1 -RetentionCount 50 -Enabled $true
    $addArray += $addConfig
    
    $scheduleToDelete = $bpToUse.BackupSchedules | Where {$_.BackupType -eq [Microsoft.WindowsAzure.Management.StorSimple.Models.BackupType]::CloudSnapshot} | Select-Object -First 1 -wait
    $deleteArray += $scheduleToDelete.Id
    
    $scheduleToUpdate = $bpToUse.BackupSchedules | Where {$_.BackupType -eq [Microsoft.WindowsAzure.Management.StorSimple.Models.BackupType]::LocalSnapshot} | Select-Object -First 1 -wait
    $updateConfig = New-AzureStorSimpleDeviceBackupScheduleUpdateConfig -Id $scheduleToUpdate.Id -BackupType LocalSnapshot -RecurrenceType Daily -RecurrenceValue 3 -RetentionCount 2 -Enabled 1
    $updateArray += $updateConfig
    
    Set-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -BackupPolicyName $bpName -BackupSchedulesToAdd $addArray -BackupSchedulesToUpdate $updateArray -BackupScheduleIdsToDelete $deleteArray -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests create, get, restore, delete of backup.
#>
function Test-CreateGetRestoreDeleteBackup
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

    Start-AzureStorSimpleDeviceBackupRestoreJob -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete

    Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests retrieval of backup by backup policy id
#>
function Test-GetBackupByBackupPolicyId
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
        $backupCreated = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 1
        $retryCount += 1
    } while(($backupCreated -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupCreated

    $backupId = $backupCreated.InstanceId

    Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests retrieval of backup by backup policy object
#>
function Test-GetBackupByBackupPolicyObject
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
        $backupCreated = $bpToUse | Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -First 1
        $retryCount += 1
    } while(($backupCreated -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupCreated

    $backupId = $backupCreated.InstanceId

    Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests retrieval of backup by volume id
#>
function Test-GetBackupByVolumeId
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

    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
    $volumeId = $vdToUse.InstanceId

    Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete

    $retryCount = 0
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
        $backupCreated = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -VolumeId $volumeId -First 1
        $retryCount += 1
    } while(($backupCreated -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupCreated

    $backupId = $backupCreated.InstanceId

    Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests retrieval of backup by volume object
#>
function Test-GetBackupByVolumeObject
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

    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName

    Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete

    $retryCount = 0
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
        $backupCreated = $vdToUse | Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -First 1
        $retryCount += 1
    } while(($backupCreated -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupCreated

    $backupId = $backupCreated.InstanceId

    Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests retrieval of backup by mentioning start and end datetime
#>
function Test-GetBackupByTimePeriod
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
    $startDt = (Get-Date).AddDays(-1).Date.ToString("O")
    $endDt = (Get-Date).AddDays(1).Date.ToString("O")
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
        $backupCreated = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -From $startDt -To $endDt -First 1
        $retryCount += 1
    } while(($backupCreated -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupCreated

    $backupCreated | Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -Force -WaitForComplete
    
    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests paginated retrieval of backup by mentioning Skip and First
#>
function Test-GetPaginatedBackup
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
    
    $totalBackupCount = 10

    for($i = 0; $i -lt $totalBackupCount; $i++)
    {
        Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot -WaitForComplete
    }

    $retryCount = 0
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
        
		#Retrieving without First or Skip
        $allBackups = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId
        
		$retryCount += 1
    } while((@($allBackups).Count -lt $totalBackupCount) -and ($retryCount -le 10))

    #Retrieving with both First ans Skip
    $backupList = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 5 -Skip 3
    Assert-AreEqual @($backupList).Count 5

    #Retrieving with only First
    $backupList = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 2
    Assert-AreEqual @($backupList).Count 2

    #Retrieving with only Skip
    $backupList = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -Skip 6
    Assert-AreEqual @($backupList).Count 4

    for($i = 0; $i -lt $totalBackupCount; $i++)
    {
        Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $allBackups[$i].InstanceId -Force -WaitForComplete
    }

    Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force -WaitForComplete

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}

<#
.SYNOPSIS
Tests create, get, restore, delete of backup in async fashion
#>
function Test-CreateGetRestoreDeleteBackup_Async
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
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
    Assert-NotNull $vdToUse

    $schedule1 = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType LocalSnapshot -RecurrenceType Daily -RecurrenceValue 10 -RetentionCount 5 -Enabled $true
    $schedule2 = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType CloudSnapshot -RecurrenceType Hourly -RecurrenceValue 1 -RetentionCount 5 -Enabled $true
    $scheduleArray = @()
    $scheduleArray += $schedule1
    $scheduleArray += $schedule2
    $volumeArray = @()
    $volumeArray += $vdToUse.InstanceId
    
    $taskId = New-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName -BackupSchedulesToAdd $scheduleArray -VolumeIdsToAdd $volumeArray
    Wait-Job $taskId
    $bpToUse = Get-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyName $bpName
	Assert-NotNull $bpToUse
    $bpId = $bpToUse.InstanceId

    $taskId = Start-AzureStorSimpleDeviceBackupJob -DeviceName $deviceName -BackupPolicyId $bpId -BackupType CloudSnapshot
    Wait-Job $taskId

    $retryCount = 0
    do {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(5000*$retryCount)
        $backupToRestore = Get-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupPolicyId $bpId -First 1
        $retryCount += 1
    } while(($backupToRestore -eq $null) -and ($retryCount -lt 10))
    Assert-NotNull $backupToRestore

    $backupId = $backupToRestore.InstanceId
    $snapshotId = $backupToRestore.Snapshots[0].Id

    $taskId = Start-AzureStorSimpleDeviceBackupRestoreJob -DeviceName $deviceName -BackupId $backupId -Snapshot $snapshotId -Force
    Wait-Job $taskId

    $taskId = Remove-AzureStorSimpleDeviceBackup -DeviceName $deviceName -BackupId $backupId -Force
    Wait-Job $taskId
    
    $taskId = Remove-AzureStorSimpleDeviceBackupPolicy -DeviceName $deviceName -BackupPolicyId $bpId -Force
    Wait-Job $taskId

    #Cleanup
    CleanupObjects-BackupScenario $deviceName $dcName $acrName $vdName
}
