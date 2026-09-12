### Example 1: Replace an Application Network resource
```powershell
Set-AzAppNetwork -Name appnet-test-01 -ResourceGroupName test_rg -Location westus2 -EnableSystemAssignedIdentity -Tag @{ key2913 = 'test_tag' }
```

```output
Name           Location ProvisioningState IdentityType   ResourceGroupName
----           -------- ----------------- ------------   -----------------
appnet-test-01 westus2  Succeeded         SystemAssigned test_rg
```

Creates or replaces the Application Network resource named `appnet-test-01` with the specified location, identity, and tags.
