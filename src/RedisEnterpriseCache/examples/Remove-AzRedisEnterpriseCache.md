### Example 1: Remove a Redis Enterprise Cache and return the result
```powershell
PS C:\> Remove-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -PassThru
True
```

This command removes a Redis Enterprise Cache and displays whether the operation is successful.

### Example 2: Remove a Redis Enterprise Cache and do not display the result
```powershell
PS C:\> Remove-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup"
```

This command removes a Redis Enterprise Cache. Because the PassThru parameter is not specified, the result of the operation is not displayed.

