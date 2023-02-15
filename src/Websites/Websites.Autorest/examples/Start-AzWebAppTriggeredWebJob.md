### Example 1: Run a triggered web job for an app
```powershell
PS C:\> Start-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01

```

This command runs a triggered web job for an app.

### Example 2: Run a triggered web job for an app by pipeline
```powershell
PS C:\> Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01 | Start-AzWebAppTriggeredWebJob

```

This command runs a triggered web job for an app by pipeline.