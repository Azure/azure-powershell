### Example 1: Get all the stream analytics clusters under a subscription
```powershell
PS C:\> Get-AzStreamAnalyticsCluster

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters 77ba5ccb-3005-40b6-b9ac-3ae9d7fb21c9
```

This command gets all the stream analytics clusters under a subscription.

### Example 2: Get all the stream analytics clusters under a resource group
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets all the stream analytics clusters under a resource group.

### Example 3: Get a stream analytics cluster by name
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets a stream analytics cluster by name.

### Example 4: Get a stream analytics cluster by pipeline
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01 | Get-AzStreamAnalyticsCluster

Location        Name         Type                               Etag
--------        ----         ----                               ----
West Central US sac-m-test01 Microsoft.StreamAnalytics/clusters c2bcffd8-b35d-430b-9759-13af9c18ed72
```

This command gets a stream analytics cluster by pipeline.