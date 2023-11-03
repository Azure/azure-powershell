### Example 1: Start a Stream Analytics job
```powershell
Start-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-portal

```

This command starts the job StreamingJob.

### Example 2: Start a Stream Analytics job by pipeline
```powershell
Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-portal | Start-AzStreamAnalyticsJob

```

This command starts the job StreamingJob by pipeline.