---
external help file: Az.PostgreSqlFlexibleServer-help.xml
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

### Example 1: Get quota usage for PostgreSQL Flexible Server in a location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -LocationName "East US"
```

```output
Name                        CurrentValue Limit Unit
----                        ------------ ----- ----
servers                     5            20    Count
vCores                      16           100   Count
storageGB                   512          10240 Count
```

Displays the current quota usage for PostgreSQL Flexible Servers in the East US region.

### Example 2: Check quota usage for a specific subscription and location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -LocationName "West Europe" -SubscriptionId "ssssssss-ssss-ssss-ssss-ssssssssssss"
```

```output
Name                        CurrentValue Limit Unit Description
----                        ------------ ----- ---- -----------
servers                     12           50    Count Maximum number of PostgreSQL Flexible Servers
vCores                      48           200   Count Total vCores across all servers
storageGB                   2048         51200 Count Total storage in GB across all servers
backupStorageGB             1024         10240 Count Backup storage usage in GB
```

Retrrieves detailed quota usage information for PostgreSQL Flexible Servers in a specific subscription and region.

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
