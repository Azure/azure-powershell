---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringcustompersistentdiskresourceobject
schema: 2.0.0
---

# New-AzSpringCustomPersistentDiskResourceObject

## SYNOPSIS
Create an in-memory object for CustomPersistentDiskResource.

## SYNTAX

```
New-AzSpringCustomPersistentDiskResourceObject -StorageId <String>
 [-CustomPersistentDiskPropertyEnableSubPath <Boolean>] [-CustomPersistentDiskPropertyMountOption <String[]>]
 [-CustomPersistentDiskPropertyMountPath <String>] [-CustomPersistentDiskPropertyReadOnly <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomPersistentDiskResource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -CustomPersistentDiskPropertyEnableSubPath
If set to true, it will create and mount a dedicated directory for every individual app instance.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomPersistentDiskPropertyMountOption
These are the mount options for a persistent disk.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomPersistentDiskPropertyMountPath
The mount path of the persistent disk.

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

### -CustomPersistentDiskPropertyReadOnly
Indicates whether the persistent disk is a readOnly one.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageId
The resource id of Azure Spring Apps Storage resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.CustomPersistentDiskResource

## NOTES

## RELATED LINKS

