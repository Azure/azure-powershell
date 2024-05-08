---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabrictaprule
schema: 2.0.0
---

# Get-AzNetworkFabricTapRule

## SYNOPSIS
Get Network Tap Rule resource details.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricTapRule [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricTapRule -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricTapRule -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get Network Tap Rule resource details.

## EXAMPLES

### Example 1: List Network Tap Rule by Subscription
```powershell
Get-AzNetworkFabricTapRule -SubscriptionId $subscriptionId
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command lists all the Network Tap Rule under the given Subscription.

### Example 2: List Network Tap Rule by Resource Group
```powershell
Get-AzNetworkFabricTapRule -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command lists all the Network Tap Rule under the given Resource Group.

### Example 3: Get Network Tap Rule
```powershell
Get-AzNetworkFabricTapRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command gets details of the given Network Tap Rule.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Network Tap Rule.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkTapRuleName

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkTapRule

## NOTES

## RELATED LINKS

