### Example 1: Create a new workspace
```powershell
New-AzDiscoveryWorkspace -ResourceGroupName "my-rg" -Name "my-workspace" -Location "eastus" -SupercomputerId @("/subscriptions/{subId}/resourceGroups/my-rg/providers/Microsoft.Discovery/supercomputers/my-supercomputer")
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-workspace    my-rg                Succeeded
```

Creates a new Discovery workspace associated with a supercomputer.
