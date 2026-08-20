### Example 1: Update a workspace with tags
```powershell
Update-AzDiscoveryWorkspace -ResourceGroupName "my-rg" -Name "my-workspace" -Tag @{Environment="Production"}
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-workspace    my-rg                Succeeded
```

Updates the tags of an existing Discovery workspace.
