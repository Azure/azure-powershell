### Example 1: List all workspaces in a resource group
```powershell
Get-AzDiscoveryWorkspace -ResourceGroupName "my-rg"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-workspace    my-rg
```

Lists all Discovery workspaces in the specified resource group.

### Example 2: Get a specific workspace
```powershell
Get-AzDiscoveryWorkspace -ResourceGroupName "my-rg" -Name "my-workspace"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-workspace    my-rg                Succeeded
```

Gets a specific Discovery workspace by name.
