---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmvirtualdiskobject
schema: 2.0.0
---

# New-AzScVmmVirtualDiskObject

## SYNOPSIS
Create an in-memory object for VirtualDisk.

## SYNTAX

```
New-AzScVmmVirtualDiskObject [-Bus <Int32>] [-BusType <String>] [-CreateDiffDisk <String>] [-DiskId <String>]
 [-DiskSizeGb <Int32>] [-Lun <Int32>] [-Name <String>] [-StorageQoSPolicyId <String>]
 [-StorageQoSPolicyName <String>] [-TemplateDiskId <String>] [-VhdType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualDisk.

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

### -Bus
Gets or sets the disk bus.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusType
Gets or sets the disk bus type.

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

### -CreateDiffDisk
Gets or sets a value indicating diff disk.

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

### -DiskId
Gets or sets the disk id.

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

### -DiskSizeGb
Gets or sets the disk total size.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lun
Gets or sets the disk lun.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Gets or sets the name of the disk.

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

### -StorageQoSPolicyId
The ID of the QoS policy.

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

### -StorageQoSPolicyName
The name of the policy.

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

### -TemplateDiskId
Gets or sets the disk id in the template.

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

### -VhdType
Gets or sets the disk vhd type.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.VirtualDisk

## NOTES

## RELATED LINKS

