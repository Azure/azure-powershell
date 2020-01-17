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
Full WAF Policy CRUD cycle
#>
function Test-PolicyCrud
{
    $resourceGroup = TestSetup-CreateResourceGroup

    # Create a WAF policy
    $policyName = getAssetName
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdPolicy = New-AzCdnWafPolicy -PolicyName $policyName -ResourceGroupName $resourceGroup.ResourceGroupName -Tag $tags -DefaultRedirectUrl "http://example.com"
    Assert-AreEqual $policyName $createdPolicy.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdPolicy.ResourceGroupName
    Assert-AreEqual "Standard_Microsoft" $createdPolicy.Sku.Name
    Assert-AreEqual "Global" $createdPolicy.Location
    Assert-Tags $tags $createdPolicy.Tags
    Assert-AreEqual @() $createdPolicy.ManagedRules
    
    # Get the WAF policy
    $retrieved = Get-AzCdnWafPolicy -Name $policyName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $policyName $retrieved.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $retrieved.ResourceGroupName
    Assert-AreEqual "Standard_Microsoft" $retrieved.Sku.Name
    Assert-AreEqual "Global" $retrieved.Location
    Assert-Tags $tags $retrieved.Tags
    Assert-AreEqual @() $retrieved.ManagedRules

    # Update the WAF policy
    # Setup a custom rule
    $matchCondition1 = New-AzCdnWafMatchCondition -MatchVariable "RequestHeader" -Selector "Content-Length" -Operator "LessThan" -MatchValue "1025" -NegateCondition
    $matchCondition2 = New-AzCdnWafMatchCondition -MatchVariable "RequestUri" -Transform "UrlDecode" -Operator "Contains" -MatchValue "../"
    $customRule = New-AzCdnWafCustomRule -CustomRuleName "TestCustomRule" -Priority 2 -MatchCondition $matchCondition1,$matchCondition2 -Action "Redirect"
    # Setup a rate limit rule
    $rateLimitRule = New-AzCdnWafRateLimitRule -RateLimitRuleName "TestRateLimitRule" -Priority 1 -MatchCondition $matchCondition1 -Action "Block" -RateLimitThreshold 30 -RateLimitDurationInMinutes 5
    # Setup managed rules
    $ruleset = (Get-AzCdnWafManagedRuleSet)[0]
    $ruleOverride1 = Set-AzCdnWafManagedRule -RuleId $ruleset.RuleGroups[0].Rules[0].RuleId -Action "Redirect" -Enabled
    $ruleGroupOverride = Set-AzCdnWafManagedRuleGroup -RuleGroupName $ruleset.RuleGroups[0].Name -RuleOverride $ruleOverride1
    $ruleGroupOverride2 = Set-AzCdnWafManagedRuleGroup -RuleGroupName $ruleset.RuleGroups[1].Name -DisableAll
    $managedRules = New-AzCdnWafManagedRuleSet -RuleSetType $ruleset.RuleSetType -RuleSetVersion $ruleset.RuleSetVersion -RuleGroupOverride $ruleGroupOverride,$ruleGroupOverride2
    # Create the actual policy
    $updated = Set-AzCdnWafPolicy -PolicyName $policyName -ResourceGroupName $resourceGroup.ResourceGroupName -DefaultRedirectUrl "http://example.com" -ManagedRuleSet $managedRules -RateLimitRule $rateLimitRule -CustomRule $customRule
    # Verify base policy fields
    Assert-AreEqual $policyName $updated.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $updated.ResourceGroupName
    Assert-AreEqual "Standard_Microsoft" $updated.Sku.Name
    Assert-AreEqual "Global" $updated.Location
    Assert-Tags @{} $updated.Tags
    # Verify managed rules
    Assert-AreEqual $ruleset.RuleSetType $updated.ManagedRules[0].RuleSetType
    Assert-AreEqual $ruleset.RuleSetVersion $updated.ManagedRules[0].RuleSetVersion
    Assert-AreEqual $ruleset.RuleGroups[0].Name $updated.ManagedRules[0].RuleGroupOverrides[0].RuleGroupName
    Assert-AreEqual $ruleset.RuleGroups[0].Rules[0].RuleId $updated.ManagedRules[0].RuleGroupOverrides[0].Rules[0].RuleId
    Assert-AreEqual "Redirect" $updated.ManagedRules[0].RuleGroupOverrides[0].Rules[0].Action
    Assert-AreEqual "Enabled" $updated.ManagedRules[0].RuleGroupOverrides[0].Rules[0].EnabledState
    Assert-AreEqual $ruleset.RuleGroups[1].Name $updated.ManagedRules[0].RuleGroupOverrides[1].RuleGroupName
    Assert-AreEqual 0 $updated.ManagedRules[0].RuleGroupOverrides[1].Rules.Count
    # Verify rate limit rules
    Assert-AreEqual 1 $updated.RateLimitRules.Count
    Assert-AreEqual "TestRateLimitRule" $updated.RateLimitRules[0].Name
    Assert-AreEqual 1 $updated.RateLimitRules[0].Priority
    Assert-AreEqual "Block" $updated.RateLimitRules[0].Action
    Assert-AreEqual 30 $updated.RateLimitRules[0].RateLimitThreshold
    Assert-AreEqual 5 $updated.RateLimitRules[0].RateLimitDurationInMinutes
    Assert-AreEqual 1 $updated.RateLimitRules[0].MatchConditions.Count
    Assert-AreEqual "RequestHeader" $updated.RateLimitRules[0].MatchConditions[0].MatchVariable
    Assert-AreEqual "Content-Length" $updated.RateLimitRules[0].MatchConditions[0].Selector
    Assert-AreEqual "LessThan" $updated.RateLimitRules[0].MatchConditions[0].Operator
    Assert-AreEqual 1 $updated.RateLimitRules[0].MatchConditions[0].MatchValues.Count
    Assert-AreEqual "1025" $updated.RateLimitRules[0].MatchConditions[0].MatchValues[0]
    Assert-True { $updated.RateLimitRules[0].MatchConditions[0].NegateCondition }
    # Verify custom rules
    Assert-AreEqual 1 $updated.CustomRules.Count
    Assert-AreEqual "TestCustomRule" $updated.CustomRules[0].Name
    Assert-AreEqual 2 $updated.CustomRules[0].Priority
    Assert-AreEqual "Redirect" $updated.CustomRules[0].Action
    Assert-AreEqual 2 $updated.CustomRules[0].MatchConditions.Count
    Assert-AreEqual "RequestHeader" $updated.CustomRules[0].MatchConditions[0].MatchVariable
    Assert-AreEqual "Content-Length" $updated.CustomRules[0].MatchConditions[0].Selector
    Assert-AreEqual "LessThan" $updated.CustomRules[0].MatchConditions[0].Operator
    Assert-AreEqual 1 $updated.CustomRules[0].MatchConditions[0].MatchValues.Count
    Assert-AreEqual "1025" $updated.CustomRules[0].MatchConditions[0].MatchValues[0]
    Assert-True { $updated.CustomRules[0].MatchConditions[0].NegateCondition }
    Assert-AreEqual "RequestUri" $updated.CustomRules[0].MatchConditions[1].MatchVariable
    Assert-AreEqual 1 $updated.CustomRules[0].MatchConditions[1].Transforms.Count
    Assert-AreEqual "UrlDecode" $updated.CustomRules[0].MatchConditions[1].Transforms[0]
    Assert-AreEqual "Contains" $updated.CustomRules[0].MatchConditions[1].Operator
    Assert-AreEqual 1 $updated.CustomRules[0].MatchConditions[1].MatchValues.Count
    Assert-AreEqual "../" $updated.CustomRules[0].MatchConditions[1].MatchValues[0]
    Assert-False { $updated.CustomRules[0].MatchConditions[1].NegateCondition }
    
    # Get updated WAF policy
    $retrieved = $updated | Get-AzCdnWafPolicy
    # Verify base policy fields
    Assert-AreEqual $policyName $retrieved.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $retrieved.ResourceGroupName
    Assert-AreEqual "Standard_Microsoft" $retrieved.Sku.Name
    Assert-AreEqual "Global" $retrieved.Location
    Assert-Tags @{} $retrieved.Tags
    # Verify managed rules
    Assert-AreEqual $ruleset.RuleSetType $retrieved.ManagedRules[0].RuleSetType
    Assert-AreEqual $ruleset.RuleSetVersion $retrieved.ManagedRules[0].RuleSetVersion
    Assert-AreEqual $ruleset.RuleGroups[0].Name $retrieved.ManagedRules[0].RuleGroupOverrides[0].RuleGroupName
    Assert-AreEqual $ruleset.RuleGroups[0].Rules[0].RuleId $retrieved.ManagedRules[0].RuleGroupOverrides[0].Rules[0].RuleId
    Assert-AreEqual "Redirect" $retrieved.ManagedRules[0].RuleGroupOverrides[0].Rules[0].Action
    Assert-AreEqual "Enabled" $retrieved.ManagedRules[0].RuleGroupOverrides[0].Rules[0].EnabledState
    Assert-AreEqual $ruleset.RuleGroups[1].Name $retrieved.ManagedRules[0].RuleGroupOverrides[1].RuleGroupName
    Assert-AreEqual 0 $retrieved.ManagedRules[0].RuleGroupOverrides[1].Rules.Count
    # Verify rate limit rules
    Assert-AreEqual 1 $retrieved.RateLimitRules.Count
    Assert-AreEqual "TestRateLimitRule" $retrieved.RateLimitRules[0].Name
    Assert-AreEqual 1 $retrieved.RateLimitRules[0].Priority
    Assert-AreEqual "Block" $updated.RateLimitRules[0].Action
    Assert-AreEqual 30 $retrieved.RateLimitRules[0].RateLimitThreshold
    Assert-AreEqual 5 $retrieved.RateLimitRules[0].RateLimitDurationInMinutes
    Assert-AreEqual 1 $retrieved.RateLimitRules[0].MatchConditions.Count
    Assert-AreEqual "RequestHeader" $retrieved.RateLimitRules[0].MatchConditions[0].MatchVariable
    Assert-AreEqual "Content-Length" $retrieved.RateLimitRules[0].MatchConditions[0].Selector
    Assert-AreEqual "LessThan" $retrieved.RateLimitRules[0].MatchConditions[0].Operator
    Assert-AreEqual 1 $retrieved.RateLimitRules[0].MatchConditions[0].MatchValues.Count
    Assert-AreEqual "1025" $retrieved.RateLimitRules[0].MatchConditions[0].MatchValues[0]
    Assert-True { $retrieved.RateLimitRules[0].MatchConditions[0].NegateCondition }
    # Verify custom rules
    Assert-AreEqual 1 $retrieved.CustomRules.Count
    Assert-AreEqual "TestCustomRule" $retrieved.CustomRules[0].Name
    Assert-AreEqual 2 $retrieved.CustomRules[0].Priority
    Assert-AreEqual "Redirect" $retrieved.CustomRules[0].Action
    Assert-AreEqual 2 $retrieved.CustomRules[0].MatchConditions.Count
    Assert-AreEqual "RequestHeader" $retrieved.CustomRules[0].MatchConditions[0].MatchVariable
    Assert-AreEqual "Content-Length" $retrieved.CustomRules[0].MatchConditions[0].Selector
    Assert-AreEqual "LessThan" $retrieved.CustomRules[0].MatchConditions[0].Operator
    Assert-AreEqual 1 $retrieved.CustomRules[0].MatchConditions[0].MatchValues.Count
    Assert-AreEqual "1025" $retrieved.CustomRules[0].MatchConditions[0].MatchValues[0]
    Assert-True { $retrieved.CustomRules[0].MatchConditions[0].NegateCondition }
    Assert-AreEqual "RequestUri" $retrieved.CustomRules[0].MatchConditions[1].MatchVariable
    Assert-AreEqual 1 $retrieved.CustomRules[0].MatchConditions[1].Transforms.Count
    Assert-AreEqual "UrlDecode" $retrieved.CustomRules[0].MatchConditions[1].Transforms[0]
    Assert-AreEqual "Contains" $retrieved.CustomRules[0].MatchConditions[1].Operator
    Assert-AreEqual 1 $retrieved.CustomRules[0].MatchConditions[1].MatchValues.Count
    Assert-AreEqual "../" $retrieved.CustomRules[0].MatchConditions[1].MatchValues[0]
    Assert-False { $retrieved.CustomRules[0].MatchConditions[1].NegateCondition }

    $policyRemoved = Remove-AzCdnWafPolicy -PolicyName $policyName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force
    Assert-True{$policyRemoved}

    Assert-ThrowsContains { Get-AzCdnWafPolicy -PolicyName $policyName -ResourceGroupName $resourceGroup.ResourceGroupName } "not found"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Link and unlink Endpoints to WAF Policy
#>
function Test-WafLink
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Microsoft"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku
    
    $policyName = getAssetName
    $policy = New-AzCdnWafPolicy -PolicyName $policyName -ResourceGroupName $resourceGroup.ResourceGroupName -Tag $tags -DefaultRedirectUrl "http://example.com"
    
    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    # Create endpoint linked to WAF policy.
    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -LinkedWafPolicyResourceId $policy.Id
    Assert-AreEqual $policy.Id $createdEndpoint.LinkedWafPolicyResourceId
    
    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $policy.Id $endpoint.LinkedWafPolicyResourceId
    
    $policy = $policy | Get-AzCdnWafPolicy
    Assert-AreEqual 1 $policy.LinkedEndpointIds.Count
    Assert-AreEqual $endpoint.Id $policy.LinkedEndpointIds[0]
    
    # Unlink endpoint from WAF policy.
    $endpoint.LinkedWafPolicyResourceId = $null
    $endpoint | Set-AzCdnEndpoint
    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-Null $endpoint.LinkedWafPolicyResourceId
    $policy = $policy | Get-AzCdnWafPolicy
    Assert-AreEqual 0 $policy.LinkedEndpointIds.Count

    # Relink endpoint to WAF policy.
    $endpoint.LinkedWafPolicyResourceId = $policy.Id
    $endpoint = $endpoint | Set-AzCdnEndpoint
    Assert-AreEqual $policy.Id $endpoint.LinkedWafPolicyResourceId
    $policy = $policy | Get-AzCdnWafPolicy
    Assert-AreEqual 1 $policy.LinkedEndpointIds.Count
    Assert-AreEqual $endpoint.Id $policy.LinkedEndpointIds[0]

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
