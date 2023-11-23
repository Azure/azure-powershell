### Example 1: Remove a Stream Analytics output
```powershell
PS C:\> Remove-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name output-01

```

This command removes the output from the job.

### Example 2: Remove a Stream Analytics output by pipeline
```powershell
PS C:\> Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name output-01 | Remove-AzStreamAnalyticsOutput

```

This command removes the output from the job by pipeline.

