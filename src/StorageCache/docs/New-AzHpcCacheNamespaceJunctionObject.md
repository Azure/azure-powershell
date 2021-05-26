---
external help file:
Module Name: HpcCache
online version: https://docs.microsoft.com/powershell/module//az.HpcCache/new-AzHpcCacheNamespaceJunctionObject
schema: 2.0.0
---

# New-AzHpcCacheNamespaceJunctionObject

## SYNOPSIS
Create a in-memory object for NamespaceJunction

## SYNTAX

```
New-AzHpcCacheNamespaceJunctionObject [-NamespacePath <String>] [-NfsAccessPolicyName <String>]
 [-NfsExport <String>] [-TargetPath <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NamespaceJunction

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -NamespacePath
Namespace path on a Cache for a Storage Target.

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

### -NfsAccessPolicyName
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

### Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NamespaceJunction

## NOTES

ALIASES

## RELATED LINKS

