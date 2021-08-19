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

	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$tableNameExisting = "dabenhamDev_CL"
	$retention = 99

	try
	{
		# get Table
		$table = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $tableNameExisting

		Assert-NotNull $table
		Assert-AreEqual $tableNameExisting $table.Name

		# update table, change retention and validate the change
		$updatedTable = Set-AzOperationalInsightsTable  -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $tableNameExisting -RetentionInDays $retention
		Assert-AreEqual $tableNameExisting $table.Name
		Assert-AreEqual $retention $table.RetentionInDays
	}
	finally
	{
		# Cleanup
        Clean-ResourceGroup $rgName
	}
	
}