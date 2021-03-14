### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsInput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsInput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name input-01

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs c3e34ed5-4f82-482e-a4a4-25520ca89098
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> $result = Get-AzStreamAnalyticsInput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name input-01
PS C:\> Get-AzStreamAnalyticsInput -InputObject $result

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs c3e34ed5-4f82-482e-a4a4-25520ca89098
```

{{ Add description here }}

