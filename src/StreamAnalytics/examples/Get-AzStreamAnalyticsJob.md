### Example 1: Get information about all jobs in a subscription
```powershell
PS C:\> Get-AzStreamAnalyticsJob

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

This command returns information about all the Stream Analytics jobs in the Azure subscription.

### Example 2: Get information about all jobs in a resource group
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

This command returns information about all the Stream Analytics jobs in the resource group.

### Example 3: Get information about a specific job in a resource group
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-02-pwsh

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

This command returns information about the Stream Analytics job StreamingJob in the resource group.


### Example 4: Get information about a specific job in a resource group by pipeline
```powershell
PS C:\> New-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-02-pwsh -Location westcentralus -SkuName Standard | Get-AzStreamAnalyticsJob 

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

This command returns information about the Stream Analytics job StreamingJob in the resource group.