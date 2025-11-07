### Example 1: Create WAF policy
```powershell
New-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Customrule $customRule1,$customRule2 -ManagedRule $managedRule1 -EnabledState Enabled -Mode Prevention -RedirectUrl "https://www.bing.com/" -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody "<html><head><title>You are blocked!</title></head><body></body></html>"
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

Create WAF policy