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
	$rgName = Get-ResourceGroupName
	$wName = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$pipeBackupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		# Create a backup of the web app
		$result = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqual $sasUri $result.StorageAccountUrl
		Assert-AreEqualArray $dbBackupSetting $result.Databases

		# Test piping
		$pipeResult = $app | New-AzureRmWebAppBackup -StorageAccountUrl $sasUri -BackupName $pipeBackupName

		# Assert
		Assert-AreEqual $pipeBackupName $pipeResult.BackupName
		Assert-AreEqual $sasUri $pipeResult.StorageAccountUrl
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
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
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		# Create a backup of the web app
		$newBackup = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get the backup
		$result = Get-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -BackupId $newBackup.Id

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqualArray $dbBackupSetting $result.Databases

		# Test piping
		$pipeResult = $app | Get-AzureRmWebAppBackup -BackupId $newBackup.Id

		Assert-AreEqual $backupName $pipeResult.BackupName
		Assert-AreEqualArray $dbBackupSetting $pipeResult.Databases
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
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
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr
		
		# Create a backup of the web app
		$backup1 = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make another one
		Do
		{
			Start-Sleep -Seconds 5
			$backupStatus = ($app | Get-AzureRmWebAppBackup -BackupId $backup1.Id).Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$backup2 = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make a third one
		Do
		{
			Start-Sleep -Seconds 5
			$backupStatus = ($app | Get-AzureRmWebAppBackup -BackupId $backup2.Id).Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$backup3 = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get a list of the backups
		$backupList = (Get-AzureWebAppBackupList -ResourceGroupName $rgName -Name $wName).Value

		# Assert
		Assert-AreEqual 3 $backupList.Count
		$listBackup1 = $backupList | where {$_.Id -eq $backup1.Id}
		$listBackup2 = $backupList | where {$_.Id -eq $backup2.Id}
		$listBackup3 = $backupList | where {$_.Id -eq $backup3.Id}
		Assert-NotNull $listBackup1
		Assert-AreEqual $backup1.Id $listBackup1.Id
		Assert-NotNull $listBackup2
		Assert-AreEqual $backup2.Id $listBackup2.Id
		Assert-NotNull $listBackup3
		Assert-AreEqual $backup3.Id $listBackup3.Id
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-RemoveAzureWebAppBackup
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wName = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$pipeBackupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		$backup1 = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting
		# Wait for that backup to complete, then delete it
		Do
		{
			Start-Sleep -Seconds 5
			$backupStatus = ($app | Get-AzureRmWebAppBackup -BackupId $backup1.Id).Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$result = Remove-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -BackupId $backup1.Id

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqualArray $dbBackupSetting $result.Databases
		$status = ($app | Get-AzureRmWebAppBackup -BackupId $backup1.Id).Status
		Assert-True (([Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::DeleteInProgress) -eq $status) -or
					(([Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Deleted) -eq $status) 

		# Test piping
		$backup2 = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $pipeBackupName -Databases $dbBackupSetting
		# Wait before deleting
		Do
		{
			Start-Sleep -Seconds 5
			$backupStatus = ($app | Get-AzureRmWebAppBackup -BackupId $backup2.Id).Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$result = Remove-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -BackupId $backup2.Id
		$pipeResult = $backup2 | Remove-AzureRmWebAppBackup $backup2.Id

		# Assert
		Assert-AreEqual $backupName $pipeResult.BackupName
		Assert-AreEqualArray $dbBackupSetting $pipeResult.Databases
		$status = ($app | Get-AzureRmWebAppBackup -BackupId $backup2.Id).Status
		Assert-True (([Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::DeleteInProgress) -eq $status) -or
					(([Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Deleted) -eq $status) 
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-EditWebAppBackupConfiguration
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wName = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$stoName = 'sto' + $rgName
	$stoContainerName = 'container' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		# Setup
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr
		$startTime = (Get-Date).AddDays(1)
		$frequencyInterval = 7
		$frequencyUnit = ([Microsoft.Azure.Management.WebSites.Models.FrequencyUnit]::Day)
		$retentionPeriod = 3

		# Set the backup configuration
		$config = Edit-AzureRmWebAppBackupConfiguration `
			-ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri `
			-FrequencyInterval $frequencyInterval -FrequencyUnit $frequencyUnit `
			-RetentionPeriodInDays $retentionPeriod -StartTime $startTime `
			-KeepAtLeastOneBackup -Databases $dbBackupSetting

		# Assert
		Assert-True $config.Enabled
		Assert-AreEqual $sasUri $config.StorageAccountUrl
		Assert-AreEqual $dbBackupSetting $config.Databases
		$configSchedule = $config.BackupSchedule
		Assert-NotNull $configSchedule
		Assert-AreEqual $frequencyInterval $configSchedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $configSchedule.FrequencyUnit 
		Assert-True $configSchedule.KeepAtLeastOneBackup
		Assert-AreEqual $retentionPeriod $configSchedule.RetentionPeriodInDays

		# Test piping
		$pipeConfig = $app | Edit-AzureRmWebAppBackupConfiguration `
			-StorageAccountUrl $sasUri -FrequencyInterval $frequencyInterval `
			-FrequencyUnit $frequencyUnit -RetentionPeriodInDays $retentionPeriod `
			-StartTime $startTime -KeepAtLeastOneBackup -Databases $dbBackupSetting

		# Assert
		Assert-True $pipeConfig.Enabled
		Assert-AreEqual $sasUri $pipeConfig.StorageAccountUrl
		Assert-AreEqual $dbBackupSetting $pipeConfig.Databases
		$pipeSchedule = $pipeConfig.BackupSchedule
		Assert-NotNull $pipeSchedule
		Assert-AreEqual $frequencyInterval $pipeSchedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $pipeSchedule.FrequencyUnit 
		Assert-True $pipeSchedule.KeepAtLeastOneBackup
		Assert-AreEqual $retentionPeriod $pipeSchedule.RetentionPeriodInDays
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppBackupConfiguration
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wName = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$stoName = 'sto' + $rgName
	$stoContainerName = 'container' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		# Setup
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr
		$startTime = (Get-Date).AddDays(1)
		$frequencyInterval = 7
		$frequencyUnit = ([Microsoft.Azure.Management.WebSites.Models.FrequencyUnit]::Day)
		$retentionPeriod = 3

		# Set the backup configuration
		Edit-AzureRmWebAppBackupConfiguration `
			-ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri `
			-FrequencyInterval $frequencyInterval -FrequencyUnit $frequencyUnit `
			-RetentionPeriodInDays $retentionPeriod -StartTime $startTime `
			-KeepAtLeastOneBackup -Databases $dbBackupSetting

		$config = Get-AzureRmWebAppBackupConfiguration -ResourceGroupName $rgName -Name $wName

		# Assert
		Assert-True $config.Enabled
		Assert-AreEqual $sasUri $config.StorageAccountUrl
		Assert-AreEqual $dbBackupSetting $config.Databases
		$configSchedule = $config.BackupSchedule
		Assert-NotNull $configSchedule
		Assert-AreEqual $frequencyInterval $configSchedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $configSchedule.FrequencyUnit 
		Assert-True $configSchedule.KeepAtLeastOneBackup
		Assert-AreEqual $retentionPeriod $configSchedule.RetentionPeriodInDays

		# Test piping
		$pipeConfig = $app | Get-AzureRmWebAppBackupConfiguration
		# Assert
		Assert-True $pipeConfig.Enabled
		Assert-AreEqual $sasUri $pipeConfig.StorageAccountUrl
		Assert-AreEqual $dbBackupSetting $pipeConfig.Databases
		$pipeSchedule = $pipeConfig.BackupSchedule
		Assert-NotNull $pipeSchedule
		Assert-AreEqual $frequencyInterval $pipeSchedule.FrequencyInterval
		Assert-AreEqual $frequencyUnit $pipeSchedule.FrequencyUnit 
		Assert-True $pipeSchedule.KeepAtLeastOneBackup
		Assert-AreEqual $retentionPeriod $pipeSchedule.RetentionPeriodInDays
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-RestoreAzureWebAppBackup
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wName = Get-WebsiteName
	$restoredSiteName = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$pipeBackupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		$app = Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		$backup = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting
		# Wait for that backup to complete, then restore it to a new site
		Do
		{
			Start-Sleep -Seconds 5
			$backup = $app | Get-AzureRmWebAppBackup -BackupId $backup.Id
			$backupStatus = $backup.Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		Restore-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $restoredSiteName -StorageAccountUrl $sasUri -BlobName $backup.BlobName -Databases $dbBackupSetting
		# Wait a few seconds for the restore to start, then check that the new site exists
		Start-Sleep -Seconds 10
		Try
		{
			Get-AzureRmWebApp -ResourceGroupName $rgName -Name $restoredSiteName
		}
		Catch [Microsoft.Rest.Azure.CloudException]
		{
			Assert-True $false "Restore to new site did not create new site"
		}

		# Test piping
		$pBackup = New-AzureRmWebAppBackup -ResourceGroupName $rgName -Name $wName -StorageAccountUrl $sasUri -BackupName $pipeBackupName -Databases $dbBackupSetting
		$pipeResult = $pBackup | Remove-AzureRmWebAppBackup $pBackup.Id
		Do
		{
			Start-Sleep -Seconds 5
			$pBackup = $app | Get-AzureRmWebAppBackup -BackupId $pBackup.Id
			$backupStatus = $pBackup.Status
		} Until ($backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupStatus -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$app | Restore-AzureRmWebAppBackup -StorageAccountUrl $sasUri -BlobName $pBackup.BlobName -Databases $dbBackupSetting -Overwrite
	}
    finally
	{
		# Cleanup
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		Remove-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName -Force
		Remove-AzureRmSqlServer -ResourceGroupName $rgName -ServerName $dbServerName -Force
		# Restore will create new server farms for restored websites, so we must clean those server farms up as well
		# This code gets the web app's server farm name by selecting the last path segment of the server farm ID
		$appSfName = (Get-AzureRmWebApp -ResourceGroupName $rgName -Name $wName).ServerFarmId.Split('/') | Select-Object -Last 1
		$restoredAppSfName = (Get-AzureRmWebApp -ResourceGroupName $rgName -Name $restoredSiteName).ServerFarmId.Split('/') | Select-Object -Last 1
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wName -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $restoredSiteName
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name $whpName -Force
		# Must be careful because restore to new server farm is still a work in progress
		# and old versions of restore will just restore to the original server farm
		If ($appSfName -ne $whpName)
		{
			Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name $appSfName -Force
		}
		If ($restoredAppSfName -ne $whpName -and $restoredAppSfName -ne $appSfName)
		{
			Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name $restoredAppSfName -Force
		}
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
	New-AzureRmResourceGroup -Name $resourceGroup -Location $location
	New-AzureRmAppServicePlan -ResourceGroupName $resourceGroup -Name  $hostingPlan -Location  $location -Tier $tier
	$app = New-AzureRmWebApp -ResourceGroupName $resourceGroup -Name $appName -Location $location -AppServicePlan $hostingPlan 
	return $app
}

# Creates a new SQL server, SQL database and returns its connection string
function Create-TestSqlDb
{
	param (
		[string] $resourceGroup,
		[string] $location,
		[string] $serverName,
		[string] $serverVersion,
		[string] $dbName,
		[string] $user,
		[string] $password
	)
	$securePword = ConvertTo-SecureString -String $password
	$credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user,$securePword
	New-AzureRmSqlServer -ResourceGroupName $resourceGroup -Location $location `
		-ServerName $serverName -ServerVersion $serverVersion -SqlAdministratorCredentials $credential
	New-AzureRmSqlDatabase -ResourceGroupName $resourceGroup -ServerName $serverName -DatabaseName $dbName
	$dbConnStr = "Server=tcp:$serverName.database.windows.net;Database=$dbName;User ID=$dbuser@$serverName;Password=$password;Trusted_Connection=False;Encrypt=True;"
	return $dbConnStr
}

# Creates a new Azure Storage account and returns SAS URI
function Create-TestStorageAccount
{
	param (
		[string] $resourceGroup,
		[string] $location,
		[string] $storageName,
		[string] $storageType
	)
	New-AzureRmStorageAccount -ResourceGroupName $resourceGroup -Name $storageName -Location $loc -Type $storageType
	$stoKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroup -Name $storageName).Key1;
	$stoCtx = New-AzureStorageContext $storageName $stoKey
	New-AzureStorageContainer -Name $stoContainerName -Context $stoCtx
	# 2 hour access duration
	$accessDuration = New-Object -TypeName TimeSpan(2,0,0)
	$permissions = [Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Write
	$sasUri = Get-SasUri $storageName $stoKey $stoContainerName $accessDuration $permissions
	return $sasUri
}

function Get-DbBackupSetting
{
	param (
		[string] $dbName,
		[string] $dbConnStr
	)
	$dbBackupSetting = New-Object -TypeName Microsoft.Azure.Management.WebSites.Models.DatabaseBackupSetting
	$dbBackupSetting.DatabaseType = "SqlAzure"
	$dbBackupSetting.Name = $dbName
	$dbBackupSetting.ConnectionString = $dbConnStr
	return $dbBackupSetting
}