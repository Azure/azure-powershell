---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonSrmPropertiesObject
schema: 2.0.0
---

# New-AzVMwareAddonSrmPropertiesObject

## SYNOPSIS
Create an Srm object for Addon

## SYNTAX

```
New-AzVMwareAddonSrmPropertiesObject -LicenseKey <String> [<CommonParameters>]
```

## DESCRIPTION
Create an Srm object for Addon

## EXAMPLES

### Example 1: Create an Srm object for Addon
```powershell
PS C:\> New-AzVMwareAddonSrmPropertiesObject -LicenseKey "YourLicenseKeyValue"

AddonType ProvisioningState LicenseKey
--------- ----------------- ----------
SRM                         YourLicenseKeyValue
```

Create an Srm object for Addon

## PARAMETERS

### -LicenseKey
The Site Recovery Manager (SRM) license.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.AddonSrmProperties

## NOTES

ALIASES

## RELATED LINKS

