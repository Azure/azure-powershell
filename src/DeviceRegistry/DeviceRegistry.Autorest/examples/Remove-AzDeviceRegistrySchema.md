### Example 1: Remove a schema by name
```powershell
Remove-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema"
```

This example removes a schema by specifying the resource group name, schema registry name, and schema name directly. Removing a schema also removes all nested schema version resources.

### Example 2: Remove a schema using schema registry identity object
```powershell
$registryIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Remove-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name "my-schema"
```

This example removes a schema by using a schema registry identity object that contains the subscription ID, resource group name, and schema registry name, along with the schema name. Removing a schema also removes all nested schema version resources.

### Example 3: Remove a schema using schema identity object
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema"
Remove-AzDeviceRegistrySchema -InputObject $schema
```

This example removes a schema by first retrieving the schema object and then passing it directly to the Remove command using the InputObject parameter. Removing a schema also removes all nested schema version resources.

