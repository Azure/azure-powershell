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
	$queryResult = Search-AzGraph 'Resources | where tags != "" | project id, tags, properties | limit 2'
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResult
	Assert-Null $queryResult.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResult.Data
	Assert-AreEqual 2 $queryResult.Data.Count

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1]
	Assert-PropertiesCount 4 $queryResult.Data[0]
	Assert-PropertiesCount 4 $queryResult.Data[1]

	Assert-IsInstance String $queryResult.Data[0].id
	Assert-IsInstance String $queryResult.Data[1].id
	Assert-IsInstance String $queryResult.Data[0].ResourceId
	Assert-IsInstance String $queryResult.Data[1].ResourceId
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0].tags
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1].tags
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1].properties
	
	Assert-AreEqual $queryResult.Data[0].id $queryResult.Data[0].ResourceId
	Assert-AreEqual $queryResult.Data[1].id $queryResult.Data[1].ResourceId

	Assert-PropertiesCount 7 $queryResult.Data[0].properties
	Assert-PropertiesCount 7 $queryResult.Data[1].properties
}

<#
.SYNOPSIS
Run paged query
#>
function Search-AzureRmGraph-PagedQuery
{
	# Page size was artificially set to 2 rows
	$queryResult = Search-AzGraph "project id" -First 3 -Skip 2
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResult
	Assert-IsInstance System.String $queryResult.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResult.Data
	Assert-AreEqual 3 $queryResult.Data.Count
	
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[2]
	
	Assert-PropertiesCount 2 $queryResult.Data[0]
	Assert-PropertiesCount 2 $queryResult.Data[1]
	Assert-PropertiesCount 2 $queryResult.Data[2]
	
	Assert-IsInstance String $queryResult.Data[0].id
	Assert-IsInstance String $queryResult.Data[1].id
	Assert-IsInstance String $queryResult.Data[2].id

	Assert-IsInstance String $queryResult.Data[0].ResourceId
	Assert-IsInstance String $queryResult.Data[1].ResourceId
	Assert-IsInstance String $queryResult.Data[2].ResourceId

	Assert-True { $queryResult.Data[0].id.Length -gt 0 }
	Assert-True { $queryResult.Data[1].id.Length -gt 0 }
	Assert-True { $queryResult.Data[2].id.Length -gt 0 }
}

<#
.SYNOPSIS
Run query with subscriptions explicitly passed
#>
function Search-AzureRmGraph-Subscriptions
{
	$testSubId = "82506e98-9fdb-41f5-ab67-031005041a26"
	$nonExsitentTestSubId = "000b1166-1e13-4370-a951-6ed345a48c16"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultSubsFromContext = Search-AzGraph $query
	$queryResultOneSub = Search-AzGraph $query -Subscription $testSubId
	$queryResultMultipleSubs = Search-AzGraph $query -Subscription @($testSubId, $nonExsitentTestSubId)
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultSubsFromContext
	Assert-Null $queryResultSubsFromContext.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultSubsFromContext.Data
	Assert-AreEqual $testSubId $queryResultSubsFromContext.Data.subscriptionId
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultOneSub
	Assert-Null $queryResultOneSub.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultOneSub.Data
	Assert-AreEqual $testSubId $queryResultOneSub.Data.subscriptionId
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultMultipleSubs
	Assert-Null $queryResultMultipleSubs.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultMultipleSubs.Data
	Assert-AreEqual $testSubId $queryResultMultipleSubs.Data.subscriptionId
}

<#
.SYNOPSIS
Run query with management groups explicitly passed
#>
function Search-AzureRmGraph-ManagementGroups
{
	$testSubId = "82506e98-9fdb-41f5-ab67-031005041a26"
	$testMgId1 = "72f988bf-86f1-41af-91ab-2d7cd011db47"
	$testMgId2 = "makharchMg"
	$nonExistentTestMgId = "nonExistentMg"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultOneMg = Search-AzGraph $query -ManagementGroup $testMgId1
	$queryResultMultipleMgs = Search-AzGraph $query -ManagementGroup @($testMgId1, $testMgId2, $nonExistentTestMgId) -AllowPartialScope
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultOneMg	
	Assert-Null $queryResultOneMg.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultOneMg.Data
	Assert-AreEqual $testSubId $queryResultOneMg.Data.subscriptionId
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultMultipleMgs
	Assert-Null $queryResultMultipleMgs.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultMultipleMgs.Data
	Assert-AreEqual $testSubId $queryResultMultipleMgs.Data.subscriptionId
}

