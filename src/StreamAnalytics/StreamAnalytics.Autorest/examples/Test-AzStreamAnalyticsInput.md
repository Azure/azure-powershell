### Example 1: Test the connection status of an input
```powershell
PS C:\> Test-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01

Status
------
TestSucceeded
```

This command tests the connection status of the input in streaming job.
