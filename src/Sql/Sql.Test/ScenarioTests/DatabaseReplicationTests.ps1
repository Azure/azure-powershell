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
		 -PartnerResourceGroupName $rg.ResourceGroupName -PartnerServerName $server.ServerName -PartnerDatabaseName "secondary" -SecondaryType "Named" `
		 -HighAvailabilityReplicaCount 2

		$newDb = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName "secondary"
		Assert-AreEqual "Named" $newDb.SecondaryType
		Assert-AreEqual 2 $newDb.HighAvailabilityReplicaCount
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
    $location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
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
		Assert-NotNull $secondary.LinkType
		Assert-AreEqual $secondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $secondary.ServerName $server.ServerName
		Assert-AreEqual $secondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $secondary.Role Primary
		Assert-AreEqual $secondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $secondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $secondary.PartnerRole
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
	Tests updating replication link type
#>
function Test-SetReplicationLink()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
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
		Assert-NotNull $secondary.LinkType
		Assert-AreEqual $secondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $secondary.ServerName $server.ServerName
		Assert-AreEqual $secondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $secondary.Role Primary
		Assert-AreEqual $secondary.LinkType GEO
		Assert-AreEqual $secondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $secondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $secondary.PartnerRole
		Assert-NotNull $secondary.AllowConnections
		Assert-NotNull $secondary.ReplicationState
		Assert-NotNull $secondary.PercentComplete

		$updatedSecondary = Set-AzSqlDatabaseReplicationLink -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		 -DatabaseName $database.DatabaseName -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -LinkId $secondary.LinkId -LinkType STANDBY
		Assert-NotNull $updatedSecondary.LinkId
		Assert-NotNull $updatedSecondary.LinkType
		Assert-AreEqual $updatedSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $updatedSecondary.ServerName $server.ServerName
		Assert-AreEqual $updatedSecondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $updatedSecondary.Role Primary
		Assert-AreEqual $updatedSecondary.LinkType STANDBY
		Assert-AreEqual $updatedSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $updatedSecondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $updatedSecondary.PartnerRole
		Assert-NotNull $updatedSecondary.AllowConnections
		Assert-NotNull $updatedSecondary.ReplicationState
		Assert-NotNull $updatedSecondary.PercentComplete
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
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
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
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition $edition -Force
}

<#
	.SYNOPSIS
	Creates test database
#>
function Create-VcoreDatabaseForTest  ($rg, $server, $numCores = 2, $licenseType = "LicenseIncluded")
{
	$databaseName = Get-DatabaseName
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore $numCores -ComputeGeneration Gen5 -Edition GeneralPurpose -LicenseType $licenseType -Force
}

<#
	.SYNOPSIS
	Creates test database
#>
function Create-HyperscaleDatabaseForTest  ($rg, $server, $numCores = 2, $licenseType = "LicenseIncluded")
{
	$databaseName = Get-DatabaseName
	New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore $numCores -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType $licenseType -Force
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
		 -CopyDatabaseName $copyDatabaseName -BackupStorageRedundancy 'Zone'

		$newDb = Get-AzSqlDatabase -ResourceGroupName $dbLocalCopy.ResourceGroupName -ServerName $dbLocalCopy.ServerName -DatabaseName $copyDatabaseName
		Assert-AreEqual "Zone" $newDb.CurrentBackupStorageRedundancy 

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
    $location = "westeurope"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Create Readable Secondary
		$readSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All -BackupStorageRedundancy 'Local'

		$secondaryDb = Get-AzSqlDatabase -ResourceGroupName $readSecondary.PartnerResourceGroupName -ServerName $readSecondary.PartnerServerName -DatabaseName $readSecondary.DatabaseName
		Assert-AreEqual $secondaryDb.CurrentBackupStorageRedundancy "Local"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg 
		Remove-ResourceGroupForTest $partRg 
	}
}

<#
	.SYNOPSIS
	Tests creating a secondary database
#>
function Test-CreateCopyDatabaseWithGeoZoneBackupStorageRedundancy()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "Brazil South"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-HyperscaleDatabaseForTest $rg $server

	$copyRg = Create-ResourceGroupForTest $location
	$copyServer = Create-ServerForTest $copyRg $location
	$copyDatabaseName = Get-DatabaseName

	try
	{
		# Create Readable Secondary
		$dbLocalCopy = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyDatabaseName $copyDatabaseName -BackupStorageRedundancy 'GeoZone'

		$newDb = Get-AzSqlDatabase -ResourceGroupName $dbLocalCopy.ResourceGroupName -ServerName $dbLocalCopy.ServerName -DatabaseName $copyDatabaseName
		Assert-AreEqual $newDb.CurrentBackupStorageRedundancy "GeoZone"
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
function Test-CreateSecondaryDatabaseWithGeoZoneBackupStorageRedundancy()
{
	# Setup
    $location = Get-Location "Microsoft.Sql" "operations" "Brazil South"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-HyperscaleDatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $location

	try
	{
		# Create Readable Secondary
		$readSecondary = New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All -BackupStorageRedundancy 'GeoZone'

		$secondaryDb = Get-AzSqlDatabase -ResourceGroupName $readSecondary.PartnerResourceGroupName -ServerName $readSecondary.PartnerServerName -DatabaseName $readSecondary.DatabaseName
		Assert-AreEqual $secondaryDb.CurrentBackupStorageRedundancy "GeoZone"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg 
		Remove-ResourceGroupForTest $partRg 
	}
}

<#
	.SYNOPSIS
	Tests creating a vldb copy with source zone redundant == false
	1. Copy source vldb passing in zone redundant == true and backup storage redundancy == Zone,
	   Verify copied vldb has zone redundant == true and backup storage redundancy == Zone
	2. Copy source vldb with no parameters passed in,
	   Verify copied vldb has zone redundant == false and backup storage redundancy == Geo
#>
function Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceNonZRDatabaseName = Get-DatabaseName + "-non-zr"

	$copyTrueZRParamDatabaseName = $sourceNonZRDatabaseName + "-source-non-zr-copy-zr-true"
	$copyNoZRParamDatabaseName = $sourceNonZRDatabaseName + "-source-non-zr-copy-no-zr-param"

	try
	{
		# Create source vldb
		$sourceNonZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded"

		# Verify created source vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $sourceNonZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceNonZRDatabase.DatabaseName $sourceNonZRDatabaseName
		Assert-AreEqual $sourceNonZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceNonZRDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $sourceNonZRDatabase.ZoneRedundant 
		Assert-False    { $sourceNonZRDatabase.ZoneRedundant }

		# Copy source vldb with zone redundancy == true and backup storage redundancy == Zone
		$copyTrueZRParamDatabaseResult = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabase.DatabaseName `
		 -CopyDatabaseName $copyTrueZRParamDatabaseName -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify returned response has zone redundancy == true
		Assert-NotNull  $copyTrueZRParamDatabaseResult.ZoneRedundant 
		Assert-True     { $copyTrueZRParamDatabaseResult.ZoneRedundant }

		# Retrieve the copied vldb
		$copyTrueZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $copyTrueZRParamDatabaseName

		# Verify copied vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $copyTrueZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $copyTrueZRParamDatabase.DatabaseName $copyTrueZRParamDatabaseName
		Assert-AreEqual $copyTrueZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $copyTrueZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $copyTrueZRParamDatabase.ZoneRedundant 
		Assert-True     { $copyTrueZRParamDatabase.ZoneRedundant }

		# Copy source vldb with no parameters passed in
		$copyNoZRParamDatabaseResult = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabase.DatabaseName `
		 -CopyDatabaseName $copyNoZRParamDatabaseName
		
		# Verify returned response has zone redundancy == false
		Assert-NotNull  $copyNoZRParamDatabaseResult.ZoneRedundant 
		Assert-False     { $copyNoZRParamDatabaseResult.ZoneRedundant }

		# Retrieve the copied vldb
		$copyNoZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $copyNoZRParamDatabaseName

		# Verify copied vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $copyNoZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $copyNoZRParamDatabase.DatabaseName $copyNoZRParamDatabaseName
		Assert-AreEqual $copyNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $copyNoZRParamDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $copyNoZRParamDatabase.ZoneRedundant 
		Assert-False    { $copyNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a vldb copy with source zone redundant == true and backup storage redundancy == Zone
	1. Copy source vldb passing in zone redundant == false and backup storage redundancy == Zone,
	   Verify copied vldb has zone redundant == false and backup storage redundancy == Zone
	2. Copy source vldb with no parameters passed in,
	   Verify copied vldb has zone redundant == true and backup storage redundancy == Zone
#>
function Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceZRDatabaseName = Get-DatabaseName + "-zr"

	$copyFalseZRParamDatabaseName = $sourceZRDatabaseName + "-source-zr-copy-zr-false"
	$copyNoZRParamDatabaseName = $sourceZRDatabaseName + "-source-zr-copy-no-zr-param"

	try
	{
		# Create source vldb with zone redundancy == true and backup storage redundancy == Zone
		$sourceZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify created source vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $sourceZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceZRDatabase.DatabaseName $sourceZRDatabaseName
		Assert-AreEqual $sourceZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceZRDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $sourceZRDatabase.ZoneRedundant 
		Assert-True    { $sourceZRDatabase.ZoneRedundant }

		# Copy source vldb with zone redundancy == false and backup storage redundancy == Zone
		$copyFalseZRParamDatabaseResult = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabase.DatabaseName `
		 -CopyDatabaseName $copyFalseZRParamDatabaseName -BackupStorageRedundancy "Zone" -ZoneRedundant:$false
		
		# Verify returned response has zone redundancy == false
		Assert-NotNull  $copyFalseZRParamDatabaseResult.ZoneRedundant 
		Assert-False    { $copyFalseZRParamDatabaseResult.ZoneRedundant }

		# Retrieve the copied vldb
		$copyFalseZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $copyFalseZRParamDatabaseName

		# Verify copied vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Zone)
		Assert-AreEqual $copyFalseZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $copyFalseZRParamDatabase.DatabaseName $copyFalseZRParamDatabaseName
		Assert-AreEqual $copyFalseZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $copyFalseZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $copyFalseZRParamDatabase.ZoneRedundant 
		Assert-False    { $copyFalseZRParamDatabase.ZoneRedundant }

		# Copy source vldb with no parameters passed in
		$copyNoZRParamDatabaseCopyResult = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabase.DatabaseName `
		 -CopyDatabaseName $copyNoZRParamDatabaseName

		# Verify returned response has zone redundancy == true
		Assert-NotNull  $copyNoZRParamDatabaseCopyResult.ZoneRedundant 
		Assert-True     { $copyNoZRParamDatabaseCopyResult.ZoneRedundant }

		# Retrieve the copied vldb
		$copyNoZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $copyNoZRParamDatabaseName

		# Verify copied vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $copyNoZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $copyNoZRParamDatabase.DatabaseName $copyNoZRParamDatabaseName
		Assert-AreEqual $copyNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $copyNoZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $copyNoZRParamDatabase.ZoneRedundant 
		Assert-True     { $copyNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a vldb geo secondary with geo primary zone redundant == false
	1. Create geo secondary vldb by passing in zone redundant == true and backup storage redundancy == Zone,
	   Verify created geo secondary vldb has zone redundant == true and backup storage redundancy == Zone
	2. Create geo secondary vldb with no parameters passed in,
	   Verify created geo secondary vldb has zone redundant == false and backup storage redundancy == Geo
#>
function Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"

	# Setup for geo primary
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceNonZRDatabaseName = Get-DatabaseName + "-non-zr"
	$sourceNonZRDatabaseName2 = Get-DatabaseName + "-non-zr-2"

	#Setup for geo secondary
	$rgSecondary = Create-ResourceGroupForTest $location
	$serverSecondary = Create-ServerForTest $rgSecondary $location
	$secondaryTrueZRParamDatabaseName = $sourceNonZRDatabaseName + "-source-non-zr-secondary-zr-true"
	$secondaryNoZRParamDatabaseName = $sourceNonZRDatabaseName2 + "-source-non-zr-secondary-no-zr-param"

	try
	{
		# Create first geo primary vldb
		$sourceNonZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded"

		# Verify created geo primary vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $sourceNonZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceNonZRDatabase.DatabaseName $sourceNonZRDatabaseName
		Assert-AreEqual $sourceNonZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceNonZRDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $sourceNonZRDatabase.ZoneRedundant 
		Assert-False    { $sourceNonZRDatabase.ZoneRedundant }

		# Create geo secondary vldb with zone redundancy == true and backup storage redundancy == Zone
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabase.DatabaseName `
		 -PartnerResourceGroupName $rgSecondary.ResourceGroupName -PartnerServerName $serverSecondary.ServerName -PartnerDatabaseName $secondaryTrueZRParamDatabaseName `
		 -BackupStorageRedundancy "Zone" -ZoneRedundant
		
		# Retrieve the created geo secondary vldb
		$secondaryTrueZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rgSecondary.ResourceGroupName -ServerName $serverSecondary.ServerName -DatabaseName $secondaryTrueZRParamDatabaseName

		# Verify geo secondary vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $secondaryTrueZRParamDatabase.ServerName $serverSecondary.ServerName
		Assert-AreEqual $secondaryTrueZRParamDatabase.DatabaseName $secondaryTrueZRParamDatabaseName
		Assert-AreEqual $secondaryTrueZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $secondaryTrueZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $secondaryTrueZRParamDatabase.ZoneRedundant 
		Assert-True     { $secondaryTrueZRParamDatabase.ZoneRedundant }

		# Create second geo primary vldb
		$sourceNonZRDatabase2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabaseName2 `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded"

		# Verify created geo primary vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $sourceNonZRDatabase2.ServerName $server.ServerName
		Assert-AreEqual $sourceNonZRDatabase2.DatabaseName $sourceNonZRDatabaseName2
		Assert-AreEqual $sourceNonZRDatabase2.Edition "Hyperscale"
		Assert-AreEqual $sourceNonZRDatabase2.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $sourceNonZRDatabase2.ZoneRedundant 
		Assert-False    { $sourceNonZRDatabase2.ZoneRedundant }

		# Create geo secondary vldb with no parameters passed in
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabase2.DatabaseName `
		 -PartnerResourceGroupName $rgSecondary.ResourceGroupName -PartnerServerName $serverSecondary.ServerName -PartnerDatabaseName $secondaryNoZRParamDatabaseName
		
		# Retrieve the created geo secondary vldb
		$secondaryNoZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rgSecondary.ResourceGroupName -ServerName $serverSecondary.ServerName -DatabaseName $secondaryNoZRParamDatabaseName

		# Verify geo secondary vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $secondaryNoZRParamDatabase.ServerName $serverSecondary.ServerName
		Assert-AreEqual $secondaryNoZRParamDatabase.DatabaseName $secondaryNoZRParamDatabaseName
		Assert-AreEqual $secondaryNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $secondaryNoZRParamDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $secondaryNoZRParamDatabase.ZoneRedundant 
		Assert-False    { $secondaryNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rgSecondary
	}
}

<#
	.SYNOPSIS
	Tests creating a vldb geo secondary with geo primary zone redundant == true and backup storage redundancy == Zone
	1. Create geo secondary vldb by passing in zone redundant == false,
	   Verify created geo secondary vldb has zone redundant == false and backup storage redundancy == Zone
	2. Create geo secondary vldb with no parameters passed in,
	   Verify created geo secondary vldb has zone redundant == true and backup storage redundancy == Zone
#>
function Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"

	# Setup for geo primary
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceZRDatabaseName = Get-DatabaseName + "-zr"
	$sourceZRDatabaseName2 = Get-DatabaseName + "-zr-2"

	#Setup for geo secondary
	$rgSecondary = Create-ResourceGroupForTest $location
	$serverSecondary = Create-ServerForTest $rgSecondary $location
	$secondaryFalseZRParamDatabaseName = $sourceZRDatabaseName + "-source-zr-secondary-zr-false"
	$secondaryNoZRParamDatabaseName = $sourceZRDatabaseName2 + "-source-zr-secondary-no-zr-param"

	try
	{
		# Create first geo primary vldb with zone redundant == true and backup storage redundancy == Zone
		$sourceZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify created geo primary vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $sourceZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceZRDatabase.DatabaseName $sourceZRDatabaseName
		Assert-AreEqual $sourceZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceZRDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $sourceZRDatabase.ZoneRedundant 
		Assert-True    { $sourceZRDatabase.ZoneRedundant }

		# Create geo secondary vldb with zone redundancy == false
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabase.DatabaseName `
		 -PartnerResourceGroupName $rgSecondary.ResourceGroupName -PartnerServerName $serverSecondary.ServerName -PartnerDatabaseName $secondaryFalseZRParamDatabaseName `
		 -ZoneRedundant:$false

		# Retrieve the created geo secondary vldb
		$secondaryFalseZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rgSecondary.ResourceGroupName -ServerName $serverSecondary.ServerName -DatabaseName $secondaryFalseZRParamDatabaseName

		# Verify geo secondary vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Zone)
		Assert-AreEqual $secondaryFalseZRParamDatabase.ServerName $serverSecondary.ServerName
		Assert-AreEqual $secondaryFalseZRParamDatabase.DatabaseName $secondaryFalseZRParamDatabaseName
		Assert-AreEqual $secondaryFalseZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $secondaryFalseZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $secondaryFalseZRParamDatabase.ZoneRedundant 
		Assert-False     { $secondaryFalseZRParamDatabase.ZoneRedundant }

		# Create second geo primary vldb with zone redundant == true and backup storage redundancy == Zone
		$sourceZRDatabase2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabaseName2 `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify created geo primary vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $sourceZRDatabase2.ServerName $server.ServerName
		Assert-AreEqual $sourceZRDatabase2.DatabaseName $sourceZRDatabaseName2
		Assert-AreEqual $sourceZRDatabase2.Edition "Hyperscale"
		Assert-AreEqual $sourceZRDatabase2.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $sourceZRDatabase2.ZoneRedundant 
		Assert-True     { $sourceZRDatabase2.ZoneRedundant }

		# Create geo secondary vldb with no parameters passed in
		New-AzSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabase2.DatabaseName `
		 -PartnerResourceGroupName $rgSecondary.ResourceGroupName -PartnerServerName $serverSecondary.ServerName -PartnerDatabaseName $secondaryNoZRParamDatabaseName

		# Retrieve the created geo secondary vldb
		$secondaryNoZRParamDatabase = Get-AzSqlDatabase -ResourceGroupName $rgSecondary.ResourceGroupName -ServerName $serverSecondary.ServerName -DatabaseName $secondaryNoZRParamDatabaseName

		# Verify geo secondary vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $secondaryNoZRParamDatabase.ServerName $serverSecondary.ServerName
		Assert-AreEqual $secondaryNoZRParamDatabase.DatabaseName $secondaryNoZRParamDatabaseName
		Assert-AreEqual $secondaryNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $secondaryNoZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $secondaryNoZRParamDatabase.ZoneRedundant 
		Assert-True     { $secondaryNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rgSecondary
	}
}

<#
	.SYNOPSIS
	Tests creating a database copy with per db cmk
#>
function Test-CreateDatabaseCopyWithPerDBCMK($location = "eastus2euap")
{
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$database = Create-DatabaseForTest $rg $server "Standard"

	$copyRg = Create-ResourceGroupForTest $location
	$copyServer = Create-ServerForTest $copyRg $location
	$copyDatabaseName = Get-DatabaseName

	$encryptionProtector = "https://pstestkv.vault.azure.net/keys/testkey/f62d937858464f329ab4a8c2dc7e0fa4"
	$umi = "/subscriptions/2c647056-bab2-4175-b172-493ff049eb29/resourceGroups/pstest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstestumi"

	try
	{
		# Create a cross server copy
		$dbCrossServerCopy = New-AzSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyResourceGroupName $copyRg.ResourceGroupName -CopyServerName $copyServer.ServerName -CopyDatabaseName $copyDatabaseName -AssignIdentity -EncryptionProtector $encryptionProtector -UserAssignedIdentityId $umi -EncryptionProtectorAutoRotation
		Assert-AreEqual $dbCrossServerCopy.CopyServerName $copyServer.ServerName
		Assert-AreEqual $dbCrossServerCopy.CopyDatabaseName $copyDatabaseName
		Assert-AreEqual $dbCrossServerCopy.EncryptionProtector $encryptionProtector
		Assert-AreEqual $dbCrossServerCopy.EncryptionProtectorAutoRotation $true
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $copyRg
	}
}