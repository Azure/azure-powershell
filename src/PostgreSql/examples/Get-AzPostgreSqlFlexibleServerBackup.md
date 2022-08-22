### Example 1: List all the backups for a given server
```powershell
Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

```output
Id                                                                                                                                                                            Name                      Type                                              BackupType CompletedTime         Source
--                                                                                                                                                                            ----                      ----                                              ---------- -------------         ------
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637953333961627768 backup_637953333961627768 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/5/2022 9:56:36 PM   Automatic
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637954198195749123 backup_637954198195749123 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/6/2022 9:56:59 PM   Automatic
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637955062430210149 backup_637955062430210149 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/7/2022 9:57:23 PM   Automatic
```

This cmdlet lists all the backups for a given server.

### Example 2: Show the details of a specific backup for a given server
```powershell
Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -BackupName backup_637953333961627768
```

```output
Id                                                                                                                                                                            Name                      Type                                              BackupType CompletedTime         Source
--                                                                                                                                                                            ----                      ----                                              ---------- -------------         ------
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637953333961627768 backup_637953333961627768 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/5/2022 9:56:36 PM   Automatic
```

This cmdlet shows the details of a specific backup for a given server.
