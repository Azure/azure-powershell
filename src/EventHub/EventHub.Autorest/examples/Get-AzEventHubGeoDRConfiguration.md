### Example 1: Get the disaster recovery configuration details of an eventhubs namespace
```powershell
Get-AzEventHubGeoDRConfiguration -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAlias
```

```output
AlternateName                     :
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/disasterRecoveryConfigs/myAlias
Location                          :
Name                              : myalias
PartnerNamespace                  : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/mySecondaryNamespace
PendingReplicationOperationsCount : 0
ProvisioningState                 : Succeeded
ResourceGroupName                 : myResourceGroup
Role                              : Primary
```

Gets disaster recovery configuration details of alias `myAlias` created for namespace `myNamespace`.