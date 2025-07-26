### Example 1: Remove a schema version by name
```powershell
Remove-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "my-schema-version"
```

This example removes a schema version by specifying the resource group name, schema registry name, schema name, and schema version name directly.

### Example 2: Remove a schema version using schema registry identity object
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -Name "my-schema-registry"
Remove-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName "my-schema" -Name "my-schema-version"
```

This example removes a schema version by using a schema registry identity object along with the schema name and schema version name.

### Example 3: Remove a schema version using schema identity object
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Name "my-schema"
Remove-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name "my-schema-version"
```

This example removes a schema version by using a schema identity object along with the schema version name.

### Example 4: Remove a schema version using schema version identity object
```powershell
$schemaVersion = Get-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "my-schema-version"
Remove-AzDeviceRegistrySchemaVersion -InputObject $schemaVersion
```

This example removes a schema version by first retrieving the schema version object and then passing it directly to the Remove command using the InputObject parameter.

