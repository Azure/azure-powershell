### Example 1: Update a private endpoint connection
```powershell
Update-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -PrivateEndpointConnectionName "my-pe-connection" -PrivateLinkServiceConnectionStateStatus "Approved" -PrivateLinkServiceConnectionStateDescription "Approved"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Updates an existing private endpoint connection for the workspace.
