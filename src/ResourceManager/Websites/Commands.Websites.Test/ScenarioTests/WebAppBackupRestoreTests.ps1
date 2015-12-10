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
	$wname = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stotype = 'Standard_LRS'

	try
	{
		# Setup
		# Make web app
		New-AzureRmResourceGroup -Name $rgName -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Location  $location -Tier $tier
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Location $location -AppServicePlan $whpName 

		# Make SQL Azure DB
		$securePword = ConvertTo-SecureString -String $dbPword
		$credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $dbUser,$securePword
		New-AzureRmSqlServer -ResourceGroupName $rgName -Location $location `
			-ServerName $dbServerName -ServerVersion $dbServerVersion -SqlAdministratorCredentials $credential
		New-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName
		$dbConnStr = "Server=tcp:$dbServerName.database.windows.net;Database=$dbName;User ID=$dbuser@$dbServerName;Password=$dbPword;Trusted_Connection=False;Encrypt=True;"

		# Make a storage account and get its SAS URI
        New-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName -Location $loc -Type $stotype
        $stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		$sasUri = Get-SasUri

		# Create a backup of the web app
		$dbBackupSetting = New-Object -TypeName Microsoft.Azure.Management.WebSites.Models.DatabaseBackupSetting
		$dbBackupSetting.DatabaseType = "SqlAzure"
		$dbBackupSetting.Name = $dbName
		$dbBackupSetting.ConnectionString = $dbConnStr
		$result = New-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

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
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppBackup
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$dbServerVersion = "2.0"
	$dbUser = "dbadmin"
	$dbPword = "h3ydiddleDIDDLEtheC@Tandthe4iddle"
	$stoName = 'sto' + $rgName
	$stotype = 'Standard_LRS'

	try
	{
		# Setup
		# Make web app
		New-AzureRmResourceGroup -Name $rgName -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Location  $location -Tier $tier
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Location $location -AppServicePlan $whpName 

		# Make SQL Azure DB
		$securePword = ConvertTo-SecureString -String $dbPword
		$credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $dbUser,$securePword
		New-AzureRmSqlServer -ResourceGroupName $rgName -Location $location `
			-ServerName $dbServerName -ServerVersion $dbServerVersion -SqlAdministratorCredentials $credential
		New-AzureRmSqlDatabase -ResourceGroupName $rgName -ServerName $dbServerName -DatabaseName $dbName
		$dbConnStr = "Server=tcp:$dbServerName.database.windows.net;Database=$dbName;User ID=$dbuser@$dbServerName;Password=$dbPword;Trusted_Connection=False;Encrypt=True;"

		# Make a storage account and get its SAS URI
        New-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName -Location $loc -Type $stotype
        $stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		$sasUri = Get-SasUri

		# Create a backup of the web app
		$dbBackupSetting = New-Object -TypeName Microsoft.Azure.Management.WebSites.Models.DatabaseBackupSetting
		$dbBackupSetting.DatabaseType = "SqlAzure"
		$dbBackupSetting.Name = $dbName
		$dbBackupSetting.ConnectionString = $dbConnStr
		$newBackup = New-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get the backup
		$result = Get-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -BackupId $newBackup.Id

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
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}

function Test-GetWebAppBackupList
{
	# Names and strings setup
	$rgName = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-Location
	$whpName = Get-WebHostPlanName
	$backupName = Get-BackupName
	$dbServerName = Get-DatabaseServerName
	$dbName = Get-DatabaseName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$stoName = 'sto' + $rgName
	$stotype = 'Standard_LRS'

	try
	{
		# Setup
		# Make web app
		New-AzureRmResourceGroup -Name $rgName -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Location  $location -Tier $tier
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Location $location -AppServicePlan $whpName 

		# Make a storage account and get its SAS URI
        New-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName -Location $loc -Type $stotype
        $stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgName -Name $stoName
		$sasUri = Get-SasUri

		# Create a backup of the web app
		$dbBackupSetting = New-Object -TypeName Microsoft.Azure.Management.WebSites.Models.DatabaseBackupSetting
		$dbBackupSetting.DatabaseType = "SqlAzure"
		$dbBackupSetting.Name = $dbName
		$dbBackupSetting.ConnectionString = $dbConnStr
		$backup1 = New-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make another one
		Do
		{
			Start-Sleep -Seconds 5
			$backupState = ($backup1 | Get-AzureWebAppBackup).Status
		} Until ($backupState -ne [Microsoft.Azure.Management.WebSites.Models]::InProgress)
		$backup2 = New-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Wait for that backup to complete, then make a third one
		Do
		{
			Start-Sleep -Seconds 5
			$backupState = ($backup2 | Get-AzureWebAppBackup).Status
		} Until ($backupState -ne [Microsoft.Azure.Management.WebSites.Models]::InProgress)
		$backup3 = New-AzureWebAppBackup -ResourceGroupName $rgName -WebAppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Get a list of the backups
		$backupList = (Get-AzureWebAppBackupList -ResourceGroupName $rgName -WebAppName $wname).Value

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
		Remove-AzureRmWebApp -ResourceGroupName $rgName -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgName -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgName -Force
    }
}