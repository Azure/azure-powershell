### Example 1: Add IP Rules and Virtual Network Rules to a Network Rule Set
```powershell
$ipRule1 = New-AzEventHubIPRuleConfig -IPMask 2.2.2.2 -Action Allow
$ipRule2 = New-AzEventHubIPRuleConfig -IPMask 3.3.3.3 -Action Allow
$virtualNetworkRule1 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId '/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default'
$networkRuleSet = Get-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$networkRuleSet.IPRule += $ipRule1
$networkRuleSet.IPRule += $ipRule2
$networkRuleSet.VirtualNetworkRule += $virtualNetworkRule1
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2 -VirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3
```

```output
DefaultAction                : Deny
IPRule                       : {{
                                 "ipMask": "1.1.1.1",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "2.2.2.2",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "3.3.3.3",
                                 "action": "Allow"
                               }}
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/networkRuleSets/
                               default
Location                     : Australia East
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : Default-EventHub-6229
TrustedServiceAccessEnabled  :
Type                         : Microsoft.EventHub/Namespaces/NetworkRuleSets
VirtualNetworkRule           : {{
                                 "subnet": {
                                   "id": "/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default"
                                 },
                                 "ignoreMissingVnetServiceEndpoint": false
                               },{
                                 "subnet": {
                                   "id": "/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/mySubnet"
                                 },
                                 "ignoreMissingVnetServiceEndpoint": false
                               }}
```

Appends virtual network rules and IPRules to the existing rules.

### Example 2: Enable Trusted Service Access on a namespace
```powershell
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TrustedServiceAccessEnabled
```

```output
DefaultAction                : Deny
IPRule                       : {{
                                 "ipMask": "1.1.1.1",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "2.2.2.2",
                                 "action": "Allow"
                               }, {
                                 "ipMask": "3.3.3.3",
                                 "action": "Allow"
                               }}
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/networkRuleSets/
                               default
Location                     : Australia East
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
TrustedServiceAccessEnabled  : True
Type                         : Microsoft.EventHub/Namespaces/NetworkRuleSets
VirtualNetworkRule           : {{
                                 "subnet": {
                                   "id": "/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default"
                                 },
                                 "ignoreMissingVnetServiceEndpoint": false
                               },{
                                 "subnet": {
                                   "id": "/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/mySubnet"
                                 },
                                 "ignoreMissingVnetServiceEndpoint": false
                               }}
```

Enabled Trusted Service Access on the eventhub namespace `myNamespace`.
