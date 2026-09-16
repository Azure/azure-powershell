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
	Tests getting all deleted servers at subscription level (no filters)
	.DESCRIPTION
	SmokeTest
#>
function Test-GetDeletedServerAtSubscriptionLevel
{
	# Setup - two servers in different regions to verify subscription-wide listing
	$rgCentralUs = Create-ResourceGroupForTest "centralus"
	$rgWestUs = Create-ResourceGroupForTest "westus"
	$serverNameCentralUs = Get-ServerName
	$serverNameWestUs = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$softDeleteRetentionDays = 7

	try
	{
		# Create and soft-delete server in centralus
		$serverCentralUs = New-AzSqlServer -ResourceGroupName $rgCentralUs.ResourceGroupName -ServerName $serverNameCentralUs -Location $rgCentralUs.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays
		Assert-NotNull $serverCentralUs
		Remove-AzSqlServer -ResourceGroupName $rgCentralUs.ResourceGroupName -ServerName $serverNameCentralUs -Force

		# Create and soft-delete server in westus
		$serverWestUs = New-AzSqlServer -ResourceGroupName $rgWestUs.ResourceGroupName -ServerName $serverNameWestUs -Location $rgWestUs.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays
		Assert-NotNull $serverWestUs
		Remove-AzSqlServer -ResourceGroupName $rgWestUs.ResourceGroupName -ServerName $serverNameWestUs -Force

		# Get all deleted servers in the subscription (no filters)
		$deletedServers = Get-AzSqlDeletedServer
		Assert-NotNull $deletedServers

		# Verify at least 2 servers are returned
		Assert-True { ($deletedServers | Measure-Object).Count -ge 2 }

		# Verify centralus server properties
		$serverFromCentralUs = $deletedServers | Where-Object { $_.ServerName -eq $serverNameCentralUs }
		Assert-NotNull $serverFromCentralUs
		Assert-AreEqual $serverFromCentralUs.ServerName $serverNameCentralUs
		Assert-AreEqual $serverFromCentralUs.ResourceGroupName $rgCentralUs.ResourceGroupName
		Assert-AreEqual $serverFromCentralUs.Location.ToLowerInvariant() $rgCentralUs.Location.Replace(' ', '').ToLowerInvariant()
		Assert-NotNull $serverFromCentralUs.DeletionTime
		Assert-NotNull $serverFromCentralUs.ScheduledPurgeTime
		Assert-AreEqual ($serverFromCentralUs.ScheduledPurgeTime - $serverFromCentralUs.DeletionTime).Days $softDeleteRetentionDays
		Assert-NotNull $serverFromCentralUs.FullyQualifiedDomainName
		Assert-NotNull $serverFromCentralUs.Version
		Assert-NotNull $serverFromCentralUs.Id
		Assert-NotNull $serverFromCentralUs.OriginalId
		Assert-NotNull $serverFromCentralUs.SubscriptionId

		# Verify westus server properties
		$serverFromWestUs = $deletedServers | Where-Object { $_.ServerName -eq $serverNameWestUs }
		Assert-NotNull $serverFromWestUs
		Assert-AreEqual $serverFromWestUs.ServerName $serverNameWestUs
		Assert-AreEqual $serverFromWestUs.ResourceGroupName $rgWestUs.ResourceGroupName
		Assert-AreEqual $serverFromWestUs.Location.ToLowerInvariant() $rgWestUs.Location.Replace(' ', '').ToLowerInvariant()
		Assert-NotNull $serverFromWestUs.DeletionTime
		Assert-NotNull $serverFromWestUs.ScheduledPurgeTime
		Assert-AreEqual ($serverFromWestUs.ScheduledPurgeTime - $serverFromWestUs.DeletionTime).Days $softDeleteRetentionDays
		Assert-NotNull $serverFromWestUs.FullyQualifiedDomainName
		Assert-NotNull $serverFromWestUs.Version
		Assert-NotNull $serverFromWestUs.Id
		Assert-NotNull $serverFromWestUs.OriginalId
		Assert-NotNull $serverFromWestUs.SubscriptionId
	}
	finally
	{
		Restore-AzSqlServer -ResourceGroupName $rgCentralUs.ResourceGroupName -ServerName $serverNameCentralUs -Location $rgCentralUs.Location
		Set-AzSqlServer -ResourceGroupName $rgCentralUs.ResourceGroupName -ServerName $serverNameCentralUs -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rgCentralUs

		Restore-AzSqlServer -ResourceGroupName $rgWestUs.ResourceGroupName -ServerName $serverNameWestUs -Location $rgWestUs.Location
		Set-AzSqlServer -ResourceGroupName $rgWestUs.ResourceGroupName -ServerName $serverNameWestUs -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rgWestUs
	}
}

