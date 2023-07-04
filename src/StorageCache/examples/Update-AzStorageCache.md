### Example 1: Update a cache instance.
```powershell
Update-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -Tag @{"123"="abc"}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Update a cache instance.

### Example 2: Update a cache instance.
```powershell
Update-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-management-identity" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault" -CacheSizeGb "3072" -Subnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/azps-vnetwork-sub-pub" -SkuName "Standard_2G" -Zone 1
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Update a cache instance.