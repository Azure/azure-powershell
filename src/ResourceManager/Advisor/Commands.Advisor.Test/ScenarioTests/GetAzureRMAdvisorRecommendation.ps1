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
function Get-AzureRmAdvisorRecommendationNoParameter
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]"

	$queryResult = Get-AzureRmAdvisorRecommendation 
		
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult

	Assert-PropertiesCount $queryResult[0] $propertiesCount
	Assert-PropertiesCount $queryResult[1] $propertiesCount
	Assert-IsInstance $queryResult[0].id String
	Assert-IsInstance $queryResult[1].id String
	Assert-IsInstance $queryResult[0].Name String
	Assert-IsInstance $queryResult[1].Name String
	Assert-PropertiesCount $queryResult[0].ShortDescription $shortDescriptionPropertiesCount
	Assert-PropertiesCount $queryResult[1].ShortDescription $shortDescriptionPropertiesCount
}

<#
.SYNOPSIS
Get recommendation using the recommendation Id.
#>
function Get-AzureRmAdvisorRecommendationByIdParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk/providers/Microsoft.Advisor/recommendations/4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$RecommendationName = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]"

	$queryResult = Get-AzureRmAdvisorRecommendation -Id $RecommendationId

	#Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult[0] $propertiesCount
	Assert-AreEqual $queryResult[0].Id $RecommendationId
	Assert-AreEqual $queryResult[0].Name $RecommendationName
	Assert-PropertiesCount $queryResult[0].ShortDescription $shortDescriptionPropertiesCount
}

<#
.SYNOPSIS
Get comeplete list of recommendations with a specific category.
#>
function Get-AzureRmAdvisorRecommendationByCategory
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$Category = "Security"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]"

	$queryResult = Get-AzureRmAdvisorRecommendation -C $Category

	#Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult[0] $propertiesCount
	Assert-AreEqual $queryResult[0].category $Category
	Assert-PropertiesCount $queryResult[0].ShortDescription $shortDescriptionPropertiesCount
}

<#
.SYNOPSIS
Get recommendation using the resourceGroup-Name
#>
function Get-AzureRmAdvisorRecommendationByNameParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$propertiesCount = 14
	$shortDescriptionPropertiesCount = 2
	$ResourceGroupName = "AzExpertStg"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]"

	$queryResult = Get-AzureRmAdvisorRecommendation -Name $ResourceGroupName
			
	Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType

	Assert-PropertiesCount $queryResult[0] 14
	Assert-PropertiesCount $queryResult[1] 14
	
	Assert-IsInstance $queryResult[0].id String
	Assert-IsInstance $queryResult[1].id String

	Assert-IsInstance $queryResult[0].Name String
	Assert-IsInstance $queryResult[1].Name String
	
	Assert-PropertiesCount $queryResult[0].ShortDescription 2
	Assert-PropertiesCount $queryResult[1].ShortDescription 2 
}

