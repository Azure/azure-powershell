---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappprobeheaderobject
schema: 2.0.0
---

# New-AzContainerAppProbeHeaderObject

## SYNOPSIS
Create an in-memory object for ContainerAppProbeHttpGetHttpHeadersItem.

## SYNTAX

```
New-AzContainerAppProbeHeaderObject -Name <String> -Value <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContainerAppProbeHttpGetHttpHeadersItem.

## EXAMPLES

### Example 1: Create a ContainerAppProbeHttpGetHttpHeadersItem object for ContainerApp.
```powershell
New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
```

```output
Name          Value
----          -----
Custom-Header Awesome
```

Create a ContainerAppProbeHttpGetHttpHeadersItem object for ContainerApp.

## PARAMETERS

### -Name
The header field name.

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

### -Value
The header field value.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ContainerAppProbeHttpGetHttpHeadersItem

## NOTES

ALIASES

## RELATED LINKS

