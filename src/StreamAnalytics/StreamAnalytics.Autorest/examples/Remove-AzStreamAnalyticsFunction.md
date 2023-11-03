### Example 1: Remove a Stream Analytics function
```powershell
Remove-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01

```

This command removes the function from the job.

### Example 2: Remove a Stream Analytics function by pipeline
```powershell
Get-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-02 | Remove-AzStreamAnalyticsFunction

```

This command removes the function from the job by pipeline.
