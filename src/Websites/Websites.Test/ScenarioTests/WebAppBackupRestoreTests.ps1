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

# !!! Storage keys and SAS URIs will be stored in the backup test recordings !!!
# To find them, open the json files in a text editor and search for "listkeys"
# to find the storage keys. Search for StorageAccountUrl to find the SAS URIs.
# Remove them when re-recording the tests so that secrets are not shared.

function Test-CreateNewWebAppBackup
{
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $backupName = Get-BackupName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoContainerName = 'container' + $rgName
    $stoType = 'Standard_LRS'

    try
    {
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
        # Create a backup of the web app
        $result = New-AzWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName 

        # Assert
        Assert-AreEqual $backupName $result.BackupName
        Assert-NotNull $result.StorageAccountUrl
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-CreateNewWebAppBackupPiping
{
    # Names and strings setup
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $backupName = Get-BackupName
    $backupName2 = Get-BackupName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoContainerName = 'container' + $rgName
    $stoType = 'Standard_LRS'

    try
    {
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
        # Create a backup of the web app
        $backup = $app | New-AzWebAppBackup -StorageAccountUrl $sasUri -BackupName $backupName

        # Assert
        Assert-AreEqual $backupName $backup.BackupName
        Assert-NotNull $backup.StorageAccountUrl

		$count = 0
		while (($backup.BackupStatus -like "Created" -or $backup.BackupStatus -like "InProgress") -and $count -le 20)
		{
			Wait-Seconds 30
		    $backup = $backup | Get-AzWebAppBackup
			$count++
		}

        # Test that it's possible to modify the return value of the cmdlet to make a new backup
        $backup.BackupName = $backupName2
        $backup2 = $backup | New-AzWebAppBackup

        # Assert
        Assert-AreEqual $backupName2 $backup2.BackupName
        Assert-NotNull $backup2.StorageAccountUrl
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppBackup
{
    # Names and strings setup
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $backupName = Get-BackupName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoType = 'Standard_LRS'
    $stoContainerName = 'container' + $rgName

    try
    {
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName

        # Create a backup of the web app
        $newBackup = New-AzWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName

        # Get the backup
        $result = Get-AzWebAppBackup -ResourceGroupName $rgName -Name $wName -BackupId $newBackup.BackupId

        # Assert
        Assert-AreEqual $backupName $result.BackupName
        Assert-NotNull $result.StorageAccountUrl
        Assert-NotNull $result.BackupId

        # Test piping - should be able to pipe result of previous get backup and get the same backup
        $pipeResult = $result | Get-AzWebAppBackup

        Assert-AreEqual $backupName $pipeResult.BackupName
        Assert-AreEqual $result.StorageAccountUrl $pipeResult.StorageAccountUrl 
        Assert-AreEqual $result.BackupId $pipeResult.BackupId
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppBackupList
{
    # Names and strings setup
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $backupName = Get-BackupName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoType = 'Standard_LRS'
    $stoContainerName = 'container' + $rgName

    try
    {
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
        
        # Create a backup of the web app
        $backup = New-AzWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

        # Get a list of the backups
        $backupList = Get-AzWebAppBackupList -ResourceGroupName $rgName -Name $wName
        $listBackup = $backupList | where {$_.BackupId -eq $backup.BackupId}

        # Assert
        Assert-AreEqual 1 $backupList.Count
        Assert-NotNull $listBackup
        Assert-AreEqual $backup.BackupName $listBackup.BackupName

        # Test piping
        $pipeBackupList = $app | Get-AzWebAppBackupList
        $pipeBackup = $pipeBackupList | where {$_.BackupId -eq $backup.BackupId}

        # Assert
        Assert-AreEqual 1 $pipeBackupList.Count
        Assert-NotNull $pipeBackup
        Assert-AreEqual $backup.BackupName $pipeBackup.BackupName
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-EditAndGetWebAppBackupConfiguration
{
    # Names and strings setup
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoContainerName = 'container' + $rgName
    $stoType = 'Standard_LRS'

    try
    {
        # Setup
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
        $startTime = (Get-Date).ToUniversalTime().AddDays(1)
        $frequencyInterval = 7
        $frequencyUnit = "Day"
        $retentionPeriod = 3

        # Set the backup configuration
        $config = Edit-AzWebAppBackupConfiguration `
            -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri `
            -FrequencyInterval $frequencyInterval -FrequencyUnit $frequencyUnit `
            -RetentionPeriodInDays $retentionPeriod -StartTime $startTime `
            -KeepAtLeastOneBackup 

        # Assert
        Assert-True { $config.Enabled }
        Assert-NotNull $config.StorageAccountUrl
        Assert-AreEqual $frequencyInterval $config.FrequencyInterval
        Assert-AreEqual $frequencyUnit $config.FrequencyUnit 
        Assert-True { $config.KeepAtLeastOneBackup }
        Assert-AreEqual $retentionPeriod $config.RetentionPeriodInDays
        # Cannot assert equality because time will be different in playback mode
        Assert-NotNull $config.StartTime

        # Get the configuration and verify it's the same
        $getConfig = Get-AzWebAppBackupConfiguration -ResourceGroupName $rgName -Name $wName

        # Assert
        Assert-True { $getConfig.Enabled }
        Assert-NotNull $getConfig.StorageAccountUrl
        Assert-AreEqual $frequencyInterval $getConfig.FrequencyInterval
        Assert-AreEqual $frequencyUnit $getConfig.FrequencyUnit 
        Assert-True { $getConfig.KeepAtLeastOneBackup }
        Assert-AreEqual $retentionPeriod $getConfig.RetentionPeriodInDays
        # Cannot assert equality because time will be different in playback mode
        Assert-NotNull $getConfig.StartTime
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-EditAndGetWebAppBackupConfigurationPiping
{
    # Names and strings setup
    $rgName = Get-ResourceGroupName
    $wName = Get-WebsiteName
    $location = Get-Location
    $whpName = Get-WebHostPlanName
    $tier = "Standard"
    $stoName = 'sto' + $rgName
    $stoContainerName = 'container' + $rgName
    $stoType = 'Standard_LRS'

    try
    {
        # Setup
        $app = Create-TestWebApp $rgName $location $whpName $tier $wName
        $sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
        $startTime = (Get-Date).ToUniversalTime().AddDays(1)
        $frequencyInterval = 7
        $frequencyUnit = "Day"
        $retentionPeriod = 3

        # Test piping a web app in
        $app | Edit-AzWebAppBackupConfiguration `
            -StorageAccountUrl $sasUri -FrequencyInterval $frequencyInterval `
            -FrequencyUnit $frequencyUnit -RetentionPeriodInDays $retentionPeriod `
            -StartTime $startTime -KeepAtLeastOneBackup
        $config = $app | Get-AzWebAppBackupConfiguration

        # Assert
        Assert-True { $config.Enabled }
        Assert-NotNull $config.StorageAccountUrl
        Assert-AreEqual $frequencyInterval $config.FrequencyInterval
        Assert-AreEqual $frequencyUnit $config.FrequencyUnit 
        Assert-True { $config.KeepAtLeastOneBackup }
        Assert-AreEqual $retentionPeriod $config.RetentionPeriodInDays
        # Cannot assert equality because time will be different in playback mode
        Assert-NotNull $config.StartTime

        # Test piping a modified configuration object into the Edit cmdlet
        $newFrequencyInterval = 5
        $newRetentionPeriod = 2
        $newFrequencyUnit = "Hour"
        $config.FrequencyInterval = $newFrequencyInterval
        $config.RetentionPeriodInDays = $newRetentionPeriod
        $config.FrequencyUnit = $newFrequencyUnit
        $config | Edit-AzWebAppBackupConfiguration
        $pipeConfig = $app | Get-AzWebAppBackupConfiguration

        # Assert
        Assert-True { $pipeConfig.Enabled }
        Assert-NotNull $pipeConfig.StorageAccountUrl
        Assert-AreEqual $newFrequencyInterval $pipeConfig.FrequencyInterval
        Assert-AreEqual $newFrequencyUnit $pipeConfig.FrequencyUnit 
        Assert-True { $pipeConfig.KeepAtLeastOneBackup }
        Assert-AreEqual $newRetentionPeriod $pipeConfig.RetentionPeriodInDays
        # Cannot assert equality because time will be different in playback mode
        Assert-NotNull $pipeConfig.StartTime
    }
    finally
    {
        # Cleanup
        Remove-AzStorageAccount -ResourceGroupName $rgName -Name $stoName
        Remove-AzWebApp -ResourceGroupName $rgName -Name $wName -Force
        Remove-AzAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppSnapshot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$slotName = "staging"
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Premium"
	$isRecordMode = ((Get-WebsitesTestMode) -ne 'Playback')

	try
	{
		New-AzResourceGroup -Name $rgname -Location $location
		New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		$app = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName

		# Wait for at least 1 snapshot to exist
		while ($snap -eq $null)
		{
			$snap = Get-AzWebAppSnapshot $app
			if ($isRecordMode)
			{
				Start-Sleep -Seconds 60
			}
		}

		# Test named parameters
		$snapshots = Get-AzWebAppSnapshot -ResourceGroupName $rgname -Name $wname -UseDisasterRecovery
		Assert-True { $snapshots.Length -gt 0 }
		Assert-NotNull $snapshots[0]
		Assert-NotNull $snapshots[0].SnapshotTime
		Assert-AreEqual 'Production' $snapshots[0].Slot

		# Test positional parameters
		$snapshots = Get-AzWebAppSnapshot $rgname $wname
		Assert-True { $snapshots.Length -gt 0 }
		Assert-NotNull $snapshots[0]
		Assert-NotNull $snapshots[0].SnapshotTime
		Assert-AreEqual 'Production' $snapshots[0].Slot

		# Test snapshots for slots
		$snapshots = Get-AzWebAppSnapshot -ResourceGroupName $rgname -Name $wname -Slot $slotName
		Assert-True { $snapshots.Length -gt 0 }
		Assert-NotNull $snapshots[0]
		Assert-NotNull $snapshots[0].SnapshotTime
		Assert-AreEqual $slotName $snapshots[0].Slot

		# Test piping
		$app = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		$snapshots = $app | Get-AzWebAppSnapshot
		Assert-True { $snapshots.Length -gt 0 }
		Assert-NotNull $snapshots[0]
		Assert-NotNull $snapshots[0].SnapshotTime
		Assert-AreEqual 'Production' $snapshots[0].Slot

	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

function Test-RestoreWebAppSnapshot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$slotName = "staging"
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Premium"
	$isRecordMode = ((Get-WebsitesTestMode) -ne 'Playback')

	try
	{
		New-AzResourceGroup -Name $rgname -Location $location
		New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		$app = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName

		# Wait for at least 1 snapshot to exist
		while ($snap -eq $null)
		{
			$snap = Get-AzWebAppSnapshot $app
			if ($isRecordMode)
			{
				Start-Sleep -Seconds 60
			}
		}

		# Test overwrite
		$snapshot = (Get-AzWebAppSnapshot $rgname $wname)[0]
		Restore-AzWebAppSnapshot -ResourceGroupName $rgname -Name $wname -InputObject $snapshot -Force -RecoverConfiguration

		if ($isRecordMode)
		{
			Start-Sleep -Seconds 600
		}

		# Test restore to target slot
		# -UseDisasterRecovery is throwing an error. Rising a bug to investigate further.
		Restore-AzWebAppSnapshot $rgname $wname $slotName $snapshot -RecoverConfiguration  -Force

		if ($isRecordMode)
		{
			Start-Sleep -Seconds 600
		}

		# Test piping and background job
		$job = $snapshot | Restore-AzWebAppSnapshot -Force -AsJob
		$job | Wait-Job

		if ($isRecordMode)
		{
			Start-Sleep -Seconds 600
		}
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

function Test-GetDeletedWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$slotName = "staging"
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Standard"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force

		$deletedApp = Get-AzDeletedWebApp -ResourceGroupName $rgname -Name $wname -Slot "Production" -Location $location
		Assert-NotNull $deletedApp
		Assert-AreEqual $rgname $deletedApp.ResourceGroupName
		Assert-AreEqual $wname $deletedApp.Name

		$deletedSlot = Get-AzDeletedWebApp -ResourceGroupName $rgname -Name $wname -Slot $slotName -Location $location
		Assert-NotNull $deletedSlot
		Assert-AreEqual $rgname $deletedSlot.ResourceGroupName
		Assert-AreEqual $wname $deletedSlot.Name
		Assert-AreEqual $slotName $deletedSlot.Slot
	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

function Test-RestoreDeletedWebAppToExisting
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$slotName = "staging"
	$appWithSlotName = "$wname/$slotName"
	$delName = Get-WebsiteName
	$delSlot = "testslot"
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Premium"
	$isRecordMode = ((Get-WebsitesTestMode) -ne 'Playback')

	try
	{
		New-AzResourceGroup -Name $rgname -Location $location
		New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName

		# Make a webapp and delete it once a snapshot is available
		$tmpApp = New-AzWebApp -ResourceGroupName $rgname -Name $delName -Location $location -AppServicePlan $whpName 
		New-AzWebAppSlot -ResourceGroupName $rgname -Name $delName -Slot $delSlot

		while ($snap -eq $null)
		{
			$snap = Get-AzWebAppSnapshot $tmpApp
			if ($isRecordMode)
			{
				Start-Sleep -Seconds 60
			}
		}

		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $delName -Slot $delSlot -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $delName -Force

		$deletedApp = Get-AzDeletedWebApp -ResourceGroupName $rgname -Name $delName -Slot "Production"

		# Test the InputObject parameter set
		$restoredApp = Restore-AzDeletedWebApp $deletedApp -TargetResourceGroupName $rgname -TargetName $wname -Force
		if ($isRecordMode) 
		{
			# Need extra time for restore operation to resolve globally
			Start-Sleep -Seconds 900
		}

		# Test the FromDeletedResourceName parameter set
		$restoredSlot = Restore-AzDeletedWebApp -ResourceGroupName $rgname -Name $delName -Slot $delSlot -TargetResourceGroupName $rgname -TargetName $wname -TargetSlot $slotName -Force
		if ($isRecordMode) 
		{
			Start-Sleep -Seconds 900
		}

		Assert-NotNull $restoredApp
		Assert-AreEqual $rgname $restoredApp.ResourceGroup
		Assert-AreEqual $wname $restoredApp.Name

		Assert-NotNull $restoredSlot
		Assert-AreEqual $rgname $restoredSlot.ResourceGroup
		Assert-AreEqual $appWithSlotName $restoredSlot.Name
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

function Test-RestoreDeletedWebAppToNew
{
	# Setup
	$rgname = Get-ResourceGroupName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Premium"
	$delName = Get-WebsiteName
	$isRecordMode = ((Get-WebsitesTestMode) -ne 'Playback')

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier

		# Make a webapp and delete it once a snapshot is available
		$tmpApp = New-AzWebApp -ResourceGroupName $rgname -Name $delName -Location $location -AppServicePlan $whpName 
		while ($snap -eq $null)
		{
			$snap = Get-AzWebAppSnapshot $tmpApp
			if ($isRecordMode)
			{
				Start-Sleep -Seconds 60
			}
		}

		Remove-AzWebApp -ResourceGroupName $rgname -Name $delName -Force
		$deletedApp = Get-AzDeletedWebApp -ResourceGroupName $rgname -Name $delName -Slot "Production"

		# Test piping the deleted app
		$job = $deletedApp | Restore-AzDeletedWebApp -TargetResourceGroupName $rgname -TargetAppServicePlanName $whpName -UseDisasterRecovery -Force -AsJob
		$result = $job | Wait-Job
		Assert-AreEqual "Completed" $result.State;

		$restoredApp = $job | Receive-Job
		Assert-NotNull $restoredApp
		Assert-AreEqual $rgname $restoredApp.ResourceGroup
		Assert-AreEqual $delName $restoredApp.Name

		if ($isRecordMode) 
		{
			# Need extra time for restore operation to resolve globally, or cleanup will be blocked
			Start-Sleep -Seconds 900
		}
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $delName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

# Utility functions

# Creates a new web app
function Create-TestWebApp
{
    param (
        [string] $resourceGroup,
        [string] $location,
        [string] $hostingPlan,
        [string] $tier,
        [string] $appName
    )
    New-AzResourceGroup -Name $resourceGroup -Location $location | Out-Null
    New-AzAppServicePlan -ResourceGroupName $resourceGroup -Name  $hostingPlan -Location  $location -Tier $tier | Out-Null
    $app = New-AzWebApp -ResourceGroupName $resourceGroup -Name $appName -Location $location -AppServicePlan $hostingPlan 
    return $app
}

# Creates a new Azure Storage account and returns SAS URI
function Create-TestStorageAccount
{
    param (
        [string] $resourceGroup,
        [string] $location,
        [string] $storageName,
        [string] $storageType,
        [string] $stoContainerName
    )
    New-AzStorageAccount -ResourceGroupName $resourceGroup -Name $storageName -Location $location -Type $storageType | Out-Null
    $stoKey = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroup -Name $storageName).Key1;
    # 2 hour access duration
    $accessDuration = New-Object -TypeName TimeSpan(2,0,0)
    $permissions = [Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Write -bor
		[Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Read -bor
		[Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::List -bor
		[Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Delete
    $sasUri = Get-SasUri $storageName $stoKey $stoContainerName $accessDuration $permissions
    return $sasUri
}