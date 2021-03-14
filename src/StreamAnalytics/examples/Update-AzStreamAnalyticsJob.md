### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-01-pwsh -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs a5eb4626-ab6c-45bb-be0d-86593ad92021
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-01-pwsh | Update-AzStreamAnalyticsJob -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs c1aa3d2a-1784-4586-926f-df5bfd084e31
```

{{ Add description here }}

