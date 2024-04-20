---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudAppDeploymentNetCoreZipUploadedObject
schema: 2.0.0
---

# New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject

## SYNOPSIS
Create an in-memory object for NetCoreZipUploadedUserSourceInfo.

## SYNTAX

```
New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject [-MainEntryPath <String>] [-RuntimeVersion <String>]
 [-Version <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetCoreZipUploadedUserSourceInfo.

## EXAMPLES

### Example 1: Create an in-memory object for NetCoreZipUploadedUserSourceInfo
```powershell
New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject
```

```output
RelativePath Version NetCoreMainEntryPath RuntimeVersion
------------ ------- -------------------- --------------
<default>
```

Create an in-memory object for NetCoreZipUploadedUserSourceInfo.

## PARAMETERS

### -MainEntryPath
The path to the .NET executable relative to zip root.

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

### -RuntimeVersion
Runtime version of the .Net file.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.NetCoreZipUploadedUserSourceInfo

## NOTES

## RELATED LINKS
