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

function Handle-FailoverGroupTest($scriptBlock, $primaryLocation = "North Europe", $secondaryLocation = "East US", $serverVersion = "12.0", $rg = $null, $server1 = $null, $server2 = $null, $cleanup = $false)
{
	try
	{
		$isCreated = $rg -eq $null

		$rg = if ($rg -eq $null) { Create-ResourceGroupForTest } else { $rg }
		$server1 = if ($server1 -eq $null) { Create-ServerForTest $rg $primaryLocation } else { $server1 }
		$server2 = if ($server2 -eq $null) { Create-ServerForTest $rg $secondaryLocation } else { $server2 }

		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $server1,$server2
	}
	finally
	{
		if ($isCreated -and $cleanup)
		{
			Remove-ResourceGroupForTest $rg
		}
	}
}

function Handle-FailoverGroupTestWithFailoverGroup($scriptBlock, $failoverPolicy = "Automatic")
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerServerName $partnerServer.ServerName -FailoverPolicy $failoverPolicy
		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $fg
		
	}.GetNewClosure()
}

function Validate-FailoverGroup($server, $partnerServer, $name, $role, $failoverPolicy, $gracePeriod, $readOnlyFailoverPolicy, $databases, $fg, $message="no context provided", $isMultiServer = $false, $partnerServersList = $null)
{
	Assert-NotNull $fg.Id "`$fg.Id ($message)"
	Assert-NotNull $fg.PartnerServers "`$fg.PartnerServers ($message)"
	Assert-AreEqual $name $fg.FailoverGroupName "`$fg.FailoverGroupName ($message)"
	# Assert-AreEqual $true $partnerServer.ResourceId.Contains($fg.PartnerSubscriptionId) "`$fg.PartnerSubscriptionId ($message)"
	if ($isMultiServer) 
	{
		foreach ($server in $partnerServersList)
		{
			Assert-AreEqual $true $fg.PartnerServers.Contains($server) "`$fg.PartnerServers[$($server)] ($message)"
		}
	}
	else 
	{
		Assert-AreEqual $server.ResourceGroupName $fg.ResourceGroupName "`$fg.ResourceGroupName ($message)"
		Assert-AreEqual $partnerServer.ResourceGroupName $fg.PartnerResourceGroupName "`$fg.PartnerResourceGroupName ($message)"
		Assert-AreEqual $server.ServerName $fg.ServerName "`$fg.ServerName ($message)"
		Assert-AreEqual $partnerServer.ServerName $fg.PartnerServerName "`$fg.PartnerServerName ($message)"
	}
	# Commented out because server location is a location id, but FG location is a location friendly name
	# Assert-AreEqual $server.Location $fg.Location "`$fg.Location ($message)"
	# Assert-AreEqual $partnerServer.Location $fg.PartnerLocation "`$fg.PartnerLocation ($message)"
	Assert-AreEqual $role $fg.ReplicationRole "`$fg.ReplicationRole ($message)"
	Assert-AreEqual $failoverPolicy $fg.ReadWriteFailoverPolicy "`$fg.FailoverPolicy ($message)"
	Assert-AreEqual $gracePeriod $fg.FailoverWithDataLossGracePeriodHours "`$fg.FailoverWithGraceperiodHours ($message)"
	Assert-AreEqual $readOnlyFailoverPolicy $fg.ReadOnlyFailoverPolicy "`$fg.ReadOnlyFailoverPolicy ($message)"
	Assert-AreEqual $databases.Count $fg.DatabaseNames.Count "`$fg.DatabaseNames.Count ($message)"
	Assert-AreEqual $databases.Count $fg.Databases.Count "`$fg.Databases.Count ($message)"
	Assert-AreEqual $true @('CATCH_UP', 'SUSPENDED', 'SEEDING').Contains($fg.ReplicationState) "`$fg.ReplicationState ($message)"

	foreach ($db in $databases)
	{
		Assert-AreEqual $true $fg.DatabaseNames.Contains($db.DatabaseName) "`$fg.DatabaseNames[$($db.DatabaseName)] ($message)"
	}
}

