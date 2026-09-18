### Example 1: Update a bookshelf with tags
```powershell
Update-AzDiscoveryBookshelf -ResourceGroupName "my-rg" -Name "my-bookshelf" -Tag @{Environment="Production"}
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-bookshelf    my-rg                Succeeded
```

Updates the tags of an existing Discovery bookshelf.
