### Example 1: Update a custom provider association
```powershell
$provider = Get-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
Update-AzCustomProviderAssociation -Scope $resourceId -Name MyAssoc -TargetResourceId $provider.Id
```

```output
Location  Name     Type
--------  ----     ----
East US 2 MyAssoc  Microsoft.CustomProviders/associations
```

Update a custom provider association, the associated target provider must be properly configured with a route for "associations"