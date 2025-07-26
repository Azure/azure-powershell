### Example 1: Remove a schema registry by name
```powershell
Remove-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

This example removes a schema registry by specifying the resource group name and schema registry name directly. Removing a schema registry resource also removes the nested schema and schema version resources below it.

### Example 2: Remove a schema registry using schema registry identity object
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
Remove-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistry
```

This example removes a schema registry by first retrieving the schema registry object and then passing it directly to the Remove command using the InputObject parameter. Removing a schema registry resource also removes the nested schema and schema version resources below it.

