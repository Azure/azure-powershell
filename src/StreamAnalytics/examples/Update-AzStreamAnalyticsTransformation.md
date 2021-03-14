### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsTransformation -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name tranf-01 -StreamingUnit 1

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations 6d100b9a-91c1-4b27-ae62-68c55635154f
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsTransformation -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name tranf-01 | Update-AzStreamAnalyticsTransformation -StreamingUnit 1

Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations 3d6570c5-6e0f-4ec6-b242-ba9e161c3e01
```

{{ Add description here }}

