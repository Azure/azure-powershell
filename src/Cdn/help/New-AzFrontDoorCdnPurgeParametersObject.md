---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnPurgeParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnPurgeParametersObject

## SYNOPSIS
Create an in-memory object for AfdPurgeParameters.

## SYNTAX

```
New-AzFrontDoorCdnPurgeParametersObject -ContentPath <String[]> [-Domain <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AfdPurgeParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AfdPurgeParameters
```powershell
$contentPath = "/a"
$content = New-AzFrontDoorCdnPurgeParametersObject -ContentPath $contentPath
```

```output
ContentPath
-----------
{/a}
```

Create an in-memory object for AfdPurgeParameters

## PARAMETERS

### -ContentPath
The path to the content to be purged.
Can describe a file path or a wild card directory.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Domain
List of domains.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.AfdPurgeParameters

## NOTES

ALIASES

## RELATED LINKS

