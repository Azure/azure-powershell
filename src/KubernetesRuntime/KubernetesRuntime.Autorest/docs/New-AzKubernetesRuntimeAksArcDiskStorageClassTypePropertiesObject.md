---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/Az.KubernetesRuntime/new-azkubernetesruntimeaksarcdiskstorageclasstypepropertiesobject
schema: 2.0.0
---

# New-AzKubernetesRuntimeAksArcDiskStorageClassTypePropertiesObject

## SYNOPSIS
Create an in-memory object for AksArcDiskStorageClassTypeProperties.

## SYNTAX

```
New-AzKubernetesRuntimeAksArcDiskStorageClassTypePropertiesObject -StoragePathId <String> [-FsType <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AksArcDiskStorageClassTypeProperties.

## EXAMPLES

### Example 1: Create a AksArcDiskStorageClassTypeProperties
```powershell
$typeProperties = New-AzKubernetesRuntimeAksArcDiskStorageClassTypePropertiesObject `
    -StoragePathId /subscription/xxx/xxx
    -FsType ext4
```

Create a `AksArcDiskStorageClassTypeProperties` object with storage path Id and fs type.

## PARAMETERS

### -FsType
fsType parameter for the storage class.

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

### -StoragePathId
The id of the storage path.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.AksArcDiskStorageClassTypeProperties

## NOTES

## RELATED LINKS

