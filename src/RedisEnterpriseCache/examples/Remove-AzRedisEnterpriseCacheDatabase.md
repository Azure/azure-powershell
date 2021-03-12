### Example 1: Remove a database in a Redis Enterprise cache and return the result
```powershell
PS C:\> Remove-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -PassThru
True
```

This command removes a database in a Redis Enterprise cache and displays whether the operation is successful.

### Example 2: Remove a database in a Redis Enterprise cache and do not display the result
```powershell
PS C:\> Remove-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup"
```

This command removes a database in a Redis Enterprise cache. Because the PassThru parameter is not specified, the result of the operation is not displayed.

