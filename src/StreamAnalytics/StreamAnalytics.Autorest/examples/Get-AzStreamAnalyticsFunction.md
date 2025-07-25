### Example 1: Get all Stream Analytics functions
```powershell
Get-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions
```

This command gets the functions defined on the job.

### Example 2: Get a specific Stream Analytics function
```powershell
Get-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions e35beaf1-8c6c-4b26-bafe-733835510f49
```

This command gets information about the function defined on the job.

### Example 3: Get a specific Stream Analytics function by pipeline
```powershell
New-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name function-05 -File .\test\template-json\Function_JavascriptUdf.json | Get-AzStreamAnalyticsFunction
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-05 Microsoft.StreamAnalytics/streamingjobs/functions e35beaf1-8c6c-4b26-bafe-733835510f49
```

This command gets information about the function defined on the job.
