### Example 1: Remove a service group by name
```powershell
Remove-AzServiceGroup -Name "Contoso"
```

Removes the service group named 'Contoso'. The delete operation is asynchronous; use the -AsJob parameter if you need to track completion.

### Example 2: Remove a service group using pipeline input
```powershell
Get-AzServiceGroup -Name "Contoso" | Remove-AzServiceGroup -PassThru
```

```output
True
```

Gets the service group 'Contoso' and pipes it to Remove-AzServiceGroup. The -PassThru switch outputs True when the deletion is successful.

