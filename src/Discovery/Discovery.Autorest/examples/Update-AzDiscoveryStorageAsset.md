### Example 1: Update a storage asset with tags
```powershell
Update-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container" -Name "my-asset" -Tag @{Environment="Production"}
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-asset        my-rg                Succeeded
```

Updates the tags of an existing storage asset.
