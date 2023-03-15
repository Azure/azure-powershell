### Example 1: Update VM Template Resource
```powershell
Update-AzConnectedVMwareVMTemplate -Name "test-vmtmpl" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" 
-Tag @{"vmtmpl"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vmtmpl azcli-test-rg
```

This command update tag of a VM Template named `test-tmpl` in a resource group named `azcli-test-rg`.