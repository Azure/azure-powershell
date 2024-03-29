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
	Tests creating a server
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateServer
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))

	try
	{
		# With all parameters
		$job = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -AsJob
		$job | Wait-Job
		$server1 = $job.Output

		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.ServerVersion $version
		Assert-AreEqual $server1.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a server
	.DESCRIPTION
	SmokeTest
#>
function Test-UpdateServer
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $rg.Location

	try
	{
		# Test using parameters
		$serverPassword = "n3wc00lP@55w0rd"
		$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force

		$server1 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-SqlAdministratorPassword $secureString

		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.ServerVersion $server.ServerVersion
		Assert-AreEqual $server1.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName

		# Test piping
		$serverPassword = "n3wc00lP@55w0rd!!!"
		$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force

		$server2 = $server | Set-AzSqlServer -SqlAdministratorPassword $secureString
		Assert-AreEqual $server2.ServerName $server.ServerName
		Assert-AreEqual $server2.ServerVersion $server.ServerVersion
		Assert-AreEqual $server2.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a server
	.DESCRIPTION
	SmokeTest
#>
function Test-GetServer
{
	# Setup
	$rg = Create-ResourceGroupForTest "West Europe"
	$rg1 = Create-ResourceGroupForTest "West Europe"
	$server1 = Create-ServerForTest $rg $rg.Location
	$server2 = Create-ServerForTest $rg $rg.Location
	$server3 = Create-ServerForTest $rg1 $rg.Location

	try
	{
		# Test using parameters
		$resp1 = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName
		Assert-AreEqual $server1.ServerName $resp1.ServerName
		Assert-AreEqual $server1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName

		# Test piping
		$resp2 = $server2 | Get-AzSqlServer
		Assert-AreEqual $server2.ServerName $resp2.ServerName
		Assert-AreEqual $server2.SqlAdministratorLogin $resp2.SqlAdministratorLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName

		$all = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -Name *
		Assert-AreEqual 2 $all.Count

		# Test getting all servers in all resource groups
		$all2 = Get-AzSqlServer -ResourceGroupName *

		# It is possible that there were existing servers in the subscription when the test was recorded, so make sure
		# that the servers that we created are retrieved and ignore the other ones.
		($server1, $server2, $server3) | ForEach-Object { Assert-True {$_.ServerName -in $all2.ServerName} }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rg1
	}
}

<#
	.SYNOPSIS
	Tests Removing a server
	.DESCRIPTION
	SmokeTest
#>
function Test-RemoveServer
{
	# Setup
	$rg = Create-ResourceGroupForTest "West Europe"
	$server1 = Create-ServerForTest $rg $rg.Location
	$server2 = Create-ServerForTest $rg $rg.Location

	try
	{
		# Test using parameters
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName -Force

		# Test piping
		$server2 | Remove-AzSqlServer -Force

		$all = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a server with an identity
#>
function Test-CreateServerWithIdentity
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))

	try
	{
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location "West Europe" -SqlAdministratorCredentials $credentials -AssignIdentity
		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.Identity.Type SystemAssigned
		Assert-NotNull $server1.Identity.PrincipalId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a server with an identity
#>
function Test-UpdateServerWithIdentity
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$location = "westeurope"
	$server = Create-ServerForTest $rg $location

	try
	{
		$serverPassword = "n3wc00lP@55w0rd"
		$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force

		$server1 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SqlAdministratorPassword $secureString -AssignIdentity
		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.Identity.Type SystemAssigned
		Assert-NotNull $server1.Identity.PrincipalId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests update on a server with an identity without using AssignIdentity switch
#>
function Test-UpdateServerWithoutIdentity
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))

	try
	{
		# Create a server with identity
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location "West Europe" -SqlAdministratorCredentials $credentials -AssignIdentity
		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.Identity.Type SystemAssigned
		Assert-NotNull $server1.Identity.PrincipalId

		# Update server without "AssignIdentity" switch and validate identity still exists
		$newPassword = "n3wc00lP@55w0rd"
		$secureString = ConvertTo-SecureString $newPassword -AsPlainText -Force
		$server2 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName -SqlAdministratorPassword $secureString
		Assert-AreEqual $server2.Identity.Type SystemAssigned
		Assert-NotNull $server2.Identity.PrincipalId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a server with a federated client id
#>
function Test-CreateServerWithFederatedClientId
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$federatedClientId = "3728d52a-7b46-47a9-8a8c-318c27263eef";

	try
	{
		New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location "eastus2euap" -SqlAdministratorCredentials $credentials -FederatedClientId $federatedClientId -AssignIdentity
		$respserver = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName
		Assert-AreEqual $respserver.ServerName $serverName
		Assert-AreEqual $respserver.FederatedClientId $federatedClientId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a server with a federated client id
#>
function Test-UpdatingServerWithFederatedClientId
{
	# Setup
	$rg = Create-ResourceGroupForTest

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$federatedClientId = "3728d52a-7b46-47a9-8a8c-318c27263eef";
	$updatedFederatedClientId = "dac7a46b-3dc9-4893-ab34-18169a917073";

	try
	{
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location "eastus2euap" -SqlAdministratorCredentials $credentials -FederatedClientId $federatedClientId -AssignIdentity
		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.FederatedClientId $federatedClientId

		# Update server with new Federated client id
		$newPassword = "n3wc00lP@55w0rd"
		$secureString = ConvertTo-SecureString $newPassword -AsPlainText -Force
		$server2 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName -SqlAdministratorPassword $secureString -FederatedClientId $updatedFederatedClientId
		Assert-AreEqual $server2.FederatedClientId $updatedFederatedClientId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests create and update a server with minimal TLS version
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateandUpdateServerWithMinimalTlsVersion
{
	# Setup
	$location = "West Europe"
	$rg = Create-ResourceGroupForTest $location

	try
	{
		# Test using parameters
		$serverName = Get-ServerName
		$version = "12.0"
		$serverLogin = "testusername"
		$serverPassword = "t357ingP@s5w0rd!"
		$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
		$tls1_1 = "1.1"
		$tls1_2 = "1.2"
		$tlsNone = "None"

		# With all parameters
		#Checking creation as well as defaulting of MinimalTlsVersion
		#$job = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName `
		#	-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -AsJob
		#$job | Wait-Job

		New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials

		$server1 =  Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName
		Assert-AreEqual $server1.MinimalTlsVersion $tls1_2

		$server2 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -MinimalTlsVersion $tls1_1
		Assert-AreEqual $server2.MinimalTlsVersion $tls1_1
		
		$server3 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -MinimalTlsVersion $tlsNone
		Assert-AreEqual $server3.MinimalTlsVersion $tlsNone
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests create server with Enabled/Disabled/null PublicNetworkAccess.  Also check get server returns correct PublicNetworkAccess.
#>
function Test-CreateAndGetServerWithPublicNetworkAccess
{
	# Setup
	$location = "westeurope"
	$rg = Create-ResourceGroupForTest $location

	$serverName1 = Get-ServerName
	$serverName2 = Get-ServerName
	$serverName3 = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$enabled = "Enabled"
	$disabled = "Disabled"

	try
	{
		# Create a server with PublicNetworkAccess Enabled
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName1 -Location $location -SqlAdministratorCredentials $credentials -PublicNetworkAccess "Enabled"
		Assert-AreEqual $server1.ServerName $serverName1
		Assert-AreEqual $server1.PublicNetworkAccess $enabled

		$retrievedServer1 = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName
		Assert-AreEqual $retrievedServer1.ServerName $server1.ServerName
		Assert-AreEqual $retrievedServer1.PublicNetworkAccess $enabled

		# Create a server with PublicNetworkAccess Disabled
		$server2 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName2 -Location $location -SqlAdministratorCredentials $credentials -PublicNetworkAccess "Disabled"
		Assert-AreEqual $server2.ServerName $serverName2
		Assert-AreEqual $server2.PublicNetworkAccess $disabled

		# Create a server with PublicNetworkAccess null (should default to Enabled)
		$server3 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName3 -Location $location -SqlAdministratorCredentials $credentials
		Assert-AreEqual $server3.ServerName $serverName3
		Assert-AreEqual $server3.PublicNetworkAccess $enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests update PublicNetworkAccess to Enabled/Disabled/null on server
#>
function Test-UpdateServerWithPublicNetworkAccess
{
	# Setup
	$location = "westeurope"
	$rg = Create-ResourceGroupForTest $location

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$enabled = "Enabled"
	$disabled = "Disabled"

	try
	{
		# Create a server with PublicNetworkAccess Disabled
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials -PublicNetworkAccess $disabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.PublicNetworkAccess $disabled

		# Update server with PublicNetworkAccess Enabled
		$server = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SqlAdministratorPassword $secureString -PublicNetworkAccess $enabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.PublicNetworkAccess $enabled

		# Update server with PublicNetworkAccess null (should still be Enabled)
		$server = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SqlAdministratorPassword $secureString -AssignIdentity
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.Identity.Type SystemAssigned
		Assert-AreEqual $server.PublicNetworkAccess $enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests create server with Enabled/Disabled/null RestrictOutboundNetworkAccess.  Also check get server returns correct RestrictOutboundNetworkAccess.
#>
function Test-CreateAndGetServerWithRestrictOutboundNetworkAccess
{
	# Setup
	$location = "westeurope"
	$rg = Create-ResourceGroupForTest $location

	$serverName1 = Get-ServerName
	$serverName2 = Get-ServerName
	$serverName3 = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$enabled = "Enabled"
	$disabled = "Disabled"

	try
	{
		# Create a server with RestrictOutboundNetworkAccess Enabled
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName1 -Location $location -SqlAdministratorCredentials $credentials -RestrictOutboundNetworkAccess "Enabled"
		Assert-AreEqual $server1.ServerName $serverName1
		Assert-AreEqual $server1.RestrictOutboundNetworkAccess $enabled

		$retrievedServer1 = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName
		Assert-AreEqual $retrievedServer1.ServerName $server1.ServerName
		Assert-AreEqual $retrievedServer1.RestrictOutboundNetworkAccess $enabled

		# Create a server with RestrictOutboundNetworkAccess Disabled
		$server2 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName2 -Location $location -SqlAdministratorCredentials $credentials -RestrictOutboundNetworkAccess "Disabled"
		Assert-AreEqual $server2.ServerName $serverName2
		Assert-AreEqual $server2.RestrictOutboundNetworkAccess $disabled

		$retrievedServer2 = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server2.ServerName
		Assert-AreEqual $retrievedServer2.ServerName $server2.ServerName
		Assert-AreEqual $retrievedServer2.RestrictOutboundNetworkAccess $disabled

		# Create a server with RestrictOutboundNetworkAccess null (should default to Disabled)
		$server3 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName3 -Location $location -SqlAdministratorCredentials $credentials
		Assert-AreEqual $server3.ServerName $serverName3
		Assert-AreEqual $server3.RestrictOutboundNetworkAccess $disabled

		$retrievedServer3 = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server3.ServerName
		Assert-AreEqual $retrievedServer3.ServerName $server3.ServerName
		Assert-AreEqual $retrievedServer3.RestrictOutboundNetworkAccess $disabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests update RestrictOutboundNetworkAccess to Enabled/Disabled/null on server
#>
function Test-UpdateServerWithRestrictOutboundNetworkAccess
{
	# Setup
	$location = "westeurope"
	$rg = Create-ResourceGroupForTest $location

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$enabled = "Enabled"
	$disabled = "Disabled"

	try
	{
		# Create a server with RestrictOutboundNetworkAccess Disabled
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials -RestrictOutboundNetworkAccess $disabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.RestrictOutboundNetworkAccess $disabled

		$retrievedServer = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.RestrictOutboundNetworkAccess $disabled

		# Update server with RestrictOutboundNetworkAccess Enabled
		$server = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SqlAdministratorPassword $secureString -RestrictOutboundNetworkAccess $enabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.RestrictOutboundNetworkAccess $enabled

		$retrievedServer = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.RestrictOutboundNetworkAccess $enabled

		# Update server with RestrictOutboundNetworkAccess null (should still be Enabled)
		$server = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SqlAdministratorPassword $secureString -AssignIdentity
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.Identity.Type SystemAssigned
		Assert-AreEqual $server.RestrictOutboundNetworkAccess $enabled

		$retrievedServer = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.RestrictOutboundNetworkAccess $enabled

		# Update server with RestrictOutboundNetworkAccess Disabled
		$server = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SqlAdministratorPassword $secureString -RestrictOutboundNetworkAccess $disabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.RestrictOutboundNetworkAccess $disabled

		$retrievedServer = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.RestrictOutboundNetworkAccess $disabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Outbound Firewall Rules CRUD operations.
#>
function Test-OutboundFirewallRulesCRUD
{
	# Setup
	$location = "westeurope"
	$rg = Create-ResourceGroupForTest $location

	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
    $enabled = "Enabled"

	try
	{
		# Create a server with RestrictOutboundNetworkAccess Enabled
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials -RestrictOutboundNetworkAccess $enabled
		Assert-AreEqual $server.ServerName $serverName
		Assert-AreEqual $server.RestrictOutboundNetworkAccess $enabled

		$retrievedServer = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.ServerName $server.ServerName
		Assert-AreEqual $retrievedServer.RestrictOutboundNetworkAccess $enabled

		# Create a server with RestrictOutboundNetworkAccess Disabled
        $initialOBFR = Get-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $initalOBFR.Count 0
        #0

        $newOBFR = New-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName -AllowedFQDN "testOBFR1"
        Assert-AreEqual $newOBFR.Count 1
        #1
        Assert-AreEqual $newOBFR[0].AllowedFQDN "testOBFR1"
        Assert-AreEqual $newOBFR[0].ServerName $serverName
        Assert-AreEqual $newOBFR[0].ResourceGroupName $rg.ResourceGroupName

        $getNewOBFR = Get-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName -AllowedFQDN "testOBFR1"
        Assert-AreEqual $getNewOBFR.Count 1
        #1
        Assert-AreEqual $getNewOBFR[0].AllowedFQDN "testOBFR1"
        Assert-AreEqual $getNewOBFR[0].ServerName $serverName
        Assert-AreEqual $getNewOBFR[0].ResourceGroupName $rg.ResourceGroupName

        try
        {
            $getUnknownOBFR = Get-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName -AllowedFQDN "testOBFR2"
        }
        catch
        {
            Assert-AreEqual $_.Exception.Message.StartsWith("Allowed FQDN with name 'testOBFR2' does not exist in the list of Outbound Firewall Rules (Allowed FQDNs) for Azure SQL Database server") true
        }

        $getAllOBFR = Get-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $getAllOBFR.Count 1
        Assert-AreEqual $getAllOBFR[0].AllowedFQDN "testOBFR1"
        Assert-AreEqual $getAllOBFR[0].ServerName $serverName
        Assert-AreEqual $getAllOBFR[0].ResourceGroupName $rg.ResourceGroupName

        $removeOBFR = Remove-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName -AllowedFQDN "testOBFR1"
        Assert-AreEqual $removeOBFR.Count 1
        Assert-AreEqual $removeOBFR[0].AllowedFQDN "testOBFR1"
        Assert-AreEqual $removeOBFR[0].ServerName $serverName
        Assert-AreEqual $removeOBFR[0].ResourceGroupName $rg.ResourceGroupName

        try
        {
            $removeUnknownOBFR = Remove-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName -AllowedFQDN "testOBFR2"
        }
        catch
        {
            Assert-AreEqual $_.Exception.Message.StartsWith("Allowed FQDN with name 'testOBFR2' does not exist in the list of Outbound Firewall Rules (Allowed FQDNs) for Azure SQL Database server") true
        }

        $finalOBFR = Get-AzSqlServerOutboundFirewallRule -ServerName $serverName -ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $finalOBFR.Count 0

        $retrievedServerAgain = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $retrievedServerAgain.ServerName $server.ServerName
		Assert-AreEqual $retrievedServerAgain.RestrictOutboundNetworkAccess $enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
