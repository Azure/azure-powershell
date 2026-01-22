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

Name              : postgresql-2024-01-15-11.log
CreatedTime       : 2024-01-15T11:00:00Z
LastModifiedTime  : 2024-01-15T11:59:59Z
SizeInKB          : 743
Type              : Error
Url               : https://prodstorageaccount.blob.core.windows.net/logs/postgresql-2024-01-15-11.log
```

Retrieves captured log files for a specific time range.

