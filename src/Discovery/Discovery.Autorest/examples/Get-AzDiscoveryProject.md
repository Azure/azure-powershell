### Example 1: List all projects in a workspace
```powershell
Get-AzDiscoveryProject -ResourceGroupName "my-rg" -WorkspaceName "my-workspace"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-project      my-rg
```

Lists all projects under the specified workspace.

### Example 2: Get a specific project
```powershell
Get-AzDiscoveryProject -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-project"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-project      my-rg                Succeeded
```

Gets a specific project by name.
