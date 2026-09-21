### Example 1: Check whether the cluster-tier limit has been reached
```powershell
Limit-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 | Format-List
```

```output
Current   : 1
IsReached : True
Maximum   : 1
Type      : FREE
```

Queries the partner to find out, per cluster tier, how many clusters the project currently has, the per-tier maximum, and whether the limit has been reached. Useful as a pre-flight check before `New-AzMongoDBCluster`.
