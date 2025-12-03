### Example 1: Update policy certificate validity using JSON string
```powershell
$jsonString = @"
{
    "properties": {
        "certificate": {
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 60
            }
        }
    }
}
"@

Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
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
                                   "leafCertificateValidityPeriodInDays": 60
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:30:45 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates the certificate validity period for an existing policy. **Note:** For PATCH operations, you only need to specify the fields you want to change.

### Example 2: Update policy tags using JSON string
```powershell
$jsonString = @"
{
    "tags": {
        "environment": "production",
        "team": "iot",
        "updated": "true"
    }
}
"@

Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
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
                                   "leafCertificateValidityPeriodInDays": 60
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:32:18 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "updated": "true"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates only the tags on an existing policy without modifying the certificate configuration.

### Example 3: Update policy from a JSON file
```powershell
Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\policies\policy-update.json"
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
                                   "leafCertificateValidityPeriodInDays": 180
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:35:02 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates a policy from a JSON file containing the update payload.

### Example 4: Update policy via identity object
```powershell
$policyIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    CredentialName = "default"
    PolicyName = "my-policy-name"
}

$jsonString = @"
{
    "properties": {
        "certificate": {
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 120
            }
        }
    },
    "tags": {
        "environment": "staging"
    }
}
"@

Update-AzDeviceRegistryPolicy -InputObject $policyIdentity -JsonString $jsonString
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
                                   "leafCertificateValidityPeriodInDays": 120
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:37:44 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "staging"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates a policy object using an identity object parameter.
