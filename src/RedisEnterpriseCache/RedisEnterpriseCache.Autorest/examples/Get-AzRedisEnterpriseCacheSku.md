### Example 1: {{ Add title here }}
```powershell
Get-AzRedisEnterpriseCacheSku -ClusterName "MyCache" -ResourceGroupName "MyGroup"
```

```output
CustomerFacingSizeInGb                       Name
----------                                   ------------
customer-facing-size                         sku-name

```

This command provides all the SKUs and their memory sizes that a Redis Enterprise cluster can be scaled to.
