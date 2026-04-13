### Example 1: Create credentials with expanded parameters
```powershell
New-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Location eastus2 -Tag @{"environment" = "production"; "team" = "iot"}
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:30:15 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Creates credentials for the namespace with specified location and tags. Note: Only one credential resource can exist per namespace.

### Example 2: Create credentials from a JSON file
```powershell
New-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\credentials\config.json"
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:30:15 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Creates credentials for the namespace from a JSON file at the specified path.

### Example 3: Create credentials from a JSON string
```powershell
$jsonString = @"
{
    "location": "eastus2",
    "tags": {
        "environment": "production",
        "team": "iot"
    }
}
"@

New-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:30:15 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Creates credentials for the namespace from a JSON string containing the credential configuration.
