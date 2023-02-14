### Example 1: Create a custom provider association
```powershell
<<<<<<< HEAD
$provider = Get-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
New-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc -TargetResourceId $provider.Id
```

```output
=======
PS C:\> $provider = Get-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
PS C:\> New-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc -TargetResourceId $provider.Id

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location  Name     Type
--------  ----     ----
East US 2 MyAssoc  Microsoft.CustomProviders/associations
```

Create a custom provider association, the associated target provioder must be properly configured with a route for "associations"

