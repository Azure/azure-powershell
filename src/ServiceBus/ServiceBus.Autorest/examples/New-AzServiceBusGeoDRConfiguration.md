### Example 1: Create a disaster recovery Alias
```powershell
New-AzServiceBusGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace -PartnerNamespace /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/mySecondaryNamespace
```

```output
AlternateName                     :
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myPrimaryNamespace/disasterRecoveryCon
                                    figs/myAlias
Location                          :
Name                              : myAlias
PartnerNamespace                  : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/mySecondaryNamespace
PendingReplicationOperationsCount :
ProvisioningState                 : Succeeded
ResourceGroupName                 : myResourceGroup
Role                              : Primary
```

Creates a Disaster Recovery configuration which sets `mySecondaryNamespace` as secondary to `myPrimaryNamespace`.

