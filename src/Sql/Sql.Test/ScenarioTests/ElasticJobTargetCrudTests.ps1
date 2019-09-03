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
	Tests adding all target types to a target group
#>
function Test-AddTarget
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		# Add server target
		Test-AddServerTargetWithDefaultParam $a1
		Test-AddServerTargetWithParentObject $a1
		Test-AddServerTargetWithParentResourceId $a1
		Test-AddServerTargetWithPiping $a1

		# Add database target
		Test-AddDatabaseTargetWithDefaultParam $a1
		Test-AddDatabaseTargetWithParentObject $a1
		Test-AddDatabaseTargetWithParentResourceId $a1
		Test-AddDatabaseTargetWithPiping $a1

		# Add elastic pool target
		Test-AddElasticPoolTargetWithDefaultParam $a1
		Test-AddElasticPoolTargetWithParentObject $a1
		Test-AddElasticPoolTargetWithParentResourceId $a1
		Test-AddElasticPoolTargetWithPiping $a1

		# Add shard map target
		Test-AddShardMapTargetWithDefaultParam $a1
		Test-AddShardMapTargetWithParentObject $a1
		Test-AddShardMapTargetWithParentResourceId $a1
		Test-AddShardMapTargetWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests removing all target types from a target group
#>
function Test-RemoveTarget
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		# Remove server target
		Test-RemoveServerTargetWithDefaultParam $a1
		Test-RemoveServerTargetWithParentObject $a1
		Test-RemoveServerTargetWithParentResourceId $a1
		Test-RemoveServerTargetWithPiping $a1

		# Remove database target
		Test-RemoveDatabaseTargetWithDefaultParam $a1
		Test-RemoveDatabaseTargetWithParentObject $a1
		Test-RemoveDatabaseTargetWithParentResourceId $a1
		Test-RemoveDatabaseTargetWithPiping $a1

		# Remove elastic pool target
		Test-RemoveElasticPoolTargetWithDefaultParam $a1
		Test-RemoveElasticPoolTargetWithParentObject $a1
		Test-RemoveElasticPoolTargetWithParentResourceId $a1
		Test-RemoveElasticPoolTargetWithPiping $a1

		# Remove shard map target
		Test-RemoveShardMapTargetWithDefaultParam $a1
		Test-RemoveShardMapTargetWithParentObject $a1
		Test-RemoveShardMapTargetWithParentResourceId $a1
		Test-RemoveShardMapTargetWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests adding server targets to target group
#>
function Test-AddServerTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Include targetServer
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetServer - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"
}

<#
	.SYNOPSIS
	Tests adding server targets to target group using target group object
#>
function Test-AddServerTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Include targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetServer - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"
}

<#
	.SYNOPSIS
	Tests adding server targets to target group using target group resource id
#>
function Test-AddServerTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Include targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetServer - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"
}

<#
	.SYNOPSIS
	Tests adding server targets to target group with piping
#>
function Test-AddServerTargetWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Include targetServer
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Exclude targetServer again - no errors and no resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetServer - no errors and resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Add all server targets in resource group
	$allServers = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName
	$resp = $allServers | Add-AzSqlElasticJobTarget -ParentObject $tg1 -RefreshCredentialName $jc1.CredentialName
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests removing server targets to target group using default param
#>
function Test-RemoveServerTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName

	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName	$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing server targets to target group using target group object
#>
function Test-RemoveServerTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing server targets to target group using target group resource id
#>
function Test-RemoveServerTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName -Exclude

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing server targets to target group with piping
#>
function Test-RemoveServerTargetWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $a1.ServerName -RefreshCredentialName $jc1.CredentialName # Add agent server

	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlServer"

	# Try remove again - should have no resp
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp

	# Try remove all server targets in resource group
	$allServers = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName
	$resp = $allServers | Remove-AzSqlElasticJobTarget -ParentObject $tg1 -RefreshCredentialName $jc1.CredentialName
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests adding database targets to target group using default param
#>
function Test-AddDatabaseTargetWithDefaultParam ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Include targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-DatabaseName $targetDatabaseName1 -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-DatabaseName $targetDatabaseName1 -Exclude
	Assert-Null $resp

	# Include targetDatabaseName - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"
}

<#
	.SYNOPSIS
	Tests adding database targets to target group using target group object
#>
function Test-AddDatabaseTargetWithParentObject ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Include targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-Null $resp

	# Include targetDatabaseName - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"
}

<#
	.SYNOPSIS
	Tests adding database targets to target group using target group resource id
#>
function Test-AddDatabaseTargetWithParentResourceId ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Include targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-Null $resp

	# Include targetDatabaseName - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"
}

<#
	.SYNOPSIS
	Tests adding database targets to target group with piping
#>
function Test-AddDatabaseTargetWithPiping ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Include targetDatabaseName
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Exclude targetDatabaseName again - no errors and no resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1 -Exclude
	Assert-Null $resp

	# Include targetDatabaseName - no errors and resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Add all dbs
	$allDbs = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzSqlDatabase
	$resp = $allDbs | Add-AzSqlElasticJobTarget -ParentObject $tg1
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests removing database target to target group using default param
#>
function Test-RemoveDatabaseTargetWithDefaultParam ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1

	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName	$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing database target to target group using target group object
#>
function Test-RemoveDatabaseTargetWithParentObject ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1

	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing database target to target group using target group resource id
