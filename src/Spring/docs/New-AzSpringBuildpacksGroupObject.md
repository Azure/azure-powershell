---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.Spring/new-AzSpringBuildpacksGroupObject
schema: 2.0.0
---

# New-AzSpringBuildpacksGroupObject

## SYNOPSIS
Create an in-memory object for BuildpacksGroupProperties.

## SYNTAX

```
New-AzSpringBuildpacksGroupObject [-Buildpack <IBuildpackProperties[]>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BuildpacksGroupProperties.

## EXAMPLES

### Example 1: Create an in-memory object for BuildpacksGroupProperties
```powershell
$pack = @()
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/python"
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/java-azure"
New-AzSpringBuildpacksGroupObject -Name 'packtest' -Buildpack $pack
```

```output
Name
----
packtest
```

Create an in-memory object for BuildpacksGroupProperties.

## PARAMETERS

### -Buildpack
Buildpacks in the buildpack group.
To construct, see NOTES section for BUILDPACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20220401.IBuildpackProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Buildpack group name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20220401.BuildpacksGroupProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BUILDPACK <IBuildpackProperties[]>`: Buildpacks in the buildpack group.
  - `[Id <String>]`: Id of the buildpack

## RELATED LINKS

