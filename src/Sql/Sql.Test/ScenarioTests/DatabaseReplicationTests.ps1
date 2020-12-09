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
	Tests creating a database copy
#>
function Test-CreateDatabaseCopy()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server "Standard"

	$copyRg = Create-ResourceGroupForTest $location
	$copyServer = Create-ServerForTest $copyRg $location
	$copyDatabaseName = Get-DatabaseName

	try
	{
		# Create a local database copy
		$job = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyDatabaseName $copyDatabaseName -AsJob
		$job | Wait-Job
		$dbLocalCopy = $job.Output

		Assert-AreEqual $dbLocalCopy.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $database.DatabaseName
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName

		# Create a cross server copy
		$dbCrossServerCopy = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyResourceGroupName $copyRg.ResourceGroupName -CopyServerName $copyServer.ServerName -CopyDatabaseName $copyDatabaseName
		Assert-AreEqual $dbCrossServerCopy.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbCrossServerCopy.ServerName $server.ServerName
		Assert-AreEqual $dbCrossServerCopy.DatabaseName $database.DatabaseName
		Assert-AreEqual $dbCrossServerCopy.CopyResourceGroupName $copyRg.ResourceGroupName
		Assert-AreEqual $dbCrossServerCopy.CopyServerName $copyServer.ServerName
		Assert-AreEqual $dbCrossServerCopy.CopyDatabaseName $copyDatabaseName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $copyRg
	}
}

<#
	.SYNOPSIS
	Tests creating a vcore database copy
#>
function Test-CreateVcoreDatabaseCopy()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$db = Create-VcoreDatabaseForTest $rg $server 2 BasePrice

	try
	{
		# Create a local database copy from a vcore database with base price license type
		$copyDatabaseName = Get-DatabaseName
		$dbLocalCopy = New-AzSqlDatabaseCopy -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -CopyDatabaseName $copyDatabaseName

		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $db.DatabaseName
		Assert-AreEqual $dbLocalCopy.LicenseType BasePrice # Copy should have same license as src unless specified
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName


		# Create a local database copy from a vcore database with license type option - Base Price
		$copyDatabaseName = Get-DatabaseName
		$dbLocalCopy = New-AzSqlDatabaseCopy -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -CopyDatabaseName $copyDatabaseName -LicenseType BasePrice

		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $db.DatabaseName
		Assert-AreEqual $dbLocalCopy.LicenseType BasePrice # Copy should be set Base Price since specified
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName

		# Create a local database copy from a vcore database with license type option - License Included
		$copyDatabaseName = Get-DatabaseName
		$dbLocalCopy = New-AzSqlDatabaseCopy -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -CopyDatabaseName $copyDatabaseName -LicenseType LicenseIncluded

		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $db.DatabaseName
		Assert-AreEqual $dbLocalCopy.LicenseType LicenseIncluded # Copy should be License Included since specified
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a secondary database
#>
function Test-CreateSecondaryDatabase()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Create Readable Secondary
		$readSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All
		Assert-NotNull $readSecondary.LinkId
		Assert-AreEqual $readSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $readSecondary.ServerName $server.ServerName
		Assert-AreEqual $readSecondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $readSecondary.Role "Primary"
		Assert-AreEqual $readSecondary.Location $location
		Assert-AreEqual $readSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $readSecondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $readSecondary.PartnerRole
		Assert-AreEqual $readSecondary.PartnerLocation $location
		Assert-NotNull $readSecondary.AllowConnections
		Assert-NotNull $readSecondary.ReplicationState
		Assert-NotNull $readSecondary.PercentComplete
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Tests creating a named secondary database
#>
function Test-CreateNamedSecondaryDatabase()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server
	$hsDatabase = Create-HyperscaleDatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Create Geo Secondary
		$geoSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -PartnerDatabaseName "secondary" -AllowConnections All -SecondaryType "Geo"
		Assert-NotNull $geoSecondary.LinkId
		Assert-AreEqual $geoSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $geoSecondary.ServerName $server.ServerName
		Assert-AreEqual $geoSecondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $geoSecondary.Role "Primary"
		Assert-AreEqual $geoSecondary.Location $location
		Assert-AreEqual $geoSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $geoSecondary.PartnerServerName $partServer.ServerName
		Assert-AreEqual $geoSecondary.PartnerDatabaseName "secondary"
		Assert-NotNull $geoSecondary.PartnerRole
		Assert-AreEqual $geoSecondary.PartnerLocation $location
		Assert-NotNull $geoSecondary.AllowConnections
		Assert-NotNull $geoSecondary.ReplicationState
		Assert-NotNull $geoSecondary.PercentComplete

		$newDb = Get-AzSqlDatabase -ResourceGroupName $partRg.ResourceGroupName -ServerName $partServer.ServerName -DatabaseName "secondary"
		Assert-AreEqual "Geo" $newDb.SecondaryType

		# Create Named Replica
		$namedReplica = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $hsDatabase.DatabaseName `
		 -PartnerResourceGroupName $rg.ResourceGroupName -PartnerServerName $server.ServerName -PartnerDatabaseName "secondary" -SecondaryType "Named"

		$newDb = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName "secondary"
		Assert-AreEqual "Named" $newDb.SecondaryType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Tests creating a named secondary database of already existing database
#>
function Test-CreateNamedSecondaryDatabaseNegative()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Attempt to Create Named Readable Secondary Using Existing Database Name
		$readSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $partRg.ResourceGroupName -ServerName $partServer.ServerName -DatabaseName "secondary" `
		 -PartnerResourceGroupName $rg.ResourceGroupName -PartnerServerName $server.ServerName -PartnerDatabaseName $database.DatabaseName -AllowConnections All
		Assert-Null $readSecondary
	}
	catch
	{
		$ErrorMessage = $_.Exception.Message
		Assert-AreEqual True $ErrorMessage.Contains("Database with name: '" + $database.DatabaseName + "' already exists in server '" + $server.ServerName + "'.")
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Tests getting a secondary database
#>
function Test-GetReplicationLink()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Get Secondary
		$job = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
			-PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All -AsJob
		$job | Wait-Job

		$secondary = Get-AzSqlDatabaseReplicationLink -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		 -DatabaseName $database.DatabaseName -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName
		Assert-NotNull $secondary.LinkId
		Assert-AreEqual $secondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $secondary.ServerName $server.ServerName
		Assert-AreEqual $secondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $secondary.Role Primary
		Assert-AreEqual $secondary.Location $location
		Assert-AreEqual $secondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $secondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $secondary.PartnerRole
		Assert-AreEqual $secondary.PartnerLocation $location
		Assert-NotNull $secondary.AllowConnections
		Assert-NotNull $secondary.ReplicationState
		Assert-NotNull $secondary.PercentComplete
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Tests removing a secondary database
#>
function Test-RemoveSecondaryDatabase()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# remove Secondary
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All

		Remove-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Tests failing over a secondary database
#>
function Test-FailoverSecondaryDatabase()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "West Europe"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# failover Secondary
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All

		$secondary = Get-AzSqlDatabaseReplicationLink -ResourceGroupName $partRg.ResourceGroupName -ServerName $partServer.ServerName -DatabaseName $database.DatabaseName -PartnerResourceGroupName $rg.ResourceGroupName -PartnerServerName $server.ServerName

		$job = $secondary | Set-AzSqlDatabaseSecondary -PartnerResourceGroupName $rg.ResourceGroupName -Failover -AsJob
		$job | Wait-Job
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}

