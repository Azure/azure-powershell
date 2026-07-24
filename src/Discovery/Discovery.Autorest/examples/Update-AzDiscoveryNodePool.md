### Example 1: Update a node pool
```powershell
Update-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer" -Name "my-pool" -Tag @{Environment="Production"}
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-pool     my-rg                Succeeded
```

Updates the tags of an existing node pool.
