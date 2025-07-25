### Example 1: Update an AML file system instance.
```powershell
Update-AzStorageCacheAmlFileSystem -Name azps-cache-fs -ResourceGroupName azps_test_gp_storagecache -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -MaintenanceWindowDayOfWeek 'Monday' -MaintenanceWindowTimeOfDayUtc "03:00" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault"
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   azps_test_gp_storagecache Available   AMLFS-Durable-Premium-250
```

Update an AML file system instance.