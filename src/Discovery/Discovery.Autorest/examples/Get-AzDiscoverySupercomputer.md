### Example 1: List all supercomputers in a resource group
```powershell
Get-AzDiscoverySupercomputer -ResourceGroupName "my-rg"
```

```output
Location    Name                ResourceGroupName
--------    ----                -----------------
eastus      my-supercomputer    my-rg
```

Lists all Discovery supercomputers in the specified resource group.

### Example 2: Get a specific supercomputer
```powershell
Get-AzDiscoverySupercomputer -ResourceGroupName "my-rg" -Name "my-supercomputer"
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-supercomputer    my-rg                Succeeded
```

Gets a specific Discovery supercomputer by name.
