---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonVrPropertiesObject
schema: 2.0.0
---

# New-AzVMwareAddonVrPropertiesObject

## SYNOPSIS
Create a Vr object for Addon

## SYNTAX

```
New-AzVMwareAddonVrPropertiesObject -VrsCount <Int32> [<CommonParameters>]
```

## DESCRIPTION
Create a Vr object for Addon

## EXAMPLES

### Example 1: Create a Vr object for Addon
```powershell
PS C:\> New-AzVMwareAddonVrPropertiesObject -AddonType VR -VrsCount 2

AddonType ProvisioningState VrsCount
--------- ----------------- --------
VR                          2
```

Create a Vr object for Addon

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.AddonVrProperties

## NOTES

ALIASES

## RELATED LINKS

