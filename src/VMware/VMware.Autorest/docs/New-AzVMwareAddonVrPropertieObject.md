---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwareaddonvrpropertieobject
schema: 2.0.0
---

# New-AzVMwareAddonVrPropertieObject

## SYNOPSIS
Create an in-memory object for AddonVrProperties.

## SYNTAX

```
New-AzVMwareAddonVrPropertieObject -VrsCount <Int32> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AddonVrProperties.

## EXAMPLES

### Example 1: Create a local VR object for the Addon Property parameter
```powershell
New-AzVMwareAddonVrPropertieObject -VrsCount 2
```

```output
AddonType ProvisioningState VrsCount
--------- ----------------- --------
VR                                 2
```

Create a local VR object for the Addon Property parameter

## PARAMETERS

### -VrsCount
The vSphere Replication Server (VRS) count.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonVrProperties

## NOTES

## RELATED LINKS

