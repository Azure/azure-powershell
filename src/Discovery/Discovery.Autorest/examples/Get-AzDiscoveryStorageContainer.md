### Example 1: List all storage containers in a resource group
```powershell
Get-AzDiscoveryStorageContainer -ResourceGroupName "my-rg"
```

```output
Location    Name                ResourceGroupName
--------    ----                -----------------
eastus      my-container        my-rg
```

Lists all Discovery storage containers in the specified resource group.

### Example 2: Get a specific storage container
```powershell
Get-AzDiscoveryStorageContainer -ResourceGroupName "my-rg" -Name "my-container"
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-container        my-rg                Succeeded
```

Gets a specific storage container by name.
