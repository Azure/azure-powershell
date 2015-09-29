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
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server "Standard"

	$copyRg = Create-ResourceGroupForTest $location
	$copyServer = Create-ServerForTest $copyRg $serverVersion $location
	$copyDatabaseName = Get-DatabaseName

	try
	{	
		# Create a local database copy
		$dbLocalCopy = New-AzureRmSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -CopyDatabaseName $copyDatabaseName
		Assert-AreEqual $dbLocalCopy.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.ServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.DatabaseName $database.DatabaseName
		Assert-AreEqual $dbLocalCopy.CopyResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $dbLocalCopy.CopyServerName $server.ServerName
		Assert-AreEqual $dbLocalCopy.CopyDatabaseName $copyDatabaseName

		# Create a cross server copy
		$dbCrossServerCopy = New-AzureRmSqlDatabaseCopy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
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
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# Create Readable Secondary
		$readSecondary = New-AzureRmSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
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
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# Get Secondary
		New-AzureRmSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All

		$secondary = Get-AzureRmSqlDatabaseReplicationLink -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
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
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# remove Secondary
		New-AzureRmSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All

		Remove-AzureRmSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
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
	Tests removing a secondary database
#>
function Test-FailoverSecondaryDatabase
{
	#v12 only
	Test-FailoverSecondaryDatabaseInternal "12.0" "North Europe"
}

<#
	.SYNOPSIS
	Tests failing over a secondary database
#>
function Test-FailoverSecondaryDatabaseInternal ($serverVersion, $location = "North Europe")
{
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location
	$database = Create-DatabaseForTest $rg $server

	$partRg = Create-ResourceGroupForTest $location
	$partServer = Create-ServerForTest $partRg $serverVersion $location

	try
	{	
		# failover Secondary
		New-AzureRmSqlDatabaseSecondary -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $database.DatabaseName `
		 -PartnerResourceGroupName $partRg.ResourceGroupName -PartnerServerName $partServer.ServerName -AllowConnections All

		$secondary = Get-AzureRmSqlDatabaseReplicationLink -ResourceGroupName $partRg.ResourceGroupName -ServerName $partServer.ServerName -DatabaseName $database.DatabaseName -PartnerResourceGroupName $rg.ResourceGroupName -PartnerServerName $server.ServerName

		$secondary | Set-AzureRmSqlDatabaseSecondary -PartnerResourceGroupName $rg.ResourceGroupName -Failover
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
	New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition $edition
}