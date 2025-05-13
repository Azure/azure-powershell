### Example 1: Get available SKUs for scaling the Redis Enterprise cluster
```powershell
Get-AzRedisEnterpriseCacheSku -ClusterName "MyCache" -ResourceGroupName "MyGroup"
```

```output
SizeInGb                       Name
----------					------------
size                         sku-name

```

This command provides all the SKUs and their memory sizes that a Redis Enterprise cluster can be scaled to.
