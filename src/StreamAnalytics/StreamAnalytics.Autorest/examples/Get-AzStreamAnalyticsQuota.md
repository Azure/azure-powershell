### Example 1: Get information about the Streaming Unit quota for a region
```powershell
PS C:\> Get-AzStreamAnalyticsQuota -Location 'WestCentralUS'

Name              Type
----              ----
StreamingUnits    Microsoft.StreamAnalytics/quotas
StreamingClusters Microsoft.StreamAnalytics/quotas
```

This command returns information about Streaming Unit quota and usage in the WestCentralUS region.


