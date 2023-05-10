### Example 1: Get details of a schema group from an EventHub namespace
```powershell
Get-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name mySchemaGroup
```

```output
CreatedAtUtc                 : 9/14/2022 6:05:47 AM
ETag                         : {etag}
GroupProperty                : {
                               }
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/schemagroups/mySchemaGroup
Location                     : Central US
Name                         : mySchemaGroup
ResourceGroupName            : myResourceGroup
SchemaCompatibility          : None
SchemaType                   : Avro
```

Gets details of schema group `mySchemaGroup` from EventHub namespace `myNamespace`.

### Example 2: List all schema groups in an EventHub namespace
```powershell
Get-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all schema groups created within EventHub namespace `myNamespace`.