function Assert-FailoverGroupsEqual($expected, $actual, $swapRoles = $false, $role = $null, $failoverPolicy = $null, $gracePeriod = $null, $readOnlyFailoverPolicy = $null, $databases = $null, $message = "no context provided")
{
	$server = @{ 'ServerName' = $expected.ServerName; 'Location' = $expected.Location; 'ResourceGroupName' = $expected.ResourceGroupName }
	$partnerServer = @{ 'ServerName' = $expected.PartnerServerName; 'Location' = $expected.PartnerLocation; 'ResourceGroupName' = $expected.ResourceGroupName }
	$failoverPolicy = if ($failoverPolicy -eq $null) { $expected.ReadWriteFailoverPolicy } else { $failoverPolicy }
	$gracePeriod = if ($gracePeriod -eq $null -and $failoverPolicy -ne "Manual") { $expected.FailoverWithDataLossGracePeriodHours } else { $gracePeriod }
	$readOnlyFailoverPolicy = if ($readOnlyFailoverPolicy -eq $null) { $expected.ReadOnlyFailoverPolicy } else { $readOnlyFailoverPolicy }
	$databases = if ($databases -eq $null) { $expected.Databases | % { @{ 'DatabaseName' = $_.Split('/')[-1] } } } else { $databases }
	$role = if ($role -eq $null) { $expected.ReplicationRole } else { $role }

	if ($swapRoles)
	{
		$tmp = $partnerServer
		$partnerServer = $server
		$server = $tmp
		$role = if ($role -eq "Primary") { "Secondary" } else { "Primary" }
	}

	Validate-FailoverGroup `
		$server `
		$partnerServer `
		$expected.FailoverGroupName `
		$role `
		$failoverPolicy `
		$gracePeriod `
		$readOnlyFailoverPolicy `
		$databases `
		$actual `
		$message
}

function Validate-FailoverGroupWithGet($fg, $message = "no context provided")
{
	$actual = $fg | Get-AzSqlDatabaseFailoverGroup
	Assert-FailoverGroupsEqual $fg $actual -message $message

	$actual = Get-AzSqlDatabaseFailoverGroup $fg.PartnerResourceGroupName $fg.PartnerServerName $fg.FailoverGroupName
	Assert-FailoverGroupsEqual $fg $actual -swapRoles $true -message $message
}

<#
	.SYNOPSIS
	Tests create and update a failover group
#>

function Test-FailoverGroup()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		# Create with default values
		$fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseFailoverGroup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -PartnerServerName $partnerServer.ServerName -FailoverGroupName $fgName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1 -AllowReadOnlyFailoverToPrimary Enabled
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Enabled @() $fg

		# Alter all properties
		$fg2 = Set-AzSqlDatabaseFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName  -FailoverPolicy Manual -AllowReadOnlyFailoverToPrimary Disabled
		Validate-FailoverGroup $server $partnerServer $fgName Primary Manual $null Disabled @() $fg2

		#Alter again but piping in the server object
		$serverObject = Get-AzSqlServer -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
		$fg3 = $serverObject | Set-AzSqlDatabaseFailoverGroup –ResourceGroupName $server.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName -FailoverPolicy Automatic
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Disabled @() $fg3

		#Get Failover Group
		Validate-FailoverGroupWithGet $fg3

		#Get Failover Group
		$fgs = $serverObject | Get-AzSqlDatabaseFailoverGroup –ResourceGroupName $server.ResourceGroupName -FailoverGroupName *
		Assert-AreEqual 1 ($fgs | where { $_.FailoverGroupName.Equals($fg.FailoverGroupName) }).Count

		#Remove Failover Group
		Remove-AzSqlDatabaseFailoverGroup -ServerName $server.ServerName -ResourceGroupName $server.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName
		$all = $server | Get-AzSqlDatabaseFailoverGroup –ResourceGroupName $server.ResourceGroupName
		Assert-AreEqual 0 ($all | where { $_.FailoverGroupName.Equals($fg.FailoverGroupName) }).Count
	}
}

function Test-CreateFailoverGroup-Named()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseFailoverGroup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -FailoverGroupName $fgName -PartnerServerName $partnerServer.ServerName -PartnerResourceGroupName $partnerServer.ResourceGroupName
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-Positional()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseFailoverGroup $server.ResourceGroupName $server.ServerName -FailoverGroupName $fgName -PartnerServerName $partnerServer.ServerName 
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-AutomaticPolicy()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Automatic
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerResourceGroupName $partnerServer.ResourceGroupName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 123 Enabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-ZeroGracePeriod()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerResourceGroupName $partnerServer.ResourceGroupName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 0 -AllowReadOnlyFailoverToPrimary Disabled
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic 1 Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-ManualPolicy()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerResourceGroupName $partnerServer.ResourceGroupName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Manual
		Validate-FailoverGroup $server $partnerServer $fgName Primary Manual $null Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-Overflow()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$expectedGracePeriod = [math]::floor([int]::MaxValue / 60)
		$gracePeriodToSet = $expectedGracePeriod + 1

		$fgName = Get-FailoverGroupName
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerResourceGroupName $partnerServer.ResourceGroupName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Automatic -GracePeriodWithDataLossHours $gracePeriodToSet
		Validate-FailoverGroup $server $partnerServer $fgName Primary Automatic $expectedGracePeriod Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-CreateFailoverGroup-CrossSubscription()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$fgName = Get-FailoverGroupName
		$partnerSubscriptionId = $partnerServer.ResourceId.Split('/')[2]
		$fg = $server | New-AzSqlDatabaseFailoverGroup -FailoverGroupName $fgName -PartnerSubscriptionId $partnerSubscriptionId -PartnerResourceGroupName $partnerServer.ResourceGroupName -PartnerServerName $partnerServer.ServerName -FailoverPolicy Manual
		Validate-FailoverGroup $server $partnerServer $fgName Primary Manual $null Disabled @() $fg
		Validate-FailoverGroupWithGet $fg
	}
}

