### Example 1: Approve a private endpoint connection
```powershell
New-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf" -Name "my-pe-connection" -PrivateLinkServiceConnectionStateStatus "Approved" -PrivateLinkServiceConnectionStateDescription "Approved by admin"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Creates or approves a private endpoint connection for the specified bookshelf.
