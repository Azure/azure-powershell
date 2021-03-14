### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsCluster

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters cf87edfa-f78f-413a-9d71-be872b7640ee
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName lucas-rg-test

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters cf87edfa-f78f-413a-9d71-be872b7640ee
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName lucas-rg-test -Name sacluster-01-portal

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> $cluster = Get-AzStreamAnalyticsCluster -ResourceGroupName lucas-rg-test -Name sacluster-01-portal
PS C:\> Get-AzStreamAnalyticsCluster -InputObject $cluster

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters
```

{{ Add description here }}

