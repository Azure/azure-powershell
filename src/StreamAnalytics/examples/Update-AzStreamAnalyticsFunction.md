### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name function-01 -File .\test\template-json\Function_JavascriptUdf.json

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name function-01 | Update-AzStreamAnalyticsFunction -File .\test\template-json\Function_JavascriptUdf.json

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 3206c07f-ed77-4e24-b101-7aa2ac1f3cef
```

{{ Add description here }}

