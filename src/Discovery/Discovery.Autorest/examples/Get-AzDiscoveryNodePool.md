### Example 1: List all node pools for a supercomputer
```powershell
Get-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer"
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus      my-pool     my-rg
```

Lists all node pools under the specified supercomputer.

### Example 2: Get a specific node pool
```powershell
Get-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer" -Name "my-pool"
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-pool     my-rg                Succeeded
```

Gets a specific node pool by name.
