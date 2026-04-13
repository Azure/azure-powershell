### Example 1: Create a policy with ECC certificate using JSON string
```powershell
$jsonString = @"
{
    "location": "eastus2",
    "properties": {
        "certificate": {
            "certificateAuthorityConfiguration": {
                "keyType": "ECC"
            },
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 90
            }
        }
    },
    "tags": {
        "environment": "production",
        "team": "iot"
    }
}
"@

New-AzDeviceRegistryPolicy -Name my-policy-ecc -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-ecc
Location                     : eastus2
Name                         : my-policy-ecc
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
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy with ECC (Elliptic Curve Cryptography) certificate authority and 90-day certificate validity. **Note:** The expanded parameters do not expose the certificateAuthorityConfiguration keyType, so JsonString or JsonFilePath must be used.

### Example 2: Create a policy with RSA certificate using JSON string
```powershell
$jsonString = @"
{
    "location": "eastus2",
    "properties": {
        "certificate": {
            "certificateAuthorityConfiguration": {
                "keyType": "RSA"
            },
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 365
            }
        }
    },
    "tags": {
        "environment": "production",
        "certType": "RSA"
    }
}
"@

New-AzDeviceRegistryPolicy -Name my-policy-rsa -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-rsa
Location                     : eastus2
Name                         : my-policy-rsa
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
                                 "environment": "production",
                                 "certType": "RSA"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy with RSA certificate authority and 365-day certificate validity.

### Example 3: Create a policy from a JSON file
```powershell
New-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\policies\policy-config.json"
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy
Location                     : eastus2
Name                         : my-policy
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
SystemDataCreatedAt          : 12/2/2024 11:25:10 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:25:10 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy from a JSON file containing the complete policy configuration including certificate authority settings.
