### Example 1: Create a disaster recovery 
```powershell
New-AzEventHubGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace -PartnerNamespace /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/mySecondaryNamespace
```

```output
AlternateName                     :
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myPrimaryNamespace/disasterRecoveryCon
                                    figs/myAlias
Location                          :
Name                              : myAlias
PartnerNamespace                  : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/mySecondaryNamespace
PendingReplicationOperationsCount :
ProvisioningState                 : Succeeded
ResourceGroupName                 : myResourceGroup
Role                              : Primary
```

Creates a Disaster Recovery configuration which sets `mySecondaryNamespace` as secondary to `myPrimaryNamespace`.

