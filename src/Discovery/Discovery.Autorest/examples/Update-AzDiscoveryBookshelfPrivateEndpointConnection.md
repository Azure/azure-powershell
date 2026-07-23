### Example 1: Update a private endpoint connection status
```powershell
Update-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf" -Name "my-pe-connection" -Tag @{Environment="Production"}
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Updates an existing private endpoint connection for the bookshelf.
