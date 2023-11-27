### Example 1: Test the connection status of an output
```powershell
PS C:\> Test-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name output-01

Status
------
TestSucceeded
```

This command tests the connection status of the output in streaming job.
