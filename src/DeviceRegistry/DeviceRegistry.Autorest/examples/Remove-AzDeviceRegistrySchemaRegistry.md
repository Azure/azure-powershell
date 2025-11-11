### Example 1: Remove a schema registry by name
```powershell
Remove-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

Removes a schema registry by specifying the resource group name and schema registry name directly. Removing a schema registry resource also removes the nested schema and schema version resources below it.

### Example 2: Remove a schema registry using schema registry identity object
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
Remove-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistry
```

Removes a schema registry by using the schema registry's InputObject parameter. Removing a schema registry resource also removes the nested schema and schema version resources below it.

