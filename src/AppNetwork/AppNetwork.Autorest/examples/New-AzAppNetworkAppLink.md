### Example 1: Create an Application Network resource
```powershell
New-AzAppNetworkAppLink -Name appnet-test-01 -ResourceGroupName test_rg -Location westus2
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Creates an Azure Kubernetes Application Network resource named `appnet-test-01` in the `test_rg` resource group.

### Example 2: Create an Application Network resource with a system-assigned identity
```powershell
New-AzAppNetworkAppLink -Name appnet-test-01 -ResourceGroupName test_rg -Location westus2 -EnableSystemAssignedIdentity
```

```output
Name           Location ProvisioningState IdentityType   ResourceGroupName
----           -------- ----------------- ------------   -----------------
appnet-test-01 westus2  Succeeded         SystemAssigned test_rg
```

Creates an Application Network resource with a system-assigned managed identity enabled.
