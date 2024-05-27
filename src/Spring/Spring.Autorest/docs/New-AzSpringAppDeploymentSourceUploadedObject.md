---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringappdeploymentsourceuploadedobject
schema: 2.0.0
---

# New-AzSpringAppDeploymentSourceUploadedObject

## SYNOPSIS
Create an in-memory object for SourceUploadedUserSourceInfo.

## SYNTAX

```
New-AzSpringAppDeploymentSourceUploadedObject [-ArtifactSelector <String>] [-RelativePath <String>]
 [-RuntimeVersion <String>] [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SourceUploadedUserSourceInfo.

## EXAMPLES

### Example 1: Create an in-memory object for SourceUploadedUserSourceInfo.
```powershell
New-AzSpringAppDeploymentSourceUploadedObject -ArtifactSelector sub-module-1 -RuntimeVersion 1.0 -RelativePath "resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc" -Version 1.0
```

```output
ArtifactSelector : sub-module-1
RelativePath     : resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc
RuntimeVersion   : 1.0
Type             : Source
Version          : 1.0
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

### -RelativePath
Relative path of the storage which stores the source.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.SourceUploadedUserSourceInfo

## NOTES

## RELATED LINKS

