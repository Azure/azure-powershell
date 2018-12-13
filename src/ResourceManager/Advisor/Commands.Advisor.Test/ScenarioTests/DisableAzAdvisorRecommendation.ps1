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


function Disable-AzAdvisorRecommendationByNameParameter
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationId = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$DaysParam = 30
	$propertiesCount = "5"
	$TTLValue = "30.00:00:00"
	$NameValue = "HardcodedSuppressionName"

	$queryResult = Disable-AzAdvisorRecommendation -RecommendationName $RecommendationId -Days $DaysParam 
	
	## Assert type of object returned 
	Assert-IsInstance $queryResult Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorSuppressionContract
	
	## Assert number of key in the body of a single response
	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].Ttl $TTLValue
		Assert-AreEqual $queryResult[$i].Name $NameValue
    }
}

function Disable-AzAdvisorRecommendationBadUserInput-Negative
{
	$DaysParam = -4
	$RecommendationName = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"

	Assert-ThrowsContains { Disable-AzAdvisorRecommendation -RecommendationName $RecommendationName -Days $DaysParam  }  "Cannot validate argument on parameter 'Days'. The -4 argument is less than the minimum allowed range of 1. Supply an argument that is greater than or equal to 1 and then try the command again."
}

function Disable-AzAdvisorRecommendationByIdParameter
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationId = "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/testing/providers/Microsoft.Storage/storageAccounts/fontcjk/providers/Microsoft.Advisor/recommendations/4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$DaysParam = 30
	$propertiesCount = 5
	$TTLValue = "30.00:00:00"
	$NameValue = "HardcodedSuppressionName"

	$queryResult = Disable-AzAdvisorRecommendation -ResourceId $RecommendationId -Days $DaysParam 
	
	## Assert type of object returned 
	Assert-IsInstance $queryResult Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorSuppressionContract
		
	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].Ttl $TTLValue
		Assert-AreEqual $queryResult[$i].Name $NameValue
    }
}

function Disable-AzAdvisorRecommendationPipelineScenario
{
	# All of our API data updates data-resource. Since this CMDLET does not update/create/delete any azure-resource, we have these hardcoded strings to test data and cmdlet.  
	$RecommendationId = "4fa2ff4f-dc90-9876-0723-1360fa9f4bd7"
	$DaysParam = 30
	$propertiesCount = 5
	$TTLValue = "30.00:00:00"
	$NameValue = "HardcodedSuppressionName"

	$queryResult = Disable-AzAdvisorRecommendation -RecommendationName $RecommendationId -Days $DaysParam 
	
	## Assert type of object returned 
	Assert-IsInstance $queryResult Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorSuppressionContract
	
	## Assert the data from the list which has only one entry.
	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].Ttl $TTLValue
		Assert-AreEqual $queryResult[$i].Name $NameValue
	}
}