<#
.SYNOPSIS
Run query with UseTenantScope passed
#>
function Search-AzureRmGraph-Tenant
{
	$testSubId = "82506e98-9fdb-41f5-ab67-031005041a26"
	$query = "distinct subscriptionId | order by subscriptionId asc"

	$queryResultTenant = Search-AzGraph $query -UseTenantScope
	$queryResultTenantWithPartialScope = Search-AzGraph $query -UseTenantScope -AllowPartialScope
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultTenant	
	Assert-Null $queryResultTenant.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultTenant.Data
	Assert-AreEqual $testSubId $queryResultTenant.Data.subscriptionId
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResultTenantWithPartialScope
	Assert-Null $queryResultTenantWithPartialScope.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResultTenantWithPartialScope.Data
	Assert-AreEqual $testSubId $queryResultTenantWithPartialScope.Data.subscriptionId
}

<#
.SYNOPSIS
Run simple query with the skip token
#>
function Search-AzureRmGraph-SkipTokenQuery
{
	$queryResult = Search-AzGraph "project id, properties" -SkipToken "ew0KICAiJGlkIjogIjEiLA0KICAiTWF4Um93cyI6IDMsDQogICJSb3dzVG9Ta2lwIjogMywNCiAgIkt1c3RvQ2x1c3RlclVybCI6ICJodHRwczovL2FyZy1ldXMtc2l4LXNmLmFyZy5jb3JlLndpbmRvd3MubmV0Ig0KfQ=="
	
	Assert-IsInstance Microsoft.Azure.Commands.ResourceGraph.Models.PSResourceGraphResponse[PSObject] $queryResult
	Assert-IsInstance System.String $queryResult.SkipToken
	Assert-IsInstance System.Collections.Generic.List[PSObject] $queryResult.Data
	Assert-AreEqual 3 $queryResult.Data.Count

	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1]
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[2]

	Assert-IsInstance String $queryResult.Data[0].id
	Assert-IsInstance String $queryResult.Data[1].id
	Assert-IsInstance String $queryResult.Data[2].id
	Assert-IsInstance String $queryResult.Data[0].ResourceId
	Assert-IsInstance String $queryResult.Data[1].ResourceId
	Assert-IsInstance String $queryResult.Data[2].ResourceId
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[0].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[1].properties
	Assert-IsInstance System.Management.Automation.PSCustomObject $queryResult.Data[2].properties
	
	Assert-AreEqual $queryResult.Data[0].id $queryResult.Data[0].ResourceId
	Assert-AreEqual $queryResult.Data[1].id $queryResult.Data[1].ResourceId
	Assert-AreEqual $queryResult.Data[2].id $queryResult.Data[2].ResourceId
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

<#
.SYNOPSIS
Run query with both subscriptions and management groups present
#>
function Search-AzureRmGraph-SubscriptionAndTenantQueryError
{
	$expectedErrorId = 'AmbiguousParameterSet,' + [Microsoft.Azure.Commands.ResourceGraph.Cmdlets.SearchAzureRmGraph].FullName
	$expectedErrorMessage = 
		'Parameter set cannot be resolved using the specified named parameters. One or more parameters issued cannot be used together or an insufficient number of parameters were provided.'

 	try
	{
		Search-AzGraph "project id, type" -Subscription 'a' -UseTenantScope
		Assert-True $false  # Expecting an error
	}
	catch [Exception]
	{
		Assert-AreEqual $expectedErrorId $PSItem.FullyQualifiedErrorId
		Assert-AreEqual $expectedErrorMessage $PSItem.Exception.Message
		Assert-IsInstance System.Management.Automation.ParameterBindingException $PSItem.Exception
	}
}