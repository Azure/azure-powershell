### Example 1: Remove one on demand backup in a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -BackupName example-backup
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

Removes one on demand backups in an Azure Database for PostgreSQL flexible server with backup name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
