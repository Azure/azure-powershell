### Example 1: Create a new node pool
```powershell
New-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer" -Name "my-pool" -Location "eastus" -VMSize "Standard_D4s_v3" -MinNodeCount 1 -MaxNodeCount 10
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-pool     my-rg                Succeeded
```

Creates a new node pool under the specified supercomputer.
