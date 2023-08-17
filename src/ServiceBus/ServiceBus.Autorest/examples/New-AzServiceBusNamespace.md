### Example 1: Create a new ServiceBus namespace with UserAssignedIdentity Encryption
```powershell
$id1 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$id2 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"
$keyVaultProperty1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$keyVaultProperty2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key5 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityID $id1,$id2 -KeyVaultProperty $keyVaultProperty1,$keyVaultProperty2
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:15:41 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/provide
                                  rs/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/reso
                                  urceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
                                     "
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/reso
                                  urceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
                                     "
                                    },
                                    "keyName": "key5",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption : False
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Premium
SkuTier                         : Premium
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 5:23:01 AM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/prov
                                  iders/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/prov
                                  iders/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Creates a new Premium ServiceBus namespace with UserAssignedIdentity encryption.


### Example 2: Create a new ServiceBus namespace with System Assigned Identity enabled.
```powershell
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType SystemAssigned
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:33:10 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/provide
                                  rs/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : SystemAssigned
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Premium
SkuTier                         : Premium
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                  }
TenantId                        : 000000000000000
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 5:40:18 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Create an ServiceBus namespace with SystemAssigned identity.

### Example 3: Create a new Standard ServiceBus namespace with DisableLocalAuth enabled 
```powershell
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -DisableLocalAuth
```

```output
AlternateName                   :
CreatedAt                       : 11/18/2022 6:06:22 AM
DisableLocalAuth                : True
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    :
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.1
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     :
SkuName                         : Standard
SkuTier                         : Standard
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                    "k1": "v1",
                                    "k2": "v2"
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/18/2022 6:07:06 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Create a standard ServiceBus namespace `myNamespace` with DisableLocalAuth enabled.