#>
function Test-RemoveDatabaseTargetWithParentResourceId ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1

	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing database target to target group with piping
#>
function Test-RemoveDatabaseTargetWithPiping ($a1)
{
	# Setup
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
	$targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName

	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlDatabase"

	# Try remove again - should have no resp
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -DatabaseName $targetDatabaseName1
	Assert-Null $resp

  # Remove all dbs in group - should only have a1.ServerName and a1.DatabaseName
	$allDbs = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzSqlDatabase
	$resp = $allDbs | Remove-AzSqlElasticJobTarget -ParentObject $tg1
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests adding elastic pool target to target group
#>
function Test-AddElasticPoolTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Include targetElasticPool
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetElasticPool
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetElasticPool again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetElasticPool - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"
}

<#
	.SYNOPSIS
	Tests adding elastic pool target to target group using target group object
#>
function Test-AddElasticPoolTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Include targetElasticPool
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetElasticPool - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"
}

<#
	.SYNOPSIS
	Tests adding elastic pool target to target group using target group resource id
#>
function Test-AddElasticPoolTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Include targetElasticPool
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetElasticPool - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"
}

<#
	.SYNOPSIS
	Tests adding elastic pool target to target group with piping
#>
function Test-AddElasticPoolTargetWithPiping ($a1)
{
	# Setup
	$ep1 = Create-ElasticPoolForTest $a1 # create pool on agent's server
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Include targetElasticPool
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Exclude targetServer again - no errors and no resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetElasticPool - no errors and resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Add all pools
	$allEps = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzSqlElasticPool
	$resp = $allEps | Add-AzSqlElasticJobTarget -ParentObject $tg1 -RefreshCredentialName $jc1.CredentialName
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests removing elastic pool target to target group using default param
#>
function Test-RemoveElasticPoolTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName

	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName	$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing elastic pool target to target group using target group object
#>
function Test-RemoveElasticPoolTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing elastic pool target to target group using target group resource id
#>
function Test-RemoveElasticPoolTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName -Exclude

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing elastic pool target to target group with piping
#>
function Test-RemoveElasticPoolTargetWithPiping ($a1)
{
	# Setup
	$ep1 = Create-ElasticPoolForTest $a1
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetElasticPoolName1 = Get-ElasticPoolName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $ep1.ServerName -ElasticPoolName $ep1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

	# Remove s2
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetElasticPoolName $targetElasticPoolName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlElasticPool"

	# Try remove again - should have no resp
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -ElasticPoolName $targetElasticPoolName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp

	# Remove all pools
	$allEps = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzSqlElasticPool
	$resp = $allEps | Remove-AzSqlElasticJobTarget -ParentObject $tg1 -RefreshCredentialName $jc1.CredentialName
	Assert-NotNull $resp
}

<#
	.SYNOPSIS
	Tests adding shard map target to target group
#>
function Test-AddShardMapTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Include targetShardMap
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetShardMap
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetShardMap again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetShardMap - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName `
		$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 `
		-ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"
}

<#
	.SYNOPSIS
	Tests adding shard map target to target group using target group object
#>
function Test-AddShardMapTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Include targetShardMap
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetShardMap - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"
}

<#
	.SYNOPSIS
	Tests adding shard map target to target group using target group resource id
#>
function Test-AddShardMapTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Include targetShardMap
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer again - no errors and no resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetShardMap - no errors and resp
	$resp = Add-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"
}

<#
	.SYNOPSIS
	Tests adding shard map target to target group with piping
#>
function Test-AddShardMapTargetWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Include targetShardMap
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Exclude targetServer again - no errors and no resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude
	Assert-Null $resp

	# Include targetShardMap - no errors and resp
	$resp = $tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"
}

<#
	.SYNOPSIS
	Tests removing shard map target to target group using default param
#>
function Test-RemoveShardMapTargetWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName

	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName	$a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing shard map target to target group using target group object
#>
function Test-RemoveShardMapTargetWithParentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentObject $tg1 -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing shard map target to target group using target group resource id
#>
function Test-RemoveShardMapTargetWithParentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName -Exclude

	# Remove s2
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Exclude"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Try remove again - should have no resp
	$resp = Remove-AzSqlElasticJobTarget -ParentResourceId $tg1.ResourceId -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}

<#
	.SYNOPSIS
	Tests removing shard map target to target group with piping
#>
function Test-RemoveShardMapTargetWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$targetServerName1 = Get-ServerName
  $targetShardMapName1 = Get-ShardMapName
  $targetDatabaseName1 = Get-DatabaseName

	# Add targets
	$tg1 | Add-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName

	# Remove s2
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.TargetServerName $targetServerName1
	Assert-AreEqual $resp.TargetShardMapName $targetShardMapName1
	Assert-AreEqual $resp.TargetDatabaseName $targetDatabaseName1
	Assert-AreEqual $resp.RefreshCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.MembershipType "Include"
	Assert-AreEqual $resp.TargetType "SqlShardMap"

	# Try remove again - should have no resp
	$resp = $tg1 | Remove-AzSqlElasticJobTarget -ServerName $targetServerName1 -ShardMapName $targetShardMapName1 -DatabaseName $targetDatabaseName1 -RefreshCredentialName $jc1.CredentialName
	Assert-Null $resp
}