### Example 1: Get information about a Stream Analytics transformation
```powershell
Get-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name tranf-01
```
```output
Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

This command returns information about the transformation on the job.

### Example 2: Get information about a Stream Analytics transformation by pipeline
```powershell
New-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name tranf-01 -StreamingUnit 6 -Query "Select Id, Name from input-01" | Get-AzStreamAnalyticsTransformation
```
```output
Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

This command returns information about the transformation on the job.
