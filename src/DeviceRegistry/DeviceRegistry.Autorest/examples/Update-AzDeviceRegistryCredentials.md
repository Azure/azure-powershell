### Example 1: Update credentials tags using expanded parameters
```powershell
Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Tag @{"environment" = "production"; "team" = "iot"; "updated" = "true"}
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
SystemDataLastModifiedAt     : 12/2/2024 10:45:33 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "updated": "true"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates the tags on the credentials resource. Note: Credentials are system-managed, only tags can be updated by users.

### Example 2: Update credentials via identity object
```powershell
$credentialsIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryCredentials -InputObject $credentialsIdentity -Tag @{"environment" = "staging"; "team" = "iot"}
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
SystemDataLastModifiedAt     : 12/2/2024 10:46:12 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "staging",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates the credentials using an identity object parameter.

### Example 3: Update credentials from a JSON file
```powershell
Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\credentials\update.json"
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
SystemDataLastModifiedAt     : 12/2/2024 10:47:05 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "version": "2.0"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates credentials from a JSON file containing the update payload.

### Example 4: Update credentials from a JSON string
```powershell
$jsonString = @"
{
    "tags": {
        "environment": "production",
        "team": "iot",
        "version": "2.0"
    }
}
"@

Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
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
SystemDataLastModifiedAt     : 12/2/2024 10:47:28 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "version": "2.0"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates credentials from a JSON string containing the update configuration.
