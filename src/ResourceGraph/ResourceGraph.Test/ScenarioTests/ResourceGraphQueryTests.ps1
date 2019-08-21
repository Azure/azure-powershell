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
Run simple query
#>
function Search-AzureRmGraph-Query
{
	$queryResult = Search-AzGraph "project id, tags, properties | limit 2"

	Assert-IsInstance $queryResult Object[]
	Assert-AreEqual $queryResult.Count 2

	Assert-IsInstance $queryResult[0] System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[1] System.Management.Automation.PSCustomObject
	Assert-PropertiesCount $queryResult[0] 4
	Assert-PropertiesCount $queryResult[1] 4

	Assert-IsInstance $queryResult[0].id String
	Assert-IsInstance $queryResult[1].id String
	Assert-IsInstance $queryResult[0].ResourceId String
	Assert-IsInstance $queryResult[1].ResourceId String	
	Assert-IsInstance $queryResult[0].tags System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[1].tags System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[0].properties System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[1].properties System.Management.Automation.PSCustomObject
	
	Assert-AreEqual $queryResult[0].id $queryResult[0].ResourceId
	Assert-AreEqual $queryResult[1].id $queryResult[1].ResourceId

	Assert-PropertiesCount $queryResult[0].properties 6
	Assert-PropertiesCount $queryResult[1].properties 4
}

<#
.SYNOPSIS
Run paged query
#>
function Search-AzureRmGraph-PagedQuery
{
	# Page size was artificially set to 2 rows
	$queryResult = Search-AzGraph "project id" -First 3 -Skip 2

	Assert-IsInstance $queryResult Object[]
	Assert-AreEqual $queryResult.Count 3
	
	Assert-IsInstance $queryResult[0] System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[1] System.Management.Automation.PSCustomObject
	Assert-IsInstance $queryResult[2] System.Management.Automation.PSCustomObject
	
	Assert-PropertiesCount $queryResult[0] 2
	Assert-PropertiesCount $queryResult[1] 2
	Assert-PropertiesCount $queryResult[2] 2
	
	Assert-IsInstance $queryResult[0].id String
	Assert-IsInstance $queryResult[1].id String
	Assert-IsInstance $queryResult[2].id String

	Assert-IsInstance $queryResult[0].ResourceId String
	Assert-IsInstance $queryResult[1].ResourceId String
	Assert-IsInstance $queryResult[2].ResourceId String

	Assert-True { $queryResult[0].id.Length -gt 0 }
	Assert-True { $queryResult[1].id.Length -gt 0 }
	Assert-True { $queryResult[2].id.Length -gt 0 }
}

<#
.SYNOPSIS
Run query with subscriptions explicitly passed
#>
function Search-AzureRmGraph-Subscriptions
{
	$testSubId1 = "11111111-1111-1111-1111-111111111111"
	$testSubId2 = "22222222-2222-2222-2222-222222222222"
	$mockedSubscriptionId = "00000000-0000-0000-0000-000000000000"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultNoSubs = Search-AzGraph $query
	$queryResultOneSub = Search-AzGraph $query -Subscription $testSubId1
	$queryResultMultipleSubs = Search-AzGraph $query -Subscription @($testSubId1, $testSubId2)

	Assert-IsInstance $queryResultNoSubs System.Management.Automation.PSCustomObject
	Assert-AreEqual $queryResultNoSubs.subscriptionId $mockedSubscriptionId
	
	Assert-IsInstance $queryResultOneSub System.Management.Automation.PSCustomObject
	Assert-AreEqual $queryResultOneSub.subscriptionId $testSubId1
	
	Assert-IsInstance $queryResultMultipleSubs Object[]
	Assert-AreEqual $queryResultMultipleSubs.Count 2
	Assert-AreEqual $queryResultMultipleSubs[0].subscriptionId $testSubId1
	Assert-AreEqual $queryResultMultipleSubs[1].subscriptionId $testSubId2
}

<#
.SYNOPSIS
Run query with subscriptions explicitly passed
#>
function Search-AzureRmGraph-IncludeSubscriptionNames
{
	$mockedScopeId = "00000000-0000-0000-0000-000000000000"
	$mockedSubscriptionName = "Test Subscription"
	$mockedTenantName = "Test Tenant"
	$query = "project subscriptionId, tenantId, subscriptionDisplayName, tenantDisplayName"

	$queryResult = Search-AzGraph $query -Include "DisplayNames"

	Assert-IsInstance $queryResult System.Management.Automation.PSCustomObject
	Assert-AreEqual $queryResult.subscriptionId $mockedScopeId
	Assert-AreEqual $queryResult.tenantId $mockedScopeId
	Assert-AreEqual $queryResult.subscriptionDisplayName $mockedSubscriptionName
	Assert-AreEqual $queryResult.tenantDisplayName $mockedTenantName
}

<#
.SYNOPSIS
Run malformed query
#>
function Search-AzureRmGraph-QueryError
{
	$expectedErrorId = 'InvalidQuery,' + [Microsoft.Azure.Commands.ResourceGraph.Cmdlets.SearchAzureRmGraph].FullName
	$expectedErrorDetails = '{
  "error": {
    "code": "InvalidQuery",
    "message": "Query validation error",
    "details": [
      {
        "code": "ParserFailure",
        "message": "Parser failure",
        "line": 1,
        "characterPositionInLine": 11,
        "token": "<EOF>",
        "expectedToken": "Ÿ"
      }
    ]
  }
}'

	try
	{
		Search-AzGraph "where where"
		Assert-True $false  # Expecting an error
	}
	catch [Exception]
	{
		Assert-AreEqual $PSItem.FullyQualifiedErrorId $expectedErrorId
		Assert-AreEqual $PSItem.ErrorDetails.Message $expectedErrorDetails
		Assert-IsInstance $PSItem.Exception Microsoft.Azure.Management.ResourceGraph.Models.ErrorResponseException
		Assert-IsInstance $PSItem.Exception.Body Microsoft.Azure.Management.ResourceGraph.Models.ErrorResponse
		
		Assert-NotNull $PSItem.Exception.Body.Error.Code
		Assert-NotNull $PSItem.Exception.Body.Error.Message
		Assert-NotNull $PSItem.Exception.Body.Error.Details
		Assert-AreEqual $PSItem.Exception.Body.Error.Details.Count 1

		Assert-NotNull $PSItem.Exception.Body.Error.Details[0].Code
		Assert-NotNull $PSItem.Exception.Body.Error.Details[0].Message
		Assert-NotNull $PSItem.Exception.Body.Error.Details[0].AdditionalProperties
		Assert-AreEqual $PSItem.Exception.Body.Error.Details[0].AdditionalProperties.Count 4
	}
}

<#
.SYNOPSIS
Run query with no subscriptions
#>
function Search-AzureRmGraph-SubscriptionQueryError
{
	$expectedErrorId = '400,' + [Microsoft.Azure.Commands.ResourceGraph.Cmdlets.SearchAzureRmGraph].FullName
	$expectedErrorMessage = 
	'No subscriptions were found to run query. Please try to add them implicitly as param to your request (e.g. Search-AzGraph -Query '''' -Subscription ''11111111-1111-1111-1111-111111111111'')'

 	try
	{
		Search-AzGraph "project id, type" -Subscription @()
		Assert-True $false  # Expecting an error
	}
	catch [Exception]
	{
	    Assert-AreEqual $expectedErrorId $PSItem.FullyQualifiedErrorId
		Assert-AreEqual $expectedErrorMessage $PSItem.Exception.Message

		Assert-IsInstance $PSItem.Exception System.ArgumentException
	}
}
