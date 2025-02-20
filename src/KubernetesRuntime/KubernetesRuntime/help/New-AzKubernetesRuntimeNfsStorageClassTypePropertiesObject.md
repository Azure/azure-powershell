---
external help file: Az.KubernetesRuntime-help.xml
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/Az.KubernetesRuntime/new-azkubernetesruntimenfsstorageclasstypepropertiesobject
schema: 2.0.0
---

# New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject

## SYNOPSIS
Create an in-memory object for NfsStorageClassTypeProperties.

## SYNTAX

```
New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject -Server <String> -Share <String>
 [-MountPermission <String>] [-OnDelete <String>] [-SubDir <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NfsStorageClassTypeProperties.

## EXAMPLES

### Example 1: Create a NfsStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject `
    -Server "0.0.0.0" `
    -Share "/share" `
    -MountPermission "777" `
    -OnDelete "Delete" `
    -SubDir "subdir"
```

Create a `NfsStorageClassTypeProperties` object.

## PARAMETERS

### -MountPermission
Mounted folder permissions.
Default is 0.
If set as non-zero, driver will perform chmod after mount.

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

### -OnDelete
The action to take when a NFS volume is deleted.
Default is Delete.

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

### -Server
NFS Server.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Share
NFS share.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubDir
Sub directory under share.
If the sub directory doesn't exist, driver will create it.

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.NfsStorageClassTypeProperties

## NOTES

## RELATED LINKS
