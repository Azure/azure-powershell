### Example 1: Add a KeyVaultProperty to an existing ServiceBus Namespace
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$newKeyVaultProperty = New-AzServiceBusKeyVaultPropertiesObject -KeyName key6 -KeyVaultUri https://{keyVaultName}.vault.azure.net/ -UserAssignedIdentity "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$serviceBusNamespace.KeyVaultProperty += $newKeyVaultProperty
Set-AzEventHubNamespaceV2 -InputObject $serviceBusNamespace -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 5:51:52 AM
DisableLocalAuth                : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    :
KeySource                       :
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://{KeyVaultName}.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key5",
                                    "keyVaultUri": "https://{KeyVaultName}.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key6",
                                    "keyVaultUri": "https://{KeyVaultName}.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : {subscriptionId}:myNamespace
MinimumTlsVersion               : 1.1
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 16
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
UpdatedAt                       : 11/21/2022 5:01:22 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Adds a new KeyVaultProperty to ServiceBus namespace `myNamespace`.


### Example 2: Remove a KeyVaultProperty from an existing ServiceBus Namespace
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$serviceBusNamespace.KeyVaultProperty = $serviceBusNamespace.KeyVaultProperty[0,2]
Set-AzServiceBusNamespaceV2 -InputObject $serviceBusNamespace -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:15:41 AM
DisableLocalAuth                : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                      userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                      userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key6",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : {subscriptionId}:myNamespace
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
UpdatedAt                       : 11/21/2022 8:52:02 AM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Remove the second KeyVaultProperty from the list of KeyVaultProperties.


### Example 3: Add UserAssigned Identity to Namespace with IdentityType SystemAssigned to test for SystemAssigned and UserAssigned
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$a = New-AzServiceBusUserAssignedIdentityObject -IdentityId /subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity,/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity
Set-AzServiceBusNamespaceV2 -InputObject $serviceBusNamespace -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentity $a
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 3:54:50 AM
DisableLocalAuth                : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : SystemAssigned, UserAssigned
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : {subscriptionId}:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000
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
                                  }
TenantId                        : 0000000000000000
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 9:15:53 AM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/mySecondIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Added UserAssigned Identity to Namespace with IdentityType SystemAssigned to test for SystemAssigned and UserAssigned.


### Example 4: # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.
```powershell
$a = New-AzServiceBusUserAssignedIdentityObject -IdentityId /subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity,/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity
$serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a
$serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -IdentityType None -UserAssignedIdentity:$null
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 3:54:50 AM
DisableLocalAuth                : False
Id                              : /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/shubham-rg/providers/M
                                  icrosoft.ServiceBus/namespaces/srcrg32
IdentityType                    :
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : 326100e2-f69d-4268-8503-075374f62b6e:srcrg32
MinimumTlsVersion               : 1.2
Name                            : srcrg32
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : shubham-rg
ServiceBusEndpoint              : https://srcrg32.servicebus.windows.net:443/
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
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 9:42:32 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Created a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.




