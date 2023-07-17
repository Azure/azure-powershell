---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/Az.Spring/new-azspringbuildpacksgroupobject
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuildpackProperties[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.BuildpacksGroupProperties

## NOTES

## RELATED LINKS

