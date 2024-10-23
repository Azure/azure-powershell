### Example 1: Add new access policy assignment.
```powershell
New-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName "testAccessPolicyAssignmentName" -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup" -UserObjectId "5fb3eb10-a8a2-4db7-8bb4-e377180e7427" -AccessPolicyName "default"
```

```output
Name
----
testAccessPolicyAssignmentName
```

This command creates access policy assignment (redis user) named testAccessPolicyAssignmentName on Redis enterprise cache named MyCache.

