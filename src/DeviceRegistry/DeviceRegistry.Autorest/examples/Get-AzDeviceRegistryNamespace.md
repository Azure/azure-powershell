### Example 1: List Namespaces in a resource group
```powershell
Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group"
```

```output
Location Name                                     SystemDataCreatedAt  SystemDataCreatedBy                  SystemDataCreatedByType
-------- ----                                     -------------------  -------------------                  -----------------------
eastus2  adr-namespace                            7/22/2025 5:15:28 AM user@outlook.com Application
eastus2  test-ns-create                           7/22/2025 7:31:54 AM user@outlook.com                   User
```

Lists the Device Registry Namespaces in a resource group.

### Example 2: List Namespaces in a subscription.
```powershell
Get-AzDeviceRegistryNamespace -SubscriptionId my-subscription-id
```

```output
Location Name                                     SystemDataCreatedAt  SystemDataCreatedBy                  SystemDataCreatedByType
-------- ----                                     -------------------  -------------------                  -----------------------
eastus2  adr-namespace                            7/22/2025 5:15:28 AM user@outlook.com Application
eastus2  test-ns-create                           7/22/2025 7:31:54 AM user@outlook.com                   User
```

Lists the Device Registry Namespaces in a subscription.

### Example 3: Get a Namespace
```powershell
Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Gets the details of the Namespace.

### Example 4: Get Namespace Via Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "my-subscription"
  ResourceGroup = "my-resource-group"
  Name = "my-namespace"
}
Get-AzDeviceRegistryNamespace -InputObject $namespaceIdentity
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Gets the details of the Device Registry Namespace resource via Identity object.