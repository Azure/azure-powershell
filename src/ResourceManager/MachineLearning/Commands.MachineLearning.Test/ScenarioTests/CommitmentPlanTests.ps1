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
Tests creating, getting and removing an AzureML commitment plan. 
#>
function Test-CreateGetRemoveMLCommitmentPlan
{  
    $planDeleted = $false

    $actualTest = {
        param([string] $location)

		try
		{
			$resourceGroupName = Get-ResourceGroupName 
			$commitmentPlanName = Get-CommitmentPlanName

			LogOutput "Creating resource group: $resourceGroupName"
			$group = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
			LogOutput("Created resource group: $($group.ResourceId)")

			# Create a commitment plan and validate it
			LogOutput "Creating commitment plan: $commitmentPlanName"
			$plan = New-AzureRmMlCommitmentPlan -ResourceGroupName $resourceGroupName -Location $location -Name $commitmentPlanName -SkuName "S1" -SkuTier "Standard" -Force
			Assert-NotNull $plan

			$planId = $plan.Id
			LogOutput "Created commitment plan: $planId"
			ValidateCommitmentPlanResult $resourceGroupName $commitmentPlanName $location $plan

			# Delete the commitment plan
			LogOutput "Removing commitment plan $commitmentPlanName from resource group $resourceGroupName"
			$plan | Remove-AzureRmMlCommitmentPlan -Force
			LogOutput "Commitment plan $commitmentPlanName was removed."    
			$planDeleted = $true

			# Validate that the commitment plan no longer exists 
			Assert-ThrowsContains { Get-AzureRmMlCommitmentPlan -ResourceGroupName $resourceGroupName -Name $commitmentPlanName } "ResourceNotFound"
        }
        finally
        {
            # Cleanup
            if (!$planDeleted) 
            {                   
                Clean-CommitmentPlan $resourceGroupName $commitmentPlanName
            }

			Clean-ResourceGroup $resourceGroupName
        }
    };

    RunCommitmentPlansTest $actualTest
}

<#
.SYNOPSIS
Tests updating an AzureML commitment plan. 
#>
function Test-UpdateMLCommitmentPlan
{  
    $planDeleted = $false

    $actualTest = {
        param([string] $location)

		try
		{
			$resourceGroupName = Get-ResourceGroupName 
			$commitmentPlanName = Get-CommitmentPlanName

			LogOutput "Creating resource group: $resourceGroupName"
			$group = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
			LogOutput("Created resource group: $($group.ResourceId)")

			# Create a commitment plan and validate it
			LogOutput "Creating commitment plan: $commitmentPlanName"
			$plan = New-AzureRmMlCommitmentPlan -ResourceGroupName $resourceGroupName -Location $location -Name $commitmentPlanName -SkuName "S1" -SkuTier "Standard" -Force
			Assert-NotNull $plan

			$planId = $plan.Id
			LogOutput "Created commitment plan: $planId"
			ValidateCommitmentPlanResult $resourceGroupName $commitmentPlanName $location $plan

			# Update the commitment plan
			LogOutput "Updating commitment plan $planId"
			Update-AzureRmMlCommitmentPlan -ResourceGroupName $resourceGroupName -Name $commitmentPlanName -SkuName "S2" -SkuTier "Standard" -SkuCapacity 2 -Tags @{"tag1" = "value1"} -Force
			
			# Delete the commitment plan
			LogOutput "Removing commitment plan $commitmentPlanName from resource group $resourceGroupName"
			$plan | Remove-AzureRmMlCommitmentPlan -Force
			LogOutput "Commitment plan $commitmentPlanName was removed."    
			$planDeleted = $true

			# Validate that the commitment plan no longer exists 
			Assert-ThrowsContains { Get-AzureRmMlCommitmentPlan -ResourceGroupName $resourceGroupName -Name $commitmentPlanName } "ResourceNotFound"
        }
        finally
        {
            # Cleanup
            if (!$planDeleted) 
            {                   
                Clean-CommitmentPlan $resourceGroupName $commitmentPlanName
            }

			Clean-ResourceGroup $resourceGroupName
        }
    };

    RunCommitmentPlansTest $actualTest
}

