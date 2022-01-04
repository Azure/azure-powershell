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
Test Table CRUD
#>
function Test-TableCRUD
{
	# setup
	$rgName = Get-ResourceGroupName
	$workspaceName = Get-ResourceName
	$loc = Get-ProviderLocation
	$tableNotFound = Get-ResourceName
	$initialRetention = 60
	$updattedRetention = 61

	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$tableNameExisting = "dabenhamDev_CL"


	try
	{
		# create new RG for the test
		New-AzResourceGroup -Name $rgname -Location $loc

		# create new WS for the test
		$workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $workspaceName -Location $loc

		# get all existing tables
		$allTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $workspaceName
		Assert-NotNull $allTable
		Assert-True {$allTable.Count -gt 0}
		
		# get table that does not exist 
		Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $workspaceName -tableName $tableNotFound} 'NotFound'

		# remove new WS that was used for the test
		Remove-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $workspaceName -force
	}
	finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname 
	}
	
}