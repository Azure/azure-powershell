### Example 1: Remove a schema by name
```powershell
Remove-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema"
```

Removes a schema by specifying the resource group name, schema registry name, and schema name directly. Removing a schema also removes all nested schema version resources.

### Example 2: Remove a schema using schema registry identity object
```powershell
$registryIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Remove-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name "my-schema"
```

Removes a schema by using the parent schema registry's identity object that contains the subscription ID, resource group name, and schema registry name. Removing a schema also removes all nested schema version resources.

### Example 3: Remove a schema using schema identity object
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema"
Remove-AzDeviceRegistrySchema -InputObject $schema
```

Removes a schema by using the schema's InputObject parameter. Removing a schema also removes all nested schema version resources.

