### Example 1: Regenerate primary access key
```powershell
PS C:\> New-AzRedisEnterpriseCacheDatabaseKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Primary"

PrimaryKey                                   SecondaryKey
----------                                   ------------
new-primary-key                              secondary-key

```

This command regenerates the primary secret access key used for authenticating connections to the database of the Redis Enterprise Cache named MyCache.

### Example 2: Regenerate secondary access key
```powershell
PS C:\> New-AzRedisEnterpriseCacheDatabaseKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Secondary"

PrimaryKey                                   SecondaryKey
----------                                   ------------
primary-key                                  new-secondary-key

```

This command regenerates the secondary secret access key used for authenticating connections to the database of the Redis Enterprise Cache named MyCache.

