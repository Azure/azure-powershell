### Example 1: List VCenters in current subscription
```powershell
Get-AzConnectedVMwareVCenter -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                         ResourceGroupName
----   --------      ----                                         -----------------
VMware eastus        test-vc1                                     test-rg1
VMware eastus        test-vc2                                     test-rg2
VMware eastus        test-vc3                                     test-rg3
VMware eastus        test-vc4                                     test-rg4
VMware eastus        test-vc5                                     test-rg5
AVS    eastus        test-vc6                                     test-rg6
VMware eastus        test-vc7                                     test-rg7
VMware EastUS        test-vc8                                     test-rg8
```

This command lists VCenters in current subscription.

### Example 2: List VCenters in a resource group
```powershell
Get-AzConnectedVMwareVCenter -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-vc1     test-rg
       eastus   test-vc2     test-rg
```

This command lists VCenters in a resource group named `test-rg`.

### Example 3: Get a specific VCenter
```powershell
Get-AzConnectedVMwareVCenter -Name "test-vc" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
ConnectionStatus             : Connected
CredentialsPassword          :
CredentialsUsername          : arcvmware
CustomResourceName           : e6048b2a-ba86-4334-adff-ba3d617d12ef
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Fqdn                         : 1.2.3.4
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
InstanceUuid                 : db73f8f2-624c-4a0f-905b-8c6f34442cbc
Kind                         : VMware
Location                     : eastus
Name                         : test-vc
Port                         : 443
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Connected",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-09-18T08:04:35.0000000Z"
                               }, {
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-01T05:26:07.8798425Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-01T05:26:07.8798425Z"
                               }}
SystemDataCreatedAt          : 2/16/2023 3:53:39 PM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/18/2023 8:04:40 AM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/vcenters
Uuid                         : e6048b2a-ba86-4334-adff-ba3d617d12ef
Version                      : 6.7.0
```

This command gets a VCenter named `test-vc` in a resource group named `test-rg`.