function Test-SetFailoverGroup-Named()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = Set-AzSqlDatabaseFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName
		Assert-FailoverGroupsEqual $fg $newFg
		Validate-FailoverGroupWithGet $newFg
	}
}

function Test-SetFailoverGroup-Positional()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = Set-AzSqlDatabaseFailoverGroup $fg.ResourceGroupName $fg.ServerName $fg.FailoverGroupName
		Assert-FailoverGroupsEqual $fg $newFg
		Validate-FailoverGroupWithGet $newFg
	}
}

function Test-SetFailoverGroup-PipeServer()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = Get-AzSqlServer $fg.ResourceGroupName $fg.ServerName | Set-AzSqlDatabaseFailoverGroup -FailoverGroupName $fg.FailoverGroupName
		Assert-FailoverGroupsEqual $fg $newFg
		Validate-FailoverGroupWithGet $newFg
	}
}

function Test-SetFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseFailoverGroup -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Assert-FailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 123 -readOnlyFailoverPolicy Enabled
		Validate-FailoverGroupWithGet $newFg
	} -failoverPolicy Manual
}

function Test-SetFailoverGroup-AutomaticWithGracePeriodZero()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseFailoverGroup -FailoverPolicy Automatic -GracePeriodWithDataLossHours 0 -AllowReadOnlyFailoverToPrimary Disabled
		Assert-FailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 1 -readOnlyFailoverPolicy Disabled
		Validate-FailoverGroupWithGet $newFg
	} -failoverPolicy Manual
}

function Test-SetFailoverGroup-AutomaticToManual()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseFailoverGroup -FailoverPolicy Manual
		Assert-FailoverGroupsEqual $fg $newFg -failoverPolicy Manual -gracePeriod $null
		Validate-FailoverGroupWithGet $newFg
	}
}

function Test-SetFailoverGroup-ManualToAutomaticNoGracePeriod()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseFailoverGroup -FailoverPolicy Automatic
		Assert-FailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 1
		Validate-FailoverGroupWithGet $newFg
	} -failoverPolicy Manual
}

function Test-SetFailoverGroup-Overflow()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$expectedGracePeriod = [math]::floor([int]::MaxValue / 60)
		$gracePeriodToSet = $expectedGracePeriod + 1

		$newFg = $fg | Set-AzSqlDatabaseFailoverGroup -GracePeriodWithDataLossHours $gracePeriodToSet
		Assert-FailoverGroupsEqual $fg $newFg -gracePeriod $expectedGracePeriod
		Validate-FailoverGroupWithGet $newFg
	} -failoverPolicy Automatic
}

function Test-AddRemoveDatabasesToFromFailoverGroup()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$db1 = New-AzSqlDatabase $fg.ResourceGroupName $fg.ServerName -DatabaseName (Get-DatabaseName)

		$newFg = $fg | Add-AzSqlDatabaseToFailoverGroup -Database $db1
		Assert-FailoverGroupsEqual $fg $newFg -databases @($db1) -message "after adding db1"
		Validate-FailoverGroupWithGet $newFg -message "get after adding db1"

		$newFg = $fg | Remove-AzSqlDatabaseFromFailoverGroup -Database $db1
		Assert-FailoverGroupsEqual $fg $newFg -databases @() -message "after removing db1"
		Validate-FailoverGroupWithGet $newFg -message "get after removing db1"

		$db2 = New-AzSqlDatabase $fg.ResourceGroupName $fg.ServerName -DatabaseName (Get-DatabaseName)

		$newFg = Add-AzSqlDatabaseToFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName -Database @($db1, $db2)
		Assert-FailoverGroupsEqual $fg $newFg -databases @($db1, $db2) -message "after adding both dbs"
		Validate-FailoverGroupWithGet $newFg -message "get after adding both dbs"

		$newFg = Remove-AzSqlDatabaseFromFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName -Database @($db1, $db2)
		Assert-FailoverGroupsEqual $fg $newFg -databases @() -message "after removing both dbs"
		Validate-FailoverGroupWithGet $newFg -message "get after removing both dbs"

		$newFg = $db1 | Add-AzSqlDatabaseToFailoverGroup $fg.ResourceGroupName $fg.ServerName $fg.FailoverGroupName
		Assert-FailoverGroupsEqual $fg $newFg -databases @($db1) -message "after adding db1 by pipeline"
		Validate-FailoverGroupWithGet $newFg -message "get after adding db1 by pipeline"

		$newFg = $db1 | Remove-AzSqlDatabaseFromFailoverGroup $fg.ResourceGroupName $fg.ServerName $fg.FailoverGroupName
		Assert-FailoverGroupsEqual $fg $newFg -databases @() -message "after removing db1 by pipeline"
		Validate-FailoverGroupWithGet $newFg -message "get after removing db1 by pipeline"
	}
}

