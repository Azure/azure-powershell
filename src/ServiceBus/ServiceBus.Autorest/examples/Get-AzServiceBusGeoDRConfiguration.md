### Example 1: Get the disaster recovery configuration details of a ServiceBus namespace
```powershell
Get-AzServiceBusGeoDRConfiguration -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAlias
```

```output
AlternateName                     :
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/disasterRecoveryConfigs/myAlias
Location                          :
Name                              : myalias
PartnerNamespace                  : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/mySecondaryNamespace
PendingReplicationOperationsCount : 0
ProvisioningState                 : Succeeded
ResourceGroupName                 : myResourceGroup
Role                              : Primary
```

Gets disaster recovery configuration details of alias `myAlias` created for namespace `myNamespace`.