### Example 1: list all regions for a specified Managed HSM
```powershell
Get-AzKeyVaultManagedHsmRegion -HsmName testmhsm -ResourceGroupName test-rg
```

```output
IsPrimary Name   ProvisioningState
--------- ----   -----------------
True      eastus Succeeded
False     westus Succeeded
```

This command lists all regions for Managed HSM named `testmhsm` in resource group `test-rg`.