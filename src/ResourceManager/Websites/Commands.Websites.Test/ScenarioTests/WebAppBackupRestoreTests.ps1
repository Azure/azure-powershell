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
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$apiVersion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		# Create a backup of the web app
		$result = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqual $sasUri $result.StorageAccountUrl
		Assert-AreEqualArray $dbBackupSetting $result.Databases

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
	$apiVersion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		# Create a backup of the web app
		$newBackup = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get the backup
		$result = Get-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -BackupId $newBackup.Id

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqualArray $dbBackupSetting $result.Databases

		# Test piping
		$pipeResult = $newBackup | Get-AzureWebAppBackup

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
	$apiVersion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		Create-TestWebApp $rgName $location $whpName $tier $wName
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr
		
		# Create a backup of the web app
		$backup1 = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make another one
		Do
		{
			Start-Sleep -Seconds 5
			$backupState = ($backup1 | Get-AzureWebAppBackup).Status
		} Until ($backupState -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupState -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$backup2 = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make a third one
		Do
		{
			Start-Sleep -Seconds 5
			$backupState = ($backup2 | Get-AzureWebAppBackup).Status
		} Until ($backupState -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::Created -and
		         $backupState -ne [Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::InProgress)
		$backup3 = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get a list of the backups
		$backupList = (Get-AzureWebAppBackupList -ResourceGroupName $rgName -AppName $wName).Value

		# Assert
		Assert-AreEqual 3 $backupList.Count
		$listContainsBackup1 = $backupList | where {$_.Id -eq $backup1.Id}
		$listContainsBackup2 = $backupList | where {$_.Id -eq $backup2.Id}
		$listContainsBackup3 = $backupList | where {$_.Id -eq $backup3.Id}
		Assert-NotNull $listContainsBackup1
		Assert-NotNull $listContainsBackup2
		Assert-NotNull $listContainsBackup3
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
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$apiVersion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr

		$backup1 = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting
		$result = Remove-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -BackupId $backup1.Id

		# Assert
		Assert-AreEqual $backupName $result.BackupName
		Assert-AreEqualArray $dbBackupSetting $result.Databases
		# TODO improve assert
		Assert-AreEqual ([Microsoft.Azure.Management.WebSites.Models.BackupItemStatus]::DeleteInProgress)

		# Test piping
		$backup2 = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting
		$pipeResult = $backup2 | Remove-AzureWebAppBackup

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
	$apiVersion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$stoName = 'sto' + $rgName
	$stoContainerName = 'container' + $rgName
	$stoType = 'Standard_LRS'

	try
	{
		# Setup
		Create-TestWebApp $rgName $location $whpName $tier $wName
		$dbConnStr = Create-TestSqlDb $rgName $location $dbServerName $dbServerVersion $dbName $dbUser $dbPword
		$sasUri = Create-TestStorageAccount $rgName $location $stoName $stoType
		$dbBackupSetting = Get-DbBackupSetting $dbName $dbConnStr
		$startTime = (Get-Date).AddDays(1)

		# Set the backup configuration
		Edit-AzureRMWebAppBackupConfiguration `
			-ResourceGroupName $rgName -AppName $wName -StorageAccountUrl $sasUri `
			-FrequencyInterval 7 -FrequencyUnit ([Microsoft.Azure.Management.WebSites.Models.FrequencyUnit]::Day) `
			-RetentionPeriodInDays 3 -StartTime $startTime -KeepAtLeastOneBackup -Databases $dbBackupSetting

		# Get the backup configuration and assert
		$result = Get-AzureWebAppBackupConfiguration -ResourceGroupName $rgName -AppName $wName

		# TODO assert
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
	New-AzureRmWebApp -ResourceGroupName $resourceGroup -Name $appName -Location $location -AppServicePlan $hostingPlan 
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