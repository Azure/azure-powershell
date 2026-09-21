### Example 1: Create a new bookshelf
```powershell
New-AzDiscoveryBookshelf -ResourceGroupName "my-rg" -Name "my-bookshelf" -Location "eastus"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-bookshelf    my-rg                Succeeded
```

Creates a new Discovery bookshelf in the specified resource group and location.
