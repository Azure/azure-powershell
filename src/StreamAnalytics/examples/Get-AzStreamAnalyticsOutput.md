### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-02-pwsh

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-02-pwsh -Name output-01

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> $output = Get-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-02-pwsh -Name output-01
PS C:\> Get-AzStreamAnalyticsOutput -InputObject $output

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0
```

{{ Add description here }}
