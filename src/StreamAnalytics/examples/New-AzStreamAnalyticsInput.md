### Example 1: Create a job input with a definition from a file
```powershell
PS C:\> New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\EventHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file EventHub.json.

### Example 2: Create a job input with a definition from a file
```powershell
PS C:\> New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\IotHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file IotHub.json.