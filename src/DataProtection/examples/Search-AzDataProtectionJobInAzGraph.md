### Example 1: Get all jobs in a certain time range
```powershell
$endtime = Get-Date
$starttime = $endtime.AddHours(-5)
Search-AzDataProtectionJobInAzGraph -Subscription "xxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -StartTime $starttime -EndTime $endtime
```

```output
Name                                 Type
----                                 ----
1c1d56c2-b21a-4038-ba46-3c1a0089e66a microsoft.dataprotection/backupvaults/backupjobs
79f2804d-a39d-487e-91b5-f2eceffcbb7a microsoft.dataprotection/backupvaults/backupjobs
96238abd-6ff3-48e0-8c07-0eabd6928a17 microsoft.dataprotection/backupvaults/backupjobs
```

This command gets all jobs in a vault in last 5 hours.

### Example 2: Get all jobs of a certain operation type
```powershell
Search-AzDataProtectionJobInAzGraph -Subscription "xxxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -Operation OnDemandBackup
```

```output
Name                                 Type
----                                 ----
11bc277d-9448-446a-9e79-4721858524d6 microsoft.dataprotection/backupvaults/backupjobs
16d7b56a-e169-41d1-aa10-cafcc19c8e12 microsoft.dataprotection/backupvaults/backupjobs
1b0b17e3-398f-4265-9d03-ffc1e21fa73a microsoft.dataprotection/backupvaults/backupjobs
```

This command gets all ondemand backup jobs in a vault.

