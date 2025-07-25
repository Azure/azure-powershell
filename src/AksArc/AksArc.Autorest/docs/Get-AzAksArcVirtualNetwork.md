---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/get-azaksarcvirtualnetwork
schema: 2.0.0
---

# Get-AzAksArcVirtualNetwork

## SYNOPSIS
Lists the virtual networks in the specified resource group

## SYNTAX

### List1 (Default)
```
Get-AzAksArcVirtualNetwork [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzAksArcVirtualNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Retrieve
```
Get-AzAksArcVirtualNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### RetrieveViaIdentity
```
Get-AzAksArcVirtualNetwork -InputObject <IAksArcIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the virtual networks in the specified resource group

## EXAMPLES

### Example 1: Get specific AksArc Virtual Network
```powershell
Get-AzAksArcVirtualNetwork -Name "test-vnet-static" -ResourceGroupName "test-arcappliance-resgrp"
```

Get AksArc virtual network.

### Example 2: List AksArc Virtual Networks 
```powershell
Get-AzAksArcVirtualNetwork -Name "test-vnet-static"
```

List all AksArc virtual networks in a resource group

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity
Parameter Sets: RetrieveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Parameter for the name of the virtual network

```yaml
Type: System.String
Parameter Sets: Retrieve
Aliases: VirtualNetworkName

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
Parameter Sets: List, Retrieve
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
Parameter Sets: List, List1, Retrieve
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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IVirtualNetwork

## NOTES

## RELATED LINKS

