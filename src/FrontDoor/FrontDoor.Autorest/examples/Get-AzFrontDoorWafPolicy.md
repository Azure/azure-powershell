### Example 1
```powershell
Get-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
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

Get a WAF policy called $policyName in $resourceGroupName

### Example 2
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName
```

```output
Location Name              Etag ResourceGroupName
-------- ----              ---- -----------------
Global   n1                     rg
Global   n2                     rg
Global   n3                     rg
Global   n4                     rg
Global   n5                     rg
Global   n6                     rg
Global   n7                     rg
Global   n8                     rg
Global   n9                     rg
```

Get all WAF policy in $resourceGroupName
