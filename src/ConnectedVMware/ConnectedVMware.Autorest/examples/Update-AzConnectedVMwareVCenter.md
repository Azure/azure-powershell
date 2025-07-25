### Example 1: Update VCenter
```powershell
Update-AzConnectedVMwareVCenter -Name "test-vc" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -Tag @{"vc"="test"}
```

```output
ConnectionStatus             : Connected
CredentialsPassword          :
CredentialsUsername          : abc
CustomResourceName           : e6048b2a-ba86-4334-adff-ba3d617d12ef
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Fqdn                         : idclab-vcen67.fareast.corp.microsoft.com
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
SystemDataLastModifiedAt     : 10/6/2023 2:30:18 PM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                                 "vc": "test"
                               }
Type                         : microsoft.connectedvmwarevsphere/vcenters
Uuid                         : e6048b2a-ba86-4334-adff-ba3d617d12ef
Version                      : 6.7.0
```

This command update tag of a VCenter named `test-vc` in a resource group named `test-rg`.