### Example 1: Stop a Stream Analytics job
```powershell
PS C:\> Stop-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-portal

```

This command stops the job StreamingJob.

### Example 2: Stop a Stream Analytics job by pipeline
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-portal | Stop-AzStreamAnalyticsJob

```

This command stops the job StreamingJob by pipeline.
