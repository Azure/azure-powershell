### Example 1: Get all jobs under the stream analytics cluster
```powershell
Get-AzStreamAnalyticsClusterStreamingJob -ResourceGroupName pwshaz-rg-test -ClusterName sac-m-test01
```
```output
JobState StreamingUnit
-------- -------------
Created  3
```

This command gets all jobs under the stream analytics cluster

