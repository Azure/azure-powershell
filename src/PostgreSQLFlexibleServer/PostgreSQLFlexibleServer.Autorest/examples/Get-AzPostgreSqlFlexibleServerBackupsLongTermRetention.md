### Example 1: List all long-term retention backups for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
Name                        Status      CreatedTime               ExpiryTime                SizeInBytes
----                        ------      -----------               ----------                -----------
ltr_backup_20240101_monthly Completed   2024-01-01T02:00:00.000Z  2025-01-01T02:00:00.000Z  2147483648
ltr_backup_20240115_weekly  Completed   2024-01-15T02:00:00.000Z  2024-04-15T02:00:00.000Z  2147483648
ltr_backup_20240120_daily   InProgress  2024-01-20T02:00:00.000Z  2024-02-20T02:00:00.000Z  -
```

Lists all long-term retention backup operations for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific long-term retention backup by name
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myresourcegroup" -ServerName "myserver" -BackupName "ltr_backup_20240101_monthly"
```

```output
Name                        Status    CreatedTime               ExpiryTime                SizeInBytes RetentionPolicy
----                        ------    -----------               ----------                ----------- ---------------
ltr_backup_20240101_monthly Completed 2024-01-01T02:00:00.000Z  2025-01-01T02:00:00.000Z  2147483648  Monthly
```

Gets information about the specific long-term retention backup named 'ltr_backup_20240101_monthly'.

