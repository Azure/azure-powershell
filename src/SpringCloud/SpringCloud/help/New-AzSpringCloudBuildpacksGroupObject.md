---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudBuildpacksGroupObject
schema: 2.0.0
---

# New-AzSpringCloudBuildpacksGroupObject

## SYNOPSIS
Create an in-memory object for BuildpacksGroupProperties.

## SYNTAX

```
New-AzSpringCloudBuildpacksGroupObject [-Buildpack <IBuildpackProperties[]>] [-Name <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BuildpacksGroupProperties.

## EXAMPLES

### Example 1: Create an in-memory object for BuildpacksGroupProperties
```powershell
$pack = @()
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/python"
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/java-azure"
New-AzSpringCloudBuildpacksGroupObject -Name 'packtest' -Buildpack $pack
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IBuildpackProperties[]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.BuildpacksGroupProperties

## NOTES

## RELATED LINKS
