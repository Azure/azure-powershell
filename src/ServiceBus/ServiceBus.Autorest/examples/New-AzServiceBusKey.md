### Example 1: Regenerate Primary Key of an ServiceBus Namespace
```powershell
New-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name rootmanagesharedaccesskey -KeyType PrimaryKey
```

```output
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : {primaryConnectionString}
PrimaryKey                     : {primaryKey}
SecondaryConnectionString      : {secondaryConnectionString}
SecondaryKey                   : {secondaryKey}
```

Regenerate primary key of authorization rule `rootmanagesharedaccesskey` on ServiceBus Namespace `myNamespace`.

### Example 2: Regenerate Secondary Key of an ServiceBus queue
```powershell
New-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName myQueue -Name rootmanagesharedaccesskey -KeyType SecondaryKey
```

```output
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : {primaryConnectionString}
PrimaryKey                     : {primaryKey}
SecondaryConnectionString      : {secondaryConnectionString}
SecondaryKey                   : {secondaryKey}
```

Regenerate primary key of authorization rule `rootmanagesharedaccesskey` on ServiceBus queue `myQueue` on ServiceBus Namespace `myNamespace`.

