### Example 1: List all storage assets in a container
```powershell
Get-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-asset        my-rg
```

Lists all storage assets under the specified storage container.

### Example 2: Get a specific storage asset
```powershell
Get-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container" -Name "my-asset"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-asset        my-rg                Succeeded
```

Gets a specific storage asset by name.
