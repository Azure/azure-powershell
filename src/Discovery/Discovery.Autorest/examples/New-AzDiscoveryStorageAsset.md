### Example 1: Create a new storage asset
```powershell
New-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container" -Name "my-asset" -Location "eastus"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-asset        my-rg                Succeeded
```

Creates a new storage asset under the specified storage container.
