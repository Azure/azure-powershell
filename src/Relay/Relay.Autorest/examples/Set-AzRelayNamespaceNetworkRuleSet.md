### Example 1: Update NetworkRuleSet for a Relay Namespace
```powershell
$rules = @()
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
Set-AzRelayNamespaceNetworkRuleSet -ResourceGroupName Relay-ServiceBus-EastUS -NamespaceName namespace-pwsh01 -DefaultAction 'Deny' -IPRule $rules | Format-List
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
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/networkRuleSets
                               /default
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/NetworkRuleSets
```

This cmdlet update NetworkRuleSet for a Relay Namespace.
Updates the specified NetworkRuleSet with a new IPRule in the specified namespace.

### Example 2: Update NetworkRuleSet for a Relay Namespace
```powershell
$rules = @()
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
Get-AzRelayNamespaceNetworkRuleSet -ResourceGroupName Relay-ServiceBus-EastUS -NamespaceName namespace-pwsh01 | Set-AzRelayNamespaceNetworkRuleSet -DefaultAction 'Deny' -IPRule $rules -PublicNetworkAccess 'Enabled' | Format-List
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
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/networkRuleSets 
                               /default
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/NetworkRuleSets
```

This cmdlet update the specified NetworkRuleSet for a Relay Namespace.

