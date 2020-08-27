### Example 1: Remove a custom provider association.
```powershell
PS C:\> PS C:\> Remove-AzCustomProviderAssociation -Scope $id -Name Namespace.Type
```

Remove a custom provider association.

### Example 2: Remove a custom provider association with Piping
```powershell
PS C:\> PS C:\> Get-AzCustomProviderAssociation | Remove-AzCustomProviderAssociation -PassThru

True
```

Remove a custom provider association, using piping and the PassThru feature to indicate success or failure.

