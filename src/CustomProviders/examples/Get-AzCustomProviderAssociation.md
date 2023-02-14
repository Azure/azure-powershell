### Example 1: List custom provider associations
```powershell
<<<<<<< HEAD
Get-AzCustomProviderAssociation
```

```output
=======
PS C:\> Get-AzCustomProviderAssociation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location  Name             Type
--------  ----             ----
East US 2 MyAssoc   Microsoft.CustomProviders/associations
```

List all custom provider associations for a given scope.

### Example 2: Get an association
```powershell
<<<<<<< HEAD
Get-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc
```

```output
=======
PS C:\> Get-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location  Name             Type
--------  ----             ----
East US 2 MyAssoc   Microsoft.CustomProviders/associations
```

Get details for a single CustomProvider association

