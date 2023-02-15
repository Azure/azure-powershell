### Example 1: Start a Service Bus migration configuration
```powershell
Start-AzServiceBusMigration -ResourceGroupName myResourceGroup -NamespaceName myNamespace -PostMigrationName myStandardNamespace2 -TargetNamespace /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myPremiumNamespace
```

```output
Id                                : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces
                                    /myNamespace/migrationConfigurations/$default
Location                          :
MigrationState                    : Active
Name                              : myNamespace
PendingReplicationOperationsCount :
PostMigrationName                 : myStandardNamespace2
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

Starts a Service Bus migration configuration that links standard namespace `myNamespace` to premium `mySecondaryNamespace`.

