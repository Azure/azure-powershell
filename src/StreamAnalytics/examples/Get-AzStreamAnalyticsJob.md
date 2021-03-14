### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsJob

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-02-pwsh

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> $job = Get-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-02-pwsh
PS C:\> Get-AzStreamAnalyticsJob -InputObject $job

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

{{ Add description here }}
