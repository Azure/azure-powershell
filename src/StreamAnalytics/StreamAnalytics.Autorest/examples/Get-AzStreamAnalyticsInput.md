### Example 1: Get information about the inputs defined on a job
```powershell
Get-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh
```
```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs
```

This command returns information about all the inputs defined on the job StreamingJob.

### Example 2: Get information about a specific input defined on a job
```powershell
Get-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01
```
```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs c3e34ed5-4f82-482e-a4a4-25520ca89098
```

This command returns information about the input named EntryStream defined on the job StreamingJob.

### Example 3: Get information about a specific input defined on a job by pipeline
```powershell
New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name input-05 -File .\test\template-json\IotHub.json | Get-AzStreamAnalyticsInput
```
```output
Name     Type                                           ETag
----     ----                                           ----
input-05 Microsoft.StreamAnalytics/streamingjobs/inputs abb81160-d9e1-4729-9b3a-5af04bd880c6
```

This command returns information about the input named EntryStream defined on the job StreamingJob.
