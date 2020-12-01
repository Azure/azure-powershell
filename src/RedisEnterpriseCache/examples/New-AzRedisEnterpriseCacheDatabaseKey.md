### Example 1: Regenerate primary access key
```powershell
PS C:\> New-AzRedisEnterpriseCacheDatabaseKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Primary"

PrimaryKey                                   SecondaryKey
----------                                   ------------
ZqY6g2H1dcL1ARne0TSCdBHs/UHQM+UTZRDB5I2+BSY= QEInlqy5WwCxkX+SQR8jCmbYdBrXXopbwRAeqLkizX0=

```

This command regenerates the primary secret access key used for authenticating connections to the database of the Redis Enterprise Cache named MyCache.

### Example 2: Regenerate secondary access key
```powershell
PS C:\> New-AzRedisEnterpriseCacheDatabaseKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Secondary"

PrimaryKey                                   SecondaryKey
----------                                   ------------
ZqY6g2H1dcL1ARne0TSCdBHs/UHQM+UTZRDB5I2+BSY= IVFu/ddyL/Q61zL/A/WPu+8aMyF9o6Jr+WbD2bgvZXA=

```

This command regenerates the secondary secret access key used for authenticating connections to the database of the Redis Enterprise Cache named MyCache.

