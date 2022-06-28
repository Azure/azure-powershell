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

	# get all existing tables
	$allTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting
	Assert-NotNull $allTable
	Assert-True {$allTable.Count -gt 1}
		
	# get table that does not exist 
	Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $tableNotFound} 'Not found'
}

<#
.SYNOPSIS
Test CRUD operations on custom log table
#>
function Test-ClTableCrud
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-pshTest"
	$clTableName = "dabenhamPoc17_CL"
	
	# Create CustomLog table
	$columns = @{'ColName1' = 'string'; 'ColName3' = 'int' ; 'TimeGenerated' = 'DateTime'}
	$clTable = New-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName -RetentionInDays 25 -TotalRetentionInDays 30 -Column $columns
	Assert-NotNull $clTable
	Assert-True { $clTable.RetentionInDays -eq 25 }
	Assert-True { $clTable.TotalRetentionInDays -eq 30 }

	# Get the new CustomLog table
	$getClTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
	Assert-NotNull $getClTable
	Assert-True { $getClTable.RetentionInDays -eq 25 }
	Assert-True { $getClTable.TotalRetentionInDays -eq 30 }

	# update CL table retention
	$updatedTable = Update-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName -RetentionInDays 30 -TotalRetentionInDays 35
	Assert-NotNull $updatedTable
	Assert-True { $updatedTable.RetentionInDays -eq 30 }
	Assert-True { $updatedTable.TotalRetentionInDays -eq 35 }

	# Migrate
	$migrateTable = Invoke-AzOperationalInsightsMigrateTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
	Assert-True { $migrateTable }

	# Delete
	$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $clTableName
	Assert-True { $deleteTable }

	# get table that does was deleted - does not exist 
	Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $clTableName} 'Not found'
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
	$queryTableName = "Heartbeat"

	# Create Search table
	$searchTable = New-AzOperationalInsightsSearchTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName -SearchQuery $queryTableName  -StartSearchTime "05-27-2022 12:26:36" -EndSearchTime "05-28-2022 12:26:36"
	Assert-NotNull $searchTable

	# Get the new Search table
	$getSearchTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName
	Assert-NotNull $getSearchTable
	Assert-True { $getSearchTable.SearchResults.SourceTable -eq $queryTableName } 
				
	#Delete
	$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $searchTableName
	Assert-True { $deleteTable }

	# get table that does was deleted - does not exist 
	Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $searchTableName} 'Not found'
}

<#
.SYNOPSIS
Test CRUD operations on Restore table
#>
function Test-RestoreTableCrud
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$wsNameExisting = "dabenham-pshTest"
	$restoreTableName = "dabenhamPoc12_RST"

	# Create Restore table
	$restoreTable = New-AzOperationalInsightsRestoreTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName -StartRestoreTime "05-25-2022 12:26:36" -EndRestoreTime "05-28-2022 12:26:36" -SourceTable "Usage"

	# Get the new Restore table
	$getRestoreTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName
	Assert-NotNull $getRestoreTable
	Assert-True { $getRestoreTable.RestoredLogs.SourceTable -eq "Usage" } 
		
	#Delete
	$deleteTable = Remove-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -TableName $restoreTableName
	Assert-True { $deleteTable }

	# get table that does was deleted - does not exist 
	Assert-ThrowsContains {Get-AzOperationalInsightsTable -ResourceGroupName $rgNameExisting -WorkspaceName $wsNameExisting -tableName $restoreTableName} 'Not found'
}