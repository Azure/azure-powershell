### Example 1: Create a new stream analytics cluster
```powershell
PS C:\> New-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-ps-test01 -Location "West Central US" -SkuName "Default" -SkuCapacity 36

Location        Name          Type                               Etag
--------        ----          ----                               ----
West Central US sac-ps-test01 Microsoft.StreamAnalytics/clusters
```

This command creates a new stream analytics cluster.