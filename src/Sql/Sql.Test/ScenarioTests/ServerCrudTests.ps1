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

<#
	.SYNOPSIS
	Tests creating a server with soft delete retention
#>
function Test-CreateServerWithSoftDeleteRetention
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"

	$serverName1 = Get-ServerName
	$serverName2 = Get-ServerName
	$serverName3 = Get-ServerName
	$serverName4 = Get-ServerName
	$serverName5 = Get-ServerName
	$serverName6 = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$retentionDays = 5

	try
	{
		# Scenario 1: Create server with EnableSoftDelete $true (should default to 7 days)
		$server1 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName1 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -EnableSoftDelete $true
		Assert-AreEqual $server1.ServerName $serverName1
		Assert-AreEqual $server1.ServerVersion $version
		Assert-AreEqual $server1.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName
		Assert-AreEqual $server1.SoftDeleteRetentionDays 7

		# Scenario 2: Create server with EnableSoftDelete $true and SoftDeleteRetentionDays
		$server2 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName2 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -EnableSoftDelete $true -SoftDeleteRetentionDays $retentionDays
		Assert-AreEqual $server2.ServerName $serverName2
		Assert-AreEqual $server2.ServerVersion $version
		Assert-AreEqual $server2.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server2.ServerName + ".") $server2.FullyQualifiedDomainName
		Assert-AreEqual $server2.SoftDeleteRetentionDays $retentionDays

		# Scenario 3: Create server with EnableSoftDelete $false (should have 0 retention days)
		$server3 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName3 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -EnableSoftDelete $false
		Assert-AreEqual $server3.ServerName $serverName3
		Assert-AreEqual $server3.ServerVersion $version
		Assert-AreEqual $server3.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server3.ServerName + ".") $server3.FullyQualifiedDomainName
		Assert-AreEqual $server3.SoftDeleteRetentionDays 0

		# Scenario 4: Create server with EnableSoftDelete $false and SoftDeleteRetentionDays 0
		$server4 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName4 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -EnableSoftDelete $false -SoftDeleteRetentionDays 0
		Assert-AreEqual $server4.ServerName $serverName4
		Assert-AreEqual $server4.ServerVersion $version
		Assert-AreEqual $server4.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server4.ServerName + ".") $server4.FullyQualifiedDomainName
		Assert-AreEqual $server4.SoftDeleteRetentionDays 0

		# Scenario 5: Create server with SoftDeleteRetentionDays 0 (should disable soft-delete)
		$server5 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName5 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays 0
		Assert-AreEqual $server5.ServerName $serverName5
		Assert-AreEqual $server5.ServerVersion $version
		Assert-AreEqual $server5.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server5.ServerName + ".") $server5.FullyQualifiedDomainName
		Assert-AreEqual $server5.SoftDeleteRetentionDays 0

		# Scenario 6: Create server without either parameter (should default to 0 - disabled or -1 until backend fix is deployed)
		$server6 = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName6 `
			-Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials
		Assert-AreEqual $server6.ServerName $serverName6
		Assert-AreEqual $server6.ServerVersion $version
		Assert-AreEqual $server6.SqlAdministratorLogin $serverLogin
		Assert-StartsWith ($server6.ServerName + ".") $server6.FullyQualifiedDomainName
		Assert-True {$server6.SoftDeleteRetentionDays -eq 0 -or $server6.SoftDeleteRetentionDays -eq -1}
	}
	finally
	{
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName1 -SoftDeleteRetentionDays 0
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName2 -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a server soft delete retention
#>
function Test-UpdateServerWithSoftDeleteRetention
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$server = Create-ServerForTest $rg $rg.Location
	$retentionDays1 = 7
	$retentionDays2 = 3
	$retentionDays3 = 5

	try
	{
		# Scenario 1: Update server from default (0) to enable soft-delete with 7 days
		$server1 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays $retentionDays1
		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.ServerVersion $server.ServerVersion
		Assert-AreEqual $server1.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server1.ServerName + ".") $server1.FullyQualifiedDomainName
		Assert-AreEqual $server1.SoftDeleteRetentionDays $retentionDays1

		# Scenario 2: Update server to change retention days from 7 to 3
		$server2 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays $retentionDays2
		Assert-AreEqual $server2.ServerName $server.ServerName
		Assert-AreEqual $server2.ServerVersion $server.ServerVersion
		Assert-AreEqual $server2.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server2.ServerName + ".") $server2.FullyQualifiedDomainName
		Assert-AreEqual $server2.SoftDeleteRetentionDays $retentionDays2

		# Scenario 3: Update server using piping to change retention days from 3 to 5
		$server3 = $server | Set-AzSqlServer -SoftDeleteRetentionDays $retentionDays3
		Assert-AreEqual $server3.ServerName $server.ServerName
		Assert-AreEqual $server3.ServerVersion $server.ServerVersion
		Assert-AreEqual $server3.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server3.ServerName + ".") $server3.FullyQualifiedDomainName
		Assert-AreEqual $server3.SoftDeleteRetentionDays $retentionDays3

		# Scenario 4: Update server to disable soft-delete by setting retention days to 0
		$server4 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays 0
		Assert-AreEqual $server4.ServerName $server.ServerName
		Assert-AreEqual $server4.ServerVersion $server.ServerVersion
		Assert-AreEqual $server4.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server4.ServerName + ".") $server4.FullyQualifiedDomainName
		Assert-AreEqual $server4.SoftDeleteRetentionDays 0

		# Scenario 5: Verify Get-AzSqlServer reflects the disabled state
		$serverGet = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $serverGet.ServerName $server.ServerName
		Assert-AreEqual $serverGet.SoftDeleteRetentionDays 0

		# Scenario 6: Re-enable soft-delete, then update another parameter (password) and verify retention days unchanged
		$server5 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays $retentionDays1
		Assert-AreEqual $server5.SoftDeleteRetentionDays $retentionDays1

		$newPassword = "n3wP@ssw0rd!123"
		$secureString = ConvertTo-SecureString $newPassword -AsPlainText -Force
		$server6 = Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SqlAdministratorPassword $secureString
		Assert-AreEqual $server6.ServerName $server.ServerName
		Assert-AreEqual $server6.ServerVersion $server.ServerVersion
		Assert-AreEqual $server6.SqlAdministratorLogin $server.SqlAdministratorLogin
		Assert-StartsWith ($server6.ServerName + ".") $server6.FullyQualifiedDomainName
		Assert-AreEqual $server6.SoftDeleteRetentionDays $retentionDays1
	}
	finally
	{
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests restoring a deleted server subjected to prior soft delete retention enabled.
#>
function Test-RestoreDeletedServer
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$server = Create-ServerForTest $rg $rg.Location

	try
	{
		# Set SoftDeleteRetentionDays to 7 and delete the server
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays 7
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Force

		# Test with parameters
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Location $rg.Location

		$all = Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 1

	}
	finally
	{
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests attempting to restore a non-existent deleted server (negative scenario)
	.DESCRIPTION
	Negative test
#>
function Test-RestoreNonExistentDeletedServer
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$nonExistentServerName = "nonexistentserver" + (Get-Random -Minimum 10000 -Maximum 99999)

	try
	{
		# Attempt to restore a server that was never deleted - should fail
		Assert-Throws { Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $nonExistentServerName -Location $rg.Location }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests attempting to restore a deleted server with invalid/non-existent resource group (negative scenario)
	.DESCRIPTION
	Negative test
#>
function Test-RestoreDeletedServerInvalidResourceGroup
{
	# Setup
	$rg = Create-ResourceGroupForTest "centralus"
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$softDeleteRetentionDays = 7
	$invalidResourceGroup = "InvalidRG" + (Get-Random -Minimum 10000 -Maximum 99999)

	try
	{
		# Create server with soft delete retention
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays
		Assert-NotNull $server

		# Delete the server (soft delete)
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Attempt to restore with a non-existent resource group - should fail
		Assert-Throws { Restore-AzSqlServer -ResourceGroupName $invalidResourceGroup -ServerName $serverName -Location $rg.Location }
	}
	finally
	{
		# Clean up - restore to correct resource group and then delete
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests attempting to restore a deleted server after the resource group has been removed (negative scenario)
	.DESCRIPTION
	Negative test
#>
function Test-RestoreDeletedServerAfterResourceGroupRemoval
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
		# Create server with soft delete retention
		$server = New-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials -SoftDeleteRetentionDays $softDeleteRetentionDays
		Assert-NotNull $server

		# Delete the server (soft delete)
		Remove-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Force

		# Delete the resource group
		Remove-ResourceGroupForTest $rg

		# Attempt to restore the deleted server to the now-deleted resource group - should fail
		Assert-Throws { Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location }

		# Recreate the same resource group that was deleted
		$rg = New-AzResourceGroup -Name $rg.ResourceGroupName -Location "centralus"
		
		# Restore the server to the recreated resource group
		Restore-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location
	}
	finally
	{
		# Disable soft delete
		Set-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -SoftDeleteRetentionDays 0
		
		# Remove the resource group
		Remove-ResourceGroupForTest $rg
	}
}