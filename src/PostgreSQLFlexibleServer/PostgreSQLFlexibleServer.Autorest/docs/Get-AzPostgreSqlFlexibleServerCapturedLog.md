---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservercapturedlog
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerCapturedLog

## SYNOPSIS
Lists all captured logs for download in a server.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerCapturedLog -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all captured logs for download in a server.

## EXAMPLES

### Example 1: Get all captured logs for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerCapturedLog -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              : postgresql-2024-01-15-10.log
CreatedTime       : 2024-01-15T10:00:00Z
LastModifiedTime  : 2024-01-15T10:59:59Z
SizeInKB          : 1024
Type              : Error
Url               : https://mystorageaccount.blob.core.windows.net/logs/postgresql-2024-01-15-10.log

Name              : postgresql-2024-01-15-09.log
CreatedTime       : 2024-01-15T09:00:00Z
LastModifiedTime  : 2024-01-15T09:59:59Z
SizeInKB          : 856
Type              : Error
Url               : https://mystorageaccount.blob.core.windows.net/logs/postgresql-2024-01-15-09.log
```

Retrieves all captured log files for the specified PostgreSQL Flexible Server.

### Example 2: Get captured logs for a specific time range
```powershell
Get-AzPostgreSqlFlexibleServerCapturedLog -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -FromTimeStamp "2024-01-15T00:00:00Z" -ToTimeStamp "2024-01-15T12:00:00Z"
```

```output
Name              : postgresql-2024-01-15-10.log
CreatedTime       : 2024-01-15T10:00:00Z
LastModifiedTime  : 2024-01-15T10:59:59Z
SizeInKB          : 1024
Type              : Error
Url               : https://prodstorageaccount.blob.core.windows.net/logs/postgresql-2024-01-15-10.log
```

Retrieves captured log files for a specific time range.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapturedLog

## NOTES

## RELATED LINKS

