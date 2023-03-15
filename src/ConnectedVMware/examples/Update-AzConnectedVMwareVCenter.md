### Example 1: Update VCenter
```powershell
Update-AzConnectedVMwareVCenter -Name "azcli-test-vc" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" 
-Tag @{"vc"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   azcli-test-vc azcli-test-rg
```

This command update tag of a VCenter named `azcli-test-vc` in a resource group named `azcli-test-rg`.