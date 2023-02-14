### Example 1: Remove a custom provider.
```powershell
<<<<<<< HEAD
Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
=======
PS C:\> PS C:\> Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Remove a custom provider

### Example 2: Remove a custom provider with PassThru
```powershell
<<<<<<< HEAD
Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type -PassThru
```

```output
=======
PS C:\> PS C:\> Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type -PassThru

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
True
```

Remove a custom provider, using the PassThru feature to indicate success or failure.
