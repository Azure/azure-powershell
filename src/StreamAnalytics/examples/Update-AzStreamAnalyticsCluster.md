### Example 1: Update a stream analytics cluster by name
```powershell
PS C:\> Update-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01 -Tag @{'key4'=4}

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters
```

This command updates a stream analytics cluster by name.

### Example 2: Update a stream analytics cluster by pipeline
```powershell
PS C:\> $sac = Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01
PS C:\> Update-AzStreamAnalyticsCluster -InputObject $sac -Tag @{'key2'=2;'key3'=3}

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters
```

This command updates a stream analytics cluster by pipeline.
