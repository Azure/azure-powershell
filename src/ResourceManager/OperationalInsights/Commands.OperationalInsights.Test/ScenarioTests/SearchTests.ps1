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

	$idArray = $searchResult.Id.Split("/")
	$id = $idArray[$idArray.Length-1]
	$updatedResult = Get-AzureRmOperationalInsightsSearchResults -ResourceGroupName $rgname -WorkspaceName $wsname -Id $id
	
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

	$savedSearches = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname
	
	Assert-NotNull $savedSearches
	Assert-NotNull $savedSearches.Value
	
	$idArray = $savedSearches.Value[0].Id.Split("/")
	$id = $idArray[$idArray.Length-1]

	$savedSearch = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id

	Assert-NotNull $savedSearch
	Assert-NotNull $savedSearch.ETag
	Assert-NotNull $savedSearch.Id
	Assert-NotNull $savedSearch.Properties
	Assert-NotNull $savedSearch.Properties.Query

	$savedSearchResult = Get-AzureRmOperationalInsightsSavedSearchResults -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id

	Assert-NotNull $savedSearchResult
	Assert-NotNull $savedSearchResult.Metadata
	Assert-NotNull $savedSearchResult.Value
}

<#
.SYNOPSIS
Create a new saved search, update, and then remove it
#>
function Test-SearchSetAndRemoveSavedSearches
{
	$rgname = "mms-eus"
    $wsname = "workspace-861bd466-5400-44be-9552-5ba40823c3aa"

	$id = "test-new-saved-search-id-2015"
	$displayName = "TestingSavedSearch"
	$category = "Saved Search Test Category"
	$version = 1
	$query = "* | measure Count() by Type"

	# Get the count of saved searches
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname
	$count = $savedSearches.Value.Count
	$newCount = $count + 1

	New-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id -DisplayName $displayName -Category $category -Query $query -Version $version -Force
	
	# Check that the search was saved
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-AreEqual $savedSearches.Value.Count $newCount

	$etag = ""
	ForEach ($s in $savedSearches.Value)
	{
		If ($s.Properties.DisplayName.Equals($displayName)) {
			$etag = $s.ETag
		}
	}

	# Test updating the search
	$query = "*"
	Set-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id -DisplayName $displayName -Category $category -Query $query -Version $version -ETag $etag
	
	# Check that the search was updated
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-AreEqual $savedSearches.Value.Count $newCount

	$found = 0
	ForEach ($s in $savedSearches.Value)
	{
		If ($s.Properties.DisplayName.Equals($displayName) -And $s.Properties.Query.Equals($query)) {
			$found = 1
		}
	}
	Assert-AreEqual $found 1


	Remove-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname -SavedSearchId $id -Force
	
	# Check that the search was deleted
	$savedSearches = Get-AzureRmOperationalInsightsSavedSearch -ResourceGroupName $rgname -WorkspaceName $wsname
	Assert-AreEqual $savedSearches.Value.Count $count
}