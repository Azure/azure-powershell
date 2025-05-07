### Example 1: Triggers EventHub Namespace Failover.
```powershell
Start-AzEventHubNamespaceFailOver -ResourceGroupName myresourceGroup -NamespaceName mynamespace -PrimaryLocation mylocation
$eventhubNamespace = Get-AzEventHubNamespace -ResourceGroupName myresourceGroup -Name mynamespace 
```

```output
AlternateName                      :
ClusterArmId                       :
CreatedAt                          : 5/5/2025 5:16:45 PM
DisableLocalAuth                   : False
EnableAutoInflate                  : False
Id                                 : /subscriptions/subscriptionId/resourceGroups/myresourceGroup/providers/Microsoft.EventHub/namespaces/mynamespace
IdentityType                       :
KafkaEnabled                       : True
KeySource                          :
KeyVaultProperty                   :
Location                           : mylocation
MaxReplicationLagDurationInSeconds : 0
MaximumThroughputUnit              : 0
MetricId                           : subscriptionId:mynamespace
MinimumTlsVersion                  : 1.2
Name                               : mynamespace
PrincipalId                        :
PrivateEndpointConnection          :
ProvisioningState                  : Succeeded
PublicNetworkAccess                : Enabled
ReplicaLocation                    : {{
                                       "locationName": "mylocation",
                                       "roleType": "Primary",
                                       "replicaState": "Ready"
                                     }, {
                                       "locationName": "mylocation2",
                                       "roleType": "Secondary",
                                       "replicaState": "Ready"
                                     }}
RequireInfrastructureEncryption    :
ResourceGroupName                  : myresourceGroup
ServiceBusEndpoint                 : https://mynamespace.servicebus.windows.net:443/
SkuCapacity                        : 1
SkuName                            : Premium
SkuTier                            : Premium
Status                             : Active
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : {
                                     }
TenantId                           :
Type                               : Microsoft.EventHub/Namespaces
UpdatedAt                          : 5/5/2025 5:17:49 PM
UserAssignedIdentity               : {
                                     }
ZoneRedundant                      : False
```

Triggers EventHub Namespace Failover.