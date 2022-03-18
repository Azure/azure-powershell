### Example 1: Stop a continuous web job for an app
```powershell
PS C:\> Stop-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01

```

This command stops a continuous web job for an app.

### Example 2: Stop a continuous web job for an app by pipeline
```powershell
PS C:\> Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01 | Stop-AzWebAppContinuousWebJob

```

This command stops a continuous web job for an app by pipeline.