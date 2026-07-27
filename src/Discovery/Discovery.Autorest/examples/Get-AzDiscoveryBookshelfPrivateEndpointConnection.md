### Example 1: List private endpoint connections for a bookshelf
```powershell
Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Lists all private endpoint connections for the specified bookshelf.
