---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az./new-AzVolume
schema: 2.0.0
---

# New-AzVolume

## SYNOPSIS
Create an in-memory object for Volume.

## SYNTAX

```
New-AzVolume [-Name <String>] [-StorageName <String>] [-StorageType <StorageType>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Volume.

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

### -Name
Volume name.

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

### -StorageName
Name of storage resource.
No need to provide for EmptyDir.

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

### -StorageType
Storage type for the volume.
If not provided, use EmptyDir.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.StorageType
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.Volume

## NOTES

ALIASES

## RELATED LINKS

