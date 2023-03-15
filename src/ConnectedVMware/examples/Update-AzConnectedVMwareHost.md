### Example 1: Update Host
```powershell
Update-AzConnectedVMwareHost -Name "test-host" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
-Tag @{"host"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-host azcli-test-rg
```

This command update tag of a Host named `test-host` in a resource group named `azcli-test-rg`.