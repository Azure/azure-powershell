### Example 1: Remove access policy assignment.
```powershell
 Remove-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup" -Name "testAccessPolicyAssignmentName"
```

This command removes an Access Policy Assignment (Redis User) named testAccessPolicyAssignmentName from Redis enterprise cache named MyCache.


