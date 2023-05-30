---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject
schema: 2.0.0
---

# New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject

## SYNOPSIS
Create an in-memory object for MigrationWebApplicationFirewallMapping.

## SYNTAX

```
New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject [-MigratedFromId <String>]
 [-MigratedToId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MigrationWebApplicationFirewallMapping.

## EXAMPLES

### Example 1: Create an in-memory object for MigrationWebApplicationFirewallMapping
```powershell
New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId migrateFromId -MigratedToId migrateToId
```

```output
MigratedFromId MigratedToId
-------------- ------------
migrateFromId  migrateToId
```

Create an in-memory object for MigrationWebApplicationFirewallMapping

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.MigrationWebApplicationFirewallMapping

## NOTES

ALIASES

## RELATED LINKS

