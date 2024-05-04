### Example 1: Update a Stream Analytics function
```powershell
Update-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01 -File .\test\template-json\Function_JavascriptUdf.json
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 3206c07f-ed77-4e24-b101-7aa2ac1f3cef
```

This command updates a function from the file Function_JavascriptUdf.json.

### Example 2: Update a Stream Analytics function by pipeline
```powershell
Get-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01 | Update-AzStreamAnalyticsFunction -File .\test\template-json\MachineLearningServices.json
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 3206c07f-ed77-4e24-b101-7aa2ac1f3cef
```

This command updates a function from the file MachineLearningServices.json by pipeline.

