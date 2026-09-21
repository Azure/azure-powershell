### Example 1: List all bookshelves in a subscription
```powershell
Get-AzDiscoveryBookshelf
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-bookshelf    my-rg
westus2     test-bookshelf  test-rg
```

Lists all Discovery bookshelves in the current subscription.

### Example 2: Get a specific bookshelf by name
```powershell
Get-AzDiscoveryBookshelf -ResourceGroupName "my-rg" -Name "my-bookshelf"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-bookshelf    my-rg
```

Gets a specific Discovery bookshelf by name and resource group.
