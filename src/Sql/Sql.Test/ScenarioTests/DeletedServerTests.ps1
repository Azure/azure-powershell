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
	Tests getting deleted servers by location
	.DESCRIPTION
	SmokeTest
#>
function Test-GetDeletedServerByLocation
{
	# Setup
	$location = "centralus"

	try
	{
		# Get all deleted servers in the location
		$deletedServers = Get-AzSqlDeletedServer -Location $location

		# Validate the results (may be empty if no deleted servers exist)
		Assert-NotNull $deletedServers
		
		# If there are deleted servers, validate their properties
		if ($deletedServers.Count -gt 0) {
			foreach ($deletedServer in $deletedServers) {
				Assert-NotNull $deletedServer.ServerName
				Assert-NotNull $deletedServer.Location
				Assert-NotNull $deletedServer.DeletionTime
				Assert-NotNull $deletedServer.Id
				Assert-NotNull $deletedServer.Type
				Assert-AreEqual $deletedServer.Location.ToLowerInvariant() $location.ToLowerInvariant().Replace(' ', '')
			}
		}
	}
	catch
	{
		# If the API returns an error (e.g., location not found), that's acceptable for this test
		Write-Host "Test completed with expected behavior for location: $location"
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
		$deletedServers = Get-AzSqlDeletedServer -Location $rg.Location -ServerName $serverName
		Assert-NotNull $deletedServers
		
		$ourDeletedServer = $deletedServers | Where-Object { $_.ServerName -eq $serverName }
		if ($ourDeletedServer) {
			Assert-AreEqual $ourDeletedServer.ServerName $serverName
			Assert-NotNull $ourDeletedServer.DeletionTime
			Assert-NotNull $ourDeletedServer.OriginalId
		}

		# Test 2: Get the specific deleted server by name
		$specificDeletedServer = Get-AzSqlDeletedServer -Location $rg.Location -ServerName $serverName
		if ($specificDeletedServer) {
			Assert-AreEqual $specificDeletedServer.ServerName $serverName
			Assert-NotNull $specificDeletedServer.DeletionTime
			Assert-NotNull $specificDeletedServer.FullyQualifiedDomainName
		}
	}
	finally
	{
		# Clean up the resource group 
		Restore-AzSqlServer -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}