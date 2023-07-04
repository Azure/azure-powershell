### Example 1: Create or update an AML file system.
```powershell
New-AzStorageCacheAmlFileSystem -Name azps-cache-fs -ResourceGroupName azps_test_gp_storagecache -Location eastus -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-management-identity" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault" -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/azps-vnetwork-sub-kv" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   AZPS_TEST_GP_STORAGECACHE Available   AMLFS-Durable-Premium-250
```

Create or update an AML file system.

### Example 2: Create or update an AML file system and setting HSM.
```powershell
New-AzStorageCacheAmlFileSystem -Name azps-cache-fs-hsm -ResourceGroupName azps_test_gp_storagecache -Location eastus -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1 -SettingContainer "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa/blobServices/default/containers/az-blob-login" -SettingImportPrefix "/" -SettingLoggingContainer "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa/blobServices/default/containers/az-blob"
```

```output
Name              Location ResourceGroupName         HealthState SkuName
----              -------- -----------------         ----------- -------
azps-cache-fs-hsm eastus   AZPS_TEST_GP_STORAGECACHE Available   AMLFS-Durable-Premium-250
```

Create or update an AML file system and setting HSM.