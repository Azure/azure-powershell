---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonSrmPropertiesObject
schema: 2.0.0
---

# New-AzVMwareAddonSrmPropertiesObject

## SYNOPSIS
Create a in-memory object for AddonSrmProperties

## SYNTAX

```
New-AzVMwareAddonSrmPropertiesObject -AddonType <AddonType> -LicenseKey <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for AddonSrmProperties

## EXAMPLES

### Example 1: Create a in-memory object for AddonSrmProperties
```powershell
PS C:\> New-AzVMwareAddonSrmPropertiesObject  -AddonType SRM -LicenseKey "LicenseKeyValue"

AddonType ProvisioningState LicenseKey
--------- ----------------- ----------
SRM                         LicenseKeyValue
```

Create a in-memory object for AddonSrmProperties

## PARAMETERS

### -AddonType
The type of private cloud addon.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.AddonType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

