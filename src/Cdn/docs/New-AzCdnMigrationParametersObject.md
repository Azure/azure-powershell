---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.Cdn/new-AzCdnMigrationParametersObject
schema: 2.0.0
---

# New-AzCdnMigrationParametersObject

## SYNOPSIS
Create an in-memory object for MigrationParameters.

## SYNTAX

```
New-AzCdnMigrationParametersObject [-ClassicResourceReference <IResourceReference>]
 [-MigrationWebApplicationFirewallMapping <IMigrationWebApplicationFirewallMapping[]>] [-ProfileName <String>]
 [-Sku <ISku>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MigrationParameters.

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

### -ClassicResourceReference
Resource reference of the classic cdn profile or classic frontdoor that need to be migrated.
To construct, see NOTES section for CLASSICRESOURCEREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20220501Preview.IResourceReference
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationWebApplicationFirewallMapping
Waf mapping for the migrated profile.
To construct, see NOTES section for MIGRATIONWEBAPPLICATIONFIREWALLMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20220501Preview.IMigrationWebApplicationFirewallMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the new profile that need to be created.

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

### -Sku
Sku for the migration.
To construct, see NOTES section for SKU properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20220501Preview.ISku
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20220501Preview.MigrationParameters

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CLASSICRESOURCEREFERENCE <IResourceReference>`: Resource reference of the classic cdn profile or classic frontdoor that need to be migrated.
  - `[Id <String>]`: Resource ID.

`MIGRATIONWEBAPPLICATIONFIREWALLMAPPING <IMigrationWebApplicationFirewallMapping[]>`: Waf mapping for the migrated profile.
  - `[MigratedFromId <String>]`: Resource ID.
  - `[MigratedToId <String>]`: Resource ID.

`SKU <ISku>`: Sku for the migration.
  - `[Name <SkuName?>]`: Name of the pricing tier.

## RELATED LINKS

