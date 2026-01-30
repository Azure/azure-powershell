### Example 1: List all backups for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
Name                          BackupType  CompletedTime             SizeInBytes
----                          ----------  -------------             -----------
automatic_20240115_100000     Automatic   2024-01-15T10:00:00.000Z  1073741824
ondemand_backup_20240115      OnDemand    2024-01-15T14:30:00.000Z  1157627904
automatic_20240116_100000     Automatic   2024-01-16T10:00:00.000Z  1073741824
```

Lists all automatic and on-demand backups for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific backup by name
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName "myresourcegroup" -ServerName "myserver" -BackupName "ondemand_backup_20240115"
```

```output
Name                     BackupType  CompletedTime             SizeInBytes Status
----                     ----------  -------------             ----------- ------
ondemand_backup_20240115 OnDemand    2024-01-15T14:30:00.000Z  1157627904  Completed
```

Gets information about the specific on-demand backup named 'ondemand_backup_20240115'.

