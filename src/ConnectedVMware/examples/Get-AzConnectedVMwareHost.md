### Example 1: List Hosts in current subscription
```powershell
Get-AzConnectedVMwareHost -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                          ResourceGroupName
----   --------      ----                                                          -----------------
       eastus        test-host1                                                    test-rg1
       eastus        test-host2                                                    test-rg2
       eastus        test-host3                                                    test-rg3
       eastus        test-host4                                                    test-rg4
       eastus        test-host5                                                    test-rg5
       eastus        test-host6                                                    test-rg6
       eastus        test-host7                                                    test-rg7
       eastus        test-host8                                                    test-rg8
```

This command lists Hosts in current subscription.

### Example 2: List Hosts in a resource group
```powershell
Get-AzConnectedVMwareHost -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-host1   test-rg
       eastus   test-host2   test-rg
```

This command lists Hosts in a resource group named `test-rg`.

### Example 3: Get a specific Host
```powershell
Get-AzConnectedVMwareHost -Name "test-host" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CpuMhz                       : 105312
CustomResourceName           : 030afcea-3fa5-4e65-bf26-84e8d1c4e230
DatastoreId                  : {}
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Hosts/test-host
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/host-1147412
Kind                         :
Location                     : eastus
MemorySizeGb                 : 127
MoName                       : 1.2.3.4
MoRefId                      : host-1147412
Name                         : test-host
NetworkId                    : {/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet-tf}
OverallCpuUsageMHz           : 20236
OverallMemoryUsageGb         : 118
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-05T06:05:59.8990231Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-05T06:05:59.8990231Z"
                               }}
SystemDataCreatedAt          : 10/5/2023 6:05:41 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/5/2023 6:59:56 AM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/hosts
Uuid                         : 030afcea-3fa5-4e65-bf26-84e8d1c4e230
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg2/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a Host named `test-host` in a resource group named `test-rg`.