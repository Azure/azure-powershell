### Example 1: Get All backup Jobs in a backup vault
```powershell
Get-AzDataProtectionjob -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
```

```output
Name                                 Type
----                                 ----
a6a4879d-f914-4174-b129-0e27da8a4fb0 Microsoft.DataProtection/backupVaults/backupJobs
1a402664-a245-4a9d-8bb5-a6bafbb40d26 Microsoft.DataProtection/backupVaults/backupJobs
672564f7-1f91-46e2-a0ca-4fb1dc977a1c Microsoft.DataProtection/backupVaults/backupJobs
1653a7b4-8ce4-457e-8084-dc1c9d9e4106 Microsoft.DataProtection/backupVaults/backupJobs
9f21c438-ca0d-45c1-88fe-79f08a8342c7 Microsoft.DataProtection/backupVaults/backupJobs
736bab4d-480f-49f8-92ea-57c5ff203c33 Microsoft.DataProtection/backupVaults/backupJobs
```

This command gets all the backup jobs in a given backup vault.

### Example 2: Get a single Job 
```powershell
Get-AzDataProtectionjob -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Id 4abaea8c-f53a-4bb1-9963-59f96b597165
```

```output
Name                                 Type
----                                 ----
4abaea8c-f53a-4bb1-9963-59f96b597165 Microsoft.DataProtection/backupVaults/backupJobs
```

This command returns a single job entity with given Id.