<#
	.SYNOPSIS
	Creates test database
#>
function Create-DatabaseForTest  ($rg, $server, $edition = "Premium")
{
	$databaseName = Get-DatabaseName
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition $edition
}

<#
	.SYNOPSIS
	Creates test database
#>
function Create-VcoreDatabaseForTest  ($rg, $server, $numCores = 2, $licenseType = "LicenseIncluded")
{
	$databaseName = Get-DatabaseName
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore $numCores -ComputeGeneration Gen5 -Edition GeneralPurpose -LicenseType $licenseType
}

<#
	.SYNOPSIS
	Creates test database
#>
function Create-HyperscaleDatabaseForTest  ($rg, $server, $numCores = 2, $licenseType = "LicenseIncluded")
{
	$databaseName = Get-DatabaseName
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore $numCores -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType $licenseType
}

<#
	.SYNOPSIS
	Creates test database with BackupStorageRedundancy
#>
function Test-CreateDatabaseCopyWithBackupStorageRedundancy()
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server "Standard"

	$copyRg = Create-ResourceGroupForTest $location
	$copyServer = Create-ServerForTest $copyRg $location
	$copyDatabaseName = Get-DatabaseName

	try
	{
		# Create a local database copy
		$dbLocalCopy = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyDatabaseName $copyDatabaseName -BackupStorageRedundancy zone

		$newDb = Get-AzSqlDatabase -ResourceGroupName $dbLocalCopy.ResourceGroupName -ServerName $dbLocalCopy.ServerName -DatabaseName $copyDatabaseName
		Assert-AreEqual "Zone" $newDb.BackupStorageRedundancy 

		# Create a cross server copy
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $copyRg
	}
}

<#
	.SYNOPSIS
	Tests creating a secondary database
#>
function Test-CreateSecondaryDatabaseWithBackupStorageRedundancy()
{
	# Setup
    $location = "westcentralus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Create Readable Secondary
		$readSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All -BackupStorageRedundancy local

		$secondaryDb = Get-AzSqlDatabase -ResourceGroupName $readSecondary.PartnerResourceGroupName -ServerName $readSecondary.PartnerServerName -DatabaseName $readSecondary.DatabaseName
		Assert-AreEqual $secondaryDb.BackupStorageRedundancy "Local"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $partRg
	}
}