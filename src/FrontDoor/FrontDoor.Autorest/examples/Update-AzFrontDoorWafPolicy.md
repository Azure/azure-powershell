### Example 1: Updates an existing WAF policy custom status code.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -CustomBlockResponseStatusCode 403
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

Update an existing WAF policy custom status code.

### Example 2: Update an existing WAF policy mode.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Mode Detection
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

Update an existing WAF policy mode.

### Example 3: Update an existing WAF policy enabled state and mode.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Mode Detection -EnabledState Disabled
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Disabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

Update an existing WAF policy enabled state and mode.

### Example 4: Update all WAF policies in $resourceGroupName
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName | Update-AzFrontDoorWafPolicy -Mode Detection -EnabledState Disabled
```

Update all WAF policies in $resourceGroupName