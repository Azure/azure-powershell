### Example 1: Update a stream analytics cluster by name
```powershell
Update-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01 -Tag @{'key4'=4}
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters
```

This command updates a stream analytics cluster by name.

### Example 2: Update a stream analytics cluster by pipeline
```powershell
$sac = Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01
Update-AzStreamAnalyticsCluster -InputObject $sac -Tag @{'key2'=2;'key3'=3}
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters
```

This command updates a stream analytics cluster by pipeline.
