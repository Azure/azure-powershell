### Example 1: Add a KeyVaultProperty to an existing EventHub Namespace
```powershell
$eventHubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace

$newKeyVaultProperty = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaultUri https://{keyVaultName}.vault.azure.net/ -UserAssignedIdentity "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"

$eventHubNamespace.KeyVaultProperty += $newKeyVaultProperty

Set-AzEventHubNamespaceV2 -InputObject $eventHubNamespace -KeyVaultProperty $eventHubNamespace.KeyVaultProperty
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/damorg/providers/Microsoft.EventHub/namespaces/testNamespaceForCLI134
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key3",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnits          : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Adds a new KeyVaultProperty to EventHub namespace `myNamespace`.

### Example 2: Remove a KeyVaultProperty from an existing EventHub Namespace
```powershell
$eventHubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace

# Remove the last KeyVaultProperty from the list of KeyVaultProperties
$eventHubNamespace.KeyVaultProperty = $eventHubNamespace.KeyVaultProperty | Where-Object { $_ -ne $eventHubNamespace.KeyVaultProperty[2] }

Set-AzEventHubNamespaceV2 -InputObject $eventHubNamespace -KeyVaultProperty $eventHubNamespace.KeyVaultProperty
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/damorg/providers/Microsoft.EventHub/namespaces/testNamespaceForCLI134
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnits          : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Removes a new KeyVaultProperty to EventHub namespace `myNamespace`.

### Example 3: Set DisableLocalAuth to true on an existing EventHub namespace
```powershell
Set-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -NamespaceName myNamespace -DisableLocalAuth
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/damorg/providers/Microsoft.EventHub/namespaces/testNamespaceForCLI134
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnits          : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Sets `DisableLocalAuth` to true on an EventHub namespace `myNamespace`.