<#
.SYNOPSIS
Tests the cmdlets for retrieving lists of AzureML commitment plans
#>
function Test-ListMLCommitmentPlans
{
    $actualTest = {
        param([string] $location)       
		 
        try 
        {
            # Create two commitment plans in the first resource group
			$firstResourceGroupName = Get-ResourceGroupName
			$firstCommitmentPlanName = Get-CommitmentPlanName
			$secondCommitmentPlanName = Get-CommitmentPlanName

			LogOutput "Creating first resource group: $firstResourceGroupName"
			$firstGroup = New-AzureRmResourceGroup -Name $firstResourceGroupName -Location $location
			LogOutput("Created first resource group: $($firstGroup.ResourceId)")

            LogOutput "Creating first commitment plan: $firstCommitmentPlanName"
			$firstPlan = New-AzureRmMlCommitmentPlan -ResourceGroupName $firstResourceGroupName -Location $location -Name $firstCommitmentPlanName -SkuName "S1" -SkuTier "Standard" -Force
			Assert-NotNull $firstPlan

			$firstPlanId = $firstPlan.Id
			LogOutput "Created first commitment plan: $firstPlanId"
			ValidateCommitmentPlanResult $firstResourceGroupName $firstCommitmentPlanName $location $firstPlan

            LogOutput "Creating second commitment plan: $secondCommitmentPlanName"
			$secondPlan = New-AzureRmMlCommitmentPlan -ResourceGroupName $firstResourceGroupName -Location $location -Name $secondCommitmentPlanName -SkuName "S1" -SkuTier "Standard" -Force
			Assert-NotNull $secondPlan

			$secondPlanId = $secondPlan.Id
			LogOutput "Created second commitment plan: $secondPlanId"
			ValidateCommitmentPlanResult $firstResourceGroupName $secondCommitmentPlanName $location $secondPlan

            # Create a third commitment plan in the second resource group
			$secondResourceGroupName = Get-ResourceGroupName
			$thirdCommitmentPlanName = Get-CommitmentPlanName

			LogOutput "Creating second resource group: $secondResourceGroupName"
			$secondGroup = New-AzureRmResourceGroup -Name $secondResourceGroupName -Location $location
			LogOutput("Created second resource group: $($secondResourceGroupName.ResourceId)")

            LogOutput "Creating third commitment plan: $thirdCommitmentPlanName"
			$thirdPlan = New-AzureRmMlCommitmentPlan -ResourceGroupName $secondResourceGroupName -Location $location -Name $thirdCommitmentPlanName -SkuName "S1" -SkuTier "Standard" -Force
			Assert-NotNull $thirdPlan

			$thirdPlanId = $thirdPlan.Id
			LogOutput "Created third commitment plan: $thirdPlanId"
			ValidateCommitmentPlanResult $secondResourceGroupName $thirdCommitmentPlanName $location $thirdPlan

            # List all commitment plans in the first resource group
            LogOutput "Listing all commitment plans in first resource group: $firstResourceGroupName"
            $plansInFirstGroup = Get-AzureRmMlCommitmentPlan -ResourceGroupName $firstResourceGroupName
            Assert-NotNull $plansInFirstGroup
            LogOutput "Group $firstResourceGroupName contains $($plansInFirstGroup.Count) commitment plans."    
            Assert-AreEqual 2 $plansInFirstGroup.Count

            LogOutput "Checking that first commitment plan $($firstPlan.Id) is part of returned list."
            Assert-NotNull ($plansInFirstGroup | where { $_.Id -eq $firstPlan.Id })

            LogOutput "Checking that second commitment plan $($secondPlan.Id) is part of returned list."
            Assert-NotNull ($plansInFirstGroup | where { $_.Id -eq $secondPlan.Id })

            # List all commitment plans in the second resource group
            LogOutput "Listing all commitment plans in second resource group: $secondResourceGroupName"
            $plansInSecondGroup = Get-AzureRmMlCommitmentPlan -ResourceGroupName $secondResourceGroupName
            Assert-NotNull $plansInSecondGroup            
            LogOutput "Group $secondResourceGroupName contains $($plansInSecondGroup.Count) commitment plans."                            
            Assert-AreEqual 1 $plansInSecondGroup.Count

            LogOutput "Checking that commitment plan $($thirdPlan.Id) is part of returned list."
            Assert-True { $plansInSecondGroup[0].Id -eq $thirdPlan.Id }

            # List all services in the subscription
            $plansInSubscription = Get-AzureRmMlCommitmentPlan
            Assert-NotNull $plansInSubscription
            LogOutput "Found $($plansInSubscription.Count) commitment plans in the current subscription."    
            Assert-False { $plansInSubscription.Count -lt 3 }
            LogOutput "Checking that commitment plan $($firstPlan.Id) is part of returned list."
            Assert-NotNull ($plansInSubscription | where { $_.Id -eq $firstPlan.Id })
            LogOutput "Checking that commitment plan $($secondPlan.Id) is part of returned list."
            Assert-NotNull ($plansInSubscription | where { $_.Id -eq $secondPlan.Id })
            LogOutput "Checking that commitment plan $($thirdPlan.Id) is part of returned list."
            Assert-NotNull ($plansInSubscription | where { $_.Id -eq $thirdPlan.Id })
        }
        finally
        {                
            Clean-WebService $firstResourceGroupName $firstCommitmentPlanName
            Clean-WebService $firstResourceGroupName $secondCommitmentPlanName
            Clean-WebService $secondResourceGroupName $thirdCommitmentPlanName

            Clean-ResourceGroup $firstResourceGroupName
			Clean-ResourceGroup $secondResourceGroupName
        }
    };

    RunCommitmentPlansTest $actualTest
}

<#
.SYNOPSIS
Base function for running commitment plans tests
#>
function RunCommitmentPlansTest([ScriptBlock] $testScript)
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.MachineLearning" "commitmentPlans"
    $cpApiVersion = Get-ProviderAPIVersion "Microsoft.MachineLearning" "commitmentPlans"
    LogOutput "Using version $cpApiVersion of the CP RP APIs"

    try
    {
        &$testScript $location
    }
    finally
    {
    }
}

function ValidateCommitmentPlanResult([string] $rgName, [string] $commitmentPlanName, [string] $location, `
                    [Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models.CommitmentPlan] $plan)
{
    $subscriptionId = ((Get-AzureRmContext).Subscription).SubscriptionId        
    $expectedResourceId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.MachineLearning/commitmentPlans/$commitmentPlanName"
	$planId = $plan.Id
    LogOutput "Checking that the created commitment plan's resource id ($planId) matches the expected value ($expectedResourceId)"
    Assert-AreEqual $expectedResourceId $planId

	$planLocation = $plan.Location
    LogOutput "Checking that the commitment plan's location ($planLocation) is the expected value ($location)"
    Assert-True { [System.String]::Equals($planLocation.Replace(" ", ""), $location, [System.StringComparison]::OrdinalIgnoreCase) }

	$expectedResourceType = "Microsoft.MachineLearning/commitmentPlans"
	$planType = $plan.Type
    LogOutput "Checking the commitment plan's resource type: ($planType) matches the expected value ($expectedResourceType)"
    Assert-AreEqual $expectedResourceType $planType

    LogOutput "Checking that the commitment plan's properties are not null."
    Assert-NotNull $plan.Properties
}
