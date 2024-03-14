---
external help file:
Module Name: EdgeZones
online version: https://learn.microsoft.com/powershell/module/edgezones/unregister-azureextendedzone
schema: 2.0.0
---

# Unregister-AzureExtendedZone

## SYNOPSIS
Unregisters a subscription for an Azure Extended Zone

## SYNTAX

### Unregister (Default)
```
Unregister-AzureExtendedZone -AzureExtendedZoneName <String> -SubscriptionId <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UnregisterViaIdentity
```
Unregister-AzureExtendedZone -InputObject <IEdgeZonesIdentity> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Unregisters a subscription for an Azure Extended Zone

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



## PARAMETERS

### -AzureExtendedZoneName
The name of the AzureExtendedZone

```yaml
Type: System.String
Parameter Sets: Unregister
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Sample.API.Models.IEdgeZonesIdentity
Parameter Sets: UnregisterViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Unregister
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

### Sample.API.Models.IEdgeZonesIdentity

## OUTPUTS

### Sample.API.Models.IAzureExtendedZone

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEdgeZonesIdentity>`: Identity Parameter
  - `[AzureExtendedZoneName <String>]`: The name of the AzureExtendedZone
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

