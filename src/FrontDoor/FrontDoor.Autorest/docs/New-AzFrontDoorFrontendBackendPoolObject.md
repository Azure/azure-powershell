---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorfrontendbackendpoolobject
schema: 2.0.0
---

# New-AzFrontDoorFrontendBackendPoolObject

## SYNOPSIS
Create an in-memory object for BackendPool.

## SYNTAX

```
New-AzFrontDoorFrontendBackendPoolObject [-Backend <IBackend[]>] [-HealthProbeSettingId <String>]
 [-Id <String>] [-LoadBalancingSettingId <String>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BackendPool.

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

### -Backend
The set of backends for this pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackend[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSettingId
Resource ID.

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

### -Id
Resource ID.

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

### -LoadBalancingSettingId
Resource ID.

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

### -Name
Resource name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.BackendPool

## NOTES

## RELATED LINKS

