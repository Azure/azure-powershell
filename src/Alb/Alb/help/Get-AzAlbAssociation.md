---
external help file:
Module Name: Az.Alb
online version: https://learn.microsoft.com/powershell/module/az.alb/get-azalbassociation
schema: 2.0.0
---

# Get-AzAlbAssociation

## SYNOPSIS
Get a Association

## SYNTAX

### List (Default)
```
Get-AzAlbAssociation -AlbName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAlbAssociation -AlbName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAlbAssociation -InputObject <IAlbIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Association

## EXAMPLES

### Example 1: Get a specified Application Gateway for Containers association resource
```powershell
Get-AzAlbAssociation -Name association1 -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name                ResourceGroupName Location       AssociationType SubnetId                                                                                                                                                       Provisioni
                                                                                                                                                                                                                                    ngState
----                ----------------- --------       --------------- --------                                                                                                                                                       ----------
association1        test-rg           NorthCentralUS subnets         /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/primary-VNET/subnets/alb-primary-subnet Succeeded
```

This command shows a specific Application Gateway for Containers association resource.

### Example 2: List associations for a given Application Gateway for Containers resource
```powershell
Get-AzAlbAssociation -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name                ResourceGroupName Location       AssociationType SubnetId                                                                                                                                                       Provisioni
                                                                                                                                                                                                                                    ngState
----                ----------------- --------       --------------- --------                                                                                                                                                       ----------
association1        test-rg           NorthCentralUS subnets         /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/primary-VNET/subnets/alb-primary-subnet Succeeded
```

This command lists all Application Gateway for Containers association resources belonging to a specific Application Gateway for Containers resource.

## PARAMETERS

### -AlbName
traffic controller name for path

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Association

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.Api20230501Preview.IAssociation

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAlbIdentity>`: Identity Parameter
  - `[AssociationName <String>]`: Name of Association
  - `[FrontendName <String>]`: Frontends
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TrafficControllerName <String>]`: traffic controller name for path

## RELATED LINKS

