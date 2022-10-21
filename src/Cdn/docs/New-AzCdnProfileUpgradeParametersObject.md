---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.Cdn/new-AzCdnProfileUpgradeParametersObject
schema: 2.0.0
---

# New-AzCdnProfileUpgradeParametersObject

## SYNOPSIS
Create an in-memory object for ProfileUpgradeParameters.

## SYNTAX

```
New-AzCdnProfileUpgradeParametersObject -WafMappingList <IProfileChangeSkuWafMapping[]> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProfileUpgradeParameters.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -WafMappingList
Web Application Firewall (WAF) and security policy mapping for the profile upgrade.
To construct, see NOTES section for WAFMAPPINGLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfileChangeSkuWafMapping[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.ProfileUpgradeParameters

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`WAFMAPPINGLIST <IProfileChangeSkuWafMapping[]>`: Web Application Firewall (WAF) and security policy mapping for the profile upgrade.
  - `SecurityPolicyName <String>`: The security policy name.
  - `[ChangeToWafPolicyId <String>]`: Resource ID.

## RELATED LINKS

