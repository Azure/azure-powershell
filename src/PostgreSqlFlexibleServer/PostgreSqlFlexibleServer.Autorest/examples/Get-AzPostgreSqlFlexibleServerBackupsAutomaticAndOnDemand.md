### Example 1: List all backups in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                           BackupType           CompletedTime             Source
----                           ----------           -------------             ------
backup_639145838028276096      Full                 3/22/2026 3:03:23 AM      Automatic
backup_639146702636854494      Full                 3/23/2026 3:04:24 AM      Automatic
example-on-demand-backup-01    Customer On-Demand   5/23/2026 9:36:13 PM      Customer Initiated
backup_639149035518395681      Full                 3/24/2026 7:52:32 PM      Automatic
backup_639149900283518862      Full                 3/25/2026 7:53:49 PM      Automatic
example-on-demand-backup-02    Customer On-Demand   3/25/2026 9:36:13 PM      Customer Initiated
```

Lists all automatic and on demand backups in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one backup in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -BackupName example-on-demand-backup-02
```

```output
Name                           BackupType           CompletedTime             Source
----                           ----------           -------------             ------
example-on-demand-backup-02    Customer On-Demand   5/23/2026 9:36:13 PM      Customer Initiated
```

Gets one automatic and on demand backup in an Azure Database for PostgreSQL flexible server with backup name, server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
