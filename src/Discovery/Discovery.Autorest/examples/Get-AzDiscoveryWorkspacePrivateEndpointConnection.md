### Example 1: List private endpoint connections for a workspace
```powershell
Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName "my-rg" -WorkspaceName "my-workspace"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Lists all private endpoint connections for the specified workspace.
