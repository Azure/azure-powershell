### Example 1: Create or update a cache.
```powershell
New-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -Location eastus -CacheSizeGb "3072" -Subnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache_2/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "Standard_2G" -Zone 1
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Create or update a cache.

### Example 2: Create or update a cache.
```powershell
New-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-management-identity" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault" -Location eastus -CacheSizeGb "3072" -Subnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "Standard_2G" -Zone 1
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Create or update a cache.