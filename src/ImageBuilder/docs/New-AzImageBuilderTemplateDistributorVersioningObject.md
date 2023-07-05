---
external help file:
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/Az.ImageBuilder/new-azimagebuildertemplatedistributorversioningobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateDistributorVersioningObject

## SYNOPSIS
Create an in-memory object for DistributeVersionerLatest.

## SYNTAX

```
New-AzImageBuilderTemplateDistributorVersioningObject -Scheme <String> [-Major <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DistributeVersionerLatest.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Major
Major version for the generated version number.
Determine what is "latest" based on versions with this value as the major version.
-1 is equivalent to leaving it unset.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scheme
Version numbering scheme to be used.

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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.DistributeVersionerLatest

## NOTES

ALIASES

## RELATED LINKS

