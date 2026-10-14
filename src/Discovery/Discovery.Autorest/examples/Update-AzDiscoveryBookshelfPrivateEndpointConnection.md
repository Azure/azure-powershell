### Example 1: Update a private endpoint connection status
```powershell
Update-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf" -PrivateEndpointConnectionName "my-pe-connection" -PrivateLinkServiceConnectionStateStatus "Approved" -PrivateLinkServiceConnectionStateDescription "Approved"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Updates an existing private endpoint connection for the bookshelf.
