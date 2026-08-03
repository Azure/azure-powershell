### Example 1: Update a project with tags
```powershell
Update-AzDiscoveryProject -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-project" -Tag @{Environment="Production"}
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-project      my-rg                Succeeded
```

Updates the tags of an existing project.
