---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/remove-aztrafficmanagerprofile
schema: 2.0.0
---

# Remove-AzTrafficManagerProfile

## SYNOPSIS
Deletes a Traffic Manager profile.

## SYNTAX

### Delete (Default)
```
Remove-AzTrafficManagerProfile -ProfileName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzTrafficManagerProfile -InputObject <ITrafficManagerIdentity> [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Deletes a Traffic Manager profile.

## EXAMPLES

### Example 1: Delete a Traffic Manager profile
```powershell
Remove-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG"
```

Deletes the specified Traffic Manager profile. Prompts for confirmation before deleting.

### Example 2: Delete a profile using pipeline
```powershell
Get-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG" | Remove-AzTrafficManagerProfile
```

Gets a profile and pipes it to the Remove cmdlet for deletion.

## PARAMETERS

### -InputObject
Identity Parameter

```yaml
Type: Az.TrafficManager.Models.ITrafficManagerIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ProfileName
The name of the Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: Delete
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
Parameter Sets: Delete
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
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
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

### Az.TrafficManager.Models.ITrafficManagerIdentity

## OUTPUTS

### Az.TrafficManager.Models.IDeleteOperationResult

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ITrafficManagerIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: The name of the Traffic Manager endpoint.
  - `[EndpointType <String>]`: The type of the Traffic Manager endpoint.
  - `[HeatMapType <String>]`: The type of the heatmap.
  - `[ProfileName <String>]`: The name of the Traffic Manager profile.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

