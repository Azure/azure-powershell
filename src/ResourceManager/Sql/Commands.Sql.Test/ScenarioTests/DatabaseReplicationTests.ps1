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
function Test-CreateDatabaseCopy
{
	Test-CreateCopyInternal "12.0" "North Europe"
}

<#
	.SYNOPSIS
	Tests creating a database copy
#>
function Test-CreateDatabaseCopyV2
{
	Test-CreateCopyInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests creating a database copy
#>
function Test-CreateCopyInternal ($serverVersion, $location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$copyRg = Create-ResourceGroupForTest
	$copyServer = Create-ServerForTest $copyRg $serverVersion $location
	$copyDatabaseName = Get-DatabaseName

	try
	{	
		# Create a local database copy
		$dbLocalCopy = New-AzureSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyDatabaseName $copyDatabaseName
		Assert-AreEqual $dbLocalCopy.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $database.DatabaseName
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName

		# Create a cross server copy
		$dbCrossServerCopy = New-AzureSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
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
	Tests creating a secondary database
#>
function Test-CreateSecondaryDatabase
{
	Test-CreateSecondaryDatabaseInternal "12.0" "North Europe"
}

<#
	.SYNOPSIS
	Tests creating a secondary database
#>
function Test-CreateSecondaryDatabaseV2
{
	Test-CreateSecondaryDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests creating a secondary database
#>
function Test-CreateSecondaryDatabaseInternal ($serverVersion, $location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# Create Secondary (defaults to NonReadableSecondary)
		$secondary = New-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName
		Assert-NotNull $nonReadSecondary.LinkId
		Assert-AreEqual $nonReadSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $nonReadSecondary.ServerName $server.ServerName
		Assert-AreEqual $nonReadSecondary.DatabaseName $database.DatabaseName
		Assert-NotNull $nonReadSecondary.Role
		Assert-AreEqual $nonReadSecondary.Location $location
		Assert-AreEqual $nonReadSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $nonReadSecondary.PartnerServerName $partServer.ServerName
		Assert-NotNull $nonReadSecondary.PartnerRole
		Assert-AreEqual $nonReadSecondary.PartnerLocation $location
		Assert-NotNull $nonReadSecondary.AllowConnections
		Assert-NotNull $nonReadSecondary.ReplicationState
		Assert-NotNull $nonReadSecondary.PercentComplete
		Get-AzureSqlDatabase -ResourceGroupName $partRg.ResourceGroupName -ServerName $partServer.ServerName -DatabaseName $database.DatabaseName | Remove-DatabaseForTest
		Get-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName | Remove-DatabaseForTest

		# Create Readable Secondary
		$database = Create-DatabaseForTest $rg $server "Premium"
		$readSecondary = New-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All
		Assert-NotNull $readSecondary.LinkId
		Assert-AreEqual $readSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $readSecondary.ServerName $server.ServerName
		Assert-AreEqual $readSecondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $readSecondary.Role "Primary"
		Assert-AreEqual $readSecondary.Location $location
		Assert-AreEqual $readSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $readSecondary.PartnerServerName $partServer.ServerName
		Assert-AreEqual $readSecondary.PartnerRole "ReadableSecondary"
		Assert-AreEqual $readSecondary.PartnerLocation $location
		Assert-AreEqual $readSecondary.AllowConnections "All"
		Assert-NotNull $readSecondary.ReplicationState
		Assert-NotNull $readSecondary.PercentComplete
		Get-AzureSqlDatabase -ResourceGroupName $readSecondary.PartnerResourceGroupName -ServerName $readSecondary.PartnerServerName -DatabaseName $readSecondary.DatabaseName `
		 | Remove-DatabaseForTest

		# Create NonReadable Secondary
		$nonReadSecondary = New-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections No
		Assert-NotNull $nonReadSecondary.LinkId
		Assert-AreEqual $nonReadSecondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $nonReadSecondary.ServerName $server.ServerName
		Assert-AreEqual $nonReadSecondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $nonReadSecondary.Role "Primary"
		Assert-AreEqual $nonReadSecondary.Location $location
		Assert-AreEqual $nonReadSecondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $nonReadSecondary.PartnerServerName $partServer.ServerName
		Assert-AreEqual $nonReadSecondary.PartnerRole "NonReadableSecondary"
		Assert-AreEqual $nonReadSecondary.PartnerLocation $location
		Assert-AreEqual $nonReadSecondary.AllowConnections "No"
		Assert-NotNull $nonReadSecondary.ReplicationState
		Assert-NotNull $nonReadSecondary.PercentComplete
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
function Test-GetReplicationLink
{
	Test-GetReplicationLinkInternal "12.0" "North Europe"
}

<#
	.SYNOPSIS
	Tests getting a secondary database
#>
function Test-GetReplicationLinkV2
{
	Test-GetReplicationLinkInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests getting a secondary database
#>
function Test-GetReplicationLinkInternal ($serverVersion, $location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# Get Secondary
		New-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName

		$secondary = Get-AzureSqlDatabaseReplicationLink -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		 -DatabaseName $database.DatabaseName -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName
		Assert-NotNull $secondary.LinkId
		Assert-AreEqual $secondary.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $secondary.ServerName $server.ServerName
		Assert-AreEqual $secondary.DatabaseName $database.DatabaseName
		Assert-AreEqual $secondary.Role Primary
		Assert-AreEqual $secondary.Location $location
		Assert-AreEqual $secondary.PartnerResourceGroupName $partRg.ResourceGroupName
		Assert-AreEqual $secondary.PartnerServerName $partServer.ServerName
		Assert-AreEqual $secondary.PartnerRole NonReadableSecondary
		Assert-AreEqual $secondary.PartnerLocation $location
		Assert-AreEqual $secondary.AllowConnections No
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
function Test-RemoveSecondaryDatabase
{
	Test-RemoveSecondaryDatabaseInternal "12.0" "North Europe"
}

<#
	.SYNOPSIS
	Tests removing a secondary database
#>
function Test-RemoveSecondaryDatabaseV2
{
	Test-RemoveSecondaryDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests removing a secondary database
#>
function Test-RemoveSecondaryDatabaseInternal ($serverVersion, $location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# remove Secondary
		New-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName

		Remove-AzureSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
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
	Creates test database
#>
function Create-DatabaseForTest  ($rg, $server, $edition = "Standard")
{
	$databaseName = Get-DatabaseName
	$maxSizeBytes = 250GB
	New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition $edition -MaxSizeBytes $maxSizeBytes
}

<#
	.SYNOPSIS
	Removes a test database
#>
function Remove-DatabaseForTest  ($testDatabase)
{
	$testDatabase | Remove-AzureSqlDatabase
}