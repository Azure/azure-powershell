### Example 1: List Datastores in current subscription
```powershell
Get-AzConnectedVMwareDatastore -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                  ResourceGroupName
----   --------      ----                                  -----------------
       eastus        vsanDatastore                         nikitademo
       eastus        vsanDatastore                         shujRG
       eastus        vsanDatastore                         demo-2021
       eastus        vsanDatastore                         mayur-rg
       eastus        test-ds                               service-sdk-test
       eastus        vsanDatastore                         niaro-1223
       eastus        vsanDatastore                         snmuvva-pm-demos
       eastus        vsanDatastore                         partner-eus
```

This command lists Datastores in current subscription.

### Example 2: List Datastores in a resource group
```powershell
Get-AzConnectedVMwareDatastore -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name           ResourceGroupName
----   -------- ----           -----------------
VMware eastus   test-datastore azcli-test-rg
```

This command lists Datastores in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Datastore
```powershell
Get-AzConnectedVMwareDatastore -Name "test-datastore" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name           ResourceGroupName
----   -------- ----           -----------------
VMware eastus   test-datastore azcli-test-rg
VMware eastus   test-ds        azcli-test-rg
```

This command gets a Datastore named `test-datastore` in a resource group named `azcli-test-rg`.