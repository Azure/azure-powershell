### Example 1: List all resource types under the resource provider namespace.
```powershell
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"
```

Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
testResourceType2           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations

List all resource types under the resource provider namespace.

### Example 2: Gets a resource type by name.
```powershell
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1"
```

Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations

Gets a resource type by name.

