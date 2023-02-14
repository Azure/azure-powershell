### Example 1: Delete a resource type registration by name.
```powershell
<<<<<<< HEAD
Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"
=======
PS C:\> Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete a resource type registration by name.

### Example 2: Delete a nested resource type registration by name.
```powershell
<<<<<<< HEAD
Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType"
=======
PS C:\> Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete a nested resource type registration by name.
