### Example 1: Get an EventHub namespace
```powershell
Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 3:14:09 PM
DisableLocalAuth                : True
EnableAutoInflate               : True
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    :
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MaximumThroughputUnit           : 0
MetricId                        : 000000000000000:myNamespace
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

Gets details of an EventHub namespace `myNamespace` in resource group `myResourceGroup`.

### Example 2: List all EventHub namespaces in a resource group
```powershell
Get-AzEventHubNamespace -ResourceGroupName myResourceGroup
```

Lists all EventHub namespaces under resource group `myResourceGroup`.

### Example 3: List all EventHub namespaces in a subscription
```powershell
Get-AzEventHubNamespace
```

Lists all EventHub namespaces in the current subscription context.
