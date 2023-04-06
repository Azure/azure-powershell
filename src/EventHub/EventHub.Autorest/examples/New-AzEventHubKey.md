### Example 1: Regenerate Primary Key of an EventHub Namespace
```powershell
New-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name rootmanagesharedaccesskey -KeyType PrimaryKey
```

```output
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : {primaryConnectionString}
PrimaryKey                     : {primaryKey}
SecondaryConnectionString      : {secondaryConnectionString}
SecondaryKey                   : {secondaryKey}
```

Regenerate primary key of authorization rule `rootmanagesharedaccesskey` on EventHub Namespace `myNamespace`.

### Example 2: Regenerate Secondary Key of an EventHub Entity
```powershell
New-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name rootmanagesharedaccesskey -KeyType SecondaryKey
```

```output
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : {primaryConnectionString}
PrimaryKey                     : {primaryKey}
SecondaryConnectionString      : {secondaryConnectionString}
SecondaryKey                   : {secondaryKey}
```

Regenerate secondary key of authorization rule `rootmanagesharedaccesskey` on EventHub entity `myEventHub` on EventHub Namespace `myNamespace`.

