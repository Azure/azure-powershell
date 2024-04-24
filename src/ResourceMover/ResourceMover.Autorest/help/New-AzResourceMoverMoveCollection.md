---
external help file:
Module Name: Az.ResourceMover
online version: https://learn.microsoft.com/powershell/module/az.resourcemover/new-azresourcemovermovecollection
schema: 2.0.0
---

# New-AzResourceMoverMoveCollection

## SYNOPSIS
Creates or updates a move collection.
The following types of move collections based on the move scenario are supported currently:

**1.
RegionToRegion** (Moving resources across regions)

**2.
RegionToZone** (Moving virtual machines into a zone within the same region)

## SYNTAX

```
New-AzResourceMoverMoveCollection -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-MoveRegion <String>] [-MoveType <MoveType>] [-SourceRegion <String>]
 [-Tag <Hashtable>] [-TargetRegion <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a move collection.
The following types of move collections based on the move scenario are supported currently:

**1.
RegionToRegion** (Moving resources across regions)

**2.
RegionToZone** (Moving virtual machines into a zone within the same region)

## EXAMPLES

### Example 1: Create a new Move collection. (RegionToRegion)
```powershell
New-AzResourceMoverMoveCollection -Name "PS-centralus-westcentralus-demoRMS"  -ResourceGroupName "RG-MoveCollection-demoRMS" -SourceRegion "centralus" -TargetRegion "westcentralus" -Location "centraluseuap" -IdentityType "SystemAssigned"
```

```output
Etag                                   Location      Name
----                                   --------      ----
"0200d92f-0000-3300-0000-6021e9ec0000" centraluseuap PS-centralus-westcentralus-demoRMs
```

Create a new Move Collection for moving resources across regions.
**Please note that here the moveType is set to its default value 'RegionToRegion' for cross region move scenarios where 'SourceRegion' and 'TargetRegion' are required parameters.
Please ensure 'MoveRegion' parameter is not required and should be set to null, as shown in the above example.**

### Example 2: Create a new Move collection. (RegionToZone)
```powershell
New-AzResourceMoverMoveCollection -Name "PS-demo-RegionToZone"  -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveRegion "eastus" -Location "eastus2euap" -IdentityType "SystemAssigned" -MoveType "RegionToZone"
```

```output
Etag                                   Location    Name
----                                   --------    ----
"01000d98-0000-3400-0000-64f707c40000" eastus2euap PS-demo-RegionToZone
```

Create a new Move Collection for moving resources into a zone within the same region.
**Please note that for 'RegionToZone' type move collections 'MoveType' parameter should be set as 'RegionToZone' and 'MoveRegion' should be set as the location where resources undergoing zonal move reside.
Please ensure 'SourceRegion' and 'TargetRegion' are not required and should be set to null, as shown in the above example.**

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

### -IdentityPrincipalId
Gets or sets the principal id.

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

### -IdentityTenantId
Gets or sets the tenant id.

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

### -IdentityType
The type of identity used for the resource mover service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives.

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

### -MoveRegion
Gets or sets the move region which indicates the region where the VM Regional to Zonal move will be conducted.

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

### -MoveType
Defines the MoveType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Move Collection Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MoveCollectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

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

### -SourceRegion
Gets or sets the source region.

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

### -SubscriptionId
The Subscription ID.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetRegion
Gets or sets the target region.

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

### -Version
Gets or sets the version of move collection.

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

### Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IMoveCollection

## NOTES

## RELATED LINKS

