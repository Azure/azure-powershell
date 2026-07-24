### Example 1: List all tools in a resource group
```powershell
Get-AzDiscoveryTool -ResourceGroupName "my-rg"
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus      my-tool     my-rg
```

Lists all Discovery tools in the specified resource group.

### Example 2: Get a specific tool
```powershell
Get-AzDiscoveryTool -ResourceGroupName "my-rg" -Name "my-tool"
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-tool     my-rg                Succeeded
```

Gets a specific Discovery tool by name.
