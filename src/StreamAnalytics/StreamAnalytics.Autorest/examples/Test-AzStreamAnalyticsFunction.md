### Example 1: Test a Stream Analytics function
```powershell
Test-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name mlsfunction-01
```
```output
Status
------
TestSucceeded
```

This command tests the connection status of the function in streaming job.

