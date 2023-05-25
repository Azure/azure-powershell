---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCacheNamespaceJunctionObject
schema: 2.0.0
---

# New-AzStorageCacheNamespaceJunctionObject

## SYNOPSIS
Create an in-memory object for NamespaceJunction.

## SYNTAX

```
New-AzStorageCacheNamespaceJunctionObject [-NamespacePath <String>] [-NfsAccessPolicy <String>]
 [-NfsExport <String>] [-TargetPath <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NamespaceJunction.

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

### -NamespacePath
Namespace path on a cache for a Storage Target.

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

### -NfsAccessPolicy
Name of the access policy applied to this junction.

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

### -NfsExport
NFS export where targetPath exists.

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

### -TargetPath
Path in Storage Target to which namespacePath points.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.NamespaceJunction

## NOTES

ALIASES

## RELATED LINKS

