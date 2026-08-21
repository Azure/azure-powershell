### Example 1: List Application Networks in the current subscription
```powershell
Get-AzAppNetworkAppLink
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
appnet-test-02 eastus   Succeeded         other_rg
```

Lists all Application Network resources in the current subscription.

### Example 2: List Application Networks in a resource group
```powershell
Get-AzAppNetworkAppLink -ResourceGroupName test_rg
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Lists the Application Network resources in the `test_rg` resource group.

### Example 3: Get an Application Network resource
```powershell
Get-AzAppNetworkAppLink -Name appnet-test-01 -ResourceGroupName test_rg
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Gets the details of the Application Network resource named `appnet-test-01`.
