### Example 1: Get keys of a ServiceBus Namespace authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name RootManageSharedAccessKey
```

```output
AliasPrimaryConnectionString   :
AliasSecondaryConnectionString :
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : 000000000000
PrimaryKey                     : 000000000000
SecondaryConnectionString      : {ConnectionString}
SecondaryKey                   : {ConnectionString}
```

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus namespace `myNamespace`.

### Example 2: Get keys of a Queue authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName queue1 -Name RootManageSharedAccessKey
```

```output
AliasPrimaryConnectionString   :
AliasSecondaryConnectionString :
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : 000000000000
PrimaryKey                     : 000000000000
SecondaryConnectionString      : {ConnectionString}
SecondaryKey                   : {ConnectionString}
```

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus queue `queue1` from namespace `myNamespace`.

### Example 3: Get keys of a Topic authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName topic1 -Name RootManageSharedAccessKey
```

```output
AliasPrimaryConnectionString   :
AliasSecondaryConnectionString :
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : 000000000000
PrimaryKey                     : 000000000000
SecondaryConnectionString      : {ConnectionString}
SecondaryKey                   : {ConnectionString}
```

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus topic `topic1` from namespace `myNamespace`.