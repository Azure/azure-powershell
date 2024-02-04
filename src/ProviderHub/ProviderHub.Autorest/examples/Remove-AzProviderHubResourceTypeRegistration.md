### Example 1: Delete a resource type registration by name.
```powershell
Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"
```

Delete a resource type registration by name.

### Example 2: Delete a nested resource type registration by name.
```powershell
Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType"
```

Delete a nested resource type registration by name.
