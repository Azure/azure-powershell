---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/set-azservicebusnetworkruleset
schema: 2.0.0
---

# Set-AzServiceBusNetworkRuleSet

## SYNOPSIS
Updates the NetworkRuleSet of a ServiceBus namespace

## SYNTAX

### SetExpanded (Default)
```
Set-AzServiceBusNetworkRuleSet -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultAction <String>] [-IPRule <INwRuleSetIPRules[]>] [-PublicNetworkAccess <String>]
 [-TrustedServiceAccessEnabled] [-VirtualNetworkRule <INwRuleSetVirtualNetworkRules[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzServiceBusNetworkRuleSet -InputObject <IServiceBusIdentity> [-DefaultAction <String>]
 [-IPRule <INwRuleSetIPRules[]>] [-PublicNetworkAccess <String>] [-TrustedServiceAccessEnabled]
 [-VirtualNetworkRule <INwRuleSetVirtualNetworkRules[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the NetworkRuleSet of a ServiceBus namespace

## EXAMPLES

### Example 1: Add IP Rules and Virtual Network Rules to a Network Rule Set
```powershell
$ipRule1 = New-AzServiceBusIPRuleConfig -IPMask 2.2.2.2 -Action Allow
$ipRule2 = New-AzServiceBusIPRuleConfig -IPMask 3.3.3.3 -Action Allow
$virtualNetworkRule1 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId /subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default
$networkRuleSet = Get-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$networkRuleSet.IPRule += $ipRule1
$networkRuleSet.IPRule += $ipRule2
$networkRuleSet.VirtualNetworkRule += $virtualNetworkRule1
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2 -VirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3
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
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/networkRuleSets/
                               default
Location                     : Australia East
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
TrustedServiceAccessEnabled  :
Type                         : Microsoft.ServiceBus/Namespaces/NetworkRuleSets
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
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TrustedServiceAccessEnabled
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
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/networkRuleSets/
                               default
Location                     : Australia East
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
TrustedServiceAccessEnabled  : True
Type                         : Microsoft.ServiceBus/Namespaces/NetworkRuleSets
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

Enabled Trusted Service Access on the ServiceBus namespace `myNamespace`.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAction
Default Action for Network Rule Set

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IPRule
List of IpRules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.INwRuleSetIPRules[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of ServiceBus namespace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.
If value is SecuredByPerimeter then Inbound and Outbound communication is controlled by the network security perimeter and profile's access rules.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustedServiceAccessEnabled
Value that indicates whether Trusted Service Access is Enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkRule
List of VirtualNetwork Rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.INwRuleSetVirtualNetworkRules[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.INetworkRuleSet

## NOTES

## RELATED LINKS

