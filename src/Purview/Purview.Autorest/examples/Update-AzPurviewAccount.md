### Example 1: Update a purview account
```powershell
Update-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg -Tag @{"k"="v"} | Format-List 
```

```output
CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.Zhou@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Purview/a 
                                   ccounts/bez-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.Zhou@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "Beisi.Zhou@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.Zhou@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.Zhou@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account
```

Update the tag of a purview account named 'test-pa'

### Example 2: Update a purview account by InputObject
```powershell
$get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg 
Update-AzPurviewAccount -InputObject $get -Tag @{"k"="v"}
```

```output
CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.Zhou@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Purview/a 
                                   ccounts/bez-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.Zhou@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "Beisi.Zhou@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.Zhou@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.Zhou@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account
```

Update the tag of a purview account named 'test-pa' by InputObject
