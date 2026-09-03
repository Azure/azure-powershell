### Example 1: Update the tags of an Application Network resource
```powershell
Update-AzAppNetwork -Name appnet-test-01 -ResourceGroupName test_rg -Tag @{ key2913 = 'test_tag' }
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Updates the tags of the Application Network resource named `appnet-test-01`.
