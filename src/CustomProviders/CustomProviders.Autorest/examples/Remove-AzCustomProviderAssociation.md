### Example 1: Remove a custom provider association.
```powershell
Remove-AzCustomProviderAssociation -Scope $id -Name Namespace.Type
```

Remove a custom provider association.

### Example 2: Remove a custom provider association with Piping
```powershell
Get-AzCustomProviderAssociation | Remove-AzCustomProviderAssociation -PassThru
```

```output
True
```

Remove a custom provider association, using piping and the PassThru feature to indicate success or failure.

