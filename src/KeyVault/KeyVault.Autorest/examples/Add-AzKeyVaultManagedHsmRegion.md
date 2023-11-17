### Example 1: Add a region for Managed HSM
```powershell
Add-AzKeyVaultManagedHsmRegion -HsmName testmhsm -ResourceGroupName test-rg -Region eastus2
```

```output
IsPrimary Name   ProvisioningState
--------- ----   -----------------
True      eastus Succeeded
False     eastus2 Succeeded
```

This command adds `eastus` as the region extension for Managed HSM named `testmhsm`.