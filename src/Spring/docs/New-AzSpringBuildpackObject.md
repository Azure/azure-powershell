---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.Spring/new-AzSpringBuildpackObject
schema: 2.0.0
---

# New-AzSpringBuildpackObject

## SYNOPSIS
Create an in-memory object for BuildpackProperties.

## SYNTAX

```
New-AzSpringBuildpackObject [-Id <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BuildpackProperties.

## EXAMPLES

### Example 1: Create an in-memory object for BuildpackProperties
```powershell
New-AzSpringBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
```

```output
Id
--
tanzu-buildpacks/dotnet-core
```

Create an in-memory object for BuildpackProperties

## PARAMETERS

### -Id
Id of the buildpack.

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20220401.BuildpackProperties

## NOTES

ALIASES

## RELATED LINKS

