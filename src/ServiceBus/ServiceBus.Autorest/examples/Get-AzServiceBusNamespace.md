### Example 1: Gets a description for the specified namespace.
```powershell
$namespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

```output
AlternateName                   :
CreatedAt                       : 11/22/2022 4:15:58 PM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : East US
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
UpdatedAt                       : 11/23/2022 7:14:58 AM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/myThirdIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/mySecondIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity
                                    /userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```
Get namespaces description from ResourceGroup.


### Example 2: List all ServiceBus namespaces in a resource group.
```powershell
Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup
```
Lists all ServiceBus namespaces under resource group `myResourceGroup`.

### Example 3: List all ServiceBus namespaces in a subscription
```powershell
Get-AzServiceBusNamespace
```

Lists all ServiceBus namespaces in the current subscription context.
