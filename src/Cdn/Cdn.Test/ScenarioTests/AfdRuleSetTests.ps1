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

function Test-CreateAfdRuleSet
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $ruleSetName = getAssetName

    $ruleSet = New-AzFrontDoorCdnRuleSet -ResourceGroupName $resourceGroupName -ProfileName $profileName -RuleSetName $ruleSetName

    Assert-AreEqual $ruleSetName $ruleSet.Name
    Assert-AreEqual $ruleSet.Type "Microsoft.Cdn/profiles/rulesets"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RemoveAfdRuleSet
{
    # Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $ruleSetName = getAssetName

    $ruleSet = New-AzFrontDoorCdnRuleSet -ResourceGroupName $resourceGroupName -ProfileName $profileName -RuleSetName $ruleSetName

    Get-AzFrontDoorCdnRuleSet -ResourceGroupName $resourceGroupName -ProfileName $profileName -RuleSetName $ruleSetName | Remove-AzFrontDoorCdnRuleSet

    Assert-ThrowsContains { Get-AzFrontDoorCdnRuleSet -ResourceId $ruleSet.Id } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}