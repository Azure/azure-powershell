### Example 1: Update a storage container with tags
```powershell
Update-AzDiscoveryStorageContainer -ResourceGroupName "my-rg" -Name "my-container" -Tag @{Environment="Production"}
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-container        my-rg                Succeeded
```

Updates the tags of an existing storage container.
