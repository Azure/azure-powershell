### Example 1: Create a new storage container
```powershell
New-AzDiscoveryStorageContainer -ResourceGroupName "my-rg" -Name "my-container" -Location "eastus"
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-container        my-rg                Succeeded
```

Creates a new Discovery storage container.
