---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverquotausage
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerQuotaUsage

## SYNOPSIS
Get quota usages at specified location in a given subscription.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerQuotaUsage -LocationName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get quota usages at specified location in a given subscription.

## EXAMPLES

### Example 1: Get quota usage for a location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -Location "East US"
```

```output
Name         : PostgreSQL Flexible Servers
Location     : East US
CurrentValue : 5
Limit        : 20
Unit         : Count
Description  : Number of PostgreSQL Flexible Servers in East US region

Name         : Total Cores
Location     : East US
CurrentValue : 16
Limit        : 100
Unit         : Cores
Description  : Total vCore quota for PostgreSQL Flexible Servers

Name         : Storage
Location     : East US
CurrentValue : 512
Limit        : 65536
Unit         : GB
Description  : Total storage quota for PostgreSQL Flexible Servers
```

Retrieves quota usage information for PostgreSQL Flexible Servers in the East US region.

### Example 2: Get quota usage for a different location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -Location "West Europe"
```

```output
Name         : PostgreSQL Flexible Servers
Location     : West Europe
CurrentValue : 12
Limit        : 20
Unit         : Count
Description  : Number of PostgreSQL Flexible Servers in West Europe region

Name         : Total Cores
Location     : West Europe
CurrentValue : 48
Limit        : 100
Unit         : Cores
Description  : Total vCore quota for PostgreSQL Flexible Servers
```

Retrieves quota usage information for PostgreSQL Flexible Servers in the West Europe region.

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

### -LocationName
The name of the location.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IQuotaUsage

## NOTES

## RELATED LINKS

