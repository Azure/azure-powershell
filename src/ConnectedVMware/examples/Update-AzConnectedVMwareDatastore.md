### Example 1: Update Datastore
```powershell
Update-AzConnectedVMwareDatastore -Name "test-datastore" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
-Tag @{"datastore"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-datastore azcli-test-rg
```

This command update tag of a Datastore named `test-datastore` in a resource group named `azcli-test-rg`.