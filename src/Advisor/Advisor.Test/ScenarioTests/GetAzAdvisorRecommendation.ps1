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
Get comeplete list of recommendations 
#>
function Get-AzAdvisorRecommendationNoParameter
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase"

	$queryResult = Get-AzAdvisorRecommendation 
	Assert-NotNull  $queryResult

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].ResourceId String
		Assert-IsInstance $queryResult[$i].Name String
		Assert-PropertiesCount $queryResult[$i].ShortDescription $shortDescriptionPropertiesCount
	}
}

<#
.SYNOPSIS
Get recommendation using the recommendation Id.
#>
function Get-AzAdvisorRecommendationByIdParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk"
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase"

	$queryResult = Get-AzAdvisorRecommendation -ResourceId $RecommendationId

	for ($i = 0; $i -lt $queryResult.Count; $i++){
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-PropertiesCount $queryResult[$i].ShortDescription $shortDescriptionPropertiesCount
	}	
}

<#
.SYNOPSIS
Get comeplete list of recommendations with a specific category.
#>
function Get-AzAdvisorRecommendationByCategory
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$Category = "Security"
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase"

	$queryResult = Get-AzAdvisorRecommendation -Category $Category

	Assert-NotNull  $queryResult
	
	for ($i = 0; $i -lt $queryResult.Count; $i++){
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].category $Category
		Assert-PropertiesCount $queryResult[$i].ShortDescription $shortDescriptionPropertiesCount
	}	
}

<#
.SYNOPSIS
Get recommendation using the resourceGroup-Name
#>
function Get-AzAdvisorRecommendationByNameParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$ResourceGroupName = "AzExpertStg"
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase"

	$queryResult = Get-AzAdvisorRecommendation -ResourceGroupName $ResourceGroupName
	Assert-NotNull  $queryResult

	for ($i = 0; $i -lt $queryResult.Count; $i++){
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] 14
		Assert-IsInstance $queryResult[$i].ResourceId String
		Assert-IsInstance $queryResult[$i].Name String
		Assert-PropertiesCount $queryResult[$i].ShortDescription 2 
	}
}
