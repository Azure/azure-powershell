### Example 1: List Clusters in current subscription
```powershell
Get-AzConnectedVMwareCluster -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        Cluster-1                                                        demo-2021
       eastus        test-cluster                                                     service-sdk-test
       eastus        Cluster-1                                                        dshiferaw
       eastus        Cluster-1                                                        ArcbenchVM
       eastus        testCluster                                                      t-ahelc-arcResource
       eastus        Cluster-1                                                        daj-rg
       eastus        ArcVMwareSyntheticsInventoryCluster                              ArcVMwareSynthetics-eastus-05082022-055514AM
       eastus        Cluster-1                                                        snmuvva-pm-demos
```

This command lists Clusters in current subscription.

### Example 2: List Clusters in a resource group
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-cluster azcli-test-rg
VMware eastus   test-clr     azcli-test-rg
```

This command lists Clusters in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Cluster
```powershell
Get-AzConnectedVMwareCluster -Name "test-cluster" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-cluster azcli-test-rg
```

This command gets a Cluster named `test-cluster` in a resource group named `azcli-test-rg`.