# ----------------------------------------------------------------------------------
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
Test List all tables for a given WS and get table on a table that does not exist
#>
function Test-TableCRUD
{
	# setup
	$tableNotFound = Get-ResourceName
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$tableNameExisting = "dabenhamDev_CL"

	try
	{
		# get all existing tables
		$allTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $workspaceName
		Assert-NotNull $allTable
		Assert-True {$allTable.Count -gt 1}
		
		# get table that does not exist 
		Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $workspaceName -tableName $tableNotFound} 'NotFound'
	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Test CRUD operations on custom log table
#>
function Test-ClTableCrud
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$clTableName = "dabenhamPoc_CL"

	try
	{
		# Create CustomLog table
		$columns = @{'ColName1' = 'string'; 'TimeGenerated' = 'DateTime'; 'ColName3' = 'int'}
		$clTable = New-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName -RetentionInDays 25 -TotalRetentionInDays 30 -Columns $columns
		Assert-NotNull $clTable
		Assert-True { $clTable.RetentionInDays -eq 25 }
		Assert-True { $clTable.TotalRetentionInDays -eq 30 }

		# Get the new CustomLog table
		$getClTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
		Assert-NotNull $getClTable
		Assert-True { $getClTable.RetentionInDays -eq 25 }
		Assert-True { $getClTable.TotalRetentionInDays -eq 30 }

		# Migrate
		$migrateTable = Migrate-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
		Assert-True { $migrateTable }

		#Delete
		$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
		Assert-True { $deleteTable 

		# get table that does was deleted - does not exist 
		Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $clTableName} 'NotFound'
	}
	finally
	{
		# Cleanup
	}

<#
.SYNOPSIS
Test CRUD operations on Search table
#>
function Test-SearchTableCrud
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$searchTableName = "dabenhamPoc_SRCH"

	try
	{
		# Create Search table
		$searchTable = New-AzOperationalInsightsSearchTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName -SearchQuery "Heartbeat"  -StartSearchTime "05-27-2022 12:26:36" -EndSearchTime "05-28-2022 12:26:36"
		Assert-NotNull $searchTable

		# Get the new Search table
		$getSearchTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName
		Assert-NotNull $getSearchTable
		# TODO - validate another property - check the object manually for potential properties
		# Assert-True { $getSearchTable.RetentionInDays -eq 25 } 
		# Assert-True { $getSearchTable.TotalRetentionInDays -eq 30 }
				
		#Delete
		$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName
		Assert-True { $deleteTable }

		# get table that does was deleted - does not exist 
		Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $searchTableName} 'NotFound'
	}
	finally
	{
		# Cleanup
	}

<#
.SYNOPSIS
Test CRUD operations on Restore table
#>
function Test-RestoreTableCrud
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-eus"
	$restoreTableName = "dabenhamPoc13_RST"

	try
	{
		# Create Restore table
		$restoreTable = New-AzOperationalInsightsRestoreTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName -StartRestoreTime "05-27-2022 12:26:36" -EndRestoreTime "05-28-2022 12:26:36" -RestoreSourceTable "Usage"

		# Get the new Restore table
		$getRestoreTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName
		Assert-NotNull $getRestoreTable
		# TODO - validate another property - check the object manually for potential properties
		# Assert-True { $getSearchTable.RetentionInDays -eq 25 } 
		# Assert-True { $getSearchTable.TotalRetentionInDays -eq 30 }
		
		#Delete
		$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName
		Assert-True { $deleteTable }

		# get table that does was deleted - does not exist 
		Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $restoreTableName} 'NotFound'
	}
	finally
	{
		# Cleanup
	}
	
}