---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.Cdn/new-AzCdnMigrationWebApplicationFirewallMappingObject
schema: 2.0.0
---

# New-AzCdnMigrationWebApplicationFirewallMappingObject

## SYNOPSIS
Create an in-memory object for MigrationWebApplicationFirewallMapping.

## SYNTAX

```
New-AzCdnMigrationWebApplicationFirewallMappingObject [-MigratedFromId <String>] [-MigratedToId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MigrationWebApplicationFirewallMapping.

## EXAMPLES

### Example 1: Create an in-memory object for MigrationWebApplicationFirewallMapping.
```powershell
New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId1 -MigratedToId wafId2
```

```output
MigratedFromId MigratedToId
-------------- ------------
wafId1         wafId2
```

Create an in-memory object for MigrationWebApplicationFirewallMapping.

### Example 2: Create an in-memory object for MigrationWebApplicationFirewallMappings.
```powershell
$waf1 = New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId1 -MigratedToId wafId2
$waf2 = New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId11 -MigratedToId wafId22

$wafs = @($waf1, $waf2)
$wafs 
```

MigratedFromId MigratedToId
-------------- ------------
wafId1         wafId2
wafId11        wafId22
```output

## PARAMETERS

### -MigratedFromId
Resource ID.

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

### -MigratedToId
Resource ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20220501Preview.MigrationWebApplicationFirewallMapping

## NOTES

ALIASES

## RELATED LINKS

