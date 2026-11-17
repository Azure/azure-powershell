### Example 1: List pool nodes
```powershell
Get-AzHorizonDbNode -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' | Format-List -Property Name, Role, AvailabilityZone
```

```output
Name             : node-01
Role             : ReadWrite
AvailabilityZone : 3

Name             : node-02
Role             : ReadOnly
AvailabilityZone : 2

Name             : node-03
Role             : ReadOnly
AvailabilityZone : 1
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a pool node
```powershell
Get-AzHorizonDbNode -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Name 'node-01' | Format-List -Property Name, Role, AvailabilityZone
```

```output
Name             : node-01
Role             : ReadWrite
AvailabilityZone : 3
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
