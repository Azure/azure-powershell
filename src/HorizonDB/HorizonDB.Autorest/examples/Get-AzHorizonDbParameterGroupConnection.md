### Example 1: List parameter group connections
```powershell
Get-AzHorizonDbParameterGroupConnection -ResourceGroupName 'example-resource-group' -ParameterGroupName 'production-parameters' | Format-List -Property PoolResourceId
```

```output
PoolResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/example-cluster/pools/example-pool-01
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
