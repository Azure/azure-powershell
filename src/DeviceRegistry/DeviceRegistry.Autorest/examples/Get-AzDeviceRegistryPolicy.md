### Example 1: List all policies in a namespace
```powershell
Get-AzDeviceRegistryPolicy -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-1
Location                     : eastus2
Name                         : my-policy-1
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 90
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:15:20 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies

Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-2
Location                     : eastus2
Name                         : my-policy-2
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "RSA"
                                   },
                                   "leafCertificateValidityPeriodInDays": 365
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:20:45 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:20:45 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Lists all policies in the specified namespace.

### Example 2: Get a specific policy by name
```powershell
Get-AzDeviceRegistryPolicy -Name my-policy-1 -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-1
Location                     : eastus2
Name                         : my-policy-1
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 90
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:25:33 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "updated": "true"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Retrieves a specific policy by name from the namespace.
