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
	Tests getting a server's service objectives
	.DESCRIPTION
	SmokeTest
#>
function Test-GetServerServiceObjective
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$rg | Out-String | Write-Output

	$server = Create-ServerForTest $rg
	$server | Out-String | Write-Output

	$requestedSlo = "GP_Gen5_2"
	$requestedSloFilter = "GP_Gen*_2"

	try
	{
		# Get with positional parameters
		$o = Get-AzSqlServerServiceObjective $rg.ResourceGroupName $server.ServerName
		Assert-AreNotEqual 0 $o.Length "Expected more than 0 service objectives"

		$o = Get-AzSqlServerServiceObjective $rg.ResourceGroupName $server.ServerName $requestedSlo
		Assert-AreEqual 1 $o.Length "Could not find exactly 1 service objective for $requestedSlo"

		# Test filtering
		$o = Get-AzSqlServerServiceObjective -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ServiceObjectiveName $requestedSlo
		Assert-AreEqual 1 $o.Length "Could not find exactly 1 service objective for $requestedSlo"

		$o = Get-AzSqlServerServiceObjective -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ServiceObjectiveName $requestedSloFilter
		Assert-True {$o.Length -ge 2} "Expected 2 or more service objectives for $requestedSloFilter, actual $($o.Length)"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting a server's service objectives
	.DESCRIPTION
	SmokeTest
#>
function Test-GetServerServiceObjectiveByLocation
{
	# Setup
	$location = "Japan East"
	$requestedSlo = "GP_Gen5_2"
	$requestedSloFilter = "GP_Gen*_2"

	# Get all
	$o = Get-AzSqlServerServiceObjective -Location $location
	Assert-AreNotEqual 0 $o.Length "Expected more than 0 service objectives"

	# Test filtering
	$o = Get-AzSqlServerServiceObjective -Location $location -ServiceObjectiveName $requestedSlo
	Assert-AreEqual 1 $o.Length "Could not find exactly 1 service objective for $requestedSlo"

	$o = Get-AzSqlServerServiceObjective -Location $location -ServiceObjectiveName $requestedSloFilter
	Assert-True {$o.Length -ge 2} "Expected 2 or more service objectives for $requestedSloFilter, actual $($o.Length)"
}
