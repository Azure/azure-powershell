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

function Test-CreateNewWebAppBackup
{
	# Names and strings setup
	Start-Transcript E:\tmp\powershell_tests.txt
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
		$result = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName 

		# Assert
		Assert-AreEqual $backupName $result.BackupItemName
		Assert-NotNull $result.StorageAccountUrl
	}
    finally
	{
		# Cleanup
		#Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
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
	$tier = "Standard"
	$stoName = 'sto' + $rgName
	$stoContainerName = 'container' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
		# Create a backup of the web app
		$result = $app | New-AzureRmWebAppBackup -StorageAccountUrl $sasUri -BackupName $backupName

		# Assert
		Assert-AreEqual $backupName $result.BackupItemName
		Assert-NotNull $result.StorageAccountUrl

	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
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
		$newBackup = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName

		# Get the backup
		$result = Get-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -BackupId $newBackup.BackupItemId

		# Assert
		Assert-AreEqual $backupName $result.BackupItemName
		Assert-NotNull $result.StorageAccountUrl
		Assert-NotNull $result.BackupItemId

		# Test piping
		$pipeResult = $app | Get-AzureRmWebAppBackup -BackupId $newBackup.BackupItemId

		Assert-AreEqual $backupName $pipeResult.BackupItemName
		Assert-NotNull $pipeResult.StorageAccountUrl
		Assert-NotNull $pipeResult.BackupItemId
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
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
		$backup = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get a list of the backups
		$backupList = Get-AzureRmWebAppBackupList -ResourceGroupName $rgName -Name $wName
		$listBackup = $backupList | where {$_.BackupItemId -eq $backup.BackupItemId}

		# Assert
		Assert-AreEqual 1 $backupList.Count
		Assert-NotNull $listBackup
		Assert-AreEqual $backup.BackupItemName $listBackup.BackupItemName

		# Test piping
		$pipeBackupList = $app | Get-AzureRmWebAppBackupList
		$pipeBackup = $pipeBackupList | where {$_.BackupItemId -eq $backup.BackupItemId}

		# Assert
		Assert-AreEqual 1 $pipeBackupList.Count
		Assert-NotNull $pipeBackup
		Assert-AreEqual $backup.BackupItemName $pipeBackup.BackupItemName
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-EditAndGetWebAppBackupConfiguration
{
	# Names and strings setup
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
		# Setup
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
		$startTime = (Get-Date).ToUniversalTime().AddDays(1)
		$frequencyInterval = 7
		$frequencyUnit = ([Microsoft.Azure.Management.WebSites.Models.FrequencyUnit]::Day)
		$retentionPeriod = 3

		# Set the backup configuration
		Edit-AzureRmWebAppBackupConfiguration `
			-ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri `
			-FrequencyInterval $frequencyInterval -FrequencyUnit $frequencyUnit `
			-RetentionPeriodInDays $retentionPeriod -StartTime $startTime `
			-KeepAtLeastOneBackup 
		$config = Get-AzureRmWebAppBackupConfiguration -ResourceGroupName $rgName -Name $wName

		# Assert
		Assert-True { $config.Enabled }
		Assert-NotNull $config.StorageAccountUrl
		#Assert-AreEqual $dbBackupSetting $config.Databases
		$configSchedule = $config.BackupSchedule
		Assert-NotNull $configSchedule
		Assert-AreEqual $frequencyInterval $configSchedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $configSchedule.FrequencyUnit 
		Assert-True { $configSchedule.KeepAtLeastOneBackup }
		Assert-AreEqual $retentionPeriod $configSchedule.RetentionPeriodInDays
		# Cannot assert equality because time will be different in playback mode
		Assert-NotNull $configSchedule.StartTime
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-EditAndGetWebAppBackupConfigurationPiping
{
	# Names and strings setup
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
		# Setup
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType $stoContainerName
		$startTime = (Get-Date).ToUniversalTime().AddDays(1)
		$frequencyInterval = 7
		$frequencyUnit = ([Microsoft.Azure.Management.WebSites.Models.FrequencyUnit]::Day)
		$retentionPeriod = 3


		# Test piping
		$app | Edit-AzureRmWebAppBackupConfiguration `
			-StorageAccountUrl $sasUri -FrequencyInterval $frequencyInterval `
			-FrequencyUnit $frequencyUnit -RetentionPeriodInDays $retentionPeriod `
			-StartTime $startTime -KeepAtLeastOneBackup
		$config = $app | Get-AzureRmWebAppBackupConfiguration

		# Assert
		Assert-True { $config.Enabled }
		Assert-NotNull $sasUri
		$schedule = $config.BackupSchedule
		Assert-NotNull $schedule
		Assert-AreEqual $frequencyInterval $schedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $schedule.FrequencyUnit 
		Assert-True { $schedule.KeepAtLeastOneBackup }
		Assert-AreEqual $retentionPeriod $schedule.RetentionPeriodInDays
		# Cannot assert equality because time will be different in playback mode
		Assert-NotNull $schedule.StartTime
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
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
	New-AzureRmResourceGroup -Name $resourceGroup -Location $location | Out-Null
	New-AzureRmAppServicePlan -ResourceGroupName $resourceGroup -Name  $hostingPlan -Location  $location -Tier $tier | Out-Null
	$app = New-AzureRmWebApp -ResourceGroupName $resourceGroup -Name $appName -Location $location -AppServicePlan $hostingPlan 
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
	New-AzureRmStorageAccount -ResourceGroupName $resourceGroup -Name $storageName -Location $location -Type $storageType | Out-Null
	$stoKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroup -Name $storageName).Key1;
	# 2 hour access duration
	$accessDuration = New-Object -TypeName TimeSpan(2,0,0)
	$permissions = [Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Write
	$sasUri = Get-SasUri $storageName $stoKey $stoContainerName $accessDuration $permissions
	return $sasUri
}