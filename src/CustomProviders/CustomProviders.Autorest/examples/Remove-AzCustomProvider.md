### Example 1: Remove a custom provider.
```powershell
Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type
```

Remove a custom provider

### Example 2: Remove a custom provider with PassThru
```powershell
Remove-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type -PassThru
```

```output
True
```

Remove a custom provider, using the PassThru feature to indicate success or failure.
