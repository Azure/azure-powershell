### Example 1: Get keys of an EventHub Namespace authorization rule
```powershell
Get-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name RootManageSharedAccessKey
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

### Example 2: Get keys of an EventHub Entity authorization rule
```powershell
Get-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name RootManageSharedAccessKey
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
