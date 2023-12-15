### Example 1: Remove a Stream Analytics input
```powershell
Remove-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01

```

This command removes the input from the job.

### Example 2: Remove a Stream Analytics input by pipeline
```powershell
Get-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 | Remove-AzStreamAnalyticsInput

```

This command removes the input from the job by pipeline.
