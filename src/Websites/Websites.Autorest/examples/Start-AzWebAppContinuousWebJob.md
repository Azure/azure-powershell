### Example 1: Start a continuous web job for an app
```powershell
PS C:\> Start-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01

```

This command starts a continuous web job for an app.

### Example 2: Start a continuous web job for an app by pipeline
```powershell
PS C:\> Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01 | Start-AzWebAppContinuousWebJo

```

This command starts a continuous web job for an app by pipeline.