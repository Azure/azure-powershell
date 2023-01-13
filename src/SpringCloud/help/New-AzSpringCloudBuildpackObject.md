---
external help file:
Module Name: Az.SpringCloud
online version: https://docs.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudBuildpackObject
schema: 2.0.0
---

# New-AzSpringCloudBuildpackObject

## SYNOPSIS
Create an in-memory object for BuildpackProperties.

## SYNTAX

```
New-AzSpringCloudBuildpackObject [-Id <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BuildpackProperties.

## EXAMPLES

### Example 1: Create an in-memory object for BuildpackProperties
```powershell
New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.BuildpackProperties

## NOTES

ALIASES

## RELATED LINKS

