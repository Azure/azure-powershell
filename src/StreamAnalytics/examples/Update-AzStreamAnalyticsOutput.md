### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name output-01 -File .\test\template-json\StroageAccount.json

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs d5a980c2-07cc-4dc7-8dd3-21d27ec1212d
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\>  Get-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name output-01| Update-AzStreamAnalyticsOutput -File .\test\template-json\StroageAccount.json

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 6bbe2f2d-519a-4cd9-9fdb-5311ea2617bc
```

{{ Add description here }}

