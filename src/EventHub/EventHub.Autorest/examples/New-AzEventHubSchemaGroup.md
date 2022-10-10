### Example 1: Create EventHub schema group
```powershell
$schemaGroup = New-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name mySchemaGroup -SchemaCompatibility Backward -SchemaType Avro
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
SchemaCompatibility          : Backward
SchemaType                   : Avro
```

Create a new schema group `mySchemaGroup` for namespace `myNamespace`.
