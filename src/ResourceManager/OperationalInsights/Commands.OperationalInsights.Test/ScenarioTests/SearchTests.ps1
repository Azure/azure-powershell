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
Get and update search results
#>
function Test-SearchGetSearchResultsAndUpdate
{
    $rgname = "OI-Default-East-US"
    $wsname = "rasha"

	$top = 25

	$searchResult = Get-AzureRmOperationalInsightsSearchResults -ResourceGroupName $rgname -WorkspaceName $wsname -Top $top -Query "*"

	Assert-NotNull $searchResult
	Assert-NotNull $searchResult.Metadata
	Assert-NotNull $searchResult.Value
	Assert-AreEqual $searchResult.Value.Count $top

	$id = $searchResult.Id
	$updatedResult = Get-AzureRmOperationalInsightsSearchResultsUpdate -Id $id
	
	Assert-NotNull $updatedResult
	Assert-NotNull $updatedResult.Metadata
	Assert-NotNull $searchResult.Value
}

<#
.SYNOPSIS
Get schemas for a given workspace
#>
function Test-SearchGetSchema
{
    $rgname = "mms-eus"
    $wsname = "workspace-861bd466-5400-44be-9552-5ba40823c3aa"

	$schema = Get-AzureRmOperationalInsightsSchema -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-NotNull $schema
	Assert-NotNull $schema.Metadata
	Assert-AreEqual $schema.Metadata.ResultType "schema"
	Assert-NotNull $schema.Value
}

<#
.SYNOPSIS
Get saved searches and search results from a saved search
#>
function Test-SearchGetSavedSearchesAndResults
{
	$rgname = "mms-eus"
    $wsname = "workspace-861bd466-5400-44be-9552-5ba40823c3aa"

	$savedSearches = Get-AzureRmOperationalInsightsSavedSearches -ResourceGroupName $rgname -WorkspaceName $wsname
	
	Assert-NotNull $savedSearches
	Assert-NotNull $savedSearches.Value
	
	$id = $savedSearches.Value[0].Id
	$savedSearch = Get-AzureRmOperationalInsightsSavedSearch -SavedSearchId $id

	Assert-NotNull $savedSearch
	Assert-NotNull $savedSearch.ETag
	Assert-NotNull $savedSearch.Id
	Assert-NotNull $savedSearch.Properties
	Assert-NotNull $savedSearch.Properties.Query

	$savedSearchResult = Get-AzureRmOperationalInsightsSavedSearchResults -SavedSearchId $id

	Assert-NotNull $savedSearchResult
	Assert-NotNull $savedSearchResult.Metadata
	Assert-NotNull $savedSearchResult.Value
}

<#
.SYNOPSIS
Put a saved search and then delete it
#>
function Test-SearchSetAndRemoveSavedSearches
{
	$rgname = "mms-eus"
    $wsname = "workspace-861bd466-5400-44be-9552-5ba40823c3aa"

	$id = "put saved search test id"
	$displayName = "put saved search test"
	$category = "put saved search test category"
	$version = 1
	$query = "* | measure Count() by Type"

	# Get the count of saved searches
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearches -ResourceGroupName $rgname -WorkspaceName $wsname
	$count = $savedSearches.Value.Count
	$newCount = $count + 1

	Set-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id -DisplayName $displayName -Category $category -Query $query -Version $version
	
	# Check that the search was saved
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearches -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-AreEqual $savedSearches.Value.Count $newCount

	Remove-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id
	
	# Check that the search was deleted
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearches -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-AreEqual $savedSearches.Value.Count $count
}