### Example 1: Update a tool with tags
```powershell
Update-AzDiscoveryTool -ResourceGroupName "my-rg" -Name "my-tool" -Tag @{Environment="Production"}
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-tool     my-rg                Succeeded
```

Updates the tags of an existing Discovery tool.
