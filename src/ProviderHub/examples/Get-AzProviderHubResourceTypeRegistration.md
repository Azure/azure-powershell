### Example 1: List all resource types under the resource provider namespace.
```powershell
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"
```

List all resource types under the resource provider namespace.

### Example 2: Gets a resource type by name.
```powershell
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"
```

Gets a resource type by name.

