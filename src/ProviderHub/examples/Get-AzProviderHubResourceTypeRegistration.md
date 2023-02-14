### Example 1: List all resource types under the resource provider namespace.
```powershell
<<<<<<< HEAD
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
=======
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
testResourceType2           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

List all resource types under the resource provider namespace.

### Example 2: Gets a resource type by name.
```powershell
<<<<<<< HEAD
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1"
```

```output
=======
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                        Type
----                        ----
testResourceType1           Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Gets a resource type by name.

### Example 3: Gets a nested resource type by name.
```powershell
<<<<<<< HEAD
Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1/nestedResourceType"
```

```output
=======
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1/nestedResourceType"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                      Type
----                                      ----
testResourceType1/nestedResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Gets a resource type by name.

