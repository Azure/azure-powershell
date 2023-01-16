### Example 1: Create or update NetworkRuleSet for a Relay Namespace
```powershell
$rules = @()
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
New-AzRelayNamespaceNetworkRuleSet -ResourceGroupName lucas-relay-rg -NamespaceName namespace-pwsh01 -DefaultAction 'Deny' -IPRule $rules | fl
```

```output
DefaultAction                : Deny
IPRule                       : {{
                                 "ipMask": "1.1.1.1",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "1.1.1.2",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "1.1.1.3",
                                 "action": "Allow"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/networkRuleSets/default
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/NetworkRuleSets
```

This cmdlet create or update NetworkRuleSet for a Relay Namespace.