### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStreamAnalyticsInput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name input-01 -File .\test\template-json\EventHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 72d568f9-f4be-455b-bab8-c31e811a0469
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStreamAnalyticsInput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name input-01 | Update-AzStreamAnalyticsInput -File .\test\template-json\EventHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 29787d67-5274-4f31-a190-30182ebcecda
```

{{ Add description here }}

