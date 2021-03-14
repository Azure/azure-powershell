### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name function-01

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions e35beaf1-8c6c-4b26-bafe-733835510f49
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> $function = Get-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name function-01
PS C:\> Get-AzStreamAnalyticsFunction -InputObject $function

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions e35beaf1-8c6c-4b26-bafe-733835510f49
```

{{ Add description here }}
