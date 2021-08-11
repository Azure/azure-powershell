---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonHcxPropertiesObject
schema: 2.0.0
---

# New-AzVMwareAddonHcxPropertiesObject

## SYNOPSIS
Create a in-memory object for AddonHcxProperties

## SYNTAX

```
New-AzVMwareAddonHcxPropertiesObject -AddonType <AddonType> -Offer <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for AddonHcxProperties

## EXAMPLES

### Example 1: Create a in-memory object for AddonHcxProperties
```powershell
PS C:\> New-AzVMwareAddonHcxPropertiesObject -AddonType HCX -Offer "YourOfferValue"

AddonType ProvisioningState Offer
--------- ----------------- -----
HCX1                        YourOfferValue
```

Create a in-memory object for AddonHcxProperties

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

### -Offer
The HCX offer, example VMware MaaS Cloud Provider (Enterprise).

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.AddonHcxProperties

## NOTES

ALIASES

## RELATED LINKS

