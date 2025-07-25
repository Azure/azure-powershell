### Example 1: Gets the migration configuration of a ServiceBus namespace
```powershell
Get-AzServiceBusMigration -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces
                                    /myNamespace/migrationConfigurations/$default
Location                          :
MigrationState                    : Active
Name                              : myNamespace
PendingReplicationOperationsCount :
PostMigrationName                 : myPremiumNamespace
ProvisioningState                 : Succeeded
ResourceGroupName                 : myResourceGroup
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetNamespace                   : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces
                                    /myPremiumNamespace
```

Gets the details of migration configuration related to namespace `myNamespace`.

