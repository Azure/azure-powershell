### Example 1: Start a long-term retention backup
```powershell
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -BackupInstanceName "ltr-backup-annual-2024" -BackupSetting @{retentionPeriod="P7Y"}
```

```output
Name              : ltr-backup-annual-2024
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
OperationType     : LtrBackup
Status            : InProgress
StartTime         : 2024-01-15T10:30:00Z
RetentionPeriod   : P7Y
```

Starts a long-term retention backup for the PostgreSQL Flexible Server with a 7-year retention period.

### Example 2: Start an LTR backup for compliance
```powershell
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -BackupInstanceName "compliance-backup-2024" -BackupSetting @{retentionPeriod="P10Y"; backupType="Full"}
```

```output
Name              : compliance-backup-2024
ServerName        : prod-postgresql-01
ResourceGroupName : production-rg
OperationType     : LtrBackup
Status            : InProgress
StartTime         : 2024-01-20T02:00:00Z
RetentionPeriod   : P10Y
BackupType        : Full
```

Starts a long-term retention backup for compliance purposes with a 10-year retention period.

