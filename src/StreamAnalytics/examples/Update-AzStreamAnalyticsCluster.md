### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsCluster -ResourceGroupName lucas-rg-test -ClusterName sacluster-01-portal -Tag @{'key01'='01';'key02'='02'}

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsCluster -ResourceGroupName lucas-rg-test -ClusterName sacluster-01-portal |Update-AzStreamAnalyticsCluster  -Tag @{'key01'='01';'key02'='02'}

Location        Name                Type                               Etag
--------        ----                ----                               ----
West Central US sacluster-01-portal Microsoft.StreamAnalytics/clusters
```

{{ Add description here }}

