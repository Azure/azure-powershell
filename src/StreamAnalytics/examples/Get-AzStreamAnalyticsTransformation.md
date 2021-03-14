### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsTransformation -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name tranf-01

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> $tranf = Get-AzStreamAnalyticsTransformation -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name tranf-01
PS C:\> Get-AzStreamAnalyticsTransformation -InputObject $tranf

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

{{ Add description here }}

