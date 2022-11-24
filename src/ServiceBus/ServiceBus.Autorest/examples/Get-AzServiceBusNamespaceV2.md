### Example 1: Get namespaces from ResourceGroup.
```powershell
$namespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
```

```output
AlternateName                   :
CreatedAt                       : 11/22/2022 4:15:58 PM
DisableLocalAuth                : False
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://keyVaultName.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : East US
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
UpdatedAt                       : 11/23/2022 7:14:58 AM
UserAssignedIdentity            : {
                                    "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/myThirdIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/mySecondIdentity": {
                                    },
                                    "/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```
Get namespaces from ResourceGroup.


### Example 2: Count the number of namespaces in the resourcegroup.
```powershell
$listOfNamespaces = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup
$listOfNamespaces.Count
```

```output
15
```

There are 15 namespaces present in the myResourceGroup.

