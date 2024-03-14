---
external help file:
Module Name: EdgeZones
online version: https://learn.microsoft.com/powershell/module/edgezones/register-azextendedzone
schema: 2.0.0
---

# Register-AzExtendedZone

## SYNOPSIS
Registers a subscription for an Azure Extended Zone

## SYNTAX

### Register (Default)
```
Register-AzExtendedZone -AzureExtendedZoneName <String> -SubscriptionId <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegisterViaIdentity
```
Register-AzExtendedZone -InputObject <IEdgeZonesIdentity> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Registers a subscription for an Azure Extended Zone

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AzureExtendedZoneName
The name of the AzureExtendedZone

```yaml
Type: System.String
Parameter Sets: Register
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
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IEdgeZonesIdentity
Parameter Sets: RegisterViaIdentity
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
Parameter Sets: Register
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

### Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IEdgeZonesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IAzureExtendedZone

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEdgeZonesIdentity>`: Identity Parameter
  - `[AzureExtendedZoneName <String>]`: The name of the AzureExtendedZone
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

