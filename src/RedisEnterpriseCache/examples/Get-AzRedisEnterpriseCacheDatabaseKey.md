### Example 1: Get database access keys
```powershell
PS C:\> Get-AzRedisEnterpriseCacheDatabaseKey -Name "MyCache" -ResourceGroupName "MyGroup"

PrimaryKey                                   SecondaryKey
----------                                   ------------
j7La5KLxe3RLExqO8W4xwIEl4KDbCs7fQM0vf7tZnPY= QEInlqy5WwCxkX+SQR8jCmbYdBrXXopbwRAeqLkizX0=

```

This command gets the secret access keys used for authenticating connections to the database of the Redis Enterprise Cache named MyCache.
