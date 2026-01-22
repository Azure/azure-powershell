---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverprivatednszonesuffix
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix

## SYNOPSIS
Gets the private DNS zone suffix.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the private DNS zone suffix.

## EXAMPLES

### Example 1: Get the private DNS zone suffix for a location
```powershell
Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix -Location "East US"
```

```output
Location           : East US
PrivateDnsZoneSuffix : private.postgres.database.azure.com
Description        : Private DNS zone suffix for PostgreSQL Flexible Servers in East US
```

Retrieves the private DNS zone suffix for PostgreSQL Flexible Servers in the East US region.

### Example 2: Get private DNS zone suffix for a different region
```powershell
Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix -Location "West Europe"
```

```output
Location           : West Europe
PrivateDnsZoneSuffix : private.postgres.database.azure.com
Description        : Private DNS zone suffix for PostgreSQL Flexible Servers in West Europe
```

Retrieves the private DNS zone suffix for PostgreSQL Flexible Servers in the West Europe region.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### System.String

## NOTES

## RELATED LINKS

