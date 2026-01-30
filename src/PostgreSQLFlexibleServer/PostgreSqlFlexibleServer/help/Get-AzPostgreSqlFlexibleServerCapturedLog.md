---
external help file: Az.PostgreSqlFlexibleServer-help.xml
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
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all captured logs for download in a server.

## EXAMPLES

### Example 1: List all captured logs for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerCapturedLog -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
LogType    Size(KB) CreatedTime         LastModifiedTime     DownloadUrl
-------    -------- -----------         ----------------     -----------
postgresql 1024     2025-01-22T08:00:00Z 2025-01-22T09:30:00Z https://logs.../postgresql_2025-01-22.log
error      256      2025-01-22T08:00:00Z 2025-01-22T09:15:00Z https://logs.../error_2025-01-22.log
```

Lists all captured log files available for the specified PostgreSQL Flexible Server.

### Example 2: Get specific log files by type and date range
```powershell
Get-AzPostgreSqlFlexibleServerCapturedLog -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -LogType "postgresql" -StartTime "2025-01-21T00:00:00Z" -EndTime "2025-01-22T00:00:00Z"
```

```output
LogType    Size(KB) CreatedTime         LastModifiedTime     DownloadUrl
-------    -------- -----------         ----------------     -----------
postgresql 2048     2025-01-21T00:00:00Z 2025-01-21T23:59:59Z https://logs.../postgresql_2025-01-21.log
postgresql 1024     2025-01-21T12:00:00Z 2025-01-21T23:30:00Z https://logs.../postgresql_2025-01-21_12.log
```

Retrieves PostgreSQL log files captured within a specific date range for analysis and troubleshooting.

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
