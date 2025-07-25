---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricroutepolicy
schema: 2.0.0
---

# New-AzNetworkFabricRoutePolicy

## SYNOPSIS
Implements Route Policy PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> -Location <String>
 -NetworkFabricId <String> [-SubscriptionId <String>] [-AddressFamilyType <String>] [-Annotation <String>]
 [-DefaultAction <String>] [-Statement <IRoutePolicyStatementProperties[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Implements Route Policy PUT method.

## EXAMPLES

### Example 1: Create the Route Policy Resource
```powershell
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixTestName"
    ConditionType = "Or"
    IPCommunityPropertyAddIpcommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
})

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGrou...
```

This command creates the Route Policy resource with IPCommunity.

### Example 2: Create the Route Policy Resource
```powershell
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPExtendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixName"
    ConditionType = "Or"
    IPExtendedCommunityPropertyAddIpextendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
})

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGrou…
```

This command creates the Route Policy resource with IPExtendedCommunity.

## PARAMETERS

### -AddressFamilyType
AddressFamilyType.
This parameter decides whether the given ipv4 or ipv6 route policy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Default action that needs to be applied when no condition is matched.
Example: Permit | Deny.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Route Policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RoutePolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricId
Arm Resource ID of Network Fabric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Statement
Route Policy statements.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicy

## NOTES

## RELATED LINKS

