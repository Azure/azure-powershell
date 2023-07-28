---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/Az.Spring/new-azspringappdeploymentnetcorezipuploadedobject
schema: 2.0.0
---

# New-AzSpringAppDeploymentNetCoreZipUploadedObject

## SYNOPSIS
Create an in-memory object for NetCoreZipUploadedUserSourceInfo.

## SYNTAX

```
New-AzSpringAppDeploymentNetCoreZipUploadedObject [-MainEntryPath <String>] [-RuntimeVersion <String>]
 [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetCoreZipUploadedUserSourceInfo.

## EXAMPLES

### Example 1: Create an in-memory object for NetCoreZipUploadedUserSourceInfo
```powershell
New-AzSpringAppDeploymentNetCoreZipUploadedObject
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.NetCoreZipUploadedUserSourceInfo

## NOTES

## RELATED LINKS

