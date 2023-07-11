---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.Spring/new-AzSpringAppDeploymentSourceUploadedObject
schema: 2.0.0
---

# New-AzSpringAppDeploymentSourceUploadedObject

## SYNOPSIS
Create an in-memory object for SourceUploadedUserSourceInfo.

## SYNTAX

```
New-AzSpringAppDeploymentSourceUploadedObject [-ArtifactSelector <String>] [-RuntimeVersion <String>]
 [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SourceUploadedUserSourceInfo.

## EXAMPLES

### Example 1: Create an in-memory object for SourceUploadedUserSourceInfo
```powershell
New-AzSpringAppDeploymentSourceUploadedObject
```

```output
RelativePath Version ArtifactSelector RuntimeVersion
------------ ------- ---------------- --------------
<default>
```

Create an in-memory object for SourceUploadedUserSourceInfo.

## PARAMETERS

### -ArtifactSelector
Selector for the artifact to be used for the deployment for multi-module projects.
This should be
        the relative path to the target module/project.

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

### -RuntimeVersion
Runtime version of the source file.

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

### -Version
Version of the source.

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20220401.SourceUploadedUserSourceInfo

## NOTES

ALIASES

## RELATED LINKS

