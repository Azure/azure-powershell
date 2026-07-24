### Example 1: Create a new project
```powershell
New-AzDiscoveryProject -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-project" -Location "eastus"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-project      my-rg                Succeeded
```

Creates a new Discovery project under the specified workspace.
