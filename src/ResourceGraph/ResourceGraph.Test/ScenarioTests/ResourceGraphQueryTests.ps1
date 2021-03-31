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

	Assert-IsInstance Object[] $queryResult
	Assert-AreEqual 2 $queryResult.Count

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1]
	Assert-PropertiesCount 4 $queryResult[0]
	Assert-PropertiesCount 4 $queryResult[1]

	Assert-IsInstance String $queryResult[0].id
	Assert-IsInstance String $queryResult[1].id
	Assert-IsInstance String $queryResult[0].ResourceId
	Assert-IsInstance String $queryResult[1].ResourceId
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0].tags
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1].tags
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1].properties
	
	Assert-AreEqual $queryResult[0].id $queryResult[0].ResourceId
	Assert-AreEqual $queryResult[1].id $queryResult[1].ResourceId

	Assert-PropertiesCount 2 $queryResult[0].properties
	Assert-PropertiesCount 4 $queryResult[1].properties
}

<#
.SYNOPSIS
Run paged query
#>
function Search-AzureRmGraph-PagedQuery
{
	# Page size was artificially set to 2 rows
	$queryResult = Search-AzGraph "project id" -First 3 -Skip 2

	Assert-IsInstance Object[] $queryResult
	Assert-AreEqual 3 $queryResult.Count
	
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[2]
	
	Assert-PropertiesCount 2 $queryResult[0]
	Assert-PropertiesCount 2 $queryResult[1]
	Assert-PropertiesCount 2 $queryResult[2]
	
	Assert-IsInstance String $queryResult[0].id
	Assert-IsInstance String $queryResult[1].id
	Assert-IsInstance String $queryResult[2].id

	Assert-IsInstance String $queryResult[0].ResourceId
	Assert-IsInstance String $queryResult[1].ResourceId
	Assert-IsInstance String $queryResult[2].ResourceId

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
	$testSubId = "eaab1166-1e13-4370-a951-6ed345a48c15"
	$nonExsitentTestSubId = "000b1166-1e13-4370-a951-6ed345a48c16"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultTenant = Search-AzGraph $query
	$queryResultOneSub = Search-AzGraph $query -Subscription $testSubId
	$queryResultMultipleSubs = Search-AzGraph $query -Subscription @($testSubId, $nonExsitentTestSubId)

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultTenant
	Assert-AreEqual $testSubId $queryResultTenant.subscriptionId
	
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultOneSub
	Assert-AreEqual $testSubId $queryResultOneSub.subscriptionId

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultMultipleSubs
	Assert-AreEqual $testSubId $queryResultMultipleSubs.subscriptionId
}

<#
.SYNOPSIS
Run query with management groups explicitly passed
#>
function Search-AzureRmGraph-ManagementGroups
{
	$testSubId = "eaab1166-1e13-4370-a951-6ed345a48c15"
	$testMgId1 = "f686d426-8d16-42db-81b7-ab578e110ccd"
	$testMgId2 = "makharchMg"
	$nonExistentTestMgId = "nonExistentMg"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultTenant = Search-AzGraph $query
	$queryResultOneMg = Search-AzGraph $query -ManagementGroup $testMgId1
	$queryResultMultipleMgs = Search-AzGraph $query -ManagementGroup @($testMgId1, $testMgId2, $nonExistentTestMgId) -AllowPartialScope
	
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultTenant
	Assert-AreEqual $testSubId $queryResultTenant.subscriptionId
	
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultOneMg
	Assert-AreEqual $testSubId $queryResultOneMg.subscriptionId

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResultMultipleMgs
	Assert-AreEqual $testSubId $queryResultMultipleMgs.subscriptionId
}

