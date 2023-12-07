### Example 1: List Clusters in current subscription
```powershell
Get-AzConnectedVMwareCluster -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        test-cluster1                                                    test-rg1
       eastus        test-cluster2                                                    test-rg2
       eastus        test-cluster3                                                    test-rg3
       eastus        test-cluster4                                                    test-rg4
       eastus        test-cluster5                                                    test-rg5
       eastus        test-cluster6                                                    test-rg6
       eastus        test-cluster7                                                    test-rg7
       eastus        test-cluster8                                                    test-rg8
```

This command lists Clusters in current subscription.

### Example 2: List Clusters in a resource group
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name          ResourceGroupName
----   -------- ----          -----------------
       eastus   test-cluster1 test-rg
       eastus   test-cluster2 test-rg
```

This command lists Clusters in a resource group named `test-rg`.

### Example 3: Get a specific Cluster
```powershell
Get-AzConnectedVMwareCluster -Name "test-cluster" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CustomResourceName           : dd163232-210f-4f82-8b0c-9866a2eac862
DatastoreId                  :
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/clusters/test-cluster
InventoryItemId              :
Kind                         :
Location                     : eastus2euap
MoName                       : Cluster-1
MoRefId                      : domain-c7
Name                         : test-cluster
NetworkId                    :
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2021-08-25T09:48:12.9989085Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2021-08-25T09:48:12.9989085Z"
                               }}
SystemDataCreatedAt          : 8/25/2021 9:38:06 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/25/2021 9:48:13 AM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
TotalCpuMHz                  :
TotalMemoryGb                :
Type                         : microsoft.connectedvmwarevsphere/clusters
UsedCpuMHz                   :
UsedMemoryGb                 :
Uuid                         : dd163232-210f-4f82-8b0c-9866a2eac862
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
```

This command gets a Cluster named `test-cluster` in a resource group named `test-rg`.