<#
	.SYNOPSIS
	Tests getting deleted servers filtered by server name only (no location, client-side filter)
	.DESCRIPTION
	SmokeTest
#>
function Test-GetDeletedServerByServerNameOnly
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))

	try
	{
		# Create and delete server to ensure it appears in soft-deleted list
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays 7
		Assert-NotNull $server

		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Get deleted servers by server name only (subscription-level, client-side filter)
		$deletedServers = Get-AzSqlDeletedServer -ServerName $serverName
		Assert-NotNull $deletedServers

		foreach ($s in $deletedServers)
		{
			Assert-AreEqual $s.ServerName $serverName
		}
	}
	finally
	{
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting deleted servers by location
	.DESCRIPTION
	SmokeTest
#>
function Test-GetDeletedServerByLocation
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))

	try
	{
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays 7
		Assert-NotNull $server

		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Get all deleted servers in the location
		$deletedServers = Get-AzSqlDeletedServer -Location $rg.Location
		Assert-NotNull $deletedServers

		$ourServer = $deletedServers | Where-Object { $_.ServerName -eq $serverName }
		Assert-NotNull $ourServer
		Assert-NotNull $ourServer.ServerName
		Assert-NotNull $ourServer.Location
		Assert-NotNull $ourServer.DeletionTime
		Assert-NotNull $ourServer.Id
		Assert-AreEqual $ourServer.Location.ToLowerInvariant() $rg.Location.Replace(' ', '').ToLowerInvariant()
	}
	finally
	{
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests creating a server with soft delete retention, deleting it, and then retrieving it using Get-AzSqlDeletedServer
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateServerWithSoftDeleteAndVerifyDeletedServer
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$softDeleteRetentionDays = 7

	try
	{
		# Create server with soft delete retention (7 days)
		$job = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays -AsJob
		$job | Wait-Job
		$server = Receive-Job -Job $job
		Assert-NotNull $server

		# Delete the server (this will soft delete it)
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Test 1: Get all deleted servers in the location and verify our server is listed
		$deletedServers = Get-AzSqlDeletedServer -Location $rg.Location
		Assert-NotNull $deletedServers

		$ourDeletedServer = $deletedServers | Where-Object { $_.ServerName -eq $serverName }
		Assert-NotNull $ourDeletedServer
		Assert-AreEqual $ourDeletedServer.ServerName $serverName
		Assert-NotNull $ourDeletedServer.DeletionTime
		Assert-NotNull $ourDeletedServer.OriginalId

		# Test 2: Get the specific deleted server by location and name
		$specificDeletedServer = Get-AzSqlDeletedServer -Location $rg.Location -ServerName $serverName
		Assert-NotNull $specificDeletedServer
		Assert-AreEqual $specificDeletedServer.ServerName $serverName
		Assert-NotNull $specificDeletedServer.DeletionTime
		Assert-NotNull $specificDeletedServer.FullyQualifiedDomainName
		Assert-NotNull $specificDeletedServer.ScheduledPurgeTime
	}
	finally
	{
		# Clean up the resource group 
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests attempting to get a deleted server from a different location than where it was deleted (negative scenario)
	.DESCRIPTION
	Negative test
#>
function Test-GetDeletedServerInvalidLocation
{
	# Setup - use two different valid locations
	$rg = Create-ResourceGroupForTest "centralus"
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$softDeleteRetentionDays = 7
	$wrongLocation = "eastus"

	try
	{
		# Create and delete server in centralus
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays
		Assert-NotNull $server

		# Delete the server (soft delete)
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Attempt to get deleted server from wrong location (eastus instead of centralus) - should throw ResourceNotFound
		Assert-Throws { Get-AzSqlDeletedServer -Location $wrongLocation -ServerName $serverName }
	}
	finally
	{
		# Clean up - restore and delete from correct location
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}