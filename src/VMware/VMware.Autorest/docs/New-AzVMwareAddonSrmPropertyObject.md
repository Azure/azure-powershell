---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwareaddonsrmpropertyobject
schema: 2.0.0
---

# New-AzVMwareAddonSrmPropertyObject

## SYNOPSIS
Create an in-memory object for AddonSrmProperties.

## SYNTAX

```
New-AzVMwareAddonSrmPropertyObject [-LicenseKey <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AddonSrmProperties.

## EXAMPLES

### Example 1: Create a local SRM object for the Addon Property parameter
```powershell
New-AzVMwareAddonSrmPropertyObject -LicenseKey "YourLicenseKeyValue"
```

```output
AddonType LicenseKey          ProvisioningState
--------- ----------          -----------------
SRM       YourLicenseKeyValue
```

Create a local SRM object for the Addon Property parameter

## PARAMETERS

### -LicenseKey
The Site Recovery Manager (SRM) license.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonSrmProperties

## NOTES

## RELATED LINKS

