### Example 1: Remove a schema version by name
```powershell
Remove-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1"
```

Removes a schema version by specifying the resource group name, schema registry name, schema name, and schema version name directly.

### Example 2: Remove a schema version using schema registry identity object
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -Name "my-schema-registry"
Remove-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName "my-schema" -Name "1"
```

Removes a schema version by using the parent schema registry's (parent of the schema version's parent schema) identity object along with the schema name and schema version name.

### Example 3: Remove a schema version using schema identity object
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Name "my-schema"
Remove-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name "1"
```

Removes a schema version by using the parent schema identity object along with the schema version name.

### Example 4: Remove a schema version using schema version identity object
```powershell
$schemaVersion = Get-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1"
Remove-AzDeviceRegistrySchemaVersion -InputObject $schemaVersion
```

Removes a schema version by using the schema version's InputObject parameter.

