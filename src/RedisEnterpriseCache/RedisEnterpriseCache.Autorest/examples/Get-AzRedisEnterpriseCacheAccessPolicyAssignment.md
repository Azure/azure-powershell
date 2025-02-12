### Example 1: Get access policy assignment information.
```powershell
 Get-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName "testAccessPolicyAssignmentName" -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup"
```

```output
Name
----
testAccessPolicyAssignmentName
```

This command gets information on access policy assignment (redis user) named testAccessPolicyAssignment from Redis enterprise cache named testCache

### Example 2: List access policy assignment information.
```powershell
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup"
```

```output
Name
----
testAccessPolicyAssignmentName
```

This command gets information on all access policy assignments from Redis enterprise cache named MyCache.

