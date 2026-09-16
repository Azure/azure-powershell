### Example 1: Update a supercomputer with tags
```powershell
Update-AzDiscoverySupercomputer -ResourceGroupName "my-rg" -Name "my-supercomputer" -Tag @{Environment="Production"}
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-supercomputer    my-rg                Succeeded
```

Updates the tags of an existing Discovery supercomputer.
