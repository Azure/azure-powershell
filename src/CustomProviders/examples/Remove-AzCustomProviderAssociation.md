### Example 1: Remove a custom provider association.
```powershell
<<<<<<< HEAD
Remove-AzCustomProviderAssociation -Scope $id -Name Namespace.Type
=======
PS C:\> PS C:\> Remove-AzCustomProviderAssociation -Scope $id -Name Namespace.Type
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Remove a custom provider association.

### Example 2: Remove a custom provider association with Piping
```powershell
<<<<<<< HEAD
Get-AzCustomProviderAssociation | Remove-AzCustomProviderAssociation -PassThru
```

```output
=======
PS C:\> PS C:\> Get-AzCustomProviderAssociation | Remove-AzCustomProviderAssociation -PassThru

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
True
```

Remove a custom provider association, using piping and the PassThru feature to indicate success or failure.

