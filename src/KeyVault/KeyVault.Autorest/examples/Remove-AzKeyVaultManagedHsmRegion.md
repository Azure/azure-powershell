### Example 1: Remove a region for Managed HSM
```powershell
Remove-AzKeyVaultManagedHsmRegion -HsmName testmhsm -ResourceGroupName test-rg -Region eastus2 -PassThru
```

```output
IsPrimary Name   ProvisioningState
--------- ----   -----------------
True      eastus Succeeded
False     westus Succeeded
```

This command removes `eastus2` from region extension for Managed HSM named `testmhsm`.