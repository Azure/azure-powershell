### Example 1: Remove a stream analytics job
```powershell
PS C:\> Remove-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-pwsh

```

This command removes the stream analytics job.

### Example 2: Remove a stream analytics job by pipeline
```powershell
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-02-pwsh | Remove-AzStreamAnalyticsJob

```

This command removes the stream analytics job by pipeline.

