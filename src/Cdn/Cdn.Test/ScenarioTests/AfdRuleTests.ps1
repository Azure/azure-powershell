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

function Test-CreateAfdRule
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    # Create Rule Set
    $ruleSetName = getAssetName
    $ruleSet = New-AzFrontDoorCdnRuleSet -ResourceGroupName $resourceGroupName -ProfileName $profileName -RuleSetName $ruleSetName

    # Create Rule 
    $ruleName = getAssetName
    $ruleAction = New-AzFrontDoorCdnRuleAction -HeaderType ModifyRequestHeader -HeaderAction Overwrite -HeaderName "x-header-name" -HeaderValue "header-value" 
    $rule = New-AzFrontDoorCdnRule -ResourceGroupName $resourceGroupName -ProfileName $profileName -RuleSetName $ruleSetName -RuleName $ruleName -Action $ruleAction -Order 2 

    Assert-AreEqual $ruleSetName $ruleSet.Name
    Assert-AreEqual $ruleName $rule.Name
    Assert-AreEqual $rule.Type "Microsoft.Cdn/profiles/rulesets/rules"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}