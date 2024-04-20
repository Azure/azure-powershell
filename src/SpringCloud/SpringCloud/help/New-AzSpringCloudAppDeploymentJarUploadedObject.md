---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudAppDeploymentJarUploadedObject
schema: 2.0.0
---

# New-AzSpringCloudAppDeploymentJarUploadedObject

## SYNOPSIS
Create an in-memory object for JarUploadedUserSourceInfo.

## SYNTAX

```
New-AzSpringCloudAppDeploymentJarUploadedObject [-JvmOption <String>] [-RuntimeVersion <String>]
 [-Version <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for JarUploadedUserSourceInfo.

## EXAMPLES

### Example 1: Create an in-memory object for JarUploadedUserSourceInfo
```powershell
New-AzSpringCloudAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
```

```output
RelativePath                     Version JvmOption RuntimeVersion
------------                     ------- --------- --------------
/resource/asd451212asdasd578454d                   Java_8
```

Create an in-memory object for JarUploadedUserSourceInfo.

## PARAMETERS

### -JvmOption
JVM parameter.

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
Runtime version of the Jar file.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.JarUploadedUserSourceInfo

## NOTES

## RELATED LINKS
