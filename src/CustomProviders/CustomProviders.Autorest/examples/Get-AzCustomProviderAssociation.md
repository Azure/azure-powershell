### Example 1: List custom provider associations
```powershell
Get-AzCustomProviderAssociation
```

```output
Location  Name             Type
--------  ----             ----
East US 2 MyAssoc   Microsoft.CustomProviders/associations
```

List all custom provider associations for a given scope.

### Example 2: Get an association
```powershell
Get-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc
```

```output
Location  Name             Type
--------  ----             ----
East US 2 MyAssoc   Microsoft.CustomProviders/associations
```

Get details for a single CustomProvider association

