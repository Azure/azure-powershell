### Example 1: Create a new tool
```powershell
New-AzDiscoveryTool -ResourceGroupName "my-rg" -Name "my-tool" -Location "eastus" -Version "1.0.0"
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-tool     my-rg                Succeeded
```

Creates a new Discovery tool.
