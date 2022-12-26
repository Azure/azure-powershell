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
	Tests creating an IPv6 Firewall rule
#>
function Test-CreateIpv6FirewallRule
{
	# Setup
	$location = "South Central US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$startIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"
	$endIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"

	try
	{
		$newIPv6FR = New-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR" -StartIpv6Address $startIpv6Address -EndIpv6Address $endIpv6Address
		Assert-AreEqual $newIPv6FR.Count 1
		Assert-AreEqual $newIPv6FR.ServerName $server.ServerName
		Assert-AreEqual $newIPv6FR.Ipv6FirewallRuleName "testIpv6FR"

	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting IPv6 Firewall rules
#>
function Test-GetIpv6FirewallRule
{
	# Setup
	$location = "South Central US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$startIpv6Address1 = "0229:e3a4:e0d7:36d3:d228:73fa:12fc:ae30"
	$endIpv6Address1 = "0229:e3a4:e0d7:36d3:d228:73fa:12fc:ae30"
	$startIpv6Address2 = "8798:d2cb:efea:2d56:0d4a:41fb:c61d:e532"
	$endIpv6Address2 = "8798:d2cb:efea:2d56:0d4a:41fb:c61d:e532"

	try
	{
		# Create IPv6 Firewall rule 1 
		$newIPv6FR1 = New-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR1" -StartIpv6Address $startIpv6Address1 -EndIpv6Address $endIpv6Address1
		Assert-AreEqual $newIPv6FR1.ServerName $server.ServerName
		Assert-AreEqual $newIPv6FR1.Ipv6FirewallRuleName "testIpv6FR1"

		# Create IPv6 Firewall rule 2
		$newIPv6FR2 = New-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR2" -StartIpv6Address $startIpv6Address2 -EndIpv6Address $endIpv6Address2
		Assert-AreEqual $newIPv6FR2.ServerName $server.ServerName
		Assert-AreEqual $newIPv6FR2.Ipv6FirewallRuleName "testIpv6FR2"

		# Get IPv6 Firewall rule 1 
		$getIpv6FR = Get-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR1"
		Assert-AreEqual $getIpv6FR.ServerName $server.ServerName
		Assert-AreEqual $getIpv6FR.Ipv6FirewallRuleName "testIpv6FR1"
		Assert-AreEqual $getIpv6FR.StartIpv6Address $startIpv6Address1
		Assert-AreEqual $getIpv6FR.EndIpv6Address $endIpv6Address1

		# Get list of Firewall rules
		$getIpv6FRList = Get-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $getIpv6FRList[0].ServerName $server.ServerName
		Assert-AreEqual $getIpv6FRList[0].Ipv6FirewallRuleName "testIpv6FR1"
		Assert-AreEqual $getIpv6FRList[1].ServerName $server.ServerName
		Assert-AreEqual $getIpv6FRList[1].Ipv6FirewallRuleName "testIpv6FR2"

        try
        {
            $getUnknownFR = Get-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testUnknowFR"
        }
        catch
        {
            Assert-AreEqual $_.Exception.Message "The requested resource of type 'Microsoft.Sql/servers/ipv6FirewallRules' with name 'testUnknowFR' was not found."
        }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests removing IPv6 Firewall rule
#>
function Test-RemoveIpv6FirewallRule
{
	# Setup
	$location = "South Central US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$startIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"
	$endIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"

	try
	{
		# Create an IPv6 Firewall rule
	    $newIPv6FR = New-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR" -StartIpv6Address $startIpv6Address -EndIpv6Address $endIpv6Address
		Assert-AreEqual $newIPv6FR.ServerName $server.ServerName
		Assert-AreEqual $newIPv6FR.Ipv6FirewallRuleName "testIpv6FR"
		
		# Remove the IPv6 Firewall rule
		$removeIPv6FR = Remove-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR"
        try
        {
			$result = Get-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR"
        }
        catch
        {
            Assert-AreEqual $_.Exception.Message "The requested resource of type 'Microsoft.Sql/servers/ipv6FirewallRules' with name 'testIpv6FR' was not found."
        }

		try
		{
			$removeUnknowFR = Remove-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testIpv6FR"
		}
		catch
		{
            Assert-AreEqual $_.Exception.Message "The requested resource of type 'Microsoft.Sql/servers/ipv6FirewallRules' with name 'testIpv6FR' was not found."
		}
	}

	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating IPv6 Firewall rule
#>
function Test-UpdateIpv6FirewallRule
{
	# Setup
	$location = "South Central US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$startIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"
	$endIpv6Address = "9a41:a145:2a80:6c8d:4628:a1b3:5812:3283"
	$startIpv6Address1 = "0229:e3a4:e0d7:36d3:d228:73fa:12fc:ae30"
	$endIpv6Address1 = "0229:e3a4:e0d7:36d3:d228:73fa:12fc:ae30"

	try
	{
		# Create an IPv6 Firewall rule
	    $newIPv6FR = New-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testSetIpv6FR" -StartIpv6Address $startIpv6Address -EndIpv6Address $endIpv6Address
		Assert-AreEqual $newIPv6FR.ServerName $server.ServerName
		Assert-AreEqual $newIPv6FR.Ipv6FirewallRuleName "testSetIpv6FR"
		
		# Update the IPv6 Firewall rule
		$updateIPv6FR = Set-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testSetIpv6FR" -StartIpv6Address $startIpv6Address1 -EndIpv6Address $endIpv6Address1
		Assert-AreEqual $updateIPv6FR.ServerName $server.ServerName
		Assert-AreEqual $updateIPv6FR.Ipv6FirewallRuleName "testSetIpv6FR"
		Assert-AreEqual $updateIPv6FR.StartIpv6Address $startIpv6Address1
		Assert-AreEqual $updateIPv6FR.EndIpv6Address $endIpv6Address1

		# Update an unknow IPv6 Firewall rule
		try
		{
			$updateUnknowIPv6FR = Set-AzSqlServerIpv6FirewallRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -Ipv6FirewallRuleName "testSetUnknowIpv6FR" -StartIpv6Address $startIpv6Address -EndIpv6Address $endIpv6Address
		}
		catch
		{
            Assert-AreEqual $_.Exception.Message "The requested resource of type 'Microsoft.Sql/servers/ipv6FirewallRules' with name 'testSetUnknowIpv6FR' was not found."
		}
	}

	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}





