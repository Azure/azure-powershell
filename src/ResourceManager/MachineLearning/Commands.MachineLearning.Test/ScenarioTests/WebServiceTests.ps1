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
Tests creating new simple resource group.
#>
function Test-CreateGetRemoveMLService
{
    # Setup
    $rgname = Get-ResourceGroupName
	Write-Debug -Message "Debug rgname: $rgname"
	Write-Output -Message "Output rgname: $rgname"	

    $location = Get-ProviderLocation "Microsoft.MachineLearning" "webservices"
    Write-Debug -Message "location: $location"	
	$commitmentPlanName = Get-CommitmentPlanName
	[System.Console]::WriteLine("commitmentPlanName: {0}", $commitmentPlanName)
	$webServiceName = Get-WebServiceName
	[System.Console]::WriteLine("webServiceName: {0}", $webServiceName)
	$cpApiVersion = Get-ProviderAPIVersion "Microsoft.MachineLearning" "commitmentPlans"
	Write-Debug -Message "cpApiVersion: $cpApiVersion"	
	
    try 
    {
		# Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location		
		#$cpPlan = New-AzureRmResource -Location $location -ResourceType "Microsoft.MachineLearning/CommitmentPlans" -ResourceName $commitmentPlanName -ResourceGroupName $rgname -SkuObject @{"name"="PLAN_SKU_NAME"; "tier"="PLAN_SKU_TIER"; "capacity"="1" } -Properties @{} -ApiVersion $cpApiVersion

        # Test
		#$svcDefinition = Import-AzureRmMlWebService -FromFile 'TestData\GraphWebServiceDefinition_Prod.json'
		#$svcDefinition.Properties.CommitmentPlan.Id = $cpPlan.Id
        #$svc = New-AzureRmMlWebService -ResourceGroupName $rgname -Location $location -Name $webServiceName -NewWebServiceDefinition $svcDefinition
        
        # Assert
        #Assert-AreEqual $svc.ResourceGroupName $rgname
    }
    finally
    {
        # Cleanup
        # Clean-WebService $rgname $webServiceName
		Clean-ResourceGroup $rgname
    }
}