function Test-SwitchFailoverGroup()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$foGroup = Get-AzSqlDatabaseFailoverGroup $fg.PartnerResourceGroupName $fg.PartnerServerName $fg.FailoverGroupName 
		$job = $foGroup | Switch-AzSqlDatabaseFailoverGroup -AsJob
		$job | Wait-Job

		$newSecondaryFg = $fg | Get-AzSqlDatabaseFailoverGroup
		Assert-FailoverGroupsEqual $fg $newSecondaryFg -role "Secondary"
		Validate-FailoverGroupWithGet $newSecondaryFg
	}
}

function Test-SwitchFailoverGroupAllowDataLoss()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		Switch-AzSqlDatabaseFailoverGroup $fg.PartnerResourceGroupName $fg.PartnerServerName $fg.FailoverGroupName -AllowDataLoss
		$newSecondaryFg = $fg | Get-AzSqlDatabaseFailoverGroup
		Assert-FailoverGroupsEqual $fg $newSecondaryFg -role "Secondary"
		Validate-FailoverGroupWithGet $newSecondaryFg
	}
}

function Test-SwitchFailoverGroupTryPlannedBeforeForcedFailover()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$foGroup = Get-AzSqlDatabaseFailoverGroup $fg.PartnerResourceGroupName $fg.PartnerServerName $fg.FailoverGroupName
		$job = $foGroup | Switch-AzSqlDatabaseFailoverGroup -TryPlannedBeforeForcedFailover -AsJob
		$job | Wait-Job

		$newSecondaryFg = $fg | Get-AzSqlDatabaseFailoverGroup
		Assert-FailoverGroupsEqual $fg $newSecondaryFg -role "Secondary"
		Validate-FailoverGroupWithGet $newSecondaryFg
	}
}

function Test-FailoverGroupMultipleSecondaries()
{
	Handle-FailoverGroupTest {
		Param($server, $partnerServer)

		$primaryRegion = "UK South"
		$primaryRg = Create-ResourceGroupForTest
		$primaryServer = Create-ServerForTest $primaryRg $primaryRegion

		$partnerServers = $server.ResourceId, $partnerServer.ResourceId

		$fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseFailoverGroup -ResourceGroupName $primaryServer.ResourceGroupName -ServerName $primaryServer.ServerName -PartnerServerName $partnerServer.ServerName -FailoverGroupName $fgName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1 -AllowReadOnlyFailoverToPrimary Enabled -PartnerServerList $partnerServers -ReadOnlyEndpointTargetServer $partnerServer.ResourceId
		Validate-FailoverGroup $primaryServer $server $fgName Primary Automatic 1 Enabled @() $fg -isMultiServer $true -PartnerServerList $partnerServers
	}
}

function Test-AddRemoveDatabasesToFromFailoverGroupWithStandby()
{
	Handle-FailoverGroupTestWithFailoverGroup {
		Param($fg)

		$db1 = New-AzSqlDatabase $fg.ResourceGroupName $fg.ServerName -DatabaseName (Get-DatabaseName)

		$newFg = $fg | Add-AzSqlDatabaseToFailoverGroup -Database $db1 -SecondaryType "Standby"
		Assert-FailoverGroupsEqual $fg $newFg -databases @($db1) -message "after adding db1"
		Validate-FailoverGroupWithGet $newFg -message "get after adding db1"

		$newFg = $fg | Remove-AzSqlDatabaseFromFailoverGroup -Database $db1
		Assert-FailoverGroupsEqual $fg $newFg -databases @() -message "after removing db1"
		Validate-FailoverGroupWithGet $newFg -message "get after removing db1"

		$db2 = New-AzSqlDatabase $fg.ResourceGroupName $fg.ServerName -DatabaseName (Get-DatabaseName)

		$newFg = Add-AzSqlDatabaseToFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName -Database @($db1, $db2) -SecondaryType "Standby"
		Assert-FailoverGroupsEqual $fg $newFg -databases @($db1, $db2) -message "after adding both dbs"
		Validate-FailoverGroupWithGet $newFg -message "get after adding both dbs"

		$newFg = Remove-AzSqlDatabaseFromFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName -Database @($db1, $db2)
		Assert-FailoverGroupsEqual $fg $newFg -databases @() -message "after removing both dbs"
		Validate-FailoverGroupWithGet $newFg -message "get after removing both dbs"
	}
}