### Example 1: List all resource types under the resource provider namespace.
```powershell
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
testResourceType2           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

List all resource types under the resource provider namespace.

### Example 2: Gets a resource type by name.
```powershell
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1"
```

```output
Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Gets a resource type by name.

### Example 3: Gets a nested resource type by name.
```powershell
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1/nestedResourceType"
```

```output
Name                                      Type
----                                      ----
testResourceType1/nestedResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Gets a resource type by name.

