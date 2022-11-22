### Example 1: Create a new EventHub namespace with UserAssignedIdentity Encryption
```powershell
$identityHashTable = New-AzEventHubUserAssignedIdentityObject -IdentityId "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity","/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"

$keyVaultProperty1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://{keyVaultName}.vault.azure.net/ -UserAssignedIdentity "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$keyVaultProperty2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaultUri https://{keyVaultName}.vault.azure.net/ -UserAssignedIdentity "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"

New-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $identityHashTable -KeyVaultProperty $keyVaultProperty1,$keyVaultProperty2
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://{keyVaultName}.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
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
                                    "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Creates a new Premium EventHub namespace with UserAssignedIdentity encryption

### Example 2: Create a new EventHub namespace with System Assigned Identity enabled
```powershell
New-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType SystemAssigned
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 3:14:09 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : SystemAssigned
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MaximumThroughputUnits          : 0
MetricId                        : {subscriptionId}:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGraph
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Premium
SkuTier                         : Premium
Status                          : Active
Tag                             : {
                                  }
TenantId                        : 00000000000
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:21:19 PM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : True
```

Create an EventHub namespace with SystemAssigned identity.

### Example 3: Create a new Standard EventHub namespace with AutoInflate enabled
```powershell
New-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -SkuCapacity 10 -MaximumThroughputUnits 18 -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -EnableAutoInflate -DisableLocalAuth
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 3:14:09 PM
DisableLocalAuth                : True
EnableAutoInflate               : True
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    :
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MaximumThroughputUnits          : 0
MetricId                        : {subscriptionId}:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Standard
SkuTier                         : Standard
Status                          : Active
Tag                             : {
                                  }
TenantId                        : 00000000000
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:21:19 PM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : True
```

Create a standard EventHub namespace `myNamespace` with Auto Inflate enabled.