<#
.SYNOPSIS
Run simple query with the skip token
#>
function Search-AzureRmGraph-SkipTokenQuery
{
	$queryResult = Search-AzGraph "project id, properties" -SkipToken "ew0KICAiJGlkIjogIjEiLA0KICAiTWF4Um93cyI6IDMsDQogICJSb3dzVG9Ta2lwIjogNiwNCiAgIkt1c3RvQ2x1c3RlclVybCI6ICJodHRwczovL2FybXRvcG9sb2d5Lmt1c3RvLndpbmRvd3MubmV0Ig0KfQ=="

	Assert-IsInstance Object[] $queryResult
	Assert-AreEqual 3 $queryResult.Count

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[2]

	Assert-IsInstance String $queryResult[0].id
	Assert-IsInstance String $queryResult[1].id
	Assert-IsInstance String $queryResult[2].id
	Assert-IsInstance String $queryResult[0].ResourceId
	Assert-IsInstance String $queryResult[1].ResourceId
	Assert-IsInstance String $queryResult[2].ResourceId
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[0].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[1].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult[2].properties
	
	Assert-AreEqual $queryResult[0].id $queryResult[0].ResourceId
	Assert-AreEqual $queryResult[1].id $queryResult[1].ResourceId
	Assert-AreEqual $queryResult[2].id $queryResult[2].ResourceId
}

<#
.SYNOPSIS
Run malformed query
#>
function Search-AzureRmGraph-QueryError
{
	$expectedErrorId = 'BadRequest,' + [Microsoft.Azure.Commands.ResourceGraph.Cmdlets.SearchAzureRmGraph].FullName
	$expectedErrorDetailsRegex = [regex]::escape('{
  "error": {
    "code": "BadRequest",
    "message": "Please provide below info when asking for support: timestamp = 2021-03-25T') + '.{17}?' + [regex]::escape(', correlationId = ') + '.{36}?' + [regex]::escape('.",
    "details": [
      {
        "code": "InvalidQuery",
        "message": "Query is invalid. Please refer to the documentation for the Azure Resource Graph service and fix the error before retrying."
      },
      {
        "code": "ParserFailure",
        "message": "ParserFailure",
        "line": 1,
        "characterPositionInLine": 11,
        "token": "<EOF>",
        "expectedToken": "Ǐ"
      }
    ]
  }
}')

	$expectedInnerCode = "InvalidQuery"
	$expectedInnerMessage = "Query is invalid. Please refer to the documentation for the Azure Resource Graph service and fix the error before retrying."

	try
	{
		Search-AzGraph "where where"
		Assert-True $false  # Expecting an error
	}
	catch [Exception]
	{
		Assert-AreEqual $expectedErrorId $PSItem.FullyQualifiedErrorId
		Assert-Match $expectedErrorDetailsRegex $PSItem.ErrorDetails.Message
		Assert-IsInstance Microsoft.Azure.Management.ResourceGraph.Models.ErrorResponseException $PSItem.Exception
		Assert-IsInstance Microsoft.Azure.Management.ResourceGraph.Models.ErrorResponse $PSItem.Exception.Body
		
		Assert-NotNull $PSItem.Exception.Body.Error.Code
		Assert-NotNull $PSItem.Exception.Body.Error.Message
		Assert-NotNull $PSItem.Exception.Body.Error.Details
		Assert-AreEqual 2 $PSItem.Exception.Body.Error.Details.Count
		
		Assert-AreEqual $expectedInnerCode $PSItem.Exception.Body.Error.Details[0].Code
		Assert-AreEqual $expectedInnerMessage $PSItem.Exception.Body.Error.Details[0].Message

		Assert-NotNull $PSItem.Exception.Body.Error.Details[1].Code
		Assert-NotNull $PSItem.Exception.Body.Error.Details[1].Message
		Assert-NotNull $PSItem.Exception.Body.Error.Details[1].AdditionalProperties
		Assert-AreEqual 4 $PSItem.Exception.Body.Error.Details[1].AdditionalProperties.Count
	}
}

<#
.SYNOPSIS
Run query with both subscriptions and management groups present
#>
function Search-AzureRmGraph-SubscriptionAndManagementGroupQueryError
{
	$expectedErrorId = 'AmbiguousParameterSet,' + [Microsoft.Azure.Commands.ResourceGraph.Cmdlets.SearchAzureRmGraph].FullName
	$expectedErrorMessage = 
		'Parameter set cannot be resolved using the specified named parameters. One or more parameters issued cannot be used together or an insufficient number of parameters were provided.'

 	try
	{
		Search-AzGraph "project id, type" -Subscription 'a' -ManagementGroup 'b'
		Assert-True $false  # Expecting an error
	}
	catch [Exception]
	{
		Assert-AreEqual $expectedErrorId $PSItem.FullyQualifiedErrorId
		Assert-AreEqual $expectedErrorMessage $PSItem.Exception.Message
		Assert-IsInstance System.Management.Automation.ParameterBindingException $PSItem.Exception
	}
}