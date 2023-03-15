### Example 1: Update Virtual Network Resource
```powershell
Update-AzConnectedVMwareVNet -Name "test-vnet" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" 
-Tag @{"vnet"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vnet azcli-test-rg
```

This command update tag of a Virtual Network named `test-vnet` in a resource group named `azcli-test-rg`.