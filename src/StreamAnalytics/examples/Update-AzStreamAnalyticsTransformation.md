### Example 1: Update a transformation in a stream analytics job
```powershell
PS C:\> Update-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name tranf-01 -StreamingUnit 1

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations 6d100b9a-91c1-4b27-ae62-68c55635154f
```

This command updates a transformation in a stream analytics job.

### Example 2: Update a transformation in a stream analytics job by pipeline
```powershell
PS C:\> Get-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name tranf-01 | Update-AzStreamAnalyticsTransformation -StreamingUnit 1

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations 3d6570c5-6e0f-4ec6-b242-ba9e161c3e01
```

This command updates a transformation in a stream analytics job by pipeline.

