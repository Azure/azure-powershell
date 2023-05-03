---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnLoadParametersObject
schema: 2.0.0
---

# New-AzCdnLoadParametersObject

## SYNOPSIS
Create an in-memory object for LoadParameters.

## SYNTAX

```
New-AzCdnLoadParametersObject -ContentPath <String[]> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LoadParameters.

## EXAMPLES

### Example 1: Create an in-memory object for LoadParameters
```powershell
$contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg")
New-AzCdnLoadParametersObject -ContentPath $contentPath
```

```output
ContentPath
-----------
{/movies/amazing.mp4, /pictures/pic1.jpg}
```

Create an in-memory object for LoadParameters

## PARAMETERS

### -ContentPath
The path to the content to be loaded.
Path should be a relative file URL of the origin.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.LoadParameters

## NOTES

ALIASES

## RELATED LINKS

