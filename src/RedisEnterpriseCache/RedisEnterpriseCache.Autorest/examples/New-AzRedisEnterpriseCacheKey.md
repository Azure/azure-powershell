### Example 1: Regenerate primary access key
```powershell
New-AzRedisEnterpriseCacheKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Primary"
```

```output
PrimaryKey                                   SecondaryKey
----------                                   ------------
new-primary-key                              secondary-key

```

This command regenerates the primary secret access key used for authenticating connections to the database of the Redis Enterprise cache named MyCache.

### Example 2: Regenerate secondary access key
```powershell
New-AzRedisEnterpriseCacheKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Secondary"
```

```output
PrimaryKey                                   SecondaryKey
----------                                   ------------
primary-key                                  new-secondary-key

```

This command regenerates the secondary secret access key used for authenticating connections to the database of the Redis Enterprise cache named MyCache.

