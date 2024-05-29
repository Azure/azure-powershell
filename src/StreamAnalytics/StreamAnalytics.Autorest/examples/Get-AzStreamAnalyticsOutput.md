### Example 1: Get information about job outputs
```powershell
Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh
```
```output
Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs
```

This command returns information about the outputs defined on the job.

### Example 2: Get information about a specific job output
```powershell
Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name output-01
```
```output
Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0
```

This command returns information about the output defined on the job.

### Example 3: Get information about a specific job output by pipeline
```powershell
New-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name output-05 -File .\test\template-json\StroageAccount.json | Get-AzStreamAnalyticsOutput
```
```output
Name      Type                                            ETag
----      ----                                            ----
output-05 Microsoft.StreamAnalytics/streamingjobs/outputs 3a11e210-2a7f-4856-8d5a-25d4ecabee06
```

This command returns information about the output defined on the job.