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

function Test-NewWebAppBackup
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
		$actual = New-AzureWebAppBackup -ResourceGroupName $rgName -AppName $wname -StorageAccountUrl $sasUri -BackupName $backupName -Databases $dbBackupSetting

		# Assert
		Assert-AreEqual $backupName $actual.BackupName
		Assert-AreEqual $sasUri $actual.StorageAccountUrl
		Assert-AreEqual $dbBackupSetting $actual.Databases

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