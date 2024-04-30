### Example 1: Get all the stream analytics clusters under a subscription
```powershell
Get-AzStreamAnalyticsCluster
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters 77ba5ccb-3005-40b6-b9ac-3ae9d7fb21c9
```

This command gets all the stream analytics clusters under a subscription.

### Example 2: Get all the stream analytics clusters under a resource group
```powershell
Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets all the stream analytics clusters under a resource group.

### Example 3: Get a stream analytics cluster by name
```powershell
Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets a stream analytics cluster by name.

### Example 4: Get a stream analytics cluster by pipeline
```powershell
Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01 | Get-AzStreamAnalyticsCluster
```
```output
Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets a stream analytics cluster by pipeline.