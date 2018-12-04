﻿# ----------------------------------------------------------------------------------
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
Neagtive Test, no user input for the parameters. 
#>
function Enable-AzureRmAdvisorRecommendationNoParameterSet
{
		Assert-ThrowsContains { Enable-AzureRmAdvisorRecommendation } "Cannot process command because of one or more missing mandatory parameters: RecommendationName."
}

<#
.SYNOPSIS
Enable-AzureRmAdvisorRecommendationPipeline scenario, given a recommendation name (stable-Id) enable all of its corresponding suppressions.
#>
function Enable-AzureRmAdvisorRecommendationByNameParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationName = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"

	$queryResult = Enable-AzureRmAdvisorRecommendation -Name $RecommendationName
	
	Assert-IsInstance $queryResult System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]
	
	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-PropertiesCount $queryResult[$i] 14	
		Assert-IsInstance $queryResult[$i].id String
		Assert-IsInstance $queryResult[$i].Name String
		Assert-PropertiesCount $queryResult[$i].ShortDescription 2
	}
}

<#
.SYNOPSIS
Enable-AzureRmAdvisorRecommendationPipeline scenario, given a recommendation ID enable all of its corresponding suppressions.
#>
function Enable-AzureRmAdvisorRecommendationByIdParameterSet
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk/providers/Microsoft.Advisor/recommendations/4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"

	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk/providers/Microsoft.Advisor/recommendations/4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$queryResult = Enable-AzureRmAdvisorRecommendation -Id $RecommendationId
	
	Assert-IsInstance $queryResult System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]
	
	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] 14	
		Assert-IsInstance $queryResult[$i].id String
		Assert-IsInstance $queryResult[$i].Name String
		Assert-PropertiesCount $queryResult[$i].ShortDescription 2
	}
}

<#
.SYNOPSIS
Enable-AzureRmAdvisorRecommendationPipeline scenario, get a recommendation and enable all of it suppressions.
#>
function Enable-AzureRmAdvisorRecommendationPipeline
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationId = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"

	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk/providers/Microsoft.Advisor/recommendations/4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$queryResult = Get-AzureRmAdvisorRecommendation -Id $RecommendationId | Enable-AzureRmAdvisorRecommendation
	
	Assert-IsInstance $queryResult System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]
	
	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] 14	
		Assert-IsInstance $queryResult[$i].id String
		Assert-IsInstance $queryResult[$i].Name String
		Assert-PropertiesCount $queryResult[$i].ShortDescription 2
	}
}


